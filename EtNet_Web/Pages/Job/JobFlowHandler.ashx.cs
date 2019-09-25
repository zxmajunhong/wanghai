using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;

namespace EtNet_Web.Pages.Job
{
    /// <summary>
    /// JobFlowHandler 的摘要说明
    /// </summary>
    public class JobFlowHandler : IHttpHandler, IRequiresSessionState
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
                    LoadAuditFile(context);
                    break;

                case "2":
                    DelJobFile(context);
                    break;
            }

        }


        /// <summary>
        /// 加载审核规则
        /// </summary>
        private void LoadAuditFile(HttpContext context)
        {
            string result = "";
            int id;
            int.TryParse(context.Request.Params["flag"], out id);
            EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(id);
            if (model != null)
            {
                string strpath = context.Server.MapPath(model.rolepic);
                if (File.Exists(strpath))
                {
                    result = File.ReadAllText(strpath);
                }
                else
                {
                    result = "";
                }   
            }

            context.Response.Write(result);
        }


        /// <summary>
        /// 删除工作流关联的附件
        /// </summary>
        private void DelJobFile(HttpContext context)
        {
            int fileid = int.Parse(context.Request.Params["fileid"]);
            EtNet_Models.JobFlowFile model = EtNet_BLL.JobFlowFileManager.GetModel(fileid);
            if (model != null)
            {
                //删除服务器上的相应的文件
                File.Delete(context.Server.MapPath(model.fileload));
                EtNet_BLL.JobFlowFileManager.DeleteId(fileid);
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