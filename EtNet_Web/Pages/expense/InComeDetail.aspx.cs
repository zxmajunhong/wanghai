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
    public partial class InComeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_InitialData();
            }
        }

        private void Load_InitialData()
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                To_Income income = To_IncomeManager.GetModel(id);
                this.lblIncomeDate.Text = income.ComeDate.ToString("yyyy-MM-dd");
                this.lblIncomeMoney.Text = income.ComeMoney.ToString("0.00");
                this.lblIncomeBankName.Text = income.ComeBankName;
                this.lblIncomeBankAccount.Text = income.ComeBankAccount;
                this.lblIncomeDepart.Text = income.ComeDepart;
                this.LtrMark.Text = income.Remark;
                this.lblmakeName.Text = income.MakeName;
                this.lblmakeDate.Text = income.MakeDate.ToString("yyyy-MM-dd");
                this.lblIncomeUnit.Text = income.ComeUnit;
                this.lblSktype.Text = income.SKType;
            }
        }
    }
}