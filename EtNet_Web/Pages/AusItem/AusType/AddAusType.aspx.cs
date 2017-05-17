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
    public partial class AddAusType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AusTypeInfo ausTypeInfo = new AusTypeInfo();
            ausTypeInfo.typename = this.txtTypeName.Text.ToString();
            if (this.iscy.Checked)
            {
                ausTypeInfo.iscy = "y";
            }
            else
            {
                ausTypeInfo.iscy = "n";
            }

            AusTypeInfo ausTypeInfocount = AusTypeInfoManager.GetModelByTypename(this.txtTypeName.Text.ToString());

            if (ausTypeInfocount == null)
            {
                bool count = AusTypeInfoManager.Add(ausTypeInfo);
                if (count == true)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功');window.location='AusTypeList.aspx'</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败')</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('类型名称不能重复！');", true);
            }
        }

       

        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AusTypeList.aspx");
        }
    }
}