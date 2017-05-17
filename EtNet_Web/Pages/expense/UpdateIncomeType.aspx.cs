using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.expense
{
    public partial class UpdateIncomeType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadType();
            }
        }

        private void LoadType()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            IncomeType model = IncomeTypeManager.GetModel(id);
            txtTypeName.Text = model.TypeName;
        }

        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            IncomeType model = IncomeTypeManager.GetModel(Convert.ToInt32(Request.QueryString["id"]));
            model.TypeName = this.txtTypeName.Text.Trim();

            IncomeType modellast = IncomeTypeManager.GetModelByName(this.txtTypeName.Text.Trim());

            if (modellast == null)
            {
                bool result = IncomeTypeManager.Update(model);
                if (result)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='InComeTypeList.aspx'</script>", false);
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
            }
            else
            {
                if (model.id == modellast.id)
                {
                    bool result = IncomeTypeManager.Update(model);
                    if (result)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='InComeTypeList.aspx'</script>", false);
                    else
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('类型名称不能重复！');", true);
                }
            }
        }

        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InComeTypeList.aspx");
        }
    }
}