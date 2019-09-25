using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
   public class HtmlRemove
    {
        public static string HtmlToDataBase(string Htmlstring)
        {
            //Htmlstring = Regex.Replace(Htmlstring, @"(<script[^>]*?>.*?</script>)", "<!-- " + @"$1" + " -->", RegexOptions.IgnoreCase);//注释js
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);//屏蔽<>标记
            Htmlstring = Regex.Replace(Htmlstring, @"(select)", "[-SQL-]" + @"$1", RegexOptions.IgnoreCase);//
            Htmlstring = Regex.Replace(Htmlstring, @"(update)", "[-SQL-]" + @"$1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"(delete)", "[SQL]" + @"$1", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            return Htmlstring;
        }
        public static string HtmlToDiv(string Htmlstring)
        {
            Htmlstring = Htmlstring.Replace("[-SQL-] ", "");
            Htmlstring = Htmlstring.Replace(" ", "&nbsp;");
            Htmlstring = Htmlstring.Replace("<", "&lt;");
            Htmlstring = Htmlstring.Replace(">", "&gt;");
            Htmlstring = Regex.Replace(Htmlstring, @"\r\n", "<br/>", RegexOptions.IgnoreCase);
            return Htmlstring;
        }
    }
}
