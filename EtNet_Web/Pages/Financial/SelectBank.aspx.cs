using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //付款单位类别
                object argPayerType = Request.QueryString["type"];
                //付款单位ID
                object argPayerID = Request.QueryString["id"];

                if (argPayerType == null || argPayerID == null)
                { return; }

                int payerType = 0, payerID = 0;
                if (!int.TryParse(argPayerType.ToString(), out payerType) || !int.TryParse(argPayerID.ToString(), out payerID))
                { return; }

                BindBankList(payerType, payerID);
            }
        }

        /// <summary>
        /// 绑定银行列表
        /// </summary>
        private void BindBankList(int payerType, int payerID)
        {
            DataTable dtBankList = new DataTable();

            dtBankList.Columns.AddRange(new DataColumn[] { 
                new DataColumn("bankId"),
                new DataColumn("bankName"),
                new DataColumn("bankAccount"),
                new DataColumn("bankUser"),
                new DataColumn("bankMark")
            });

            if (payerType == 0) { FillCustomerBank(dtBankList, payerID); }
            else { FillCompanyBank(dtBankList, payerID); }

            RpBankList.DataSource = dtBankList;
            RpBankList.DataBind();
        }

        /// <summary>
        /// 绑定客户银行列表
        /// </summary>
        private void FillCustomerBank(DataTable dtBankList, int customerID)
        {
            EtNet_Models.Customer customer = CustomerManager.getCustomerById(customerID);

            if (customer != null && customer.Bank.Trim() != string.Empty)
            {
                DataRow newRow = dtBankList.NewRow();

                newRow["bankId"] = 0;
                newRow["bankName"] = customer.Bank;// string.Format("{0}（主银行）", customer.Bank);
                newRow["bankAccount"] = customer.CardId;
                newRow["bankUser"] = customer.CardName;
                newRow["bankMark"] = customer.Remark;

                dtBankList.Rows.Add(newRow);
            }

            DataTable dtCustomerBankList = CusBankManager.getList(customerID);

            if (dtCustomerBankList.Rows.Count > 0)
            {
                int rowCount = dtCustomerBankList.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow currentRow = dtCustomerBankList.Rows[i];
                    DataRow newRow = dtBankList.NewRow();

                    newRow["bankId"] = currentRow["id"];
                    newRow["bankName"] = currentRow["bank"];
                    newRow["bankAccount"] = currentRow["cardId"];
                    newRow["bankUser"] = currentRow["cardName"];
                    newRow["bankMark"] = currentRow["remark"];

                    dtBankList.Rows.Add(newRow);
                }
            }
        }

        /// <summary>
        /// 绑定公司银行列表
        /// </summary>
        private void FillCompanyBank(DataTable dtBankList, int companyID)
        {
            EtNet_Models.Company company = CompanyManager.getCompanyById(companyID);

            if (company != null && company.Bank.Trim() != string.Empty)
            {
                DataRow newRow = dtBankList.NewRow();

                newRow["bankId"] = 0;
                newRow["bankName"] = company.Bank;// string.Format("{0}（主银行）", company.Bank);
                newRow["bankAccount"] = company.CardId;
                newRow["bankUser"] = company.CardName;
                newRow["bankMark"] = company.Remark;

                dtBankList.Rows.Add(newRow);
            }

            DataTable dtCompanyBankList = ComBankManager.getList(companyID);

            if (dtCompanyBankList.Rows.Count > 0)
            {
                int rowCount = dtCompanyBankList.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow currentRow = dtCompanyBankList.Rows[i];
                    DataRow newRow = dtBankList.NewRow();

                    newRow["bankId"] = currentRow["id"];
                    newRow["bankName"] = currentRow["bank"];
                    newRow["bankAccount"] = currentRow["cardId"];
                    newRow["bankUser"] = currentRow["cardName"];
                    newRow["bankMark"] = currentRow["remark"];

                    dtBankList.Rows.Add(newRow);
                }
            }
        }
    }
}