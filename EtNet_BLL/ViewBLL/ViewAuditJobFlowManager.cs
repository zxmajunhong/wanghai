using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EtNet_BLL.ViewBLL
{
    public class ViewAuditJobFlowManager
    {

        /// <summary>
        /// 按指定的条件查找数据
        /// </summary>
        public static DataTable getList(string strWhere )
        {
            return EtNet_DAL.ViewDAL.ViewAuditJobFlowService.getList(strWhere);  
        }


        /// <summary>
        /// 按指定的条件查找数据，可以在第一个参数中设置显示行数
        /// </summary>
        public static DataTable getList(string filter, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewAuditJobFlowService.getList(filter, strWhere);
        } 


    }
}
