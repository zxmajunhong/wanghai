using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;


namespace PJOAUI.View.Job.LeaveForm
{
    public partial class AddLeaveForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if(!IsPostBack)
             {
                 LoadAuditSort();
                 LoadApprovalRole();
                 LoadLoginInfo();
                 
             }
        }



        /// <summary>
        /// 加载登录用户数据
        /// </summary>
        private void LoadLoginInfo()
        {
            this.lblcanme.Text = ((EtNet_Models.LoginInfo)Session["login"]).Cname;
            this.lbldepart.Text = ((EtNet_Models.LoginInfo)Session["login"]).Departid.Departcname;
            this.lblapplydate.Text = DateTime.Now.ToString("yyyy-MM-dd");

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
            DataTable tbl = EtNet_BLL.ApprovalRuleManager.GetList(str, "01");
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
        /// 动态生成单据编号
        /// </summary>
        private string Numbers()
        {
            string str = "QJD";
            str += DateTime.Now.ToString("yyyyMMdd");
            string strnum = "";
            DataTable tblnum = EtNet_BLL.ViewBLL.ViewApplyLeaveListManager.getList(" sort='01' order by id desc ");
            if (tblnum.Rows.Count < 1)
            {
                str += string.Format("{0:D3}", 1); //用三位数字来表示，不足的三位用0补充

            }
            else
            {
                strnum = tblnum.Rows[0]["cname"].ToString().Substring(3, 8);
                if (strnum == DateTime.Now.ToString("yyyyMMdd"))
                {

                    str += string.Format("{0:D3}", int.Parse(tblnum.Rows[0]["cname"].ToString().Substring(11, 3)) + 1);
                }
                else
                {
                    str += string.Format("{0:D3}", 1); //用三位数字来表示，不足的三位用0补充
                }
            }

            str += DateTime.Now.ToString("ss");
            return str;

        }


        protected void ddlauditsort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更具不同的审核分类，显示相应的可用规则选项
            LoadApprovalRole();
            this.auditpic.InnerHtml = "";//清空原有的审核流程图
            string str = Server.UrlDecode(this.iptremark.Value);
            this.iptremark.Value = str;          
        }




        /// <summary>
        /// 依据不同的审核规则查看相应的审核流程图
        /// </summary>
        protected void ddlapprovalrole_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.ddlapprovalrole.SelectedIndex != 0)
            {
                int auditruleid = int.Parse(this.ddlapprovalrole.SelectedValue);
                EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(auditruleid);
                if (model != null)
                {
                    string strpath = model.rolepic;
                    this.auditpic.InnerHtml = File.ReadAllText(Server.MapPath(strpath));
                }
            }
            string str = Server.UrlDecode(this.iptremark.Value);
            this.iptremark.Value = str;

        }



        
        /// <summary>
        /// 上传附件，返回上传文件的路径的集合
        /// </summary>
        private string[] FileUp(HttpFileCollection item )
        {
            string[] str = new string[7]{"","","","","","","0"};
            string fileload =""; //文件的路径
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
                            fileload  = str[j].Substring(0, str[j].LastIndexOf("|"));
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
                        string orfilename = postfile.FileName.Substring(postfile.FileName.LastIndexOf("\\") + 1 );
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
        ///  创建审批序列
        /// </summary>
        /// <param name="auditsort">审批的类型单审，选审或是会签</param>
        /// <param name="staff">审核人员的列表</param>
        /// <param name="id">工作流的id号</param>
        private void CreateApproval(string auditsort, string stafflist,int id)
        {
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

           switch(auditsort)
           {
               case "单审":
                   for (int i = 0; i < staff.Length; i++ )
                   {
                       model = new EtNet_Models.AuditJobFlow();
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
                       EtNet_BLL.AuditJobFlowManager.Add(model); 
                   }
                   break;

               case "选审":
               case "会签":
                   for (int i = 0; i < staff.Length; i++ )
                   {
                       model = new EtNet_Models.AuditJobFlow();
                       model.audittime = new DateTime(1900,1,1); 
                       model.nowreviewer = "T";
                       model.mainreviewer = "T";
                       model.numbers = 1; 
                       model.jobflowid = id;
                       model.auditoperat = "未操作";
                       model.operatstatus = "未审核";
                       model.reviewerid = int.Parse(staff[i]);
                       EtNet_BLL.AuditJobFlowManager.Add(model); 
                   }
                   break;
              
           }
        }



        /// <summary>
        /// 保存附件的路径
        /// </summary>
        /// <param name="filelist">附件的路径的列表</param>
        /// <param name="jobflowid">工作流的id值</param>
        private void CreateJobFlowFile(string[] filelist,int jobflowid)
        {
            EtNet_Models.JobFlowFile model = null;
          
            for (int i = 1; i < 6; i++ )
            {
                if (filelist[i] != "")
                {
                    model = new EtNet_Models.JobFlowFile();
                    model.createtime = DateTime.Now.ToString();
                    model.fileload = filelist[i].Substring(0,filelist[i].IndexOf("|"));
                    int startindex = filelist[i].LastIndexOf("/");
                    int endindex = filelist[i].LastIndexOf(".");
                    model.filename = filelist[i].Substring(startindex + 1, endindex - startindex - 1);
                    model.filesize = int.Parse( filelist[i].Substring(filelist[i].LastIndexOf("|") + 1));
                    model.jobflowid = jobflowid;
                    EtNet_BLL.JobFlowFileManager.Add(model);
                    
                }
            }
        }



        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendInformation(int jobflowid, string[] list)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jobflowid);
            EtNet_Models.Information informodel = null;
            if (model != null)
            {
                informodel = new EtNet_Models.Information();
                informodel.sortid = 2;
                informodel.associationid = jobflowid;
                informodel.contents = "审核编号为" + model.cname + "的单据";
                informodel.createtime = DateTime.Now;
                informodel.sendtime = DateTime.Now;
                informodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                if (EtNet_BLL.InformationManager.Add(informodel))
                {
                    int maxid = EtNet_BLL.InformationManager.GetMaxId();
                    EtNet_Models.InformationNotice infnotic = null;
                    for (int j = 0; j < list.Length; j++)
                    {
                        infnotic = new EtNet_Models.InformationNotice();
                        infnotic.informationid = maxid;
                        infnotic.recipientid = int.Parse(list[j].ToString());
                        infnotic.remind = "是";
                        EtNet_BLL.InformationNoticeManager.Add(infnotic);
                    }
                }
            }
        }



        /// <summary>
        /// 申请保存
        /// </summary>
        private void SaveInput()
        {
            string[] strfile = FileUp(Request.Files);
            if (strfile[0] != "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "jobflow", "<script>alert('草稿保存失败原因:" + strfile[0] + "！');</script>", false);
            }
            else
            {
                //创建工作流
                this.lblnumbers.Text = Numbers(); //动态生成编号
                EtNet_Models.JobFlow jobmodel = new EtNet_Models.JobFlow();
                jobmodel.cname = this.lblnumbers.Text;
                jobmodel.attachment = (strfile[6] == "1" ? strfile[6] : "~/UploadFile/Job/defaultfile.txt");
                jobmodel.sort = "01"; //请假申请的编号
                jobmodel.auditsort = "";
                jobmodel.auditstatus = "01"; //未开始
                jobmodel.createtime = DateTime.Now; //默认是当前时间
                jobmodel.endtime = DateTime.Now;
                jobmodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id号
                jobmodel.savestatus = "草稿";
                jobmodel.txt = ""; //保留字段
                //未选审核规则字段值为“1”
                jobmodel.ruleid = (this.ddlapprovalrole.SelectedIndex == 0) ? 1 : int.Parse(this.ddlapprovalrole.SelectedValue);
                
               //EtNet_BLL.JobFlowManager.Add(jobmodel);
               //int maxid = EtNet_BLL.JobFlowManager.Maxid();

                int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(jobmodel);

                if (strfile[6] == "1")
                {
                    CreateJobFlowFile(strfile, maxid);
                }

                EtNet_Models.ApplyLeaveList model = new EtNet_Models.ApplyLeaveList();
                model.applydate = DateTime.Now;
                model.starttime = Convert.ToDateTime(this.iptstartdate.Value);
                model.endtime = Convert.ToDateTime(this.iptenddate.Value);
                model.jobflowid = maxid;
                model.leavepeopleid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id号
                model.sort = this.radsort.SelectedValue; //请假类型
                model.remark = Server.UrlDecode(this.iptremark.Value);  //请假的详细情况
                model.txt = ""; //审批人员填写的字段

                if (EtNet_BLL.ApplyLeaveListManager.Add(model))
                {
                    Response.Redirect("ShowLeaveForm.aspx");
                }

            }
        }



        /// <summary>
        /// 申请
        /// </summary>
        private void SubmitInput()
        {
            string[] strfile = FileUp(Request.Files);
            if (strfile[0] != "")
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "jobflow", "<script>alert('提交申请失败原因:" + strfile[0] + "！');</script>", false);
            }
            else
            {
                //创建工作流
                this.lblnumbers.Text = Numbers(); //动态生成编号
                EtNet_Models.JobFlow jobmodel = new EtNet_Models.JobFlow();
                jobmodel.cname = this.lblnumbers.Text;
                jobmodel.attachment = (strfile[6] == "1" ? strfile[6] : "~/UploadFile/Job/defaultfile.txt");
                jobmodel.sort = "01";
                jobmodel.auditsort = "";
                jobmodel.auditstatus = "01";
                jobmodel.createtime = DateTime.Now; //默认是当前时间
                jobmodel.endtime = DateTime.Now;
                jobmodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id号
                jobmodel.savestatus = "已提交";
                jobmodel.txt = "";
                jobmodel.ruleid = int.Parse(this.ddlapprovalrole.SelectedValue);

                // EtNet_BLL.JobFlowManager.Add(jobmodel);
                // int maxid = EtNet_BLL.JobFlowManager.Maxid();

                int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(jobmodel);
                if (strfile[6] == "1")
                {
                    CreateJobFlowFile(strfile, maxid);
                }

                EtNet_Models.ApplyLeaveList model = new EtNet_Models.ApplyLeaveList();
                model.applydate = DateTime.Now;
                model.starttime = Convert.ToDateTime(this.iptstartdate.Value);
                model.endtime = Convert.ToDateTime(this.iptenddate.Value);
                model.jobflowid = maxid;
                model.leavepeopleid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id号
                model.sort = this.radsort.SelectedValue;
                model.remark = Server.UrlDecode(this.iptremark.Value);
                model.txt = ""; //审批人员填写的字段


                if (EtNet_BLL.ApplyLeaveListManager.Add(model))
                {
                    string stafflist = EtNet_BLL.ApprovalRuleManager.GetModel(int.Parse(this.ddlapprovalrole.SelectedValue)).idgourp.ToString();
                    CreateApproval(ddlauditsort.SelectedValue, stafflist, maxid);
                    SendInformation(maxid, stafflist.Split(','));

                    Response.Redirect("ShowLeaveForm.aspx");

                }
            }
        }






        /// <summary>
        /// 提交申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            SubmitInput();
        }


        /// <summary>
        /// 保存申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            SaveInput();
        }



        /// <summary>
        /// 重置清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
        {
            this.iptstartdate.Value = "";
            this.iptenddate.Value = "";
            this.iptremark.Value = "";
            this.ddlauditsort.SelectedIndex = 0;
            this.ddlapprovalrole.SelectedIndex = 0;
            this.auditpic.InnerHtml = "";
            this.radsort.SelectedIndex = 0;
        }


      




       

    }
}