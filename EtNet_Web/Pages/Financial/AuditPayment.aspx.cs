using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_Models;

namespace EtNet_Web.Pages.Financial
{
    public partial class AuditPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["jobflowid"] == null || Request.QueryString["jobflowid"].ToString().Trim() == string.Empty)
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');location.href='../Job/AuditJobFlow.aspx';", true);
                    return;
                }

                ReadAuthority();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="jobflowID"></param>
        private void LoadPaymentData(string jobflowID)
        {
            To_PaymentManager bPayment = new To_PaymentManager();

            DataTable dtPayment = bPayment.GetViewPaymentList(string.Format("and jobflowID='{0}'", jobflowID));

            if (dtPayment.Rows.Count > 0)
            {
                DataRow row = dtPayment.Rows[0];
                lblMaker.Text = row["makerName"].ToString();
                lblPayerName.Text = row["payerName"].ToString();
                lblRequestDate.Text = DateTime.Parse(row["requestDate"].ToString()).ToShortDateString();
                lblSerialNumber.Text = row["serialNum"].ToString();
                lblSumAmount.Text = row["totalAmount"].ToString();
                lblPaymentType.Text = row["paymentType"].ToString(); //付款类别

                LoadPaymentDetail(row["id"].ToString());
                LoadPaymentReturn(row["id"].ToString());
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
        /// 判断进入审核界面是通过审核管理还是消息提示，如是消息提示判断是否具有审核权限
        /// </summary>
        private void ReadAuthority()
        {
            if (Request.QueryString["login"] != null)
            {
                string str = "  reviewerid=" + Request.QueryString["login"] + " AND jobflowid=" + Request.QueryString["jobflowid"];
                str += "  AND nowreviewer='T' AND  auditstatus not in('03','04')";
                DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(str);
                if (tbl.Rows.Count < 1)
                {
                    Response.Redirect("../Job/AuditError.aspx?error=2");
                }
                else
                {
                    string jobflowID = Request.QueryString["jobflowid"];
                    LoadPaymentData(jobflowID);
                }
            }
            else
            {
                string jobflowID = Request.QueryString["jobflowid"];
                LoadPaymentData(jobflowID);
            }

        }

        /// <summary>
        /// 获取付款名称
        /// </summary>
        /// <param name="payForField"></param>
        /// <returns></returns>
        protected string GetPayForName(object payForField)
        {
            string payForName = "未知";
            if (payForField == DBNull.Value || payForField == null) { return payForName; }

            string payFor = payForField.ToString();

            switch (payFor)
            {
                case "exp_premium":
                    payForName = "代垫保费";
                    break;
                case "exp_commission":
                    payForName = "佣金";
                    break;
                case "exp_tiefei":
                    payForName = "贴费";
                    break;
                case "exp_consultingFees":
                    payForName = "咨询费";
                    break;
                case "exp_serviceCharge":
                    payForName = "服务费";
                    break;
                case "exp_managementFees":
                    payForName = "管理费";
                    break;
                case "exp_other1":
                    payForName = "其他1";
                    break;
                case "exp_other2":
                    payForName = "其他2";
                    break;
                case "exp_other3":
                    payForName = "其他3";
                    break;
                case "exp_other4":
                    payForName = "其他4";
                    break;
                case "exp_other5":
                    payForName = "其他5";
                    break;
                default:
                    break;
            }

            return payForName;
        }


        /// <summary>
        /// 通过审核方法
        /// </summary>
        private void Approve()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id

            string comparedata = " reviewerid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND jobflowid=" + jobflowid.ToString();
            if (EtNet_BLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../Job/AuditError.aspx?error=0");
            }
            else if (EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../Job/AuditError.aspx?error=1");
            }
            else
            {
                string ruletxt = ""; //审核的分类
                string strsql = " and jobflowID=" + jobflowid.ToString();

                To_PaymentManager bPayment = new To_PaymentManager();
                DataTable tbl = bPayment.GetViewPaymentList(strsql);// EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
                if (tbl.Rows.Count >= 1)
                {
                    int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                    EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
                    ruletxt = rule.sort;


                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
                    DataTable audittbl = EtNet_BLL.AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                    int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                    string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                    auditmodel = new EtNet_Models.AuditJobFlow();
                    auditmodel.auditoperat = "通过";
                    auditmodel.audittime = DateTime.Now;
                    auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                    auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                    auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                    auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                    auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                    auditmodel.operatstatus = "已审批";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                    auditmodel.opiniontxt = Server.UrlDecode(txtApprovalOpinion.Value);
                    EtNet_BLL.AuditJobFlowManager.Update(auditmodel);

                    EtNet_Models.JobFlow jobflowmodel = new EtNet_Models.JobFlow();
                    jobflowmodel = EtNet_BLL.JobFlowManager.GetModel(jobflowid);

                    //依据不同的审核类型进行操作
                    switch (ruletxt)
                    {
                        case "单审":
                            if (mainreviewer != "T")
                            {
                                auditmodel = new EtNet_Models.AuditJobFlow(); //设置下一个审核人的数据记录
                                string nextauditstr = " jobflowid=" + jobflowid.ToString() + " AND numbers=" + (num + 1).ToString();
                                DataTable nextaudittbl = EtNet_BLL.AuditJobFlowManager.GetList(nextauditstr);
                                auditmodel.auditoperat = nextaudittbl.Rows[0]["auditoperat"].ToString();
                                auditmodel.audittime = DateTime.Parse(nextaudittbl.Rows[0]["audittime"].ToString());
                                auditmodel.id = int.Parse(nextaudittbl.Rows[0]["id"].ToString());
                                auditmodel.jobflowid = int.Parse(nextaudittbl.Rows[0]["jobflowid"].ToString());
                                auditmodel.mainreviewer = nextaudittbl.Rows[0]["mainreviewer"].ToString();
                                auditmodel.nowreviewer = "T"; //设置其为审核人员
                                auditmodel.numbers = int.Parse(nextaudittbl.Rows[0]["numbers"].ToString());
                                auditmodel.operatstatus = nextaudittbl.Rows[0]["operatstatus"].ToString();
                                auditmodel.reviewerid = int.Parse(nextaudittbl.Rows[0]["reviewerid"].ToString());
                                auditmodel.opiniontxt = nextaudittbl.Rows[0]["opiniontxt"].ToString();
                                EtNet_BLL.AuditJobFlowManager.Update(auditmodel);

                                jobflowmodel.auditstatus = "02"; //工作流的审核状态为“进行中”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);

                            }
                            else
                            {
                                jobflowmodel.endtime = DateTime.Now;
                                jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                                updateOrderPayDetail(jobflowid);
                                updateOrderRetDetail(jobflowid);

                            }
                            break;

                        case "选审":

                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                            EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            EtNet_BLL.AuditJobFlowManager.UpdateOther(" reviewerid != " + ((EtNet_Models.LoginInfo)Session["login"]).Id + " and jobflowid=" + jobflowid.ToString());
                            updateOrderPayDetail(jobflowid);
                            updateOrderRetDetail(jobflowid);
                            break;

                        case "会审":
                            bool pass = true;
                            string straudit = " jobflowid=" + jobflowid.ToString();
                            DataTable auditjobtbl = EtNet_BLL.AuditJobFlowManager.GetList(straudit);
                            for (int i = 0; i < auditjobtbl.Rows.Count; i++)
                            {
                                if (auditjobtbl.Rows[i]["auditoperat"].ToString() != "通过")
                                {
                                    pass = false; //说明还有其他审核人员未开始审核
                                    break;
                                }

                            }

                            if (pass)
                            {
                                jobflowmodel.endtime = DateTime.Now;
                                jobflowmodel.auditstatus = "04"; //工作流的状审核状态为“已通过”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                                updateOrderPayDetail(jobflowid);
                                updateOrderRetDetail(jobflowid);
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; //工作流的状审核状态为“进行中”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            break;

                    }



                    string strad = "编号为" + jobflowmodel.cname + "的单据已通过审批!";
                    SendInfo(strad, jobflowmodel.id);

                    SendNextAudit(jobflowmodel.id);

                    //修改客户的审核意见与启用状态
                    string paymentID = tbl.Rows[0]["id"].ToString();
                    To_Payment mPayment = bPayment.GetModel(paymentID);
                    //EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(cusid);
                    mPayment.approvalOpinion = mPayment.approvalOpinion + ((EtNet_Models.LoginInfo)Session["login"]).Cname + "的审核意见：" + Server.UrlDecode(txtApprovalOpinion.Value) + "|";

                    bPayment.Update(mPayment);
                    if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                    {
                        int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                        Response.Redirect("../Job/AuditJobFlow.aspx?page=" + page + "");
                    }
                    else
                    Response.Redirect("../Job/AuditJobFlow.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
        }

        /// <summary>
        /// 拒绝方法
        /// </summary>
        private void Refuse()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            string comparedata = " reviewerid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND jobflowid=" + jobflowid.ToString();
            if (EtNet_BLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../Job/AuditError.aspx?error=0");
            }
            else if (EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../Job/AuditError.aspx?error=1");
            }

            else
            {
                string ruletxt = ""; //审核的分类
                string strsql = " AND jobflowID=" + jobflowid.ToString();
                To_PaymentManager bPayment = new To_PaymentManager();
                DataTable tbl = bPayment.GetViewPaymentList(strsql);
                if (tbl.Rows.Count == 1)
                {
                    int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                    EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
                    ruletxt = rule.sort;




                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
                    DataTable audittbl = EtNet_BLL.AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                    int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                    string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                    auditmodel = new EtNet_Models.AuditJobFlow();
                    auditmodel.auditoperat = "拒绝";
                    auditmodel.audittime = DateTime.Now;
                    auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                    auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                    auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                    auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                    auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                    auditmodel.operatstatus = "已审批";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                    auditmodel.opiniontxt = Server.UrlDecode(txtApprovalOpinion.Value);
                    EtNet_BLL.AuditJobFlowManager.Update(auditmodel);

                    EtNet_Models.JobFlow jobflowmodel = new EtNet_Models.JobFlow();
                    jobflowmodel = EtNet_BLL.JobFlowManager.GetModel(jobflowid);

                    //依据不同的审核类型进行操作
                    switch (ruletxt)
                    {
                        case "单审":
                        case "会审":
                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "03"; //工作流的审核状态为“被拒绝”
                            EtNet_BLL.JobFlowManager.Update(jobflowmodel);

                            break;

                        case "选审":
                            string st = " jobflowid=" + jobflowid.ToString();
                            DataTable tbla = EtNet_BLL.AuditJobFlowManager.GetList(st);
                            bool refuse = true;

                            for (int j = 0; j < tbla.Rows.Count; j++)
                            {
                                if (tbla.Rows[j]["auditoperat"].ToString() != "拒绝")
                                {
                                    refuse = false; //还有其他审核人员未审
                                    break;
                                }
                            }
                            if (refuse)
                            {
                                jobflowmodel.endtime = DateTime.Now;
                                jobflowmodel.auditstatus = "03"; // 工作流的审核状态为被拒绝
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; // 工作流的审核状态为进行中
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            break;
                    }


                    string strad = "编号为" + jobflowmodel.cname + "的单据已被审批人拒绝!";
                    SendInfo(strad, jobflowmodel.id);

                    string paymentID = tbl.Rows[0]["id"].ToString();
                    To_Payment mPayment = bPayment.GetModel(paymentID);
                    //EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(cusid);
                    mPayment.approvalOpinion = mPayment.approvalOpinion + ((EtNet_Models.LoginInfo)Session["login"]).Cname + "的审核意见：" + Server.UrlDecode(txtApprovalOpinion.Value) + "|";

                    bPayment.Update(mPayment);
                    if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                    {
                        int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                        Response.Redirect("../Job/AuditJobFlow.aspx?page=" + page + "");
                    }
                    else
                    Response.Redirect("../Job/AuditJobFlow.aspx");


                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
        }



        /// <summary>
        /// 创建消息,返回消息的id值
        /// </summary>
        public int CreateInfo(string straudit)
        {

            EtNet_Models.Information model = new EtNet_Models.Information();
            model.sortid = 1;
            model.associationid = 1;
            model.createtime = DateTime.Now;
            model.sendtime = DateTime.Now;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.contents = straudit;
            EtNet_BLL.InformationManager.Add(model);
            int maxid = EtNet_BLL.InformationManager.GetMaxId(((EtNet_Models.LoginInfo)Session["login"]).Id.ToString());
            return maxid;
        }


        /// <summary>
        /// 创建消息通知
        /// </summary>
        /// <param name="infoid">消息的id值</param>
        /// <param name="acceptid">接受人员的id值</param>
        public void CreateInfoNotice(int infoid, int acceptid)
        {
            EtNet_Models.InformationNotice model = new EtNet_Models.InformationNotice();
            model.informationid = infoid;
            model.recipientid = acceptid;
            model.remind = "是";
            EtNet_BLL.InformationNoticeManager.Add(model);
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="straud">审核单据编号及意见</param>
        /// <param name="jobflowid">工作流id值</param>
        public void SendInfo(string straud, int jobflowid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jobflowid);
            if (model != null)
            {
                int infoid = CreateInfo(straud);
                CreateInfoNotice(infoid, model.founderid);
            }

        }


        /// <summary>
        /// 发送审批消息给下一个审批人员
        /// </summary>
        public void SendNextAudit(int jfid)
        {
            EtNet_Models.LoginInfo login = ((EtNet_Models.LoginInfo)Session["login"]);
            EtNet_Models.JobFlow jfmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (jfmodel != null)
            {
                EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(jfmodel.ruleid);
                string[] list = rule.idgourp.Split(',');
                if (rule.sort != "单审" || list.Length == 1)
                {
                    return;
                }
                if (list[list.Length - 1] == login.Id.ToString())
                {
                    return;
                }

                int recipientid = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == login.Id.ToString() && i != list.Length - 1)
                    {
                        recipientid = int.Parse(list[i + 1]);
                    }
                }
                EtNet_Models.Information model = new EtNet_Models.Information();
                model.sortid = 4;
                model.associationid = jfid;
                model.createtime = DateTime.Now;
                model.sendtime = DateTime.Now;
                model.founderid = jfmodel.founderid;
                model.contents = "名称为" + jfmodel.cname + "的单据需要您审批!"; ;
                EtNet_BLL.InformationManager.Add(model);
                int maxid = EtNet_BLL.InformationManager.GetMaxId(jfmodel.founderid.ToString());

                EtNet_Models.InformationNotice infnotic = new EtNet_Models.InformationNotice();
                infnotic.informationid = maxid;
                infnotic.recipientid = recipientid;
                infnotic.remind = "是";
                EtNet_BLL.InformationNoticeManager.Add(infnotic);
            }
        }

        /// <summary>
        /// 通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApprove_Click(object sender, ImageClickEventArgs e)
        {
            Approve();
        }


        /// <summary>
        /// 拒绝审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefuse_Click(object sender, ImageClickEventArgs e)
        {
            Refuse();
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

        /// <summary>
        /// 更新订单付款的实际信息的
        /// </summary>
        /// <param name="jobflowid"></param>
        public void updateOrderPayDetail(int jobflowid)
        {
            To_PaymentDetailManager manager = new To_PaymentDetailManager();
            //得到该条付款申请的明细数据
            DataTable dt = manager.GetOrderPayDetail(" jobFlowID =" + jobflowid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string orderPayId = dt.Rows[i]["orderPayId"].ToString(); //得到付款明细所引用的订单付款明细数据的id
                double hasAmount = manager.GetRealityHasAmount(orderPayId); //得到实际付过款的金额
                double shouldAmount = Convert.IsDBNull(dt.Rows[i]["money"]) ? Convert.ToDouble(dt.Rows[i]["money"]) : 0; //应付金额
                string getStatus = "";
                if (hasAmount == 0)
                    getStatus = "未付款";
                else if (shouldAmount > hasAmount)
                    getStatus = "部分付款";
                else
                    getStatus = "完成付款";
                To_OrderPayDetialManager.updateDetialStatusAndMoney(orderPayId, getStatus, hasAmount.ToString());
            }
        }

        /// <summary>
        /// 更新订单退款的实际信息
        /// </summary>
        /// <param name="jobflowid"></param>
        public void updateOrderRetDetail(int jobflowid)
        {
            DataTable dt = To_PaymentReturnManager.GetOrderReturnDetail(" jobFlowID =" + jobflowid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string orderRetID = dt.Rows[i]["orderRetID"].ToString(); //得到退款明细所引用的订单退款明细数据的id
                double hasAmount = To_PaymentReturnManager.GetRealityHasAmount(orderRetID);
                double shouldAmount = Convert.IsDBNull(dt.Rows[i]["money"]) ? Convert.ToDouble(dt.Rows[i]["money"]) : 0;
                string getStatus = "";
                if (hasAmount == 0)
                    getStatus = "未退款";
                else if (shouldAmount > hasAmount)
                    getStatus = "部分退款";
                else
                    getStatus = "完成退款";

                To_OrderRefunDetialManager.updateDetialStatusAndMoney(orderRetID, getStatus, hasAmount.ToString());

            }
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