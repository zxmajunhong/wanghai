using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Information
{
    public partial class InformationFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DownloadFile();
        }

        private void DownloadFile()
        {
            if (Request.Params["id"] != null)
            {
                int id = int.Parse(Request.Params["id"]);
                EtNet_Models.InformationFile model =  EtNet_BLL.InformationFileManager.GetModel(id);
               
                if (model != null)
                {
                    string path = model.fileload;
                    Response.Clear();
                    Response.Buffer = false;
                    Response.ContentEncoding = System.Text.Encoding.UTF8; //注意编码
                    //string filename = Server.UrlEncode(tbl.Rows[0]["cname"].ToString()) + path.Substring(path.LastIndexOf('.'));
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
                    //设置输出流HttpMiME类型(导出文件格式)
                    Response.ContentType = "application/octet-stream;"; //image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
                    Response.WriteFile(Server.MapPath(model.fileload));


                }
            }

        }








    }
}