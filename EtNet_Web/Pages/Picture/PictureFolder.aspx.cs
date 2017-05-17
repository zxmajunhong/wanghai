using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace EtNet_Web.Pages.Picture
{
    public partial class PictureFolder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                   
                    LoadPictureFolder();    
                }
            }
        }



        /// <summary>
        /// 加载文件夹列表
        /// </summary>
        private void LoadPictureFolder()
        {       
            string strsql = " creater=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            DataTable tbl =  EtNet_BLL.PictureFolderInfoManager.GetList(strsql);
            this.rptdata.DataSource = tbl;
            this.rptdata.DataBind();
        }


        /// <summary>
        /// 删除图片文件
        /// </summary>
        private void DelFile(string folderid)
        {
            string strsql = " folderid=" + folderid;
            string path = "";
            DataTable tbl = EtNet_BLL.PictureInfoManager.GetList(strsql);
             
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                path = tbl.Rows[i]["imgpath"].ToString();
                File.Delete(Server.MapPath(path));   
            }
        }


        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            { 
                case "del":
                    string id = e.CommandArgument.ToString();
                    DelFile(id);
                    string strdel = " folderid=" + id;
                    EtNet_BLL.PictureInfoManager.DelList(strdel);
                    EtNet_BLL.PictureFolderInfoManager.Delete(int.Parse(id));               
                    break;
            }
            LoadPictureFolder();
        }


        //新增
        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            string strsql = " creater=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND cname='" + this.hidtxt.Value + "'";
            DataTable tbl =  EtNet_BLL.PictureFolderInfoManager.GetList(strsql);
            if (tbl.Rows.Count == 0)
            {
                EtNet_Models.PictureFolderInfo model = new EtNet_Models.PictureFolderInfo();
                model.capacity = 10;
                model.capacityused = 10;
                model.cname = this.hidtxt.Value;
                model.creater = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                model.typecode = 1;
                model.typetxt = "个人图库";
                model.upid = 0;
                if (EtNet_BLL.PictureFolderInfoManager.Add(model))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败')</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败,该名称已存在')</script>",false);
            }
            this.hidsel.Value = "";
            this.hidtxt.Value = "";
            LoadPictureFolder();
        }


        //修改
        protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
        {
            string strsql = " creater=" + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND cname='" + this.hidtxt.Value + "' AND id not in("+this.hidsel.Value+")";
            DataTable tbl = EtNet_BLL.PictureFolderInfoManager.GetList(strsql);
            if (tbl.Rows.Count == 0)
            {
                int id = int.Parse(this.hidsel.Value);
                EtNet_Models.PictureFolderInfo model = EtNet_BLL.PictureFolderInfoManager.GetModel(id);
                model.cname = this.hidtxt.Value;
                if (EtNet_BLL.PictureFolderInfoManager.Update(model))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改成功')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改失败')</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改失败,该名称已存在')</script>", false);
            }
            this.hidsel.Value = "";
            this.hidtxt.Value = "";
            LoadPictureFolder();
        }

      


    }
}