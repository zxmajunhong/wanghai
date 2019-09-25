using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EtNet_BLL.DataPage;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Order
{
    public partial class SelectCus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.salemane.Value = Request.QueryString["saleman"].ToString();
                QueryBuilder();
                PageSymbolNum();
                dataBind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void dataBind()
        {
            #region 控制不能选择相同单位的代码
            //string cusid = Request.QueryString["Cusid"].ToString().Trim().TrimEnd(',');
            //cusid = "'" + cusid + "'";
            //string sqlstr = " and Id not in (" + cusid + ")";
            #endregion
            string sqlstr = "";
            sqlstr += FilterSql;
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("Customer", sqlstr);
            DataTable dt = data.GetList("Customer", "Id", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            RpCustomerList.DataSource = dt;
            RpCustomerList.DataBind();

        }

        /// <summary>
        /// 客户属性
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string cuspro(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>新客户</span>";
            }
            else
            {
                return args = "<span style='color:blue'>老客户</span>";
            }
        }


        /// <summary>
        /// 业务员
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string touser(string userid) 
        {
            return LoginInfoManager.getLoginInfoById(Convert.ToInt32(userid)).Cname;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            dataBind();
        }
    }
}