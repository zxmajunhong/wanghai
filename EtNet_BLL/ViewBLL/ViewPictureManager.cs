using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_BLL.ViewBLL
{
    public class ViewPictureManager
    {
        public static DataTable getList(string fields, string strWhere)
        {
            return  EtNet_DAL.ViewDAL.ViewPictureService.getList(fields,strWhere);
        }

    }
}
