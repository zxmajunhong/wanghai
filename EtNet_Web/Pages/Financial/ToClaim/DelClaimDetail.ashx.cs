using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Financial.ToClaim
{
    /// <summary>
    /// DelClaimDetail 的摘要说明
    /// </summary>
    public class DelClaimDetail : IHttpHandler
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
            To_ClaimDetailManager claimDetailManager = new To_ClaimDetailManager();
            claimDetailManager.Delete(int.Parse(id));
        }
    }
}