using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Text;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectPayerUnit : System.Web.UI.Page
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
            string cusname = Request.QueryString["cusName"];
            if (!string.IsNullOrEmpty(cusname) && cusname == "c")
                hidcusname.Value = "c";

            string sqlstr = "";
            sqlstr += FilterSql;
            Data data = new Data();
            DataTable dt = new DataTable();
            AspNetPager1.RecordCount = data.GetCount("Customer", sqlstr);
            dt = data.GetList("Customer", "Id", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
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


        //#region ****************************方法****************************

        ///// <summary>
        ///// 绑定客户列表数据
        ///// </summary>
        //private void BindRpCustomerList()
        //{
        //    string where = "cusPro = 1 AND used = 1 ";
        //    AspNetPager1.RecordCount = CustomerManager.GetTotalCount(where);
        //    AspNetPager1.NumericButtonCount = 10;
        //    AspNetPager1.PageSize = 10;

        //    RpCustomerList.DataSource = CustomerManager.GetListByPage(where, AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
        //    RpCustomerList.DataBind();
        //}

        ///// <summary>
        ///// 绑定公司列表数据
        ///// </summary>
        //private void BindRpCompanyList()
        //{
        //    AspNetPager2.RecordCount = CompanyManager.GetTotalCount("");
        //    AspNetPager2.NumericButtonCount = 10;
        //    AspNetPager2.PageSize = 10;

        //    RpCompanyList.DataSource = CompanyManager.GetListByPage("", AspNetPager2.StartRecordIndex, AspNetPager2.EndRecordIndex);
        //    RpCompanyList.DataBind();
        //}

        //#endregion


        //#region ****************************事件****************************

        ///// <summary>
        ///// 客户列表翻页时触发
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    BindRpCustomerList();
        //}

        ///// <summary>
        ///// 公司列表翻页时触发
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        //{
        //    BindRpCompanyList();
        //}

        //#endregion
    }
}