using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementSearch : System.Web.UI.Page
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
                // SiftIsOpen();
                LoadAnnouncementSort();
                LoadLoginData();
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
            if (Session["PageNum"].ToString() != "001")
            {
                Session["PageNum"] = "001";
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
            strsql += " AND pagenum='001'";
            DataTable tbl =  EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "001";
                pageset.Pagecount = 5;
                pageset.Pageitem = 15;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }


        /// <summary>
        /// 是否打开筛选栏
        /// </summary>
        //private void SiftIsOpen()
        //{
        //    DataTable tbl = Exists();
        //    if (tbl.Rows[0]["siftfence"].ToString() == "1")
        //    {
        //        this.hidsift.Value = "1";
        //    }
        //    else
        //    {
        //        this.hidsift.Value = "0";
        //    }

        //}


      
        /// <summary>
        /// 加载公告的分类
        /// </summary>
        private void LoadAnnouncementSort()
        {
            DataTable tbl =  EtNet_BLL.AnnouncementSortManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = "-1";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlsort.DataSource = tbl;
            this.ddlsort.DataValueField = "id";
            this.ddlsort.DataTextField = "txt";
            this.ddlsort.DataBind();

        }


        /// <summary>
        /// 加载人员数据
        /// </summary>
        private void LoadLoginData()
        {
            IList<EtNet_Models.LoginInfo> list = EtNet_BLL.LoginInfoManager.getLoginInfoAll();
           
            this.ddlpeople.DataSource = list;
            this.ddlpeople.DataValueField = "id";
            this.ddlpeople.DataTextField = "cname";
            this.ddlpeople.DataBind();
            ListItem item = new ListItem("——请选中——", "-1");
            this.ddlpeople.Items.Insert(0, item);
        }


        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strsql = " ";
            string createtime = " convert(varchar(10),createtime,120) ";
            if (this.ipttitle.Value.Trim() != "")
            {
                strsql += "AND  title like '%" + this.ipttitle.Value.Trim() + "%' ";
            }
            if (this.ddlsort.SelectedIndex != 0)
            {
                strsql += "AND  sortcode =" + this.ddlsort.SelectedValue + " ";
            }
            if (this.ddlpeople.SelectedIndex != 0)
            {
                strsql += " AND creatercode=" + this.ddlpeople.SelectedValue;
            }
            if (this.hidcdate.Value != "")
            {
                string[] list = this.hidcdate.Value.Split(',');
                if (list[0] != "" && list[1] != "")
                {
                    strsql += " AND  ( " + createtime + " >= '" + list[0] + "' AND  " + createtime + " <= '" + list[1] + "')";
                }
                else if (list[0] != "" && list[1] == "")
                {
                    strsql += " AND " + createtime + " >= '" + list[0] + "'";
                }
                else
                {
                    strsql += " AND " + createtime + " <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.ddldate.SelectedValue)
                {
                    case "1":
                        strsql += " AND " + createtime + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "2":
                        strsql += " AND ( " + createtime + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        strsql += " AND " + createtime + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "3":
                        strsql += " AND ( " + createtime + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        strsql += " AND " + createtime + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
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
            result += DateTime.Parse(edate).ToString("yyyy-MM-dd") + " ";
            result += "&nbsp;&nbsp;有效天数为:" + period + "天";
            return result;
        }




        /// <summary>
        /// 加载公告数据
        /// </summary>
        private void LoadAnnouncementList()
        {        
            this.pages.Visible = true;
            DataTable strtbl = Exists();
            EtNet_Models.LoginInfo model = (EtNet_Models.LoginInfo)Session["login"];
            string strsql = "AND visiblecode=1 AND statuscode=2 ";
            strsql += "AND (sortcode=1 OR (sortcode=2 AND ',' + departlist +','  like '%,"+model.Departid+",%' ))";
            strsql += Session["query"].ToString();
            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet tbl = data.DataPage("ViewAnnouncementInfo", "id", "*", strsql, "createtime", true, pitem, pcount, pages);
            this.rptdata.DataSource = tbl;
            this.rptdata.DataBind();
        }


        /// <summary>
        /// 阅读公告
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void ReadAnnouncementDetails(int id)
        {
            EtNet_Models.AnnouncementInfo model = EtNet_BLL.AnnouncementInfoManager.GetModel(id);
            if (model.sortid == 1)
            {
                Response.Redirect("AnnouncementReadFirm.aspx?id=" + id);           
            }
            else
            {
                Response.Redirect("AnnouncementRead.aspx?id=" + id);
            }
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
            this.ddlpeople.SelectedIndex = 0;
            this.ddlsort.SelectedIndex = 0;
            this.ipttitle.Value = "";
            Session["query"] = "";
            LoadAnnouncementList();
        }

        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            { 
                case "details":
                    int id = int.Parse(e.CommandArgument.ToString());
                    ReadAnnouncementDetails(id);
                    break;
            }
        }


    }
}