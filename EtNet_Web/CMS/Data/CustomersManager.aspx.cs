using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using EtNet_BLL;
using System.Collections;
using System.Configuration;

namespace EtNet_Web.CMS.Data
{
    public partial class CustomersManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void dataBind()
        {
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["CMSCount"]);
            int page = Convert.ToInt32(ConfigurationManager.AppSettings["CMSPage"]);
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("Customer", "Id", "*", "", "Id", true, count, page, pages);
            rpCustomer.DataSource = ds;
            rpCustomer.DataBind();
        }

        public static string toMadeFrom(int id)
        {
            LoginInfo login = LoginInfoManager.getLoginInfoById(id);
            return login.Cname;
        }

        protected void ibtnDeleteAll_Click(object sender, ImageClickEventArgs e)
        {
            string delId = "";
            //先遍历取得选中项    

            for (int i = 0; i < this.rpCustomer.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)(rpCustomer.Items[i].FindControl("cbx"));
                Label lbl = (Label)rpCustomer.Items[i].FindControl("lbl");
                if (cbx != null || cbx.Text != "")
                {
                    if (cbx.Checked)
                    {
                        delId += lbl.Text + ",";
                    }
                }
            }
            //去掉最后一个,    
            delId = (delId + ")").Replace(",)", "");
            IList check = delId.Split(',');

            for (int i = 0; i < check.Count; i++)
            {

                Customer customer = CustomerManager.getCustomerById(Convert.ToInt32(check[i]));
                if (customer != null)
                {
                    CusBankManager.deleteCusBankByCusId(customer.Id);
                    CusLinkmanManager.deleteCusLinkmanByCusId(customer.Id);
                    CustomerManager.deleteCustomer(customer.Id);
                }
            }
            dataBind();
        }


        protected void rpCustomer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                EtNet_Models.Customer model = EtNet_BLL.CustomerManager.getCustomerById(id);
                if (model != null)
                {
                    CusBankManager.deleteCusBankByCusId(model.Id);
                    CusLinkmanManager.deleteCusLinkmanByCusId(model.Id);
                    int count = CustomerManager.deleteCustomer(model.Id);
                 
                    if (count <= 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('删除失败')", true);
                        return;
                    }
                }
                  
            }
            dataBind();
        }

    }
}