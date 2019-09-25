using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.expense
{
    public partial class OutComeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_InititalData();
            }
        }

        private void Load_InititalData()
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                To_Outcome outcome = To_OutcomeManager.GetModel(id);

                this.lblOutcomeDate.Text = outcome.OutComeDate.ToString("yyyy-MM-dd");
                this.lblOutComeItem.Text = outcome.OutComeItem;
                this.lblOutcomeMoney.Text = outcome.OutComeMoney.ToString("0.00");
                this.lblComeDepart.Text = outcome.ComeUnit;
                this.lblOutcomeBank.Text = outcome.OutComeBankName;
                this.lblOutcomeBankAccount.Text = outcome.OutComeBankAccount;
                this.lblOutcomeDepart.Text = outcome.OutComeDepart;
                this.LtrMark.Text = outcome.Remark;
                this.lblmakeName.Text = outcome.MakeName;
                this.lblmakeDate.Text = outcome.MakeDate.ToString("yyyy-MM-dd");
                this.lblOutcomeStatus.Text = outcome.OutComeStatus == "1" ? "已支付" : "未支付";
            }
        }
    }
}