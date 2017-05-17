using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;
using EtNet_BLL.DataPage;

namespace Pages.Message
{
    public partial class NoticeManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        //绑定公告数据

        private void bindData()
        {
            EtNet_BLL.DataPage.Data data = new Data();
            DataSet ds = data.DataPage("View_Notice", "noticeid", "*", "", "noticeid", true, 10, 10, pages);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }


        //删除修改信息
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Response.Redirect("UpdateNotice.aspx?noticeid=" + id);
            }

            //现在方法
            if (e.CommandName == "File")
            {
                NoticeInfo notice = NoticeInfoManager.getNoticeInfoById(Convert.ToInt32(id));
                string filename = notice.Accressory.ToString();
                EtNet_Models.FileInfo file = new EtNet_Models.FileInfo();
                ////清空输出流
                Response.Clear();
                Response.Charset = "utf-8";
                Response.Buffer = true;
                this.EnableViewState = false;
                ////定义输出文件编码及类型和文件名
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename.Substring(25));
                ////因为保存的文件类型不限，此处类型选择“unknown”。
                Response.ContentType = "application/unknown"; ;
                Response.WriteFile(filename);
                ////清空并关闭输出流
                Response.Flush();
                Response.Close();
                Response.End();
            }

            if (e.CommandName == "Delete")
            {
                try
                {
                    int delCount = NoticeInfoManager.deleteNoticeInfo(Convert.ToInt32(id));


                    if (delCount > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！')</script>");
                        bindData();

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败发生异常！')</script>");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static string simplename(string name)
        {
            return name;
        }

        public static string simplecontent(string content)
        {
            if (content.Length > 10)
            {
                return content.Substring(0, 10) + "...";
            }
            else
            {
                return content;
            }
        }



        public DataTable ExportData(string fields)
        {
            DataTable tbl = EtNet_BLL.NoticeInfoManager.getlist(fields, "");
            tbl.Columns["title"].ColumnName = "标题";
            tbl.Columns["context"].ColumnName = "内容";
            return tbl;

        }
    

        //数据导出
        protected void imgbtndata_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = false;
            Response.ContentEncoding = System.Text.Encoding.Default; //注意编码
            Response.AppendHeader("Content-Disposition", "attachment;filename=msg.xls");
            //设置输出流HttpMiME类型(导出文件格式)
            Response.ContentType = "application /ms-excel"; //image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
            //关闭ViewState
            Page.EnableViewState = false;
            GridView gv = new GridView();

            string strfildes = " title,context ";
            gv.DataSource = ExportData(strfildes);
            gv.DataBind();

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter);
            gv.RenderControl(textWriter);
            //把HTML写回游览器
            Response.Write(stringWriter.ToString());
            Response.End();
        }
    }
}