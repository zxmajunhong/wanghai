using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtNet_Models;
using EtNet_DAL;
using System.Data;

namespace EtNet_BLL
{
    public class RegPaymentInvoiceManager
    {
        private RegPaymentInvoiceService dal = new RegPaymentInvoiceService();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(RegPaymentInvoice model)
        {
            dal.Add(model);
        }

        public bool DeleteByRegID(string regID)
        {
            return dal.DeleteByRegID(regID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public  DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        public int GetCount(string regid)
        {
            return dal.GetCount(regid);
        }
    }
}
