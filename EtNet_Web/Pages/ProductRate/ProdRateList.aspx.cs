using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.ProductRate
{
    public partial class ProdRateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                PageSymbolNum();
                QueryBuilder();
                LoadRate();
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
            if (Session["PageNum"].ToString() != "012")
            {
                Session["PageNum"] = "012";
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
            }
            if (Session["query"].ToString() != "")
            {
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='012'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "012";
                pageset.Pagecount = 10;
                pageset.Pageitem = 10;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }

        /// <summary>
        /// 加载综合比率信息
        /// </summary>
        public void LoadRate()
        {
            this.pages.Visible = true;
            DataTable tbl = Exists(); //页面设置信息
            string sql = "";
            sql += Session["query"].ToString();
            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("LoginProdRate", "id", "*", sql, "id", false, pitem, pcount, pages);
            this.ratelist.DataSource = ds;
            this.ratelist.DataBind();
        }

        protected void ratelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Update":
                    string id = e.CommandArgument.ToString();
                    Response.Redirect("UpdateProdRate.aspx?id=" + id);
                    break;
                case "Delete":
                    int id1 = int.Parse(e.CommandArgument.ToString());
                    LoginProdRateManager.Delete(id1);
                    LoadRate();
                    break;
            }
        }

        public string rateshow(string rate)
        {
            return rate + "%";
        }
    }
}