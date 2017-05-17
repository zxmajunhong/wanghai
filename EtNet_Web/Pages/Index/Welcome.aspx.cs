using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Index
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPanelMenuData();
            }
        }

        /// <summary>
        /// 返回关于面板菜单的列数的记录
        /// </summary>
        private int PanelMenuRecord()
        {
            string str = " founderid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;

            DataTable tbl = EtNet_BLL.PanelMenuRecordManager.GetList(str);
            if (tbl.Rows.Count == 0)
            {
                EtNet_Models.PanelMenuRecord model = new EtNet_Models.PanelMenuRecord();
                model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                model.totalcols = 1;
                model.userempty = "F";//面板条目不设置为空

                if (EtNet_BLL.PanelMenuRecordManager.Add(model))
                {
                    FirstFourLItem();
                }
                return model.totalcols;
            }
            else
            {
                return int.Parse(tbl.Rows[0]["totalcols"].ToString());
            }

        }

        /// <summary>
        /// 首次打开主页面板时创建的四个默认的条目
        /// </summary>
        private void FirstFourLItem()
        {

            string strSql = " num in('1','2','5','12')";
            DataTable tbl = EtNet_BLL.PanelMenuListManager.GetList(strSql);

            EtNet_Models.PanelMenu model = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                model = new EtNet_Models.PanelMenu();
                model.colsnum = 1;
                model.rowsnum = i + 1;
                model.title = tbl.Rows[i]["cname"].ToString();
                model.imageload = tbl.Rows[i]["imageload"].ToString();
                model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                model.direction = tbl.Rows[i]["num"].ToString();
                EtNet_BLL.PanelMenuManager.Add(model);

            }

        }


        /// <summary>
        /// 加载显示面板菜单数据
        /// </summary>
        private void LoadPanelMenuData()
        {
            int totalcols = PanelMenuRecord();

            string strSql = " founderid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strSql += " order by colsnum,rowsnum";
            DataTable tbl = EtNet_BLL.PanelMenuManager.GetList(strSql);
            if (tbl.Rows.Count != 0)
            {
                this.columnleft.InnerHtml = "";
                this.columncenter.InnerHtml = "";
                this.columnright.InnerHtml = "";
                CreatePanelItem(tbl, totalcols);
            }
            else
            {

            }
        }



        /// <summary>
        /// 创建面板菜单条目
        /// </summary>
        private void CreatePanelItem(DataTable tbl, int totalcols)
        {

            DataRow[] rows = null;

            for (int j = 1; j < 4; j++)
            {
                rows = tbl.Select(" colsnum=" + j);
                if (rows.Length != 0)
                {
                    LoadRowsDataToPanel(j, rows);

                }

            }

            switch (totalcols)
            {
                case 0:
                    break;

                case 1:
                    this.columnleft.Attributes["style"] = "width:99%; float:left;";
                    this.columncenter.Attributes["style"] = "width:0%;float:left;";
                    this.columnright.Attributes["style"] = "width:0%; float:left;";

                    break;

                case 2:
                    this.columnleft.Attributes["style"] = "width:49%; float:left;";
                    this.columncenter.Attributes["style"] = "width:49%;float:left;";
                    this.columnright.Attributes["style"] = "width:0%; float:left;";
                    break;

                case 3:
                    this.columnleft.Attributes["style"] = "width:33%;float:left;";
                    this.columncenter.Attributes["style"] = "width:33%;float:left;";
                    this.columnright.Attributes["style"] = "width:33%; float:left;";
                    break;

            }

        }


        /// <summary>
        /// 为每一列加载数据
        /// </summary>
        private void LoadRowsDataToPanel(int col, DataRow[] datars)
        {

            string strdata = "";
            for (int k = 0; k < datars.Length; k++)
            {
                strdata += " <div id=portlet" + datars[k]["id"].ToString() + " class='portlet'>";
                strdata += " <div class='portlet-header'><span class='portlet-header-title'>" + datars[k]["title"].ToString() + "</span></div>";
                strdata += " <div id='content" + datars[k]["direction"].ToString() + "' class='portlet-content'></div></div>";

            }

            switch (col)
            {
                case 1:

                    this.columnleft.InnerHtml = strdata;
                    break;

                case 2:

                    this.columncenter.InnerHtml = strdata;
                    break;

                case 3:
                    this.columnright.InnerHtml = strdata;
                    break;
            }

        }

        /// <summary>
        /// 合并为指定的列数
        /// </summary>
        private void MergerDataList(int targetnum)
        {
            string strSql = " founderid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strSql += " order by colsnum,rowsnum";
            DataTable tbl = EtNet_BLL.PanelMenuManager.GetList(strSql);
            DataRow[] rows = null;
            EtNet_Models.PanelMenu model = null;
            int colsnoe = 0;
            if (tbl.Rows.Count > 0)
            {
                switch (targetnum)
                {
                    case 1:
                        colsnoe = tbl.Select(" colsnum = 1").Length;
                        rows = tbl.Select("colsnum in(2,3)");
                        break;
                    case 2:
                        colsnoe = tbl.Select(" colsnum = 1").Length;
                        rows = tbl.Select("colsnum in(3)");
                        break;
                    case 3:
                        colsnoe = tbl.Select(" colsnum = 1").Length;
                        rows = tbl.Select("colsnum in(4)");
                        break;
                }

                for (int i = 0; i < rows.Length; i++)
                {
                    model = new EtNet_Models.PanelMenu();
                    model.id = int.Parse(rows[i]["id"].ToString());
                    model.founderid = int.Parse(rows[i]["founderid"].ToString());
                    model.colsnum = 1;
                    model.direction = rows[i]["direction"].ToString();
                    model.imageload = rows[i]["imageload"].ToString();
                    model.title = rows[i]["title"].ToString();
                    model.rowsnum = ++colsnoe;
                    EtNet_BLL.PanelMenuManager.Update(model);

                }

            }

        }


        /// <summary>
        /// 判断是合并还是拆分列,返回true表示合并列表
        /// </summary>
        private bool JudgeIsMerger(int orinum, int targenum)
        {
            if (orinum >= targenum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 合并或是拆分列
        /// </summary>
        private void SplitOrMerger(int targenum)
        {
            int original = 0;
            string str = " founderid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            DataTable tbl = EtNet_BLL.PanelMenuRecordManager.GetList(str);
            if (tbl.Rows.Count == 1)
            {
                original = int.Parse(tbl.Rows[0]["totalcols"].ToString());

                if (JudgeIsMerger(original, targenum))
                {
                    MergerDataList(targenum);
                }
                else
                {

                }

                //更改面板菜单记录数据
                EtNet_Models.PanelMenuRecord model = new EtNet_Models.PanelMenuRecord();
                model.id = int.Parse(tbl.Rows[0]["id"].ToString());
                model.founderid = int.Parse(tbl.Rows[0]["founderid"].ToString());
                model.totalcols = targenum;
                model.userempty = tbl.Rows[0]["userempty"].ToString();
                EtNet_BLL.PanelMenuRecordManager.Update(model);

                LoadPanelMenuData();

            }
            else
            {
                string msg = "<script>jNotify('无法更改!',{ ShowOverlay: true, AutoHide: true,";
                msg += "VerticalPosition: 'center', HorizontalPosition:'center'});</script>";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), " spinoffs", msg, false);
            }


        }

        protected void imgbtnone_Click(object sender, ImageClickEventArgs e)
        {
            SplitOrMerger(1);
        }


        protected void imgbtntwo_Click(object sender, ImageClickEventArgs e)
        {
            SplitOrMerger(2);
        }

        protected void imgbtnthree_Click(object sender, ImageClickEventArgs e)
        {
            SplitOrMerger(3);
        }
    }
}