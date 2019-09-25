using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class WebConfig
    {
        public static string EditClass = "list_mod";
        public static string DeleteClass = "list_del";
        public static string DetailClass = "list_det";
        public static string DisableFunctionName = "list_disable";
        public static string WebName = "商互网后台管理系统";
        public static string FileUploadPosition = "upload/";

        public static string domain = WEBRootURL();

        //获取网站根目录
        public static string WEBRootURL()
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
