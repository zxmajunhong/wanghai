using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Text;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object objPayFor = Request.QueryString["payfor"];
                object objPayer = Request.QueryString["payer"];
                object objPayerType = Request.QueryString["payertype"];
                
                if
                (
                    objPayFor == null || objPayer == null || objPayerType == null
                    || objPayer.ToString().Trim() == string.Empty || objPayFor.ToString().Trim() == string.Empty
                    || objPayerType.ToString().Trim() == string.Empty
                )
                {
                    form1.InnerHtml = "<font color=\"red\">参数信息错误</font>";
                    return;
                }

                string payFor = objPayFor.ToString().Trim();//付款名称
                string payer = objPayer.ToString().Trim();//付款单位ID
                string payerType = objPayerType.ToString().Trim();//付款单位类别，0：客户；1：公司

                LoadPolicyList(payer, payerType, payFor);
            }
        }

        /// <summary>
        /// 加载保单数据
        /// </summary>
        /// <param name="payer">付款单位ID</param>
        /// <param name="payerType">付款单位类别，0：客户；1：公司</param>
        /// <param name="payFor">付款单位名称</param>
        private void LoadPolicyList(string payer, string payerType, string payFor)
        {
            To_PaymentManager b_payment = new To_PaymentManager();

            StringBuilder whereBuilder = new StringBuilder();

            string payerField = payerType == "0" ? "customer" : "company";

            whereBuilder.AppendFormat("AND {0}={1} AND ( payerType = {2} or payerType is null or payFor is null ) ", payerField, payer, payerType);

            //if (withInvoice == "1")
            //{
            //    whereBuilder.Append("AND invoiceID IS NOT NULL ");
            //}

            RpPolicyList.DataSource = b_payment.GetPaymentInvoice(whereBuilder.ToString(), payFor);
            RpPolicyList.DataBind();
        }

        /// <summary>
        /// 获取剩余未付款金额
        /// </summary>
        /// <returns></returns>
        protected string GetPayForFiledName()
        {
            return Request.QueryString["payfor"].ToString().Trim();
        }


        protected string GetAmount(object policyAmount, object payAmount)
        {
            if (payAmount == DBNull.Value)
            {
                return Convert.ToDouble(policyAmount).ToString("F2");
            }

            return (Convert.ToDouble(policyAmount) - Convert.ToDouble(payAmount)).ToString("F2");
        }
    }
}