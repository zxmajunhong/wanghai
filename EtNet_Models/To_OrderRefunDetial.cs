using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderRefunDetial
    {
        //To_OrderRefunDetial���Ĭ�Ϲ��췽��
        public To_OrderRefunDetial()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderRefunDetial]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int orderid;
        /// <summary>
        ///[To_OrderRefunDetial]�� [orderid]��
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
        ///[To_OrderRefunDetial]�� [cusName]��
        /// </summary>
        public string CusName
        {
            get { return cusName; }
            set { this.cusName = value; }
        }
        private double money;
        /// <summary>
        ///[To_OrderRefunDetial]�� [money]��
        /// </summary>
        public double Money
        {
            get { return money; }
            set { this.money = value; }
        }
        private double refundAmount;
        /// <summary>
        ///[To_OrderRefunDetial]�� [refundAmount]��
        /// </summary>
        public double RefundAmount
        {
            get { return refundAmount; }
            set { this.refundAmount = value; }
        }
        private string refundStatus;
        /// <summary>
        ///[To_OrderRefunDetial]�� [refundStatus]��
        /// </summary>
        public string RefundStatus
        {
            get { return refundStatus; }
            set { this.refundStatus = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }
    }
}
