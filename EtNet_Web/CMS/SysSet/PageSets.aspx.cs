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
    public partial class PageSets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadSet();

            }
        }

        protected void itbnSave_Click(object sender, ImageClickEventArgs e)
        {
            Configuration conf = WebConfigurationManager.OpenWebConfiguration("~");

            // conf.AppSettings.Settings["LoginShowVerifyCode"].Value = DdlShowVerifyCode.SelectedValue;
            conf.AppSettings.Settings["CMSCount"].Value = this.ddlShowCount.SelectedValue;
            conf.AppSettings.Settings["CMSPage"].Value = this.ddlShowPage.SelectedValue;

            //否则无法保存修改
            conf.Save();
            ConfigurationManager.RefreshSection("AppSettings");

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存成功')</script>");
        }


        private void loadSet()
        {
            object count = ConfigurationManager.AppSettings["CMSCount"];
            object page = ConfigurationManager.AppSettings["CMSPage"];

            if (count != null)
            {
                this.ddlShowCount.SelectedValue = count.ToString();
            }
            if (page != null)
            {
                this.ddlShowPage.SelectedValue = page.ToString();
            }
        }
    }
}