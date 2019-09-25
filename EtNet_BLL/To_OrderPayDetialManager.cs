using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class To_OrderPayDetialManager
    {
        public static int addTo_OrderPayDetial(To_OrderPayDetial to_orderpaydetial)
        {
            return To_OrderPayDetialService.addTo_OrderPayDetial(to_orderpaydetial);
        }

        public static int updateTo_OrderPayDetial(To_OrderPayDetial to_orderpaydetial)
        {
            return To_OrderPayDetialService.updateTo_OrderPayDetialById(to_orderpaydetial);
        }

        public static int deleteTo_OrderPayDetial(int id)
        {
            return To_OrderPayDetialService.deleteTo_OrderPayDetialById(id);
        }

        /// <summary>
        /// 根据sql条件删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteTo_orderPayDetailbySql(string sql)
        {
            return To_OrderPayDetialService.deleteTo_orderPayDetailbySql(sql);
        }

        public static To_OrderPayDetial getTo_OrderPayDetialById(int id)
        {
            return To_OrderPayDetialService.getTo_OrderPayDetialById(id);
        }

        public static IList<To_OrderPayDetial> getTo_OrderPayDetialAll()
        {
            return To_OrderPayDetialService.getTo_OrderPayDetialAll();
        }

        public static int deleteTo_OrderPayDetialByOrderID(int orderid)
        {
            return To_OrderPayDetialService.deleteTo_OrderPayDetialByOrderID(orderid);
        }

        public static System.Data.DataTable getList(int id)
        {
            return To_OrderPayDetialService.getList(id);
        }

        public static IList<To_OrderPayDetial> getTo_OrderPayDetialByOrderId(int orderID)
        {
            return To_OrderPayDetialService.getTo_OrderPayDetialByOrderId(orderID);
        }

        /// <summary>
        /// 更新付款明细信息的付款状态和实际付款金额
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getstatus"></param>
        /// <param name="hasAmount"></param>
        /// <returns></returns>
        public static int updateDetialStatusAndMoney(string id, string getstatus, string hasAmount)
        {
            return To_OrderPayDetialService.updateDetialStatusAndMoney(id, getstatus, hasAmount);
        }
    }
}
