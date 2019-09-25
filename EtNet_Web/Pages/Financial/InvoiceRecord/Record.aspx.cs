using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial.InvoiceRecord
{
    public partial class Record : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrderInfo();
            }
        }

        /// <summary>
        /// 加载订单信息
        /// </summary>
        private void LoadOrderInfo()
        {
            string id = Request.QueryString["id"];
            id = "(" + id + ")";
            string sql = " and orderid in " + id;
            sql += Session["invoiceQuery"]; //收款单位
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("View_OrderAndClollect", "orderid", "*", sql, "orderNum", false, 5, 5, pages);
            payRepeater.DataSource = ds;
            payRepeater.DataBind();
        }

        /// <summary>
        /// 更新订单的方法
        /// </summary>
        private void UpdateOrder()
        {
            string orderid = Request.QueryString["id"];
            string[] orderids = orderid.Split(',');
            for (int i = 0; i < orderids.Length; i++)
            {
                To_OrderInfoManager.updateOrderInvoice(orderids[i], this.invoicStatus.SelectedValue);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert('更新成功');", true);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            UpdateOrder();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecordList.aspx");
        }


    }
}