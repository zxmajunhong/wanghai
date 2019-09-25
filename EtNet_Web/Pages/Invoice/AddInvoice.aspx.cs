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
    public partial class AddInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                else
                {
                    bindSource();

                }
            }
        }

        private void bindSource()
        {
            LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            //this.txtInvoiceID.Value = "FP" + DateTime.Now.ToString("yyyyMMddHHmmss");
            this.txtInvoiceDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

            this.lblCMan.Text = login.Cname.ToString();
            this.lblCDepart.Text = DepartmentInfoManager.getDepartmentInfoById(login.Departid).Departcname;
            this.lblCDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void sessionType(string type)
        {
            string typename = this.ddlType.SelectedValue;
            Session["type"] = typename;
        }

        protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
        {
            addinvoice();
        }


        private void addinvoice()
        {
            int id = Convert.ToInt32(this.txtInvoiceID.Value.ToString());
            int idsum = To_InvoiceManager.getInvoiceById(id);
        

            if (idsum == 0)
            {
                LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
                To_Invoice invoice = new To_Invoice();
                //创建
                invoice.InvoiceCDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                invoice.InvoiceCDepartment = DepartmentInfoManager.getDepartmentInfoById(login.Departid).Departid;
                invoice.InvoiceCMan = login.Id;
                //发票
                invoice.InvoiceDate = DateTime.Parse(this.txtInvoiceDate.Value.ToString());
                invoice.InvoiceID = this.txtInvoiceID.Value.ToString();
                invoice.InvoiceID = this.txtInvoiceID.Value.ToString();
                invoice.InvoiceUnit = this.txtUnit.Value.ToString();
                invoice.Remark = this.txtRemark.Value.ToString();
                invoice.Selasmane = Convert.ToInt32(this.HidSalesman.Value.ToString());
                invoice.Department = this.txtDepart.Value.ToString();
                invoice.Sum = float.Parse(this.txtSum.Value);
                invoice.InvoiceType = this.ddlType.SelectedItem.Text.ToString();
                invoice.Upfile = "";
                invoice.IsSure = this.ChkConfirm.Checked ? 1 : 0;
            
                int count = To_InvoiceManager.addTo_Invoice(invoice);

                if (count > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');location.href='../Invoice/InvoiceList.aspx'", true);
              
                    addcombank();
                }

            }
            else
            {

                lblInvoiceID.Text = "<font color='red'>发票号码已存在!</font>";
                this.policyList.InnerHtml = this.hidTable.Value;
               
            }

        }

        protected void imgbtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InvoiceList.aspx");
            
        }


        //添加详细信息
        private void addcombank()
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
    }
}