﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_DAL.ViewDAL
{
    public class ViewStaffInfoService
    {
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
            strSql += " from ViewStaffInfo ";
            if (strWhere != "")
            {
                strSql += " where " + strWhere;
            }
            
            return EtNet_DAL.DBHelper.GetDataSet(strSql);
        }

    }
}
