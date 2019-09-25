using System;
using System.Collections.Generic;
using System.Text;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{


    public class To_OrderReimDetialManager
    {
        public static int addTo_OrderReimDetial(To_OrderReimDetial to_orderreimdetial)
        {
            return To_OrderReimDetialService.addTo_OrderReimDetial(to_orderreimdetial);
        }

        public static int updateTo_OrderReimDetial(To_OrderReimDetial to_orderreimdetial)
        {
            return To_OrderReimDetialService.updateTo_OrderReimDetialById(to_orderreimdetial);
        }

        public static int deleteTo_OrderReimDetial(int id)
        {
            return To_OrderReimDetialService.deleteTo_OrderReimDetialById(id);
        }

        public static To_OrderReimDetial getTo_OrderReimDetialById(int id)
        {
            return To_OrderReimDetialService.getTo_OrderReimDetialById(id);
        }

        public static IList<To_OrderReimDetial> getTo_OrderReimDetialAll()
        {
            return To_OrderReimDetialService.getTo_OrderReimDetialAll();
        }
        public static int deleteTo_OrderReimDetialByOrderID(int orderid)
        {
            return To_OrderReimDetialService.deleteTo_OrderReimDetialByOrderID(orderid);
        }

        public static System.Data.DataTable getList(int id)
        {
            return To_OrderReimDetialService.getList(id);
        }
    }
}
