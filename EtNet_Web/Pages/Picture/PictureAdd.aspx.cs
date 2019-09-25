using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.IO;

namespace EtNet_Web.Pages.Picture
{
    public partial class PictureAdd : System.Web.UI.Page
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
                    LoadFolderData();
                }
            }
        }


        //加载图集文件夹
        private void LoadFolderData()
        {
            string strsql = " creater=" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND typecode not in(2)";
            DataTable tbl = EtNet_BLL.PictureFolderInfoManager.GetList(strsql);

            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["cname"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlfolder.DataValueField = "id";
            this.ddlfolder.DataTextField = "cname";
            this.ddlfolder.DataSource = tbl;
            this.ddlfolder.DataBind();
        }




        
        //保存上传的图片,提示是否上传成功
        private void Save()
        {
            string saveurl = "../../UploadFile/Picture/";
            string filename = "";
            string newfile = "";
            string format = "";
            string result = "";
            HttpPostedFile file = null;
            EtNet_Models.PictureInfo model = null;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                file = Request.Files[i];
                filename = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);

                if (file.FileName != "")
                {
                    if (file.ContentLength <= (1024 * 1024))
                    {

                        format = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);
                        newfile = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + filename;
                        file.SaveAs(HttpContext.Current.Server.MapPath(saveurl + newfile));

                        model = new EtNet_Models.PictureInfo();
                        model.cname = filename;
                        model.creater = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                        model.createtime = DateTime.Now;
                        model.delidlist = "";
                        model.deltxtlist = "";
                        model.editidlist = "";
                        model.edittxtlist = "";
                        model.folderid = int.Parse(this.ddlfolder.SelectedValue);
                        model.format = format;
                        model.imgpath = saveurl + newfile;
                        model.modifytime = DateTime.Now;
                        model.sharecode = 0;
                        model.sharestxt = "私有";
                        model.size = file.ContentLength;
                        model.viewidlist = "";
                        model.viewtxtlist = "";
                        model.visiblecode = 1;
                        model.visibletxt = "可见";

                        EtNet_BLL.PictureInfoManager.Add(model);

                    }
                    else
                    {
                        if (result == "")
                        {
                            result = filename;
                        }
                        else
                        {
                            result += "," + filename;
                        }

                    }
                }
            }
            if (result == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('图片上传成功'); window.location = 'PictureShow.aspx'</script>", false);

            }
            else
            {
               result = "<script>alert('括号中的图片超出1M上传失败[" + result + "]')</script>";
               Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", result, false);
            }
        
        }




        //保存上传
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            Save();
        }


        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PictureShow.aspx");
        }


    }
}