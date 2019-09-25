using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Collections;
using System.Data;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class AusType: System.Web.UI.Page
    {
        string strwhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            strwhere = " iscy = 'y'";
            getType();
        }

        private void getType()
        {

            DataTable ausType = AusTypeInfoManager.GetList(strwhere);

            this.type.DataSource = ausType;
            this.type.DataBind();
        }

        protected void isCy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList d = (DropDownList)sender;
            //Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "cy", "<script>alert(" + d.SelectedValue + ")</script>");
            if (d.SelectedIndex == 0)
            {
                strwhere = " iscy = 'y'"; //获得常用数据
            }
            if (d.SelectedIndex == 1)
            {
                strwhere = " iscy = 'n' or iscy is null";   //获得非常用数据
            }
            if (d.SelectedIndex == 2)
            {
                strwhere = "";  //获得全部数据
            }
            getType();
        }
      
    }
}