using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages.SysSet
{
    public partial class DepartUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserData();
            }
        }



        /// <summary>
        /// 加载部门下的用户数据
        /// </summary>
        private void LoadUserData()
        { 
           int id  = int.Parse(Request.QueryString["id"].Trim());
           IList<EtNet_Models.LoginInfo> list = EtNet_BLL.LoginInfoManager.getLoginInfoByDeptId(id);
           this.rptlist.DataSource = list;
           this.rptlist.DataBind();
        }

        //返回部门列表
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowDepart.aspx");
        }
    }
}