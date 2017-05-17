using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DbAccess
{
   public  class RunProcedure
    {
       public  DataSet RunPro(string connectionString, string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connectionString, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                return dataSet;
            }
        }
        public  SqlCommand BuildQueryCommand(string connectionString, string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;

        }


        public  DataSet ReturnPageList(string connectionString, string procName, string tblName, string fieldKey, string fieldNameShow, int pageSize, int pageIndex, string fieldOrder, bool Order, string fieldWhere, bool Distinct, out int pageCount, out int Counts, out string strSql)
        {
            SqlParameter[] commandParameters = new SqlParameter[] 
         {  
             new SqlParameter("@tblName", SqlDbType.NVarChar), 
             new SqlParameter("@fieldKey", SqlDbType.NVarChar), 
             new SqlParameter("@fieldNameShow", SqlDbType.NVarChar), 
             new SqlParameter("@pageSize", SqlDbType.Int),
             new SqlParameter("@pageCurrentSize", SqlDbType.Int), 
             new SqlParameter("@fieldOrder", SqlDbType.NVarChar), 
             new SqlParameter("@Order", SqlDbType.Bit), 
             new SqlParameter("@fieldWhere", SqlDbType.NVarChar,1000), 
             new SqlParameter("@fieldDistinct", SqlDbType.Bit), 
             new SqlParameter("@pageCount", SqlDbType.Int,4), 
             new SqlParameter("@Counts", SqlDbType.Int,4), 
             new SqlParameter("@strSql", SqlDbType.NVarChar,1000) 
         };
            commandParameters[0].Value = tblName;
            commandParameters[1].Value = fieldKey;
            commandParameters[2].Value = (fieldNameShow == null) ? "*" : fieldNameShow;
            commandParameters[3].Value = pageSize;
            commandParameters[4].Value = pageIndex;
            commandParameters[5].Value = fieldOrder;
            commandParameters[6].Value = Order;
            commandParameters[7].Value = (fieldWhere == null) ? "" : fieldWhere;
            commandParameters[8].Value = Distinct;
            commandParameters[9].Direction = ParameterDirection.Output;
            commandParameters[10].Direction = ParameterDirection.Output;
            commandParameters[11].Direction = ParameterDirection.Output;
            DataSet ds = RunPro(connectionString,procName, commandParameters, tblName);
            pageCount = (int)commandParameters[9].Value;
            Counts = (int)commandParameters[10].Value;
            strSql = commandParameters[11].Value.ToString();
            return ds;


        }
       
    }
}
