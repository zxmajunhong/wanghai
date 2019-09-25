using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNetBLL.ViewBLL
{
    public class ViewStaffInfoManager
    {

        public static DataTable getList(string fields, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewStaffInfoService.getList(fields, strWhere);
        }

    }
}
