using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages.SysSet
{
    public partial class ModifyLoginPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                this.imgbtncanel.Enabled = false;
                this.imgbtnsave.Enabled = false;
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('无法更改')</script>", false);
            }
            else
            {
                EtNet_Models.LoginInfo model = (EtNet_Models.LoginInfo)Session["login"];
                this.iptlogin.Value = model.Loginid;
                this.iptlogin.Disabled = true;
            }
        }


        //保存修改
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            EtNet_Models.LoginInfo model = (EtNet_Models.LoginInfo)Session["login"];
            string pastPwd = EtNet_BLL.CodeMD5.GetMD5(this.iptdefpwd.Value.ToString());
            if (pastPwd != model.Loginpwd)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('更改失败,原密码输入错误')</script>", false);
            }
            else
            {
                model.Loginpwd = EtNet_BLL.CodeMD5.GetMD5(this.iptpwd.Value.ToString());
                EtNet_BLL.LoginInfoManager.updateLoginInfo(model);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('更改成功');winclose();</script>", false);
            }
        }

        //取消修改
        protected void imgbtncanel_Click(object sender, ImageClickEventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "modify", "<script> winclose();</script>", false);
        }

    }
}