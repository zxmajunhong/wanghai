﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EtNet_DAL;

namespace EtNet_DAL.ViewDAL
{
    public class ViewAddressListService
    {
        public static DataTable getList(string fields, string strWhere)
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
            str += " from ViewAddressList ";
            if (strWhere.Trim() != "")
            {
                str += " where " + strWhere;
            }

            return DBHelper.GetDataSet(str);
        }

    }
}
