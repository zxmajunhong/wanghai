using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;

namespace EtNet_Web.Pages.Common
{
    public partial class CusShortName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            string shortName = this.tbxName.Text;

            bool count = CustomerManager.getSName(shortName, 0);
            if (count == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已存在相同简称！');", true);
            }
            else
            {
                
            }
        }
    }
}