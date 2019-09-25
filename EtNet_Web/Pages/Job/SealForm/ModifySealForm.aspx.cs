using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Globalization;

namespace PJOAUI.View.Job.SealForm
{
    public partial class ModifySealForm : System.Web.UI.Page
    {

       
     

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {    
                ReadAuthority();        
            }
            else
            {
                //加载原有附件的列表
                LoadFile();
            }
            
        }







        /// <summary>
        /// 判断进入修改界面是通过审核管理还是消息提示或主页，如是消息提示或主页判断是否符合修改所需的条件
        /// </summary>
        private void ReadAuthority()
        {
            if (Request.QueryString["login"] != null)
            {
                string str = "  founderid=" + Request.QueryString["login"] + " AND id=" + Request.QueryString["id"];
                str += " AND  savestatus='草稿' AND  auditstatus  in('01')";
                DataTable tbl = PJOABLL.JobFlowManager.GetList(str);
                if (tbl.Rows.Count < 1)
                {
                    Response.Redirect("../Error.aspx?error=1");
                }
                else
                {
                    LoadSealSort();
                    LoadAuditSort();
                    LoadApprovalRole();
                    LoadOriginalData();
                    //加载原有附件的列表
                    LoadFile(); ;
                }
            }
            else
            {
                LoadSealSort();
                LoadAuditSort();
                LoadApprovalRole();
                LoadOriginalData();
                //加载原有附件的列表
                LoadFile();
            }

        }









        /// <summary>
        /// 加载公章分类数据
        /// </summary>
        private void LoadSealSort()
        {
            DataTable tbl = PJOABLL.SealSortManager.GetList("");
            this.ddlsealsort.DataTextField = "txt";
            this.ddlsealsort.DataValueField = "id";
            this.ddlsealsort.DataSource = tbl;
            this.ddlsealsort.DataBind();
        }

        /// <summary>
        /// 加载审核类型下来列表的数据
        /// </summary>
        private void LoadAuditSort()
        {
            string[] str = new string[4];
            str[0] = "——请选中——";
            str[1] = "单审";
            str[2] = "选审";
            str[3] = "会签";

            this.ddlauditsort.DataSource = str;
            this.ddlauditsort.DataBind();


        }


        /// <summary>
        /// 加载审核规则
        /// </summary>
        private void LoadApprovalRole()
        {
            string str = this.ddlauditsort.SelectedItem.Text;

            DataTable tbl = PJOABLL.ApprovalRuleManager.GetList(str, "04");
            DataRow row = tbl.NewRow();
            row["id"] = "0";
            row["cname"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlapprovalrole.DataSource = tbl;
            this.ddlapprovalrole.DataValueField = "id";
            this.ddlapprovalrole.DataTextField = "cname";
            this.ddlapprovalrole.DataBind();

        }





        /// <summary>
        ///加载公章单的数据
        /// </summary>
        private void LoadOriginalData()
        {
           
            int id = int.Parse(Request.QueryString["id"]); //获取工作流的id值
            DataTable tbl = PJOABLL.ViewBLL.ViewApplySealManager.getlist(id);
            if (tbl.Rows.Count == 1)
            {

                Session["GZDId"] = tbl.Rows[0]["id"].ToString(); //公章单的id值
                this.lblnumbers.Text = tbl.Rows[0]["jobflowcname"].ToString();
                this.lbldepart.Text = tbl.Rows[0]["applicantdepartcname"].ToString();
                this.lblcanme.Text = tbl.Rows[0]["applicantcname"].ToString();
                this.lblapplydate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.ddlsealsort.SelectedValue = tbl.Rows[0]["sealsort"].ToString();

                this.iptstartdate.Value = tbl.Rows[0]["borrowstarttime"].ToString();
                this.iptenddate.Value = tbl.Rows[0]["borrowsendtime"].ToString();
                this.iptremark.Value = tbl.Rows[0]["remark"].ToString();

                int auditruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                if (auditruleid != 1)
                {
                    PJOAModels.ApprovalRule model = PJOABLL.ApprovalRuleManager.GetModel(auditruleid);
                    string path = model.rolepic;
                    string patha = Server.MapPath(path);
                    this.auditpic.InnerHtml = File.ReadAllText(Server.MapPath(path));
                    this.ddlauditsort.SelectedValue = model.sort;
                    LoadApprovalRole();
                    this.ddlapprovalrole.SelectedValue = model.id.ToString(); 


                }


            }

        }


        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        public void LoadFile()
        {

            string strfile = " jobflowid =" + int.Parse(Request.QueryString["id"]); ;
            DataTable tblfile = PJOABLL.JobFlowFileManager.GetList(strfile);
            HtmlTableRow filetr = null;
            HtmlTableCell filetd = null;
            HtmlAnchor filea = null;
            ImageButton imgbtn = null;

            if (tblfile.Rows.Count >= 1)
            {
                this.iptflienum.Value = tblfile.Rows.Count.ToString();
                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    filetr = new HtmlTableRow();
                    filetd = new HtmlTableCell();
                    filea = new HtmlAnchor();
                    filea.InnerText = tblfile.Rows[i]["filename"].ToString();
                    filea.HRef = tblfile.Rows[i]["fileload"].ToString();
                    imgbtn = new ImageButton();
                    imgbtn.CommandArgument = tblfile.Rows[i]["id"].ToString();
                    imgbtn.ImageUrl = "../../../Images/Job/delete.gif";
                    imgbtn.Click += new ImageClickEventHandler(imgbtnFile);
                    filetd.Controls.Add(filea);
                    filetd.Controls.Add(imgbtn);
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
            //现有附件的数量
            this.iptflienum.Value = tblfile.Rows.Count.ToString();

        }


        /// <summary>
        /// 删除附件
        /// </summary>
        public void imgbtnFile(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = sender as ImageButton;
            if (imgbtn != null)
            {

                string filename = PJOABLL.JobFlowFileManager.GetModel(int.Parse(imgbtn.CommandArgument)).fileload;
                //删除服务器上的相应的文件
                File.Delete(Server.MapPath(filename));
                PJOABLL.JobFlowFileManager.DeleteId(int.Parse(imgbtn.CommandArgument));
                this.originalfile.Controls.Clear();
                LoadFile();
            }
            else
            {
                this.originalfile.Controls.Clear();
                LoadFile();
            }


        }


        /// <summary>
        /// 上传附件，返回上传文件的路径的集合
        /// </summary>
        private string[] FileUp(HttpFileCollection item)
        {
            string[] str = new string[7] { "", "", "", "", "", "", "0" };
            string fileload = ""; //文件的路径
            //str[6] = "0";0为没有文件，1为有上传文件
            int num = 1;
            string saveUrl = "~/UploadFile/Job/";
            HttpPostedFile postfile = null;
            for (int i = 0; i < item.Count; i++)
            {
                postfile = item[i];
                if (postfile.FileName == "")
                {

                }
                else if (String.IsNullOrEmpty(Path.GetExtension(postfile.FileName).ToLower()))
                {
                    str[0] = postfile.FileName + "文件拓展名出错，导致上传失败";
                    str[6] = "0";
                    if (num == 1)
                    {

                        return str;
                    }
                    else
                    {
                        for (int j = 1; j < num; j++)
                        {
                            fileload = str[j].Substring(0, str[j].LastIndexOf("|"));
                            File.Delete(HttpContext.Current.Server.MapPath(fileload));
                        }
                        return str;
                    }
                }
                else
                {
                    if (postfile.ContentLength <= (1024 * 1024))
                    {
                        string fileExt = Path.GetExtension(postfile.FileName).ToLower();
                        //上传文件的名称包括拓展名
                        string orfilename = postfile.FileName.Substring(postfile.FileName.LastIndexOf("\\") + 1);
                        string newFile = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + orfilename;
                        postfile.SaveAs(HttpContext.Current.Server.MapPath(saveUrl + newFile));
                        str[num] = saveUrl + newFile + "|" + postfile.ContentLength;
                        str[6] = "1";
                        num++;

                    }
                    else
                    {
                        str[0] = postfile.FileName + "文件太大，导致上传失败";
                        str[6] = "0";
                        if (num == 1)
                        {
                            return str;
                        }
                        else
                        {
                            for (int j = 1; j < num; j++)
                            {
                                fileload = str[j].Substring(0, str[j].LastIndexOf("|"));
                                File.Delete(HttpContext.Current.Server.MapPath(fileload));

                            }
                            return str;
                        }
                    }

                }

            }

            return str;

        }


        /// <summary>
        /// 保存附件的路径
        /// </summary>
        /// <param name="filelist">附件的路径的列表</param>
        /// <param name="jobflowid">工作流的id值</param>
        private void CreateJobFlowFile(string[] filelist, int jobflowid)
        {
            PJOAModels.JobFlowFile model = null;

            for (int i = 1; i < 6; i++)
            {
                if (filelist[i] != "")
                {
                    model = new PJOAModels.JobFlowFile();
                    model.createtime = DateTime.Now.ToString();
                    model.fileload = filelist[i].Substring(0, filelist[i].IndexOf("|"));
                    int startindex = filelist[i].LastIndexOf("/");
                    int endindex = filelist[i].LastIndexOf(".");
                    model.filename = filelist[i].Substring(startindex + 1, endindex - startindex - 1);
                    model.filesize = int.Parse(filelist[i].Substring(filelist[i].LastIndexOf("|") + 1));
                    model.jobflowid = jobflowid;
                    PJOABLL.JobFlowFileManager.Add(model);

                }
            }
        }

        /// <summary>
        /// 查询原有附件的数量
        /// </summary>
        private bool SerchFile(int jobflowid)
        {
            string str = " jobflowid =" + jobflowid;
            DataTable tbl = PJOABLL.JobFlowFileManager.GetList(str);
            if (tbl.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        ///  创建审批序列
        /// </summary>
        /// <param name="auditsort">审批的类型单审，选审或是会签</param>
        /// <param name="staff">审核人员的列表</param>
        /// <param name="id">工作流的id号</param>
        private void CreateApproval(string auditsort, string stafflist, int id)
        {
            string[] staff = null;
            int len = 0; //审批人员的个数
            PJOAModels.AuditJobFlow model = null;
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
                        model = new PJOAModels.AuditJobFlow();
                        model.auditoperat = "未操作";
                        model.operatstatus = "未审核";
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
                        PJOABLL.AuditJobFlowManager.Add(model);
                    }
                    break;

                case "选审":
                case "会签":
                    for (int i = 0; i < staff.Length; i++)
                    {
                        model = new PJOAModels.AuditJobFlow();
                        model.auditoperat = "未操作";
                        model.operatstatus = "未审核";
                        model.audittime = new DateTime(1900, 1, 1);
                        model.nowreviewer = "T";
                        model.mainreviewer = "T";
                        model.numbers = 1;
                        model.jobflowid = id;
                        model.reviewerid = int.Parse(staff[i]);
                        PJOABLL.AuditJobFlowManager.Add(model);
                    }
                    break;

            }
        }



        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendInformation(int jobflowid, string[] list)
        {
            PJOAModels.JobFlow model = PJOABLL.JobFlowManager.GetModel(jobflowid);
            PJOAModels.Information informodel = null;
            if (model != null)
            {
                informodel = new PJOAModels.Information();
                informodel.sortid = 5;
                informodel.associationid = jobflowid;
                informodel.contents = "审核编号为" + model.cname + "的单据";
                informodel.createtime = DateTime.Now;
                informodel.sendtime = DateTime.Now;
                informodel.founderid = ((PJOAModels.LoginInfo)Session["login"]).Id;
                if (PJOABLL.InformationManager.Add(informodel))
                {
                    int maxid = PJOABLL.InformationManager.GetMaxId();
                    PJOAModels.InformationNotice infnotic = null;
                    for (int j = 0; j < list.Length; j++)
                    {
                        infnotic = new PJOAModels.InformationNotice();
                        infnotic.informationid = maxid;
                        infnotic.recipientid = int.Parse(list[j].ToString());
                        infnotic.remind = "是";
                        PJOABLL.InformationNoticeManager.Add(infnotic);

                    }

                }
            }

        }





        /// <summary>
        /// 单据是否可修改以及提交单据
        /// </summary>
        private bool IsCanModifyUp()
        {
            string str = "  founderid=" + ((PJOAModels.LoginInfo)Session["login"]).Id + " AND id=" + Request.QueryString["id"];
            str += " AND  savestatus='草稿' AND  auditstatus  in('01')";
            DataTable tbl = PJOABLL.JobFlowManager.GetList(str);
            if (tbl.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 提交数据
        /// </summary>
        private void Submit()
        {
            if (IsCanModifyUp())
            {

                string[] strfile = FileUp(Request.Files);
                if (strfile[0] != "")
                {

                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "jobflow", "<script>alert('提交申请失败原因:" + strfile[0] + "！');</script>", false);
                }
                else
                {

                    PJOAModels.JobFlow jobmodel = new PJOAModels.JobFlow();
                    jobmodel.cname = this.lblnumbers.Text;
                    jobmodel.sort = "04";
                    jobmodel.auditsort = "";
                    jobmodel.auditstatus = "01";
                    jobmodel.createtime = DateTime.Now; //默认是当前时间
                    jobmodel.endtime = DateTime.Now;
                    jobmodel.founderid = ((PJOAModels.LoginInfo)Session["login"]).Id; //登录人员的id号
                    jobmodel.savestatus = "已提交";
                    jobmodel.txt = "";
                    jobmodel.ruleid = int.Parse(this.ddlapprovalrole.SelectedValue);
                    jobmodel.id = int.Parse(Request.QueryString["id"].ToString());

                    //判断是否有附件
                    if (strfile[6] == "1")
                    {
                        jobmodel.attachment = "1";
                        CreateJobFlowFile(strfile, int.Parse(Request.QueryString["id"].ToString()));

                    }
                    else
                    {
                        bool hasflie = SerchFile(int.Parse(Request.QueryString["id"].ToString()));
                        if (hasflie)
                        {
                            jobmodel.attachment = "1";
                        }
                        else
                        {
                            jobmodel.attachment = "~/UploadFile/Job/defaultfile.txt";
                        }
                    }

                    PJOABLL.JobFlowManager.Update(jobmodel);


                    int jfid = int.Parse(Request.QueryString["id"].ToString()); //获取工作流的id值

                    PJOAModels.ApplySeal model = new PJOAModels.ApplySeal();
                    model.applicantid = ((PJOAModels.LoginInfo)Session["login"]).Id;
                    model.applydate = DateTime.Now;
                    model.borrowstarttime = Convert.ToDateTime(this.iptstartdate.Value);
                    model.borrowsendtime = Convert.ToDateTime(this.iptenddate.Value);
                    model.jobflowid = jfid;
                    model.id = int.Parse(Session["GZDId"].ToString());
                    model.remark = Server.UrlDecode(this.iptremark.Value);
                    model.sort = int.Parse(this.ddlsealsort.SelectedValue);
                    model.txt = ""; //审批人员填写的字段



                    if (PJOABLL.ApplySealManager.Update(model))
                    {
                        string stafflist = PJOABLL.ApprovalRuleManager.GetModel(int.Parse(this.ddlapprovalrole.SelectedValue)).idgourp.ToString();
                        CreateApproval(ddlauditsort.SelectedValue, stafflist, jfid);

                        SendInformation(jfid, stafflist.Split(','));
                        Response.Redirect("ShowSealForm.aspx");

                    }
                }
            }
            else
            {
                Response.Redirect("../Error.aspx?error=2");
            }
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        private void Save()
        {
            if (IsCanModifyUp())
            {
                string[] strfile = FileUp(Request.Files);
                if (strfile[0] != "")
                {

                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "jobflow", "<script>alert('草稿保存失败原因:" + strfile[0] + "！');</script>", false);
                }
                else
                {

                    PJOAModels.JobFlow jobmodel = new PJOAModels.JobFlow();
                    jobmodel.cname = this.lblnumbers.Text;
                    jobmodel.sort = "04";
                    jobmodel.auditsort = "";
                    jobmodel.auditstatus = "01";
                    jobmodel.createtime = DateTime.Now; //默认是当前时间
                    jobmodel.endtime = DateTime.Now;
                    jobmodel.founderid = ((PJOAModels.LoginInfo)Session["login"]).Id; //登录人员的id号
                    jobmodel.savestatus = "草稿";
                    jobmodel.txt = "";
                    jobmodel.id = int.Parse(Request.QueryString["id"].ToString());
                    //未选审核规则字段值为“1”
                    jobmodel.ruleid = (this.ddlapprovalrole.SelectedIndex == 0) ? 1 : int.Parse(this.ddlapprovalrole.SelectedValue);

                    //判断是否有附件
                    if (strfile[6] == "1")
                    {
                        jobmodel.attachment = "1";
                        CreateJobFlowFile(strfile, int.Parse(Request.QueryString["id"].ToString()));
                    }
                    else
                    {
                        bool hasflie = SerchFile(int.Parse(Request.QueryString["id"].ToString()));
                        if (hasflie)
                        {
                            jobmodel.attachment = "1";
                        }
                        else
                        {
                            jobmodel.attachment = "~/UploadFile/Job/defaultfile.txt";
                        }
                    }

                    PJOABLL.JobFlowManager.Update(jobmodel);

                    PJOAModels.ApplySeal model = new PJOAModels.ApplySeal();
                    model.applicantid = ((PJOAModels.LoginInfo)Session["login"]).Id;
                    model.applydate = DateTime.Now;
                    model.borrowstarttime = Convert.ToDateTime(this.iptstartdate.Value);
                    model.borrowsendtime = Convert.ToDateTime(this.iptenddate.Value);
                    model.jobflowid = int.Parse(Request.QueryString["id"].ToString());
                    model.id = int.Parse(Session["GZDId"].ToString());
                    model.jobflowid = int.Parse(Request.QueryString["id"].ToString());
                    model.remark = Server.UrlDecode(this.iptremark.Value);
                    model.sort = int.Parse(this.ddlsealsort.SelectedValue);
                    model.txt = ""; //审批人员填写的字段

                    if (PJOABLL.ApplySealManager.Update(model))
                    {

                        Response.Redirect("ShowSealForm.aspx");

                    }
                }
            }
            else
            {
                Response.Redirect("../Error.aspx?error=2");
            }
        }




        /// <summary>
        /// 依据不同的审核规则查看相应的审核流程图
        /// </summary>
        protected void ddlapprovalrole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlapprovalrole.SelectedIndex != 0)
            {
                int auditroleid = int.Parse(this.ddlapprovalrole.SelectedValue);
                PJOAModels.ApprovalRule model = PJOABLL.ApprovalRuleManager.GetModel(auditroleid);
                if (model != null)
                {
                    string strpath = model.rolepic;
                    this.auditpic.InnerHtml = File.ReadAllText(Server.MapPath(strpath));

                }

            }
            else
            {

            }

            string str = "<script> $(function(){ $('#iptremark').val(jQuery.changereducestr($('#iptremark').val()));});</script>";

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "reducestr", str, false);


        }


        protected void ddlauditsort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更具不同的审核分类，显示相应的可用规则选项
            LoadApprovalRole();
            //没有可选的审核的规则时，清楚掉审核流程图
            if (this.ddlapprovalrole.Items.Count == 1)
            {
                this.auditpic.InnerHtml = "";
            }

            string str = "<script> $(function(){ $('#iptremark').val(jQuery.changereducestr($('#iptremark').val()));});</script>";

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "reducestr", str, false);


        }

        /// <summary>
        /// 重置数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
        {
            this.ddlauditsort.SelectedIndex = 0;
            this.ddlapprovalrole.SelectedIndex = 0;
            this.auditpic.InnerHtml = "";
            LoadOriginalData();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            Save();
        }
        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            Submit();
        }





    }
}