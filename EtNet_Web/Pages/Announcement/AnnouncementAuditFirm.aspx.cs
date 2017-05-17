using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CommonlyUsed;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementAuditFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadAnnouncementData();
            }
        }

        /// <summary>
        /// 加载公告数据
        /// </summary>
        private void LoadAnnouncementData()
        {
            string strsql = " jobflowcode=" + Request.QueryString["jobflowid"];
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", strsql);
            if (tbl.Rows.Count == 1)
            {
                this.lblfirmtop.InnerHtml = tbl.Rows[0]["firmtxt"].ToString() + "文件";
                this.lblsfirm.InnerHtml = tbl.Rows[0]["firmstxt"].ToString();
                this.lblyear.InnerHtml = "[" + tbl.Rows[0]["yearnow"].ToString() + "]";
                this.lblorder.InnerHtml = tbl.Rows[0]["filenum"].ToString();
                this.lbltitle.InnerHtml = tbl.Rows[0]["title"].ToString();
                this.lbltxt.InnerHtml = tbl.Rows[0]["txt"].ToString();
                this.lblfirmbottom.InnerHtml = tbl.Rows[0]["firmtxt"].ToString();
                this.lbldate.InnerHtml = Conversion.ConversionDate(DateTime.Parse(tbl.Rows[0]["filetime"].ToString()), 1);
                this.lblword.InnerHtml = tbl.Rows[0]["themeword"].ToString();
                this.lblcarboncopy.InnerHtml = tbl.Rows[0]["carboncopytxt"].ToString();
                this.lblprintime.InnerHtml = Conversion.ConversionDate(DateTime.Parse(tbl.Rows[0]["printtime"].ToString()), 2);
                this.sealpath.Src = tbl.Rows[0]["imgpath"].ToString();
                this.lblcreater.InnerHtml = tbl.Rows[0]["creatertxt"].ToString();   
                int jfid = int.Parse(tbl.Rows[0]["jobflowcode"].ToString());  //工作流的id值
                string checkpid = tbl.Rows[0]["checkpcode"].ToString(); //校对人员的id值
                string checkptxt = tbl.Rows[0]["checkptxt"].ToString();  //校对人员的名称
                string signpid = tbl.Rows[0]["signpcode"].ToString();    //签发人员的id值
                string signptxt = tbl.Rows[0]["signptxt"].ToString();    //签发人员的名称
                this.lblcheckp.InnerHtml = ShowPname(checkpid, jfid, checkptxt);
                this.lblsignp.InnerHtml = ShowPname(signpid, jfid, signptxt);

                string announcementid = tbl.Rows[0]["id"].ToString();
                LoadFile(announcementid);
     
            }
        }



        /// <summary>
        /// 按条件显示校对人员或签发人员的名称
        /// </summary>
        /// <param name="checkpid">校对人员或签发人员的id值</param>
        /// <param name="jfid">工作流id值</param>
        /// <param name="checkptxt">校对人员或签发人员的名称</param>
        /// <returns></returns>
        private string ShowPname(string pid, int jfid, string checkptxt)
        {
            string result = "";
            string strsql = " reviewerid=" + pid;
            strsql += " AND jobflowid=" + jfid;
            strsql += " AND nowreviewer='P'";
            strsql += " AND auditoperat='通过'";
            DataTable tbl = EtNet_BLL.AuditJobFlowManager.GetList(strsql);
            if (tbl.Rows.Count == 1)
            {
                result = checkptxt;
            }

            return result;
        }


        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        /// <param name="announcementid">公告的id值</param>
        private void LoadFile(string announcementid)
        {
            string strfile = " announcementid=" + announcementid;
            DataTable tblfile = EtNet_BLL.AnnouncementFilesManager.GetList(strfile);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string str = "";
            if (tblfile.Rows.Count >= 1)
            {

                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();

                    cell.InnerHtml = FileIcon(tblfile.Rows[i]["path"].ToString());
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = tblfile.Rows[i]["cname"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    str = "<a target='_blank' href='AnnouncementFiles.aspx?id=" + tblfile.Rows[i]["id"].ToString() + "'>";
                    str += "<img src='../../Images/Public/download.png' /></a>";

                    cell.InnerHtml = str;
                    row.Controls.Add(cell);
                    this.originalfile.Controls.Add(row);

                }
            }

        }



        /// <summary>
        /// 返回文件显示的图标
        /// </summary>
        private string FileIcon(string path)
        {
            string result = "<img src='../../Images/public/";
            string[] extend = new string[5] { "txt", "xls", "doc", "ppt", "pic" };
            string suffix = "";
            if (path.Trim() != "" && path.LastIndexOf('.') != -1)
            {
                int start = path.LastIndexOf('.');
                suffix = path.Substring(start + 1).ToLower();
                switch (suffix)
                {
                    case "txt":
                        result += "txtfile.png' />";
                        break;

                    case "xls":
                    case "xlsx":
                        result += "xlsfile.png' />";
                        break;

                    case "doc":
                    case "docx":
                        result += "docfile.png' />";
                        break;

                    case "ppt":
                    case "pptx":
                        result += "pptfile.png' />";
                        break;

                    case "png":
                    case "gif":
                    case "jpg":
                    case "bmp":
                        result += "picfile.png' />";
                        break;
                    default:
                        result += "dftfile.png' />";
                        break;
                }
            }
            else
            {
                result += "dftfile.png' />";
            }
            return result;
        }







        /// <summary>
        /// 创建审批结果消息,返回消息的id值
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
        /// 创建审批结果消息通知
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
        /// 发送审批结果消息
        /// </summary>
        /// <param name="straud">审批单据编号及意见</param>
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




        ///<summary>
        ///发送公告查看消息
        ///</summary>
        ///<param name="id">公告id值</param>
        private void AnnouncementInformation(int id)
        {
            DataTable tbl =  EtNet_BLL.LoginInfoManager.getList("");
            EtNet_Models.AnnouncementInfo announcement = EtNet_BLL.AnnouncementInfoManager.GetModel(id);
            
            EtNet_Models.Information model = new EtNet_Models.Information();
            model.associationid = id;
            model.contents = "你有一个新公告可以查看,该公告的名称为:'" + announcement.title + "'";
            model.createtime = DateTime.Now;
            model.sendtime = model.createtime;
            model.founderid = announcement.createrid;
            model.sortid = 8;
            EtNet_BLL.InformationManager.Add(model);
            int maxid = EtNet_BLL.InformationManager.GetMaxId();

            EtNet_Models.InformationNotice noticemodel = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                noticemodel = new EtNet_Models.InformationNotice();
                noticemodel.informationid = maxid;
                noticemodel.recipientid = int.Parse(tbl.Rows[i]["id"].ToString());
                noticemodel.remind = "是";
                EtNet_BLL.InformationNoticeManager.Add(noticemodel);
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
                model.sortid = 11;
                model.associationid = jfid;
                model.createtime = DateTime.Now;
                model.sendtime = DateTime.Now;
                model.founderid = jfmodel.founderid;
                model.contents = "名称为" + jfmodel.cname + "的公司公告需要您审批!"; ;
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
        /// 通过审批的方法
        /// </summary>
        private void Pass()
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
                //该工作流是审批方式是选审或会签所以在提交审批时，工作流已由他人审批通过
                Response.Redirect("../Job/AuditError.aspx?error=1");
            }
            else
            {
                string ruletxt = ""; //审批的分类
                string strsql = " jobflowcode=" + jobflowid.ToString();
            
                DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", strsql);

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
                            EtNet_BLL.AuditJobFlowManager.UpdateOther(" reviewerid != " + ((EtNet_Models.LoginInfo)Session["login"]).Id + " and jobflowid=" + jobflowid.ToString());
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

                    EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
                    string strad = "标题为" + jobflowmodel.cname + "公告，【"+ login.Cname +"】通过审批!";
                    SendInfo(strad, jobflowmodel.id);
                    SendNextAudit(jobflowmodel.id);

                    //修改公告的审批意见
                    int announcementid = int.Parse(tbl.Rows[0]["id"].ToString());
                    EtNet_Models.AnnouncementInfo announcement = EtNet_BLL.AnnouncementInfoManager.GetModel(announcementid);
                    announcement.opiniontxt = announcement.opiniontxt + login.Cname + "的审批意见：" + Server.UrlDecode(this.iptcomment.Value.Trim()) + "|";
                    if (jobflowmodel.auditstatus == "04")
                    {
                        announcement.statusid = 2;
                        announcement.createtime = DateTime.Now;

                        AnnouncementInformation(announcementid);
                    }
                    EtNet_BLL.AnnouncementInfoManager.Update(announcement);
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
        /// 拒绝审批的方法
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
                string ruletxt = ""; //审批的分类
                string strsql = " jobflowcode=" + jobflowid.ToString();
                DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", strsql);
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

                    EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
                    string strad = "标题为" + jobflowmodel.cname + "公告，【" + login.Cname + "】拒绝审批!";
                    SendInfo(strad, jobflowmodel.id);
                    
                    //修改公告的审批意见
                    int announcementid = int.Parse(tbl.Rows[0]["id"].ToString());
                    EtNet_Models.AnnouncementInfo announcement = EtNet_BLL.AnnouncementInfoManager.GetModel(announcementid);
                    announcement.opiniontxt = announcement.opiniontxt + login.Cname + "的审批意见：" + Server.UrlDecode(this.iptcomment.Value.Trim()) + "|";
                  
                    EtNet_BLL.AnnouncementInfoManager.Update(announcement);
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
        /// 通过申请
        /// </summary>
        protected void imgbtnpass_Click(object sender, ImageClickEventArgs e)
        {
            Pass();
        }

        /// <summary>
        /// 拒绝申请
        /// </summary>
        protected void imgbtnrefuse_Click(object sender, ImageClickEventArgs e)
        {
            Refuse();
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