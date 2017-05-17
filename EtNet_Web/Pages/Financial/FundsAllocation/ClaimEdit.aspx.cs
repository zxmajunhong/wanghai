using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_Models;

namespace EtNet_Web.Pages.Financial.FundAllocation
{
    public partial class ClaimEdit : System.Web.UI.Page
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

                LoadClaimInfo(receiptID);
            }
        }

        /// <summary>
        /// 加载认领信息
        /// </summary>
        private void LoadClaimInfo(int colletingID)
        {
            To_ClaimManager b_claim = new To_ClaimManager();
            DataTable data = b_claim.GetList(1, string.Format(" collectingID = {0} ", colletingID), "collectingID");

            if (data == null)//说明收款尚未认领
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert(\"收款尚未认领，不能编辑\");self.location.href=\"../FundsAllocation.aspx\"", true);
                return;
            }
            
            LblPayer.Text = string.Format("{0}  (<font color='red'>{1}</font>)", data.Rows[0]["payer"], Convert.ToInt32(data.Rows[0]["payerType"]) == 0 ? "投保客户" : "保险公司");
            LblReceiptType.Text = ChangeCostType(data.Rows[0]["costType"].ToString());
            LblSalesman.Text = data.Rows[0]["salesman"].ToString();

            HidPayer.Value = data.Rows[0]["payer"].ToString().Trim();
            HidPayerID.Value = data.Rows[0]["payerID"].ToString().Trim();
            HidPayerType.Value = data.Rows[0]["payerType"].ToString().Trim();
            HidSalesmanID.Value = data.Rows[0]["salesmanID"].ToString().Trim();
            HidSalesman.Value = data.Rows[0]["salesman"].ToString().Trim();
            HidReceiptType.Value = data.Rows[0]["costType"].ToString().Trim();

            LoadClaimDetail(colletingID);
        }

        /// <summary>
        /// 根据收款单据ID查询认领明细
        /// </summary>
        /// <param name="collcetingID"></param>
        /// <returns></returns>
        private void LoadClaimDetail(int collcetingID)
        {
            RpPolicyList.DataSource = To_CollectingManager.GetClaimDetail(collcetingID);
            RpPolicyList.DataBind();
        }

        /// <summary>
        /// 转换收款类别
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string ChangeCostType(string type)
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

        //private bool IsLimit(int id)
        //{
        //    To_ClaimManager b_claim = new To_ClaimManager();
        //    DataTable claim = b_claim.GetList(1, " collectingID=" + id.ToString() + " ", "id");

        //    int makerID = Convert.ToInt32(claim.Rows[0]["makerID"]);

        //    int userID = (Session["login"] as LoginInfo).Id;

        //    return makerID != userID;
        //}

        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            To_ClaimManager b_claim = new To_ClaimManager();
            To_Claim m_claim = new To_Claim();

            int collectingID = Convert.ToInt32(Request.QueryString["id"]);

            m_claim.collectingID = collectingID;
            m_claim.costType = HidReceiptType.Value;
            m_claim.payer = HidPayer.Value;
            m_claim.payerID = int.Parse(HidPayerID.Value);
            m_claim.payerType = int.Parse(HidPayerType.Value);
            m_claim.salesman = HidSalesman.Value;
            m_claim.salesmanID = int.Parse(HidSalesmanID.Value);

            int claimID = 0;
            int.TryParse(b_claim.GetID(collectingID), out claimID);
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

                To_ClaimDetailManager b_claimDetail = new To_ClaimDetailManager();
                b_claimDetail.DeleteByClaim(claimID.ToString());

                if (HidClaimDetail.Value.Trim() != string.Empty)
                {
                    string[] items = HidClaimDetail.Value.Trim().TrimEnd('@').Split('@');

                    if (items.Length > 0)
                    {
                        To_ClaimDetail m_claimDetail = new To_ClaimDetail();

                        foreach (string item in items)
                        {
                            string[] detail = item.Trim().Split('$');
                            if (detail.Length > 0)
                            {
                                int policyID = int.Parse(detail[0].Trim());
                                decimal amount = decimal.Parse(detail[1].Trim().TrimStart('¥').TrimStart('￥'));
                                decimal realAmount = decimal.Parse(detail[2].Trim().TrimStart('¥').TrimStart('￥'));

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
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('认领失败,该收款记录没有被认领过，不能编辑');self.location.href='../FundsAllocation.aspx';", true);
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