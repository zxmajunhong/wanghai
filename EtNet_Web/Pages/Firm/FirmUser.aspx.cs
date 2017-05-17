using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Firm
{
    public partial class FirmUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUesr();
            }
        }


        /// <summary>
        /// 加载用户数据
        /// </summary>
        private void LoadUesr()
        {
            int id = int.Parse(Request.Params["id"]);
            string strsql = " ',' + firmidlist + ',' like '%," + id.ToString() + ",%'";
            DataTable tbl = LoginInfoManager.getList(strsql);
            this.UserList.DataSource = tbl;
            this.UserList.DataBind();
        }

        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowFirm.aspx");
        }
    }
}