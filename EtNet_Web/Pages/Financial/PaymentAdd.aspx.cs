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
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //txtSerialNumber.CssClass = string.Concat(txtSerialNumber.CssClass, " readonly");
                //txtSerialNumber.Text = Guid.NewGuid().ToString();// new Guid().ToString();
                IsEditCuscode();
            }
        }

        /// <summary>
        /// 初始化页面信息
        /// </summary>
        private void InitData()
        {
            txtRequestDate.Text = DateTime.Now.ToString("yyyy-MM-dd");//默认申请日期为当前时间

            LoginInfo currentUser = Session["login"] as LoginInfo;

            if (currentUser != null)
            {
                txtMaker.Text = currentUser.Cname;
                hidSalesmanID.Value = currentUser.Id.ToString();
            }

            BindApprovalProcess();
        }

        /// <summary>
        /// 添加付费信息
        /// </summary>
        /// <returns>GUID主键</returns>
        private string SavePayment(string serialNumber, string codeFormat, string orderNum, int workflowID)
        {
            To_PaymentManager bPayment = new To_PaymentManager();
            To_Payment mPayment = new To_Payment();

            #region To_Payment实体
            mPayment.approvalOpinion = "";

            mPayment.codeFormat = codeFormat;
            mPayment.orderNum = orderNum;
            mPayment.serialNum = serialNumber;


            mPayment.jobFlowID = workflowID;

            LoginInfo currentUser = Session["login"] as LoginInfo;
            mPayment.makerID = currentUser.Id;
            mPayment.makerName = currentUser.Cname;


            mPayment.payerID = int.Parse(hidPayerID.Value.Trim());
            mPayment.payerName = txtPayerName.Text.Trim();

            mPayment.paymentType = txtPayType.Text.Trim(); //付款类别
            mPayment.requestDate = DateTime.Parse(txtRequestDate.Text.Trim());

            mPayment.totalAmount = decimal.Parse(txtSumAmount.Text.Trim());

            mPayment.makeTime = DateTime.Now;
            

            mPayment.id = Guid.NewGuid().ToString();
            #endregion

            mPayment.payFor = "payAmount";


            bPayment.Add(mPayment);

            //SavePaymentDetail(mPayment.id);
            return mPayment.id;
        }

        /// <summary>
        /// 添加付款详细信息
        /// </summary>
        /// <param name="paymentID"></param>
        private void SavePaymentDetail(string paymentID)
        {
            To_PaymentDetailManager bPaymentDetail = new To_PaymentDetailManager();
            To_PaymentDetail mPaymentDetail = new To_PaymentDetail();
            IList<string> payids = new List<string>();
            mPaymentDetail.PaymentID = paymentID;

            if (hidPayDetail.Value.Trim().TrimEnd('@') != string.Empty)
            {
                IEnumerable<string> detailList = hidPayDetail.Value.Trim().TrimEnd('@').Split('@').Where(x => x.Trim() != string.Empty);

                if (detailList.Count() > 0)
                {
                    foreach (string detail in detailList)
                    {
                        string[] detailItem = detail.Split('$');
                        mPaymentDetail.OrderPayId = int.Parse(detailItem[0].Trim()); //订单付款信息明细表id
                        if (!payids.Contains(detailItem[0].Trim()))
                        {
                            payids.Add(detailItem[0].Trim());
                        }
                        mPaymentDetail.OrderNum = detailItem[1].Trim(); //订单编号
                        mPaymentDetail.ShouldPay = double.Parse(detailItem[2].Trim()); //应付金额
                        mPaymentDetail.PayAmount = double.Parse(detailItem[3].Trim()); //本次支付金额

                        bPaymentDetail.Add(mPaymentDetail);
                    }
                }

                //更新付款信息明细表的付款状态和实际付款金额
                for (int i = 0; i < payids.Count; i++)
                {
                    if (payids[i] != "")
                    {
                        double hasAmount = bPaymentDetail.GetHasAmount(payids[i].Trim()); //得到付过款的金额
                        double shouldAmount = To_OrderPayDetialManager.getTo_OrderPayDetialById(int.Parse(payids[i])).Money; //得到应付金额
                        string getstatus = "";
                        if (hasAmount == 0)
                            getstatus = "未付款";
                        else if (shouldAmount > hasAmount)
                            getstatus = "部分付款";
                        else
                            getstatus = "完成付款";
                        To_OrderPayDetialManager.updateDetialStatusAndMoney(payids[i], getstatus, hasAmount.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 保存退款信息
        /// </summary>
        /// <param name="paymentId"></param>
        private void SavePaymentReturn(string paymentId)
        {
            IList<string> returnIDs = new List<string>();
            To_PaymentReturn paymentReturn = new To_PaymentReturn();
            paymentReturn.PaymentID = paymentId;
            if (hidPayReturn.Value.Trim().TrimEnd('@') != string.Empty)
            {
                IEnumerable<string> returnList = hidPayReturn.Value.Trim().TrimEnd('@').Split('@').Where(x => x.Trim() != string.Empty);
                if (returnList.Count() > 0)
                {
                    foreach (string list in returnList)
                    {
                        string[] item = list.Split('$');
                        paymentReturn.orderRetID = int.Parse(item[0].Trim()); //订单退款信息明细表id
                        if (!returnIDs.Contains(item[0].Trim()))
                        {
                            returnIDs.Add(item[0].Trim());
                        }
                        paymentReturn.OrderNum = item[1].Trim(); //订单编号
                        paymentReturn.ShouldReturn = double.Parse(item[2].Trim()); //应退金额
                        paymentReturn.ReturnAmount = double.Parse(item[3].Trim()); //本次退付金额

                        To_PaymentReturnManager.addTo_PaymentReturn(paymentReturn);
                    }
                }

                for (int i = 0; i < returnIDs.Count; i++)
                {
                    if (returnIDs[i] != "")
                    {
                        double hasAmount = To_PaymentReturnManager.GetHasAmount(returnIDs[i]); //得到该退款信息明细表关联的所有退过款的金额
                        double shouldAmount = To_OrderRefunDetialManager.getTo_OrderRefunDetialById(int.Parse(returnIDs[i])).Money; //得到应退金额
                        string getstatus = "";
                        if (hasAmount == 0)
                            getstatus = "未退款";
                        else if (shouldAmount > hasAmount)
                            getstatus = "部分退款";
                        else
                            getstatus = "完成退款";

                        To_OrderRefunDetialManager.updateDetialStatusAndMoney(returnIDs[i], getstatus, hasAmount.ToString());
                    }
                }
            }
        }

        #region 工作流
        /// <summary>
        /// 加载审核流程
        /// </summary>
        public void BindApprovalProcess()
        {
            ddlApproval.Items.Clear();

            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string strsql = " jobflowsort='05' AND  ',' + departidlist + ',' like '%," + login.Departid.ToString() + ",%' ";

            DataTable typelist = EtNet_BLL.ViewBLL.ViewApprovalRuleManager.getList(strsql);
            for (int i = 0; i < typelist.Rows.Count; i++)
            {
                ListItem list = new ListItem(typelist.Rows[i]["sort"].ToString() + "→" + typelist.Rows[i]["CName"].ToString(), typelist.Rows[i]["Id"].ToString());
                ddlApproval.Items.Add(list);
            }
            ListItem ltem = new ListItem("选择流程", "-1");//添加第一行默认值
            ddlApproval.Items.Insert(0, ltem);//添加第一行默认值

        }


        /// <summary>
        ///  创建审批序列
        /// </summary>
        ///<param name="ruleid">审核规则id值</param>
        /// <param name="id">工作流的id号</param>
        private void CreateApproval(int ruleid, int id)
        {
            EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
            string stafflist = rule.idgourp;
            string auditsort = rule.sort;
            string[] staff = null;
            int len = 0; //审批人员的个数
            EtNet_Models.AuditJobFlow model = null;
            if (stafflist.IndexOf(",") == -1)
            {
                staff = new string[1];
                staff[0] = stafflist;
                len = 1;
            }
            else
            {
                staff = stafflist.Split(',');
                len = staff.Length;
            }

            switch (auditsort)
            {
                case "单审":
                    for (int i = 0; i < staff.Length; i++)
                    {
                        model = new EtNet_Models.AuditJobFlow();
                        model.auditoperat = "未操作";
                        model.operatstatus = "未审批";
                        model.audittime = new DateTime(1900, 1, 1);
                        if (i == 0)
                        {
                            model.nowreviewer = "T";//第一个审核的人员 
                        }
                        else
                        {
                            model.nowreviewer = "F";
                        }

                        if ((i + 1) == len)
                        {
                            model.mainreviewer = "T";//最终审核的人员 
                        }
                        else
                        {
                            model.mainreviewer = "F";
                        }
                        model.numbers = i + 1;
                        model.jobflowid = id;
                        model.reviewerid = int.Parse(staff[i]);
                        model.opiniontxt = "";
                        EtNet_BLL.AuditJobFlowManager.Add(model);
                    }
                    break;

                case "选审":
                case "会审":
                    for (int i = 0; i < staff.Length; i++)
                    {
                        model = new EtNet_Models.AuditJobFlow();
                        model.audittime = new DateTime(1900, 1, 1);
                        model.nowreviewer = "T";
                        model.mainreviewer = "T";
                        model.numbers = 1;
                        model.jobflowid = id;
                        model.auditoperat = "未操作";
                        model.operatstatus = "未审批";
                        model.opiniontxt = "";
                        model.reviewerid = int.Parse(staff[i]);
                        EtNet_BLL.AuditJobFlowManager.Add(model);
                    }
                    break;
            }
        }

        /// <summary>
        /// 添加工作流管理
        /// </summary>
        /// <param name="args">保存或已提交</param>
        private int SavePaymentWorkflow(string args, string auditsatus, string serialNumber)
        {
            int result = 0;
            JobFlow jobflow = null;
            if (Request.Params["jobflowid"] == null || Request.Params["jobflowid"] == "")
            {

                jobflow = new JobFlow();
                jobflow.savestatus = args.ToString();
                jobflow.createtime = DateTime.Now;
                jobflow.endtime = DateTime.Now;
                jobflow.cname = serialNumber;
                jobflow.attachment = "";
                jobflow.sort = "05";
                jobflow.auditsort = "";
                jobflow.auditstatus = auditsatus;
                jobflow.founderid = ((LoginInfo)Session["login"]).Id;
                jobflow.txt = "";
                jobflow.ruleid = int.Parse(ddlApproval.SelectedValue);
                result = JobFlowManager.AddAndGetId(jobflow);
            }
            else
            {
                result = int.Parse(Request.Params["jobflowid"]);
                jobflow = JobFlowManager.GetModel(int.Parse(Request.Params["jobflowid"]));
                if (jobflow != null)
                {
                    jobflow.savestatus = args.ToString();
                    jobflow.auditstatus = auditsatus;
                    jobflow.ruleid = int.Parse(ddlApproval.SelectedValue);
                    JobFlowManager.Update(jobflow);
                }
            }
            return result;

        }
        #endregion

        /// <summary>
        /// 发消息给审核用户
        /// </summary>
        private void SendMessage(string serialNumber)
        {
            ApprovalRule rule = ApprovalRuleManager.GetModel(int.Parse(ddlApproval.SelectedValue));

            if (rule.idgourp.Trim() != string.Empty)
            {
                EtNet_Models.Information messageEntity = new EtNet_Models.Information();


                messageEntity.associationid = 0;//此处不需要，默认给一个值 
                messageEntity.contents = string.Format("编号为{0}的单据需要您审批!", serialNumber);
                messageEntity.createtime = DateTime.Now;
                messageEntity.founderid = (Session["login"] as LoginInfo).Id;
                messageEntity.sendtime = DateTime.Now;
                messageEntity.sortid = 1;//消息分类：个人消息

                if (InformationManager.Add(messageEntity))
                {
                    IEnumerable<string> userList = rule.idgourp.Split(',').Where(x => x != string.Empty);

                    int messageID = InformationManager.GetMaxId();

                    EtNet_Models.InformationNotice messageNoticeEntity = new InformationNotice();
                    messageNoticeEntity.informationid = messageID;

                    int len = rule.sort == "单审" ? 1 : userList.Count();

                    if (rule.sort == "单审")
                    {
                        messageNoticeEntity.recipientid = int.Parse(userList.ElementAt(0));
                        messageNoticeEntity.remind = "是";//默认未阅读;

                        InformationNoticeManager.Add(messageNoticeEntity);
                    }

                    else
                    {

                        foreach (string user in userList)
                        {

                            messageNoticeEntity.recipientid = int.Parse(user);
                            messageNoticeEntity.remind = "是";//默认未阅读;

                            InformationNoticeManager.Add(messageNoticeEntity);
                        }
                    }
                }
            }
        }

        #region 自动编码
        /// <summary>
        /// 单号是否自动生成
        /// </summary>
        private void IsEditCuscode()
        {
            DataTable tbl = GetModuleCoding();
            if (tbl.Rows[0]["usecode"].ToString() == "1") //流水号
            {
                lblAutoCode.Text = "*自动生成";
                txtSerialNumber.CssClass = string.Concat(txtSerialNumber.CssClass, " readonly");
            }

            string serialNumber = "";
            string codeFormat = "";
            string orderNum = "";

            if (StrNumbers(this.txtSerialNumber.Text.Trim(), out serialNumber, out codeFormat, out orderNum))
            {
                this.txtSerialNumber.Text = serialNumber;
            }
        }




        /// <summary>
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = " num = '00006'";
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
        /// <param name="cuscode">输入的客户代码</param>
        /// <param name="cname">客户代码全称</param>
        /// <param name="attachment">>客户代码不包含流水号</param>
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
                To_PaymentManager bPayment = new To_PaymentManager();
                custbl = bPayment.GetList(1, strsql, " makeTime desc ");

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
        #endregion


        /// <summary>
        /// 点击送审时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApproval_Click(object sender, EventArgs e)
        {
            string serialNum = string.Empty;
            string orderNum = string.Empty;
            string codeFormat = string.Empty;

            if (StrNumbers(txtSerialNumber.Text, out serialNum, out codeFormat, out orderNum))
            {
                int workflowID = SavePaymentWorkflow("已提交", "01", serialNum); //得到工作流id
                string paymentID = SavePayment(serialNum, codeFormat, orderNum, workflowID);
                SavePaymentDetail(paymentID);
                SavePaymentReturn(paymentID);
                CreateApproval(int.Parse(ddlApproval.SelectedValue), workflowID);
                SendMessage(serialNum);
                

                ClientScript.RegisterClientScriptBlock(this.GetType(), "save ", "<script type=\"text/javascript\">alert(\"送审成功\");window.location.href=\"PaymentList.aspx\";</script>", false);
            }
        }


        /// <summary>
        /// 点击保存按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {

            string serialNum = string.Empty; //申请单号
            string orderNum = string.Empty; //流水号
            string codeFormat = string.Empty; //编码规格

            if (StrNumbers(txtSerialNumber.Text, out serialNum, out codeFormat, out orderNum))
            {
                int workflowID = SavePaymentWorkflow("草稿", "01", serialNum);
                string paymentID = SavePayment(serialNum, codeFormat, orderNum, workflowID);
                SavePaymentDetail(paymentID);
                SavePaymentReturn(paymentID);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "save", "<script type=\"text/javascript\">alert(\"保存成功\");window.location.href=\"PaymentList.aspx\";</script>", false);
            }
        }
    }
}