using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Web.Security;
using System.Configuration;
using System.Text;
using System.Data;

namespace EtNet_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowVerifyCode();
            LoadCopyright();
            Page.DataBind();
            if (Session["login"] != null)
            {
                Response.Redirect("Index.aspx");
            }


        }

        private void ShowVerifyCode()
        {
            object showVerifyCode = ConfigurationManager.AppSettings["LoginShowVerifyCode"];
            if (showVerifyCode == null)
            {
                return;
            }
            if (showVerifyCode.ToString() == "display")
            {
                AuthCode1.Visible = true;
            }
            else
            {
                AuthCode1.Visible = false;
                codeBox.Visible = false;
            }
        }

        private void LoadCopyright()
        {
            object tel = ConfigurationManager.AppSettings["LoginTel"];
            object email = ConfigurationManager.AppSettings["LoginEmail"];

            StringBuilder footHtml = new StringBuilder();

            if (tel != null)
            {
                footHtml.Append("联系电话:");
                footHtml.Append(tel);
                footHtml.Append("<br />");
            }

            if (email != null)
            {
                footHtml.Append("电子邮箱:");
                footHtml.Append(email);
                footHtml.Append("<br />");
            }
            LtrCopyRight.Text = footHtml.ToString().TrimEnd("<br />".ToArray());
        }

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            // string loginid = this.txtLoginId.Text.Trim();
            // string loginpwd = this.txtPwd.Text.Trim();


            string loginid = this.txtLoginId.Text;
            string loginpwd = this.txtPwd.Text;

            string pwd = CodeMD5.GetMD5(loginpwd);

            //加密后的
            LoginInfo login = LoginInfoManager.Login(loginid, pwd);
            //未加密的
            //LoginInfo login = LoginInfoManager.Login(loginid, loginpwd);
            if (login != null)
            {
                //检测是否有权限进入
                if (LoginLimitIsEmpty() > 0)
                {
                    //检测是否已经有用户登录，防止session被覆盖
                    if (LoginIsEmpty())
                    {

                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "login", "<script>alert('已有用户登录')</script>", false);
                    }
                    else
                    {
                        Session["login"] = login;
                        // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='index.aspx'", true);
                        Response.Redirect("Index.aspx");
                        FormsAuthentication.SignOut();
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('当前用户没有设置使用权限,请与系统管理员联系！')</script>", false);
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


        /// <summary>
        /// 检测是否有用户登录
        /// </summary>
        /// <returns></returns>
        private bool LoginIsEmpty()
        {
            if (Session["login"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 获取消息提示
        /// </summary>
        /// <returns></returns>
        public string GetMsgData()
        {

            string strsql = " sortid=1 AND visiblecode=1 AND statusid=2 ";
            DataTable tbl = EtNet_BLL.AnnouncementInfoManager.GetList(strsql);
            string strdata = "";
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                strdata += "'" + tbl.Rows[i]["title"].ToString() + "',";
            }
            if (strdata != "")
            {
                strdata = strdata.Substring(0, strdata.Length - 1);
            }
            strdata = "[" + strdata + "]";

            return strdata;
        }

    }
}