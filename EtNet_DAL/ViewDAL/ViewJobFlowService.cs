using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EtNet_DAL.ViewDAL
{
    public class ViewJobFlowService
    {
        public static DataTable getList(string strWhere)
        {
            string str = "select * from ViewJobFlow ";
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere + " order by id desc";
            }
            else
            {
                str += " order by id desc";
            }
            return DBHelper.GetDataSet(str);
        }



        public static DataTable getList(string filter, string strWhere)
        {
            string str = "select distinct ";
            str += filter;
            str += "  from ViewJobFlow ";
       
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere + " order by id desc";
            }
            else
            {
                str += " order by id desc";
            }
            return DBHelper.GetDataSet(str);
        }
        


    }
}
