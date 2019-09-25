using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class To_OrderRefunDetialManager
    {
        public static int addTo_OrderRefunDetial(To_OrderRefunDetial to_orderrefundetial)
        {
            return To_OrderRefunDetialService.addTo_OrderRefunDetial(to_orderrefundetial);
        }

        public static int updateTo_OrderRefunDetial(To_OrderRefunDetial to_orderrefundetial)
        {
            return To_OrderRefunDetialService.updateTo_OrderRefunDetialById(to_orderrefundetial);
        }

        public static int deleteTo_OrderRefunDetial(int id)
        {
            return To_OrderRefunDetialService.deleteTo_OrderRefunDetialById(id);
        }

        /// <summary>
        /// 条件删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int deleteTo_OrderRefunDetialbySql(string sql)
        {
            return To_OrderRefunDetialService.deleteTo_OrderRefunDetialbySql(sql);
        }

        public static To_OrderRefunDetial getTo_OrderRefunDetialById(int id)
        {
            return To_OrderRefunDetialService.getTo_OrderRefunDetialById(id);
        }

        public static IList<To_OrderRefunDetial> getTo_OrderRefunDetialAll()
        {
            return To_OrderRefunDetialService.getTo_OrderRefunDetialAll();
        }


        public static int deleteTo_OrderRefunDetialByOrderID(int orderid)
        {
            return To_OrderRefunDetialService.deleteTo_OrderRefunDetialByOrderID(orderid);
        }

        public static System.Data.DataTable getList(int id)
        {
            return To_OrderRefunDetialService.getList(id);
        }

        /// <summary>
        /// 更新订单退款信息明细表的退款状态和以退金额
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getstatus"></param>
        /// <param name="hasAmount"></param>
        /// <returns></returns>
        public static int updateDetialStatusAndMoney(string id, string getstatus, string hasAmount)
        {
            return To_OrderRefunDetialService.updateDetialStatusAndMoney(id, getstatus, hasAmount);
        }
    }
}
