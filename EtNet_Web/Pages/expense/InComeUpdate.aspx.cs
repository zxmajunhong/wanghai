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
    public partial class InComeUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Type();
                Load_InitialData();
            }
        }

        private void Load_Type()
        {
            ddlsktype.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = IncomeTypeManager.GetList("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Text = dt.Rows[i]["typename"].ToString();
                adItem.Value = dt.Rows[i]["id"].ToString();
                ddlsktype.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 加载初始信息
        /// </summary>
        private void Load_InitialData()
        {
            Load_Bank();
            Load_Depart();
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                To_Income income = To_IncomeManager.GetModel(id);
                this.txtSKDate.Text = income.ComeDate.ToString("yyyy-MM-dd");
                this.txtMoney.Text = income.ComeMoney.ToString("0.00");
                this.ddlBank.SelectedValue = income.ComeBankId.ToString();
                this.lblBankAccount.Text = income.ComeBankAccount;
                this.ddlDepart.SelectedValue = income.ComeDepartId.ToString();
                this.txtMark.Value = income.Remark;
                this.lblMaker.Text = income.MakeName;
                this.lblMakeDate.Text = income.MakeDate.ToString("yyyy-MM-dd");
                this.txtSKUnit.Text = income.ComeUnit;
                this.ddlsktype.SelectedValue = income.SKTypeId.ToString();
            }
        }

        /// <summary>
        /// 绑定银行信息
        /// </summary>
        private void Load_Bank()
        {

            DataTable dtBanks = FirmAccountInfoManager.GetList("");
            DataRow dr = dtBanks.NewRow();
            dr["bankname"] = "——请选择——";
            dr["id"] = "0";
            dtBanks.Rows.InsertAt(dr, 0);
            ddlBank.DataTextField = "bankname";
            ddlBank.DataValueField = "id";
            ddlBank.DataSource = dtBanks;
            ddlBank.DataBind();
        }

        /// <summary>
        /// 选择银行之后显示帐号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBank.SelectedIndex > 0)
            {
                FirmAccountInfo bankInfo = FirmAccountInfoManager.GetModel(int.Parse(ddlBank.SelectedValue));
                this.lblBankAccount.Text = bankInfo.account.Trim();
            }
            else
                this.lblBankAccount.Text = "";
        }

        /// <summary>
        /// 绑定部门
        /// </summary>
        private void Load_Depart()
        {
            DataTable dtDeparts = DepartmentInfoManager.GetList("");

            ddlDepart.DataTextField = "departcname";
            ddlDepart.DataValueField = "departid";
            ddlDepart.DataSource = dtDeparts;
            ddlDepart.DataBind();
        }

        private int UpdateCollecting()
        {
            string id = Request.QueryString["id"];
            To_Income income = To_IncomeManager.GetModel(id);

            income.ComeDate = DateTime.Parse(this.txtSKDate.Text.Trim());
            income.ComeMoney = double.Parse(this.txtMoney.Text.Trim());
            income.ComeBankName = this.ddlBank.SelectedItem.Text;
            income.ComeBankId = int.Parse(this.ddlBank.SelectedValue);
            income.ComeBankAccount = this.lblBankAccount.Text;
            income.ComeDepart = this.ddlDepart.SelectedItem.Text; //所属部门
            income.ComeDepartId = int.Parse(ddlDepart.SelectedValue); //所属部门id
            income.Remark = this.txtMark.Value; //备注
            income.ComeUnit = this.txtSKUnit.Text.Trim();
            income.SKTypeId = Convert.ToInt32(ddlsktype.SelectedValue);
            income.SKType = ddlsktype.SelectedValue == "0" ? "" : ddlsktype.SelectedItem.Text;

            return To_IncomeManager.Update(income);
        }


        protected void ibtSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (UpdateCollecting() > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('更新成功');self.location.href='InComeList.aspx';", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('更新失败');", true);
            }
        }
    }
}