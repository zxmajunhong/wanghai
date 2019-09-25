using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class SelectBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBankList();
            }
        }

        private void LoadBankList()
        {
            DataTable dt = FirmAccountInfoManager.GetList("");
            rpBankList.DataSource = dt;
            rpBankList.DataBind();
        }
    }
}