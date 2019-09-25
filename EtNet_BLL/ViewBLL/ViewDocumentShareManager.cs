using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_BLL.ViewBLL
{
    public class ViewDocumentShareManager
    {
        /// <summary>
        ///依据指定的条件筛选数据列表
        /// </summary>
        public static DataTable getList(string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewDocumentShareService.getList(strWhere);
        }


        /// <summary>
        /// 依据筛选条件,以及指定的字段返回数据列表
        /// </summary>
        public static DataTable getList(string fields, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewDocumentShareService.getList(fields, strWhere);
        }

    }
}
