using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

namespace EtNet_Web.Pages.AppConfig
{
    public partial class AppConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitConfig();
            }
        }

        /// <summary>
        /// 初始化配置数据
        /// </summary>
        private void InitConfig()
        {
            object showVerifyCode = ConfigurationManager.AppSettings["ShowVerifyCode"];
            object copyright = ConfigurationManager.AppSettings["Copyright"];
            object tel = ConfigurationManager.AppSettings["Tel"];
            object email = ConfigurationManager.AppSettings["Email"];
            object support = ConfigurationManager.AppSettings["Support"];
            object fax = ConfigurationManager.AppSettings["Fax"];
            if (showVerifyCode != null)
            {
                ListItem selectedItem = DdlShowVerifyCode.Items.FindByValue(showVerifyCode.ToString());
                int selectedIndex = DdlShowVerifyCode.Items.IndexOf(selectedItem);
                DdlShowVerifyCode.SelectedIndex = selectedIndex;
            }
            if (copyright != null)
            {
                TxtCopyright.Text = copyright.ToString();
            }
            if (tel != null)
            {
                TxtTel.Text = tel.ToString();
            }
            if (email != null)
            {
                TxtEmail.Text = email.ToString();
            }
            if (support != null)
            {
                TxtSupport.Text = support.ToString();
            }
            if (fax != null)
            {
                TxtFax.Text = support.ToString();
            }
        }

        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            Configuration conf = WebConfigurationManager.OpenWebConfiguration("~");

            conf.AppSettings.Settings["ShowVerifyCode"].Value = DdlShowVerifyCode.SelectedValue;
            conf.AppSettings.Settings["Copyright"].Value = TxtCopyright.Text;
            conf.AppSettings.Settings["Tel"].Value = TxtTel.Text;
            conf.AppSettings.Settings["Email"].Value = TxtEmail.Text;
            conf.AppSettings.Settings["Support"].Value = TxtSupport.Text;
            conf.AppSettings.Settings["Fax"].Value = TxtFax.Text;

            //否则无法保存修改
            conf.Save();
            ConfigurationManager.RefreshSection("AppSettings");

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存成功')</script>");
        }
    }
}