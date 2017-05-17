using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace EtNet_DAL.ViewDAL
{
    public class ViewAuditJobFlowService
    {
        public static DataTable getList( string strWhere)
        {
            string strSql = "select * from ViewAuditJobFlow ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);

        }



        public static DataTable getList(string filter, string strWhere)
        {
            string strSql = "select distinct ";
            strSql +=  filter;
            strSql += " from ViewAuditJobFlow ";
          
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);

        }






    }
}
