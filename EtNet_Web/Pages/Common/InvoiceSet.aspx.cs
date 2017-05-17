using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Collections;

namespace EtNet_Web.Pages.Common
{
    public partial class InvoiceSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getType();
        }

        private void getType()
        {

            IList<To_Invoice> com = To_InvoiceManager.getTo_InvoiceAll();
            
            this.type.DataSource = com;
            this.type.DataBind();
        }

     
    }
}