using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //To_ClaimDetail
    public class To_ClaimDetail
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 收款认领表ID
        /// </summary>		
        private int _claimid;
        public int claimID
        {
            get { return _claimid; }
            set { _claimid = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        private string _orderNum;
        public string orderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }
        /// <summary>
        /// 订单付款单位明细表id
        /// </summary>		
        private int _orderCollectId;
        public int orderCollectId
        {
            get { return _orderCollectId; }
            set { _orderCollectId = value; }
        }
        /// <summary>
        /// 付款单位id
        /// </summary>
        private int _orderCusId;
        public int orderCusId
        {
            get { return _orderCusId; }
            set { _orderCusId = value; }
        }
        /// <summary>
        /// 应收金额
        /// </summary>		
        private decimal _receiptamount;
        public decimal receiptAmount
        {
            get { return _receiptamount; }
            set { _receiptamount = value; }
        }
        /// <summary>
        /// 实际收款金额
        /// </summary>		
        private decimal _realamount;
        public decimal realAmount
        {
            get { return _realamount; }
            set { _realamount = value; }
        }
        /// <summary>
        /// 收款状态（0：未完成；1：已完成）
        /// </summary>		
        private int _receiptstatuscode;
        public int receiptStatusCode
        {
            get { return _receiptstatuscode; }
            set { _receiptstatuscode = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _mark;
        public string mark
        {
            get { return _mark; }
            set { _mark = value; }
        }

    }
}
