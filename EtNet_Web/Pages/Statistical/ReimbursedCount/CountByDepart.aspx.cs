using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using EtNet_BLL;
using System.IO;

namespace EtNet_Web.Pages.Statistical.ReimbursedCount
{
    public partial class CountByDepart : System.Web.UI.Page
    {
        string pagesql = "";
        public static Dictionary<String, String> di = new Dictionary<String, String>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {

                
                QueryBuilder();
                PageSymbolNum();
                itembind();
                typebind();
                diBind();
                string[] args = Request.QueryString["args"].Split(',');
                if (args[3] == "") //如果不存在月参数，表示是最后一列部门_月累计数据
                {
                    Session["sort"] = " and belongsort='" + args[1] + "' and year=" + args[2];
                    this.biaoti.InnerText = args[1] + "部门 报销明细";
                    loaduser(args[1]);
                    this.ddldepart.Enabled = false;
                }
                else if (args[1].Contains('|')) //如果在部门参数中包含'|'字符表示的是月_部门累计数据
                {
                    string depart = args[1].Replace('|', ',');
                    depart = depart.Substring(0, depart.Length - 1); //得到当前登录人员可以看到哪些部门
                    Session["sort"] = "and belongsort in (" + depart + ") and year=" + args[2] + " and month=" + args[3];
                    this.biaoti.InnerText = args[3] + "月 报销明细";
                    loaduser(depart);
                    loaddepart(depart);
                }
                else
                {
                    Session["sort"] = " and belongsort='" + args[1] + "'" + " and year=" + args[2] + " and month=" + args[3];
                    this.biaoti.InnerText = args[1] + args[2] + "年" + args[3] + "月 报销明细";
                    loaduser(args[1]);
                    this.ddldepart.Enabled = false;
                }
                LoadReimbursementDetial();
            }
        }

        public void diBind()
        {
            di.Clear();
            di.Add("happendate", "发生时间");
            di.Add("belongsort", "部门");
            di.Add("Salesman", "报销人员");
            di.Add("ausname", "项目类别");
            di.Add("austype", "发票内容");
            di.Add("ausmoney", "报销金额");
            di.Add("remark", "备注");
            di.Add("payStatus", "支付状态");
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
            if (Session["PageNum"].ToString() != "029")
            {
                Session["PageNum"] = "029";
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

        /// <summary>
        /// 加载项目类别
        /// </summary>
        private void itembind()
        {
            this.ddlitem.Items.Clear();
            DataTable tbl = EtNet_BLL.AusItemInfoManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["itemname"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlitem.DataSource = tbl;
            this.ddlitem.DataTextField = "itemname";
            this.ddlitem.DataValueField = "itemname";
            this.ddlitem.DataBind();

        }

        /// <summary>
        /// 绑定票面内容
        /// </summary>
        private void typebind()
        {
            this.ddltype.Items.Clear();
            DataTable tbl = EtNet_BLL.AusTypeInfoManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["typename"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddltype.DataSource = tbl;
            this.ddltype.DataTextField = "typename";
            this.ddltype.DataValueField = "typename";

            this.ddltype.DataBind();
        }

        /// <summary>
        /// 加载报销人员数据
        /// </summary>
        /// <param name="depart"></param>
        private void loaduser(string depart)
        {
            this.ddlperson.Items.Clear();
            if (depart.Contains(','))
            {
                string departid = "";
                IList<DepartmentInfo> department = DepartmentInfoManager.getDepartmentInfoBynames(depart);
                foreach (DepartmentInfo de in department)
                {
                    departid += de.Departid + ",";
                }
                departid = departid.Substring(0, departid.Length - 1);
                string sql = " DepartId in (" + departid + ")";
                DataTable tbl = EtNet_BLL.LoginInfoManager.getList(sql);
                DataRow row = tbl.NewRow();
                row["id"] = 0;
                row["cname"] = "——请选中——";
                tbl.Rows.InsertAt(row, 0);
                this.ddlperson.DataSource = tbl;
                this.ddlperson.DataTextField = "cname";
                this.ddlperson.DataValueField = "cname";
                this.ddlperson.DataBind();

            }
            else
            {
                DepartmentInfo department = DepartmentInfoManager.getDepartmentInfoBydepartcname(depart);
                string sql = " DepartId=" + department.Departid;
                DataTable tbl = LoginInfoManager.getList(sql);
                DataRow row = tbl.NewRow();
                row["id"] = 0;
                row["cname"] = "——请选中——";
                tbl.Rows.InsertAt(row, 0);
                this.ddlperson.DataSource = tbl;
                this.ddlperson.DataTextField = "cname";
                this.ddlperson.DataValueField = "cname";
                this.ddlperson.DataBind();
            }
        }

        /// <summary>
        /// 加载部门信息
        /// </summary>
        private void loaddepart(string depart)
        {
            this.ddldepart.Items.Clear();
            IList<DepartmentInfo> departs = DepartmentInfoManager.getDepartmentInfoBynames(depart);
            this.ddldepart.DataSource = departs;
            this.ddldepart.DataTextField = "departcname";
            this.ddldepart.DataValueField = "departcname";
            this.ddldepart.DataBind();
            this.ddldepart.Items.Insert(0, "——请选中——");
        }

        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='029'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "029";
                pageset.Pagecount = 10;
                pageset.Pageitem = 10;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }

        /// <summary>
        /// 加载明细数据
        /// </summary>
        private void LoadReimbursementDetial()
        {
            pagesql = "";
            pagesql = Session["sort"].ToString();
            this.pages.Visible = true;
            double zje = 0;
            DataTable tbl = Exists();
            pagesql += Session["query"];
            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet set = data.DataPage("View_AusDetialInfo", "id", "*", pagesql, "happendate", true, pitem, pcount, pages);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                zje += set.Tables[0].Rows[i]["ausmoney"].ToString() == "" ? 0.00 : Convert.ToDouble(set.Tables[0].Rows[i]["ausmoney"]);
            }


            this.rptdata.DataSource = set;
            this.rptdata.DataBind();

            Session["MyData"] = set.Tables[0];

            this.zje.Text = zje.ToString("0.00");
        }

        /// <summary>
        /// 根据筛选条件查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBulider();
            
            LoadReimbursementDetial();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.txtje.Value = "";
            this.ddlitem.SelectedIndex = 0;
            this.ddltype.SelectedIndex = 0;
            this.ddlstatus.SelectedIndex = 0;
            this.ddlperson.SelectedIndex = 0;
            if (this.ddldepart.Enabled)
            {
                this.ddldepart.SelectedIndex = 0;
            }
            this.ddldate.SelectedIndex = 0;

            Session["query"] = "";
            LoadReimbursementDetial();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBulider()
        {
            string sqlstr = "";
            string happendate = " convert(varchar(10),happendate,120) ";
            if (this.txtje.Value != "") //金额条件
            {
                sqlstr += " and ausmoney = " + this.txtje.Value.Trim();
            }
            if (this.ddlitem.SelectedIndex != 0) //项目类别
            {
                sqlstr += " and ausname = '" + this.ddlitem.SelectedValue + "'";
            }
            if (this.ddltype.SelectedIndex != 0) //发票内容
            {
                sqlstr += " and austype = '" + this.ddltype.SelectedValue + "'";
            }
            if (this.ddlstatus.SelectedValue != "")
            {
                if (this.ddlstatus.SelectedValue == "1")
                {
                    sqlstr += " AND  payStatus='1' ";
                }
                else if (this.ddlstatus.SelectedValue == "2")
                {
                    sqlstr += " AND  (payStatus='0' or payStatus is null) ";
                }

            }
            if (this.ddlperson.SelectedIndex != 0) //报销人
            {
                sqlstr += " and Salesman = '" + this.ddlperson.SelectedValue + "'";
            }
            if (this.ddldepart.SelectedIndex > 0) //部门
            {
                sqlstr += " and belongsort = '" + this.ddldepart.SelectedValue + "'";
            }
            if (this.hidcdate.Value != "")
            {
                string[] list = this.hidcdate.Value.Split(',');
                if (list[0] != "" && list[1] != "")
                {
                    sqlstr += " AND ( " + happendate + " >= '" + list[0] + "' AND " + happendate + " <= '" + list[1] + "')";

                }
                else if (list[0] != "" && list[1] == "")
                {
                    sqlstr += " AND " + happendate + " >= '" + list[0] + "'";
                }
                else
                {
                    sqlstr += " AND " + happendate + " <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.ddldate.SelectedValue)
                {
                    case "1":
                        sqlstr += " AND " + happendate + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;
                    case "2":
                        sqlstr += " AND " + happendate + " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;
                    case "3":
                        sqlstr += " AND " + happendate + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                        break;

                    case "4":
                        sqlstr += " AND ( " + happendate + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        sqlstr += " AND " + happendate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "5":
                        sqlstr += " AND ( " + happendate + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        sqlstr += " AND " + happendate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;
                }
            }

            Session["query"] = sqlstr;
        }

        /// <summary>
        /// 显示时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string showTime(string str)
        {
            DateTime dt = Convert.ToDateTime(str);
            string time = dt.Year.ToString() + "年" + dt.Month.ToString() + "月";
            return time;
        }

        protected void back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MonthCount.aspx");
        }

        /// <summary>
        /// 得到两位小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string two(string str)
        {
            if (str != "")
            {
                return String.Format("{0:F}", Convert.ToDouble(str));
            }
            else
            {
                return "0.00";
            }
        }

        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgexport_Click(object sender, ImageClickEventArgs e)
        {
            string filename = Server.MapPath("../../../ExportToExcel/CountByDepart/" + this.biaoti.InnerText + ".xls");
            if (doExport(filename))
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('导出成功')</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script>alert('导出失败')</script>");
            }
        }

        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool doExport(string filename)
        {

            if (ExportToExcel((DataTable)Session["MyData"], filename))
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.ClearHeaders();
                System.Web.HttpContext.Current.Response.Buffer = false;
                System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("部门月度报销明细.xls"));
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] content = br.ReadBytes((int)fs.Length);
                        System.Web.HttpContext.Current.Response.BinaryWrite(content);
                    }
                }
                System.Web.HttpContext.Current.Response.End();

                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 将datatable导出excel文件
        /// </summary>
        /// <param name="dt">需要导出的datatable</param>
        /// <param name="AbosultedFilePath">导出文件的绝对路径</param>
        /// <returns></returns>
        public bool ExportToExcel(System.Data.DataTable dt, string AbosultedFilePath)
        {
            dt.Columns.Remove("id");
            dt.Columns.Remove("year");
            dt.Columns.Remove("month");
            dt.Columns.Remove("jobflowid");
            dt.AcceptChanges();
            //检查数据表是否为空，如果为空，则退出
            if (dt == null)
            {
                return false;
            }

            //创建Excel应用程序对象，如果未创建成功则退出
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                System.Web.HttpContext.Current.Response.Write("无法创建Excel对象，可能你的电脑未装Excel");
                return false;
            }

            //创建Excel的工作簿
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1]; //取得sheet1
            Excel.Range range = null;
            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;

            range = (Excel.Range)worksheet.get_Range("A1", "I1");//获取表格第一行
            range.Merge(0);
            worksheet.Cells[1, 1] = this.biaoti.InnerText;
            range.Font.Size = 22;
            range.Font.Bold = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.EntireColumn.AutoFit();
            range.EntireRow.AutoFit();

            //写入标题
            for (int i = 0; i < dt.Columns.Count + 1; i++)
            {
                //写入标题名称
                if (i == 0)
                {
                    worksheet.Cells[2, i + 1] = "序号"; //加入序号列
                }
                else
                {
                    worksheet.Cells[2, i + 1] = di[dt.Columns[i - 1].ColumnName];
                }
                range = (Excel.Range)worksheet.Cells[2, i + 1];
                range.Font.Bold = true;//粗体
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.Interior.ColorIndex = 15;
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);

                if (i == 0)//序号列宽度设为自动调整
                {
                    range.EntireColumn.AutoFit();

                }
                else
                {
                    if (range.EntireColumn.ColumnWidth <= 8.5)
                    {
                        range.EntireColumn.ColumnWidth = 8.5;
                    }
                    else
                    {
                        range.EntireColumn.AutoFit();
                    }
                }
            }

            //写入DataTable中数据的内容
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count + 1; c++)
                {
                    range = (Excel.Range)worksheet.Cells[r + 3, c + 1];
                    //写入内容
                    if (c == 0) //增加序号
                    {
                        worksheet.Cells[r + 3, c + 1] = (r + 1).ToString();
                    }
                    else if (dt.Columns[c - 1].ColumnName == "happendate") //时间列
                    {
                        worksheet.Cells[r + 3, c + 1] = ((DateTime)dt.Rows[r][c - 1]).ToString("yyyy年MM月dd日");

                    }
                    else if (dt.Columns[c - 1].ColumnName == "ausmoney") //金额列
                    {
                        worksheet.Cells[r + 3, c + 1] = dt.Rows[r][c - 1].ToString();
                        range.NumberFormat = "#,##0.00";
                    }
                    else if (dt.Columns[c - 1].ColumnName == "payStatus") //支付列
                    {
                        if (dt.Rows[r][c - 1].ToString() == "1")
                        {
                            worksheet.Cells[r + 3, c + 1] = "已支付";
                        }
                        else
                        {
                            worksheet.Cells[r + 3, c + 1] = "未支付";
                        }
                    }
                    else
                    {
                        worksheet.Cells[r + 3, c + 1] = dt.Rows[r][c - 1].ToString();
                    }

                    //设置样式
                    range.Font.Size = 9;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null); //加边框

                    //设置单元格的宽度，如果小于8.5就设置为8.5，如果大于。则设置为自动
                    if (c == 0) //序号列宽度设为自动
                    {
                        range.EntireColumn.AutoFit();
                    }
                    else
                    {
                        if (range.EntireColumn.ColumnWidth <= 8.5)
                        {
                            range.EntireColumn.ColumnWidth = 8.5;
                        }
                        else
                        {
                            range.EntireColumn.AutoFit();//自动设置列宽
                        }
                    }
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
                System.Windows.Forms.Application.DoEvents();
            }

            //设置合计那一行
            range = (Excel.Range)worksheet.get_Range("A" + (dt.Rows.Count + 3).ToString(), "I" + (dt.Rows.Count + 3).ToString());
            range.Font.ColorIndex = 41;
            //range.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            range.Font.Size = 10;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //居中
            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null); //加边框
            range.EntireColumn.AutoFit(); //自动调整列宽
            worksheet.Cells[3 + dt.Rows.Count, 1] = "合计:";  //合计那一行的第一列
            if (dt.Rows.Count == 0)
            {
                worksheet.Cells[3 + dt.Rows.Count, 7] = 0;
            }
            else
            {
                worksheet.Cells[3 + dt.Rows.Count, 7] = "=SUM(G3:G" + (dt.Rows.Count + 2).ToString() + ")";
            }
            range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;

            System.Windows.Forms.Application.DoEvents();

            try
            {
                workbook.Saved = true;
                workbook.SaveCopyAs(AbosultedFilePath);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("导出文件时出错，文件可能正被打开！\n" + ex.ToString());
                return false;
            }

            workbook.Close();

            if (xlApp != null)
            {
                xlApp.Workbooks.Close();
                xlApp.Quit();

                int generation = System.GC.GetGeneration(xlApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                xlApp = null;
                System.GC.Collect(generation);
            }

            GC.Collect();//强行销毁

            #region 强行杀死最近打开的Excel进程
            System.Diagnostics.Process[] excelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            System.DateTime startTime = new DateTime();
            int m, killID = 0;
            for (m = 0; m < excelProc.Length; m++)
            {
                if (startTime < excelProc[m].StartTime)
                {
                    startTime = excelProc[m].StartTime;
                    killID = m;
                }
            }
            if (excelProc[killID].HasExited == false)
            {
                excelProc[killID].Kill();
            }
            #endregion

            return true;
        }
    }
}