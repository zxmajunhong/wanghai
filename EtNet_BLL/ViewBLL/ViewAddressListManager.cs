using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_BLL.ViewBLL
{
    public class ViewAddressListManager
    {

        public static DataTable getList(string fields, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewAddressListService.getList(fields, strWhere);
        }
    }
}
