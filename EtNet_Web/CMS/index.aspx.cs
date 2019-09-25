using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] != null)
                {
                    Session["CMSLogin"] = Session["login"];
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                //if (Session["CMSLogin"] == null)
                //{
                //    Response.Redirect("Login.aspx");
                //}
            }
        }
    }
}