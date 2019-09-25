using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EtNet_BLL;

namespace EtNet_Web.Pages.Policy
{
    /// <summary>
    /// ExitsRecord 的摘要说明 判断该保单是否存在
    /// </summary>
    public class ExitsRecord : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string msg = "ok";
            object id = context.Request.QueryString["id"];
            string snum = context.Request.QueryString["s"];
            string pnum = context.Request.QueryString["p"];

            if (To_PolicyManager.ExitsRecordByField("serialnum", snum, id))
            {
                msg = "业务编号已存在";
            }
            else if (To_PolicyManager.ExitsRecordByField("policy_num", pnum, id))
            {
                msg = "保单编号已存在";
            }

            context.Response.Write(msg);
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