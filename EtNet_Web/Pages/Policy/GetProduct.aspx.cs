using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Policy
{
    public partial class GetProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object id = Request["id"];
            if (id == null || id.ToString() == string.Empty)
            {
                Response.Write("暂无数据");
                return;
            }

            ProductManager proBLL = new ProductManager();
            DataTable dt = proBLL.GetList(string.Format("ProdTypeID='{0}'", id));
            if (dt.Rows.Count == 0)
            {
                Response.Write("暂无数据");
                return;
            }
            RpProType.DataSource = dt;
            RpProType.DataBind();
        }
    }
}