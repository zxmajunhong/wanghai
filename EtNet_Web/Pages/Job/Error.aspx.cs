using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtNet_Web.Pages.Job
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowEor();
        }


        /// <summary>
        /// 显示错误消息
        /// </summary>
        private void ShowEor()
        {
            string str = Request.QueryString["error"] == null ? "0" : Request.QueryString["error"];
            if(str == "0")
            {
                this.showerror.InnerHtml = "";
            }
            else if(str == "1")
            {
                this.showerror.InnerHtml = "无法进入修改页面!";
            }
            else if(str == "2")
            {
                this.showerror.InnerHtml = "单据修改失败!";
            }
        }
    }
}