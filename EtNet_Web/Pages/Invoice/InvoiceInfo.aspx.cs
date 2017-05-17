using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Invoice
{
    public partial class InvoiceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddata();
            }
        }


        private void binddata()
        {

            string id = Request.QueryString["id"].ToString();
            To_Invoice invoice = To_InvoiceManager.getTo_InvoiceById(Convert.ToInt32(id));
            this.lblInvoiceID.Text = invoice.InvoiceID.ToString();
            this.lblInvoiceDate.Text = invoice.InvoiceDate.ToString("yyyy-MM-dd");
            this.lblInvoiceDepart.Text = invoice.Department.ToString();
            this.lblInvoiceRemark.Text = invoice.Remark.ToString();
            this.lblInvoiceUnit.Text = invoice.InvoiceUnit.ToString();
            this.lblSalesman.Text = LoginInfoManager.getLoginInfoById(invoice.Selasmane).Cname.ToString();
            this.lblCost.Text = invoice.Sum.ToString()+".00";
            this.lblCDate.Text = invoice.InvoiceCDate.ToString("yyyy-MM-dd");
            this.lblCDepart.Text = DepartmentInfoManager.getDepartmentInfoById(invoice.InvoiceCDepartment).Departcname.ToString();
            this.lblCMan.Text = LoginInfoManager.getLoginInfoById(invoice.InvoiceCMan).Cname.ToString();
            this.lblInvoiceType.Text = invoice.InvoiceType.ToString();
            lblState.Text = invoice.IsSure == 1 ? "已确认" : "<font color='red'>未确认</font>";
            rpBind(invoice.Id.ToString());

        }

        private void rpBind(string invoiceID)
        {
            IList<To_InvoiceDetial> detial = To_InvoiceDetialManager.getTo_InvoiceDetialByInvoiceId(invoiceID);
            this.rpPolicyDetial.DataSource = detial;
            this.rpPolicyDetial.DataBind();
        }

        protected void imgbtnback_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InvoiceList.aspx");
        }

    }
}