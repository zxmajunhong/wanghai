using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

namespace EtNet_Web.CMS.SysSet
{
    public partial class Support : System.Web.UI.Page
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
            // object showVerifyCode = ConfigurationManager.AppSettings["LoginShowVerifyCode"];
            object copyright = ConfigurationManager.AppSettings["LoginCopyright"];
            object tel = ConfigurationManager.AppSettings["LoginTel"];
            object email = ConfigurationManager.AppSettings["LoginEmail"];
            object support = ConfigurationManager.AppSettings["LoginSupport"];
            object fax = ConfigurationManager.AppSettings["LoginFax"];
            object url = ConfigurationManager.AppSettings["LoginURL"];
            //if (showVerifyCode != null)
            //{
            //    ListItem selectedItem = DdlShowVerifyCode.Items.FindByValue(showVerifyCode.ToString());
            //    int selectedIndex = DdlShowVerifyCode.Items.IndexOf(selectedItem);
            //    DdlShowVerifyCode.SelectedIndex = selectedIndex;
            //}
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
                TxtFax.Text = fax.ToString();
            }
            if (url != null)
            {
                TxtURL.Text = url.ToString();
            }
        }



        protected void itbnSave_Click(object sender, ImageClickEventArgs e)
        {
            Configuration conf = WebConfigurationManager.OpenWebConfiguration("~");

            // conf.AppSettings.Settings["LoginShowVerifyCode"].Value = DdlShowVerifyCode.SelectedValue;
            conf.AppSettings.Settings["LoginCopyright"].Value = TxtCopyright.Text.ToString();
            conf.AppSettings.Settings["LoginTel"].Value = TxtTel.Text.ToString();
            conf.AppSettings.Settings["LoginEmail"].Value = TxtEmail.Text.ToString();
            conf.AppSettings.Settings["LoginSupport"].Value = TxtSupport.Text.ToString();
            conf.AppSettings.Settings["LoginFax"].Value = TxtFax.Text.ToString();
            conf.AppSettings.Settings["LoginURL"].Value = TxtURL.Text.ToString();

            //否则无法保存修改
            conf.Save();
            ConfigurationManager.RefreshSection("AppSettings");

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存成功')</script>");
        }
    }
}