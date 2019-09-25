using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.SysSet
{
    public partial class UpdateUserPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                LoginInfo logininfo = LoginInfoManager.getLoginInfoById(id);
                this.iptlogin.Text = logininfo.Cname;
            }
        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            LoginInfo logininfo = LoginInfoManager.getLoginInfoById(id);
            string pwd = EtNet_BLL.CodeMD5.GetMD5(this.iptpwd.Value.ToString());
            logininfo.Loginpwd = pwd;
            int count = LoginInfoManager.updateLoginInfo(logininfo);
            if (count>0)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('修改成功');winclose();</script>");
            }
        }
    }
}