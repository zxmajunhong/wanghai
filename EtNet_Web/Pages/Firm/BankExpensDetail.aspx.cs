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

namespace EtNet_Web.Pages.Firm
{
    public partial class BankExpensDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
                ExpenseListBind();
            }
        }

        /// <summary>
        /// 页面数字标识
        /// </summary>
        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = ""; //如无PageNum，先生成一个
            }
            if (Session["PageNum"].ToString() != "210")
            {
                Session["PageNum"] = "210";
                Session["query"] = "";
            }
        }


        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
            }
        }

        private DataTable dtExpense = new DataTable();

        /// <summary>
        /// 初始化数据table
        /// </summary>
        /// <returns></returns>
        private DataTable initializeDataTable()
        {
            if (dtExpense != null && dtExpense.Rows.Count > 0)
            {
                return dtExpense;
            }
            else
            {
                string bankId = Request.QueryString["bankid"];
                if (!string.IsNullOrEmpty(bankId))
                {
                    FirmAccountInfo accountinfo = FirmAccountInfoManager.GetModel(int.Parse(bankId));
                    string sqlstr = " and comebankid = " + bankId;
                    sqlstr += accountinfo.ystime.ToString() != "" ? " and comedate >='" + accountinfo.ystime.ToString("yyyy-MM-dd") + "' " : "";
                    decimal preinstallMoney = accountinfo.amount; //得到账户预设余额
                    DataTable dt = FirmAccountInfoManager.GetExpense(sqlstr,"comedate asc");
                    dt.Columns.Add("balance"); //增加余额一列
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["InMoney"].ToString() == "-") // 表示是一条付款记录
                        {
                            decimal d = 0;
                            decimal.TryParse(dt.Rows[i]["OutMoney"].ToString(), out d);
                            preinstallMoney -= d;
                            dt.Rows[i]["balance"] = preinstallMoney.ToString("0.00");
                        }
                        else //一条收款记录
                        {
                            decimal d = 0;
                            decimal.TryParse(dt.Rows[i]["InMoney"].ToString(), out d);
                            preinstallMoney += d;
                            dt.Rows[i]["balance"] = preinstallMoney.ToString("0.00");
                        }
                    }
                    dtExpense = dt.Copy();
                    dtExpense.Columns["comedate"].DataType = typeof(DateTime);
                    return dtExpense;
                }
                else
                    return null;
            }
        }

        private void ExpenseListBind()
        {
            string sqlstr = " 1=1 ";
            sqlstr += Session["query"].ToString();
            DataTable dt0 = initializeDataTable().Copy();
            DataRow[] rows = dt0.Select(sqlstr);
            DataTable dt = dt0.Clone();
            foreach (DataRow row in rows)
            {
                dt.ImportRow(row);
            }
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 210);
            AspNetPager1.RecordCount = dt.Rows.Count;
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
            rptexpens.DataSource = SplitDataTable(dt, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            rptexpens.DataBind();

            #region
            //string sqlstr = "";
            //if (!string.IsNullOrEmpty(Request.QueryString["bankid"]))
            //    sqlstr += " and comebankid = " + Request.QueryString["bankid"];
            //sqlstr += Session["query"].ToString();
            //LoginInfo login = (LoginInfo)Session["login"];
            //SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 210);
            //Data data = new Data();
            //AspNetPager1.RecordCount = data.GetCount("ViewExpense", sqlstr);
            //if (sps == null)
            //{
            //    AspNetPager1.NumericButtonCount = 10;
            //    AspNetPager1.PageSize = 10;
            //}
            //else
            //{
            //    AspNetPager1.NumericButtonCount = sps.Pagecount;
            //    AspNetPager1.PageSize = sps.Pageitem;
            //}
            //DataTable dt = data.GetList("ViewExpense", "comedate", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            //rptexpens.DataSource = dt;
            //rptexpens.DataBind();
            #endregion
        }

        /// <summary>
        /// 根据索引和pagesize返回记录
        /// </summary>
        /// <param name="dt">记录集 DataTable</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="pagesize">一页的记录数</param>
        /// <returns></returns>
        public static DataTable SplitDataTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Clone();
            //newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }


        /// <summary>
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            ExpenseListBind();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();
            if (this.txtUnit.Value.Trim() != "")
            {
                sqlstr.AppendFormat(" and Unit like '%{0}%' ", this.txtUnit.Value.Trim());
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" AND ( comedate >= '{0}' AND comedate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" AND comedate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" AND comedate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND comedate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND comedate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND comedate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( comedate >= '{0}' AND comedate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( comedate >= '{0}' AND comedate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }
            Session["query"] = sqlstr;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            ExpenseListBind();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.txtUnit.Value = "";
            ddlRequestDate.SelectedIndex = -1;
            hidDateValue.Value = "";
            Session["query"] = "";
            ExpenseListBind();
        }

        protected void rptexpens_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string args = e.CommandArgument.ToString();
            string id = args.Split('_')[0];
            string item = args.Split('_')[1];
            string result = "";
            switch (item)
            {
                case "0":
                    result = "<script language=javascript>window.open('../expense/InComeDetail.aspx?id=" + id + "')</script>";
                    //Response.Write("<script language=javascript>window.open('../expense/InComeDetail.aspx?id=" + id + "')</script>");
                    break;
                case "1":
                    result = "<script language=javascript>window.open('../Financial/Collecting.aspx?id=" + id + "')</script>";
                    //Response.Write("<script language=javascript>window.open('../Financial/Collecting.aspx?id=" + id + "')</script>");
                    break;
                case "2":
                    result = "<script language=javascript>window.open('../Job/ReimbursedForm/RegreimbursedFormDetail.aspx?regId=" + id + "')</script>";
                    //Response.Write("<script language=javascript>window.open('../Job/ReimbursedForm/RegreimbursedFormDetail.aspx?regId=" + id + "')</script>");
                    break;
                case "3":
                    result = "<script language=javascript>window.open('../Financial/RegPayment/SearchRegPayment.aspx?payid=" + id + "')</script>";
                    //Response.Write("<script language=javascript>window.open('../Financial/RegPayment/RegPayment.aspx?payid=" + id + "')</script>");
                    break;
                case "4":
                    result = "<script language=javascript>window.open('../expense/OutComeDetail.aspx?id=" + id + "')</script>";
                    //Response.Write("<script language=javascript>window.open('../expense/OutComeDetail.aspx?id=" + id + "')</script>");
                    break;
            }
            if (result != "")
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "turn", result, false);
        }

        /// <summary>
        /// 显示类别
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string showItem(object item)
        {
            string _item = "";
            switch (item.ToString())
            {
                case "0":
                    _item = "其他收款";
                    break;
                case "1":
                    _item = "订单收款";
                    break;
                case "2":
                    _item = "报销付款";
                    break;
                case "3":
                    _item = "订单付款";
                    break;
                case "4":
                    _item = "其他付款";
                    break;
            }

            return _item;
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnback_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["returl"]))
            {
                Response.Redirect("BankExpenseList.aspx");
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["firmid"]))
                {
                    Response.Redirect("DetailFirm.aspx?id=" + Request.QueryString["firmid"]);
                }
                else
                {
                    Response.Redirect("ShowFirm.aspx");
                }
            }
        }

        private void Export(DataTable dt,string tablename)
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
            workbook.Save(Response, DateTime.Now.ToString("yyyy-MM-dd") + "Account.xls", ContentDisposition.Attachment, workbook.SaveOptions);
        }

        protected void ibtexport_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("日期", typeof(string));
            dt.Columns.Add("收入", typeof(string));
            dt.Columns.Add("支出", typeof(string));
            dt.Columns.Add("余额", typeof(string));
            dt.Columns.Add("对方单位", typeof(string));
            dt.Columns.Add("银行账户", typeof(string));
            dt.Columns.Add("类别", typeof(string));
            //double InMoney = 0;
            //double OutMoney = 0;
            DataTable dt0 = initializeDataTable().Copy();
            string sqlstr = " 1=1 ";
            sqlstr += Session["query"].ToString();
            DataRow[] rows = dt0.Select(sqlstr);
            for (int i = 0; i < rows.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = Convert.ToDateTime(rows[i]["comedate"]).ToString("yyyy-MM-dd");
                dr[1] = rows[i]["InMoney"].ToString();
                dr[2] = rows[i]["OutMoney"].ToString();
                dr[3] = rows[i]["balance"].ToString();
                dr[4] = rows[i]["Unit"].ToString();
                dr[5] = rows[i]["comebankname"].ToString();
                dr[6] = showItem(rows[i]["item"]);
                dt.Rows.Add(dr);
                //InMoney += rows[i]["InMoney"].ToString() != "-" ? Convert.ToDouble(rows[i]["InMoney"]) : 0;
                //OutMoney += rows[i]["OutMoney"].ToString() != "-" ? Convert.ToDouble(rows[i]["OutMoney"]) : 0;
            }
            /*计算合计行*/
            //DataRow drSum = dt.NewRow();
            //drSum[0] = "合计";
            //drSum[1] = InMoney.ToString("0.00");
            //drSum[2] = OutMoney.ToString("0.00");
            //dt.Rows.Add(drSum);

            Export(dt, rows[0]["comebankname"].ToString() + "_对账表");
        }
    }
}