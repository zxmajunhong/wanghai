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

namespace EtNet_Web.Pages.Statistical.CollectCount
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static string thissqlstr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBulider();
                LoadData();
            }
        }


        private void QueryBulider()
        {
            if (Session["CollectDetailQuery"] == null)
            {
                Session["CollectDetailQuery"] = "";
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string unitID = Request.QueryString["unit"]; //收款单位id
            string sqlstr = " and iscancel = 'N' ";
            sqlstr += this.cbxFileShow.Checked ? "" : " and fileStatus=0 ";
            sqlstr += " and cusId=" + unitID;
            sqlstr += Session["CollectDetailQuery"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 033);
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("View_OrderAndClollect", sqlstr);
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
            DataTable dt = data.GetList("View_OrderAndClollect", "outTime", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            rptdata.DataSource = dt;
            rptdata.DataBind();
            thissqlstr = sqlstr + " order by outTime desc";

            //计算金额合计
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("select sum(money) as shouldAmount,sum(collectAmount) as collectAmount,sum(syAmount) as syAmount ");
            string tblname = "View_OrderAndClollect";
            DataTable dtSum = data.GetSumMoney(sqlSelect.ToString(), tblname, sqlstr);
            if (dtSum.Rows.Count > 0)
            {
                DataRow dr = dtSum.Rows[0];
                shouldamount.InnerText = Convert.IsDBNull(dr["shouldAmount"]) ? "" : Convert.ToDouble(dr["shouldAmount"]).ToString("N2");
                hasamount.InnerText = Convert.IsDBNull(dr["collectAmount"]) ? "" : Convert.ToDouble(dr["collectAmount"]).ToString("N2");
                syamount.InnerText = Convert.IsDBNull(dr["syAmount"]) ? "" : Convert.ToDouble(dr["syAmount"]).ToString("N2");
            }

            /*计算人数合计*/
            StringBuilder sqlNumSelect = new StringBuilder();
            sqlNumSelect.AppendFormat("select sum(adultNum) as adultNumAmount,sum(childNum) as childNumAmount,sum(withNum) as withNumAmount ");
            DataTable dtNum = data.GetSumMoney(sqlNumSelect.ToString(), tblname, sqlstr);
            if (dtNum.Rows.Count > 0)
            {
                DataRow dr = dtNum.Rows[0];
                adultNum.InnerText = Convert.IsDBNull(dr["adultNumAmount"]) ? "" : Convert.ToDouble(dr["adultNumAmount"]).ToString("N0");
                childNum.InnerText = Convert.IsDBNull(dr["childNumAmount"]) ? "" : Convert.ToDouble(dr["childNumAmount"]).ToString("N0");
                withNum.InnerText = Convert.IsDBNull(dr["withNumAmount"]) ? "" : Convert.ToDouble(dr["withNumAmount"]).ToString("N0");
            }

            //double a = 0;
            //double b = 0;
            //double c = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    a += Convert.IsDBNull(dt.Rows[i]["money"]) ? 0 : Convert.ToDouble(dt.Rows[i]["money"]);
            //    b += Convert.IsDBNull(dt.Rows[i]["collectAmount"]) ? 0 : Convert.ToDouble(dt.Rows[i]["collectAmount"]);
            //    c += ((Convert.IsDBNull(dt.Rows[i]["money"]) ? 0 : Convert.ToDouble(dt.Rows[i]["money"])) - (Convert.IsDBNull(dt.Rows[i]["collectAmount"]) ? 0 : Convert.ToDouble(dt.Rows[i]["collectAmount"])));
            //}
            //this.shouldamount.InnerText = a.ToString("F2");
            //this.hasamount.InnerText = b.ToString("F2");
            //this.syamount.InnerText = c.ToString("F2");
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();
            if (txtordernum.Value != "")
            {
                sqlstr.Append(" and orderNum like '%" + txtordernum.Value.Trim() + "%'");
            }
            if (txtdepartname.Value != "")
            {
                sqlstr.Append(" and departName like '%" + txtdepartname.Value.Trim() + "%'");
            }
            if (txtlinkname.Value != "")
            {
                sqlstr.Append(" and linkname like '%" + txtlinkname.Value.Trim() + "%'");
            }
            if (txtremark.Value != "")
            {
                sqlstr.Append(" and remark like '%" + txtremark.Value.Trim() + "%'");
            }
            if (ddlCollectStatus.SelectedIndex != 0)
            {
                sqlstr.Append(" and collectStatus='" + ddlCollectStatus.SelectedValue + "'");
            }
            if (ddlCollectMoney.SelectedIndex != 0)
            {
                switch (ddlCollectMoney.SelectedValue)
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
            Session["CollectDetailQuery"] = sqlstr;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadData();
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
            txtdepartname.Value = "";
            txtlinkname.Value = "";
            txtremark.Value = "";
            ddlRequestDate.SelectedIndex = -1;
            hidsort.Value = "";
            hidDateValue.Value = "";
            ddlCollectStatus.SelectedIndex = 0;
            ddlCollectMoney.SelectedIndex = 0;
            Session["CollectDetailQuery"] = "";
            LoadData();
        }

        protected void imgreturn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CollectAmountList.aspx");

        }

        #region 收款方式的转换
        /// <summary>
        /// 收款方式
        /// </summary>
        /// <param name="pay"></param>
        /// <returns></returns>
        public string getPayModel(object pay)
        {
            switch (pay.ToString())
            {
                case "0":
                    return "现金";
                case "1":
                    return "转账";
                case "2":
                    return "网银";
                default:
                    return "参数错误";
            }
        }
        #endregion

        #region 日期转换方法
        /// <summary>
        /// 日期转换方法
        /// </summary>
        /// <param name="LongDatetime"></param>
        /// <returns></returns>
        public string ConvertToShort(string LongDatetime)
        {
            DateTime dt = Convert.ToDateTime(LongDatetime);
            return dt.ToString("yyyy-MM-dd");
        }
        #endregion

        /// <summary>
        /// 得到剩余金额
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public string getSyMoney(object o1, object o2)
        {
            double money = 0;
            double hasmoney = 0;
            double.TryParse(o1.ToString(), out money);
            double.TryParse(o2.ToString(), out hasmoney);
            return (money - hasmoney).ToString("F2");
        }

        /// <summary>
        /// 得到已经收款的明细数据
        /// </summary>
        /// <param name="ordercollectid"></param>
        /// <returns></returns>
        public string getHasCollectDetail(object ordercollectid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' >");
            str.Append("<tr><th width='90px'>收款日期</th><th width='200px'>收款单位</th><th width='70px'>收款金额</th><th width='70px'>收款方式</th><th width='70px'>总金额</th><th width='200px'>银行名称</th><th width='200px'>备注</th></tr>");
            DataTable dt = new To_ClaimDetailManager().GetCollectDetail(" orderCollectId =" + ordercollectid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double money = Convert.IsDBNull(dt.Rows[i]["realAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["realAmount"]);
                str.Append("<tr><td>" + Convert.ToDateTime(dt.Rows[i]["receiptDate"]).ToString("yyyy-MM-dd") + "</td>"); //收款日期
                str.Append("<td>" + dt.Rows[i]["payer"].ToString() + "</td>"); //收款单位
                str.Append("<td>" + money.ToString("F2") + "</td>"); //收款金额
                str.Append("<td>" + getPayModel(dt.Rows[i]["paymentMode"]) + "</td>"); //收款方式
                str.Append("<td>" + Convert.ToDouble(dt.Rows[i]["receiptAmount"]).ToString("F2") + "</td>"); //总金额
                str.Append("<td>" + dt.Rows[i]["payBank"].ToString() + "</td>"); //银行名称
                str.Append("<td>" + dt.Rows[i]["mark"].ToString() + "</td></tr>"); //备注
            }
            str.Append("</table>");
            return str.ToString();
        }

        protected void cbxFileShow_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
	
	/// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="dt">所要导出的数据</param>
	/// <param name="tablename">标题</param>
        /// <returns></returns>
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


            //Range range = worksheet.Cells.CreateRange(0, 0, 1, 6);
            //range.Merge();
            //Cell cell = range[0, 0];
            //cell.PutValue("测试导出数据");

            //Aspose.Cells.Style style = new Aspose.Cells.Style();
            //style.Font.Name = "楷体";
            //style.VerticalAlignment = TextAlignmentType.Center;
            //style.HorizontalAlignment = TextAlignmentType.Center;
            //style.Font.Size = 18;
            //style.Font.Color = System.Drawing.Color.Blue;
            //style.BackgroundColor = System.Drawing.Color.Gray;
            //cell.SetStyle(style);
            //datatable.Columns.Add("测试1", typeof(string));
            //datatable.Columns.Add("测试2", typeof(string));
            //datatable.Columns.Add("测试3", typeof(string));
            //datatable.Columns.Add("测试4", typeof(string));
            //datatable.Columns.Add("测试5", typeof(string));
            //datatable.Columns.Add("测试6", typeof(string));
            //for (int i = 0; i < 6; i++)
            //{
            //    DataRow dr = datatable.NewRow();
            //    dr[0] = datatable.Columns[i].ColumnName + "_" + i;
            //    dr[1] = datatable.Columns[i].ColumnName + "_" + i;
            //    dr[2] = datatable.Columns[i].ColumnName + "_" + i;
            //    dr[3] = datatable.Columns[i].ColumnName + "_" + i;
            //    dr[4] = datatable.Columns[i].ColumnName + "_" + i;
            //    dr[5] = datatable.Columns[i].ColumnName + "_" + i;

            //    datatable.Rows.Add(dr);
            //}
            //worksheet.Cells.ImportDataTable(datatable, true, "A2");

            worksheet.AutoFitColumns();
            worksheet.AutoFitRows();
            workbook.Save(Response, DateTime.Now.ToString("yyyy-MM-dd") + ".xls", ContentDisposition.Attachment, workbook.SaveOptions);
        }

        protected void ibtexport_Click(object sender, ImageClickEventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("订单编号", typeof(string));
            //dt.Columns.Add("出团日期", typeof(string));
            //dt.Columns.Add("联系人", typeof(string));
            //dt.Columns.Add("成人数", typeof(string));
            //dt.Columns.Add("儿童数", typeof(string));
            //dt.Columns.Add("陪同数", typeof(string));
            //dt.Columns.Add("应收金额", typeof(string));
            //dt.Columns.Add("已收金额", typeof(string));
            //dt.Columns.Add("未收金额", typeof(string));
            //dt.Columns.Add("收款状态", typeof(string));
            //dt.Columns.Add("备注", typeof(string));
            Data data = new Data();
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("select orderNum as 订单编号,CONVERT(varchar(50),convert(date,outTime)) as 出团日期,departName as 营业部,linkname as 联系人,adultNum as 成人数,childNum as 儿童数,withNum as 陪同,convert(varchar(50), money) as 应收金额,convert(varchar(50),collectAmount) as 已收金额,convert(varchar(50),syAmount) as 未收金额,collectStatus as 收款状态,remark as 备注");
            DataTable dt = data.GetSumMoney(sqlSelect.ToString(), "View_OrderAndClollect", thissqlstr).Copy();
            //增加合计行
            DataRow dr = dt.NewRow();
            dr[0] = "合计";
            dr[4] = adultNum.InnerText;
            dr[5] = childNum.InnerText;
            dr[6] = withNum.InnerText;
            dr[7] = shouldamount.InnerText;
            dr[8] = hasamount.InnerText;
            dr[9] = syamount.InnerText;
            dt.Rows.Add(dr);
            string unitId = Request.QueryString["unit"];
            string cusshortname = CustomerManager.getCustomerById(int.Parse(unitId)).CusshortName;
            Export(dt, cusshortname + "_应收款汇总表");
        }
    }
}