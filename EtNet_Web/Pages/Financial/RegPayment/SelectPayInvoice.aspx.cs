using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Financial.RegPayment
{
    public partial class SelectPayInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInvoiceList();
            }
        }

        /// <summary>
        /// 加载发票数据
        /// </summary>
        private void LoadInvoiceList()
        {
            DataTable dtInvoiceList = EtNet_BLL.To_InvoiceManager.GetUnpaidInvoice();

            rpInvoiceList.DataSource = dtInvoiceList.DefaultView;
            rpInvoiceList.DataBind();
        }
    }
}