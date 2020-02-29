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
using System.Diagnostics;

namespace EtNet_Web.Pages.Statistical.Grossprofit
{
    public partial class GrossList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLine();
                BindInputer();
                QueryBulider();
                LoadData();
            }
        }

        /// <summary>
        /// 绑定线路
        /// </summary>
        private void BindLine()
        {
            ddlline.Items.Clear();
            IList<Tb_line> linelist = Tb_lineManager.getTb_lineAll();
            ddlline.Items.Add(new ListItem("选择线路", "-1")); //添加第一行默认
            foreach (Tb_line line in linelist)
            {
                ListItem adItem = new ListItem();
                adItem.Text = line.Line;
                adItem.Value = line.Line;
                ddlline.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 绑定操作人员
        /// </summary>
        private void BindInputer()
        {
            ddlinputer.Items.Clear();
            IList<LoginInfo> loginlist = LoginInfoManager.getLoginInfoAll();
            ddlinputer.Items.Add(new ListItem("选择人员", "-1"));
            foreach (LoginInfo login in loginlist)
            {
                ListItem adItem = new ListItem();
                adItem.Text = login.Cname;
                adItem.Value = login.Id.ToString();
                ddlinputer.Items.Add(adItem);
            }
        }


        /// <summary>
        /// 初始化筛选条件
        /// </summary>
        private void QueryBulider()
        {
            if (Session["orderGrossQuery"] == null)
            {
                Session["orderGrossQuery"] = getCurYearFilter();
            }
        }

        /// <summary>
        /// 获取当前年份的筛选条件
        /// </summary>
        /// <returns></returns>
        private string getCurYearFilter()
        {
            int year = DateTime.Now.Year;
            string filter = " and (outTime >= '" + year.ToString() + "-01-01 00:00:00' and outTime <= '" + year.ToString() + "-12-31 23:59:59')";
            return filter;
        }

        private static DataTable orderGrossList;

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            Stopwatch stpwth = new Stopwatch();
            stpwth.Start();
            string sqlstr = " and iscancel = 'N' ";
            sqlstr += this.cbxFileShow.Checked ? "" : " and fileStatus=0 ";
            sqlstr += Session["orderGrossQuery"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 036);

            // 20200226优化毛利表打不开，将直接查询视图数据，改为查询出来数据后程序做统计 ViewOrderGrossList 这张视图不用了
            Data data = new Data();
            // 配置分页信息 分页用程序分页了，不通过数据库查询
            AspNetPager1.RecordCount = data.GetCount("ViewOrder", sqlstr);
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
            // 获取指定条件的所有订单信息
            DataTable orderTbl = To_OrderInfoManager.GetTableInfo("ViewOrder", "orderNum,id,outTime,teamNum,natrue,gross,codenum,auditstutastxt,line,iscancel,inputer,inputerID,departautocode,fileStatus", sqlstr + "order by outTime asc");

            // 订单支付信息
            DataTable payTbl = To_OrderInfoManager.GetTableInfo("ViewOrderPayMoney", "orderid,money,payAmount,syAmount", "and orderid in (select id from ViewOrder where 1=1 " + sqlstr + ")");

            // 订单收款信息
            DataTable colTbl = To_OrderInfoManager.GetTableInfo("ViewOrderCollectMoney", "orderid,money,collectAmount,syAmount,collectStatus", "and orderid in (select id from ViewOrder where 1=1 " + sqlstr + ")");

            // 订单退款信息
            DataTable refuTbl = To_OrderInfoManager.GetTableInfo("ViewOrderRefuMoney", "orderid,money,refundAmount,syAmount", "and orderid in (select id from ViewOrder where 1=1 " + sqlstr + ")");

            // 订单报销信息
            DataTable reimTbl = To_OrderInfoManager.GetTableInfo("ViewOrderReimMoney", "orderId,totalmoney", "and orderid in (select id from ViewOrder where 1=1 " + sqlstr + ")");

            // 付款信息的key-value
            Dictionary<string, DataRow> payMap = new Dictionary<string, DataRow>();
            for (int i = 0; i < payTbl.Rows.Count; i++)
            {
                payMap.Add(payTbl.Rows[i]["orderid"].ToString(), payTbl.Rows[i]);
            }

            // 收款信息的key-value
            Dictionary<string, DataRow> colMap = new Dictionary<string, DataRow>();
            for (int i = 0; i < colTbl.Rows.Count; i++)
            {
                colMap.Add(colTbl.Rows[i]["orderid"].ToString(), colTbl.Rows[i]);
            }

            // 退款信息的key-value
            Dictionary<string, DataRow> refuMap = new Dictionary<string, DataRow>();
            for (int i = 0; i < refuTbl.Rows.Count; i++)
            {
                refuMap.Add(refuTbl.Rows[i]["orderid"].ToString(), refuTbl.Rows[i]);
            }

            // 报销信息的key-value
            Dictionary<string, DataRow> reimMap = new Dictionary<string, DataRow>();
            for (int i = 0; i < reimTbl.Rows.Count; i++)
            {
                reimMap.Add(reimTbl.Rows[i]["orderId"].ToString(), reimTbl.Rows[i]);
            }

            // 合计信息
            double collectShouldSum = 0, collectAmountSum = 0, collectSySum = 0, payShouldSum = 0, payAmountSum = 0, paySySum = 0, refuShouldSum = 0, refundAmountSum = 0, refuSySum = 0, reimShouldSum = 0, grossBxSum=0;

            // 生成最终的毛利表信息
            orderTbl.Columns.Add("payShould");
            orderTbl.Columns.Add("payAmount");
            orderTbl.Columns.Add("paySy");
            orderTbl.Columns.Add("collectShould");
            orderTbl.Columns.Add("collectAmount");
            orderTbl.Columns.Add("collectSy");
            orderTbl.Columns.Add("collectStatus");
            orderTbl.Columns.Add("refuShould");
            orderTbl.Columns.Add("refundAmount");
            orderTbl.Columns.Add("refuSy");
            orderTbl.Columns.Add("reimShould");
            orderTbl.Columns.Add("gross_bx");
            for (int i = 0; i < orderTbl.Rows.Count; i++)
            {
                string orderId = orderTbl.Rows[i]["id"].ToString();
                double gross_bx = 0;
                if (payMap.ContainsKey(orderId))
                {
                    DataRow payRow = payMap[orderId];

                    orderTbl.Rows[i]["payShould"] = payRow["money"]; // 应付款
                    orderTbl.Rows[i]["payAmount"] = payRow["payAmount"]; // 付款合计
                    orderTbl.Rows[i]["paySy"] = payRow["syAmount"]; // 付款剩余
                    payShouldSum += Convert.IsDBNull(payRow["money"]) ? 0 : Convert.ToDouble(payRow["money"]);
                    payAmountSum += Convert.IsDBNull(payRow["payAmount"]) ? 0 : Convert.ToDouble(payRow["payAmount"]);
                    paySySum += Convert.IsDBNull(payRow["syAmount"]) ? 0 : Convert.ToDouble(payRow["syAmount"]);
                    gross_bx -= Convert.IsDBNull(payRow["money"]) ? 0 : Convert.ToDouble(payRow["money"]);

                }
                if (colMap.ContainsKey(orderId))
                {
                    DataRow colRow = colMap[orderId];

                    orderTbl.Rows[i]["collectShould"] = colRow["money"]; // 应收款
                    orderTbl.Rows[i]["collectAmount"] = colRow["collectAmount"]; // 收款合计
                    orderTbl.Rows[i]["collectSy"] = colRow["syAmount"]; // 收款剩余
                    orderTbl.Rows[i]["collectStatus"] = colRow["collectStatus"]; // 收款状态
                    collectShouldSum += Convert.IsDBNull(colRow["money"]) ? 0 : Convert.ToDouble(colRow["money"]);
                    collectAmountSum += Convert.IsDBNull(colRow["collectAmount"]) ? 0 : Convert.ToDouble(colRow["collectAmount"]);
                    collectSySum += Convert.IsDBNull(colRow["syAmount"]) ? 0 : Convert.ToDouble(colRow["syAmount"]);
                    gross_bx += Convert.IsDBNull(colRow["money"]) ? 0 : Convert.ToDouble(colRow["money"]);
                }
                if (refuMap.ContainsKey(orderId))
                {
                    DataRow refuRow = refuMap[orderId];
                    orderTbl.Rows[i]["refuShould"] = refuRow["money"]; // 应退款
                    orderTbl.Rows[i]["refundAmount"] = refuRow["refundAmount"]; // 退款合计
                    orderTbl.Rows[i]["refuSy"] = refuRow["syAmount"]; // 退款剩余
                    refuShouldSum += Convert.IsDBNull(refuRow["money"]) ? 0 : Convert.ToDouble(refuRow["money"]);
                    refundAmountSum += Convert.IsDBNull(refuRow["refundAmount"]) ? 0 : Convert.ToDouble(refuRow["refundAmount"]);
                    refuSySum += Convert.IsDBNull(refuRow["syAmount"]) ? 0 : Convert.ToDouble(refuRow["syAmount"]);
                    gross_bx += Convert.IsDBNull(refuRow["money"]) ? 0 : Convert.ToDouble(refuRow["money"]);
                }
                if (reimMap.ContainsKey(orderId))
                {
                    DataRow reimRow = reimMap[orderId];
                    orderTbl.Rows[i]["reimShould"] = reimRow["totalmoney"]; // 应报销款
                    reimShouldSum += Convert.IsDBNull(reimRow["totalmoney"]) ? 0 : Convert.ToDouble(reimRow["totalmoney"]);
                    gross_bx -= Convert.IsDBNull(reimRow["totalmoney"]) ? 0 : Convert.ToDouble(reimRow["totalmoney"]);
                }
                orderTbl.Rows[i]["gross_bx"] = gross_bx;
                grossBxSum += gross_bx;
            }

            orderGrossList = orderTbl;

            // 获取排序后的订单信息数据
            //DataTable dt = data.GetList("ViewOrderGrossList", "id", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            //rpgrossdata.DataSource = dt;
            //rpgrossdata.DataBind();

            //计算金额合计
            scshould.InnerText = collectShouldSum.ToString("N2");
            scamount.InnerText = collectAmountSum.ToString("N2");
            scsy.InnerText = collectSySum.ToString("N2");
            spshould.InnerText = payShouldSum.ToString("N2");
            spamount.InnerText = payAmountSum.ToString("N2");
            spsy.InnerText = paySySum.ToString("N2");
            srshould.InnerText = refuShouldSum.ToString("N2");
            sramount.InnerText = refundAmountSum.ToString("N2");
            srsy.InnerText = refuSySum.ToString("N2");
            sbx.InnerText = reimShouldSum.ToString("N2");
            sml.InnerText = grossBxSum.ToString("N2");
            stpwth.Stop();
            TimeSpan ts = stpwth.Elapsed;
            bindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void bindData()
        {
            int skip = (AspNetPager1.CurrentPageIndex-1) * AspNetPager1.PageSize;
            int surplus = AspNetPager1.RecordCount - skip;
            int take = surplus > AspNetPager1.PageSize ? AspNetPager1.PageSize : surplus;
            
            DataTable dtnew = orderGrossList.AsEnumerable().Skip(skip).Take(take).CopyToDataTable();
            
            rpgrossdata.DataSource = dtnew;
            rpgrossdata.DataBind();
        }

        /// <summary>
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Stopwatch stpwth = new Stopwatch();
            stpwth.Start();
            bindData();
            stpwth.Stop();
            TimeSpan ts = stpwth.Elapsed;
            Console.WriteLine("time" + ts.TotalSeconds);
        }

        /// <summary>
        /// 得到收款明细信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getCollectDetail(object orderid)
        {
            //return "得到收款明细";
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' >");
            str.Append("<tr><th width='200px'>收款单位</th><th width='50px'>成人</th><th width='50px'>儿童</th><th width='50px'>陪同</th><th width='80px'>应收团款</th><th width='80px'>已收团款</th><th width='80px'>未收团款</th><th width='80px'>业务提成</th></tr>");
            DataTable dt = To_OrderCollectDetialManager.getList(int.Parse(orderid.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double money = Convert.IsDBNull(dt.Rows[i]["money"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["money"]);
                double collectAmount = Convert.IsDBNull(dt.Rows[i]["collectAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["collectAmount"]);
                str.Append("<tr><td>" + dt.Rows[i]["cusName"].ToString() + "</td>"); //收款单位
                str.Append("<td>" + dt.Rows[i]["adultNum"].ToString() + "</td>"); //成人数
                str.Append("<td>" + dt.Rows[i]["childNum"].ToString() + "</td>"); //儿童数
                str.Append("<td>" + dt.Rows[i]["withNum"].ToString() + "</td>"); //陪同数
                str.Append("<td>" + money.ToString() + "</td>"); //应收团款
                str.Append("<td>" + collectAmount.ToString() + "</td>"); //已收团款
                str.Append("<td>" + (money - collectAmount).ToString() + "</td>"); //未收团款
                str.Append("<td>" + dt.Rows[i]["cutPayStatus"].ToString() + "</td></tr>"); //业务提成
            }

            str.Append("</table>");

            return str.ToString();
        }

        /// <summary>
        /// 得到付款明细
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getPayDetail(object orderid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' >");
            str.Append("<tr><th width='200px'>付款单位</th><th width='80px'>付款类别</th><th width='80px'>应付金额</th><th width='80px'>已付金额</th><th width='80px'>未付金额</th></tr>");
            DataTable dt = To_OrderPayDetialManager.getList(int.Parse(orderid.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double money = Convert.IsDBNull(dt.Rows[i]["money"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["money"]); //应付金额
                double payAmount = Convert.IsDBNull(dt.Rows[i]["payAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["payAmount"]);
                str.Append("<tr><td>" + dt.Rows[i]["supName"].ToString() + "</td>"); //付款单位
                str.Append("<td>" + dt.Rows[i]["payType"].ToString() + "</td>"); //付款类别
                str.Append("<td>" + money.ToString() + "</td>"); //应付金额
                str.Append("<td>" + payAmount.ToString() + "</td>"); //已付金额
                str.Append("<td>" + (money - payAmount).ToString() + "</td></tr>"); //未付金额
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 得到退款明细
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getRefDetail(object orderid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' >");
            str.Append("<tr><th width='200px'>退款单位</th><th width='80px'>应退金额</th><th width='80px'>已退金额</th><th width='80px'>未退金额</th></tr>");
            DataTable dt = To_OrderRefunDetialManager.getList(int.Parse(orderid.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double money = Convert.IsDBNull(dt.Rows[i]["money"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["money"]);
                double refAmount = Convert.IsDBNull(dt.Rows[i]["refundAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["refundAmount"]);
                str.Append("<tr><td>" + dt.Rows[i]["cusName"].ToString() + "</td>"); //退款单位
                str.Append("<td>" + money.ToString() + "</td>"); //应退金额
                str.Append("<td>" + refAmount.ToString() + "</td>"); //已退金额
                str.Append("<td>" + (money - refAmount).ToString() + "</td>"); //未退金额
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 得到报销明细
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getReimDetail(object orderid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1'>");
            str.Append("<tr><th width='100px'>报销单号</th><th width='80px'>报销金额</th><th width='100px'>项目类别</th></tr>");
            DataTable dt = AusRottenInfoManager.GetViewList("  orderid= " + orderid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str.Append("<tr><td>" + dt.Rows[i]["jobflowcname"].ToString() + "</td>"); //报销单号
                str.Append("<td>" + dt.Rows[i]["totalmoney"].ToString() + "</td>");
                str.Append("<td>" + dt.Rows[i]["itemtype"].ToString() + "</td>");
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            if (txtOrderNum.Value != "")
            {
                sqlstr.Append(" and orderNum like '%" + txtOrderNum.Value + "%'");
            }
            if (ddlline.SelectedIndex != 0)
            {
                sqlstr.Append(" and line ='" + ddlline.SelectedValue + "'");
            }
            if (txtDepart.Value != "")
            {
                sqlstr.Append(" and departautocode like '%" + txtDepart.Value + "%'");
            }
            if (ddlnature.SelectedIndex != 0)
            {
                sqlstr.Append(" and natrue ='" + ddlnature.SelectedValue + "'");
            }
            if (ddlinputer.SelectedIndex != 0)
            {
                sqlstr.Append(" and inputerID =" + ddlinputer.SelectedValue);
            }
            if (ddlcollectstatus.SelectedIndex != 0)
            {
                sqlstr.Append(" and collectStatus = '" + ddlcollectstatus.SelectedValue + "'");
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');
                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime <= '{1}' ) ", list[0].Trim(), list[1].Trim());
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
            else
            {
                sqlstr.AppendFormat(getCurYearFilter());
            }

            Session["orderGrossQuery"] = sqlstr;
        }

        /// <summary>
        /// 筛选
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
            txtOrderNum.Value = "";
            txtDepart.Value = "";
            ddlline.SelectedIndex = 0;
            ddlnature.SelectedIndex = 0;
            ddlinputer.SelectedIndex = 0;
            ddlcollectstatus.SelectedIndex = 0;
            ddlRequestDate.SelectedIndex = 0;
            hidDateValue.Value = "";
            Session["orderGrossQuery"] = getCurYearFilter();
            LoadData();
        }

        protected void cbxFileShow_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void daochu1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "GB2312";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("毛利表统计") + "" + System.DateTime.Now.Date + ".xls");

            // 如果设置为 GetEncoding("GB2312");导出的文件将会出现乱码！！！
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。

            //Response.ContentType = "application/vnd.ms-excel";//输出类型
            //Response.Charset = "";

            //关闭 ViewState
            flexigrid.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();//将信息写入字符串
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);//在WEB窗体页上写出一系列连续的HTML特定字符和文本。
            //此类提供ASP.NET服务器控件在将HTML内容呈现给客户端时所使用的格式化功能
            //获取control的HTML

            flexigrid.RenderControl(hw);//将table中的内容输出到HtmlTextWriter对象中

            // 把HTML写回浏览器
            Response.Write(tw.ToString());
            Response.Flush();
            Response.End();

        }
    }
}