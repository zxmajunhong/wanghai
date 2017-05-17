using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial.ToClaim
{
    public partial class ClaimAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClaim();
            }
        }

        /// <summary>
        /// 加载收款单位信息
        /// </summary>
        private void LoadClaim()
        {
            string id = Request.QueryString["id"];
            if (id == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "error", "alert('参数错误');self.location.href='ClaimList.aspx';", true);
            }

            To_Collecting collecting = To_CollectingManager.getTo_CollectingById(int.Parse(id));

            LblNumber.Text = collecting.ReceiptNum; //收款单号
            LtrAmount.Text = collecting.ReceiptAmount.ToString("N2"); //收款金额
            this.HidReceiptAmount.Value = collecting.ReceiptAmount.ToString();
            txtUnit.Text = collecting.PaymentUnit; //付款单位
            LoginInfo login = (LoginInfo)Session["login"];
            LblMaker.Text = login.Cname; //登记人员
            HidMaker.Value = login.Id.ToString(); //登记人员id

            hidComID.Value = collecting.PaymentUnitID.ToString(); //付款单位id

        }

        /// <summary>
        /// 保存收款认领方法
        /// </summary>
        private void SaveClaim()
        {
            To_Claim claimModel = new To_Claim();

            claimModel.collectingID = int.Parse(Request.QueryString["id"]); //收款id
            claimModel.collectingNum = LblNumber.Text; //收款单号
            claimModel.makerman = LblMaker.Text; //认领人员
            claimModel.MakerID = int.Parse(HidMaker.Value); //认领人员id
            claimModel.payer = txtUnit.Text; //付款单位
            claimModel.payerID = int.Parse(hidComID.Value); //付款单位id
            claimModel.collectAmount = double.Parse(HidReceiptAmount.Value); //收款金额

            To_Collecting collectModel = To_CollectingManager.getTo_CollectingById(claimModel.collectingID);
            collectModel.PaymentUnit = txtUnit.Text;
            int comid = 0;
            int.TryParse(hidComID.Value, out comid);
            collectModel.PaymentUnitID = comid;
            To_CollectingManager.updateTo_CollectPaymentUnit(collectModel);

            To_ClaimManager claimManager = new To_ClaimManager();
            int result = claimManager.Add(claimModel);
            if (result > 0)
            {
                SaveClaimDetail(result, claimModel.collectingID);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('认领成功');self.location.href='ClaimList.aspx';", true);
            }
        }

        /// <summary>
        /// 保存收款认领明细数据的方法
        /// </summary>
        /// <param name="claimId">收款认领单id</param>
        /// <param name="collectId">收款单id</param>
        private void SaveClaimDetail(int claimId, int collectId)
        {
            IList<string> orderColectIDs = new List<string>();
            To_CollectingManager.ChangeClaim(Convert.ToInt32(Request.QueryString["id"]), chkFinish.Checked ? 2 : 1);
            if (chkFinish.Checked)
            {
                SendMessage(collectId, LblMaker.Text, 1);
            }
            else
            {
                SendMessage(collectId, LblMaker.Text, 0);
            }
            if (HidClaimDetail.Value.Trim() != string.Empty)
            {
                To_ClaimDetailManager claimDetailManager = new To_ClaimDetailManager();
                string[] items = HidClaimDetail.Value.Trim().TrimEnd('@').Split('@');
                if (items.Length > 0)
                {
                    To_ClaimDetail claimDetail = new To_ClaimDetail();
                    foreach (string item in items)
                    {
                        string[] detail = item.Trim().Split('$');
                        if (detail.Length > 0)
                        {
                            claimDetail.claimID = claimId; //收款单id
                            claimDetail.orderCollectId = int.Parse(detail[0]); //订单表收款信息明细表id
                            if (!orderColectIDs.Contains(detail[0]))
                            {
                                orderColectIDs.Add(detail[0]);
                            }
                            claimDetail.orderCusId = int.Parse(hidComID.Value);  //付款单位id
                            claimDetail.orderNum = detail[1]; //订单编号
                            claimDetail.receiptAmount = decimal.Parse(detail[2]); //应收金额（在编辑的时候还是要去该订单表收款明细的应收金额，因为这个应收金额可能会变）
                            claimDetail.realAmount = decimal.Parse(detail[3]); //本次收款金额
                            claimDetail.mark = detail[4]; //备注

                            claimDetailManager.Add(claimDetail);
                        }
                    }
                }

                //更新收款信息明细表的收款状态和实际收款金额
                for (int i = 0; i < orderColectIDs.Count; i++)
                {
                    if (orderColectIDs[i] != "")
                    {
                        double hasAmount = claimDetailManager.GetHasAmount(orderColectIDs[i]); //得到该收款信息明细表关联的所有认领过的金额
                        double shouldAmount = To_OrderCollectDetialManager.getTo_OrderCollectDetialById(int.Parse(orderColectIDs[i])).Money; //得到应收金额
                        string getstatus = "";
                        if (hasAmount == 0)
                            getstatus = "未收款";
                        else if (shouldAmount > hasAmount)
                            getstatus = "部分收款";
                        else
                            getstatus = "完成收款";
                        To_OrderCollectDetialManager.updateDetialStatusAndMoney(orderColectIDs[i], getstatus, hasAmount.ToString());
                    }
                }
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

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            SaveClaim();
        }
    }
    
}