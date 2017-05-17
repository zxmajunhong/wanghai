using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class CusLinkInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getmainlink();
            getCuslink();
        }


        private void getmainlink() 
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Customer cus = CustomerManager.getCustomerById(Convert.ToInt32(id));
            this.lblLinkname.Text = cus.LinkName.ToString();
            this.lblPost.Text = cus.Post.ToString();
            this.lblTel.Text = cus.Telephone.ToString();
            this.lblFax.Text = cus.Fax.ToString();
            this.lblEmail.Text = cus.Email.ToString();
            this.lblMobile.Text = cus.Mobile.ToString();
            this.lblMsn.Text = cus.Msn.ToString();
            this.lblSkype.Text = cus.Skype.ToString();
        }

        //获取次要联系人
        private void getCuslink()
        {
            string id = Request.QueryString["id"].ToString();
            IList<CusLinkman> cusLinkman = CusLinkmanManager.getCusLinkmanByCusId(Convert.ToInt32(id));
            if (cusLinkman.Count == 0)
            {
                tip.InnerHtml = "<div style='line-height:60px;height:60px;width:100%;text-align:center;'><p style='color:gray;width:200px;margin:0 auto;background:#FFFFFF;border:solid 0px #ccc; text-algin:center'><p></div>";
            }
            else
            {
                cuslinklist.DataSource = cusLinkman;
            }
            cuslinklist.DataBind();
        }
    }
}