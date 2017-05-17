using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Text;
using EtNet_Models;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Financial.FundAllocation
{
    public partial class SelectPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int salesman = Convert.ToInt32(Request.QueryString["salesman"]);
                int payerId = Convert.ToInt32(Request.QueryString["payer"]);
                int payerType = Convert.ToInt32(Request.QueryString["payertype"]);
                string receiptType = Request.QueryString["type"].ToString();

                LoadPolicyList(salesman, payerId, payerType, receiptType);
            }
        }

        private void LoadPolicyList(int salesman, int payerID, int payerType, string receiptType)
        {

            ViewBudgetIncomeManager budgetBLL = new ViewBudgetIncomeManager();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" policySalesman={0} ", salesman);
            sql.AppendFormat(" and {0} is not null ", receiptType);
            sql.AppendFormat(" and auditstatus = '04' ");

            if (payerType == 1)
            {
                sql.AppendFormat(" and company={0} ", payerID);
            }
            else
            {
                sql.AppendFormat(" and customer={0} ", payerID);
            }

            sql.AppendFormat(" and ({0} >realAmount or realAmount is null) ", receiptType);

            //Data data = new Data();
            //DataSet ds = data.DataPage("ViewClaim", "policyID", "*", sql.ToString(), "policyID", true, 10, 5, pages);

            RpPolicyList.DataSource = budgetBLL.GetListByPage(sql.ToString());
            RpPolicyList.DataBind();
        }


        protected string GetReceiptType()
        {
            return Request.QueryString["type"].ToString();
        }

        protected string GetAmount(object amount,object realAmount)
        {
            if (realAmount == DBNull.Value)
                return amount.ToString();

            return (Convert.ToDecimal(amount) - Convert.ToDecimal(realAmount)).ToString("F2");
            //To_ClaimDetailManager b_claimDetail = new To_ClaimDetailManager();

            //if (!b_claimDetail.Exists(policyID))
            //{
            //    return amount.ToString();
            //}

            //IList<To_ClaimDetail> list = b_claimDetail.GetModelList(string.Format("policyID={0}", policyID));

            //decimal realAmount=0;
            //foreach (To_ClaimDetail item in list)
            //{
            //    realAmount += item.realAmount;
            //}

            //return ((decimal)amount - realAmount).ToString("F2");
        }

    }
}