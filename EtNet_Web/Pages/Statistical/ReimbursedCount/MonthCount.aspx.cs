using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;
using System.IO;
using System.Globalization;

namespace EtNet_Web.Pages.Statistical.ReimbursedCount
{
    public partial class MonthCount : System.Web.UI.Page
    {
        public static Dictionary<String, String> di = new Dictionary<String, String>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string year = DateTime.Now.Year.ToString();
                PageSymbolNum();
                YearListBind();
                diBind();
                databind(year);
            }
        }


        public void tdBind() 
        {

            string str = "";
            DataTable dt = AusItemInfoManager.GetList(" ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "<td class='clstitleimg' style='width: 50px'>" + dt.Rows[i]["itemname"] + "</td>";
            }
            
        }


        //绑定导出excel列标题字典
        public void diBind()
        {
            di.Clear();
            di.Add("departtxt", "部门");
            di.Add("1", "1月");
            di.Add("2", "2月");
            di.Add("3", "3月");
            di.Add("4", "4月");
            di.Add("5", "5月");
            di.Add("6", "6月");
            di.Add("7", "7月");
            di.Add("8", "8月");
            di.Add("9", "9月");
            di.Add("10", "10月");
            di.Add("11", "11月");
            di.Add("12", "12月");
            di.Add("13", "合计");
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
            if (Session["PageNum"].ToString() != "028")
            {
                Session["PageNum"] = "028";
                Session["query"] = "";
                Session["sort"] = "";
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void databind(string year)
        {
            int loginID = ((LoginInfo)Session["login"]).Id;
            DataTable dt = AusDetialInfoManager.GetMonthCount(loginID, year);

            rptdata.DataSource = dt;
            rptdata.DataBind();

            Session["MyData"] = dt;
        }

        /// <summary>
        /// 绑定时间
        /// </summary>
        protected void YearListBind()
        {
            int nowYear = DateTime.Now.Year;
            this.selectyear.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Value = (nowYear - i).ToString();
                adItem.Text = (nowYear - i).ToString() + "年";
                this.selectyear.Items.Add(adItem);
            }
        }

        protected void selectyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind(this.selectyear.SelectedValue);
        }

        /// <summary>
        /// 得到金额
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string getje(string args)
        {
            string[] s = args.Split(',');
            if (s[0] != "")
            {
                return String.Format("{0:F}", Convert.ToDouble(s[0]));
            }
            else
            {
                return s[0];
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

            range = (Excel.Range)worksheet.get_Range("A1", "O1");//获取表格中第一行
            range.Merge(0);//合并第一行
            worksheet.Cells[1, 1] = this.selectyear.SelectedValue + "年度报销费用-部门报销费用按月度汇总"; //大标题
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
                    worksheet.Cells[2, i + 1] = "序号";
                }
                else
                {
                    worksheet.Cells[2, i + 1] = di[dt.Columns[i - 1].ColumnName];//从第二行的第一格开始写数据
                }

                //设置标题的样式
                range = (Excel.Range)worksheet.Cells[2, i + 1];
                range.Font.Bold = true;//粗体
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//居中
                range.Interior.ColorIndex = 15;
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);//背景色

                if (i == 0) //序号列宽度自动
                {
                    range.EntireColumn.AutoFit();
                }
                else
                {
                    //设置单元格的宽度，如果小于9就设置为9，如果大于。则设置为自动
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

            //写入DataTable中数据的内容
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count + 1; c++)
                {
                    range = (Excel.Range)worksheet.Cells[r + 3, c + 1];
                    //写入内容
                    if (c == 0)
                    {
                        if (r == dt.Rows.Count - 1)
                        {
                            worksheet.Cells[r + 3, c + 1] = "";
                        }
                        else
                        {
                            worksheet.Cells[r + 3, c + 1] = (r + 1).ToString(); //得到序号
                        }
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//居中
                    }
                    else if (c == 1)
                    {
                        worksheet.Cells[r + 3, c + 1] = dt.Rows[r][c - 1].ToString();
                    }
                    else
                    {
                        worksheet.Cells[r + 3, c + 1] = dt.Rows[r][c - 1].ToString().Split(',')[0];
                        range.NumberFormat = "#,##0.00";
                    }
                    //设置样式
                    range.Font.Size = 9; //字体大小
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
                if (r == dt.Rows.Count - 1)
                {
                    range = (Excel.Range)worksheet.get_Range("A" + (r + 3).ToString(), "B" + (r + 3).ToString());
                    range.Merge(0);
                    range.Value = "合计";
                    range.Font.Size = 9;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//居中
                    range.EntireColumn.AutoFit();
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
                System.Windows.Forms.Application.DoEvents();
            }

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
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("年度报销费用按月度汇总.xls"));
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

        //导出excel
        protected void imgexport_Click(object sender, ImageClickEventArgs e)
        {
            string filename = Server.MapPath("../../../ExportToExcel/MonthCount/" + this.selectyear.SelectedValue + "年度报销费用按月度汇总.xls");
            if (doExport(filename))
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('导出成功')</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script>alert('导出失败')</script>");
            }
        }

    }
}