using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Supplier
{
    public partial class FactLinkInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getmainlink();
            getCuslink();
        }


        private void getmainlink()
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Factory fact = FactoryManager.getFactoryById(Convert.ToInt32(id));
            this.lblLinkname.Text = fact.LinkeName.ToString();
            this.lblPost.Text = fact.Duty.ToString();
            this.lblTel.Text = fact.Telephone.ToString();
            this.lblFax.Text = fact.Fax.ToString();
            this.lblEmail.Text = fact.Email.ToString();
            this.lblMobile.Text = fact.Mobile.ToString();
            this.lblMsn.Text = fact.QQ.ToString();
            this.lblSkype.Text = fact.Skype.ToString();
        }

        //获取次要联系人
        private void getCuslink()
        {
            string id = Request.QueryString["id"].ToString();
            IList<FactLinkman> factLinkman = FactLinkmanManager.getFactLinkmanByFactId(Convert.ToInt32(id));
            if (factLinkman.Count == 0)
            {
                tip.InnerHtml = "<div style='line-height:60px;height:60px;width:100%;text-align:center;'><p style='color:gray;width:200px;margin:0 auto;background:#FFFFFF;border:solid 0px #ccc; text-algin:center'><p></div>";
            }
            else
            {
                cuslinklist.DataSource = factLinkman;
            }
            cuslinklist.DataBind();
        }
    }
}