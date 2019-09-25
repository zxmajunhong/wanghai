using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using EtNet_BLL.DataPage;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Order
{
    public partial class SelectCusReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
                dataBind();
                BindTypes();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void dataBind()
        {
            #region 控制不能选择相同的单位代码（目前不用）
            //string returnid = Request.QueryString["unit"].ToString().Trim().TrimEnd(',');
            //returnid = "'" + returnid + "'";
            //string sqlstr = " and id not in (" + returnid + ")";
            //sqlstr += FilterSql;
            //Data data = new Data();
            //DataSet ds = data.DataPage("Factory", "id", "*", sqlstr, "id", true, 10, 5, pages);
            //RpCustomerList.DataSource = ds;
            //RpCustomerList.DataBind();
            #endregion

            string sqlstr = "";
            sqlstr += FilterSql;
            Data data = new Data();
            DataSet ds = data.DataPage("Factory", "id", "*", sqlstr, "id", true, 10, 5, pages);
            RpCustomerList.DataSource = ds;
            RpCustomerList.DataBind();

        }

        /// <summary>
        /// 类型
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string facttype(string id)
        {
            return FactTypeManager.getFactTypeById(Convert.ToInt32(id)).TypeName;
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
            int typesup = Convert.ToInt32(this.ddltype.SelectedValue);
            //string fullName = txtFullName.Value.Trim();
            string shortName = txtShortName.Value.Trim();

            StringBuilder filterBuilder = new StringBuilder();

            if (typesup != -1)
                filterBuilder.AppendFormat(" and facttype = {0}", typesup);

            if (shortName != string.Empty)
                filterBuilder.AppendFormat(" and factShortName like '%{0}%' ", txtShortName.Value.Trim());

            FilterSql = filterBuilder.ToString();
        }

        /// <summary>
        /// 加载类别
        /// </summary>
        public void BindTypes()
        {
            ddltype.Items.Clear();

            IList<FactType> typelist = FactTypeManager.getFactTypeAll();


            for (int i = 0; i < typelist.Count; i++)
            {
                ListItem list = new ListItem(typelist[i].TypeName, typelist[i].Id.ToString());
                ddltype.Items.Add(list);
            }
            ListItem ltem = new ListItem("选择类别", "-1");//添加第一行默认值
            ddltype.Items.Insert(0, ltem);//添加第一行默认值

        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            FilterSql = "";
            txtShortName.Value = "";
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