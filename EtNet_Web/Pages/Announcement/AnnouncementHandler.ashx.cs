using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace EtNet_Web.Pages.Announcement
{
    /// <summary>
    /// AnnouncementHandler 的摘要说明
    /// </summary>
    public class AnnouncementHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.Expires = 0;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "private");
            context.Response.CacheControl = "no-cache";
            Sort(context);
        }

        //分类导航，执行不同的功能
        private void Sort(HttpContext context)
        {
            switch (context.Request.Params["sort"])
            {
                case "1":
                    DelFile(context);
                    break;
            }

        }


        /// 删除附件
        /// </summary>
        private void DelFile(HttpContext context)
        {
            int id = int.Parse(context.Request.Params["fileid"]);
            EtNet_Models.AnnouncementFiles model =  EtNet_BLL.AnnouncementFilesManager.GetModel(id);
            if (model != null)
            {
                //删除服务器上的相应的文件
                File.Delete(context.Server.MapPath(model.path));
                EtNet_BLL.AnnouncementFilesManager.Delete(model.id);
                context.Response.Write("删除成功_1");
            }
            else
            {
                context.Response.Write("删除失败_0");
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



    }
}