using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;

namespace EtNet_Web.Pages.Financial
{
    public partial class PaymentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object objPolicyID = Request.QueryString["pid"];

                if (null == objPolicyID)
                {
                    form1.InnerHtml = "<font color='red'>参数错误</font>";
                    return;
                }

                int policyID;
                if (!int.TryParse(objPolicyID.ToString().Trim(), out policyID))
                {
                    form1.InnerHtml = "<font color='red'>参数错误</font>";
                    return;
                }

                LoadPaymentDetail(policyID);
                LoadPolicyInfo(policyID);

                UCBudget.InitData(policyID);
                
            }
        }
        
        private void LoadPaymentDetail(int policyID)
        {
            //To_PaymentDetailManager bPaymentDetail = new To_PaymentDetailManager();

            //DataTable dtPaymentDetail= bPaymentDetail.GetPaymentDetailByPolicy(policyID);

            //if (dtPaymentDetail.Rows.Count > 0)
            //{
            //    RpPaymentDetail.DataSource = dtPaymentDetail;
            //    RpPaymentDetail.DataBind();
            //}
            //else 
            //{
            //    lblEmptyMsg.Visible = true;
            //}
        }

        private void LoadPolicyInfo(int policyId)
        {
            To_Policy mPolicy = To_PolicyManager.getTo_PolicyById(policyId);

            if (null == mPolicy) {
                return;
            }

            ltrPolicyInfo.Text = string.Format("您在查看编号为<font color='red'>{0}</font>的保单，保费<font color='red'>{1}代垫的</font>", mPolicy.Policy_num, mPolicy.IsDaidian == 0 ? "不是" : "是");
        }

        /// <summary>
        /// 获取付款名称
        /// </summary>
        /// <param name="payForField"></param>
        /// <returns></returns>
        protected string GetPayForName(object payForField)
        {
            string payForName = "未知";
            if (payForField == DBNull.Value || payForField == null) { return payForName; }

            string payFor = payForField.ToString();

            switch (payFor)
            {
                case "exp_premium":
                    payForName = "代垫保费";
                    break;
                case "exp_commission":
                    payForName = "佣金";
                    break;
                case "exp_tiefei":
                    payForName = "贴费";
                    break;
                case "exp_consultingFees":
                    payForName = "咨询费";
                    break;
                case "exp_serviceCharge":
                    payForName = "服务费";
                    break;
                case "exp_managementFees":
                    payForName = "管理费";
                    break;
                case "exp_other1":
                    payForName = "其他1";
                    break;
                case "exp_other2":
                    payForName = "其他2";
                    break;
                case "exp_other3":
                    payForName = "其他3";
                    break;
                case "exp_other4":
                    payForName = "其他4";
                    break;
                case "exp_other5":
                    payForName = "其他5";
                    break;
                default:
                    break;
            }

            return payForName;
        }
    }
}