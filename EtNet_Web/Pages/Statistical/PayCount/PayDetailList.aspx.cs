using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;
using System.Text;
using Aspose.Cells;

namespace EtNet_Web.Pages.Statistical.PayCount
{
    public partial class PayDetailList : System.Web.UI.Page
    {
        public static string thissqlstr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBulider();
                loadPayItem();
                loadInputer();
                LoadData();
            }
        }

        private void QueryBulider()
        {
            if (Session["payDetailQuery"] == null)
            {
                Session["payDetailQuery"] = "";
            }
        }

        /// <summary>
        /// 加载付款类别
        /// </summary>
        private void loadPayItem()
        {
            this.ddlPayItem.Items.Clear();
            this.ddlPayItem.Items.Add(new ListItem("——请选择——", ""));
            DataTable dt = AusFinInfoManager.GetList("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Text = dt.Rows[i]["itemname"].ToString();
                adItem.Value = dt.Rows[i]["itemname"].ToString();
                this.ddlPayItem.Items.Add(adItem);
            }
            this.ddlPayItem.Items.Add(new ListItem("订单退款", "订单退款"));
        }

        /// <summary>
        /// 加载操作人员信息
        /// </summary>
        private void loadInputer()
        {
            ddlInputer.Items.Clear();
            ddlInputer.Items.Add(new ListItem("——请选择——", ""));
            IList<LoginInfo> list = LoginInfoManager.getLoginInfoAll();
            foreach (LoginInfo login in list)
            {
                ListItem adItem = new ListItem();
                adItem.Text = login.Cname;
                adItem.Value = login.Id.ToString();
                ddlInputer.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string unitID = Request.QueryString["unit"]; //付款单位id
            string sqlstr = " and iscancel = 'N' ";
            sqlstr += this.cbxFileShow.Checked ? "" : " and fileStatus=0 ";
            sqlstr += " and factid=" + unitID;
            sqlstr += Session["payDetailQuery"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 033);
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("View_OrderPayAndReturn", sqlstr);
            if (sps == null)
            {
                AspNetPager1.NumericButtonCount = 10;
                AspNetPager1.PageSize = 10;
            }
            else
            {
                AspNetPager1.NumericButtonCount = sps.Pagecount;
                AspNetPager1.PageSize = sps.Pageitem;
            }
            DataTable dt = data.GetList("View_OrderPayAndReturn", "outTime", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            rptdata.DataSource = dt;
            rptdata.DataBind();
            thissqlstr = sqlstr + " order by outTime desc";

            //计算金额合计
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("select sum(money) as shouldAmount,sum(payAmount) as payAmount,sum(syAmount) as syAmount ");
            string tblname = "View_OrderPayAndReturn";
            DataTable dtSum = data.GetSumMoney(sqlSelect.ToString(), tblname, sqlstr);
            if (dtSum.Rows.Count > 0)
            {
                DataRow dr = dtSum.Rows[0];
                shouldamount.InnerText = Convert.IsDBNull(dr["shouldAmount"]) ? "" : Convert.ToDouble(dr["shouldAmount"]).ToString("N2");
                hasamount.InnerText = Convert.IsDBNull(dr["payAmount"]) ? "" : Convert.ToDouble(dr["payAmount"]).ToString("N2");
                syamount.InnerText = Convert.IsDBNull(dr["syAmount"]) ? "" : Convert.ToDouble(dr["syAmount"]).ToString("N2");
            }

        }

        /// <summary>
        /// 得到支付状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string getStatus(object status)
        {
            string result = "";
            switch (status.ToString())
            {
                case "完成付款":
                    result = "<font color='green'>完成付款</font>";
                    break;
                case "部分付款":
                    result = "<font color='blue'>部分付款</font>";
                    break;
                case "未付款":
                    result = "<font color='red'>未付款</font>";
                    break;
                case "完成退款":
                    result = "<font color='green'>完成退款</font>";
                    break;
                case "部分退款":
                    result = "<font color='blue'>部分退款</font>";
                    break;
                case "未退款":
                    result = "<font color='red'>未退款</font>";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();
            //if (txtunit.Value != "")
            //{
            //    sqlstr.Append("and payerName like '%" + txtunit.Value.Trim() + "%'");
            //}
            if (txtordernum.Value != "")
            {
                sqlstr.Append(" and orderNum like '%" + this.txtordernum.Value.Trim() + "%'");
            }

            if (ddlPayItem.SelectedValue != "")
            {
                sqlstr.Append(" and payType ='" + ddlPayItem.SelectedValue + "'");
            }
            if (txtlinkname.Value != "")
            {
                sqlstr.Append(" and linkName like '%" + this.txtlinkname.Value.Trim() + "%'");
            }
            if (txtremark.Value != "")
            {
                sqlstr.Append(" and remark like '%" + txtremark.Value.Trim() + "%'");
            }
            if (ddlInputer.SelectedValue != "")
            {
                sqlstr.Append(" and inputerID =" + ddlInputer.SelectedValue);
            }
            if (ddlPayStatus.SelectedValue != "")
            {
                sqlstr.Append(" and payStatus='" + ddlPayStatus.SelectedValue + "'");
            }
            if (ddlNoPayAmount.SelectedValue != "")
            {
                switch (ddlNoPayAmount.SelectedValue)
                {
                    case "1":
                        sqlstr.Append(" and syAmount < 10000 ");
                        break;
                    case "2":
                        sqlstr.Append(" and ( syAmount >= 10000 and syAmount <= 50000 ) ");
                        break;
                    case "3":
                        sqlstr.Append(" and ( syAmount >= 50000 and syAmount <= 100000) ");
                        break;
                    case "4":
                        sqlstr.Append(" and syAmount > 100000 ");
                        break;
                    default:
                        break;
                }
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');
                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" and ( outTime >= '{0} ' and outTime <= '{1}' ) ", list[0].Trim(), list[1].Trim());

                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" AND outTime >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" AND outTime <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND outTime < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }
            Session["payDetailQuery"] = sqlstr;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadData();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            txtordernum.Value = "";
            ddlPayItem.SelectedIndex = 0;
            txtlinkname.Value = "";
            txtremark.Value = "";
            ddlRequestDate.SelectedIndex = -1;
            hidsort.Value = "";
            hidDateValue.Value = "";
            ddlInputer.SelectedIndex = 0;
            ddlPayStatus.SelectedIndex = 0;
            ddlNoPayAmount.SelectedIndex = 0;
            Session["payDetailQuery"] = "";
            LoadData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void imgreturn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PayAmountList.aspx");
        }

        /// <summary>
        /// 得到支付日期（未财务登记的支付日期为空）
        /// </summary>
        /// <param name="objdate"></param>
        /// <param name="regtype"></param>
        /// <returns></returns>
        public string paymentDate(object objdate, object regtype)
        {
            if (regtype.ToString() == "1")
            {
                return Convert.ToDateTime(objdate).ToString("yyyy-MM-dd");
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 得到剩余支付金额
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public string getSyMoney(object o1, object o2)
        {
            double money = 0;
            double hasAmount = 0;
            double.TryParse(o1.ToString(), out money);
            double.TryParse(o2.ToString(), out hasAmount);
            return (money - hasAmount).ToString("F2");
        }

        /// <summary>
        /// 得到已经支付的付款明细数据
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        public string getHasPayDetail(object detailId, object item)
        {
            StringBuilder str = new StringBuilder();
            switch (item.ToString())
            {
                case "0":
                    str.Append("<table border='1'>");
                    str.Append("<tr><th width='70px'>财务登记</th><th width='80px'>支付日期</th><th width='200px'>支付单位</th><th width='70px'>应付金额</th><th width='70px'>支付金额</th><th width='70px'>总金额</th><th width='80px'>支付方式</th><th width='180px'>备注</th></tr>");
                    DataTable dt = new To_PaymentDetailManager().GetPayDetail(" orderPayId =" + detailId);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        double money = Convert.IsDBNull(dt.Rows[i]["shouldPay"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["shouldPay"]);
                        double hasAmount = Convert.IsDBNull(dt.Rows[i]["payAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["payAmount"]);
                        str.Append(dt.Rows[i]["regType"].ToString() == "1" ? "<tr><td>已登记" : "<tr><td>未登记" + "</td>"); //财务登记
                        str.Append("<td>" + paymentDate(dt.Rows[i]["paymentDate"], dt.Rows[i]["regType"]) + "</td>"); //支付日期
                        str.Append("<td>" + dt.Rows[i]["payerName"].ToString() + "</td>"); //支付单位
                        str.Append("<td>" + money.ToString("F2") + "</td>"); //应付金额
                        str.Append("<td>" + hasAmount.ToString("F2") + "</td>"); //支付金额
                        str.Append("<td>" + Convert.ToDouble(dt.Rows[i]["totalAmount"]).ToString("F2") + "</td>"); //总金额
                        str.Append("<td>" + dt.Rows[i]["payType"].ToString() + "</td>"); //支付方式
                        str.Append("<td>" + dt.Rows[i]["payRemark"].ToString() + "</td></tr>"); //支付备注

                    }
                    str.Append("</table>");
                    break;
                case "1":
                    str.Append("<table border='1'>");
                    str.Append("<tr><th width='70px'>财务登记</th><th width='80px'>退款日期</th><th width='200px'>退款单位</th><th width='70px'>应退金额</th><th width='70px'>已退金额</th><th width='70px'>总金额</th><th width='80px'>支付方式</th><th width='180px'>备注</th></tr>");
                    DataTable dt1 = To_PaymentReturnManager.GetReturnDetail(" orderRetID =" + detailId);
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        double money = Convert.IsDBNull(dt1.Rows[i]["shouldReturn"])?0.0:Convert.ToDouble(dt1.Rows[i]["shouldReturn"]);
                        double hasAmount = Convert.IsDBNull(dt1.Rows[i]["returnAmount"]) ? 0.0 : Convert.ToDouble(dt1.Rows[i]["returnAmount"]);
                        str.Append(dt1.Rows[i]["regType"].ToString() == "1" ? "<tr><td>已登记" : "<tr><td>未登记" + "</td>"); //财务登记
                        str.Append("<td>" + paymentDate(dt1.Rows[i]["paymentDate"], dt1.Rows[i]["regType"]) + "</td>"); //支付日期
                        str.Append("<td>" + dt1.Rows[i]["payerName"].ToString() + "</td>"); //支付单位
                        str.Append("<td>" + money.ToString("F2") + "</td>"); //应付金额
                        str.Append("<td>" + hasAmount.ToString("F2") + "</td>"); //支付金额
                        str.Append("<td>" + Convert.ToDouble(dt1.Rows[i]["totalAmount"]).ToString("F2") + "</td>"); //总金额
                        str.Append("<td>" + dt1.Rows[i]["payType"].ToString() + "</td>"); //支付方式
                        str.Append("<td>" + dt1.Rows[i]["payRemark"].ToString() + "</td></tr>"); //支付备注
                    }
                    str.Append("</table>");
                    break;
            }

            return str.ToString();
        }

        protected void cbxFileShow_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Export(DataTable dt, string tablename)
        {
            Workbook workbook = new Workbook();//工作簿
            Worksheet worksheet = workbook.Worksheets[0];//工作表
            Cells cells = worksheet.Cells; //单元格集合
            //为表名设置样式
            Aspose.Cells.Style styleTablename = workbook.Styles[workbook.Styles.Add()]; //新增样式
            styleTablename.HorizontalAlignment = TextAlignmentType.Center; //文字居中
            styleTablename.Font.Name = "宋体"; //文字字体
            styleTablename.Font.Size = 22; //文字大小
            styleTablename.Font.IsBold = true;

            //为标题设置样式
            Aspose.Cells.Style styleTitle = workbook.Styles[workbook.Styles.Add()]; //
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;
            styleTitle.Font.Name = "宋体";
            styleTitle.Font.Size = 12;
            styleTitle.Font.IsBold = true;

            styleTitle.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            styleTitle.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            styleTitle.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            styleTitle.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //为内容设置样式
            Aspose.Cells.Style styleBody = workbook.Styles[workbook.Styles.Add()];
            styleBody.HorizontalAlignment = TextAlignmentType.Center;
            styleTitle.Font.Name = "宋体";
            styleBody.Font.Size = 9;
            styleBody.IsTextWrapped = true;
            styleBody.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            styleBody.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            styleBody.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            styleBody.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;


            int colnum = dt.Columns.Count; //表格列数
            int rownum = dt.Rows.Count; //表格行数

            //生成行1标题行
            cells.Merge(0, 0, 1, colnum); //合并单元格
            cells[0, 0].PutValue(tablename);
            cells[0, 0].SetStyle(styleTablename);

            //填充数据
            cells.ImportDataTable(dt, true, "A2");

            //设置列名的样式
            Range rangeTitle = cells.CreateRange(1, 0, 1, colnum);
            rangeTitle.ApplyStyle(styleTitle, new StyleFlag() { All = true });

            Range rangeBody = cells.CreateRange(2, 0, rownum, colnum);
            rangeBody.ApplyStyle(styleBody, new StyleFlag() { All = true });

            worksheet.AutoFitColumns();
            worksheet.AutoFitRows();
            workbook.Save(Response, DateTime.Now.ToString("yyyy-MM-dd") + ".xls", ContentDisposition.Attachment, workbook.SaveOptions);
        }

        protected void ibtexport_Click(object sender, ImageClickEventArgs e)
        {
            Data data = new Data();
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("select orderNum as 订单编号,CONVERT(varchar(50),convert(date,outTime)) as 出团日期,payType as 付款类别,linkName as 联系人,inputer as 操作人,convert(varchar(50), money) as 应付金额,convert(varchar(50),payAmount) as 已付金额,convert(varchar(50),syAmount) as 未付金额,payStatus as 付款状态,remark as 备注");
            DataTable dt = data.GetSumMoney(sqlSelect.ToString(), "View_OrderPayAndReturn", thissqlstr).Copy();
            //增加合计行
            DataRow dr = dt.NewRow();
            dr[0] = "合计";
            dr[5] = shouldamount.InnerText;
            dr[6] = hasamount.InnerText;
            dr[7] = syamount.InnerText;
            dt.Rows.Add(dr);
            string unitID = Request.QueryString["unit"];
            string payshortname = FactoryManager.getFactoryById(int.Parse(unitID)).FactshortName;
            Export(dt, payshortname + "_应付款汇总表");
        }
    }
}