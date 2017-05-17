using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace EtNet_DAL
{
    public class InvoiceRecordDetailService
    {
        public static bool Add(EtNet_Models.InvoiceRecordDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InvoiceRecordDetail (");
            strSql.Append("invoiceId,orderNum,orderCollectId,shouldMoney,invoiceMoney");
            strSql.Append(") values (");
            strSql.Append("@invoiceId,@orderNum,@orderCollectId,@shouldMoney,@invoiceMoney)");
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@invoiceId",model.invoiceId),
                new SqlParameter("@orderNum",model.orderNum),
                new SqlParameter("@orderCollectId",model.orderCollectId),
                new SqlParameter("@shouldMoney",model.shouldMoney),
                new SqlParameter("@invoiceMoney",model.invoiceMoney)
            };

            int result = DBHelper.ExecuteCommand(strSql.ToString(), sp);
            return result > 0;
        }

        public static DataTable GetList(string strWhere)
        {
            string sql = " select * from View_HasInvoiceDetail ";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DBHelper.GetDataSet(sql);
        }

        public static bool DeleteByInoviceId(int InvoiceId)
        {
            string sql = " delete InvoiceRecordDetail where invoiceId=@invoiceId";
            SqlParameter[] sp = new SqlParameter[] 
            {
                new SqlParameter("@invoiceId",InvoiceId)
            };

            int result = DBHelper.ExecuteCommand(sql, sp);
            return result > 0;
        }

    }
}
