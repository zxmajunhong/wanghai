using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL.DataPage;
using System.IO;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();          
                LoadAnnouncementStatus();             
                LoadAnnouncementList();
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
            if (Session["PageNum"].ToString() != "005")
            {
                Session["PageNum"] = "005";
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
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='005'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "005";
                pageset.Pagecount = 2;
                pageset.Pageitem = 5;     
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }




        /// <summary>
        /// 加载公告的状态
        /// </summary>
        private void LoadAnnouncementStatus()
        {
            DataTable tbl =   EtNet_BLL.AnnouncementStatusManager.GetList("");
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
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strsql = "";
            string strdate = " convert(varchar(10),createtime,120) ";
            if (this.ipttitle.Value.Trim() != "")
            {
                strsql += "AND  title like '%" + this.ipttitle.Value.Trim() + "%' ";
            }
            if (this.ddlstatus.SelectedIndex!= 0)
            {
                strsql += "AND  statuscode =" + this.ddlstatus.SelectedValue;
            }
            if (this.ddlvisible.SelectedIndex != 0)
            {
                strsql += "AND  visiblecode=" + this.ddlvisible.SelectedValue;
            }    
            if (this.hidcdate.Value != "")
            {
                string[] list = this.hidcdate.Value.Split(',');
                if (list[0] != "" && list[1] != "")
                {
                    strsql += " AND  ( " + strdate + " >= '" + list[0] + "' AND  " + strdate + " <= '" + list[1] + "')";
                }
                else if (list[0] != "" && list[1] == "")
                {
                    strsql += " AND " + strdate + " >= '" + list[0] + "'";
                }
                else
                {
                    strsql += " AND " + strdate + " <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.ddldate.SelectedValue)
                {
                    case "1":
                        strsql += " AND " + strdate + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "2":
                        strsql += " AND " + strdate + " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "3":
                        strsql += " AND " + strdate + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                        break;

                    case "4":
                        strsql += " AND ( " + strdate + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        strsql += " AND " + strdate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "5":
                        strsql += " AND ( " + strdate + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        strsql += " AND " + strdate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;
                }
            }

            Session["query"] = strsql;
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
            result += DateTime.Parse(edate).ToString("yyyy-MM-dd")+ " ";
            result += "&nbsp;&nbsp;有效天数为:" + period + "天";
            return result;
        }



        /// <summary>
        /// 加载公告数据
        /// </summary>
        private void LoadAnnouncementList()
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            this.pages.Visible = true;
            DataTable strtbl = Exists();
            string strsql = " AND creatercode=" + login.Id;
            strsql += " AND sortcode=2 ";
            strsql += Session["query"].ToString();
            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new Data();
            DataSet tbl = data.DataPage("ViewAnnouncementInfo", "id", "*", strsql, "id", true, pitem, pcount, pages);
            this.rptdata.DataSource = tbl;
            this.rptdata.DataBind();
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
        /// <param name="id">公告的id值</param>
        /// <param name="sort">公告的分类</param>
        /// <param name="title">公告的标题</param>
        /// <param name="departlist">部门列表</param>
        private void SendInformation(int id, int sort, string title, string departlist)
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
                tbl =  EtNet_BLL.LoginInfoManager.getList(strsql);
            }

            EtNet_Models.Information model = new EtNet_Models.Information();
            model.associationid = id;
            model.contents = "你有一个新公告可以查看,该公告的名称为:'" + title + "'";
            model.createtime = DateTime.Now;
            model.sendtime = model.createtime;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.sortid = 8;
            EtNet_BLL.InformationManager.Add(model);
            int maxid =  EtNet_BLL.InformationManager.GetMaxId();
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
        /// 删除公告以及包含的附件
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void DelAnnouncement(int id)
        {
            string strsql = " announcementid=" + id.ToString();
            DataTable tbl = EtNet_BLL.AnnouncementFilesManager.GetList(strsql);
            for (int i = 0; i < tbl.Rows.Count; i++ )
            {
                File.Delete(Server.MapPath(tbl.Rows[i]["path"].ToString()));
                EtNet_BLL.AnnouncementFilesManager.Delete(int.Parse(tbl.Rows[i]["id"].ToString()));
            }
            EtNet_BLL.AnnouncementLogManager.Del(strsql);
            if (EtNet_BLL.AnnouncementInfoManager.Delete(id))
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('删除成功')</script>", false);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('删除失败')</script>", false);
            }
        }



        /// <summary>
        /// 发布公告
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void PublishAnnouncement(int id)
        {
            string str = "";
            EtNet_Models.AnnouncementInfo model =  EtNet_BLL.AnnouncementInfoManager.GetModel(id);
            if(model.statusid == 2)
            {
                str = "该公告已发布";
            }
            else
            {
               model.createtime = DateTime.Now;
               model.statusid = 2;
               if (EtNet_BLL.AnnouncementInfoManager.Update(model))
               {
                   str = "发布成功";
                   OperationRecord(model.id);
                   SendInformation(model.id, model.sortid, model.title, model.departlist);
               }
               else
               {
                   str = "发布失败";
               }
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "publish", "<script>alert('"+str+"')</script>", false);
        }

        /// <summary>
        /// 隐藏公告
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void VisibleAnnouncement(int id)
        {
            string str = "";
            EtNet_Models.AnnouncementInfo model =  EtNet_BLL.AnnouncementInfoManager.GetModel(id);
            if (model.statusid == 1)
            {
                str = "草稿无需隐藏或显示";
            }
            else
            {
                if (model.visiblecode == 0)
                {
                    model.visiblecode = 1;
                    model.visibletxt = "可见";
                    str = "显示成功";
                }
                else
                {
                    model.visiblecode = 0;
                    model.visibletxt = "不可见";
                    str = "隐藏成功";
                }
              
                if (!EtNet_BLL.AnnouncementInfoManager.Update(model))
                {
                    str = "隐藏或修改失败";
                }
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "publish", "<script>alert('" + str + "')</script>", false);
        }
       

        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            { 
                case "edit":
                    Response.Redirect("AnnouncementModify.aspx?id=" + e.CommandArgument.ToString());
                    break;

                case "hdata":
                    VisibleAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

                case "publish":
                    PublishAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

                case "del":
                    DelAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;
            }
            LoadAnnouncementList();
        }


        //查询
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadAnnouncementList();
        }


        //重置
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {     
            this.ddlstatus.SelectedIndex = 0;
            this.ipttitle.Value = "";
            this.hidcdate.Value = "";  
            this.ddldate.SelectedIndex = 0;        
            this.ddlvisible.SelectedIndex = 0;     
            Session["query"] = "";
            LoadAnnouncementList();
        }



    }
}