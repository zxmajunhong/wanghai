using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Financial.InvoiceRecord
{
    public partial class EditRecord : System.Web.UI.Page
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
            if(!string.IsNullOrEmpty(Id))
            {
                EtNet_Models.InvoiceRecord model = InvoiceRecordManager.GetModel(int.Parse(Id));
                txtInvoiceDate.Text = model.recordDate.ToString("yyyy-MM-dd");
                lblAmount.Text = model.amount.ToString("F2");
                hidAmount.Value = model.amount.ToString();
                txtUnit.Text = model.cusName;
                hidComID.Value = model.cusId.ToString();
                txtRemakr.Text = model.makeRemark;
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

        /// <summary>
        /// 保存数据
        /// </summary>
        private void Save()
        {
            string Id = Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                EtNet_Models.InvoiceRecord model = InvoiceRecordManager.GetModel(int.Parse(Id));
                model.recordDate = DateTime.Parse(txtInvoiceDate.Text);
                model.makeRemark = txtRemakr.Text;
                model.amount = double.Parse(hidAmount.Value);

                bool result = InvoiceRecordManager.Update(model);
                if (result)
                {
                    SaveDetail(int.Parse(Id));
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert('保存成功');self.location.href='RecordList.aspx';", true);
                }
            }
        }

        /// <summary>
        /// 保存明细数据
        /// </summary>
        /// <param name="InvoiceId"></param>
        private void SaveDetail(int InvoiceId)
        {
            bool result = InvoiceRecordDetailManager.DeleteByInoviceId(InvoiceId);
            if (hidInvoiceDetail.Value.Trim() != string.Empty)
            {
                string[] items = hidInvoiceDetail.Value.Trim().TrimEnd('@').Split('@');
                if (items.Length > 0)
                {
                    InvoiceRecordDetail model = new InvoiceRecordDetail();
                    foreach (string item in items)
                    {
                        string[] detail = item.Trim().Split('$');
                        if (detail.Length > 0)
                        {
                            model.invoiceId = InvoiceId;
                            model.orderCollectId = int.Parse(detail[0]);
                            model.orderNum = detail[1];
                            model.shouldMoney = double.Parse(detail[2]);
                            model.invoiceMoney = double.Parse(detail[3]);

                            InvoiceRecordDetailManager.Add(model);
                        }
                    }
                }
            }
        }

        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            Save();
        }
    }
}