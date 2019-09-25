using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using EtNet_BLL.DataPage;

namespace EtNet_Web.Pages.Information
{
    public partial class ReceiveInformationShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    QueryBuilder();
                    PageSymbolNum();
                    LoadInformationSortData();
                    LoadSendPeopleList();
                    LoadInformationNoticeData();             
                }
            }       
        }

       

        /// <summary>
        /// 页面数字标识
        /// </summary>
        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = ""; //如无PageNum，先生成一个
            }
            if (Session["PageNum"].ToString() != "006")
            {
                Session["PageNum"] = "006";
                Session["query"] = "";
            }
        }


        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
            }
        }


        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strsqldata = " ";
            string sendtime = " convert(varchar(10),sendtime,120) ";
            if (this.ddlsend.SelectedIndex != 0)
            {
                strsqldata += " AND  founderid=" + this.ddlsend.SelectedValue;
            }
            if (this.ddlsort.SelectedIndex != 0)
            {
                strsqldata += " AND  sortid=" + this.ddlsort.SelectedValue;
            }
            if (this.hidcdate.Value != "")
            {
                string[] list = this.hidcdate.Value.Split(','); 
                if(list[0] !="" && list[1] !="")
                {
                    strsqldata += " AND  ( " + sendtime + " >= '" + list[0] + "' AND  " + sendtime + " <= '" + list[1] + "')";
                } 
                else if (list[0] != "" && list[1] == "")
                {
                    strsqldata += " AND "+ sendtime+" >= '" + list[0] + "'";
                }
                else
                {
                    strsqldata += " AND " + sendtime +" <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.ddldate.SelectedValue)
                { 
                    case "1":
                        strsqldata += " AND " + sendtime + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "2":
                        strsqldata += " AND " + sendtime + " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "3":
                        strsqldata += " AND " + sendtime + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                        break;

                    case "4":
                        strsqldata += " AND ( " + sendtime + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        strsqldata += " AND " + sendtime + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "5":
                        strsqldata += " AND ( " + sendtime + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        strsqldata += " AND " + sendtime + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                }
            }

            Session["query"] = strsqldata;

        }



        /// <summary>
        /// 绑定消息的分类
        /// </summary>
        private void LoadInformationSortData()
        {
            DataTable tbl =  EtNet_BLL.InformationSortManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);

            this.ddlsort.DataSource = tbl;
            this.ddlsort.DataValueField = "id";
            this.ddlsort.DataTextField = "txt";
            this.ddlsort.DataBind();

        }


        /// <summary>
        ///绑定发送人的列表
        /// </summary>
        private void LoadSendPeopleList()
        {
            string filed = " founderid , cname";
            string str = " recipientid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;  
            DataTable tbl =  EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(filed,str);
            DataRow row = tbl.NewRow();
            row["founderid"] = 0;
            row["cname"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlsend.DataSource = tbl;
            this.ddlsend.DataTextField = "cname";
            this.ddlsend.DataValueField = "founderid";
            this.ddlsend.DataBind();
            
                        
        }



        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='006'";
            DataTable tbl =  EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "006";
                pageset.Pagecount = 5;
                pageset.Pageitem = 30;    
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }



        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadInformationNoticeData()
        {
            DataTable strtbl = Exists();
            string strfixed = " AND recipientid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
                   strfixed  += " AND sendtime <= '" + DateTime.Now.ToString() + "'";

            string str = Session["query"].ToString();

            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());

            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet tbl = data.DataPage("ViewInformationNotice", "id", "*", strfixed + str, "id", true, pitem, pcount, pages);
            this.rptinformation.DataSource = tbl;
            this.rptinformation.DataBind();
      
        }



        /// <summary>
        /// 是否打开筛选栏
        /// </summary>
        private void SiftIsOpen()
        {
            DataTable tbl = Exists();
            if (tbl.Rows[0]["siftfence"].ToString() == "1")
            {
                this.hidsift.Value = "1";
            }
            else
            {
                this.hidsift.Value = "0";
            }

        }



   

        //新加消息
        protected void imgadd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddInformation.aspx");
        }


        /// <summary>
        ///取得消息的附件
        /// </summary>
        /// <param name="informationid">消息的id值</param>
        private void GetFiles(string informationid)
        {
            string strsql = " informationid=" + informationid;
            DataTable tbl = EtNet_BLL.InformationFileManager.GetList(strsql);
            string str ="";
            if (tbl.Rows.Count >= 1)
            {
                string strtable = "<table>";
                for (int i = 0; i < tbl.Rows.Count; i++ )
                {
                    strtable += "<tr><td style=\"width:50px; \">" + "附件" + (i + 1) + ":" + "</td>"; ;
                    strtable += "<td><a target=\"_blank\" href=\" InformationFiles.aspx?id=" + tbl.Rows[i]["id"].ToString() + "\">" + tbl.Rows[i]["filename"].ToString() + "</a></td></tr>";
                }
                strtable += "</table>";
                str += "<script> $(function () { $('<div>" + strtable + "</div>')";
                str += ".window({title: '附件列表',width:300, height:200, minimizable: false,maximizable: false,";
                str += "draggable:true,resizable:false, modal: true });})</script>";
            }
            else
            {
                str = "<script>alert('此消息无附件!')</script>";
            }
          

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(),"fs" + DateTime.Now.ToString(),str,false);
        
        }


        /// <summary>
        /// 依据消息的id值，查询是否具有附件
        /// </summary>
        public string clsfile(string informationid)
        {
            string strsql = " informationid=" + informationid;
            DataTable tbl =  EtNet_BLL.InformationFileManager.GetList(strsql);
            string cls = "";
            if (tbl.Rows.Count >= 1)
            {
                cls = "clsfileshow";
            }
            else
            {
                cls = "clsfilehide";
            }
            return cls;
        }

        /// <summary>
        /// 取消提醒
        /// </summary>
        /// <param name="id">消息通知id值</param>
        private void canelremind(int id)
        {
            EtNet_Models.InformationNotice model =  EtNet_BLL.InformationNoticeManager.GetModel(id);
            if (model != null)
            {
                model.remind = "否";
                if (EtNet_BLL.InformationNoticeManager.Update(model))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "remind", "<script>alert('提醒取消成功')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "remind", "<script>alert('提醒取消失败')</script>", false); 
                }
            }
        }



        protected void rptinformation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            { 

                case "reply":
                    Response.Redirect("ReplyInformation.aspx?id="+ e.CommandArgument.ToString().Trim());
                    break;

                case "remind":
                    canelremind(int.Parse(e.CommandArgument.ToString()));
                    LoadInformationNoticeData();
                    break;
                
                case "filelook":
                    string informationid = e.CommandArgument.ToString();//取得消息的id值
                    GetFiles(informationid);
                    break;

                case "del":
                   
                    int id = int.Parse(e.CommandArgument.ToString()); //通知消息的id值
                    EtNet_BLL.InformationNoticeManager.Delete(id);         
                    LoadInformationNoticeData();             
                    break;
                
            }

            
        }


        /// <summary>
        /// 链接到项目或公告
        /// </summary>
        /// <param name="associationid">项目或公告的id值</param>
        public string LinkItem(int sort,int associationid,int informationid)
        {
            string strlink = "";
            switch (sort)
            {
                case 7:
                    //EtNet_Models.ItemInfo info = EtNet_BLL.ItemInfoManager.GetModel(associationid);
                    //if(info !=null)
                    //{
                    //  strlink += "<span style='color:blue;padding-left:10px;'>";
                    //  strlink += " 转到该项目:<a  style='color:red;' href='../Items/EditItems.aspx?id=" + info.id;
                    //  strlink += "'>【" + info.cname + "】</a></span>";
                    //}
                    break;

                case 8:
                    EtNet_Models.AnnouncementInfo announcemrnt =  EtNet_BLL.AnnouncementInfoManager.GetModel(associationid);
                    if (announcemrnt != null)
                    {
                        strlink += "<span style='color:blue;padding-left:10px;'>";
                        strlink += " 转到该公告:<a class='clslink' style='color:red;' ";
                        // strlink += " id='noticeid" + informationid.ToString() + "' ";
                        if (announcemrnt.sortid == 1)
                        {
                            strlink += " href='../Announcement/AnnouncementReadFirm.aspx?id=" + announcemrnt.id;
                        }
                        else
                        {
                            strlink += " href='../Announcement/AnnouncementRead.aspx?id=" + announcemrnt.id;
                        }
                        strlink += "&infoid=" + informationid.ToString();
                        strlink += "'>【" + announcemrnt.title + "】</a></span>";
                    }
                    break;
            }
            return strlink;
        }


        /// <summary>
        /// 返回阅读状态
        /// </summary>
        /// <param name="remind">是否提醒</param>
        public string ReadStatus(string remind)
        {
            string result = "";
            if (remind.Trim() == "是")
            {
                result = "未阅读";
            }
            else
            {
                result = "已阅读";
            }
            return result;
        }



        //查询
        protected void ibtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            pages.Visible = true;
            ModifyQueryBuilder();
            LoadInformationNoticeData();
        }



        //重置
        protected void ibtnreset_Click(object sender, ImageClickEventArgs e)
        {
             pages.Visible = true;
             this.ddlsend.SelectedIndex = 0;
             this.ddlsort.SelectedIndex = 0;
             this.ddldate.SelectedIndex = 0;
             this.hidcdate.Value = "";
             Session["query"] = "";
             LoadInformationNoticeData();
        }


        //选中项删除
        protected void imgdel_Click(object sender, ImageClickEventArgs e)
        {
            CheckBox box = null;
            ImageButton imgbtn = null;
            int id = 0;
            int len = this.rptinformation.Controls.Count;
            for (int i = 0; i < len; i++)
            {
                box = this.rptinformation.Controls[i].Controls[1] as CheckBox;
                imgbtn = this.rptinformation.Controls[i].Controls[7] as ImageButton;    
                if (box != null && imgbtn != null)
                {
                    if (box.Checked && imgbtn.CommandArgument != "")
                    {
                       id = int.Parse(imgbtn.CommandArgument.ToString());
                       EtNet_BLL.InformationNoticeManager.Delete(id);            
                    }
                }
            }
            LoadInformationNoticeData();
        }



        //取消提醒，阅读状态改为已阅读
        protected void imgread_Click(object sender, ImageClickEventArgs e)
        {

            CheckBox box = null;
            ImageButton imgbtn = null;
            EtNet_Models.InformationNotice model = null;
            int id = 0;
            int len = this.rptinformation.Controls.Count;
            for (int i = 0; i < len; i++)
            {
                box = this.rptinformation.Controls[i].Controls[1] as CheckBox;
                imgbtn = this.rptinformation.Controls[i].Controls[7] as ImageButton;

                if (box != null && imgbtn != null)
                {
                    if (box.Checked && imgbtn.CommandArgument != "")
                    {
                        id = int.Parse(imgbtn.CommandArgument.ToString());
                        model =  EtNet_BLL.InformationNoticeManager.GetModel(id);
                        if (model != null)
                        {
                            model.remind = "否";
                            EtNet_BLL.InformationNoticeManager.Update(model);
                        }
                    }

                }
            }
            LoadInformationNoticeData();

        }




    }
}