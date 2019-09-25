using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;
using System.Text;

namespace EtNet_Web.Pages.Invoice
{
    public partial class ComAndPro : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RpCompanyBindData();
            }
        }



        private void RpCompanyBindData()
        {
            RpCompany.DataSource = CompanyManager.getCompanyAll();
            RpCompany.DataBind();
        }

    }
}