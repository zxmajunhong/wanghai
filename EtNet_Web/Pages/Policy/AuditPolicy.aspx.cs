using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using System.Data;
using EtNet_BLL;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Policy
{
    public partial class AuditPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object id = Request.QueryString["jobflowid"];
            if (id == null || id.ToString() == "")
                return;
            int rid = 0;
            DataTable tbl = To_PolicyManager.GetLists(" isVerify=" + id.ToString());
            rid = int.Parse(tbl.Rows[0]["id"].ToString());
            InitData(Convert.ToInt32(rid));
        }

        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        private void LoadFile(int policyid)
        {

            string strfile = " policyID=" + policyid;
            EtNet_BLL.To_PolicyFileManager file = new To_PolicyFileManager();
            DataTable tblfile = file.GetList(strfile);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string str = "";
            if (tblfile.Rows.Count >= 1)
            {

                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();

                    cell.InnerHtml = FileIcon(tblfile.Rows[i]["filepath"].ToString());
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = tblfile.Rows[i]["filename"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    str = "<a target='_blank' href='PolicyFiles.aspx?id=" + tblfile.Rows[i]["id"].ToString() + "'>";
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
        /// 加载当前数据
        /// </summary>
        /// <param name="id"></param>
        private void InitData(int id)
        {
            To_Policy policyModel = new To_Policy();

            DataTable data = To_PolicyManager.GetList(id);

            if (data.Rows.Count > 0)
            {
                LblAssured.Text = data.Rows[0]["assured"].ToString();//被保险人
                //LblBrokerage.Text = data.Rows[0][""].ToString();//经纪费
                LblCompany.Text = data.Rows[0]["comshortname"].ToString();//保险公司
                LblCustomer.Text = data.Rows[0]["cusshortName"].ToString();//投保客户
                LblIsRenewal.Text = Convert.ToInt32(data.Rows[0]["IsRenewal"]) == 0 ? "否" : "是";//是否续保
                LblIsVirify.Text = data.Rows[0]["auditstutastxt"].ToString(); //审核状态

                LblPolicyDate.Text = Convert.ToDateTime(data.Rows[0]["policy_date"]).ToString("yyyy-MM-dd");//保单日期
                LblPolicyMaker.Text = data.Rows[0]["policy_maker"].ToString();//制单人
                LblPolicyNum.Text = data.Rows[0]["policy_num"].ToString();//保单编号
                LblPolicyState.Text = Convert.ToInt32(data.Rows[0]["policy_state"]) == 0 ? "无效" : "有效";//保单状态
                //LblPremium.Text = data.Rows[0][""].ToString();//保费合计
                //LblSalesman.Text = data.Rows[0]["cname"].ToString();//所属业务员

                LoginInfo userInfo = LoginInfoManager.getLoginInfoById(Convert.ToInt32(data.Rows[0]["policy_makerId"]));
                if (userInfo != null)
                {
                    DepartmentInfo department = DepartmentInfoManager.getDepartmentInfoById(userInfo.Departid);
                    if (department != null)
                    {
                        LblMakerDepart.Text = department.Departcname; //制单部门
                    }
                }

                zjjfrate.Text = data.Rows[0]["totalEcoRate"].ToString();//总经济费比率
                zbf.Text = data.Rows[0]["totalPremium"].ToString(); //总保费
                zjjf.Text = data.Rows[0]["totalEconomic"].ToString();//总经济费
                zbe.Text = data.Rows[0]["totalBrokerage"].ToString();//总保额
                ztf.Text = data.Rows[0]["totalRich"].ToString();//总贴费
                cm.Text = data.Rows[0]["shipName"].ToString();//船名

                LblSerialNum.Text = data.Rows[0]["serialnum"].ToString();//内部流水号
                LblTimeEnd.Text = Convert.ToDateTime(data.Rows[0]["policy_enddate"]).ToString("yyyy-MM-dd");//保单日期结束日期
                LblTimeStart.Text = Convert.ToDateTime(data.Rows[0]["policy_startdate"]).ToString("yyyy-MM-dd");//保单日期开始日期
                ltrYearsCount.Text = (Convert.ToDateTime(data.Rows[0]["policy_enddate"]).Year - Convert.ToDateTime(data.Rows[0]["policy_startdate"]).Year).ToString();
                LblType.Text = data.Rows[0]["ProdTypeName"].ToString();//险种
                lblUserCompany.Text = data.Rows[0]["userCompany"].ToString();

                InitProductType(id);

                BudgetPre1.InitData(id);
                UCTarget1.BindTarget(id);

                LoadFile(id);
            }
        }

        /// <summary>
        /// 加载保单的明细信息
        /// </summary>
        /// <param name="pid"></param>
        private void InitProductType(int pid)
        {
            ProductManager proBLL = new ProductManager();
            DataTable data = To_PolicyDetailManager.GetListByPolicyid(pid);


            RpProType.DataSource = data;
            RpProType.DataBind();


            decimal coverage = 0;
            decimal premium = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i]["fmone"] != null && data.Rows[i]["rich"] != null)
                {
                    coverage += Convert.ToDecimal(data.Rows[i]["fmone"]);
                    premium += Convert.ToDecimal(data.Rows[i]["rich"]);
                }
            }

            totalCoverage.InnerText = coverage.ToString("C");
            totalPremium.InnerText = premium.ToString("C");
        }


        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Job/AuditJobFlow.aspx");
        }



        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnrefuse_Click(object sender, ImageClickEventArgs e)
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string comparedata = " reviewerid=" + login.Id + " AND jobflowid=" + jobflowid.ToString();
            if (AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../AuditError.aspx?error=0");
            }
            else if (JobFlowManager.GetModel(jobflowid).auditstatus == "03" || JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../AuditError.aspx?error=1");
            }
            else
            {
                JobFlow jobflow = JobFlowManager.GetModel(jobflowid);
                ApprovalRule rule = ApprovalRuleManager.GetModel(jobflow.ruleid);
                string ruletxt = rule.sort; //审核的分类

                //修改当前审核人的记录
                AuditJobFlow auditmodel = null;
                string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + ((LoginInfo)Session["login"]).Id;
                DataTable audittbl = AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                auditmodel = new AuditJobFlow();
                auditmodel.auditoperat = "拒绝";
                auditmodel.audittime = DateTime.Now;
                auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                auditmodel.operatstatus = "已审批";
                auditmodel.opiniontxt = Server.UrlDecode(this.treatxt.Value.Trim());
                auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                AuditJobFlowManager.Update(auditmodel);
                //依据不同的审核类型进行操作
                switch (ruletxt)
                {
                    case "单审":
                    case "会审":
                        jobflow.endtime = DateTime.Now;
                        jobflow.auditstatus = "03"; //工作流的审核状态为“被拒绝”
                        JobFlowManager.Update(jobflow);
                        break;

                    case "选审":
                        string st = " jobflowid=" + jobflowid.ToString();
                        DataTable tbla = AuditJobFlowManager.GetList(st);
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
                            jobflow.endtime = DateTime.Now;
                            jobflow.auditstatus = "03"; // 工作流的审核状态为被拒绝
                            JobFlowManager.Update(jobflow);
                        }
                        else
                        {
                            jobflow.auditstatus = "02"; // 工作流的审核状态为进行中
                            JobFlowManager.Update(jobflow);
                        }

                        break;
                }

                string sqlpolicy = " isVerify =" + jobflowid.ToString();
                DataTable tblpolicy = EtNet_BLL.To_PolicyManager.GetList(1, sqlpolicy, "id");
                EtNet_Models.To_Policy policy = EtNet_BLL.To_PolicyManager.getTo_PolicyById(int.Parse(tblpolicy.Rows[0]["id"].ToString()));
                if (policy.Txt == "")
                {
                    policy.Txt = login.Cname + "的审批意见：" + Server.UrlDecode(this.treatxt.Value.Trim());
                }
                else
                {
                    policy.Txt = policy.Txt + "|" + login.Cname + "的审批意见：" + Server.UrlDecode(this.treatxt.Value.Trim());
                }
                EtNet_BLL.To_PolicyManager.updateTo_Policy(policy);

                SendMessage("【" + login.Cname + "】拒绝审批");
                Response.Redirect("../Job/AuditJobFlow.aspx");
            }
        }



        //通过审核
        protected void imgbtnpass_Click(object sender, ImageClickEventArgs e)
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string comparedata = " reviewerid=" + login.Id + " AND jobflowid=" + jobflowid.ToString();
            if (AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../Job/AuditJobFlow.aspx");
            }
            else if (JobFlowManager.GetModel(jobflowid).auditstatus == "03" || JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../Job/AuditJobFlow.aspx");
            }
            else
            {
                JobFlow jobflow = JobFlowManager.GetModel(jobflowid);
                ApprovalRule rule = ApprovalRuleManager.GetModel(jobflow.ruleid);
                string ruletxt = rule.sort; //审核的分类

                //修改当前审核人的记录
                AuditJobFlow auditmodel = null;
                string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + ((LoginInfo)Session["login"]).Id;
                DataTable audittbl = AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                auditmodel = new AuditJobFlow();
                auditmodel.auditoperat = "通过";
                auditmodel.audittime = DateTime.Now;
                auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                auditmodel.operatstatus = "已审批";
                auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                auditmodel.opiniontxt = Server.UrlDecode(this.treatxt.Value.Trim());
                AuditJobFlowManager.Update(auditmodel);



                //依据不同的审核类型进行操作
                switch (ruletxt)
                {
                    case "单审":
                        if (mainreviewer != "T")
                        {
                            auditmodel = new AuditJobFlow(); //设置下一个审核人的数据记录
                            string nextauditstr = " jobflowid=" + jobflowid.ToString() + " AND numbers=" + (num + 1).ToString();
                            DataTable nextaudittbl = AuditJobFlowManager.GetList(nextauditstr);
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
                            AuditJobFlowManager.Update(auditmodel);
                            jobflow.auditstatus = "02"; //工作流的审核状态为“进行中”
                            JobFlowManager.Update(jobflow);

                        }
                        else
                        {
                            jobflow.endtime = DateTime.Now;
                            jobflow.auditstatus = "04"; //工作流的审核状态为“已通过”
                            JobFlowManager.Update(jobflow);

                        }
                        break;

                    case "选审":

                        jobflow.endtime = DateTime.Now;
                        jobflow.auditstatus = "04"; //工作流的审核状态为“已通过”
                        JobFlowManager.Update(jobflow);
                        break;

                    case "会审":
                        bool pass = true;
                        string strsql = " jobflowid=" + jobflowid.ToString();
                        DataTable auditjobtbl = AuditJobFlowManager.GetList(strsql);
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
                            jobflow.endtime = DateTime.Now;
                            jobflow.auditstatus = "04"; //工作流的状审核状态为“已通过”
                            JobFlowManager.Update(jobflow);
                        }
                        else
                        {
                            jobflow.auditstatus = "02"; //工作流的状审核状态为“进行中”
                            JobFlowManager.Update(jobflow);
                        }
                        break;
                }

                string sqlpolicy = " isVerify =" + jobflowid.ToString();
                DataTable tblpolicy = EtNet_BLL.To_PolicyManager.GetList(1, sqlpolicy, "id");
                EtNet_Models.To_Policy policy = EtNet_BLL.To_PolicyManager.getTo_PolicyById(int.Parse(tblpolicy.Rows[0]["id"].ToString()));
                if (policy.Txt == "")
                {
                    policy.Txt = login.Cname + "的审批意见：" + Server.UrlDecode(this.treatxt.Value.Trim());
                }
                else
                {
                    policy.Txt = policy.Txt + "|" + login.Cname + "的审批意见：" + Server.UrlDecode(this.treatxt.Value.Trim());
                }
                EtNet_BLL.To_PolicyManager.updateTo_Policy(policy);

                SendMessage("【" + login.Cname + "】通过审批");
                SendNextAudit(jobflowid);
                Response.Redirect("../Job/AuditJobFlow.aspx");
            }
        }


        /// <summary>
        /// 发消息给用户
        /// </summary>
        /// <param name="msg">消息类型（已通过|被拒绝）</param>
        private void SendMessage(string msg)
        {

            EtNet_Models.Information messageEntity = new EtNet_Models.Information();

            DataTable tbl = To_PolicyManager.GetLists(" isVerify=" + Request.QueryString["jobflowid"].ToString());

            messageEntity.associationid = 0;//此处不需要，默认给一个值 
            messageEntity.contents = string.Format("编号为{0}的保单，{1}", tbl.Rows[0]["serialnum"], msg);
            messageEntity.createtime = DateTime.Now;
            messageEntity.founderid = (Session["login"] as LoginInfo).Id;
            messageEntity.sendtime = DateTime.Now;
            messageEntity.sortid = 1;//消息分类：个人消息

            if (InformationManager.Add(messageEntity))
            {
                int userID = int.Parse(tbl.Rows[0]["policy_makerId"].ToString());

                int messageID = InformationManager.GetMaxId();

                EtNet_Models.InformationNotice messageNoticeEntity = new InformationNotice();
                messageNoticeEntity.informationid = messageID;

                messageNoticeEntity.recipientid = userID;
                messageNoticeEntity.remind = "是";//默认未阅读;

                InformationNoticeManager.Add(messageNoticeEntity);
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
                model.sortid = 10;
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
        /// 转换文件大小单位
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        protected string ChangeSize(int size)
        {
            decimal newSize = size / 1024;

            if ((newSize / 1024) >= 1)
                return (newSize / 1024).ToString("F2") + "M";
            return newSize.ToString("F2") + "KB";
        }
    }
}