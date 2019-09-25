using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

namespace EtNet_Web.CMS.SysSet.AppConfig
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
            object showVerifyCode = ConfigurationManager.AppSettings["LoginShowVerifyCode"];

            object tel = ConfigurationManager.AppSettings["LoginTel"];
            object email = ConfigurationManager.AppSettings["LoginEmail"];
            if (showVerifyCode != null)
            {
                ListItem selectedItem = DdlShowVerifyCode.Items.FindByValue(showVerifyCode.ToString());
                int selectedIndex = DdlShowVerifyCode.Items.IndexOf(selectedItem);
                DdlShowVerifyCode.SelectedIndex = selectedIndex;
            }

            if (tel != null)
            {
                TxtTel.Text = tel.ToString();
            }
            if (email != null)
            {
                TxtEmail.Text = email.ToString();
            }

        }

        protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            Configuration conf = WebConfigurationManager.OpenWebConfiguration("~");

            conf.AppSettings.Settings["LoginShowVerifyCode"].Value = DdlShowVerifyCode.SelectedValue;
            conf.AppSettings.Settings["LoginTel"].Value = TxtTel.Text;
            conf.AppSettings.Settings["LoginEmail"].Value = TxtEmail.Text;

            //否则无法保存修改
            conf.Save();
            ConfigurationManager.RefreshSection("AppSettings");

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存成功')</script>");
        }
    }
}