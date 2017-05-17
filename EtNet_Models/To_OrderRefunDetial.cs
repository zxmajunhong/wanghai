using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderRefunDetial
    {
        //To_OrderRefunDetial表的默认构造方法
        public To_OrderRefunDetial()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderRefunDetial]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int orderid;
        /// <summary>
        ///[To_OrderRefunDetial]表 [orderid]列
        /// </summary>
        public int Orderid
        {
            get { return orderid; }
            set { this.orderid = value; }
        }


        private int cusid;


        public int Cusid
        {
            get { return cusid; }
            set { this.cusid = value; }
        }
        private string cusName;
        /// <summary>
        ///[To_OrderRefunDetial]表 [cusName]列
        /// </summary>
        public string CusName
        {
            get { return cusName; }
            set { this.cusName = value; }
        }
        private double money;
        /// <summary>
        ///[To_OrderRefunDetial]表 [money]列
        /// </summary>
        public double Money
        {
            get { return money; }
            set { this.money = value; }
        }
        private double refundAmount;
        /// <summary>
        ///[To_OrderRefunDetial]表 [refundAmount]列
        /// </summary>
        public double RefundAmount
        {
            get { return refundAmount; }
            set { this.refundAmount = value; }
        }
        private string refundStatus;
        /// <summary>
        ///[To_OrderRefunDetial]表 [refundStatus]列
        /// </summary>
        public string RefundStatus
        {
            get { return refundStatus; }
            set { this.refundStatus = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
