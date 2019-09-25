using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_DAL.ViewDAL
{
    public  class ViewInformationService
    {
        public static DataTable getList(string strWhere)
        {
            string strSql = "select * from ViewInformation ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return DBHelper.GetDataSet(strSql);

        }



        public static DataTable getList(string fields,string strWhere)
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
            strSql += " from ViewInformation ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return DBHelper.GetDataSet(strSql);
        }


    }
}
