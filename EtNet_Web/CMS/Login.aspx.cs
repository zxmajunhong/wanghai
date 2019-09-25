using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Web.Security;

namespace EtNet_Web.CMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            // string loginid = this.txtLoginId.Text.Trim();
            // string loginpwd = this.txtPwd.Text.Trim();
            string loginid = this.txtLoginId.Text;
            string loginpwd = this.txtPwd.Text;
            string pwd = EtNet_BLL.CodeMD5.GetMD5(loginpwd);
            LoginInfo login = LoginInfoManager.Login(loginid, pwd);


            if (login != null)
            {
                if (loginid == "admin")
                {
                    Session["CMSLogin"] = login;
                    Session["login"] = login;
                    Session.Timeout = 5;
                    // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='index.aspx'", true);
                    Response.Redirect("Index.aspx");
                    FormsAuthentication.SignOut();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('此用户没有权限登录！')", true);// 错误提示
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('用户不存在或密码错误！')", true);// 错误提示
                this.txtPwd.Text = "";//清空密码
            }
        }

        private int LoginLimitIsEmpty()
        {
            LoginInfo login = LoginInfoManager.getLoginInfoByLoginID(this.txtLoginId.Text.ToString());
            return LoginUserLimitManager.GetLimitCount(login.Id);
        }

    }
}