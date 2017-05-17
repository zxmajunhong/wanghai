using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;

namespace EtNet_Web.Pages.SysSet
{
    public partial class Service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSource();
        }

        private void LoadSource()
        {
            object copyright = ConfigurationManager.AppSettings["LoginCopyright"];
            object email = ConfigurationManager.AppSettings["LoginEmail"];
            object tel = ConfigurationManager.AppSettings["LoginTel"];
            object fax = ConfigurationManager.AppSettings["LoginFax"];
            object support = ConfigurationManager.AppSettings["LoginSupport"];
            object url = ConfigurationManager.AppSettings["LoginURL"];
            StringBuilder footHtml = new StringBuilder();
            if (copyright != null)
            {
                footHtml.Append("<strong>公司名称</strong>：");
                footHtml.Append(copyright);
                footHtml.Append("<br />");
            }

            if (tel != null)
            {
                footHtml.Append("<strong>联系电话</strong>：");
                footHtml.Append(tel);
                footHtml.Append("<br />");
            }

            if (email != null)
            {
                footHtml.Append("<strong>电子邮箱</strong>：");
                footHtml.Append(email);
                footHtml.Append("<br />");
            }

            if (support != null)
            {
                footHtml.Append("<strong>技术支持</strong>：");
                footHtml.Append(support);
                footHtml.Append("<br />");
            }
            if (fax != null)
            {
                footHtml.Append("<strong>联系传真</strong>：");
                footHtml.Append(fax);
                footHtml.Append("<br />");
            }
            if (url != null)
            {
                footHtml.Append("<strong>公司网址</strong>：");
                footHtml.Append(url);
                footHtml.Append("<br />");
            }


            LtrCopyRight.Text = footHtml.ToString().TrimEnd("<br />".ToArray());
        }
    }
}