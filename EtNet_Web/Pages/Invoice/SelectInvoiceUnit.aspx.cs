using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Invoice
{
    public partial class SelectInvoiceUnit : System.Web.UI.Page
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
            DataSet ds = data.DataPage("Company", "Id", "*", "", "Id", true, 10, 5, pages);
            Rpunit.DataSource = ds;
            Rpunit.DataBind();
        }

        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}