using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Customers
{
    public partial class CusLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            linkman();
        }

        private void linkman()
        {
            string id = Request.QueryString["id"].ToString();
            IList<CusLinkman> cusLinkman = CusLinkmanManager.getCusLinkmanByCusId(Convert.ToInt32(id));
            if (cusLinkman.Count == 0)
            {
                tip.InnerHtml = "<div style='line-height:60px;height:60px;width:100%;text-align:center;'><p style='color:gray;width:200px;margin:0 auto;background:#FFFFFF;border:solid 0px #ccc; text-algin:center'><p></div>";
            }
            else
            {
                cuslinklist.DataSource = cusLinkman;
            }
            cuslinklist.DataBind();
        }
    }
}