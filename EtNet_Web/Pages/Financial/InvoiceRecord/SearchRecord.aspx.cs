using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Financial.InvoiceRecord
{
    public partial class SearchRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Record_Load();
            }
        }

        /// <summary>
        /// 加载开票信息
        /// </summary>
        private void Record_Load()
        {
            string Id = Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                EtNet_Models.InvoiceRecord model = InvoiceRecordManager.GetModel(int.Parse(Id));
                lblInvoiceDate.Text = model.recordDate.ToString("yyyy-MM-dd");
                lblAmount.Text = model.amount.ToString("F2");
                lblUnit.Text = model.cusName;
                lblRemark.Text = model.makeRemark;
                lblRecordDate.Text = model.makeDate.ToString("yyyy-MM-dd");
                lblRecordMan.Text = model.makeMan;

                RecordDetail_Load(Id);
            }
        }

        /// <summary>
        /// 加载明细数据
        /// </summary>
        /// <param name="Id"></param>
        private void RecordDetail_Load(string Id)
        {
            string strWhere = " invoiceId = " + Id;
            DataTable dt = InvoiceRecordDetailManager.GetList(strWhere);
            rpRecordList.DataSource = dt;
            rpRecordList.DataBind();

            double total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += Convert.ToDouble(dt.Rows[i]["invoiceMoney"]);
            }

            this.hasSumBox.InnerText = total.ToString("F2");
        }
    }
}