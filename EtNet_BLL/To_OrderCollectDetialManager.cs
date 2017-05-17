using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class To_OrderCollectDetialManager
    {
        public static int addTo_OrderCollectDetial(To_OrderCollectDetial to_ordercollectdetial)
        {
            return To_OrderCollectDetialService.addTo_OrderCollectDetial(to_ordercollectdetial);
        }

        public static int updateTo_OrderCollectDetial(To_OrderCollectDetial to_ordercollectdetial)
        {
            return To_OrderCollectDetialService.updateTo_OrderCollectDetialById(to_ordercollectdetial);
        }

        /// <summary>
        /// 更新收款明细信息的收款状态和实际收款金额
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="hasAmount"></param>
        /// <returns></returns>
        public static int updateDetialStatusAndMoney(string id, string status, string hasAmount)
        {
            return To_OrderCollectDetialService.updateDetialStatusAndMoney(id, status, hasAmount);
        }

        /// <summary>
        /// 更新收款明细信息的提成发放状态
        /// </summary>
        /// <param name="id">id的集合</param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int updateDetialCutStatus(string strWhere, string status)
        {
            return To_OrderCollectDetialService.updateDetialCutStatus(strWhere, status);
        }

        public static int deleteTo_OrderCollectDetial(int id)
        {
            return To_OrderCollectDetialService.deleteTo_OrderCollectDetialById(id);
        }

        /// <summary>
        /// 根据sql条件删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteTo_OrderCollectDetailbySql(string sql)
        {
            return To_OrderCollectDetialService.deleteTo_OrderCollectDetailbySql(sql);
        }

        public static To_OrderCollectDetial getTo_OrderCollectDetialById(int id)
        {
            return To_OrderCollectDetialService.getTo_OrderCollectDetialById(id);
        }

        public static IList<To_OrderCollectDetial> getTo_OrderCollectDetialAll()
        {
            return To_OrderCollectDetialService.getTo_OrderCollectDetialAll();
        }
        public static int deleteTo_OrderCollectDetialByOrderID(int orderid)
        {
            return To_OrderCollectDetialService.deleteTo_OrderCollectDetialByOrderID(orderid);
        }

        public static System.Data.DataTable getList(int id)
        {
            return To_OrderCollectDetialService.getList(id);
        }

        public static System.Data.DataTable GetOrderCollectInvoice(string strWhere)
        {
            return To_OrderCollectDetialService.GetOrderCollectInvoice(strWhere);
        }
    }
}
