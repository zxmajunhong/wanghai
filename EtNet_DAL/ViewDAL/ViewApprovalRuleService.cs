using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EtNet_DAL.ViewDAL
{
    public class ViewApprovalRuleService
    {
        public static DataTable getList(string strWhere)
        {
            string strSql = "select * from ViewApprovalRule ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);

        }



        public static DataTable getList(string fields, string strWhere)
        {
            string strSql = "select ";
            if (fields != "")
            {
                strSql += fields;
            }
            else
            {
                strSql += " * ";
            }
            strSql += " from ViewApprovalRule ";
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
