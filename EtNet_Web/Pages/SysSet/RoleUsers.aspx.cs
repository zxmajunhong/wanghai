using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.SysSet
{
    public partial class RoleUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int roleID = 0;
                object argRoleID = Request.QueryString["roleid"];

                if (argRoleID == null || !int.TryParse(argRoleID.ToString(), out roleID))
                {
                    return;
                }

                RpUserListBindData(roleID);
            }
        }

        /// <summary>
        /// 根据角色绑定用户信息
        /// </summary>
        /// <param name="roleID">角色ID</param>
        private void RpUserListBindData(int roleID)
        {
            string userIDs = LoginDataLimitManager.GetUsersByRole(roleID);

            if (string.IsNullOrWhiteSpace(userIDs))
            {
                return;
            }

            string strWhere = string.Format("id in ({0})", userIDs);
            DataTable dtUser = LoginInfoManager.getList(strWhere);

            RpUserList.DataSource = dtUser;
            RpUserList.DataBind();
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RoleSet.aspx");
        }
    }
}