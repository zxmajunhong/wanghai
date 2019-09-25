using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
   public  class HtmlTag
    {
       public static string NoHTML(object Htmlstring)
       {
           string re =Convert.ToString( Htmlstring);
           if (re != null && re != "")
           {
               re = re.Replace("<", "&lt;");
               re = re.Replace(">", "&gt;");
               re = re.Replace(" ", "&nbsp;");
               re = re.Replace("\r\n", "<br/>");
               re = re.Replace("\n", "<br/>");
               re = Regex.Replace(re, @"(\r\n)+", "<br/>", RegexOptions.IgnoreCase);
           }
           else {
               re = "";
           }
           return re;

       }
    }
}
