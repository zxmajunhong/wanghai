using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using EtNet_DAL;

namespace EtNet_BLL
{
    public class InvoiceRecordDetailManager
    {
        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(InvoiceRecordDetail model)
        {
            return InvoiceRecordDetailService.Add(model);
        }

        /// <summary>
        /// 根据条件得到开票的明细数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetList(string strWhere)
        {
            return InvoiceRecordDetailService.GetList(strWhere);
        }

        /// <summary>
        /// 根据发票记录主表id删除明细数据
        /// </summary>
        /// <param name="InvoiceId"></param>
        /// <returns></returns>
        public static bool DeleteByInoviceId(int InvoiceId)
        {
            return InvoiceRecordDetailService.DeleteByInoviceId(InvoiceId);
        }
    }
}
