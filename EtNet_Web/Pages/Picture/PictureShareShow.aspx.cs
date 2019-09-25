using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Picture
{
    public partial class PictureShareShow : System.Web.UI.Page
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
                    // SiftIsOpen();           
                    LoadFormatData();
                    LoadPictureData();
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
            if (Session["PageNum"].ToString() != "021")
            {
                Session["PageNum"] = "021";
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



        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='021'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "021";
                pageset.Pagecount = 2;
                pageset.Pageitem = 2;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }



        //加载格式数据
        private void LoadFormatData()
        {
            string[] list = new string[] { "——请选中——", "png", "gif", "bmp", "jpg" };
            this.ddlformat.DataSource = list;
            this.ddlformat.DataBind();
        }


        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strsql = "";
            if (this.iptcname.Value != "")
            {
                strsql += "  AND cname like '%" + this.iptcname.Value + "%' ";
            }
            if (this.ddlformat.SelectedIndex != 0)
            {
               
                strsql += "  AND format ='" + this.ddlformat.SelectedValue + "'";
            }

            Session["query"] = strsql;

        }



        /// <summary>
        /// 加载图片数据
        /// </summary>
        private void LoadPictureData()
        {
            this.picturedata.Visible = true;
            this.pages.Visible = true;
            DataTable strtbl = Exists();
            string login = ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            string strfixed = " AND creatercode not in(" + login + ") AND sharecode = 1 AND ',' + viewidlist + ',' like '%," + login + ",%'";
            string strsql = Session["query"].ToString();

            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());

            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataTable tbl = data.DataPage("ViewPictureInfo", "id", "*", strfixed + strsql, "id", true, pitem, pcount, pages).Tables[0];

            string str = "";
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                str += "<div class='pictotal'>";
                str += "<div class='pictop' title='" + tbl.Rows[i]["sharestxt"] + "'>";
                str += "<img src='" + tbl.Rows[i]["imgpath"] + "' /></div>";
                str += "<div class='piccenter'>" + tbl.Rows[i]["cname"] + "</div></div>"; 
            }
            if (str == "")
            {
                this.picturedata.Visible = false;
            }
            else
            {
                this.picturedata.InnerHtml = str;
            }


        }

        //查询
        protected void btnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadPictureData();
        }

        //重置
        protected void btnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.iptcname.Value = "";
            this.ddlformat.SelectedIndex = 0;
            Session["query"] = "";
            LoadPictureData();
        }




    }
}