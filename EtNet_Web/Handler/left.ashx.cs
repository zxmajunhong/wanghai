using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EtNet_Models;
using System.Web.SessionState;

namespace EtNet_Web.Handler
{
    /// <summary>
    /// Summary description for left
    /// </summary>
    public class left : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/x-json";
            LoginInfo login = (LoginInfo)context.Session["login"];
            System.Collections.Generic.IList<ViewMenuByLogin> menus = EtNet_BLL.ViewMenuByLoginManager.getMenuOfLay(login.Id);
            string json = "[";
            foreach (var menu in menus)
            {
                json += menu.ToString() + ",";
            }
            json = json.Remove(json.Length - 1) + "]";

            context.Response.Write(json);
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