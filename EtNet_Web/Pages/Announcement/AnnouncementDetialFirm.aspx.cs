using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CommonlyUsed;
using System.IO;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementDetialFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAnnouncementData();
            }
        }

        /// <summary>
        /// 加载公告数据
        /// </summary>
        private void LoadAnnouncementData()
        {
            string strsql = " id=" + Request.QueryString["id"];
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
                string checkpid =  tbl.Rows[0]["checkpcode"].ToString(); //校对人员的id值
                string checkptxt = tbl.Rows[0]["checkptxt"].ToString();  //校对人员的名称
                string signpid = tbl.Rows[0]["signpcode"].ToString();    //签发人员的id值
                string signptxt = tbl.Rows[0]["signptxt"].ToString();    //签发人员的名称

                this.lblcheckp.InnerHtml = ShowPname(checkpid, jfid, checkptxt);
                this.lblsignp.InnerHtml = ShowPname(signpid, jfid, signptxt);
                this.optiniontxt.InnerHtml = ShowOpiniontxt(jfid);
  
                LoadNowAudit(jfid);
                LoadAuditImg(jfid);
                LoadFile();

            }

        }


        /// <summary>
        /// 按条件显示校对人员或签发人员的名称
        /// </summary>
        /// <param name="checkpid">校对人员或签发人员的id值</param>
        /// <param name="jfid">工作流id值</param>
        /// <param name="checkptxt">校对人员或签发人员的名称</param>
        /// <returns></returns>
        private string ShowPname(string pid,int jfid,string checkptxt)
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
        /// 审批意见
        /// </summary>
        /// <param name="jfid">工作流的id值</param>
        private string ShowOpiniontxt(int jfid)
        {
            string result = "";
            string strsql = " jobflowid=" + jfid.ToString();
            strsql += " AND nowreviewer='P'";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(strsql);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                result += "<span>" + tbl.Rows[i]["reviewername"] + "的审批意见:";
                result += tbl.Rows[i]["opiniontxt"] + "</span><span style='margin-left:10px;'>(审批时间:";
                result += DateTime.Parse(tbl.Rows[i]["audittime"].ToString()).ToString("yyyy-MM-dd hh:mm:ss") + ")</span><br/>";
            }
            return result;
        }




        /// <summary>
        /// 加载当前审批人员的情况
        /// </summary>
        private void LoadNowAudit(int jfid)
        {
            string strsql = " id=" + jfid.ToString();
            DataTable tbl = EtNet_BLL.JobFlowManager.GetList(strsql);
            string audit = tbl.Rows[0]["auditstatus"].ToString(); //审批状态
            string save = tbl.Rows[0]["savestatus"].ToString(); //保存状态
            if (audit == "01" && save == "草稿")
            {
                this.hidlist.Value = "-1"; //代表审批未开始
            }
            else if (audit == "02" || (audit == "01" && save == "已提交"))
            {
                strsql = "nowreviewer='T' AND jobflowid=" + jfid;
                tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList("reviewerid", strsql);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (this.hidlist.Value == "")
                    {
                        this.hidlist.Value = tbl.Rows[i]["reviewerid"].ToString();
                    }
                    else
                    {
                        this.hidlist.Value += "," + tbl.Rows[i]["reviewerid"].ToString();
                    }
                }
            }     
            else
            {           
                this.hidlist.Value = "0"; //代表审核结束
            }
        }



        //加载审核流程图
        public void LoadAuditImg(int jfid)
        {
            EtNet_Models.JobFlow jobflowmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
            EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(jobflowmodel.ruleid);
            if (model != null)
            {
                string strpath = Server.MapPath(model.rolepic);
                if (File.Exists(strpath))
                {
                    this.auditpic.InnerHtml = File.ReadAllText(strpath);
                }
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






        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            string sqsh = Request.QueryString["sqsh"];
            if (sqsh == "sq")
            {
                Response.Redirect("AnnouncementShowFirm.aspx");
            }
            else
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
}