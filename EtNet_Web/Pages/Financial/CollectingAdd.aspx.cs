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
    public partial class CollectingAdd : System.Web.UI.Page
    {
        #region ****************************Page_Load方法****************************
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo currentUser = Session["login"] as LoginInfo;
            if (currentUser == null)
            {
                Response.Redirect("~/Login.aspx", true);
            }
            else
            {

                if (!IsPostBack)
                {
                    //string departname = DepartmentInfoManager.getDepartmentInfoById(currentUser.Departid).Departcname;
                    //if (departname == "财务部") //财务部的人员才能做确认登记
                    //    confirmBox.Visible = true;
                    //else
                    //    confirmBox.Visible = false;
                    InitData(currentUser);
                    LoadUnit(currentUser);
                    LoadBank();
                    LoadBankAccount();
                    getUserList();
                }
            }
        }
        #endregion

        #region ****************************方法****************************

        /// <summary>
        /// 初始化页面信息
        /// </summary>
        private void InitData(LoginInfo currentUser)
        {
            DepartmentInfo department = DepartmentInfoManager.getDepartmentInfoById(currentUser.Departid);
            lblMarker.Text = currentUser.Cname; //制单员
            if (department != null)
            {
                lblMarkerDepartment.Text = department.Departcname;//制单部门
            }
            txtMarkDate.Text = DateTime.Now.ToString("yyyy-MM-dd");//制单日期
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");//收款日期（默认为当前日期，可更改);

            IsEditCuscode();
        }

        /// <summary>
        /// 单号是否自动生成
        /// </summary>
        private void IsEditCuscode()
        {
            DataTable tbl = GetModuleCoding();
            if (tbl.Rows[0]["usecode"].ToString() == "1")
            {
                lblAutoCode.Text = "*自动生成";
                txtNumber.ReadOnly = true;

                string number = "";
                string codeFormat = "";
                string orderNum = "";
                if (StrNumbers(txtNumber.Text.Trim(), out number, out codeFormat, out orderNum))
                {
                    txtNumber.Text = number;
                }
            }
            else
            {
                lblAutoCode.Visible = false;
            }
        }

        /// <summary>
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = " num = '00007'";
            DataTable tbl = ModuleCodingInfoManager.GetList(strsql);
            if (tbl.Rows.Count == 1)
            {
                return tbl;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 检验是否能成功产生单据名称
        /// </summary>
        /// <param name="cuscode">输入的单号</param>
        /// <param name="cname">单号全称</param>
        /// <param name="attachment">>单号代码不包含流水号</param>
        /// <param name="txt">流水号</param>
        private bool StrNumbers(string strcuscode, out string serialNum, out string codeformat, out string ordernum)
        {
            bool result = true;
            serialNum = ""; //客户代码全称
            codeformat = ""; //名称，不包含流水号
            ordernum = ""; //流水号

            DataTable tbl = GetModuleCoding(); //自动编码
            string txtformat = tbl.Rows[0]["txtformat"].ToString(); //名称的格式
            string usecode = tbl.Rows[0]["usecode"].ToString(); //流水号
            int len = int.Parse(tbl.Rows[0]["orderlen"].ToString()); //流水号长度


            DataTable custbl = null;
            string strsql = ""; //查询字符窜
            if (usecode == "0")
            {
                if (strcuscode.Trim() != "")
                {

                    serialNum = strcuscode; //客户代码全称

                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,业务编号不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                codeformat = Numbers(txtformat); //名称
                strsql = "  codeFormat= '" + codeformat + "' AND LEN(orderNum) =" + len.ToString();
                custbl = To_CollectingManager.GetList(1, strsql, "markDate desc");

                if (custbl.Rows.Count >= 1)
                {
                    if (custbl.Rows[0]["orderNum"].ToString() != "")
                    {
                        num = int.Parse(custbl.Rows[0]["orderNum"].ToString()) + 1; //流水号
                        if (num.ToString().Length > len)
                        {
                            result = false;
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,业务编号长度不够!')</script>");
                        }

                    }
                }
                ordernum = num.ToString().PadLeft(len, '0'); //流水号
                serialNum = codeformat + ordernum; //客户代码全称
            }
            return result;
        }

        /// <summary>
        /// 返回名称,不包含流水号
        /// </summary>
        private string Numbers(string txtformat)
        {
            string result = ""; //返回的名称        
            if (txtformat.Contains("[YYYY]"))
            {
                txtformat = txtformat.Replace("[YYYY]", DateTime.Now.ToString("yyyy"));
            }
            if (txtformat.Contains("[YY]"))
            {
                txtformat = txtformat.Replace("[YY]", DateTime.Now.ToString("yy"));
            }
            if (txtformat.Contains("[MM]"))
            {
                txtformat = txtformat.Replace("[MM]", DateTime.Now.ToString("MM"));
            }
            if (txtformat.Contains("[DD]"))
            {
                txtformat = txtformat.Replace("[DD]", DateTime.Now.ToString("dd"));
            }
            result = txtformat;
            return result;
        }



        /// <summary>
        /// 加载经营单位数据
        /// </summary>
        /// <param name="currentUser">当前登录用户信息</param>
        private void LoadUnit(LoginInfo currentUser)
        {
            if (currentUser.Firmidlist.Trim() != string.Empty)
            {
                string strWhere = string.Format("id in ({0})", currentUser.Firmidlist);
                DataTable dtFirmList = FirmInfoManager.GetList(strWhere);

                ddlUnit.DataTextField = "cname";
                ddlUnit.DataValueField = "id";
                ddlUnit.DataSource = dtFirmList;
                ddlUnit.DataBind();

                if (ddlUnit.Items.Count > 0)
                    ddlUnit.SelectedIndex = 0;
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
        private int AddCollecting()
        {
            string number = ""; //单号
            string codeFormart = ""; //自动编码规则
            string orderNum = ""; //流水号
            if (StrNumbers(txtNumber.Text.Trim(), out number, out codeFormart, out orderNum))
            {
                LoginInfo currentUser = Session["login"] as LoginInfo;

                To_Collecting collectingModel = new To_Collecting();
                collectingModel.ReceiptNum = number; //收款单号
                collectingModel.codeFormat = codeFormart; //编码规则
                collectingModel.orderNum = orderNum;
                collectingModel.ReceiptDate = DateTime.Parse(txtDate.Text.Trim()); //收款时间
                collectingModel.ReceiptAmount = double.Parse(txtMoney.Text.Trim()); // 收款金额
                collectingModel.BusinessUnit = ddlUnit.SelectedItem.Text; //经营单位
                collectingModel.BusinessUnitID = int.Parse(ddlUnit.SelectedValue);
                collectingModel.PaymentUnit = txtUnit.Text; //付款单位
                collectingModel.PaymentUnitID = int.Parse(hidComID.Value.Trim() == string.Empty ? "0" : hidComID.Value.Trim()); //付款单位id
                collectingModel.PaymentMode = 1; /* int.Parse(ddlWay.SelectedValue.Trim()); //入账方式*/
                collectingModel.ReceiptMark = txtMark.Value; //备注
                collectingModel.Marker = currentUser.Cname;
                collectingModel.MarkerID = currentUser.Id;
                collectingModel.MarkerDepartment = lblMarkerDepartment.Text;
                collectingModel.MarkerDepartmentID = currentUser.Departid;
                collectingModel.MarkDate = DateTime.Parse(txtMarkDate.Text);
                collectingModel.ConfirmReceipt = ChkConfirm.Checked ? 1 : 0;
                collectingModel.receiptStatusCode = 0;

                collectingModel.payBankId = int.Parse(DdlBank.SelectedValue);
                collectingModel.PayBank = DdlBank.SelectedItem.Text;//txtBank.Text;
                collectingModel.PayBankAcount = txtBankAccount.Text;

                //if (int.Parse(ddlWay.SelectedValue.Trim()) != 0)
                //{
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

                int id = To_CollectingManager.addTo_Collecting(collectingModel);
                if (ChkConfirm.Checked) //如果确认登记了。那么需要登记确认人和确认日期
                {
                    To_CollectingManager.updateConfirm(id.ToString(), currentUser.Cname, DateTime.Now.ToString());
                }
                AddLimit(id);
                return id;

            }
            else 
            {
                return 0;
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
            if (AddCollecting() > 0)
            {
                SendMessage();
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

        public void getUserList()
        {
            string checkname="";
            string checkuserid="";
            IList<LoginInfo> loginList = LoginInfoManager.getLoginInfoAll();
             foreach (LoginInfo login in loginList)
            {
                checkname += login.Cname + ",";
                checkuserid += login.Id + ",";

            }
             checkname = checkname.TrimEnd(',');
             checkuserid = checkuserid.TrimEnd(',');
            hidUserName.Value  = checkname;
           hidListUser.Value = checkuserid;
        }
    }
}