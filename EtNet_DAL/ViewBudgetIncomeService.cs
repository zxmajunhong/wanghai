using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_DAL
{
    public class ViewBudgetIncomeService
    {
        public ViewBudgetIncomeService()
        { }
        #region  Method
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select serialnum,policy_date,policy_num,budgetID,income_premium,income_brokerageFees,income_serviceCharge,income_other1,income_other2,income_other3,income_other4,income_other5,income_other6,income_other7,income_other8,income_other9,income_other10,customer,company,policyID,salesman ");
            strSql.Append(" FROM ViewBudgetIncome ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.GetDataSet(strSql.ToString());
        }

        public DataTable GetListByPage(string where)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select * from (");
            sqlBuilder.Append("select policyID,");
            sqlBuilder.Append("max(serialnum) as serialnum,max(policy_date) as policy_date,max(policy_num) as policy_num,MAX(budgetID) as budgetID,MAX(income_premium) as income_premium,MAX(income_brokerageFees) as income_brokerageFees,MAX(income_serviceCharge) as income_serviceCharge,MAX(income_other1) as income_other1,MAX(income_other2) as income_other2,MAX(income_other3) as income_other3,MAX(income_other4) as income_other4,MAX(income_other5) as income_other5,MAX(income_other6) as income_other6,MAX(income_other7) as income_other7,MAX(income_other8) as income_other8,MAX(income_other9) as income_other9,MAX(income_other10) as income_other10,MAX(customer) as customer,MAX(company) as company,MAX(receiptAmount) as receiptAmount,MAX(claimAmount) as claimAmount,MAX(receiptStatusCode) as receiptStatusCode,MAX(mark) as mark,MAX(costType) as costType,MAX(payerType) as payerType,MAX(claimID) as claimID,MAX(payerID) as payerID,MAX(payer) as payer,MAX(salesman) as salesman,MAX(collectingID) as collectingID,MAX(policySalesman) as policySalesman,MAX(auditstatus) as auditstatus,sum(realAmount) as realAmount from ViewClaim ");
            sqlBuilder.Append("group by policyID ");
            sqlBuilder.Append(") as temp ");

            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.Append("where ");
                sqlBuilder.Append(where);
            }


            return DBHelper.GetDataSet(sqlBuilder.ToString());
        }

        #endregion  Method
    }
}
