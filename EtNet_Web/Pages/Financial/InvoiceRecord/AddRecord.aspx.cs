using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial.InvoiceRecord
{
    public partial class AddRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }

        /// <summary>
        /// 初始化页面信息
        /// </summary>
        private void InitData()
        {
            lblRecordDate.Text = txtInvoiceDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); //默认开票日期和登记日期

            LoginInfo currentUser = Session["login"] as LoginInfo;
            if (currentUser != null)
            {
                lblRecordMan.Text = currentUser.Cname;
            }
        }

        /// <summary>
        /// 保存开票信息
        /// </summary>
        private void Save()
        {
            EtNet_Models.InvoiceRecord model = new EtNet_Models.InvoiceRecord();
            LoginInfo currentUser = Session["login"] as LoginInfo;
            model.recordDate = DateTime.Parse(txtInvoiceDate.Text);
            model.makeDate = DateTime.Now;
            model.makeMan = currentUser.Cname;
            model.makeId = currentUser.Id;
            model.makeRemark = txtRemakr.Text;
            model.amount = double.Parse(hidAmount.Value);
            model.cusId = int.Parse(hidComID.Value);
            model.cusName = txtUnit.Text;

            int id = InvoiceRecordManager.Add(model);

            if (id > 0)
            {
                SaveDetail(id);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert('保存成功');self.location.href='RecordList.aspx';", true);
            }
        }

        /// <summary>
        /// 保存明细信息
        /// </summary>
        /// <param name="InvoiceId"></param>
        private void SaveDetail(int InvoiceId)
        {
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