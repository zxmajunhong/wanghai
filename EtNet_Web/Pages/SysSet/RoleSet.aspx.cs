using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;

namespace Pages.SysSet
{
    public partial class RoleSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }

        }

        //绑定数据

        /// <summary>
        /// 绑定
        /// </summary>
        private void bindData()
        {
            EtNet_BLL.DataPage.Data data = new Data();
            DataSet ds = data.DataPage("RoleInfo", "roleid", "*", "", "roleid", true, 10, 10, pages);
            roleInfo.DataSource = ds;
            roleInfo.DataBind();
        }



        protected void roleInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //编辑
            if (e.CommandName == "Edit")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("../Permission/RolePermission.aspx?id=" + id);
            }
            //删除
            if (e.CommandName == "Delete")
            {
                string id = e.CommandArgument.ToString();
                try
                {
                    int del = RoleInfoManager.deleteRoleInfo(Convert.ToInt32(id));
                    if (del > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('删除成功！')", true);// 信息提示
                        LoginLimitManager.DeleteRoleMenu(id);
                        bindData();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('删除失败！请联系管理员！')", true);// 信息提示
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('角色当前在使用，不能删除。')", true);// 信息提示
                }
            }
        }

    }
}