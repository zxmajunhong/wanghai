using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class AuditCus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCus();
            }
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
                    loadCus();
                }
            }
            else
            {
                loadCus();
            }

        }


        private void loadCus()
        {
            string jfid = Request.QueryString["jobflowid"].ToString();
            string strsql = " jobflowid=" + jfid;
            DataTable tbl = EtNet_BLL.CustomerManager.GetList(strsql);
            if (tbl.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "audit", "alert('数据出错，客户可能已删除！');location.href='../Job/AuditJobFlow.aspx'", true);
                return;
            }
            int id = int.Parse(tbl.Rows[0]["id"].ToString());

            EtNet_Models.Customer customer = EtNet_BLL.CustomerManager.getCustomerById(Convert.ToInt32(id));
            //基本信息
            this.lblcuscode.Text = customer.CusCode.ToString() + "　";
            this.lblshortname.Text = customer.CusshortName.ToString() + "　";
            this.lbladdress.Text = customer.Province.ToString() + " " + customer.City.ToString() + "　";
            this.lblcname.Text = customer.CusCName.ToString() + "　";
            this.lblcompanyurl.Text = customer.CompanyURL.ToString() + "　";

            if (customer.CusType == 0)
            {
                this.lblcustype.Text = "暂未选择类别";
            }
            else
            {
                this.lblcustype.Text = EtNet_BLL.CusTypeManager.getCusTypeById(customer.CusType).TypeName.ToString();
            }

            if (customer.Used == 0)
            {
                this.lblused.Text = "暂未启用";
            }
            else
            {
                this.lblused.Text = "已启用";
            }


            if (customer.CusPro == 0)
            {
                this.lblcuspro.Text = "潜在客户";
            }
            else
            {
                this.lblcuspro.Text = "正式客户";
            }


            this.lblcaddress.Text = customer.CusCAddress.ToString() + "　";

            //主要联系人
            this.lbllinkname.Text = customer.LinkName.ToString() + "　";
            this.lbllinkpost.Text = customer.Post.ToString() + "　";
            this.lbllinkfax.Text = customer.Fax.ToString() + "　";
            this.lbllinkemail.Text = customer.Email.ToString() + "　";
            this.lbllinkmobile.Text = customer.Mobile.ToString() + "　";
            this.lbllinktel.Text = customer.Telephone.ToString() + "　";
            this.lbllinkskype.Text = customer.Skype.ToString() + "　";
            this.lbllinkmsn.Text = customer.Msn.ToString() + "　";

            //主要银行信息
            this.lblbank.Text = customer.Bank.ToString() + "　";
            this.lblbankcard.Text = customer.CardId.ToString() + "　";
            this.lblbankman.Text = customer.CardName.ToString() + "　";
            this.lblremark.Text = customer.Remark.ToString() + "　";


            this.lblMadeFrom.Text = EtNet_BLL.LoginInfoManager.getLoginInfoById(customer.Madefrom).Cname;
            this.lblMadeTime.Text = customer.MadeTime.ToString("yyyy-MM-dd");

            loadOtherLink(id);
            loadOtherBank(id);

        }

        //读取其他联系人信息
        private void loadOtherBank(int id)
        {
            DataTable dt = EtNet_BLL.CusLinkmanManager.getList(id);
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["linkName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["post"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["telephone"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["fax"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["mobile"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["email"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["msn"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["skype"].ToString();
                    row.Controls.Add(cell);

                    // this.tablelanguage.Controls.Add(row);
                    this.tablelink.Controls.Add(row);
                }
            }


        }


        //读取其他银行信息
        private void loadOtherLink(int id)
        {
            DataTable dt = EtNet_BLL.CusBankManager.getList(id);
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["bank"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["cardId"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["cardName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["remark"].ToString();
                    row.Controls.Add(cell);

                    this.tablebank.Controls.Add(row);
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
                model.sortid = 9;
                model.associationid = jfid;
                model.createtime = DateTime.Now;
                model.sendtime = DateTime.Now;
                model.founderid = jfmodel.founderid;
                model.contents = "名称为" + jfmodel.cname + "的客户需要您审批!"; ;
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
        /// 通过审核方法
        /// </summary>
        private void Pass()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string comparedata = " reviewerid=" + login.Id + " AND jobflowid=" + jobflowid.ToString();
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
                string strsql = " jobflowcode=" + jobflowid.ToString();

                DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
                if (tbl.Rows.Count == 1)
                {
                    int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                    EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
                    ruletxt = rule.sort;

                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + login.Id;
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
                    auditmodel.opiniontxt = Server.UrlDecode(this.iptcomment.Value.Trim());
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

                            }
                            break;

                        case "选审":

                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                            EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            EtNet_BLL.AuditJobFlowManager.UpdateOther(" reviewerid != " + login.Id + " and jobflowid=" + jobflowid.ToString());
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
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; //工作流的状审核状态为“进行中”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            break;

                    }



                    string strad = "编号为" + jobflowmodel.cname + "的客户，【" + login.Cname + "】通过审批!";
                    SendInfo(strad, jobflowmodel.id);

                    SendNextAudit(jobflowmodel.id);

                    //修改客户的审核意见与启用状态
                    int cusid = int.Parse(tbl.Rows[0]["id"].ToString());
                    EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(cusid);
                    cus.Txt = cus.Txt + login.Cname + "的审批意见：" + Server.UrlDecode(this.iptcomment.Value.Trim()) + "|";
                    if (jobflowmodel.auditstatus == "04")
                    {
                        cus.Used = 1;
                    }
                    EtNet_BLL.CustomerManager.updateCustomer(cus);

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
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string comparedata = " reviewerid=" + login.Id + " AND jobflowid=" + jobflowid.ToString();
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
                string strsql = " jobflowcode=" + jobflowid.ToString();
                DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
                if (tbl.Rows.Count == 1)
                {
                    int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                    EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
                    ruletxt = rule.sort;

                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + login.Id;
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
                    auditmodel.opiniontxt = Server.UrlDecode(this.iptcomment.Value.Trim());
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


                    string strad = "编号为" + jobflowmodel.cname + "的客户，【" + login.Cname + "】拒绝审批!";
                    SendInfo(strad, jobflowmodel.id);

                    //修改客户的审核意见
                    int cusid = int.Parse(tbl.Rows[0]["id"].ToString());
                    EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(cusid);
                    cus.Txt = cus.Txt + login.Cname + "的审批意见：" + Server.UrlDecode(this.iptcomment.Value.Trim()) + "|";
                    EtNet_BLL.CustomerManager.updateCustomer(cus);

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


        //通过
        protected void ibtnPass_Click(object sender, ImageClickEventArgs e)
        {
            Pass();
        }

        //拒绝
        protected void ibtnRefuse_Click(object sender, ImageClickEventArgs e)
        {
            Refuse();
        }


    }
}