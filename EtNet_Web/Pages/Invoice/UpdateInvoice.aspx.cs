using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Invoice
{
    public partial class UpdateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindPage();
            }
        }


        private void bindPage()
        {
            string id = Request.QueryString["id"].ToString();
            To_Invoice invoice = To_InvoiceManager.getTo_InvoiceById(Convert.ToInt32(id));

            this.lblCDate.Value = invoice.InvoiceCDate.ToString("yyyy-MM-dd");
            this.lblCDepart.Value = DepartmentInfoManager.getDepartmentInfoById(invoice.InvoiceCDepartment).Departcname.ToString();
            this.lblCMan.Value = LoginInfoManager.getLoginInfoById(invoice.InvoiceCMan).Cname.ToString();
            this.txtInvoiceID.Value = invoice.InvoiceID.ToString();
            this.txtDepart.Value = invoice.Department.ToString();
            this.txtInvoiceDate.Value = invoice.InvoiceDate.ToString("yyyy-MM-dd");
            this.txtRemark.Value = invoice.Remark.ToString();
            this.TxtSalesman.Value = LoginInfoManager.getLoginInfoById(invoice.Selasmane).Cname.ToString();
            this.HidSalesman.Value = invoice.Selasmane.ToString();
            this.txtSum.Value = invoice.Sum.ToString();
            this.txtUnit.Value = invoice.InvoiceUnit.ToString();
            this.ddlType.Items.FindByText(invoice.InvoiceType).Selected = true;
            this.ChkConfirm.Checked = invoice.IsSure == 1;
            //rpBind(invoice.Id.ToString());
            rpBind(id.ToString());



        }

        protected void imgbtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InvoiceList.aspx");
        }

        protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
        {
            add();
        }

        private void add()
        {
            LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            To_Invoice invoice = new To_Invoice();
            //创建
            invoice.Id = Convert.ToInt32(Request.QueryString["id"]);
            invoice.InvoiceCDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            invoice.InvoiceCDepartment = DepartmentInfoManager.getDepartmentInfoById(login.Departid).Departid;
            invoice.InvoiceCMan = login.Id;
            //发票
            invoice.InvoiceDate = DateTime.Parse(this.txtInvoiceDate.Value.ToString());
            invoice.InvoiceID = this.txtInvoiceID.Value.ToString();
            invoice.InvoiceUnit = this.txtUnit.Value.ToString();
            invoice.Remark = this.txtRemark.Value.ToString();
            invoice.Selasmane = Convert.ToInt32(this.HidSalesman.Value.ToString());
            invoice.Department = this.txtDepart.Value.ToString();
            invoice.Sum = float.Parse(this.txtSum.Value);
            invoice.InvoiceType = this.ddlType.SelectedItem.Text.ToString();
            invoice.Upfile = "";
            invoice.IsSure = this.ChkConfirm.Checked ? 1 : 0;
            int count = To_InvoiceManager.updateTo_Invoice(invoice);

            if (count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功！');location.href='../Invoice/InvoiceList.aspx'", true);
                addcombank();
                //addcombank();
            }
        }

        private void rpBind(string invoiceID)
        {
            IList<To_InvoiceDetial> detial = To_InvoiceDetialManager.getTo_InvoiceDetialByInvoiceId(invoiceID);
            this.rpPolicyDetial.DataSource = detial;
            this.rpPolicyDetial.DataBind();
        }


        //添加其他银行
        private void addcombank()
        {
            string id = Request.QueryString["id"].ToString();
            To_InvoiceDetialManager.deleteTo_InvoiceDetialByInvoiceID(Convert.ToInt32(id));

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

    }
}