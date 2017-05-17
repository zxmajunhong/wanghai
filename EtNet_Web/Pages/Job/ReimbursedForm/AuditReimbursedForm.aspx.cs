using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class AuditReimbursedForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    LoadReimbursedFormData();

                }
            }
            else
            {
                LoadReimbursedFormData();
            }

        }



        /// <summary>
        /// 加载报销单数据
        /// </summary>
        private void LoadReimbursedFormData()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"]);
            string str = " jobflowid=" + jobflowid.ToString();
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(str);
            if (tbl.Rows.Count >= 1)
            {
                this.lblnumbers.Text = tbl.Rows[0]["jobflowcname"].ToString();   //报销申请单编号
                this.lblcanme.Text = tbl.Rows[0]["applycantcname"].ToString();   //填单人员
                this.lblapplydate.Text = tbl.Rows[0]["applydate"].ToString().Substring(0, 8); //填单日期
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString());//备注
                //收款账户信息
                this.lblbanker.Text = tbl.Rows[0]["banker"].ToString();
                this.lblbankname.Text = tbl.Rows[0]["bankname"].ToString();
                this.lblbanknum.Text = tbl.Rows[0]["banknum"].ToString();
                LoadDetialData();
                LoadOrderDetail();
                LoadFile();

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('报销单据不存在');window.location ='../AuditJobFlow.aspx'</script>", false);
            }

        }


        /// <summary>
        /// 加载订单明细数据
        /// </summary>
        private void LoadOrderDetail()
        {
            string jfid = Request.QueryString["jobflowid"];
            DataTable dt = EtNet_BLL.AusOrderInfoManager.GetList(jfid);
            rpOrderlist.DataSource = dt;
            rpOrderlist.DataBind();
        }

        /// <summary>
        /// 加载报销明细
        /// </summary>
        private void LoadDetialData()
        {
            string jfid = Request.QueryString["jobflowid"]; //获取工作流的id值
            DataTable tbl = EtNet_BLL.AusDetialInfoManager.GetLists(jfid);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string strnumeral = "";
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                row = new HtmlTableRow();
                cell = new HtmlTableCell();
                cell.InnerHtml = DateTime.Parse(tbl.Rows[i]["happendate"].ToString()).ToString("yyyy-MM-dd");
                cell.Attributes.Add("class", "clshdate");
                row.Controls.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = (string)tbl.Rows[i]["ausname"];
                cell.Attributes.Add("class", "clshdate");
                row.Controls.Add(cell);

                //EtNet_Models.DepartmentInfo departmentInfo = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(Convert.ToInt32(tbl.Rows[i]["belongsort"]));
                cell = new HtmlTableCell();
                cell.InnerHtml = (string)tbl.Rows[i]["belongsort"];
                cell.Attributes.Add("class", "clshdate");
                row.Controls.Add(cell);

                //EtNet_Models.LoginInfo loginInfo = EtNet_BLL.LoginInfoManager.getLoginInfoById(Convert.ToInt32(tbl.Rows[i]["Salesman"]));
                cell = new HtmlTableCell();
                cell.InnerHtml = (string)tbl.Rows[i]["Salesman"];
                cell.Attributes.Add("class", "clshdate");
                row.Controls.Add(cell);

                cell = new HtmlTableCell();
                strnumeral = tbl.Rows[i]["billnum"].ToString();
                cell.Attributes.Add("class", "clsdigit");
                cell.InnerHtml = ShowNumeral(strnumeral);
                row.Controls.Add(cell);

                cell = new HtmlTableCell();
                strnumeral = tbl.Rows[i]["ausmoney"].ToString();
                cell.Attributes.Add("class", "clsmoney");
                cell.InnerHtml = ShowNumeral(strnumeral);
                row.Controls.Add(cell);



                cell = new HtmlTableCell();
                cell.InnerHtml = tbl.Rows[i]["remark"].ToString();
                row.Controls.Add(cell);

                this.tblprocess.Controls.Add(row);

            }

        }

        /// <summary>
        /// 显示票据张数或金额
        /// </summary>
        /// <returns></returns>
        private string ShowNumeral(string strnumeral)
        {
            string result = "";
            result = strnumeral.Replace("0", "");
            result = result.Replace(".", "");
            if (result != "")
            {
                result = Decimal.Round(Decimal.Parse(strnumeral), 2).ToString();
            }
            return result;
        }


        /// <summary>
        /// 报销费用文本值
        /// </summary>
        private string ShowBelongSort(string sort)
        {
            string result = "";
            if (sort == "1")
            {
                result = "个人";
            }
            else
            {
                result = "公司";
            }
            return result;
        }



        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        private void LoadFile()
        {
            string strsql = " jobflowid=" + Request.QueryString["jobflowid"];
            DataTable tblfile = EtNet_BLL.JobFlowFileManager.GetList(strsql);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string str = "";
            if (tblfile.Rows.Count >= 1)
            {

                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();

                    cell.InnerHtml = FileIcon(tblfile.Rows[i]["fileload"].ToString());
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = tblfile.Rows[i]["filename"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    str = "<a target='_blank' href='../JobFlowFiles.aspx?id=" + tblfile.Rows[i]["id"].ToString() + "'>";
                    str += "<img alt='下载' src='../../../Images/public/download.png' /></a>";
                    cell.InnerHtml = str;
                    cell.Attributes.Add("align", "center");
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
            string result = "<img src='../../../Images/public/";
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
        /// 通过审核方法
        /// </summary>
        private void Pass()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id

            EtNet_Models.LoginInfo login = ((EtNet_Models.LoginInfo)Session["login"]);

            string comparedata = " reviewerid=" + login.Id.ToString() + " AND jobflowid=" + jobflowid.ToString();
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
                string streimburse = " jobflowid=" + jobflowid.ToString();
                DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(streimburse); //得到审核的信息
                if (tbl.Rows.Count == 1)
                {
                    ruletxt = tbl.Rows[0]["rulesort"].ToString();

                    //修改报销申请单
                    EtNet_Models.AusRottenInfo rotmodel = new EtNet_Models.AusRottenInfo();
                    rotmodel.applycantid = int.Parse(tbl.Rows[0]["applycantid"].ToString());//填单人员关联id
                    rotmodel.applydate = DateTime.Parse(tbl.Rows[0]["applydate"].ToString());//填单时间
                    rotmodel.id = int.Parse(tbl.Rows[0]["id"].ToString());//表id
                    rotmodel.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());//工作流关联id
                    //rotmodel.reimbursedsort = int.Parse(tbl.Rows[0]["reimbursedsort"].ToString());
                    rotmodel.remark = tbl.Rows[0]["remark"].ToString();//备注
                    rotmodel.totalmoney = Decimal.Parse(tbl.Rows[0]["totalmoney"].ToString());//总金额
                    //rotmodel.belongsort = int.Parse(tbl.Rows[0]["belongsort"].ToString());
                    rotmodel.billstate = int.Parse(tbl.Rows[0]["billstatecode"].ToString());//有票付款还是无票付款（现在隐藏该项，默认都是有票付款）
                    rotmodel.txt = tbl.Rows[0]["txt"].ToString() + login.Cname + "的审批意见：" + Server.UrlDecode(this.tracomment.Value.Trim()) + "|";
                    rotmodel.itemtype = tbl.Rows[0]["itemtype"].ToString();//项目类别汇总
                    rotmodel.person = tbl.Rows[0]["person"].ToString();//报销人员汇总
                    rotmodel.Banker = tbl.Rows[0]["banker"].ToString();
                    rotmodel.BankName = tbl.Rows[0]["bankname"].ToString();
                    rotmodel.bankNum = tbl.Rows[0]["banknum"].ToString();
                    EtNet_BLL.AusRottenInfoManager.Update(rotmodel);


                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + login.Id.ToString();
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
                    auditmodel.opiniontxt = Server.UrlDecode(this.tracomment.Value.Trim());
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
                                auditmodel.auditoperat = nextaudittbl.Rows[0]["auditoperat"].ToString(); //审批操作 开始/未开始/通过
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
                                //ModifyPayMoney(jobflowid);

                            }
                            break;

                        case "选审":

                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                            EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            EtNet_BLL.AuditJobFlowManager.UpdateOther(" reviewerid != " + login.Id + " and jobflowid=" + jobflowid.ToString());
                            //ModifyPayMoney(jobflowid);
                            break;

                        case "会审":
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
                                //ModifyPayMoney(jobflowid);
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; //工作流的状审核状态为“进行中”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            break;

                    }


                    string strad = "编号为" + jobflowmodel.cname + "的单据,【" + login.Cname + "】通过审批!";
                    SendInfo(strad, jobflowmodel.id);
                    SendNextAudit(jobflowmodel.id);
                    if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                    {
                        int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                        Response.Redirect("../AuditJobFlow.aspx?page=" + page + "");
                    }
                    else
                    Response.Redirect("../AuditJobFlow.aspx");
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

            string comparedata = " reviewerid=" + login.Id.ToString() + " AND jobflowid=" + jobflowid.ToString();
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
                string streimburse = " jobflowid=" + jobflowid.ToString();
                DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(streimburse);
                if (tbl.Rows.Count == 1)
                {
                    ruletxt = tbl.Rows[0]["rulesort"].ToString();
                    //修改报销申请单
                    EtNet_Models.AusRottenInfo rotmodel = new EtNet_Models.AusRottenInfo();
                    rotmodel.applycantid = int.Parse(tbl.Rows[0]["applycantid"].ToString());
                    rotmodel.applydate = DateTime.Parse(tbl.Rows[0]["applydate"].ToString());
                    rotmodel.id = int.Parse(tbl.Rows[0]["id"].ToString());
                    rotmodel.jobflowid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                    //rotmodel.reimbursedsort = int.Parse(tbl.Rows[0]["reimbursedsort"].ToString());
                    rotmodel.remark = tbl.Rows[0]["remark"].ToString();
                    rotmodel.totalmoney = Decimal.Parse(tbl.Rows[0]["totalmoney"].ToString());
                    //rotmodel.belongsort = int.Parse(tbl.Rows[0]["belongsort"].ToString());
                    rotmodel.billstate = int.Parse(tbl.Rows[0]["billstatecode"].ToString());
                    rotmodel.txt = tbl.Rows[0]["txt"].ToString() + login.Cname + "的审批意见：" + Server.UrlDecode(this.tracomment.Value.Trim()) + "|";
                    rotmodel.itemtype = tbl.Rows[0]["itemtype"].ToString();//项目类别汇总
                    rotmodel.person = tbl.Rows[0]["person"].ToString();//报销人员汇总
                    rotmodel.Banker = tbl.Rows[0]["banker"].ToString();
                    rotmodel.BankName = tbl.Rows[0]["bankname"].ToString();
                    rotmodel.bankNum = tbl.Rows[0]["banknum"].ToString();
                    EtNet_BLL.AusRottenInfoManager.Update(rotmodel);

                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + login.Id.ToString();
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
                    auditmodel.opiniontxt = Server.UrlDecode(this.tracomment.Value.Trim());
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


                    string strad = "编号为" + jobflowmodel.cname + "的单据,【" + login.Cname + "】拒绝审批!";
                    SendInfo(strad, jobflowmodel.id);
                    if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                    {
                        int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                        Response.Redirect("../AuditJobFlow.aspx?page=" + page + "");
                    }
                    else
                    Response.Redirect("../AuditJobFlow.aspx");


                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
        }


        /// <summary>
        /// 返回审核页面
        /// </summary>
        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["pageindex"] != null)
            {
                int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                Response.Redirect("../AuditJobFlow.aspx?page=" + page + "");
            }
            else
            Response.Redirect("../AuditJobFlow.aspx");
        }


        /// <summary>
        /// 拒绝审核
        /// </summary>
        protected void ibtnRefuse_Click(object sender, ImageClickEventArgs e)
        {
            Refuse();
        }


        /// <summary>
        /// 通过审核
        /// </summary>
        protected void ibtnPass_Click(object sender, ImageClickEventArgs e)
        {
            Pass();
        }

        /// <summary>
        /// 更改可支付金额
        /// </summary>
        /// <param name="jobflowid"></param>
        private void ModifyPayMoney(int jobflowid)
        {
            try
            {
                DataTable dt = EtNet_BLL.AusDetialInfoManager.GetLists(jobflowid.ToString());
                int year;
                string itemname;
                string username;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        year = DateTime.Parse(dt.Rows[i]["happendate"].ToString()).Year;
                        itemname = dt.Rows[i]["ausname"].ToString();
                        username = dt.Rows[i]["Salesman"].ToString();
                        if (EtNet_BLL.AusMoneyManager.Exists(itemname, username, year))
                        {
                            EtNet_Models.AusMoney ausmoney = EtNet_BLL.AusMoneyManager.GetModelByName(itemname, username, year);
                            ausmoney.haspay = (double)((decimal)ausmoney.haspay + decimal.Parse(dt.Rows[i]["ausmoney"].ToString()));
                            EtNet_BLL.AusMoneyManager.UpdateMoney(ausmoney);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}