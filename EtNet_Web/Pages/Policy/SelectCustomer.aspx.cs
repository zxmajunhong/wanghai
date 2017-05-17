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
using System.Text;

namespace EtNet_Web.Pages.Policy
{
    public partial class SelectCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
                dataBind();
            }
        }

        private void dataBind()
        {
            string sqlstr = "and cusPro = 1 AND used = 1";
            sqlstr += FilterSql;
            Data data = new Data();
            DataSet ds = data.DataPage("Customer", "Id", "*", sqlstr, "Id", true, 10, 5, pages);
            RpCustomerList.DataSource = ds;
            RpCustomerList.DataBind();

        }



        public static string ifused(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>未启用</span>";
            }
            else
            {
                return args = "<span style='color:blue'>已启用</span>";
            }
        }

        public static string cuspro(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>潜在客户</span>";
            }
            else
            {
                return args = "<span style='color:blue'>正式客户</span>";
            }
        }

        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            dataBind();
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
            if (Session["PageNum"].ToString() != "001")
            {
                Session["PageNum"] = "001";
                FilterSql = "";
            }
        }



        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string fullName = txtFullName.Value.Trim();
            string shortName = txtShortName.Value.Trim();

            StringBuilder filterBuilder = new StringBuilder();

            if (fullName != string.Empty)
                filterBuilder.AppendFormat(" and cusCName like '%{0}%' ", txtFullName.Value.Trim());

            if (shortName != string.Empty)
                filterBuilder.AppendFormat(" and cusShortName like '%{0}%' ", txtShortName.Value.Trim());

            FilterSql = filterBuilder.ToString();
        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            FilterSql = "";
            txtShortName.Value = "";
            txtFullName.Value = "";
            dataBind();
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }
    }
}