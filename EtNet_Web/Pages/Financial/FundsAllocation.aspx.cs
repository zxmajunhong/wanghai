using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using System.Text;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Financial
{
    public partial class FundsAllocation : System.Web.UI.Page
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
                BindRpList();
            }
        }
        #endregion

        #region ****************************方法****************************

        /// <summary>
        /// 绑定收款单据列表数据
        /// </summary>
        private void BindRpList()
        {
            LoginInfo login = Session["login"] as LoginInfo;

            AspNetPager1.RecordCount = To_CollectingManager.GetTotalCountByLimit(FilterSql + " AND confirmReceipt=1 ", login.Id);

            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 018);
            if (sps == null)
            {
                AspNetPager1.NumericButtonCount = 5;
                AspNetPager1.PageSize = 5;
            }
            else
            {
                AspNetPager1.NumericButtonCount = sps.Pagecount;
                AspNetPager1.PageSize = sps.Pageitem;
            }

            DataTable data = To_CollectingManager.GetListByLimit(FilterSql + " AND confirmReceipt=1 ", login.Id, AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            RpList.DataSource = data;
            RpList.DataBind();
        }

        /// <summary>
        /// 根据单据ID删除收款数据
        /// </summary>
        /// <param name="id">要删除的单据ID</param>
        private void DeleteCollecting(int id)
        {
            To_CollectingManager.deleteTo_Collecting(id);
            BindRpList();
        }

        /// <summary>
        /// 根据条件筛选单据
        /// </summary>
        private void FilterReceipt()
        {
            StringBuilder filterBuilder = new StringBuilder();

            if (txtFilterNum.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND receiptNum LIKE '%{0}%' ", txtFilterNum.Text.Trim());
            if (DdlFilterPayMode.SelectedValue != string.Empty)
                filterBuilder.AppendFormat(" AND paymentMode = '{0}' ", DdlFilterPayMode.SelectedValue);
            if (txtFilterPolicyAmount.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND receiptAmount = {0} ", txtFilterPolicyAmount.Text.Trim());
            if (txtFilterUnit.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND paymentUnit LIKE '%{0}%' ", txtFilterUnit.Text.Trim());

            if (txtFilterSatrtTime.Text.Trim() == string.Empty)
            {
                if (txtFilterEndTime.Text.Trim() != string.Empty)
                {
                    filterBuilder.AppendFormat(" AND receiptDate <= '{0}' ", txtFilterEndTime.Text.Trim());
                }
            }

            if (txtFilterEndTime.Text.Trim() == string.Empty)
            {
                if (txtFilterSatrtTime.Text.Trim() != string.Empty)
                {
                    filterBuilder.AppendFormat(" AND receiptDate >= '{0}' ", txtFilterSatrtTime.Text.Trim());
                }
            }

            if (txtFilterSatrtTime.Text.Trim() != string.Empty && txtFilterEndTime.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND ( receiptDate BETWEEN '{0}' AND '{1}' ) ", txtFilterSatrtTime.Text.Trim(), txtFilterEndTime.Text.Trim());

            FilterSql = filterBuilder.ToString();
        }

        /// <summary>
        /// 转换收款方式
        /// </summary>
        /// <param name="mode">0：现金；1：转账；2：网银</param>
        /// <returns></returns>
        protected string ChangePaymentMode(string mode)
        {
            switch (mode)
            {
                case "0":
                    return "现金";
                case "1":
                    return "转账";
                case "2":
                    return "网银";
                default:
                    return "未知";
            }
        }

        /// <summary>
        /// 获取一个值表示按钮是否可见
        /// </summary>
        /// <param name="makerID"></param>
        /// <returns></returns>
        protected bool GetVisible(int makerID)
        {
            LoginInfo currentUser = Session["login"] as LoginInfo;
            return currentUser.Id == makerID;
        }

        /// <summary>
        /// 取消认领
        /// </summary>
        /// <param name="id"></param>
        private void CancelClaim(int id)
        {
            To_ClaimManager b_claim = new To_ClaimManager();
            To_ClaimDetailManager b_claimDetail = new To_ClaimDetailManager();


            string claimID = b_claim.GetID(id);


            if (claimID != "" && b_claim.Delete(int.Parse(claimID)))
            {
                b_claimDetail.DeleteByClaim(claimID);
            }

            To_CollectingManager.ChangeClaim(id, 0);
        }

        /// <summary>
        /// 发消息给用户
        /// </summary>
        /// <param name="falg">0:取消确认，1：取消认领</param>
        private void SendMessage(int collectingID, int falg)
        {

            To_Collecting collecting = To_CollectingManager.getTo_CollectingById(collectingID);

            if (collecting == null)
                return;

            EtNet_Models.Information messageEntity = new EtNet_Models.Information();

            To_ClaimManager claimBLL = new To_ClaimManager();

            string salesman = claimBLL.GetFiledValue(collectingID, "salesman");

            string msg = "";
            if (falg == 0)
            {
                msg = string.Format("收款编号：{0}，被业务员：{1}，取消认领，取消时间：{2}", collecting.ReceiptNum, salesman, DateTime.Now.ToShortDateString());
            }
            else
            {
                msg = string.Format("业务员：{0}，对收款编号：{1}，进行收款认定修改！", salesman, collecting.ReceiptNum);
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

        #endregion

        #region ****************************事件****************************

        protected void RpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            int id = int.Parse(e.CommandArgument.ToString().Trim());
            To_ClaimManager b_claim = new To_ClaimManager();
            DataTable claim = b_claim.GetList(1, " collectingID=" + id.ToString() + " ", "id");

            int makerID = Convert.ToInt32(claim.Rows[0]["makerID"]);
            if (!GetVisible(makerID))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('您不是认领人，无权执行此操作');", true);
                return;
            }
            switch (e.CommandName)
            {
                case "CANCEL":
                    CancelClaim(id);
                    SendMessage(id, 0);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('您已成功取消认领');", true);
                    BindRpList();
                    break;
                case "CONFIRM":
                    To_CollectingManager.ChangeClaim(id, 1);
                    SendMessage(id, 1);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('您已成功取消确认');", true);
                    BindRpList();
                    break;
                case "EDIT":
                    Response.Redirect("FundsAllocation/ClaimEdit.aspx?id=" + id.ToString());
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 当前页索引发生变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRpList();
        }

        /// <summary>
        /// 点击查询按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterReceipt();
            BindRpList();
        }

        /// <summary>
        /// 点击重置筛选条件时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterSql = string.Empty;
            txtFilterUnit.Text = string.Empty;
            txtFilterSatrtTime.Text = string.Empty;
            txtFilterPolicyAmount.Text = string.Empty;
            txtFilterNum.Text = string.Empty;
            txtFilterEndTime.Text = string.Empty;
            DdlFilterPayMode.SelectedValue = string.Empty;

            BindRpList();
        }

        #endregion

        #region ****************************属性****************************

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }

        #endregion


    }
}