using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectCollect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRpFactoryList();
            }
        }


        #region ****************************方法****************************

        /// <summary>
        /// 绑定客户列表数据
        /// </summary>
        private void BindRpFactoryList()
        {
            string sqlstr = "";
            sqlstr += FilterSql;
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("Factory", sqlstr);
            DataTable dt = data.GetList("Factory", "Id", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            RpfacttomerList.DataSource = dt;
            RpfacttomerList.DataBind();

        }

        #endregion


        #region ****************************事件****************************

        /// <summary>
        /// 客户列表翻页时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRpFactoryList();
        }

        

        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, ImageClickEventArgs e)
        {
            modeify();
            BindRpFactoryList();
        }

        private void modeify()
        {
            string strsql = "";
            if (this.txtskdw.Value != "")
            {
                strsql += " and factCode like '%" + this.txtskdw.Value.Trim() + "%'";
            }
            if (this.txtdwjc.Value != "")
            {
                strsql += " and factshortName like '%" + this.txtdwjc.Value.Trim() + "%'";
            }
            FilterSql = strsql;
        }


        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            this.txtskdw.Value = this.txtdwjc.Value = "";
            FilterSql = "";
            BindRpFactoryList();
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }

        #endregion
    }
}