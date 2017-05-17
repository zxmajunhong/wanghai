using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL.DataPage;
using System.Data;
using System.Text;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddata();
            }
        }

        //绑定数据
        private void binddata()
        {
            Data data = new Data();
            DataSet ds = data.DataPage("Company", "Id", "*", FilterSql, "Id", true, 10, 10, pages);
            Rpunit.DataSource = ds;
            Rpunit.DataBind();
        }

        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            StringBuilder strWhere = new StringBuilder();
            string allName = name.Value.Trim();
            string shortName = shortname.Value.Trim();
            if (allName != string.Empty)
                strWhere.AppendFormat(" and comCName like '%{0}%' ", allName);
            if (shortName != string.Empty)
                strWhere.AppendFormat(" and comShortName like '%{0}%' ", shortName);

            FilterSql = strWhere.ToString();
            binddata();
        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            name.Value = "";
            shortname.Value = "";
            FilterSql = "";
            binddata();
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }
    }
}