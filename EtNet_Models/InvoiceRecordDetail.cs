using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class InvoiceRecordDetail
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 对应的开票信息主表id
        /// </summary>
        public int invoiceId { get; set; }

        /// <summary>
        /// 对应的订单收款明细表id
        /// </summary>
        public int orderCollectId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderNum { get; set; }

        /// <summary>
        /// 开票金额
        /// </summary>
        public double invoiceMoney { get; set; }

        /// <summary>
        /// 应开金额
        /// </summary>
        public double shouldMoney { get; set; }
    }
}
