using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Financial.InvoiceRecord
{
    public partial class SelectOrderCollect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrderCollectList();
            }
        }

        /// <summary>
        /// 加载订单的收款信息
        /// </summary>
        private void LoadOrderCollectList()
        {
            string cusId = Request.QueryString["cusId"];
            string sql = " iscancel='N'";
            if (!string.IsNullOrEmpty(cusId))
            {
                sql += " and cusId = " + cusId;
                sql += " and canAmount > 0 "; //已开完票的订单数据不显示
                rpOrderCollectList.DataSource = To_OrderCollectDetialManager.GetOrderCollectInvoice(sql);
                rpOrderCollectList.DataBind();
            }
        }
    }
}