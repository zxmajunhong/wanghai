using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectPayer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRpCustomerList();
                BindRpCompanyList();
            }
        }


        #region ****************************方法****************************

        /// <summary>
        /// 绑定客户列表数据
        /// </summary>
        private void BindRpCustomerList()
        {
            string where = "cusPro = 1 AND used = 1 ";
            AspNetPager1.RecordCount = CustomerManager.GetTotalCount(where);
            AspNetPager1.NumericButtonCount = 10;
            AspNetPager1.PageSize = 10;

            RpCustomerList.DataSource = CustomerManager.GetListByPage(where, AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            RpCustomerList.DataBind();
        }

        /// <summary>
        /// 绑定公司列表数据
        /// </summary>
        private void BindRpCompanyList()
        {
            AspNetPager2.RecordCount = CompanyManager.GetTotalCount("");
            AspNetPager2.NumericButtonCount = 10;
            AspNetPager2.PageSize = 10;

            RpCompanyList.DataSource = CompanyManager.GetListByPage("", AspNetPager2.StartRecordIndex, AspNetPager2.EndRecordIndex);
            RpCompanyList.DataBind();
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
            BindRpCustomerList();
        }

        /// <summary>
        /// 公司列表翻页时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindRpCompanyList();
        }

        #endregion
    }
}