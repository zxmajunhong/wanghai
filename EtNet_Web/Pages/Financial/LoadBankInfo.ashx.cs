using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using EtNet_BLL;
using System.Data;
using System.Web.Script.Serialization;

namespace EtNet_Web.Pages.Financial
{
    /// <summary>
    /// LoadBankInfo 的摘要说明
    /// </summary>
    public class LoadBankInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "html";
            //context.Response.Write("Hello World");

            //要执行的方法
            object argMethod = context.Request.QueryString["m"];
            if (argMethod == null)
            {
                context.Response.Write(string.Empty);
                return;
            }

            string method = argMethod.ToString();

            //付款单位类别
            object argPayerType = context.Request.QueryString["type"];
            //付款单位ID或银行ID
            object argPayerID = context.Request.QueryString["ID"];

            if (argPayerType == null || argPayerID == null)
            {
                context.Response.Write(string.Empty);
                return;
            }

            int payerType = 0, payerID = 0;
            if (!int.TryParse(argPayerType.ToString(), out payerType) || !int.TryParse(argPayerID.ToString(), out payerID))
            {
                context.Response.Write(string.Empty);
                return;
            }


            string result = string.Empty;

            switch (method)
            {
                case "getlist":
                    result = GetBankList(payerType, payerID);
                    break;
                case "getinfo":
                    context.Response.ContentType = "text/javascript";
                    result = GetBankInfo(payerType, payerID);
                    break;
                default:
                    break;
            }

            context.Response.Write(result);
        }

        /// <summary>
        /// 获取银行列表，用于绑定下拉框
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetBankList(int type, int id)
        {
            string result = string.Empty;
            switch (type)
            {
                case 0:
                    result = GetCustomerBankList(id);
                    break;
                case 1:
                    result = GetCompanyBankList(id);
                    break;
                default:
                    break;
            }
            return result;
        }


        /// <summary>
        /// 获取银行信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetBankInfo(int type, int id)
        {
            string result = string.Empty;
            switch (type)
            {
                case 0:
                    result = GetCustomerBankInfo(id);
                    break;
                case 1:
                    result = GetCompanyBankInfo(id);
                    break;
                default:
                    break;
            }
            return result;
        }


        /// <summary>
        /// 获取客户银行列表
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        private string GetCustomerBankList(int customerID)
        {
            DataTable dtBankList = CusBankManager.getList(customerID);

            StringBuilder htmlBuilder = new StringBuilder();

            EtNet_Models.Customer customer = CustomerManager.getCustomerById(customerID);

            if (customer != null && customer.Bank.Trim() != string.Empty)
            {
                htmlBuilder.AppendFormat("<option value=\"{0}\">", customer.CardId + "$" + customer.CardName + "$" + customer.Remark);
                //htmlBuilder.Append("<option value=\"0\">");
                htmlBuilder.Append(customer.Bank);
                htmlBuilder.Append("</option>");
            }

            if (dtBankList.Rows.Count > 0)
            {
                int rowCount = dtBankList.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow currentRow = dtBankList.Rows[i];
                    htmlBuilder.AppendFormat("<option value=\"{0}\">", currentRow["id"]);
                    htmlBuilder.Append(currentRow["bank"]);
                    htmlBuilder.Append("</option>");
                }
            }

            return htmlBuilder.ToString();
        }


        /// <summary>
        /// 获取公司银行列表
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        private string GetCompanyBankList(int companyID)
        {
            DataTable dtBankList = ComBankManager.getList(companyID);

            StringBuilder htmlBuilder = new StringBuilder();

            EtNet_Models.Company company = CompanyManager.getCompanyById(companyID);

            if (company != null)
            {
                htmlBuilder.AppendFormat("<option value=\"{0}\">", company.CardId + "$" + company.CardName + "$" + company.Remark);
                //htmlBuilder.Append("<option value=\"0\">");
                htmlBuilder.Append(company.Bank);
                htmlBuilder.Append("</option>");
            }

            if (dtBankList.Rows.Count > 0)
            {
                int rowCount = dtBankList.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow currentRow = dtBankList.Rows[i];
                    htmlBuilder.AppendFormat("<option value=\"{0}\">", currentRow["id"]);
                    htmlBuilder.Append(currentRow["bank"]);
                    htmlBuilder.Append("</option>");
                }
            }

            return htmlBuilder.ToString();
        }

        /// <summary>
        /// 获取客户银行信息
        /// </summary>
        /// <param name="bankID"></param>
        /// <returns></returns>
        private string GetCustomerBankInfo(int bankID)
        {
            string result = string.Empty;

            EtNet_Models.CusBank bankInfo = CusBankManager.getCusBankById(bankID);
            if (bankInfo != null)
            {
                result = string.Format("{0}\"account\":\"{1}\",\"accountname\":\"{2}\",\"mark\":\"{3}\"{4}"
                    , "{", bankInfo.CardId, bankInfo.CardName, bankInfo.Remark, "}");
            }

            return result;
        }


        /// <summary>
        /// 获取公司银行信息
        /// </summary>
        /// <param name="bankID"></param>
        /// <returns></returns>
        private string GetCompanyBankInfo(int bankID)
        {
            string result = string.Empty;

            EtNet_Models.ComBank bankInfo = ComBankManager.getComBankById(bankID);
            if (bankInfo != null)
            {
                result = string.Format("{0}\"account\":\"{1}\",\"accountname\":\"{2}\",\"mark\":\"{3}\"{4}"
                    , "{", bankInfo.CardId, bankInfo.CardName, bankInfo.Remark, "}");
            }

            return result;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}