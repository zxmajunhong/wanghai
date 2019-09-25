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
    public partial class CopyInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindPage();
            }
        }


        private void rpBind(string invoiceID)
        {
            IList<To_InvoiceDetial> detial = To_InvoiceDetialManager.getTo_InvoiceDetialByInvoiceId(invoiceID);
            this.rpPolicyDetial.DataSource = detial;
            this.rpPolicyDetial.DataBind();
        }

        private void bindPage()
        {
            LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            //this.txtInvoiceID.Value = "FP" + DateTime.Now.ToString("yyyyMMddHHmmss");
            this.txtInvoiceDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string id = Request.QueryString["id"].ToString();
            To_Invoice invoice = To_InvoiceManager.getTo_InvoiceById(Convert.ToInt32(id));

            this.lblCDate.Text = invoice.InvoiceCDate.ToString();
            this.lblCDepart.Text = DepartmentInfoManager.getDepartmentInfoById(invoice.InvoiceCDepartment).Departcname.ToString();
            this.lblCMan.Text = LoginInfoManager.getLoginInfoById(invoice.InvoiceCMan).Cname.ToString();
            
            this.txtDepart.Value = invoice.Department.ToString();
           
            this.txtRemark.Text = invoice.Remark.ToString();
            this.TxtSalesman.Value = LoginInfoManager.getLoginInfoById(invoice.Selasmane).Cname.ToString();
            this.HidSalesman.Value = invoice.Selasmane.ToString();
            this.txtSum.Value = invoice.Sum.ToString();
            this.txtUnit.Value = invoice.InvoiceUnit.ToString();
            this.ddlType.SelectedValue = invoice.InvoiceType.ToString();
            //rpBind(invoice.Id.ToString());
            rpBind(id.ToString());
        }



        //添加
        private void addinvoice()
        {
            LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            To_Invoice invoice = new To_Invoice();
            //创建
            invoice.InvoiceCDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            invoice.InvoiceCDepartment = DepartmentInfoManager.getDepartmentInfoById(login.Departid).Departid;
            invoice.InvoiceCMan = login.Id;
            //发票
            invoice.InvoiceDate = DateTime.Parse(this.txtInvoiceDate.Value.ToString());
            invoice.InvoiceID = this.txtInvoiceID.Value.ToString();
            invoice.InvoiceUnit = this.txtUnit.Value.ToString();
            invoice.Remark = this.txtRemark.Text.ToString();
            invoice.Selasmane = Convert.ToInt32(this.HidSalesman.Value.ToString());
            invoice.Department = this.txtDepart.Value.ToString();
            invoice.Sum = float.Parse(this.txtSum.Value);
            invoice.InvoiceType = this.ddlType.SelectedItem.Text.ToString();
            invoice.Upfile = "";
            int count = To_InvoiceManager.addTo_Invoice(invoice);

            if (count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');location.href='../Invoice/InvoiceList.aspx'", true);
                adddetial();
            }

        }

        private void adddetial()
        {
            string policyList = this.HidPolicy.Value;
            if (policyList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.To_InvoiceDetial invoiceDetial = null;
                if (policyList.IndexOf(',') >= 0) { row = policyList.Split(','); }
                else { row = new string[1] { policyList }; }
                for (int i = 0; i < row.Length; i++)
                {
                    invoiceDetial = new To_InvoiceDetial();
                    cell = row[i].Split('|');
                    invoiceDetial.PolicyID = cell[0];
                    invoiceDetial.CusName = cell[1];
                    invoiceDetial.Cost = float.Parse(cell[2]);
                    invoiceDetial.DetialReamrk = "";
                    invoiceDetial.InvoiceID = To_InvoiceManager.getTo_InvoiceLastONE().Id;
                    To_InvoiceDetialManager.addTo_InvoiceDetial(invoiceDetial);
                }
            }
        }


        protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
        {
            addinvoice();
        }

        protected void imgbtnBack_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}