using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
using System.Data;
namespace EtNet_BLL
{


    public class To_OrderInfoManager
    {
        public static int addTo_OrderInfo(To_OrderInfo to_orderinfo)
        {
            return To_OrderInfoService.addTo_OrderInfo(to_orderinfo);
        }

        public static int updateTo_OrderInfo(To_OrderInfo to_orderinfo)
        {
            return To_OrderInfoService.updateTo_OrderInfoById(to_orderinfo);
        }

        public static int deleteTo_OrderInfo(int id)
        {
            return To_OrderInfoService.deleteTo_OrderInfoById(id);
        }

        public static To_OrderInfo getTo_OrderInfoById(int id)
        {
            return To_OrderInfoService.getTo_OrderInfoById(id);
        }

        public static IList<To_OrderInfo> getTo_OrderInfoAll()
        {
            return To_OrderInfoService.getTo_OrderInfoAll();
        }

        public static DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return To_OrderInfoService.GetList(Top, strWhere, filedOrder);
        }

        public static To_OrderInfo getLastOneID()
        {
            return To_OrderInfoService.getLastOneID();
        }

        public static DataTable GetLists(string strWhere)
        {
            return To_OrderInfoService.GetLists(strWhere);
        }


        public static DataTable getList(string fields, string strWhere)
        {
            return To_OrderInfoService.getList(fields, strWhere);
        }

        public static DataTable GetViewOrder(string fields, string strWhere)
        {
            return To_OrderInfoService.GetViewOrder(fields, strWhere);
        }

        public static To_OrderInfo getTo_OrderInfoByOrderNum(string orderID)
        {
            return To_OrderInfoService.getTo_OrderInfoByOrderNum(orderID);
        }

        public static DataTable GetViewOrderAndCollect(string fields, string strWhere)
        {
            return To_OrderInfoService.GetViewOrderAndCollect(fields, strWhere);
        }

        public static DataTable GetViewOrderAndReturn(string fields, string strWhere)
        {
            return To_OrderInfoService.GetViewOrderAndReturn(fields, strWhere);
        }

        /// <summary>
        /// 更新订单的实际毛利
        /// </summary>
        /// <param name="jobflowid"></param>
        /// <param name="sjgross"></param>
        /// <returns></returns>
        public static int updateOrdersjGross(string jobflowid, string sjgross)
        {
            return To_OrderInfoService.updateOrdersjGross(jobflowid, sjgross);
        }

        /// <summary>
        /// 更新订单的发票情况
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="invoiceStatus"></param>
        /// <returns></returns>
        public static int updateOrderInvoice(string orderid, string invoiceStatus)
        {
            return To_OrderInfoService.updateOrderInvoice(orderid, invoiceStatus);
        }

        /// <summary>
        /// 得到订单中的退款信息
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetViewOrderReturn(string fields, string strWhere)
        {
            return To_OrderInfoService.GetViewOrderReturn(fields, strWhere);
        }

        public static int Clear()
        {
            return EtNet_DAL.To_OrderInfoService.Clear();
        }

        /// <summary>
        /// 判断订单是否能够删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CanDelete(int id)
        {
            return To_OrderInfoService.CanDelete(id);
        }

        public static bool updateInputerTcStatus(string strWhere, string status)
        {
            return To_OrderInfoService.updateInputerTcStatus(strWhere, status);
        }

        /// <summary>
        /// 修改订单的存档状态
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        public static bool updateFileStatus(int status, int id)
        {
            return To_OrderInfoService.updateFileStatus(status, id);
        }

        /// <summary>
        /// 修改订单的预计毛利
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public static bool updateOrderGross(To_OrderInfo orderInfo)
        {
            return To_OrderInfoService.updateOrderGross(orderInfo);
        }
    }
}
