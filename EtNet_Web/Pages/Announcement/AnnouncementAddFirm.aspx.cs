using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementAddFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {              
                LoadRule();
                LoadFixedItem();
            }
        }



        /// <summary>
        /// 审核流规则
        /// </summary>
        private void LoadRule()
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            string fields = " id,(sort + '—' + cname  ) as rulename ";
            string strsql = " jobflowsort='04' AND  ',' + departidlist + ',' like '%," + login.Departid.ToString() + ",%' ";
            strsql += " AND sort='单审' ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewApprovalRuleManager.getList(fields, strsql);
            DataRow row = tbl.NewRow();
            row["id"] = "-1";
            row["rulename"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlrule.DataSource = tbl;
            this.ddlrule.DataValueField = "id";
            this.ddlrule.DataTextField = "rulename";
            this.ddlrule.DataBind();
        }



        /// <summary>
        /// 加载用户所属公司列表
        /// </summary>
        /// <param name="firmlist">公司的id值列表</param>
        private void LoadFirmList(string firmlist)
        {
            string strsql = "";
            DataTable tbl = null;
            if (firmlist != "")
            {
                strsql = " id in(" + firmlist + ") ";
                tbl = EtNet_BLL.FirmInfoManager.GetList(strsql);
            }
            else
            {
                tbl = EtNet_BLL.FirmInfoManager.GetList(strsql);
                tbl.Clear();
            }
            DataRow row = tbl.NewRow();
            row["id"] = "-1";
            row["cname"] = "——请选择——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlfirm.DataSource = tbl;
            this.ddlfirm.DataTextField = "cname";
            this.ddlfirm.DataValueField = "id";
            this.ddlfirm.DataBind();
            if (this.ddlfirm.Items.Count == 2)
            {
                this.ddlfirm.SelectedIndex = 1;
            }

        }


        /// <summary>
        /// 加载固定项
        /// </summary>
        private void LoadFixedItem()
        {
            EtNet_Models.LoginInfo model = (EtNet_Models.LoginInfo)Session["login"];     
            DateTime date = DateTime.Now;
            this.iptcreater.Value = model.Cname; 
            this.iptcreater.Disabled = true;
            this.iptprintime.Value = date.Year.ToString() + "年" + date.Month.ToString() + "月" + date.Day + "日";
            this.iptprintime.Disabled = true;
            this.iptstart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            this.iptperiod.Value = "1";
            LoadFirmList(model.Firmidlist);      
        }




        /// <summary>
        /// 检测审批规则是否有效
        /// </summary>
        /// <param name="ruleid">审批规则的id值</param>
        private bool TestRule(string ruleid, ref int checkpid, ref int signpid)
        {
            bool result = true;
            int id = int.Parse(ruleid);
            EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(id);
            if (rule == null)
            {
                result = false;
            }
            else
            {
                if (rule.idgourp.IndexOf(',') == -1)
                {
                    result = false;
                }
                else {
                    string[] list = rule.idgourp.Split(',');
                    if (rule.sort == "单审" && list.Length == 2)
                    {
                        checkpid = int.Parse(list[0]);
                        signpid = int.Parse(list[1]);                 
                    }
                    else
                    {
                        result = false;
                    }
                }      
            }
            if (!result)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "rule", "<script>alert('公司公告只能选两级单审')</script>", false);
            }
            return result;
        }



        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void OperationRecord(int id)
        {
            EtNet_Models.AnnouncementLog model = new EtNet_Models.AnnouncementLog();
            model.announcementid = id;
            model.createtime = DateTime.Now;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.ipaddress = Request.UserHostAddress;
            model.operatecode = 1;
            model.operatetxt = "创建";
            EtNet_BLL.AnnouncementLogManager.Add(model);

        }


        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendInformation(int jobflowid, int ruleid)
        {
            EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
            string[] list = rule.idgourp.Split(',');
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jobflowid);
            EtNet_Models.Information informodel = null;
            if (model != null)
            {
                informodel = new EtNet_Models.Information();
                informodel.sortid = 11;
                informodel.associationid = jobflowid;
                informodel.contents = "名称为" + model.cname + "的公司公告需要您审批!";
                informodel.createtime = DateTime.Now;
                informodel.sendtime = DateTime.Now;
                informodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                if (EtNet_BLL.InformationManager.Add(informodel))
                {
                    int maxid = EtNet_BLL.InformationManager.GetMaxId();
                    EtNet_Models.InformationNotice infnotic = null;

                    int len = (rule.sort == "单审") ? 1 : list.Length;

                    for (int j = 0; j < len; j++)
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



        /// <summary>
        /// 上传附件，返回上传文件的路径的集合
        /// </summary>
        private string[] FileUp(HttpFileCollection item)
        {
            string[] str = new string[7] { "", "", "", "", "", "", "0" };
            string fileload = ""; //文件的路径
            //str[6] = "0";0为没有文件，1为有上传文件
            int num = 1;
            string saveUrl = "~/UploadFile/Announcement/";
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
                        str[num] = saveUrl + newFile + "|" + postfile.ContentLength + "|" + orfilename;
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
        /// <param name="id">公告的id值</param>
        private void CreateFile(string[] filelist, int id)
        {
            EtNet_Models.AnnouncementFiles model = null;
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            for (int i = 1; i < 6; i++)
            {
                if (filelist[i] != "")
                {
                    model = new EtNet_Models.AnnouncementFiles();
                    model.path = filelist[i].Substring(0, filelist[i].IndexOf("|"));
                    model.uptime = DateTime.Now;
                    model.cname = filelist[i].Substring(filelist[i].LastIndexOf('|') + 1);
                    model.announcementid = id;
                    model.founderid = login.Id;
                    model.remark = "";
                    EtNet_BLL.AnnouncementFilesManager.Add(model);
                }
            }
        }





        /// <summary>
        /// 保存草稿
        /// </summary>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {

            string[] str = FileUp(Request.Files);
            if (str[0] != "")
            {
                string strerror = "<script> alert('" + str[0] + "');</script>";
                this.hidtxt.Value = Server.UrlDecode(this.hidtxt.Value);
                this.ddlrule.SelectedIndex = 0;
                this.iptimgseal.Value = "";
                this.hidimgseal.Value = "";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "fileup", strerror, false);
                return;
            }

            int checkpid = 0; //校对人的id值
            int signpid = 0;  //签发人的id值
            if (TestRule(this.ddlrule.SelectedValue, ref checkpid, ref signpid))
            {
                EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
                EtNet_Models.JobFlow jfmodel = new EtNet_Models.JobFlow();
                jfmodel.attachment = "";
                jfmodel.txt = "";
                jfmodel.cname = this.ipttitle.Value;
                jfmodel.sort = "04"; //公告管理申请
                jfmodel.auditsort = "";
                jfmodel.auditstatus = "01";
                jfmodel.createtime = DateTime.Now; //默认是当前时间
                jfmodel.endtime = DateTime.Now;
                jfmodel.founderid = login.Id; //登录人员的id     
                jfmodel.ruleid = int.Parse(this.ddlrule.SelectedValue);
                jfmodel.savestatus = "草稿";

                int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(jfmodel); //工作流的id值

                EtNet_Models.AnnouncementInfo model = new EtNet_Models.AnnouncementInfo();
                model.createrid = login.Id;
                model.createtime = DateTime.Now;
                model.departlist = ""; //查看部门的id值,部门公告时有效
                model.departtxtlist = ""; //部门公告时有效
                model.starttime = DateTime.Parse(this.iptstart.Value); 
                model.period = int.Parse(this.iptperiod.Value);
                model.endtime = model.starttime.AddDays(model.period);
                model.peoplelist = ""; //保留字段
                model.sortid = 1;
                model.statusid = 1;
                model.title = this.ipttitle.Value;
                model.visiblecode = 1;
                model.visibletxt = "可见";
                model.txt = Server.UrlDecode(this.hidtxt.Value);
                model.carboncopy = this.hidcarboncopy.Value;
                model.carboncopytxt = this.iptcarboncopy.Value;
                model.checkpid = checkpid;
                model.signpid = signpid;
                model.filenum = this.iptorder.Value;
                model.filetime = DateTime.Now;
                model.firmid = int.Parse(this.ddlfirm.SelectedValue);
                model.imgid = int.Parse(this.hidimgseal.Value);
                model.opiniontxt = "";
                model.printtime = DateTime.Now;
                model.themeword = this.iptword.Value;
                model.yearnow = DateTime.Now.Year.ToString();
                model.jobflowid = maxid;
                int id = EtNet_BLL.AnnouncementInfoManager.Add(model);
                CreateFile(str, id);
                OperationRecord(id);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ad", "<script> alert('保存成功'); window.location='AnnouncementShowFirm.aspx'</script>",false);
            }
            else
            {
               this.hidtxt.Value =  Server.UrlDecode(this.hidtxt.Value);
               this.ddlrule.SelectedIndex = 0;
               this.iptimgseal.Value = "";
               this.hidimgseal.Value = "";
            }
        }



        /// <summary>
        /// 送审
        /// </summary>
        protected void imgbtnaudit_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = FileUp(Request.Files);
            if (str[0] != "")
            {
                string strerror = "<script> alert('" + str[0] + "');</script>";
                this.hidtxt.Value = Server.UrlDecode(this.hidtxt.Value);
                this.ddlrule.SelectedIndex = 0;
                this.iptimgseal.Value = "";
                this.hidimgseal.Value = "";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "fileup", strerror, false);
                return;
            }

            int checkpid = 0; //校对人的id值
            int signpid = 0;  //签发人的id值
            if (TestRule(this.ddlrule.SelectedValue, ref checkpid, ref signpid))
            {
                EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
                EtNet_Models.JobFlow jfmodel = new EtNet_Models.JobFlow();
                jfmodel.attachment = "";
                jfmodel.txt = "";
                jfmodel.cname = this.ipttitle.Value;
                jfmodel.sort = "04"; //公告管理申请
                jfmodel.auditsort = "";
                jfmodel.auditstatus = "01";
                jfmodel.createtime = DateTime.Now; //默认是当前时间
                jfmodel.endtime = DateTime.Now;
                jfmodel.founderid = login.Id; //登录人员的id     
                jfmodel.ruleid = int.Parse(this.ddlrule.SelectedValue);
                jfmodel.savestatus = "已提交";
                int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(jfmodel); //工作流的id值
                CreateApproval(jfmodel.ruleid,maxid);
                SendInformation(maxid, jfmodel.ruleid);


                EtNet_Models.AnnouncementInfo model = new EtNet_Models.AnnouncementInfo();
                model.createrid = login.Id;
                model.createtime = DateTime.Now;
                model.departlist = ""; //查看部门的id值,部门公告时有效
                model.departtxtlist = ""; //部门公告时有效
                model.starttime = DateTime.Parse(this.iptstart.Value);
                model.period = int.Parse(this.iptperiod.Value);
                model.endtime = model.starttime.AddDays(model.period);
                model.peoplelist = ""; //保留字段
                model.sortid = 1;
                model.statusid = 1;
                model.title = this.ipttitle.Value;
                model.visiblecode = 1;
                model.visibletxt = "可见";
                model.txt = Server.UrlDecode(this.hidtxt.Value);
                model.carboncopy = this.hidcarboncopy.Value;
                model.carboncopytxt = this.iptcarboncopy.Value;
                model.checkpid = checkpid;
                model.signpid = signpid;
                model.filenum = this.iptorder.Value;
                model.filetime = DateTime.Now;
                model.firmid = int.Parse(this.ddlfirm.SelectedValue);
                model.imgid = int.Parse(this.hidimgseal.Value);
                model.opiniontxt = "";
                model.printtime = DateTime.Now;
                model.themeword = this.iptword.Value;
                model.yearnow = DateTime.Now.Year.ToString();
                model.jobflowid = maxid;
                int id = EtNet_BLL.AnnouncementInfoManager.Add(model);
                OperationRecord(id);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ad", "<script> alert('送审成功'); window.location='AnnouncementShowFirm.aspx'</script>", false);
            }
            else
            {
                this.hidtxt.Value = Server.UrlDecode(this.hidtxt.Value);
                this.ddlrule.SelectedIndex = 0;
                this.iptimgseal.Value = "";
                this.hidimgseal.Value = "";
            }
        }


        /// <summary>
        /// 返回
        /// </summary>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AnnouncementShowFirm.aspx");
        }



    }
}