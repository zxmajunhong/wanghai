using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementRead : System.Web.UI.Page
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


        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AnnouncementSearch.aspx");
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
            string list = "," + model.Departid + ",";

            string visiblecode = ctbk.Rows[0]["visiblecode"].ToString(); //公告的可见性
            string statuscode = ctbk.Rows[0]["statuscode"].ToString(); //公告状态
            string sortcode = ctbk.Rows[0]["sortcode"].ToString(); //公告分类
            string departlist = "," + ctbk.Rows[0]["departlist"].ToString() + ","; //部门列表

            if (visiblecode == "0") //公告不可见
            {
                result = false;
            }
            else if (statuscode == "1") //公告为草稿
            {
                result = false;
            }
            else if (sortcode == "2" && departlist.IndexOf(list) == -1)
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
        /// 加载原有的公告数据
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
                this.hidid.Value = Request.Params["id"];
                this.lbltitle.Text = tbl.Rows[0]["title"].ToString();
                this.lblsort.Text =  tbl.Rows[0]["sorttxt"].ToString();
                this.lbltxt.InnerHtml= tbl.Rows[0]["txt"].ToString();
                this.lblcreater.Text = tbl.Rows[0]["creatertxt"].ToString();
                this.lbldate.Text = DateTime.Parse(tbl.Rows[0]["createtime"].ToString()).ToString("yyyy-MM-dd");
                this.lblperiodtxt.InnerHtml = ShowValidPeriod(tbl.Rows[0]["starttime"].ToString(), tbl.Rows[0]["endtime"].ToString(), tbl.Rows[0]["period"].ToString());
                this.lblpast.InnerText = PastPeriod(tbl.Rows[0]["endtime"].ToString());
                LoadFile();
                OperationRecord(int.Parse(Request.Params["id"]));
            }

        }


        /// <summary>
        /// 显示有效时间
        /// </summary>
        /// <param name="sdate">开始时间</param>
        /// <param name="edate">结束时间</param>
        /// <param name="period">天数</param>
        public string ShowValidPeriod(string sdate, string edate, string period)
        {
            string result = "";
            result = "公告的有效期限为:";
            result += DateTime.Parse(sdate).ToString("yyyy-MM-dd") + "至";
            result += DateTime.Parse(edate).ToString("yyyy-MM-dd");
            result += "&nbsp;&nbsp;有效天数为:" + period + "天";
            return result;
        }

        /// <summary>
        /// 验证公告是否过期
        /// </summary>
        /// <param name="edate">公告的结束时间</param>
        public string PastPeriod(string edate)
        {
            string result = "";
            int count = DateTime.Now.CompareTo(DateTime.Parse(edate));
            if (count > 1)
            {
                result = "公告已过期";
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
            model.founderid = (( EtNet_Models.LoginInfo)Session["login"]).Id;
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
        /// 加载原有附件的列表
        /// </summary>
        private void LoadFile()
        {

            string strfile = " announcementid=" + Request.QueryString["id"].ToString();
            DataTable tblfile =  EtNet_BLL.AnnouncementFilesManager.GetList(strfile);
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




    }
}