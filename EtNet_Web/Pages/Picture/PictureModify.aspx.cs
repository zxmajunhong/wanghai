using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Picture
{
    public partial class PictureModify : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFolderData();
                LoadPictureData();
            }
        }


        /// <summary>
        /// 加载目录
        /// </summary>
        private void LoadFolderData()
        {
            string strsql = " creater=" +  ((EtNet_Models.LoginInfo)Session["login"]).Id;
            DataTable tbl =  EtNet_BLL.PictureFolderInfoManager.GetList(strsql);
            DataRow row = tbl.NewRow();
            row["id"] = "0";
            row["cname"] = "——其选中——";
            tbl.Rows.InsertAt(row, 0);

            this.ddlfolder.DataValueField = "id";
            this.ddlfolder.DataTextField = "cname";
            this.ddlfolder.DataSource = tbl;
            this.ddlfolder.DataBind();
        }


        /// <summary>
        /// 加载需修改的图片
        /// </summary>
        private void LoadPictureData()
        {
            if (Request.Params["id"] != "")
            {
                int id = int.Parse(Request.Params["id"]);
                EtNet_Models.PictureInfo model =  EtNet_BLL.PictureInfoManager.GetModel(id);
                if (model != null)
                {
                    this.iptcname.Value = model.cname;
                    this.ddlfolder.SelectedValue = model.folderid.ToString();
                    if (model.sharecode == 1)
                    {
                        this.radshare.Items[0].Selected = true;
                        this.iptplist.Value = model.viewtxtlist;
                        this.hidplist.Value = model.viewidlist;
                    }
                    else
                    {
                        this.radshare.Items[1].Selected = true;
                    }
                }
                else
                {
                  this.imgbtnsure.Enabled = false;
                }
            }
        }


        
        protected void imgbtnsure_Click(object sender, ImageClickEventArgs e)
        {
            int id = int.Parse(Request.Params["id"]);
            EtNet_Models.PictureInfo model =  EtNet_BLL.PictureInfoManager.GetModel(id);
            if (model != null)
            {
                model.folderid = int.Parse(this.ddlfolder.SelectedValue);
                model.cname = this.iptcname.Value;
                if (this.radshare.SelectedValue == "0")
                {
                    model.sharecode = 0;
                    model.sharestxt = "私有";
                    model.viewidlist = "";
                    model.viewtxtlist = "";
                }
                else
                {
                    model.sharecode = 1;
                    model.sharestxt = "共享";
                    model.viewidlist = this.hidplist.Value;
                    model.viewtxtlist = this.iptplist.Value;
                }
                EtNet_BLL.PictureInfoManager.Update(model);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('修改成功'); window.location = 'PictureShow.aspx';</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('修改失败,图片已删除');window.location = 'PictureShow.aspx'</script>");
            }
        }


        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PictureShow.aspx");
        }

    }
}