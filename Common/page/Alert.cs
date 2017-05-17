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
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
namespace Common
{
   public  class Alert
    {
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
        }
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            string js = @"<script language=javascript>showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
        }

       public static string JsAlert(string Msg=null, string Url=null,bool IsParentIframeNava=false)
       {
           string jsstr = "<script type=\"text/javascript\" >";
           if (Msg != null)
           {
               jsstr += "alert('"+Msg+"');";
           }
           if (Url != null)
           {
               if (IsParentIframeNava)
               {
                   jsstr += "window.parent.location.href='" + Url + "';";
               }
               else
               {
                   jsstr += "window.location.href='" + Url + "';";
               }
 
           }
           jsstr += "</script>";
           return jsstr;
       }

       public static string  JsDo(string Js_Str="")
       {
           string jsstr = "<script type=\"text/javascript\" >";
           if (Js_Str!="")
           {
               jsstr += Js_Str;
           }
           jsstr += "</script>";
           return jsstr;

       }
      

    }
}
