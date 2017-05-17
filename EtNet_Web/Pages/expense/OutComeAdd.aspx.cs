using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;


namespace EtNet_Web.Pages.expense
{
    public partial class OutComeAdd : System.Web.UI.Page
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
            this.lblMaker.Text = ((LoginInfo)Session["login"]).Cname;
            this.lblMakeDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Load_Bank();
            Load_Depart();
            BindOutComeType();
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

        private int AddPayment()
        {
            LoginInfo currentUser = Session["login"] as LoginInfo;
            To_Outcome outcome = new To_Outcome();

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
            outcome.MakeName = currentUser.Cname;
            outcome.MakeId = currentUser.Id;
            outcome.MakeDate = DateTime.Now;
            outcome.OutComeStatus = this.payStatus.Checked ? "1" : "0";

            int result = To_OutcomeManager.Add(outcome);
            return result;
        }

        protected void ibtSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (AddPayment() > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存成功');self.location.href='OutComeList.aspx';", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存失败');", true);
            }
        }

        
    }
}