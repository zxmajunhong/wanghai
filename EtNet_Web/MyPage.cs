using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.Adapters;

namespace EtNet_Web
{
    public class MyPage : PageAdapter
    {
        protected override void OnLoad(EventArgs e)
        {
            if (Page.Session["login"] == null)
            {
                if (!Page.Request.Path.Trim().ToUpper().EndsWith("/LOGIN.ASPX") && !Page.Request.Path.Trim().ToUpper().EndsWith("/INDEX.ASPX"))
                {
                    string loginUrl = GetRootURI() + "/Login.aspx";
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "page", "window.top.location.href='" + loginUrl + "';", true);
                }
                else
                {
                    base.OnLoad(e);
                }
            }
            else
            {
                base.OnLoad(e);
            }
        }

        /// <summary>
        /// 取得网站的根目录的URL,包括虚拟目录
        /// </summary>
        /// <returns>如：https：//www.do.com/apppath </returns>
        private static string GetRootURI()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;

                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority;
                else
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath;
            }
            return AppPath;
        }
    }
}