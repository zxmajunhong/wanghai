using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Financial.ToClaim
{
    public partial class ClaimEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClaimInfo();
            }
        }

        /// <summary>
        /// 加载收款信息
        /// </summary>
        private void LoadClaimInfo()
        {
            string collectId = Request.QueryString["collectId"];
            string claimId = Request.QueryString["claimId"];
            if (collectId == "" || claimId == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "error", "alert('参数错误');self.location.href='ClaimList.aspx';", true);
            }

            To_Collecting collecting = To_CollectingManager.getTo_CollectingById(int.Parse(collectId));

            LblNumber.Text = collecting.ReceiptNum; //收款单号
            txtUnit.Text = collecting.PaymentUnit; //付款单位
            hidComID.Value = collecting.PaymentUnitID.ToString(); //付款单位id
            LoginInfo login = (LoginInfo)Session["login"];
            LblMaker.Text = login.Cname; //登记人员
            HidMaker.Value = login.Id.ToString(); //登记人员id

            LtrAmount.Text = collecting.ReceiptAmount.ToString("N2"); //收款金额
            this.HidReceiptAmount.Value = collecting.ReceiptAmount.ToString();

            LoadClaimDetail(claimId);
        }

        /// <summary>
        /// 加载已经认领过的认领明细数据
        /// </summary>
        /// <param name="claimId"></param>
        private void LoadClaimDetail(string claimId)
        {
            To_ClaimDetailManager claimDetailManager = new To_ClaimDetailManager();
            DataTable dt = claimDetailManager.GetHasDetail("claimID = " + claimId);
            this.RpClaimDetailList.DataSource = dt;
            this.RpClaimDetailList.DataBind();
            double hasSum = 0.00;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hasSum += Convert.ToDouble(dt.Rows[i]["realAmount"]);
                
            }
            this.hasSumBox.InnerText = hasSum.ToString("F2");
        }

        /// <summary>
        /// 保存收款认领的方法
        /// </summary>
        private void SaveClaim()
        {
            string claimId = Request.QueryString["claimId"];
            To_ClaimManager claimManager = new To_ClaimManager();
            To_Claim claimModel = claimManager.GetModel(int.Parse(claimId));

            //更新收款单的单位信息
            To_Collecting collectModel = To_CollectingManager.getTo_CollectingById(claimModel.collectingID);
            collectModel.PaymentUnit = txtUnit.Text;
            int comid = 0;
            int.TryParse(hidComID.Value, out comid);
            collectModel.PaymentUnitID = comid;
            To_CollectingManager.updateTo_CollectPaymentUnit(collectModel);
            //认领主表的数据没有什么需要修改，故没有写，只修改认领明细中的数据

            int result = SaveClaimDetail(claimModel.ID, claimModel.collectingID);

            if (result == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('修改成功');self.location.href='ClaimList.aspx';", true);
            }
        }

        /// <summary>
        /// 保存收款认领明细数据
        /// </summary>
        /// <param name="claimId"></param>
        /// <param name="collectId"></param>
        private int SaveClaimDetail(int claimId, int collectId)
        {
            int result = 1;
            IList<string> orderColectIDs = new List<string>();
            To_CollectingManager.ChangeClaim(Convert.ToInt32(Request.QueryString["collectId"]), chkFinish.Checked ? 2 : 1);
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
                    claimDetailManager.DeleteByClaim(claimId.ToString()); //先删除这条认领单的以前的认领明细数据
                    foreach (string item in items)
                    {
                        string[] detail = item.Trim().Split('$');
                        if (detail.Length > 0)
                        {
                            claimDetail.claimID = claimId; //收款单id
                            claimDetail.orderCollectId = int.Parse(detail[0]); //订单表收款单位明细表id
                            if (!orderColectIDs.Contains(detail[0]))
                            {
                                orderColectIDs.Add(detail[0]);
                            }
                            claimDetail.orderCusId = int.Parse(hidComID.Value);  //付款单位id
                            claimDetail.orderNum = detail[1]; //订单编号
                            claimDetail.receiptAmount = decimal.Parse(detail[2]); //应收金额
                            claimDetail.realAmount = decimal.Parse(detail[3]); //本次收款金额
                            claimDetail.mark = detail[4]; //备注

                            if (claimDetailManager.Add(claimDetail) < 1)
                            {
                                result = 0;
                            }
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
            else
            {
                result = 0;
            }

            return result;
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
        /// 保存数据的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            SaveClaim();
        }

    }
}