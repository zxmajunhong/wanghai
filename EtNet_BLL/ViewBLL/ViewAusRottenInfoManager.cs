using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_BLL.ViewBLL
{
    public class ViewAusRottenInfoManager
    {
        public static DataTable getlist(string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewAusRottenInfoService.getlist(strWhere);
        }


        /// <summary>
        /// 返回报销单的数据列表
        /// </summary>
        /// <param name="fields">返回的字段</param>
        /// <param name="strWhere">筛选的条件</param>
        public static DataTable getlist(string fields, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewAusRottenInfoService.getlist(fields, strWhere);
        }

    }
}
