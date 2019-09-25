using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.SystemSetting
{
    public partial class parameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryBuilder();
            PageSymbolNum();
            dataBind();
        }


        private void dataBind()
        {
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 003);
            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Parameter", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
                Pramas.DataSource = ds;
                Pramas.DataBind();
            }
            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Parameter", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                Pramas.DataSource = ds;
                Pramas.DataBind();

            }
        }


        /// <summary>
        /// 保存数据列表
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 页面数字标识
        /// </summary>
        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = ""; //如无PageNum，先生成一个
            }
            if (Session["PageNum"].ToString() != "003")
            {
                Session["PageNum"] = "003";
                Session["query"] = "";
            }
        }
    }
}