using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages.SysSet
{
    public partial class AddRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //检验是否可以添加该角色,名称已存在的不能添加
        private bool TestAdd()
        {
            bool isadd = true;
            IList<EtNet_Models.RoleInfo> list = EtNet_BLL.RoleInfoManager.getRoleInfoAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Rolenname == this.txtRoleName.Text.Trim())
                {
                    isadd = false;
                    break;
                }
            }
            return isadd;
        }

        //添加角色
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (TestAdd())
            {
                EtNet_Models.RoleInfo role = new EtNet_Models.RoleInfo();
                role.Rolenname = this.txtRoleName.Text.ToString();
                role.Remark = this.txtRoleRemark.Text.ToString();
                int roleId = EtNet_BLL.RoleInfoManager.AddRole(role);
                if (roleId > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功')</script>", false);
                    Response.Redirect("../Permission/RolePermission.aspx?id=" + roleId);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败')</script>", false);
                }
                this.txtRoleName.Text = "";
                this.txtRoleRemark.Text = "";
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败,该角色已存在')</script>", false);
            }

        }

        //返回角色显示页面
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RoleSet.aspx");
        }
    }
}