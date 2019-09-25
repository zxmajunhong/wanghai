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
    public partial class OutComeUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_InitialData();
            }
        }

        /// <summary>
        /// 加载初始信息
        /// </summary>
        private void Load_InitialData()
        {
            Load_Bank();
            Load_Depart();
            BindOutComeType();
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                To_Outcome outcome = To_OutcomeManager.GetModel(id);

                this.txtFKDate.Text = outcome.OutComeDate.ToString("yyyy-MM-dd");
                this.ddlpayitem.SelectedValue = outcome.OutComeItemId.ToString();
                this.txtPayMoney.Text = outcome.OutComeMoney.ToString("0.00");
                this.txtSKUnit.Text = outcome.ComeUnit.ToString();
                this.ddlPayBank.SelectedValue = outcome.OutComeBankId.ToString();
                this.lblPayAccount.Text = outcome.OutComeBankAccount;
                this.ddlPayDepart.SelectedValue = outcome.OutComeDepartId.ToString();
                this.txtMark.Value = outcome.Remark;
                this.lblMaker.Text = outcome.MakeName;
                this.lblMakeDate.Text = outcome.MakeDate.ToString("yyyy-MM-dd");
                this.payStatus.Checked = outcome.OutComeStatus == "1" ? true : false;
            }
        }

        /// <summary>
        /// 绑定付款类别
        /// </summary>
        private void BindOutComeType()
        {
            ddlpayitem.Items.Clear();
            DataTable dt = AusFinInfoManager.GetList("");
            DataRow dr = dt.NewRow();
            dr["itemname"] = "——请选择——";
            dr["id"] = "0";
            dt.Rows.InsertAt(dr, 0);
            ddlpayitem.DataTextField = "itemname";
            ddlpayitem.DataValueField = "id";
            ddlpayitem.DataSource = dt;
            ddlpayitem.DataBind();
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
            ddlPayBank.DataTextField = "bankname";
            ddlPayBank.DataValueField = "id";
            ddlPayBank.DataSource = dtBanks;
            ddlPayBank.DataBind();
        }

        /// <summary>
        /// 选择银行之后显示帐号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPayBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPayBank.SelectedIndex > 0)
            {
                FirmAccountInfo bankInfo = FirmAccountInfoManager.GetModel(int.Parse(ddlPayBank.SelectedValue));
                this.lblPayAccount.Text = bankInfo.account.Trim();
            }
            else
                this.lblPayAccount.Text = "";
        }

        /// <summary>
        /// 绑定部门
        /// </summary>
        private void Load_Depart()
        {
            DataTable dtDeparts = DepartmentInfoManager.GetList("");

            ddlPayDepart.DataTextField = "departcname";
            ddlPayDepart.DataValueField = "departid";
            ddlPayDepart.DataSource = dtDeparts;
            ddlPayDepart.DataBind();
        }

        private int UpdatePayment()
        {
            string id = Request.QueryString["id"];
            To_Outcome outcome = To_OutcomeManager.GetModel(id);

            outcome.OutComeDate = DateTime.Parse(this.txtFKDate.Text.Trim()); //付款日期
            outcome.OutComeItem = this.ddlpayitem.SelectedItem.Text; ; //付款类别
            outcome.OutComeItemId = int.Parse(ddlpayitem.SelectedValue); //付款类别对应id
            outcome.OutComeMoney = double.Parse(this.txtPayMoney.Text); //付款金额
            outcome.ComeUnit = this.txtSKUnit.Text.Trim(); //收款单位
            outcome.OutComeBankName = this.ddlPayBank.SelectedItem.Text; //付款银行
            outcome.OutComeBankId = int.Parse(this.ddlPayBank.SelectedValue);
            outcome.OutComeBankAccount = this.lblPayAccount.Text.Trim(); //付款帐号
            outcome.OutComeDepart = this.ddlPayDepart.SelectedItem.Text; //所属部门
            outcome.OutComeDepartId = int.Parse(this.ddlPayDepart.SelectedValue); //所属部门id
            outcome.Remark = this.txtMark.Value.Trim(); //备注
            outcome.OutComeStatus = this.payStatus.Checked ? "1" : "0";

            int result = To_OutcomeManager.Update(outcome);
            return result;
        }

        protected void ibtSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (UpdatePayment() > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('更新成功');self.location.href='OutComeList.aspx';", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('更新失败');", true);
            }
        }
    }
}