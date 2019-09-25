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
    public partial class AnnouncementReadFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RemindInformationNotice();
                LoadAnnouncementData();
                IsEnable();
            }
           
        }


        /// <summary>
        /// 提醒修改
        /// </summary>
        private void RemindInformationNotice()
        {
            if (Request.QueryString["infoid"] != null)
            {
                int id = int.Parse(Request.QueryString["infoid"]);
                EtNet_Models.InformationNotice model = EtNet_BLL.InformationNoticeManager.GetModel(id);
                model.remind = "否";
                EtNet_BLL.InformationNoticeManager.Update(model);
            }
        }






        /// <summary>
        /// 检验公告是否可查看
        /// </summary>
        private bool TestAuthority(DataTable ctbk)
        {
            bool result = true;
            EtNet_Models.LoginInfo model = (EtNet_Models.LoginInfo)Session["login"];   
            string visiblecode = ctbk.Rows[0]["visiblecode"].ToString(); //公告的可见性
            string statuscode = ctbk.Rows[0]["statuscode"].ToString(); //公告状态   
         
            if (visiblecode == "0") //公告不可见
            {
                result = false;
            }
            else if (statuscode == "1") //公告为草稿
            {
                result = false;
            }       
            else
            {
                result = true; //公告可查看
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
            model.operatecode = 3;
            model.operatetxt = "查看";
            EtNet_BLL.AnnouncementLogManager.Add(model);
        }



        //检测历史记录按钮是否可用
        private void IsEnable()
        {
            string str = "  creatercode=" + ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            str += " AND id=" + Request.QueryString["id"];
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", str);
            if (tbl.Rows.Count == 0)
            {
                this.record.Visible = false;
            }
        }




        /// <summary>
        /// 加载公告数据
        /// </summary>
        private void LoadAnnouncementData()
        {          
            string strsql = " id=" + Request.Params["id"];
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("",strsql);
            if (tbl.Rows.Count != 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "laod", "<script>alert('加载失败');window.location='AnnouncementSearch.aspx'</script>", false);
            }
            else if (!TestAuthority(tbl))
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "laod", "<script>alert('无此权限');window.location='AnnouncementSearch.aspx'</script>", false);
            }
            else
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
                this.lblcheckp.InnerHtml = tbl.Rows[0]["checkptxt"].ToString();
                this.lblsignp.InnerHtml = tbl.Rows[0]["signptxt"].ToString();
                this.hidid.Value = Request.Params["id"];
                OperationRecord(int.Parse(Request.Params["id"]));
                LoadFile();
            }
        
        }




        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        private void LoadFile()
        {
            string strfile = " announcementid=" + Request.QueryString["id"].ToString();
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





        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AnnouncementSearch.aspx");
        }


    }
}