using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Financial.PayConfirm
{
    public partial class PayConfirmed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPayInfo();
                LoadPayAccount();
                LoadGetAccount();

                LoginInfo login = ((LoginInfo)Session["login"]);
                this.confirmMan.Value = login.Cname;
                this.confirmDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        /// <summary>
        /// 加载付款信息
        /// </summary>
        private void LoadPayInfo()
        {
            string id = Request.QueryString["id"];
            id = "(" + id + ")";
            string sql = "jobFlowID in " + id;
            To_PaymentManager paymanager = new To_PaymentManager();
            DataTable dt = paymanager.GetList(sql);
            payRepeater.DataSource = dt;
            payRepeater.DataBind();
        }

        /// <summary>
        /// 加载支付帐号信息
        /// </summary>
        private void LoadPayAccount()
        {
            this.payAccount.Items.Clear();
            this.payAccount.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = FirmAccountInfoManager.GetList("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Text = "开户银行:" + dt.Rows[i]["bankname"].ToString() + ", 银行帐号:" + dt.Rows[i]["account"].ToString() + ", 开户名称:" + dt.Rows[i]["accountUser"].ToString();
                adItem.Value = dt.Rows[i]["bankname"].ToString() + "," + dt.Rows[i]["account"].ToString() + "," + dt.Rows[i]["accountUser"].ToString() + "," + dt.Rows[i]["id"].ToString();
                this.payAccount.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 加载收款帐号信息
        /// </summary>
        private void LoadGetAccount()
        {
            string factid = Request.QueryString["factid"];
            this.getAccount.Items.Clear();
            this.getAccount.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = FactoryManager.getList(" id='" + factid + "'");
            if (dt.Rows.Count > 0)
            {
                ListItem item1 = new ListItem();
                item1.Text = "开户银行:" + dt.Rows[0]["bank"].ToString() + ", 银行帐号:" + dt.Rows[0]["accountID"].ToString() + ", 开户名称:" + dt.Rows[0]["accountName"].ToString();
                item1.Value = dt.Rows[0]["bank"].ToString() + "," + dt.Rows[0]["accountID"].ToString() + "," + dt.Rows[0]["accountName"].ToString();
                this.getAccount.Items.Add(item1);
                DataTable tbl = FactBankManager.getList(int.Parse(dt.Rows[0]["id"].ToString()));
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    ListItem adItem = new ListItem();
                    adItem.Text = "开户银行:" + tbl.Rows[i]["bank"].ToString() + ", 银行帐号:" + tbl.Rows[i]["accountId"].ToString() + ", 开户名称:" + tbl.Rows[i]["accountName"].ToString();
                    adItem.Value = tbl.Rows[i]["bank"].ToString() + "," + tbl.Rows[i]["accountId"].ToString() + "," + tbl.Rows[i]["accountName"].ToString();
                    this.getAccount.Items.Add(adItem);
                }
            }
        }

        /// <summary>
        /// 更新帐号方法
        /// </summary>
        private void UpdatePayment()
        {
            string jfid = Request.QueryString["id"].ToString();
            string[] jfids = jfid.Split(',');
            bool result = true;
            string[] payAccounts = payAccount.SelectedValue.Split(','); //支付帐号信息（0、银行名；1、帐号；2、开户名）
            string[] getAccounts = getAccount.SelectedValue.Split(','); //收款帐号信息
            To_PaymentManager paymentManager = new To_PaymentManager();
            To_Payment payment = null;
            for (int i = 0; i < jfids.Length; i++)
            {
                payment = paymentManager.GetModelByjfid(jfids[i]);
                if (this.payAccount.SelectedIndex != 0)
                {
                    payment.bankName = payAccounts[0];
                    payment.bankAccount = payAccounts[1];
                    payment.bankAccountName = payAccounts[2];
                    payment.bankID = int.Parse(payAccounts[3]);
                }
                else
                {
                    payment.bankName = payment.bankAccount = payment.bankAccountName = "";
                    payment.bankID = 0;
                }
                if (this.getAccount.SelectedIndex != 0)
                {
                    payment.getBank = getAccounts[0];
                    payment.getAccount = getAccounts[1];
                    payment.getAccountName = getAccounts[2];
                }
                else
                {
                    payment.getBank = payment.getAccount = payment.getAccountName = "";
                }
                payment.payType = "转账"; /*this.payType.SelectedValue; //支付方式*/
                payment.isConfirm = "1"; //确认状态
                LoginInfo login = ((LoginInfo)Session["login"]);
                payment.confirmMan = login.Cname; //确认人
                payment.confirmDate = DateTime.Now; //确认日期
                result = paymentManager.UpdateAccount(payment);
                if (!result)
                {
                    break;
                }
            }
            if (result)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "false", "alert('保存成功！');location.href='payConfirmList.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "false", "alert('保存失败！');", true);
            }

        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            UpdatePayment();
        }

        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("payConfirmList.aspx");
        }


    }
}