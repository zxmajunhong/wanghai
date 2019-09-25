using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_DAL.ViewDAL
{
    public class ViewAusRottenInfoService
    {
        public static DataTable getlist(string strWhere)
        {
            string str = "select * from ViewAusRottenInfo ";
            if(strWhere !="")
            {
               str += " where " + strWhere;
            }
            else
            {
            }
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(str);
            return tbl;
            
        }



        public static DataTable getlist(string fields, string strWhere)
        {
            string str = "select ";
            if (fields != "")
            {
                str += fields;
            }
            else
            {
                str += " * ";  
            }
              str += " from ViewAusRottenInfo ";

            if (strWhere != "")
            {
                str += " where " + strWhere;
            }
          
            DataTable tbl = EtNet_DAL.DBHelper.GetDataSet(str);
            return tbl;

        }




    }
}
