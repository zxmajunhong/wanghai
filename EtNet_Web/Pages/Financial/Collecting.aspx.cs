using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Financial
{
    public partial class Collecting : System.Web.UI.Page
    {
        #region ****************************Page_Load方法****************************
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx", true);
            }

            if (!IsPostBack)
            {
                object objID = Request.QueryString["id"];
                if (objID == null)
                {
                    Response.Redirect("CollectingList.aspx", true);
                }
                int id;
                if (!int.TryParse(objID.ToString(), out id))
                {
                    Response.Redirect("CollectingList.aspx", true);
                }

                LoadCollecting(id);
            }
        }
        #endregion

        #region ****************************方法****************************

        /// <summary>
        /// 根据单据ID加载收款单据数据
        /// </summary>
        /// <param name="id"></param>
        private void LoadCollecting(int id)
        {
            To_Collecting collectingModel = To_CollectingManager.getTo_CollectingById(id);
            if (collectingModel == null)
            {
                form1.InnerHtml = "<p style='font-size:14px;'>单据不存在，可能已被删除！<br /><a href='CollectingList.aspx'>返回单据列表</a></p>";
                return;
            }

            LblMakeDate.Text = collectingModel.MarkDate.ToShortDateString();
            LblMakeDepartment.Text = collectingModel.MarkerDepartment;
            LblPayBank.Text = collectingModel.PayBank;
            LblPayBankAcount.Text = collectingModel.PayBankAcount;
            LblPaymentUnit.Text = collectingModel.PaymentUnit;
            LblReceiptAmount.Text = collectingModel.ReceiptAmount.ToString("N2");
            LblReceiptDate.Text = collectingModel.ReceiptDate.ToShortDateString();
            LtrMark.Text = collectingModel.ReceiptMark;
            LblReceiptNum.Text = collectingModel.ReceiptNum;
            LtrConfirm.Text = collectingModel.ConfirmReceipt == 1 ? "已确认" : "<font color='red'>未确认</font>";
            LblMaker.Text = collectingModel.Marker;

            //如果已经确认那么显示确认信息
            if (collectingModel.ConfirmReceipt == 1)
            {
                confirm.Visible = true;
                DataTable dt = To_CollectingManager.getConfirmInfo(id.ToString());
                if (dt.Rows.Count > 0)
                {
                    this.lblConfirmMan.Text = dt.Rows[0]["confirmMan"].ToString();
                    this.lblConfirmDate.Text = dt.Rows[0]["confirmDate"].ToString();
                }
            }

            switch (collectingModel.PaymentMode)
            {
                case 0:
                    LblPaymentMode.Text = "现金";
                    break;
                case 1:
                    LblPaymentMode.Text = "转账";
                    break;
                case 2:
                    LblPaymentMode.Text = "网银";
                    break;
                default:
                    LblPaymentMode.Text = "未知";
                    break;
            }

            LblBusinessUnit.Text = collectingModel.BusinessUnit;

            if (collectingModel.PaymentMode != 0)
            {
                paymentInfo.Visible = true;
            }
            else
            {
                paymentInfo.Visible = false;
            }

            LoadClaimDetail(id);
        }

        /// <summary>
        /// 根据收款单据ID查询认领明细
        /// </summary>
        /// <param name="collcetingID"></param>
        /// <returns></returns>
        private void LoadClaimDetail(int collcetingID)
        {
            To_ClaimManager claimManager = new To_ClaimManager();
            To_ClaimDetailManager claimDetailManager = new To_ClaimDetailManager();
            string claimId = claimManager.GetFiledValue(collcetingID, "ID");
            if (claimId != "")
            {
                RpClaimDetail.DataSource = claimDetailManager.GetHasDetail(" claimID=" + claimId);
                RpClaimDetail.DataBind();
            }
        }

        /// <summary>
        /// 转换收款类别
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected string ChangeCostType(string type)
        {
            switch (type)
            {
                case "income_premium":
                    return "保费";
                case "income_brokerageFees":
                    return "经纪费";
                case "income_serviceCharge":
                    return "服务费";
                case "income_other1":
                    return "其他项1";
                case "income_other2":
                    return "其他项2";
                case "income_other3":
                    return "其他项3";
                case "income_other4":
                    return "其他项4";
                case "income_other5":
                    return "其他项5";
                case "income_other6":
                    return "其他项6";
                case "income_other7":
                    return "其他项7";
                case "income_other8":
                    return "其他项8";
                case "income_other9":
                    return "其他项9";
                case "income_other10":
                    return "其他项10";
                default:
                    return "未知";
            }
        }

        #endregion

        #region ****************************事件****************************

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["pageindex"] != null)
            {
                int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                Response.Redirect("CollectingList.aspx?page=" + page + "");
            }
            else
                Response.Redirect("CollectingList.aspx");
            //原写法 0510 改为以上表述
            //if (Request.QueryString["returnUrl"] == null || Request.QueryString["returnUrl"].ToString() == string.Empty)
            //{
            //    Response.Redirect("CollectingList.aspx");
            //}
            //else
            //{
            //    Response.Redirect(Request.QueryString["returnUrl"].ToString());
            //}
        }

        #endregion
    }
}