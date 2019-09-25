using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial.FundAllocation
{
    public partial class Step2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object objReceiptID = Request.QueryString["id"];

                int receiptID;
                if (objReceiptID == null || !int.TryParse(objReceiptID.ToString(), out receiptID))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('参数错误');self.location.href='../FundsAllocation.aspx';", true);
                    return;
                }

                string strAmount = To_CollectingManager.GetAmount(receiptID);

                if (strAmount != string.Empty)
                {
                    LtrAmount.Text = double.Parse(strAmount).ToString("C2");
                    HidReceiptAmount.Value = strAmount;
                }

                LoadStep1Info();
            }
        }

        /// <summary>
        /// 加载第一步填写信息
        /// </summary>
        private void LoadStep1Info()
        {
            Step1 step1 = Context.Handler as Step1;
            if (step1 == null)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('请先完成第一步信息');self.location.href='Step1.aspx';", true);
                Response.End();
            }

            LblPayer.Text = string.Format("{0}  (<font color='red'>{1}</font>)", step1.Payer, step1.PayerType == 0 ? "投保客户" : "保险公司");
            LblReceiptType.Text = step1.ReceiptTypeName;
            LblSalesman.Text = step1.Salesman;

            HidPayer.Value = step1.Payer.Trim();
            HidPayerID.Value = step1.PayerID.ToString().Trim();
            HidPayerType.Value = step1.PayerType.ToString().Trim();
            HidSalesmanID.Value = step1.SalesmanID.ToString().Trim();
            HidSalesman.Value = step1.Salesman.Trim();
            HidReceiptType.Value = step1.ReceiptType.Trim();
        }

        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            To_ClaimManager b_claim = new To_ClaimManager();
            To_Claim m_claim = new To_Claim();

            Step1 step1 = Context.Handler as Step1;
            m_claim.collectingID = Convert.ToInt32(Request.QueryString["id"]);
            m_claim.costType = HidReceiptType.Value;
            m_claim.payer = HidPayer.Value;
            m_claim.payerID = int.Parse(HidPayerID.Value);
            m_claim.payerType = int.Parse(HidPayerType.Value);
            m_claim.salesman = HidSalesman.Value;
            m_claim.salesmanID = int.Parse(HidSalesmanID.Value);
            m_claim.makerID = (Session["login"] as LoginInfo).Id;

            int claimID = b_claim.Add(m_claim);
            if (claimID != 0)
            {

                To_CollectingManager.ChangeClaim(Convert.ToInt32(Request.QueryString["id"]), chkFinish.Checked ? 2 : 1);
                if (chkFinish.Checked)
                {
                    SendMessage(m_claim.collectingID, HidSalesman.Value, 1);
                }
                else
                {
                    SendMessage(m_claim.collectingID, HidSalesman.Value, 0);
                }

                if (HidClaimDetail.Value.Trim() != string.Empty)
                {
                    string[] items = HidClaimDetail.Value.Trim().TrimEnd('@').Split('@');

                    if (items.Length > 0)
                    {
                        To_ClaimDetailManager b_claimDetail = new To_ClaimDetailManager();
                        To_ClaimDetail m_claimDetail = new To_ClaimDetail();

                        foreach (string item in items)
                        {
                            string[] detail = item.Trim().Split('$');
                            if (detail.Length > 0)
                            {
                                int policyID = int.Parse(detail[0].Trim());
                                decimal amount = decimal.Parse(detail[1].Trim().TrimStart('¥').TrimStart('￥'));
                                decimal realAmount = decimal.Parse(detail[2].Trim());

                                m_claimDetail.claimID = claimID;
                                m_claimDetail.mark = "";
                                m_claimDetail.policyID = policyID;
                                m_claimDetail.realAmount = realAmount;
                                m_claimDetail.receiptAmount = amount;
                                m_claimDetail.receiptStatusCode = 0;

                                b_claimDetail.Add(m_claimDetail);
                            }
                        }
                    }
                }


                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('认领成功');self.location.href='../FundsAllocation.aspx';", true);
            }

        }

        /// <summary>
        /// 发消息给用户
        /// </summary>
        /// <param name="falg">0：认领，1：认领完成</param>
        private void SendMessage(int collectingID, string salesman, int falg)
        {

            To_Collecting collecting = To_CollectingManager.getTo_CollectingById(collectingID);

            if (collecting == null)
                return;

            EtNet_Models.Information messageEntity = new EtNet_Models.Information();

            string msg = "";

            if (falg == 0)
            {
                msg = string.Format("收款编号：{0}，被业务员：{1}，认领，认领时间：{2}", collecting.ReceiptNum, salesman, DateTime.Now.ToShortDateString());
            }
            else
            {
                msg = string.Format("业务员：{0}，已完成对收款编号：{1}的收款认定！", salesman, collecting.ReceiptNum);
            }

            messageEntity.associationid = 0;//此处不需要，默认给一个值 
            messageEntity.contents = msg;
            messageEntity.createtime = DateTime.Now;
            messageEntity.founderid = (Session["login"] as LoginInfo).Id;
            messageEntity.sendtime = DateTime.Now;
            messageEntity.sortid = 1;//消息分类：个人消息

            if (InformationManager.Add(messageEntity))
            {

                int messageID = InformationManager.GetMaxId();

                EtNet_Models.InformationNotice messageNoticeEntity = new InformationNotice();
                messageNoticeEntity.informationid = messageID;

                messageNoticeEntity.recipientid = collecting.MarkerID;
                messageNoticeEntity.remind = "是";//默认未阅读;

                InformationNoticeManager.Add(messageNoticeEntity);
            }

        }

    }
}