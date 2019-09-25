using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectPayType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPayType();
        }

        private void GetPayType()
        {
            DataTable dt = AusFinInfoManager.GetList("");
            this.type.DataSource = dt;
            this.type.DataBind();
        }
    }
}