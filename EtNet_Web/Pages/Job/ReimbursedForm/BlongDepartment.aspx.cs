using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Collections;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class BlongDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getType();
        }

        private void getType()
        {

            IList<DepartmentInfo> departmentInfo = DepartmentInfoManager.getDepartmentInfoAll();

            this.type.DataSource = departmentInfo;
            this.type.DataBind();
        }

      
    }
}