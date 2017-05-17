using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL.DataPage;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.expense
{
    public partial class InComeTypeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        private void dataBind()
        {
            LoginInfo currentLogin = Session["login"] as LoginInfo;
            int pitem = 0;
            int pcount = 0;
            SearchPageSet set = SearchPageSetManager.getSearchPageSetByLoginId(currentLogin.Id, 024);
            if (set != null)
            {
                pitem = set.Pageitem;
                pcount = set.Pagecount;
            }
            else
            {
                pitem = 10;
                pcount = 10;
            }
            EtNet_BLL.DataPage.Data data = new Data();
            DataSet ds = data.DataPage("IncomeType", "id", "*", "", "id", true, pitem, pcount, pages);
            typeList.DataSource = ds;
            typeList.DataBind();
        }

        protected void typeList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Update":
                    Response.Redirect("UpdateIncomeType.aspx?id=" + id);
                    break;
                case "Delete":
                    bool del = IncomeTypeManager.Delete(Convert.ToInt32(id));
                    break;
            }
            dataBind();
        }


    }
}