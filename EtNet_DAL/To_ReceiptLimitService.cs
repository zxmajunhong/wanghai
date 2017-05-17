using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EtNet_DAL
{
    public class To_ReceiptLimitService
    {

        public static void AddLimit(string userID, string receiptID)
        {


            StringBuilder sqlText = new StringBuilder();
            sqlText.Append("UPDATE To_ReceiptLimit SET receiptList = receiptList+@receiptList WHERE userID = @userID ");
            sqlText.Append("IF @@ROWCOUNT = 0 ");
            sqlText.Append("BEGIN ");
            sqlText.Append("INSERT INTO To_ReceiptLimit (userID, receiptList) VALUES (@userID, @receiptList) ");
            sqlText.Append("END ");




            using (SqlConnection connection = new SqlConnection(DBHelper.connectionString))
            {
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand();

                sqlCmd.Parameters.AddRange(new SqlParameter[]{
                    new SqlParameter("@userID",userID),
                    new SqlParameter("@receiptList",receiptID)
                });

                sqlCmd.Connection = connection;
                sqlCmd.CommandText = sqlText.ToString();

                sqlCmd.ExecuteNonQuery();
            }
        }

        public static string GetReceiptList(int userID)
        {
            string sql = "select receiptList from To_ReceiptLimit where userID=@userID";

            using (SqlConnection connection=new SqlConnection(DBHelper.connectionString))
            {
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.Add(new SqlParameter("@userID", userID));

                object result = sqlCmd.ExecuteScalar();

                return result == null ? "" : result.ToString().Trim(',');
            }
        }
    }
}
