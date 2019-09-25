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
    public partial class InComeAdd : System.Web.UI.Page
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
            Load_Type();

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

        /// <summary>
        /// 绑定收款类别
        /// </summary>
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

        private int AddCollecting()
        {
            LoginInfo currentUser = Session["login"] as LoginInfo;
            To_Income income = new To_Income();

            income.ComeDate = DateTime.Parse(this.txtSKDate.Text.Trim()); //收款日期
            income.ComeMoney = double.Parse(this.txtMoney.Text.Trim()); //收款金额
            income.ComeUnit = this.txtSKUnit.Text.Trim();//付款单位
            income.ComeBankName = this.ddlBank.SelectedItem.Text; //入账银行
            income.ComeBankId = int.Parse(this.ddlBank.SelectedValue); //入账银行id
            income.ComeBankAccount = this.lblBankAccount.Text; //入账银行帐号
            income.ComeDepart = this.ddlDepart.SelectedItem.Text; //所属部门
            income.ComeDepartId = int.Parse(ddlDepart.SelectedValue); //所属部门id
            income.MakeName = currentUser.Cname; //制单员
            income.MakeId = currentUser.Id; //制单员id
            income.Remark = this.txtMark.Value; //备注
            income.MakeDate = DateTime.Parse(this.lblMakeDate.Text.Trim()); //制单日期
            income.SKTypeId = Convert.ToInt32(ddlsktype.SelectedValue);
            income.SKType = ddlsktype.SelectedValue == "0" ? "" : ddlsktype.SelectedItem.Text;

            int result = To_IncomeManager.Add(income);
            return result;
        }

        protected void ibtSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (AddCollecting() > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存成功');self.location.href='InComeList.aspx';", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存失败');", true);
            }
        }


    }
}