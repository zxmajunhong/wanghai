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
    public partial class PostSetType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getType();
            }
        }

        private void getType()
        {

            IList<To_Post> com = To_PostManager.getTo_PostAll();

            this.post.DataSource = com;
            this.post.DataBind();
        }

        //protected void type_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Delete")
        //    {

        //        string id = e.CommandArgument.ToString();

        //        IList<Company> cop = CompanyManager.getCompanyType(Convert.ToInt32(id));

        //        if (cop.Count > 0)
        //        {
        //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('正在使用中的类型不能删除！');", true);
        //        }
        //        else
        //        {
        //            ComTypeManager.deleteComType(Convert.ToInt32(id));
        //        }
        //    }
        //    getType();
        //}

        //protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        //{
        //    ComType type = new ComType();
        //    type.TypeName = this.tbxTypeName.Text.ToString();
        //    type.Typeremark = this.tbxTypeRemark.Text.ToString();
        //    ComTypeManager.addComType(type);
        //    getType();
        //}
    }
}