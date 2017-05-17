using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.AusType
{
    public partial class UpdateAusType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAusType();
            }
        }
        private void loadAusType()
        { 
            int id = Convert.ToInt32( Request.QueryString["id"]);
            AusTypeInfo typeInfo = AusTypeInfoManager.getAusTypesById(id);
            txtTypeName.Text = typeInfo.typename;
            if (typeInfo.iscy == "y")
            {
                this.iscy.Checked = true;
            }
            else
            {
                this.iscy.Checked = false;
            }
        }
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AusTypeInfo ausTypeInfo = new AusTypeInfo();
            ausTypeInfo.id = Convert.ToInt32(Request.QueryString["id"]);//得到当前更改类别的id
            ausTypeInfo.typename = this.txtTypeName.Text.ToString();
            if (this.iscy.Checked)
            {
                ausTypeInfo.iscy = "y";
            }
            else
            {
                ausTypeInfo.iscy = "n";
            }

            AusTypeInfo ausTypeInfocount = AusTypeInfoManager.GetModelByTypename(this.txtTypeName.Text.ToString());//得到该类别名称的实例  控制不会出现重复的类型名称

            if (ausTypeInfocount == null)
            {
                bool count = AusTypeInfoManager.Update(ausTypeInfo);
                if (count == true)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='AusTypeList.aspx'</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
                }
            }
            else
            {

                if (ausTypeInfocount.id == ausTypeInfo.id)//判断其与所需要更新的类别的ID是否一样，如果一样可以更新。如果不一样就不能更新
                {
                    bool count = AusTypeInfoManager.Update(ausTypeInfo);
                    if (count == true)
                    {

                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='AusTypeList.aspx'</script>", false);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('类型名称不能重复！');", true);
                }
            }
        }

       

        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AusTypeList.aspx");
        }
    }
}