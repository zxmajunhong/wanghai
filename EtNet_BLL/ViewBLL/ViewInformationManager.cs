using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_BLL.ViewBLL
{
    public  class ViewInformationManager
    {
        public static DataTable getList(string strWhere)
        {
            return  EtNet_DAL.ViewDAL.ViewInformationService.getList(strWhere);
        }


        /// <summary>
        /// 返回消息列表
        /// </summary>
        /// <param name="fields">字段列名称，设置多个字段可用逗号分割，为空表示全部字段</param>
        /// <param name="strWhere">查询条件</param>
        public static DataTable getList(string fields, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewInformationService.getList(fields, strWhere);
        }


    }
}
