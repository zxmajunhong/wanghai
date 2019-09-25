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
    public partial class CollectingEdit : System.Web.UI.Page
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
                LoginInfo currentUser = Session["login"] as LoginInfo;
                string departname = DepartmentInfoManager.getDepartmentInfoById(currentUser.Departid).Departcname;
                if (departname == "财务部") //财务部的人员才能做确认登记
                    confirmBox.Visible = true;
                else
                    confirmBox.Visible = false;
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

            txtMarkDate.Text = collectingModel.MarkDate.ToShortDateString();
            lblMarkerDepartment.Text = collectingModel.MarkerDepartment;
            //txtBank.Text = collectingModel.PayBank;
            txtBankAccount.Text = collectingModel.PayBankAcount.Trim();
            txtUnit.Text = collectingModel.PaymentUnit;
            txtMoney.Text = collectingModel.ReceiptAmount.ToString("F2");
            txtDate.Text = collectingModel.ReceiptDate.ToShortDateString();
            txtMark.Value = collectingModel.ReceiptMark;
            lblMarker.Text = collectingModel.Marker;

            hidComID.Value = collectingModel.PaymentUnitID.ToString() == "0" ? string.Empty : collectingModel.PaymentUnitID.ToString();
            //ddlWay.SelectedValue = collectingModel.PaymentMode.ToString();

            LoginInfo userInfo = LoginInfoManager.getLoginInfoById(collectingModel.MarkerID);
            if (userInfo != null)
            {
                LoadUnit(userInfo, collectingModel.BusinessUnitID);
            }

            if (collectingModel.PaymentMode == 0)
            {
                paymentInfo.Style.Add("display", "none");
            }

            LoadBank(collectingModel.PayBank);
            if (Request.QueryString["action"] == null)
            {
                txtNumber.Text = collectingModel.ReceiptNum;
                txtNumber.ReadOnly = true;
                txtMarkDate.Text = collectingModel.MarkDate.ToShortDateString();
                ChkConfirm.Checked = collectingModel.ConfirmReceipt == 1;
            }
        }

        /// <summary>
        /// 加载经营单位数据
        /// </summary>
        /// <param name="currentUser">当前登录用户信息</param>
        private void LoadUnit(LoginInfo currentUser, int unitID)
        {
            if (Request.QueryString["action"] != null)
            {
                currentUser = Session["login"] as LoginInfo;
            }
            if (currentUser.Firmidlist.Trim() != string.Empty)
            {
                LoginInfo userInfo = LoginInfoManager.getLoginInfoById(currentUser.Id);
                string strWhere = string.Format("id in ({0})", userInfo.Firmidlist);
                DataTable dtFirmList = FirmInfoManager.GetList(strWhere);

                ddlUnit.DataTextField = "cname";
                ddlUnit.DataValueField = "id";
                ddlUnit.DataSource = dtFirmList;
                ddlUnit.DataBind();

                ListItem item = ddlUnit.Items.FindByValue(unitID.ToString());
                if (item != null)
                {
                    ddlUnit.SelectedValue = unitID.ToString();
                }
            }
        }

        /// <summary>
        /// 加载银行信息
        /// </summary>
        private void LoadBank(string bank = "")
        {
            if (ddlUnit.SelectedIndex < 0)
                return;
            DataTable dtBanks = FirmAccountInfoManager.GetList(string.Format(" firmid={0}", ddlUnit.SelectedValue));

            DdlBank.DataTextField = "bankname";
            DdlBank.DataValueField = "id";
            DdlBank.DataSource = dtBanks;
            DdlBank.DataBind();

            if (!string.IsNullOrEmpty(bank))
            {
                ListItem item = DdlBank.Items.FindByText(bank);
                if (item != null)
                {
                    DdlBank.SelectedIndex = DdlBank.Items.IndexOf(item);
                }
            }
        }

        /// <summary>
        /// 根据选择银行加载银行账号
        /// </summary>
        private void LoadBankAccount()
        {
            if (DdlBank.SelectedIndex < 0)
                return;
            FirmAccountInfo bankInfo = FirmAccountInfoManager.GetModel(int.Parse(DdlBank.SelectedValue));
            txtBankAccount.Text = bankInfo.account.Trim();
        }

        /// <summary>
        /// 添加收款数据
        /// </summary>
        /// <returns>添加成功返回true</returns>
        private bool EditCollecting()
        {
            LoginInfo currentUser = Session["login"] as LoginInfo;

            To_Collecting collectingModel = new To_Collecting();

            int ID = Convert.ToInt32(Request.QueryString["id"]);

            collectingModel = To_CollectingManager.getTo_CollectingById(ID);

            collectingModel.BusinessUnit = ddlUnit.SelectedItem.Text;
            collectingModel.BusinessUnitID = int.Parse(ddlUnit.SelectedValue);
            collectingModel.MarkDate = DateTime.Parse(txtMarkDate.Text);
            collectingModel.Marker = currentUser.Cname;
            collectingModel.MarkerID = currentUser.Id;
            collectingModel.MarkerDepartment = lblMarkerDepartment.Text;
            collectingModel.MarkerDepartmentID = currentUser.Departid;
            collectingModel.payBankId = int.Parse(DdlBank.SelectedValue);
            collectingModel.PayBank = DdlBank.SelectedItem.Text;//txtBank.Text;
            collectingModel.PayBankAcount = txtBankAccount.Text;

            //collectingModel.PaymentMode = int.Parse(ddlWay.SelectedValue.Trim());
            //if (int.Parse(ddlWay.SelectedValue.Trim()) != 0)
            //{
            //    if (DdlBank.SelectedIndex < 0)
            //    {
            //        return false;
            //    }
            //    collectingModel.payBankId = int.Parse(DdlBank.SelectedValue);
            //    collectingModel.PayBank = DdlBank.SelectedItem.Text;//txtBank.Text;
            //    collectingModel.PayBankAcount = txtBankAccount.Text;
            //}
            //else
            //{
            //    collectingModel.payBankId = 0;
            //    collectingModel.PayBank = "";//txtBank.Text;
            //    collectingModel.PayBankAcount = "";
            //}

            collectingModel.PaymentUnit = txtUnit.Text;
            collectingModel.PaymentUnitID = int.Parse(hidComID.Value.Trim() == string.Empty ? "0" : hidComID.Value.Trim());
            collectingModel.ReceiptAmount = float.Parse(txtMoney.Text);
            collectingModel.ReceiptDate = DateTime.Parse(txtDate.Text);
            collectingModel.ReceiptMark = txtMark.Value;
            collectingModel.ReceiptNum = txtNumber.Text;
            collectingModel.ConfirmReceipt = ChkConfirm.Checked ? 1 : 0;

            AddLimit(ID);
            if (ChkConfirm.Checked) //如果确认登记了。那么需要登记确认人和确认日期
            {
                To_CollectingManager.updateConfirm(ID.ToString(), currentUser.Cname, DateTime.Now.ToString());
            }
            if (Request.QueryString["action"] == null)
            {
                collectingModel.ID = Convert.ToInt32(Request.QueryString["id"]);
                return To_CollectingManager.updateTo_Collecting(collectingModel) > 0;
            }
            else
            {
                return To_CollectingManager.addTo_Collecting(collectingModel) > 0;
            }

            
        }

        private void AddLimit(int receiptID)
        {
            string userStr = hidUserList.Value.Trim().TrimEnd(',');
            if (userStr != string.Empty)
            {
                IEnumerable<string> userList = userStr.Split(',').Where(x => x != string.Empty);
                To_ReceiptLimitManager.AddLimit(userList, "," + receiptID.ToString().Trim());
            }
        }

        /// <summary>
        /// 发消息给用户
        /// </summary>
        private void SendMessage()
        {
            string userStr = hidUserList.Value.Trim().TrimEnd(',');
            if (userStr != string.Empty)
            {
                EtNet_Models.Information messageEntity = new EtNet_Models.Information();


                messageEntity.associationid = 0;//此处不需要，默认给一个值 
                messageEntity.contents = string.Format("{0}收到一张水单，金额为{1}，请相关业务员尽快来认领。", txtMarkDate.Text, txtMoney.Text);
                messageEntity.createtime = DateTime.Now;
                messageEntity.founderid = (Session["login"] as LoginInfo).Id;
                messageEntity.sendtime = DateTime.Now;
                messageEntity.sortid = 1;//消息分类：个人消息

                if (InformationManager.Add(messageEntity))
                {
                    IEnumerable<string> userList = userStr.Split(',').Where(x => x != string.Empty);

                    int messageID = InformationManager.GetMaxId();

                    EtNet_Models.InformationNotice messageNoticeEntity = new InformationNotice();
                    messageNoticeEntity.informationid = messageID;

                    foreach (string user in userList)
                    {
                        messageNoticeEntity.recipientid = int.Parse(user);
                        messageNoticeEntity.remind = "是";//默认未阅读;

                        InformationNoticeManager.Add(messageNoticeEntity);
                    }
                }
            }
        }

        #endregion


        #region ****************************事件****************************

        /// <summary>
        /// 提交时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (EditCollecting())
            {
                SendMessage();
                if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                {
                    int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存成功');self.location.href='CollectingList.aspx?page=" + page + "';", true);

                }
                else
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存成功');self.location.href='CollectingList.aspx';", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存失败');", true);
            }
        }

        /// <summary>
        /// 银行选项发生变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBank();
        }

        /// <summary>
        /// 银行选项发生变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DdlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBankAccount();
        }

        #endregion

        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["pageindex"] != null)
            {
                int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                Response.Redirect("CollectingList.aspx?page=" + page + "");
            }
            else
                Response.Redirect("CollectingList.aspx");
        }
    }
}