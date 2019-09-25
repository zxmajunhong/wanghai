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
    public partial class AddIncomeType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 新增类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            IncomeType type = IncomeTypeManager.GetModelByName(this.txtTypeName.Text.Trim());
            if (type == null)
            {
                type = new IncomeType();
                type.TypeName = this.txtTypeName.Text.Trim();
                bool result = IncomeTypeManager.Add(type);
                if (result)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('添加成功');window.location='InComeTypeList.aspx'</script>", false);
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "defaul", "<script>alert('添加失败')</script>", false);
            }
            else
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('类型名称不能重复！');", true);
        }

        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InComeTypeList.aspx");
        }


    }
}