using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.SysSet.SetInitialize
{
    public partial class InitializeSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInitializeData();
            }
        }


        /// <summary>
        /// 加载面板数据
        /// </summary>
        /// <param name="strlist">已选面板的id值</param>
        private void LoadPanel(string strlist)
        {
            this.hidpanellist.Value = strlist;
            string strsql = " id in (" + strlist + ")";
            DataTable tbl = EtNet_BLL.PanelMenuListManager.GetList(strsql);

            this.listright.DataSource = tbl;
            this.listright.DataTextField = "cname";
            this.listright.DataValueField = "id";
            this.listright.DataBind();

            strsql = " id not in (" + strlist + ")";
            tbl = EtNet_BLL.PanelMenuListManager.GetList(strsql);

            this.listleft.DataSource = tbl;
            this.listleft.DataTextField = "cname";
            this.listleft.DataValueField = "id";
            this.listleft.DataBind();


        }


        /// <summary>
        /// 加载可添加面板的数据
        /// </summary>
        /// <param name="strlist">已用于添加的面板的id值</param>
        private void LoadUserPanel(string strlist)
        {
            this.hidupanellist.Value = strlist;
            string strsql = " id in (" + strlist + ")";
            DataTable tbl = EtNet_BLL.PanelMenuListManager.GetList(strsql);

            this.listuright.DataSource = tbl;
            this.listuright.DataTextField = "cname";
            this.listuright.DataValueField = "id";
            this.listuright.DataBind();

            strsql = " id not in (" + strlist + ")";
            tbl = EtNet_BLL.PanelMenuListManager.GetList(strsql);

            this.listuleft.DataSource = tbl;
            this.listuleft.DataTextField = "cname";
            this.listuleft.DataValueField = "id";
            this.listuleft.DataBind();


        }




        /// <summary>
        /// 加载全局初始化参数设置
        /// </summary>
        private void LoadInitializeData()
        {
            DataTable tbl = EtNet_BLL.InitializeSetManager.GetList(1, "", "id");
            if (tbl.Rows.Count == 1)
            {
                this.hidval.Value = tbl.Rows[0]["id"].ToString();
                this.ddlpagecount.SelectedValue = tbl.Rows[0]["pagecount"].ToString();
                this.ddlpageitem.SelectedValue = tbl.Rows[0]["pageitem"].ToString();
                this.ddlnewinforemind.SelectedValue = tbl.Rows[0]["newinforemind"].ToString();
                this.iptinfocycle.Value = tbl.Rows[0]["infocycle"].ToString();
                this.ddlpanelcount.SelectedValue = tbl.Rows[0]["panelcount"].ToString();
                this.ddlpanelcols.SelectedValue = tbl.Rows[0]["panelcols"].ToString();
                LoadPanel(tbl.Rows[0]["panellist"].ToString());
                LoadUserPanel(tbl.Rows[0]["panellistall"].ToString());
            }
            else
            {
                this.imgbtnsave.Enabled = false;
            }
        }




        //保存参数配置
        private bool SaveInitializeSet()
        {
            int id = int.Parse(this.hidval.Value);
            EtNet_Models.InitializeSet model = EtNet_BLL.InitializeSetManager.GetModel(id);
            model.infocycle = int.Parse(this.iptinfocycle.Value);
            model.newinforemind = int.Parse(this.ddlnewinforemind.SelectedValue);
            model.pagecount = int.Parse(this.ddlpagecount.SelectedValue);
            model.pageitem = int.Parse(this.ddlpageitem.SelectedValue);
            model.panelcols = int.Parse(this.ddlpanelcols.SelectedValue);
            model.panelcount = this.ddlpanelcount.SelectedValue;
            model.panellist = this.hidpanellist.Value;
            model.panellistall = this.hidupanellist.Value;
            if (EtNet_BLL.InitializeSetManager.Update(model))
            {
                LoadInitializeData();
                return true;

            }
            else
            {
                return false;
            }
        }





        //保存
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            if (SaveInitializeSet())
            {

                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "up", "<script>alert('修改成功!')</script>", false);
            }
        }



        /// <summary>
        /// 修改数据列表的显示
        /// </summary>
        /// <param name="sift">是否打筛选栏</param>
        /// <param name="count">导航页数</param>
        /// <param name="item">数据条数</param>
        private void ModifyDataList(int founderid, int sift, int count, int item)
        {
            string strsql = " ownersid=" + founderid;
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            EtNet_Models.SearchPageSet pageset = null;
            int id = 0;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                id = int.Parse(tbl.Rows[i]["id"].ToString());
                pageset = EtNet_BLL.SearchPageSetManager.GetModel(id);
                pageset.Pagecount = count;
                pageset.Pageitem = item;
                EtNet_BLL.SearchPageSetManager.updateSearchPageSet(pageset);
            }
        }




        /// <summary>
        /// 修改面板菜单的列数的记录
        /// </summary>
        private void ModifyPanelMenuRecord(int founderid, int totalcols)
        {
            string strsql = " founderid=" + founderid;
            DataTable tbl = EtNet_BLL.PanelMenuRecordManager.GetList(strsql);

            EtNet_Models.PanelMenuRecord model = new EtNet_Models.PanelMenuRecord();
            model.founderid = founderid;
            model.totalcols = totalcols;
            model.userempty = "F";//面板条目不设置为
            model.id = int.Parse(tbl.Rows[0]["id"].ToString());
            EtNet_BLL.PanelMenuRecordManager.Update(model);
        }



        /// <summary>
        /// 首次打开主页面板时创建的默认的条目
        /// </summary>
        private void ModifyPanelItem(int founderid, string panel)
        {
            string strdel = " founderid=" + founderid;
            EtNet_BLL.PanelMenuManager.Del(strdel); //删除面板菜单项


            string strSql = " id in(" + panel + ")";
            DataTable tbl = EtNet_BLL.PanelMenuListManager.GetList(strSql);

            EtNet_Models.PanelMenu model = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                model = new EtNet_Models.PanelMenu();
                model.colsnum = 1;
                model.rowsnum = i + 1;
                model.title = tbl.Rows[i]["cname"].ToString();
                model.imageload = tbl.Rows[i]["imageload"].ToString();
                model.founderid = founderid;
                model.direction = tbl.Rows[i]["num"].ToString();
                EtNet_BLL.PanelMenuManager.Add(model);
            }
        }




        /// <summary>
        /// 修改用户参数设置
        /// </summary>
        private void ResetUserSet()
        {
            SaveInitializeSet(); //保存参数设置

            int id = int.Parse(this.hidval.Value);
            EtNet_Models.InitializeSet model = EtNet_BLL.InitializeSetManager.GetModel(id);

            string[] list = null; //用户的id值列表
            if (this.hiduserlist.Value.IndexOf(',') != -1)
            {
                list = this.hiduserlist.Value.Split(',');
            }
            else
            {
                list = new string[1] { this.hiduserlist.Value };
            }
            int founderid = 0; //用户的id值
            for (int i = 0; i < list.Length; i++)
            {
                founderid = int.Parse(list[i]);
                string strdel = " createrid=" + founderid;
                EtNet_BLL.InitializeUserSetManager.Del(strdel); //删除用户参数设置

                EtNet_Models.InitializeUserSet user = new EtNet_Models.InitializeUserSet();
                user.cname = model.cname;
                user.createrid = founderid;
                user.createtime = DateTime.Now;
                user.infocycle = model.infocycle;
                user.inforemind = model.inforemind;
                user.newinforemind = model.newinforemind;
                user.pagecount = model.pagecount;
                user.pageitem = model.pageitem;
                user.panelcols = model.panelcols;
                user.panelcount = model.panelcount;
                user.panellist = model.panellist;
                user.panellistall = model.panellistall;
                user.siftopen = model.siftopen;
                EtNet_BLL.InitializeUserSetManager.Add(user);

                ModifyDataList(founderid, model.siftopen, model.pagecount, model.pageitem);
                ModifyPanelMenuRecord(founderid, model.panelcols);
                ModifyPanelItem(founderid, model.panellist);
            }
        }

        //修改用户参数配置
        protected void imgbtnuser_Click(object sender, ImageClickEventArgs e)
        {
            ResetUserSet();
        }
    }
}