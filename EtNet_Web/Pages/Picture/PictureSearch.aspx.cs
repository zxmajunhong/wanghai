using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Picture
{
    public partial class PictureSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {           
                LoadFolderData();
                LoadPictureData();
            }
        }



        //加载图集文件夹
        private void LoadFolderData()
        {
            string strsql = " creater=" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND typecode not in(2)";
            DataTable tbl = EtNet_BLL.PictureFolderInfoManager.GetList(strsql);
            DataRow row = tbl.NewRow();
            row["id"] = "0";
            row["cname"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            row = tbl.NewRow();
            row["id"] = "-1";
            row["cname"] = "他人共享图片";
            tbl.Rows.InsertAt(row, 1);
            this.ddlfolder.DataValueField = "id";
            this.ddlfolder.DataTextField = "cname";
            this.ddlfolder.DataSource = tbl;
            this.ddlfolder.DataBind();
        }



        /// <summary>
        /// 加载图片数据
        /// </summary>
        private void LoadPictureData()
        {
            this.hidimgid.Value = "";
            this.hidimgpath.Value = "";
            this.picturedata.Visible = true;
            string login = ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            string strsql = "";
            switch(this.ddlfolder.SelectedIndex)
            {
                case 0:
                    break;

                case 1:
                    strsql = " creatercode not in(" + login + ") AND sharecode = 1 AND ',' + viewidlist + ',' like '%," + login + ",%'";
                    break;

                default:
                    strsql =" creatercode  in(" + login + ") AND foldercode ="+ this.ddlfolder.SelectedValue;
                    break;
            
            }

            if (this.ddlfolder.SelectedIndex != 0)
            {
                DataTable tbl = EtNet_BLL.ViewBLL.ViewPictureManager.getList("", strsql);
                string str = "";
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    str += "<div class='pictotal'>";
                    str += "<div class='pictop' title='" + tbl.Rows[i]["sharestxt"] + "'>";
                    str += "<img id='" + tbl.Rows[i]["id"] +"' ";
                    str += " src='" + tbl.Rows[i]["imgpath"] + "' /></div>";
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
        }




        //依据目录筛选图片
        protected void ddlfolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPictureData();
        }




    }
}