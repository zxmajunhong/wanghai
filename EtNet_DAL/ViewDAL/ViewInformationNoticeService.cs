using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_DAL.ViewDAL
{
    public class ViewInformationNoticeService
    {

        public static DataTable getList(string strWhere)
        {
            string strSql = "select top 10 * from ViewInformationNotice ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);

        }

        public static DataTable getListCount(string strWhere)
        {
            string strSql = "select * from ViewInformationNotice ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);

        }

        
        public static DataTable getList(string fields,string strWhere)
        {
            string strSql = "select distinct ";
                   strSql +=  fields;
                   strSql += " from ViewInformationNotice ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            else
            { }
            return EtNet_DAL.DBHelper.GetDataSet(strSql);
        
        }



        public static DataTable getdataList(string fields, string strWhere)
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
            strSql += " from ViewInformationNotice ";
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
