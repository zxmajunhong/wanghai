using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class InvoiceRecord
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 开票时间
        /// </summary>
        public DateTime recordDate { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime makeDate { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        public string makeMan { get; set; }

        /// <summary>
        /// 登记人id
        /// </summary>
        public int makeId { get; set; }

        /// <summary>
        /// 开票备注
        /// </summary>
        public string makeRemark { get; set; }

        /// <summary>
        /// 开票金额
        /// </summary>
        public double amount { get; set; }

        /// <summary>
        /// 开票单位id
        /// </summary>
        public int cusId { get; set; }

        /// <summary>
        /// 开票单位名称
        /// </summary>
        public string cusName { get; set; }
    }
}
