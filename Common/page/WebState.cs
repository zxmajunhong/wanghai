using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Common
{
    public class WebState
    {
        /// <summary>
        /// 网状运营状态（在线人数、总人数、今日访问量）
        /// </summary>
        /// <returns>实体类（Model）</returns>
        public static Webs GetWebState()
        {
            Webs web = new Webs();
            string logFile = AppDomain.CurrentDomain.BaseDirectory + "Log/online.txt";
            FileStream fs = new FileStream(logFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            if (!sr.EndOfStream)
            {
                for (int i = 0; i < 4; i++)
                {
                    string str = sr.ReadLine();
                    if (i == 0)
                    {
                        web.TotalCount = str;
                    }
                    if (i == 1)
                    {
                        web.TodayCount = str;
                    }
                    if (i == 2)
                    {
                        web.OnlineCount = str;
                    }
                    if (i == 3)
                    {
                        web.TodayTime = str;
                    }
                }
            }
            sr.Close();
            fs.Close();
            return web;
        }
        public static string IPAddress
        {
            get
            {
                string userIP;
                // HttpRequest Request = HttpContext.Current.Request;
                HttpRequest Request = HttpContext.Current.Request; // ForumContext.Current.Context.Request;
                // 如果使用代理，获取真实IP
                if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                    userIP = Request.ServerVariables["REMOTE_ADDR"];
                else
                    userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (userIP == null || userIP == "")
                    userIP = Request.UserHostAddress;
                return userIP;
            }
        }

    }

    public class Webs
    {

        public Webs()
        {
        }
        private string _totalcount;
        private string _todaycount;
        private string _onlinecount;
        private string _todaytime;
        /// <summary>
        /// 
        /// </summary>
        public string TotalCount
        {
            set { _totalcount = value; }
            get { return _totalcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TodayCount
        {
            set { _todaycount = value; }
            get { return _todaycount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OnlineCount
        {
            set { _onlinecount = value; }
            get { return _onlinecount; }
        }
        public string TodayTime
        {
            set { _todaytime = value; }
            get { return _todaytime; }
        }
    }
}
