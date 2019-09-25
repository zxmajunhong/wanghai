using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EtNet_BLL
{
    public class ViewInformationNoticeManager
    {

        public static DataTable getList(string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewInformationNoticeService.getList(strWhere);
         
        }
        public static DataTable getListCount(string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewInformationNoticeService.getListCount(strWhere);

        }


        /// <summary>
        /// 依据指定条件，去掉重复行返回查询数据
        /// </summary>
        public static DataTable getList(string fields, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewInformationNoticeService.getList(fields, strWhere);
        }

        /// <summary>
        /// 返回接收到消息数据列表
        /// </summary>
        /// <param name="fields">返回数据的列字段，设置为空表示全部字段</param>
        /// <param name="strWhere">指定的筛选条件</param>
        /// <returns></returns>
        public static DataTable getdataList(string fields, string strWhere)
        {
            return EtNet_DAL.ViewDAL.ViewInformationNoticeService.getdataList(fields, strWhere);
          
        }


    }
}
