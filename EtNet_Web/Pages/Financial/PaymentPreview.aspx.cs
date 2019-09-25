using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;
using System.IO;

namespace EtNet_Web.Pages.Financial
{
    public partial class PaymentPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqsh = Request.QueryString["sqsh"]; //判断是从申请还是审核到预览界面的
            if (sqsh == "sq")
            {
                this.sqyl.Visible = true;
                this.imgbtnback.Visible = false;
            }
            else
            {
                this.sqyl.Visible = false;
                this.imgbtnback.Visible = true;
            }
            if (Request.QueryString["payid"] == null || Request.QueryString["payid"].ToString().Trim() == string.Empty)
            {
                if (sqsh == "sq")
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');location.href='PaymentList.aspx';", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');location.href='../Job/AuditJobFlow.aspx';", true);
                }
                return;
            }

            string paymentID = Request.QueryString["payid"];
            LoadPaymentData(paymentID);
        }

        /// <summary>
        /// 加载信息
        /// </summary>
        /// <param name="paymentID"></param>
        private void LoadPaymentData(string paymentID)
        {
            To_PaymentManager bPayment = new To_PaymentManager();

            DataTable dtPayment = bPayment.GetViewPaymentList(string.Format("and id='{0}'", paymentID));

            if (dtPayment.Rows.Count > 0)
            {
                DataRow row = dtPayment.Rows[0];
                lblMaker.Text = row["makerName"].ToString();
                lblPayerName.Text = row["payerName"].ToString();
                lblRequestDate.Text = DateTime.Parse(row["requestDate"].ToString()).ToShortDateString();
                lblSerialNumber.Text = row["serialNum"].ToString();
                lblSumAmount.Text = row["totalAmount"].ToString();
                lblPaymentType.Text = row["paymentType"].ToString(); //付款类别


                LoadPaymentDetail(paymentID);
                LoadPaymentReturn(paymentID);

                LoadAuditImg(int.Parse(row["ruleid"].ToString()));
                LoadNowAudit(row["jobFlowID"].ToString());
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "load", "alert('数据不存在或没有权限查看');location.href='PaymentList.aspx';", true);
            }
        }

        /// <summary>
        /// 加载付款明细
        /// </summary>
        /// <param name="paymentID"></param>
        private void LoadPaymentDetail(string paymentID)
        {
            To_PaymentDetailManager bPaymentDetail = new To_PaymentDetailManager();
            RpPaymentDetail.DataSource = bPaymentDetail.GetList(" paymentid ='" + paymentID + "'");
            RpPaymentDetail.DataBind();

            sumBox.InnerText = bPaymentDetail.GetSumByPaymentId(paymentID).ToString("F2");
        }

        /// <summary>
        /// 加载退款信息
        /// </summary>
        /// <param name="paymentID"></param>
        private void LoadPaymentReturn(string paymentID)
        {
            RpReturnList.DataSource = To_PaymentReturnManager.GetList(" paymentID='" + paymentID + "'");
            RpReturnList.DataBind();

            returnsumBox.InnerText = To_PaymentReturnManager.GetSumByPaymentId(paymentID).ToString("F2");
        }

        /// <summary>
        /// 加载审核流程图
        /// </summary>
        private void LoadAuditImg(int ruleid)
        {
            ApprovalRule model = ApprovalRuleManager.GetModel(ruleid);
            if (model != null)
            {
                string filePath = Server.MapPath(model.rolepic);
                if (File.Exists(filePath))
                {
                    auditpic.InnerHtml = File.ReadAllText(filePath);
                }
                else
                {
                    auditpic.InnerHtml = "流程图不存在，或已被删除";
                }

            }
        }

        /// <summary>
        /// 加载当前审核人员的情况
        /// </summary>
        private void LoadNowAudit(string jfid)
        {
            string strsql = " auditstatus in('03','04') AND id=" + jfid;
            DataTable tbl = EtNet_BLL.JobFlowManager.GetList(strsql);
            if (tbl.Rows.Count == 0)
            {
                strsql = "nowreviewer='T' AND jobflowid=" + jfid;
                tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList("reviewerid", strsql);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (this.hidlist.Value == "")
                    {
                        this.hidlist.Value = tbl.Rows[i]["reviewerid"].ToString();
                    }
                    else
                    {
                        this.hidlist.Value += "," + tbl.Rows[i]["reviewerid"].ToString();
                    }
                }
            }
            else
            {
                this.hidlist.Value = "0"; //代表审核结束
            }
        }

        protected string CalcAmount(object a1, object a2)
        {
            if (a1 == DBNull.Value)
            {
                return string.Empty;
            }

            if (a2 == DBNull.Value)
            {
                return a1.ToString();
            }

            return (double.Parse(a1.ToString()) - double.Parse(a2.ToString())).ToString("F2");
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

        /// <summary>
        /// 得到订单id
        /// </summary>
        /// <param name="orderRetid">退款信息明细表id</param>
        /// <returns></returns>
        public string getOrderidRet(string orderRetid)
        {
            int id = 0;
            int.TryParse(orderRetid, out id);
            To_OrderRefunDetial model = To_OrderRefunDetialManager.getTo_OrderRefunDetialById(id);
            if (model != null)
                return model.Orderid.ToString();
            else
                return "";
        }

        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["pageindex"] != null)
            {
                int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                Response.Redirect("../Job/AuditJobFlow.aspx?page=" + page + "");
            }
            else
                Response.Redirect("../Job/AuditJobFlow.aspx");
        }
    }
}