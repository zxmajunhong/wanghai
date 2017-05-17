using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;
using EtNet_BLL.DataPage;
using System.Text;
using messageBLL = EtNet_BLL.InformationManager;

namespace EtNet_Web.Pages.Policy
{
    public partial class PolicyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RpPolicyBindData();
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void RpPolicyBindData()
        {
            AspNetPager1.RecordCount = To_PolicyManager.GetCount(FilterSql, (Session["login"] as LoginInfo).Id) ?? 0;

            LoginInfo login = Session["login"] as LoginInfo;
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 015);
            if (sps == null)
            {
                AspNetPager1.NumericButtonCount = 10;
                AspNetPager1.PageSize = 10;
            }
            else
            {
                AspNetPager1.NumericButtonCount = sps.Pagecount;
                AspNetPager1.PageSize = sps.Pageitem;
            }

            DataTable dtPolicy = To_PolicyManager.GetListByPage(null, (Session["login"] as LoginInfo).Id, "", FilterSql, AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            RpPolicy.DataSource = dtPolicy;
            RpPolicy.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            RpPolicyBindData();
        }

        public string GetDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }



        /// <summary>
        /// 删除保单
        /// </summary>
        /// <param name="id">保单的id值</param>
        private void Del(int id)
        {
            To_Policy policy = To_PolicyManager.getTo_PolicyById(id);
            if (policy != null)
            {
                int jobflowid = policy.IsVerify;
                JobFlow model = JobFlowManager.GetModel(jobflowid);
                if (model == null || model.auditstatus != "01")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('保单已删除或审核员已审核')</script>");
                }
                else
                {
                    string strdel = " jobflowid=" + jobflowid;
                    AuditJobFlowManager.Delete(strdel);
                    JobFlowManager.Delete(jobflowid);
                    To_PolicyManager.deleteTo_Policy(id);
                    To_PolicyDetailManager.DeleteByPolicy(id);
                }
            }
        }

        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="jfid"></param>
        private void Refresh(int jfid)
        {
            EtNet_Models.JobFlow refreshmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (refreshmodel != null && (refreshmodel.auditstatus == "01" || refreshmodel.auditstatus == "03"))
            {
                string strfresh = " jobflowid = " + jfid;
                EtNet_BLL.AuditJobFlowManager.Delete(strfresh); //删除审核人员的数据，请假单回到草稿状态
                refreshmodel.savestatus = "草稿";
                refreshmodel.auditstatus = "01";
                refreshmodel.txt = "";

                string sqlpolicy = " isVerify =" + jfid.ToString();
                DataTable tblpolicy = EtNet_BLL.To_PolicyManager.GetList(1, sqlpolicy, "id");
                EtNet_Models.To_Policy policy = EtNet_BLL.To_PolicyManager.getTo_PolicyById(int.Parse(tblpolicy.Rows[0]["id"].ToString()));
                policy.Txt = "";
                EtNet_BLL.To_PolicyManager.updateTo_Policy(policy);

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


        protected void RpPolicy_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DELETE")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                //if (To_PolicyManager.deleteTo_Policy(id) > 0)
                //{
                //    To_PolicyDetailManager.DeleteByPolicy(id);
                //  RpPolicyBindData();
                //}
                Del(id);

            }
            if (e.CommandName == "refresh")
            {
                int jfid = int.Parse(e.CommandArgument.ToString());
                Refresh(jfid);
            }

            if (e.CommandName == "audit")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                int jobFlowID = int.Parse(args[0].Trim());
                int policyID = int.Parse(args[1].Trim());
                string num = args[2].Trim();

                JobFlow jobFlow = JobFlowManager.GetModel(jobFlowID);
                if (jobFlow.savestatus == "草稿" && jobFlow.auditstatus == "01")
                {
                    jobFlow.savestatus = "已提交";
                    jobFlow.auditstatus = "01";
                    JobFlowManager.Update(jobFlow);

                    int ruleID = jobFlow.ruleid;
                    CreateApproval(ruleID, jobFlowID);

                    SendMessage(ruleID, num);

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('送审成功');", true);


                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('该保单已送审，无需再次送审');", true);
                }
            }

            RpPolicyBindData();
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
                messageEntity.contents = string.Format("编号为{0}的保单需要您审批!", num);
                messageEntity.createtime = DateTime.Now;
                messageEntity.founderid = (Session["login"] as LoginInfo).Id;
                messageEntity.sendtime = DateTime.Now;
                messageEntity.sortid = 10;//消息分类：保单审核

                if (messageBLL.Add(messageEntity))
                {
                    IEnumerable<string> userList = rule.idgourp.Split(',').Where(x => x != string.Empty);

                    int messageID = messageBLL.GetMaxId();

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
                        model.reviewerid = int.Parse(staff[i]);
                        model.opiniontxt = "";
                        EtNet_BLL.AuditJobFlowManager.Add(model);
                    }
                    break;
            }
        }

        public bool IsSelf(object id)
        {
            LoginInfo login = Session["login"] as LoginInfo;
            if (login != null)
            {
                return id.Equals(login.Id);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 点击筛选保单时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterPolicy();
            RpPolicyBindData();
        }

        /// <summary>
        /// 点击重置筛选条件时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterSql = string.Empty;
            RpPolicyBindData();
            txtFilterCompany.Text = string.Empty;
            txtFilterCustomer.Text = string.Empty;
            txtFilterPolicyNum.Text = string.Empty;
            txtFilterProType.Text = string.Empty;
            txtFilterSalesman.Text = string.Empty;
            ddlFilterPolicyState.SelectedIndex = 0;
            //ddldate.SelectedIndex = 0;
            txtFilterSatrtTime.Text = string.Empty;
            txtFilterEndTime.Text = string.Empty;
        }

        /// <summary>
        /// 根据条件筛选保单数据
        /// </summary>
        private void FilterPolicy()
        {

            StringBuilder filterSql = new StringBuilder();
            if (txtFilterCompany.Text.Trim() != string.Empty)
                filterSql.AppendFormat(" AND comShortName like '%{0}%' ", txtFilterCompany.Text.Trim());
            if (txtFilterCustomer.Text.Trim() != string.Empty)
                filterSql.AppendFormat(" AND cusshortName like '%{0}%' ", txtFilterCustomer.Text.Trim());
            //if (txtFilterPolicyDate.Text.Trim() != string.Empty)
            //    filterSql.AppendFormat(" AND Datename(year,policy_date)+'-'+Datename(month,policy_date)+'-'+Datename(day,policy_date) = '{0}' ", txtFilterPolicyDate.Text.Trim());
            if (txtFilterPolicyNum.Text.Trim() != string.Empty)
                filterSql.AppendFormat(" AND policy_num like '%{0}%' ", txtFilterPolicyNum.Text.Trim());
            if (txtFilterProType.Text.Trim() != string.Empty)
                filterSql.AppendFormat(" AND ProdTypeName like '%{0}%' ", txtFilterProType.Text.Trim());
            if (txtFilterSalesman.Text.Trim() != string.Empty)
                filterSql.AppendFormat(" AND cname like '%{0}%' ", txtFilterSalesman.Text.Trim());
            if (ddlFilterPolicyState.SelectedValue != "all")
                filterSql.AppendFormat(" AND auditstatus = '{0}' ", ddlFilterPolicyState.SelectedValue);
            if (ddlsavestatus.SelectedValue.ToString() != "0")
                filterSql.AppendFormat(" AND savestatus = '{0}' ", ddlsavestatus.SelectedItem.ToString());

            if (txtFilterSatrtTime.Text.Trim() == string.Empty)
            {
                if (txtFilterEndTime.Text.Trim() != string.Empty)
                {
                    filterSql.AppendFormat(" AND policy_date <= '{0}' ", txtFilterEndTime.Text.Trim());
                }
            }

            if (txtFilterEndTime.Text.Trim() == string.Empty)
            {
                if (txtFilterSatrtTime.Text.Trim() != string.Empty)
                {
                    filterSql.AppendFormat(" AND policy_date >= '{0}' ", txtFilterSatrtTime.Text.Trim());
                }
            }

            if (txtFilterSatrtTime.Text.Trim() != string.Empty && txtFilterEndTime.Text.Trim() != string.Empty)
                filterSql.AppendFormat(" AND ( policy_date BETWEEN '{0}' AND '{1}' ) ", txtFilterSatrtTime.Text.Trim(), txtFilterEndTime.Text.Trim());
            //if (ddldate.SelectedValue != "0")
            //{
            //    switch (this.ddldate.SelectedValue)
            //    {
            //        case "1":
            //            filterSql.AppendFormat (" AND policy_date='"+ DateTime.Now.ToString("yyyy-MM-dd") + "'",ddldate.Text.Trim());
            //            break;

            //        case "2":
            //            filterSql.AppendFormat(" AND policy_date" +  " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", ddldate.Text.Trim());
            //            break;

            //        case "3":
            //            filterSql.AppendFormat(" AND policy_date" + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'", ddldate.Text.Trim());
            //            break;

            //        case "4":
            //            filterSql.AppendFormat(" AND policy_date" + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'",ddldate.Text.Trim());
            //            filterSql.AppendFormat ( " AND policy_date" + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ",ddldate.Text.Trim());
            //            break;

            //        case "5":
            //            filterSql.AppendFormat(" AND policy_date " + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'", ddldate.Text.Trim());
            //            filterSql.AppendFormat(" AND policy_date" + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ", ddldate.Text.Trim());
            //            break;
            //    }
            //}

            this.FilterSql = filterSql.ToString();
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }
    }
}