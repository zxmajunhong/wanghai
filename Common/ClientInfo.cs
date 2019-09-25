using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Management;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
namespace Common
{

    public class ClientInfo 
    {
        public static  string ClientIP()
        {
            string userIP;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] == null)
            {
                userIP = HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                userIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            return userIP;
        }
    

    }
}
