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
    public partial class FactBankInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getMain();
            bank();
        }



        private void getMain()
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Factory cus = FactoryManager.getFactoryById(Convert.ToInt32(id));
            this.lblBank.Text = cus.Bank.ToString();
            this.lblCardID.Text = cus.AccountID.ToString();
            this.lblName.Text = cus.AccountName.ToString();
            this.lblRemark.Text = cus.Remark.ToString();
        }

        private void bank()
        {
            string id = Request.QueryString["id"].ToString();
            IList<FactBank> factbank = FactBankManager.getFactBankByFacrId(Convert.ToInt32(id));
            if (factbank.Count == 0)
            {
                tip.InnerHtml = "<div style='line-height:60px;height:60px;width:100%;text-align:center;'><p style='color:gray;width:200px;margin:0 auto;background:#FFFFFF;border:solid 0px #ccc; text-algin:center'><p></div>";
            }
            else
            {
                banklist.DataSource = factbank;
            }

            banklist.DataBind();
        }
    }
}