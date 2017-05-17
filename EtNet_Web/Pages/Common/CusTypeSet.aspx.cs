using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Common
{
    public partial class CusTypeSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getType();
        }

        private void getType()
        {
            IList<CusType> com = CusTypeManager.getCusTypeAll();
            this.rpCusType.DataSource = com;
            this.rpCusType.DataBind();
        }

        protected void rpCusType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                string id = e.CommandArgument.ToString();

                IList<Customer> cop = CustomerManager.getCustomerType(Convert.ToInt32(id));

                if (cop.Count > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('正在使用中的类型不能删除！');", true);
                }
                else
                {
                    CusTypeManager.deleteCusType(Convert.ToInt32(id));
                }
            }
            getType();
        }

        //protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        //{
        //    CusType type = new CusType();
        //    type.TypeName = this.tbxTypeName.Text.ToString();
        //    type.Typeremark = this.tbxTypeRemark.Text.ToString();
        //    CusTypeManager.addCusType(type);

        //    getType();
        //}
    }
}