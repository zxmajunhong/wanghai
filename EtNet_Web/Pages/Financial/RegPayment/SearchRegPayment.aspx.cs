using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_Models;

namespace EtNet_Web.Pages.Financial.RegPayment
{
    public partial class SearchRegPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string paymentID = Request.QueryString["payid"];
                if (Request.QueryString["payid"] == null || Request.QueryString["payid"].ToString().Trim() == string.Empty)
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');location.href='RegPaymentList.aspx';", true);
                    return;
                }
                else
                {
                    LoadPaymentData(paymentID);
                    LoadData(paymentID);
                }
            }
        }

        /// <summary>
        /// 加载付款信息
        /// </summary>
        /// <param name="paymentID"></param>
        private void LoadPaymentData(string paymentID)
        {
            To_PaymentManager bPayment = new To_PaymentManager();

            DataTable dtPayment = bPayment.GetViewPaymentList(string.Format("and id='{0}'", paymentID));

            if (dtPayment.Rows.Count > 0)
            {
                DataRow row = dtPayment.Rows[0];
                lblSerialNumber.Text = row["serialNum"].ToString(); //申请单号
                lblRequestDate.Text = DateTime.Parse(row["requestDate"].ToString()).ToString("yyyy-MM-dd"); //申请日期
                lblMaker.Text = row["makerName"].ToString(); //制单员
                lblpayType.Text = row["payType"].ToString(); //支付方式
                lblPayerName.Text = row["payerName"].ToString(); //收款单位名称
                lblPayFor.Text = row["paymentType"].ToString(); //付款类别
                lblSumAmount.Text = decimal.Parse(row["totalAmount"].ToString()).ToString("N2"); //支付金额合计
                lblPayBank.Text = row["bankName"].ToString(); //付款银行
                lblPayAccount.Text = row["bankAccount"].ToString(); //付款帐号
                lblPayAccountName.Text = row["bankAccountName"].ToString(); //付款账户人
                lblBank.Text = row["getBank"].ToString(); //收款银行
                lblBankAccount.Text = row["getAccount"].ToString(); //收款帐号
                lblBankAccountName.Text = row["getAccountName"].ToString(); //收款账户人

                sumBox.InnerText = lblSumAmount.Text; //金额合计

                LoadPaymentDetail(paymentID);
                LoadReturnDetail(paymentID);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "load", "alert('数据不存在或没有权限查看');location.href='PaymentList.aspx';", true);
            }
        }

        /// <summary>
        /// 加载支付明细数据
        /// </summary>
        /// <param name="paymentID"></param>
        private void LoadPaymentDetail(string paymentID)
        {
            To_PaymentDetailManager bPaymentDetail = new To_PaymentDetailManager();

            RpPaymentDetail.DataSource = bPaymentDetail.GetList(" paymentid ='" + paymentID + "'");
            RpPaymentDetail.DataBind();
        }

        private void LoadReturnDetail(string paymentId)
        {
            RpReturnList.DataSource = To_PaymentReturnManager.GetList(" paymentID='" + paymentId + "'");
            RpReturnList.DataBind();
        }

        /// <summary>
        /// 加载支付数据
        /// </summary>
        /// <param name="paymentID"></param>
        private void LoadData(string paymentID)
        {
            RegPaymentManager manager = new RegPaymentManager();
            EtNet_Models.RegPayment regpayment = manager.GetModel(paymentID);
            if (regpayment != null)
            {
                lblIsPay.Text = regpayment.payStatus == 1 ? "已支付" : "未支付"; //是否支付
                if (regpayment.payStatus == 1)
                {
                    lblPayer.Text = regpayment.payerName; //支付人
                    lblPaymentDate.Text = regpayment.paymentDate.ToString("yyyy-MM-dd"); //支付时间
                }
                else
                {
                    lblPayer.Text = "";
                    lblPaymentDate.Text = "";
                }
                lblHasInvoice.Text = regpayment.hasInvoice == 1 ? "已收到" : "未收到"; //是否收到发票
                if (regpayment.hasInvoice == 1)
                {
                    lblHasInvoiceDate.Text = regpayment.hasInvoiceDate.ToString("yyyy-MM-dd"); //收到发票日期
                }
                else
                {
                    lblHasInvoiceDate.Text = "";
                }
                lblpz.Text = regpayment.payRemark; //凭证
            }

        }

        /// <summary>
        /// 得到订单id
        /// </summary>
        /// <param name="orderPayid">付款信息明细表id</param>
        /// <returns></returns>
        public string getOrderidpay(string orderPayid)
        {
            int id = 0;
            int.TryParse(orderPayid, out id);
            To_OrderPayDetial model = To_OrderPayDetialManager.getTo_OrderPayDetialById(id);
            if (model != null)
                return model.Orderid.ToString();
            else
                return "";
        }

        public string getOrderidReturn(object orderReturnId)
        {
            int id = 0;
            int.TryParse(orderReturnId.ToString(), out id);
            To_OrderRefunDetial model = To_OrderRefunDetialManager.getTo_OrderRefunDetialById(id);
            if (model != null)
            {
                return model.Orderid.ToString();
            }
            else
                return "";

        }
    }
}