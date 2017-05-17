using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EtNet_Web.Pages.Financial.ToClaim
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Del(context);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void Del(HttpContext context)
        {
            string id = context.Request.QueryString["claimDetailId"];
            context.Response.Write("<script>alert('" + id.ToString() + "')</script>");
        }
    }
}