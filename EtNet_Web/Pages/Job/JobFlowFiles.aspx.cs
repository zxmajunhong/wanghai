using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Job
{
    public partial class JobFlowFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DownloadFile();
        }


        private void DownloadFile()
        {
            if (Request.Params["id"] != null)
            {
                EtNet_Models.JobFlowFile model = EtNet_BLL.JobFlowFileManager.GetModel(int.Parse(Request.Params["id"]));
                if (model != null)
                {
                    string path = model.fileload;
                    Response.Clear();
                    Response.Buffer = false;
                    string filename = "";
                    if (model.filename.IndexOf('.') != -1)
                    {
                        filename = model.filename;
                    }
                    else
                    {
                        filename = model.filename + path.Substring(path.LastIndexOf('.'));
                    }
                    if (Request.Browser.Browser == "IE")
                    {
                        filename = Server.UrlEncode(filename);
                    }
                    Response.ContentEncoding = System.Text.Encoding.UTF8; //注意编码
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);                  
                    //设置输出流HttpMiME类型(导出文件格式)
                    Response.ContentType = "application/octet-stream"; //image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
                    Response.WriteFile(Server.MapPath(path));

                }
            }

        }


    }
}