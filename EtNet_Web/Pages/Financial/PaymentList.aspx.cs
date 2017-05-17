using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Text;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Financial
{
    public partial class PaymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPaymentList();
            }
        }


        /// <summary>
        /// 绑定付费列表数据
        /// </summary>
        private void BindPaymentList()
        {
            LoginInfo login = (LoginInfo)Session["login"];
            string sqlstr = "";
            sqlstr += FilterSql;
            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
                sqlstr += " and makerID = " + login.Id;
            else
                sqlstr += " and makerID in (" + ids + ")";
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 017);
            Data data = new Data();

            if (sps == null)
            {
                DataSet ds = data.DataPage("View_PaymentList", "id", "*", sqlstr, "requestDate", true, 10, 5, pages);
                RpPaymentList.DataSource = ds;
                RpPaymentList.DataBind();
            }
            else
            {
                DataSet ds = data.DataPage("View_PaymentList", "id", "*", sqlstr, "requestDate", true, sps.Pageitem, sps.Pagecount, pages);
                RpPaymentList.DataSource = ds;
                RpPaymentList.DataBind();
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
        /// 删除付费申请
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        private string DeletePayment(string paymentID)
        {
            To_PaymentManager bPayment = new To_PaymentManager();
            //To_PaymentDetailManager bPaymentDetail = new To_PaymentDetailManager();

            string resultMsg = "删除成功";


            To_Payment mPayment = bPayment.GetModel(paymentID);


            if (!bPayment.Delete(paymentID))
            {
                resultMsg = "删除失败";
            }
            else
            {
                // bPaymentDetail.DeleteByPayment(paymentID);

                string delWhere = " jobflowid=" + mPayment.jobFlowID;
                AuditJobFlowManager.Delete(delWhere);
                JobFlowManager.Delete(mPayment.jobFlowID);
            }

            return resultMsg;
        }

        /// <summary>
        /// 发消息给审核用户
        /// </summary>
        /// <param name="ruleID">审核规则ID</param>
        /// <param name="num">业务编号</param>
        private void SendMessage(int ruleID, string num)
        {
            ApprovalRule rule = ApprovalRuleManager.GetModel(ruleID);

            if (rule.idgourp.Trim() != string.Empty)
            {
                EtNet_Models.Information messageEntity = new EtNet_Models.Information();


                messageEntity.associationid = 0;//此处不需要，默认给一个值 
                messageEntity.contents = string.Format("编号为{0}的单据需要您审批!", num);
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
        /// 回收
        /// </summary>
        /// <param name="jfid"></param>
        private void Recover(int jobflowID)
        {
            EtNet_Models.JobFlow refreshmodel = EtNet_BLL.JobFlowManager.GetModel(jobflowID);
            if (refreshmodel != null && (refreshmodel.auditstatus == "01" || refreshmodel.auditstatus == "03"))
            {
                string strfresh = " jobflowid = " + jobflowID;
                EtNet_BLL.AuditJobFlowManager.Delete(strfresh); //删除审核人员的数据，请假单回到草稿状态
                refreshmodel.savestatus = "草稿";
                refreshmodel.auditstatus = "01";
                refreshmodel.txt = "";

                if (EtNet_BLL.JobFlowManager.Update(refreshmodel))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "reone", "<script>alert('成功收回')</script>", false);
                }

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "retwo", "<script>alert('回收失败，原因可能审核人员在审核或审核已通过！')</script>", false);
            }
        }

        protected void RpPaymentList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            object objArg = e.CommandArgument;
            string cmdName = e.CommandName;

            if (cmdName == "DELETE")//删除
            {
                string[] arrArg = objArg.ToString().Split(',');
                string paymentID = arrArg[0];
                string jobflowID = arrArg[1];

                JobFlow jobFlow = JobFlowManager.GetModel(Convert.ToInt32(jobflowID));


                if (jobFlow.auditstatus != "01" || jobFlow.savestatus == "已提交")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "delete", "alert('该申请已通过或者是正在审核，不能删除');", true);
                }
                else
                {
                    //string paymentID = objArg.ToString();
                    string resultMsg = DeletePayment(paymentID);
                    To_PaymentDetailManager pcdm = new To_PaymentDetailManager();
                    pcdm.DeleteByPayment(paymentID);
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "delete", string.Format("alert(\"{0}\");", resultMsg), true);
                }

            }

            if (cmdName == "EDIT")//编辑
            {
                string[] arrArg = objArg.ToString().Split(',');
                string paymentID = arrArg[0];
                string jobflowID = arrArg[1];
                JobFlow jobFlow = JobFlowManager.GetModel(Convert.ToInt32(jobflowID));
                if (jobFlow.auditstatus == "01" && jobFlow.savestatus == "草稿")
                {
                    Response.Redirect("PaymentEdit.aspx?payid=" + paymentID + "&jobflowid=" + jobflowID);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "edit", "alert('该申请已通过或者是正在审核，不能编辑');", true);
                }
                return;
            }

            if (cmdName == "APPROVAL")//送审
            {
                string[] arrArg = objArg.ToString().Split(',');
                int jobflowID = int.Parse(arrArg[0]);
                string paymentID = arrArg[1];
                string serialNum = arrArg[2];

                JobFlow jobFlow = JobFlowManager.GetModel(jobflowID);
                if (jobFlow.savestatus == "草稿" && jobFlow.auditstatus == "01")
                {
                    jobFlow.savestatus = "已提交";
                    jobFlow.auditstatus = "01";
                    JobFlowManager.Update(jobFlow);

                    int ruleID = jobFlow.ruleid;
                    CreateApproval(ruleID, jobflowID);

                    SendMessage(ruleID, serialNum);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('送审成功');", true);


                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('该申请已送审，无需再次送审');", true);
                }
            }

            if (cmdName == "RECOVER")
            {
                int jobflowID = Convert.ToInt32(objArg);
                Recover(jobflowID);
            }

            if (cmdName == "PRINT")
            {
                string[] args = objArg.ToString().Split(',');
                if (args[1].Trim() != "04")
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "aa", "alert('未通过审核申请不能打印')", true);
                else
                    Print(args[0].Trim());

                return;
            }

            BindPaymentList();
        }

        private void Print(string id)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "print", string.Format("printForm(\"{0}\");", id), true);
        }


        protected string GetApprovalHtml(object statusCode)
        {
            if (statusCode != DBNull.Value)
            {
                string code = statusCode.ToString();
                if (code == "未开始")
                {
                    return "<font color='red'>未开始</font>";
                }

                if (code == "已通过")
                {
                    return "<font color='green'>已通过</font>";
                }
                if (code == "被拒绝")
                {
                    return "<font color='red'>被拒绝</font>";
                }

                return code;
            }
            else
            {
                return "<font color='red'>未知</font>";
            }
        }


        /// <summary>
        /// 构建筛选sql
        /// </summary>
        private void BuildFilterSql()
        {
            StringBuilder filterBuilder = new StringBuilder();

            if (txtSerialNum.Text.Trim() != string.Empty)//申请单号
                filterBuilder.AppendFormat(" AND serialNum = '{0}'", txtSerialNum.Text.Trim());

            if (txtPayerUnit.Text.Trim() != string.Empty)//付款单位
                filterBuilder.AppendFormat(" AND payerName like '%{0}%' ", txtPayerUnit.Text.Trim());

            if (txtPayAmount.Text.Trim() != string.Empty)//付款金额
                filterBuilder.AppendFormat(" AND totalAmount ={0} ", txtPayAmount.Text.Trim());

            if (txtMaker.Text.Trim() != string.Empty)//制单员
                filterBuilder.AppendFormat(" AND makerName like '{0}' ", txtMaker.Text.Trim());

            //if (ddlAuditStaus.SelectedValue.Trim() != "-1")//审核状态
            //    filterBuilder.AppendFormat(" AND auditstatus = '{0}' ", ddlAuditStaus.SelectedValue.Trim());

            //if (ddlSaveSatus.SelectedValue.Trim() != "-1")//保存状态
            //    filterBuilder.AppendFormat(" AND savestatus = '{0}' ", ddlSaveSatus.SelectedValue.Trim());

            //申请日期
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        filterBuilder.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        filterBuilder.AppendFormat(" AND requestDate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        filterBuilder.AppendFormat(" AND requestDate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            filterBuilder.AppendFormat(" AND requestDate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            filterBuilder.AppendFormat(" AND requestDate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            filterBuilder.AppendFormat(" AND requestDate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            filterBuilder.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            filterBuilder.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }

            FilterSql = filterBuilder.ToString();
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }


        /// <summary>
        /// 点击筛选时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, ImageClickEventArgs e)
        {
            BuildFilterSql();

            BindPaymentList();
        }


        /// <summary>
        /// 点击重置时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterSql = string.Empty;

            BindPaymentList();

            txtMaker.Text = txtPayAmount.Text = txtPayerUnit.Text = txtSerialNum.Text = string.Empty;

            //ddlAuditStaus.SelectedIndex = ddlPayfor.SelectedIndex = ddlPaymentType.SelectedIndex = ddlRequestDate.SelectedIndex = ddlSaveSatus.SelectedIndex = 0;
        }
    }
}