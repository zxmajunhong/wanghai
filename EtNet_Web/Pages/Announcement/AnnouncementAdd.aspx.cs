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
    public partial class AnnouncementAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAnnouncementStatus();
                LoadInitialTerm();
            }
        }


        /// <summary>
        /// 加载公告的状态
        /// </summary>
        private void LoadAnnouncementStatus()
        {
            DataTable tbl = EtNet_BLL.AnnouncementStatusManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = "-1";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlstatus.DataSource = tbl;
            this.ddlstatus.DataValueField = "id";
            this.ddlstatus.DataTextField = "txt";
            this.ddlstatus.DataBind();

        }

   
        /// <summary>
        /// 加载初始项
        /// </summary>
        private void LoadInitialTerm()
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            this.lblcreater.Text = login.Cname;
            this.lbldatetime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.iptstart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            this.iptperiod.Value = "1";
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
                    if (postfile.ContentLength <= (1024 * 1024 * 10))
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

        ///<summary>
        ///发送消息
        ///</summary>
        ///<param name="id">公告id值</param>
        ///<param name="sort">公告的分类</param>
        ///<param name="title">公告的标题</param>
        ///<param name="departlist">部门列表</param>
        private void SendInformation(int id, int sort,string title, string departlist)
        {      
            string strsql = "";
            DataTable tbl = null;
            if (sort == 1)
            {
               //公司公告
                tbl = EtNet_BLL.LoginInfoManager.getList("");
            }
            else
            {
               strsql = " departid in(select departid from DepartmentInfo where departid in("+ departlist+"))";
               tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            }

            EtNet_Models.Information model = new EtNet_Models.Information();
            model.associationid = id;
            model.contents = "你有一个新公告可以查看,该公告的名称为:'" + title +"'";
            model.createtime = DateTime.Now;
            model.sendtime = model.createtime;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.sortid = 8;
            EtNet_BLL.InformationManager.Add(model);
            int maxid =  EtNet_BLL.InformationManager.GetMaxId();
            EtNet_Models.InformationNotice noticemodel = null;
            for (int i = 0; i < tbl.Rows.Count; i++ )
            {
                noticemodel = new EtNet_Models.InformationNotice();
                noticemodel.informationid = maxid;
                noticemodel.recipientid = int.Parse(tbl.Rows[i]["id"].ToString());
                noticemodel.remind = "是"; //判断公告是否查看标记
                EtNet_BLL.InformationNoticeManager.Add(noticemodel);
            }
        }







        /// <summary>
        /// 保存
        /// </summary>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = FileUp(Request.Files);

            if (str[0] != "")
            {
                string strerror = "<script> alert('" + str[0] + "');</script>";
                this.hidtxt.Value = "";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "fileup", strerror, false);
            }
            else
            {
                EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
                EtNet_Models.AnnouncementInfo model = new EtNet_Models.AnnouncementInfo();
                model.createrid = login.Id;
                model.createtime = DateTime.Now;
                model.departlist = this.hiddepartlist.Value;
                model.departtxtlist = this.iptdepartlist.Value;
                model.starttime = Convert.ToDateTime(this.iptstart.Value);
                model.period = int.Parse(this.iptperiod.Value);
                model.endtime = model.starttime.AddDays(model.period);
                model.peoplelist = "";
                model.sortid = 2;
                model.statusid = int.Parse(this.ddlstatus.SelectedValue);
                model.title = this.ipttitle.Value;
                model.visiblecode = 1;
                model.visibletxt = "可见";
                model.txt = Server.UrlDecode(this.hidtxt.Value);
                model.opiniontxt = "";
                model.carboncopy = "";
                model.carboncopytxt = "";
                model.checkpid = login.Id;
                model.filenum = "";
                model.filetime = DateTime.Now;
                model.firmid = 0;
                model.imgid = 0;
                model.jobflowid = 0;
                model.signpid = login.Id;
                model.themeword = "";
                model.yearnow = "";
                model.printtime = DateTime.Now;
                int id =  EtNet_BLL.AnnouncementInfoManager.Add(model);
                CreateFile(str, id);
                if (model.statusid == 2)
                {
                    OperationRecord(id);
                    SendInformation(id,model.sortid, model.title, model.departlist);
                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('新增成功');window.location='AnnouncementShow.aspx'</script>", false);
            }
            
        }


        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AnnouncementShow.aspx");
        }






    }
}