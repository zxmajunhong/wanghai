using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL.DataPage;
using EtNet_BLL;

namespace EtNet_Web.Pages.Line
{
    public partial class LineList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataLoad();
            }
        }

        /// <summary>
        /// 绑定
        /// </summary>
        private void DataLoad()
        {

            EtNet_BLL.DataPage.Data data = new Data();
            DataSet ds = data.DataPage("tb_line", "id", "*", "", "id", true, 10, 10, pages);
            cuslist.DataSource = ds;
            cuslist.DataBind();
        }
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case"Edit":
                    Response.Redirect("EditLine.aspx?id=" + e.CommandArgument);
                    break;
                case"Delete":
                    Tb_lineManager.deleteTb_line(Convert.ToInt32(e.CommandArgument));
                    break;
            }
            DataLoad();
        }
    }
}