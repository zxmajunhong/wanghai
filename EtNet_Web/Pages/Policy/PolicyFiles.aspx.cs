using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Policy
{
    public partial class PolicyFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object objFileID = Request.QueryString["id"];
            int fileID = 0;
            if (objFileID == null || !int.TryParse(objFileID.ToString(), out fileID))
            {
                form1.InnerHtml = "<p style='font-size:14px;'>附件不存在或已被删除!</p>";
                return;
            }

            DownloadFile(fileID);
        }

        private void DownloadFile(int fileID)
        {
            To_PolicyFileManager fileBLL = new To_PolicyFileManager();
            To_PolicyFile fileEntity = fileBLL.GetModel(fileID);

            if (fileEntity == null)
            {
                form1.InnerHtml = "<p style='font-size:14px;'>附件不存在或已被删除!</p>";
                return;
            }

            string filePath = fileEntity.filepath;
            string fileName = fileEntity.filename;

            if (Request.Browser.Browser == "IE")
                fileName = Server.UrlEncode(fileName);

            Response.Clear();
            Response.Buffer = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8; //注意编码

            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            //设置输出流HttpMiME类型(导出文件格式)
            Response.ContentType = "application/octet-stream;"; //image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
            Response.WriteFile(Server.MapPath(filePath));

        }
    }
}