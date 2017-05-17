using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_BLL.DataPage;

namespace EtNet_Web.Pages.Customers
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void dataBind()
        {
            Data data = new Data();
            DataSet ds = data.DataPage("Customer", "Id", "*", "", "Id", true, 5, 5, pages);
            cuslist.DataSource = ds;
            cuslist.DataBind();
        }

        public static string ifused(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>未启用</span>";
            }
            else
            {
                return args = "<span style='color:blue'>已启用</span>";
            }
        }

        public static string cuspro(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>潜在客户</span>";
            }
            else
            {
                return args = "<span style='color:blue'>正式客户</span>";
            }
        }

        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                string id = e.CommandArgument.ToString();
                CustomerManager.deleteCustomer(Convert.ToInt32(id));
            }
            if (e.CommandName == "update")
            {

            }
            dataBind();
        }
    }
}