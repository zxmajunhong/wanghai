using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace Common
{
    public class URL
    {
        public  string UrlPageName = System.IO.Path.GetFileName(HttpContext.Current.Request.PhysicalPath);
        public  string UrlAddress = HttpContext.Current.Request.Url.AbsoluteUri;
        public  string UrlParams = HttpContext.Current.Request.Url.Query;
        public  string StaticUrl = HttpContext.Current.Request.RawUrl;
        public  string StaticPageName()
        {
            string url=System.IO.Path.GetFileName(HttpContext.Current.Request.RawUrl);
            if(url.Contains("?"))
            {
                url = url.Substring(0, url.LastIndexOf("?"));
            }
            return url;
        }
    }
}
