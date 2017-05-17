using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAnnouncementStatus();            
                LoadAnnouncementData();
                
            }
        }



        /// <summary>
        /// 加载公告的状态
        /// </summary>
        private void LoadAnnouncementStatus()
        {
            DataTable tbl =  EtNet_BLL.AnnouncementStatusManager.GetList("");
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
        /// 加载原有的公告数据
        /// </summary>
        private void LoadAnnouncementData()
        {
            int id = int.Parse(Request.Params["id"]);
            EtNet_Models.AnnouncementInfo model = EtNet_BLL.AnnouncementInfoManager.GetModel(id);
            if (model == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "laod", "<script>alert('加载失败');window.location='AnnouncementShow.aspx'</script>", false);
            }
            else
            {
                EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
                this.lblcreater.Text = login.Cname;
                this.hiddepartlist.Value = model.departlist;
                this.iptdepartlist.Value = model.departtxtlist;
                this.iptperiod.Value = model.period.ToString();
                this.ddlstatus.SelectedValue =  model.statusid.ToString();
                this.ipttitle.Value = model.title;
                this.hidtxt.Value =  model.txt;
                if (model.statusid == 1)
                {   
                    //草稿状态
                    lbldatetime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.iptstart.Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                   //发布状态
                   lbldatetime.Text =  model.createtime.ToString("yyyy-MM-dd");
                   this.iptstart.Value = model.starttime.ToString("yyyy-MM-dd");
                   this.ddlstatus.Enabled = false;
                }
                
                LoadFile();
            }
        }

        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        public void LoadFile()
        {
            string strfile = " announcementid=" + Request.QueryString["id"];
            DataTable tblfile = EtNet_BLL.AnnouncementFilesManager.GetList(strfile);
            HtmlTableRow filetr = null;
            HtmlTableCell filetd = null;

            for (int i = 0; i < tblfile.Rows.Count; i++)
            {
                filetr = new HtmlTableRow();

                filetd = new HtmlTableCell();
                filetd.InnerHtml = FileIcon(tblfile.Rows[i]["path"].ToString());
                filetd.Attributes.Add("style", "text-align:center");
                filetr.Controls.Add(filetd);

                filetd = new HtmlTableCell();
                filetd.InnerHtml = tblfile.Rows[i]["cname"].ToString();
                filetd.Attributes.Add("style", "text-align:center");
                filetr.Controls.Add(filetd);


                filetd = new HtmlTableCell();
                filetd.Attributes.Add("align", "center");
                filetd.InnerHtml = "<div title='删除' id='fd" + tblfile.Rows[i]["id"].ToString() + "' class='clsfiledel'>&nbsp;</div>";
                filetr.Controls.Add(filetd);
                this.originalfile.Controls.Add(filetr);
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
                    if (postfile.ContentLength <= (1024 * 1024 *10))
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
                    model.cname = filelist[i].Substring(filelist[i].LastIndexOf("|") + 1);
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
        /// <param name="sort">操作的分类值(1创建/2编辑/3查看/4隐藏/5显示)</param>
        private void OperationRecord(int id,int sort)
        {
            EtNet_Models.AnnouncementLog model = new EtNet_Models.AnnouncementLog();
            model.announcementid = id;
            model.createtime = DateTime.Now;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.ipaddress = Request.UserHostAddress;
            if (sort == 1)
            {
                model.operatecode = 1;
                model.operatetxt = "创建";
            }
            else
            {
                model.operatecode = 2;
                model.operatetxt = "编辑";
            }
            EtNet_BLL.AnnouncementLogManager.Add(model);

        }



        ///<summary>
        ///发送消息
        ///</summary>
        ///<param name="id">公告的id值</param>
        ///<param name="sort">公告的分类</param>
        ///<param name="title">公告的标题</param>
        ///<param name="departlist">部门列表</param>
        ///<param name="isnew">是否是新公告</param>
        private void SendInformation(int id,int sort,string title, string departlist,bool isnew)
        {
            string strsql = "";
            DataTable tbl = null;
            if (sort == 1)
            {
                //公司公告
                tbl =  EtNet_BLL.LoginInfoManager.getList("");
            }
            else
            {
                strsql = " departid in(select departid from DepartmentInfo where departid in(" + departlist + "))";
                tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            }

            EtNet_Models.Information model = new EtNet_Models.Information();
            model.associationid = id;
            model.createtime = DateTime.Now;
            model.sendtime = model.createtime;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.sortid = 8;
            if (isnew)
            {
                model.contents = "你有一个新公告可以查看,该公告的名称为:'" + title + "'";
            }
            else
            {
                model.contents = "公告的名称为:'" + title + "'已修改,请注意查看";
            }
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
        /// 返回
        /// </summary>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AnnouncementShow.aspx");
        }


        //保存修改
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
                int id = int.Parse(Request.Params["id"]);
                EtNet_Models.AnnouncementInfo model = EtNet_BLL.AnnouncementInfoManager.GetModel(id);
               
                model.createtime = DateTime.Parse(this.lbldatetime.Text);
                model.departlist = this.hiddepartlist.Value;
                model.departtxtlist = this.iptdepartlist.Value;
                model.starttime = Convert.ToDateTime(this.iptstart.Value);
                model.period = int.Parse(this.iptperiod.Value);
                model.endtime = model.starttime.AddDays(model.period);
                model.title = this.ipttitle.Value;
                model.txt = Server.UrlDecode(this.hidtxt.Value);
                if (model.statusid == 1)
                {
                    //原为草稿可进行修改,已发布无需修改
                    model.statusid = int.Parse(this.ddlstatus.SelectedValue);
                    if (model.statusid == 2)
                    {
                        OperationRecord(model.id, 1);
                        SendInformation(model.id, model.sortid, model.title, model.departlist, true);
                    }
                }
                else
                {
                    OperationRecord(model.id, 2);
                    SendInformation(model.id, model.sortid, model.title, model.departlist, false);
                }
                EtNet_BLL.AnnouncementInfoManager.Update(model);
                CreateFile(str, model.id);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改成功');window.location='AnnouncementShow.aspx'</script>", false);
            }
        }



    }
}