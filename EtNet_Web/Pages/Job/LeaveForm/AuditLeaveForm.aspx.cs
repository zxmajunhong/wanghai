﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace PJOAUI.View.Job.LeaveForm
{
    public partial class AuditLeaveForm : System.Web.UI.Page
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
                DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(str);
                if (tbl.Rows.Count < 1)
                {
                    Response.Redirect("../AuditError.aspx?error=2");
                }
                else
                {
                    LoadLeaveFormData();
                }
            }
            else
            {
                LoadLeaveFormData();
            }

        }


        

        /// <summary>
        /// 加载请假单的视图数据
        /// </summary>
        private void LoadLeaveFormData()
        {

            int id = int.Parse(Request.QueryString["jobflowid"].ToString());
            DataTable tbl = EtNet_BLL.ViewBLL.ViewApplyLeaveListManager.getOneList(id);
            if (tbl.Rows.Count > 0)
            {
                this.lblnumbers.Text = tbl.Rows[0]["cname"].ToString();
                this.lblapplydate.Text = tbl.Rows[0]["applydate"].ToString().Substring(0,10);
                this.lblcomment.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["applyleavetxt"].ToString());
                this.lbldepart.Text = tbl.Rows[0]["departcname"].ToString();
                this.lblleavesort.Text = tbl.Rows[0]["applyleavesort"].ToString();
                this.lblname.Text = tbl.Rows[0]["logincname"].ToString();
                this.leavetime.Text = tbl.Rows[0]["leavestarttime"].ToString() + " —— " + tbl.Rows[0]["leaveendtime"].ToString();
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString());
                
                LoadFile();

            }
          
        }



        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        public void LoadFile()
        {

            string strfile = " jobflowid =" + int.Parse(Request.QueryString["jobflowid"].ToString());
            DataTable tblfile = EtNet_BLL.JobFlowFileManager.GetList(strfile);
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
        /// 创建消息,返回消息的id值
        /// </summary>
        public int CreateInfo( string straudit)
        {

            EtNet_Models.Information model = new EtNet_Models.Information();
            model.sortid = 1;
            model.associationid = 1;
            model.createtime = DateTime.Now;
            model.sendtime = DateTime.Now;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.contents =  straudit;
            EtNet_BLL.InformationManager.Add(model);
            int maxid = EtNet_BLL.InformationManager.GetMaxId(((EtNet_Models.LoginInfo)Session["login"]).Id.ToString());
            return maxid;
        }

        


        /// <summary>
        /// 创建消息通知
        /// </summary>
        /// <param name="infoid">消息的id值</param>
        /// <param name="acceptid">接受人员的id值</param>
        public void CreateInfoNotice(int infoid,int acceptid)
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
            if(model != null)
            {
               int infoid = CreateInfo(straud);
               CreateInfoNotice(infoid, model.founderid);
            }
  
        }




        //不做审核，返回审核查询页面
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AuditJobFlow.aspx");
        }



        //审核通过
        protected void btnpass_Click(object sender, EventArgs e)
        {
            
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
             
            string comparedata = " reviewerid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND jobflowid=" + jobflowid.ToString();
            if (EtNet_BLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../AuditError.aspx?error=0");
            }
            else if (EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../AuditError.aspx?error=1");
            }
            else
            {
                string ruletxt = ""; //审核的分类
                DataTable tbl = EtNet_BLL.ViewBLL.ViewApplyLeaveListManager.getOneList(jobflowid);
                if (tbl.Rows.Count == 1)
                {
                    ruletxt = tbl.Rows[0]["rulesort"].ToString();
                    //修改请假单
                    EtNet_Models.ApplyLeaveList model = new EtNet_Models.ApplyLeaveList();
                    model.applydate = DateTime.Parse(tbl.Rows[0]["applydate"].ToString());
                    model.endtime = DateTime.Parse(tbl.Rows[0]["leaveendtime"].ToString());
                    model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                    model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                    model.leavepeopleid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                    model.remark = tbl.Rows[0]["remark"].ToString();
                    model.sort = tbl.Rows[0]["applyleavesort"].ToString();
                    model.starttime = DateTime.Parse(tbl.Rows[0]["leavestarttime"].ToString());
                    model.txt = tbl.Rows[0]["applyleavetxt"].ToString() + ((EtNet_Models.LoginInfo)Session["login"]).Cname + "的审核意见：" + Server.UrlDecode(this.treacomment.Value.Trim()) + "|";
                    EtNet_BLL.ApplyLeaveListManager.Update(model);

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
                    auditmodel.operatstatus = "已审核";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
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
                            break;

                        case "会签":
                            bool pass = true;
                            string strsql = " jobflowid=" + jobflowid.ToString();
                            DataTable auditjobtbl = EtNet_BLL.AuditJobFlowManager.GetList(strsql);
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

                    string strad ="通过编号为" + jobflowmodel.cname + "的单据申请";
                    SendInfo(strad ,jobflowmodel.id);
                    Response.Redirect("../AuditJobFlow.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
           

        }



        //审核不通过
        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            string comparedata = " reviewerid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND jobflowid=" + jobflowid.ToString();
            if (EtNet_BLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../AuditError.aspx?error=0");
            }
            else if (EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../AuditError.aspx?error=1");
            }
            else
            {
                string ruletxt = ""; //审核的分类
                DataTable tbl = EtNet_BLL.ViewBLL.ViewApplyLeaveListManager.getOneList(jobflowid);
                if (tbl.Rows.Count == 1)
                {
                    ruletxt = tbl.Rows[0]["rulesort"].ToString();
                    //修改请假单
                    EtNet_Models.ApplyLeaveList model = new EtNet_Models.ApplyLeaveList();
                    model.applydate = DateTime.Parse(tbl.Rows[0]["applydate"].ToString());
                    model.endtime = DateTime.Parse(tbl.Rows[0]["leaveendtime"].ToString());
                    model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                    model.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                    model.leavepeopleid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                    model.remark = tbl.Rows[0]["remark"].ToString();
                    model.sort = tbl.Rows[0]["applyleavesort"].ToString();
                    model.starttime = DateTime.Parse(tbl.Rows[0]["leavestarttime"].ToString());
                    model.txt = tbl.Rows[0]["applyleavetxt"].ToString() + ((EtNet_Models.LoginInfo)Session["login"]).Cname + "的审核意见：" + Server.UrlDecode(this.treacomment.Value.Trim()) + "| ";
                    EtNet_BLL.ApplyLeaveListManager.Update(model);

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
                    auditmodel.operatstatus = "已审核";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                    EtNet_BLL.AuditJobFlowManager.Update(auditmodel);

                    EtNet_Models.JobFlow jobflowmodel = new EtNet_Models.JobFlow();
                    jobflowmodel = EtNet_BLL.JobFlowManager.GetModel(jobflowid);

                    //依据不同的审核类型进行操作
                    switch (ruletxt)
                    {
                        case "单审":
                        case "会签":
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





    }
}