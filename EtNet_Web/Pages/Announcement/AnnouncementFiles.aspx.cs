using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DownloadFile();
        }


        private void DownloadFile()
        {
            if (Request.Params["id"] != null)
            {
                string strsql = " id =" + Request.QueryString["id"].ToString();
                DataTable tbl = EtNet_BLL.AnnouncementFilesManager.GetList(strsql);
                if (tbl.Rows.Count != 0)
                {
                    string path = tbl.Rows[0]["path"].ToString();
                    Response.Clear();
                    Response.Buffer = false;
                    Response.ContentEncoding = System.Text.Encoding.UTF8; //注意编码
                    //string filename = Server.UrlEncode(tbl.Rows[0]["cname"].ToString()) + path.Substring(path.LastIndexOf('.'));
                    string filename = "";
                    if (tbl.Rows[0]["cname"].ToString().IndexOf('.') != -1)
                    {
                        filename = tbl.Rows[0]["cname"].ToString();
                    }
                    else
                    {
                        filename = tbl.Rows[0]["cname"].ToString() + path.Substring(path.LastIndexOf('.'));
                    }
                    if (Request.Browser.Browser == "IE")
                    {
                        filename = Server.UrlEncode(filename);
                    }
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
                    //设置输出流HttpMiME类型(导出文件格式)
                    Response.ContentType = "application/octet-stream;"; //image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
                    Response.WriteFile(Server.MapPath(tbl.Rows[0]["path"].ToString()));


                }
            }

        }

    }
}