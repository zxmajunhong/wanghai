using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Common
{
  public class QQ
    {
        public static void ChatWithQQ()
        {
            HttpContext.Current.Response.Write("<script language='javascript'type='text/javascript'> window.open('http://wpa.qq.com/msgrd?v=3&uin=361312185&site=qq&menu=yes','','', false);</script>");
        }
    }

 
}
