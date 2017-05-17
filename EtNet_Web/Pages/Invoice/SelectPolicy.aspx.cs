using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL.DataPage;
using System.Data;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Invoice
{
    public partial class SelectPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddata();
            }
        }

        private void binddata()
        {
            //string type = Request.QueryString["type"].ToString();
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            string com = Request.QueryString["com"].ToString();
            string sale = Request.QueryString["sale"].ToString();
            sqlstr += " and company = " + Convert.ToInt32(com) + " and salesman = " + sale + " and auditstatus=" + "'04'";// + " and " + type + " is not null"
            Data data = new Data();
            DataSet ds = data.DataPage("View_PolicyAndBudget", "Id", "*", sqlstr, "Id", true, 10, 5, pages);
            Rppolicy.DataSource = ds;
            Rppolicy.DataBind();
        }

        public string price()
        {
            string type = Request.QueryString["type"].ToString();
            return type;
        }

        public string customer(int id)
        {
            Customer cus = CustomerManager.getCustomerById(id);
            return cus == null ? string.Empty : cus.CusCName;
        }


        public string changerNull(string args)
        {
            if (args == null || args == "")
            {
                return args = "0";
            }
            else
            {
                return args;
            }

        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryString();
            binddata();
            Session["query"] = "";
        }

        private void ModifyQueryString()
        {
            string serialnum = this.serialnum.Value.ToString();
            string start = this.txtBeginDate.Value.ToString();
            string end = this.txtEndDate.Value.ToString();
            string sqlstring = "";
            if (serialnum != "")
            {
                sqlstring += " and serialnum like '%" + serialnum + "%'";
            }
            if (start != "" && end != "")
            {
                sqlstring += " and policy_date between '" + start + "' and '" + end + "'";
            }

            Session["query"] = sqlstring;
        }

        protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
        {
            this.serialnum.Value = "";
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            string com = Request.QueryString["com"].ToString();
            string sale = Request.QueryString["sale"].ToString();
            sqlstr += " and company = " + Convert.ToInt32(com) + " and salesman = " + sale;// + " and " + type + " is not null"
            Data data = new Data();
            DataSet ds = data.DataPage("View_PolicyAndBudget", "Id", "*", sqlstr, "Id", true, 10, 5, pages);
            Rppolicy.DataSource = ds;
            Rppolicy.DataBind();
        }
    }
}