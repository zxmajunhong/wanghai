using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
namespace Common
{
    /// <summary>
    /// 重写基类(生成静态页类)
    /// </summary>
    public class ReWhitePage : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.AuthorizeRequest += delegate(object sender, EventArgs e)
            {
                HttpApplication app2 = (HttpApplication)sender;
                Rewrite(app2.Request.Path, app2);
            };
        }

        /// <summary>
        /// 处置由实现 System.Web.IHttpModule 的模块使用的资源(内存除外)
        /// </summary>
        public void Dispose() { }
        /// <summary>
        /// URL 重写
        /// </summary>
        /// <param name="requestedPath"></param>
        /// <param name="app"></param>
        protected void Rewrite(string requestedPath, System.Web.HttpApplication app)
        {
            //这边为方便演示直接往集合添加规则，实际应用可考虑将规则写到配置文件中再读取
            Dictionary<string, string> rules = new Dictionary<string, string>();
            rules.Add(@"^/soft/(\w+)\.aspx", "/soft.aspx?t=$1");
            rules.Add(@"^/music/(\w+)\.aspx", "/music.aspx?t=$1");

            rules.Add(@"^/Directory.html", "/Directory.aspx");
           
            rules.Add(@"^(?:/([1-9][0-9]*))?(?:/([1-9][0-9]*))?(?:/([1-9][0-9]*))?/(urlrewhite)\.aspx", "/$4.aspx?id=$2&page=$1&type=$3");
            rules.Add(@"^/info([1-9][0-9]*)/(urlrewhite)\.aspx", "/$2.aspx?id=$1");
            rules.Add(@"^/page([1-9][0-9]*)/(urlrewhite)\.aspx", "/$2.aspx?page=$1");

            rules.Add(@"^/example(?:/num([1-9][0-9]*))?(?:/id([1-9][0-9]*))?(?:/page([1-9][0-9]*))?/(datapage)\.aspx", "/example/$4.aspx?num=$1&id=$2&page=$3");
           
            foreach (KeyValuePair<string, string> rule in rules)
            {
                Match match = Regex.Match(app.Context.Request.Path, rule.Key, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    string sendToUrl = Regex.Replace(app.Context.Request.Path, rule.Key, rule.Value, RegexOptions.IgnoreCase);
                    string path = sendToUrl;//虚拟路径
                    string querystring = string.Empty;//查询参数
                    if (sendToUrl.IndexOf("?") != -1)
                    {
                        path = sendToUrl.Substring(0, sendToUrl.IndexOf("?"));
                        querystring = sendToUrl.Substring(sendToUrl.IndexOf("?") + 1);
                    }

                    app.Context.RewritePath(path, string.Empty, querystring);

                    return;
                }
            }
        }
    }

}