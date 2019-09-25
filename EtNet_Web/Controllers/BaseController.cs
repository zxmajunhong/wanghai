using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using EtNet_Models;

namespace EtNet_Web.Controllers
{
    public class BaseController : Controller
    {

        public string UserId
        {
            get
            {
                if (Session["login"] == null)
                    return "0";
                else
                {
                    LoginInfo login = (LoginInfo)Session["login"];
                    return login.Loginid;
                }
            }
        }
        
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            SetCulture(requestContext);
        }
        private void SetCulture(string culture)
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture);

        }
        private void SetCulture(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["Culture"] != null)
            {
                SetCulture(requestContext.HttpContext.Session["Culture"].ToString());
            }           
        }

    }
}
