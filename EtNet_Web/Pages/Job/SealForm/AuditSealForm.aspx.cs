using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace PJOAUI.View.Job.SealForm
{
    public partial class AuditSealForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ReadAuthority();
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
                DataTable tbl = PJOABLL.ViewBLL.ViewAuditJobFlowManager.getList(str);
                if (tbl.Rows.Count < 1)
                {
                    Response.Redirect("../AuditError.aspx?error=2");
                }
                else
                {
                    LoadViewSealData();
                }
            }
            else
            {
                  LoadViewSealData();

            }

        }






        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        public void LoadFile()
        {

            string strfile = " jobflowid =" + int.Parse(Request.QueryString["jobflowid"].ToString());
            DataTable tblfile = PJOABLL.JobFlowFileManager.GetList(strfile);
            HtmlTableRow filetr = null;
            HtmlTableCell filetd = null;
            HtmlAnchor filea = null;

            if (tblfile.Rows.Count >= 1)
            {

                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    filetr = new HtmlTableRow();
                    filetd = new HtmlTableCell();
                    filea = new HtmlAnchor();
                    filea.InnerText = tblfile.Rows[i]["filename"].ToString();
                    filea.HRef = tblfile.Rows[i]["fileload"].ToString();
                    filetd.Controls.Add(filea);

                    filetr.Controls.Add(filetd);
                    this.originalfile.Controls.Add(filetr);

                }
            }
            else
            {
                filetr = new HtmlTableRow();
                filetd = new HtmlTableCell();
                filetd.InnerText = "无附件";
                filetr.Controls.Add(filetd);
                this.originalfile.Controls.Add(filetr);
            }


        }



        /// <summary>
        /// 加载审核的公章申请单内容
        /// </summary>
        private void LoadViewSealData()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString());

            DataTable sealtbl = PJOABLL.ViewBLL.ViewApplySealManager.getlist(jobflowid);

            if(sealtbl.Rows.Count > 0)
            {
                this.lblnumbers.Text = sealtbl.Rows[0]["jobflowcname"].ToString();
                this.lblname.Text = sealtbl.Rows[0]["applicantcname"].ToString();
                this.lbldepart.Text = sealtbl.Rows[0]["applicantdepartcname"].ToString();
                this.lblapplydate.Text = sealtbl.Rows[0]["applydate"].ToString().Substring(0,10);
                this.lblsealsort.Text = sealtbl.Rows[0]["sealsorttxt"].ToString();
                this.lblusetime.Text = sealtbl.Rows[0]["borrowstarttime"].ToString() + "——" + sealtbl.Rows[0]["borrowsendtime"].ToString();
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(sealtbl.Rows[0]["remark"].ToString());
                this.lblcomment.Text = CommonlyUsed.Conversion.StrConversion(sealtbl.Rows[0]["sealtxt"].ToString());
                LoadFile();

            }
            else
            { 
            
            }
                 
        }




        /// <summary>
        /// 创建消息,返回消息的id值
        /// </summary>
        public int CreateInfo(string straudit)
        {

            PJOAModels.Information model = new PJOAModels.Information();
            model.sortid = 1;
            model.associationid = 1;
            model.createtime = DateTime.Now;
            model.sendtime = DateTime.Now;
            model.founderid = ((PJOAModels.LoginInfo)Session["login"]).Id;
            model.contents = straudit;
            PJOABLL.InformationManager.Add(model);
            int maxid = PJOABLL.InformationManager.GetMaxId(((PJOAModels.LoginInfo)Session["login"]).Id.ToString());
            return maxid;
        }




        /// <summary>
        /// 创建消息通知
        /// </summary>
        /// <param name="infoid">消息的id值</param>
        /// <param name="acceptid">接受人员的id值</param>
        public void CreateInfoNotice(int infoid, int acceptid)
        {
            PJOAModels.InformationNotice model = new PJOAModels.InformationNotice();
            model.informationid = infoid;
            model.recipientid = acceptid;
            model.remind = "是";
            PJOABLL.InformationNoticeManager.Add(model);
        }



        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="straud">审核单据编号及意见</param>
        /// <param name="jobflowid">工作流id值</param>
        public void SendInfo(string straud, int jobflowid)
        {
            PJOAModels.JobFlow model = PJOABLL.JobFlowManager.GetModel(jobflowid);
            if (model != null)
            {
                int infoid = CreateInfo(straud);
                CreateInfoNotice(infoid, model.founderid);
            }

        }
        /// <summary>
        /// 通过审核方法
        /// </summary>
        private void Pass()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id

            string comparedata = " reviewerid=" + ((PJOAModels.LoginInfo)Session["login"]).Id + " AND jobflowid=" + jobflowid.ToString();
            if (PJOABLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../AuditError.aspx?error=0");
            }
            else if (PJOABLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || PJOABLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../AuditError.aspx?error=1");
            }
            else
            {
                string ruletxt = ""; //审核的分类
                DataTable tbl = PJOABLL.ViewBLL.ViewApplySealManager.getlist(jobflowid);
                if (tbl.Rows.Count == 1)
                {
                    ruletxt = tbl.Rows[0]["rulesort"].ToString();
                    //修改公章申请单
                    PJOAModels.ApplySeal model = new PJOAModels.ApplySeal();
                    model.applicantid = int.Parse(tbl.Rows[0]["applicantid"].ToString());
                    model.applydate = DateTime.Parse(tbl.Rows[0]["applydate"].ToString());
                    model.borrowsendtime = DateTime.Parse(tbl.Rows[0]["borrowsendtime"].ToString());
                    model.borrowstarttime = DateTime.Parse(tbl.Rows[0]["borrowstarttime"].ToString());
                    model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                    model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                    model.remark = tbl.Rows[0]["remark"].ToString();
                    model.sort = int.Parse(tbl.Rows[0]["sealsort"].ToString());
                    model.txt = tbl.Rows[0]["sealtxt"].ToString() + ((PJOAModels.LoginInfo)Session["login"]).Cname + "的审核意见：" + Server.UrlDecode(this.treacomment.Value.Trim()) + "|";
                    PJOABLL.ApplySealManager.Update(model);



                    //修改当前审核人的记录
                    PJOAModels.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + ((PJOAModels.LoginInfo)Session["login"]).Id;
                    DataTable audittbl = PJOABLL.AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                    int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                    string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                    auditmodel = new PJOAModels.AuditJobFlow();
                    auditmodel.auditoperat = "通过";
                    auditmodel.audittime = DateTime.Now;
                    auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                    auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                    auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                    auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                    auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                    auditmodel.operatstatus = "已审核";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                    PJOABLL.AuditJobFlowManager.Update(auditmodel);

                    PJOAModels.JobFlow jobflowmodel = new PJOAModels.JobFlow();
                    jobflowmodel = PJOABLL.JobFlowManager.GetModel(jobflowid);

                    //依据不同的审核类型进行操作
                    switch (ruletxt)
                    {
                        case "单审":
                            if (mainreviewer != "T")
                            {
                                auditmodel = new PJOAModels.AuditJobFlow(); //设置下一个审核人的数据记录
                                string nextauditstr = " jobflowid=" + jobflowid.ToString() + " AND numbers=" + (num + 1).ToString();
                                DataTable nextaudittbl = PJOABLL.AuditJobFlowManager.GetList(nextauditstr);
                                auditmodel.auditoperat = nextaudittbl.Rows[0]["auditoperat"].ToString();
                                auditmodel.audittime = DateTime.Parse(nextaudittbl.Rows[0]["audittime"].ToString());
                                auditmodel.id = int.Parse(nextaudittbl.Rows[0]["id"].ToString());
                                auditmodel.jobflowid = int.Parse(nextaudittbl.Rows[0]["jobflowid"].ToString());
                                auditmodel.mainreviewer = nextaudittbl.Rows[0]["mainreviewer"].ToString();
                                auditmodel.nowreviewer = "T"; //设置其为审核人员
                                auditmodel.numbers = int.Parse(nextaudittbl.Rows[0]["numbers"].ToString());
                                auditmodel.operatstatus = nextaudittbl.Rows[0]["operatstatus"].ToString();
                                auditmodel.reviewerid = int.Parse(nextaudittbl.Rows[0]["reviewerid"].ToString());
                                PJOABLL.AuditJobFlowManager.Update(auditmodel);

                                jobflowmodel.auditstatus = "02"; //工作流的审核状态为“进行中”
                                PJOABLL.JobFlowManager.Update(jobflowmodel);

                            }
                            else
                            {
                                jobflowmodel.endtime = DateTime.Now;
                                jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                                PJOABLL.JobFlowManager.Update(jobflowmodel);

                            }
                            break;

                        case "选审":

                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                            PJOABLL.JobFlowManager.Update(jobflowmodel);
                            break;

                        case "会签":
                            bool pass = true;
                            string strsql = " jobflowid=" + jobflowid.ToString();
                            DataTable auditjobtbl = PJOABLL.AuditJobFlowManager.GetList(strsql);
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
                                PJOABLL.JobFlowManager.Update(jobflowmodel);
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; //工作流的状审核状态为“进行中”
                                PJOABLL.JobFlowManager.Update(jobflowmodel);
                            }
                            break;

                    }

                    string strad = "通过编号为" + jobflowmodel.cname + "的单据申请";
                    SendInfo(strad, jobflowmodel.id);
                    Response.Redirect("../AuditJobFlow.aspx");

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
        }
        /// <summary>
        /// 拒绝审核
        /// </summary>
        private void Refuse()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            string comparedata = " reviewerid=" + ((PJOAModels.LoginInfo)Session["login"]).Id + " AND jobflowid=" + jobflowid.ToString();
            if (PJOABLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../AuditError.aspx?error=0");
            }
            else if (PJOABLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || PJOABLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../AuditError.aspx?error=1");
            }

            else
            {
                string ruletxt = ""; //审核的分类
                DataTable tbl = PJOABLL.ViewBLL.ViewApplySealManager.getlist(jobflowid);
                if (tbl.Rows.Count == 1)
                {
                    ruletxt = tbl.Rows[0]["rulesort"].ToString();
                    //修改公章申请单
                    PJOAModels.ApplySeal model = new PJOAModels.ApplySeal();
                    model.applicantid = int.Parse(tbl.Rows[0]["applicantid"].ToString());
                    model.applydate = DateTime.Parse(tbl.Rows[0]["applydate"].ToString());
                    model.borrowsendtime = DateTime.Parse(tbl.Rows[0]["borrowsendtime"].ToString());
                    model.borrowstarttime = DateTime.Parse(tbl.Rows[0]["borrowstarttime"].ToString());
                    model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                    model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                    model.remark = tbl.Rows[0]["remark"].ToString();
                    model.sort = int.Parse(tbl.Rows[0]["sealsort"].ToString());
                    model.txt = tbl.Rows[0]["sealtxt"].ToString() + ((PJOAModels.LoginInfo)Session["login"]).Cname + "的审核意见：" + Server.UrlDecode(this.treacomment.Value.Trim()) + "|";
                    PJOABLL.ApplySealManager.Update(model);

                    //修改当前审核人的记录
                    PJOAModels.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + ((PJOAModels.LoginInfo)Session["login"]).Id;
                    DataTable audittbl = PJOABLL.AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                    int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                    string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                    auditmodel = new PJOAModels.AuditJobFlow();
                    auditmodel.auditoperat = "拒绝";
                    auditmodel.audittime = DateTime.Now;
                    auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                    auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                    auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                    auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                    auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                    auditmodel.operatstatus = "已审核";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                    PJOABLL.AuditJobFlowManager.Update(auditmodel);

                    PJOAModels.JobFlow jobflowmodel = new PJOAModels.JobFlow();
                    jobflowmodel = PJOABLL.JobFlowManager.GetModel(jobflowid);

                    //依据不同的审核类型进行操作
                    switch (ruletxt)
                    {
                        case "单审":
                        case "会签":
                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "03"; //工作流的审核状态为“被拒绝”
                            PJOABLL.JobFlowManager.Update(jobflowmodel);

                            break;

                        case "选审":
                            string st = " jobflowid=" + jobflowid.ToString();
                            DataTable tbla = PJOABLL.AuditJobFlowManager.GetList(st);
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
                                PJOABLL.JobFlowManager.Update(jobflowmodel);
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; // 工作流的审核状态为进行中
                                PJOABLL.JobFlowManager.Update(jobflowmodel);
                            }

                            break;


                    }

                    string strad = "拒绝编号为" + jobflowmodel.cname + "的单据申请";
                    SendInfo(strad, jobflowmodel.id);
                    Response.Redirect("../AuditJobFlow.aspx");

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
        }

        /// <summary>
        /// 通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnPass_Click(object sender, ImageClickEventArgs e)
        {
            Pass();
        }
        /// <summary>
        /// 返回列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../AuditJobFlow.aspx");
        }

        protected void ibtnRefuse_Click(object sender, ImageClickEventArgs e)
        {
            Refuse();
        }
    }
}