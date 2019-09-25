using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_DAL.ViewDAL
{
    public  class ViewDocumentShareService
    {

        public static DataTable getList(string strWhere)
        {
            string strSql = "select * from ViewDocumentShare ";
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
                strSql += fields + " from ViewDocumentShare ";
            }
            else 
            {
                strSql += "* from ViewDocumentShare ";
            }
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
