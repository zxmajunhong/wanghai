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
    public partial class AnnouncementShowFirm : System.Web.UI.Page
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
                LoadAuditStatus();
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
            if (Session["PageNum"].ToString() != "004")
            {
                Session["PageNum"] = "004";
                Session["query"] = " AND  auditstatus in('01','02','03','04') ";
            }
        }


        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                //Session["query"] = "";
                Session["query"] = " AND  auditstatus in('01','02','03','04') ";
            }
        }


        /// <summary>
        /// 加载审批状态
        /// </summary>
        private void LoadAuditStatus()
        {
            DataTable tbl = EtNet_BLL.JobAuditStatusManager.GetList("");
            DataRow row = tbl.NewRow();
            row["num"] = "00";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);

            row = tbl.NewRow();
            row["num"] = "-1";
            row["txt"] = "全部状态";
            tbl.Rows.InsertAt(row, 1);

            this.ddlauditstatus.DataSource = tbl;
            this.ddlauditstatus.DataTextField = "txt";
            this.ddlauditstatus.DataValueField = "num";
            this.ddlauditstatus.DataBind();

        }





        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='004'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "004";
                pageset.Pagecount = 5;
                pageset.Pageitem = 10;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }


        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strsql = " ";
            string strdate = " convert(varchar(10),createtime,120) ";
            if (this.ipttitle.Value.Trim() != "")
            {
                strsql += "AND  title like '%" + this.ipttitle.Value.Trim() + "%' ";
            }
            if (this.iptword.Value.Trim() != "")
            {
                strsql += "AND  themeword like '%" + this.iptword.Value.Trim() + "%' ";
            }
            if (this.ddlvisible.SelectedIndex != 0)
            {
                strsql += "AND  visiblecode=" + this.ddlvisible.SelectedValue;
            }
            if (this.ddlsavestatus.SelectedIndex != 0)
            {
                strsql += " AND  savestatus='" + this.ddlsavestatus.SelectedValue + "'";
            }
            if (this.ddlauditstatus.SelectedIndex != 0)
            {
                if (this.ddlauditstatus.SelectedIndex == 1)
                {
                    strsql += " AND  auditstatus in('01','02','03','04') ";
                }
                else
                {
                    strsql += " AND  auditstatus='" + this.ddlauditstatus.SelectedValue + "'";
                }
            }
            else
            {
                strsql += " AND  auditstatus in('01','02','03','04') ";
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


        public string ShowColor(string str)
        {
            string result = "";
            switch (str)
            {
                case "未开始":
                case "被拒绝":
                    result = "<span style='color:Red'>" + str + "</span>";
                    break;

                case "已通过":
                    result = "<span style='color:Green'>" + str + "</span>";
                    break;
                default:
                    result = str;
                    break;
            }
            return result;
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
            result += DateTime.Parse(edate).ToString("yyyy-MM-dd") + " ";
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
            strsql += " AND sortcode=1";
            strsql += Session["query"].ToString();
            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new Data();
            DataSet tbl = data.DataPage("ViewAnnouncementInfo", "id", "*", strsql, "id", true, pitem, pcount, pages);
            this.rptdata.DataSource = tbl;
            this.rptdata.DataBind();
        }




        /// <summary>
        /// 删除公告以及包含的附件
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void DelAnnouncement(int id)
        {
            string str ="";
            string login = ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            string strsql = " id=" + id;
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", strsql);

            if (tbl.Rows.Count == 0)
            {
                str = "<script>alert('删除失败,公告已删除')</script>";       
            }
            else if(tbl.Rows[0]["auditstatus"].ToString() != "01")
            {
              str = "<script>alert('删除失败,审核员已审核')</script>";         
            }
            else if(tbl.Rows[0]["creatercode"].ToString() != login)
            {
               str = "<script>alert('删除失败,无此权限')</script>";
            }
            else
            {
                int jfid = int.Parse(tbl.Rows[0]["jobflowcode"].ToString());        
                string strdel = " jobflowid = " + jfid;
                EtNet_BLL.AuditJobFlowManager.Delete(strdel);
                EtNet_BLL.JobFlowManager.Delete(jfid);  //删除工作流

                string strannouncement = " announcementid=" + id.ToString();

                DataTable tblfile = EtNet_BLL.AnnouncementFilesManager.GetList(strsql);
                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    File.Delete(Server.MapPath(tblfile.Rows[i]["path"].ToString()));
                    EtNet_BLL.AnnouncementFilesManager.Delete(int.Parse(tblfile.Rows[i]["id"].ToString()));
                }
                EtNet_BLL.AnnouncementLogManager.Del(strannouncement);
                EtNet_BLL.AnnouncementInfoManager.Delete(id);
           
                str = "<script>alert('删除成功')</script>";
            }       
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", str, false);
        
        }



        /// <summary>
        /// 编辑修改公告
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void ModifyAnnouncement(int id)
        {           
            string str = "";
            string login = ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            string strsql = " id=" + id;
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", strsql);

            if (tbl.Rows.Count == 0)
            {
                str = "<script>alert('编辑失败,该公告已删除')</script>";              
            }
            else if (tbl.Rows[0]["savestatus"].ToString() != "草稿")
            {
                str = "<script>alert('编辑失败,只有草稿状态才能编辑')</script>";               
            }
            else if (tbl.Rows[0]["creatercode"].ToString() != login)
            {
                str = "<script>alert('编辑失败,无此权限')</script>";              
            }
            else
            {
                Response.Redirect("AnnouncementModifyFirm.aspx?id="+ id);  
            }


            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", str, false);
        }



        /// <summary>
        /// 查看公告详情
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void DetialAnnouncement(int id)
        {
            string str = "";
            string strsql = " id=" + id;
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", strsql);
            if (tbl.Rows.Count == 0)
            {
                str = "<script>alert('查看失败,该公告已删除')</script>";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", str, false);
            }
            else
            {
                Response.Redirect("AnnouncementDetialFirm.aspx?id=" + id + "&sqsh=sq");
            }       
        }



        /// <summary>
        /// 回收公告
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void RefreshAnnouncement(int id)
        {
            string str = "";   
            string strsql = " id=" + id;
                   strsql += " AND auditstatus in('01','03') ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAnnouncementInfoManager.getList("", strsql);       
            if (tbl.Rows.Count == 0)
            {
                str = "<script>alert('回收失败,只有状态是未开始或被拒绝的公告才能回收')</script>";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "refresh", str, false);
            }
            else
            {
                int jfid = int.Parse(tbl.Rows[0]["jobflowcode"].ToString());
                string strdel = " jobflowid = " + jfid;
                EtNet_BLL.AuditJobFlowManager.Delete(strdel);

                EtNet_Models.JobFlow jfmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
                jfmodel.auditstatus = "01";
                jfmodel.savestatus = "草稿";
                EtNet_BLL.JobFlowManager.Update(jfmodel);

                EtNet_Models.AnnouncementInfo model = EtNet_BLL.AnnouncementInfoManager.GetModel(id);
                model.opiniontxt = "";
                EtNet_BLL.AnnouncementInfoManager.Update(model);
                str = "<script>alert('回收成功')</script>";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "refresh", str, false);
                          
            }
        }




        /// <summary>
        /// 隐藏公告
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void VisibleAnnouncement(int id)
        {
            string str = "";
            EtNet_Models.AnnouncementInfo model = EtNet_BLL.AnnouncementInfoManager.GetModel(id);
           
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
          
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "publish", "<script>alert('" + str + "')</script>", false);
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
        /// 公告送审
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void SendAuditAnnouncement(int id)
        {
            EtNet_Models.AnnouncementInfo model = EtNet_BLL.AnnouncementInfoManager.GetModel(id);
            if (model != null)
            {
                EtNet_Models.JobFlow jfmodel = EtNet_BLL.JobFlowManager.GetModel(model.jobflowid);
                if (jfmodel.savestatus == "已提交")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('已经送审')</script>", false);
                }
                else
                {
                    jfmodel.createtime = DateTime.Now; //默认是当前时间
                    jfmodel.endtime = DateTime.Now;
                    jfmodel.savestatus = "已提交";
                    EtNet_BLL.JobFlowManager.Update(jfmodel);
                    CreateApproval(jfmodel.ruleid, jfmodel.id);
                    SendInformation(jfmodel.id, jfmodel.ruleid);

                    model.createtime = DateTime.Now;
                    model.filetime = DateTime.Now;
                    model.printtime = DateTime.Now;
                    model.yearnow = DateTime.Now.Year.ToString();
                    EtNet_BLL.AnnouncementInfoManager.Update(model);

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审成功')</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审失败')</script>", false);
            }
        }





        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    ModifyAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

                case "del":
                    DelAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

                case "detial":
                    DetialAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

                case "refresh":
                    RefreshAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

                case "hdata":
                    VisibleAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

                case "audit":
                    SendAuditAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;
            }

            LoadAnnouncementList();
        }


        /// <summary>
        /// 查询
        /// </summary>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadAnnouncementList();
        }



        /// <summary>
        /// 重置
        /// </summary>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
             this.ipttitle.Value = "";
             this.iptword.Value = "";
             this.hidcdate.Value = "";
             this.ddlauditstatus.SelectedIndex = 0;
             this.ddldate.SelectedIndex = 0;
             this.ddlsavestatus.SelectedIndex = 0;
             this.ddlvisible.SelectedIndex = 0;         
             ModifyQueryBuilder();
             Session["query"] = " AND  auditstatus in('01','02','03','04') ";
             LoadAnnouncementList();
        }


    }
}