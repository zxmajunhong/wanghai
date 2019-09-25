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
    public partial class CustBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bank();
        }

        private void bank() 
        {
            string id = Request.QueryString["id"].ToString();
            IList<CusBank> cusbank = CusBankManager.getCusBankByCusId(Convert.ToInt32(id));
            if (cusbank.Count == 0)
            {
                tip.InnerHtml = "<div style='line-height:60px;height:60px;width:100%;text-align:center;'><p style='color:gray;width:200px;margin:0 auto;background:#FFFFFF;border:solid 0px #ccc; text-algin:center'>暂无银行信息<p></div>";
            }
            else
            {
                banklist.DataSource = cusbank;
            }
            
            banklist.DataBind();
        }
    }
}