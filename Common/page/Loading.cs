using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public   class Loading
    {
        //页面首次加载方法
        public static  void initJavascript()
        {
            StringBuilder sb = new StringBuilder();
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            sb.Append(" <script language=JavaScript type=text/javascript>");
            sb.Append("var t_id = setInterval(animate,20);");
            sb.Append("var pos=0;var dir=2;var len=0;");
            sb.Append("function animate(){");
            sb.Append("var elem = document.getElementById('progress');");
            sb.Append("if(elem != null) {");
            sb.Append("if (pos==0) len += dir;");
            sb.Append("if (len>32 || pos>79) pos += dir;");
            sb.Append("if (pos>79) len -= dir;");
            sb.Append(" if (pos>79 && len==0) pos=0;");
            sb.Append("elem.style.left = pos;");
            sb.Append("elem.style.width = len;");
            sb.Append("}}");
            sb.Append("function remove_loading() {");
            sb.Append(" this.clearInterval(t_id);");
            sb.Append("var targelem = document.getElementById('loader_container');");
            sb.Append("targelem.style.display='none';");
            sb.Append("targelem.style.visibility='hidden';");
            sb.Append("}");
            sb.Append("</script>");
            sb.Append("<style>");
            sb.Append("#loader_container {text-align:center; position:absolute; top:40%; width:100%; left: 0;}");
            sb.Append("#loader {font-family:Tahoma, Helvetica, sans; font-size:11.5px; color:#000000; background-color:#FFFFFF; padding:10px 0 16px 0; margin:0 auto; display:block; width:130px; border:1px solid #5a667b; text-align:left; z-index:2;}");
            sb.Append("#progress {height:5px; font-size:1px; width:1px; position:relative; top:1px; left:0px; background-color:#8894a8;}");
            sb.Append("#loader_bg {background-color:#e4e7eb; position:relative; top:8px; left:8px; height:7px; width:113px; font-size:1px;}");
            sb.Append("</style>");
            sb.Append("<div id=loader_container>");
            sb.Append("<div id=loader>");
            sb.Append("<div align=center>页面正在加载中 ...<hr/></div>");
            sb.Append("<div id=loader_bg></div>");
            sb.Append("</div></div>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "",sb.ToString());
        }

        public static void loading()
        {
           StringBuilder sb = new StringBuilder();
           System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
           
           sb.Append(" <script language=JavaScript type=text/javascript>");
           sb.Append("var t_id = setInterval(animate,20);");
           sb.Append("var pos=0;var dir=2;var len=0;");
           sb.Append("function animate(){");
           sb.Append("var elem = document.getElementById('progress');");
           sb.Append("if(elem != null) {");

           sb.Append("if (pos==0) len += dir;");
           sb.Append("if (len>32 || pos>79) pos += dir;");
           sb.Append("if (pos>79) len -= dir;");
           sb.Append(" if (pos>79 && len==0) pos=0;");
           sb.Append("elem.style.left = pos;");
           sb.Append("elem.style.width = len;");
           sb.Append("}}");



           sb.Append("function remove_loading() {");
           sb.Append(" this.clearInterval(t_id);");
           sb.Append("var targelem = document.getElementById('loader_container');");
           sb.Append("targelem.style.display='none';");
           sb.Append("targelem.style.visibility='hidden';");
           sb.Append("}");
           sb.Append("</script>");
           sb.Append("<style>");
           sb.Append("#loader_container {text-align:center; position:absolute; top:40%; width:100%; left: 0;}");
           sb.Append("#loader {font-family:Tahoma, Helvetica, sans; font-size:11.5px; color:#000000; background-color:#FFFFFF; padding:10px 0 16px 0; margin:0 auto; display:block; width:130px; border:1px solid #5a667b;text-align:left; z-index:2;}");
           //sb.Append("#progress {height:5px; font-size:1px; width:1px; position:relative; top:1px; left:0px; background-color:#8894a8;}");
           //sb.Append("#loader_bg {background-color:#e4e7eb; position:relative; top:8px; left:8px; height:7px; width:113px; font-size:1px;}");
           sb.Append("</style>");
           sb.Append("<div id=loader_container>");
           sb.Append("<div id=loader style='background:#f6f6f6;'>");
           sb.Append("<div align=center>页面正在加载中 ...<hr/><div><img  src='images/loading3.gif' /></div></div>");
           sb.Append("<div id=loader_bg></div>");
           sb.Append("</div></div>");
           page.ClientScript.RegisterStartupScript(page.GetType(), "", sb.ToString());
        }
    }
}
