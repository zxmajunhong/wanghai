using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class AusOrderInfo
    {
        public AusOrderInfo()
        { }
        #region Model
        /// <summary>
        /// 自动增长id，主键
        /// </summary>
        public int id
        { get; set; }

        /// <summary>
        /// 订单id
        /// </summary>
        public int orderId
        { get; set; }

        /// <summary>
        /// 工作流id
        /// </summary>
        public int jobflowId
        { get; set; }

        /// <summary>
        /// 订单序号
        /// </summary>
        public string orderNum
        { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string orderType
        { get; set; }

        /// <summary>
        /// 出团日期
        /// </summary>
        public DateTime outTime
        { get; set; }

        /// <summary>
        /// 性质
        /// </summary>
        public string natrue
        { get; set; }

        /// <summary>
        /// 路线
        /// </summary>
        public string tour
        { get; set; }
        #endregion
    }
}
