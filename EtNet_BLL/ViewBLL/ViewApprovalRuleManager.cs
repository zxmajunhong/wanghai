using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace EtNet_BLL.ViewBLL
{
    public  class ViewApprovalRuleManager
    {
        public static DataTable getList(string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewApprovalRuleService.getList(strWhere);
        }

        /// <summary>
        /// 返回审核规则的数据列表
        /// </summary>
        /// <param name="fields">返回的字段，设置为空表示全部字段</param>
        /// <param name="strWhere">指定的筛选条件</param>
        /// <returns></returns>
        public static DataTable getList(string fields, string strWhere )
        {
            return EtNet_DAL.ViewDAL.ViewApprovalRuleService.getList(fields,strWhere);
        }

    }
}
