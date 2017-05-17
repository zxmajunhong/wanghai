using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderPayDetial
    {
        //To_OrderPayDetial���Ĭ�Ϲ��췽��
        public To_OrderPayDetial()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderPayDetial]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int orderid;
        /// <summary>
        ///[To_OrderPayDetial]�� [orderid]��
        /// </summary>
        public int Orderid
        {
            get { return orderid; }
            set { this.orderid = value; }
        }


        private int factid;


        public int Factid 
        {
            get { return factid; }
            set { this.factid = value; }
        }
        private string supName;
        /// <summary>
        ///[To_OrderPayDetial]�� [supName]��
        /// </summary>
        public string SupName
        {
            get { return supName; }
            set { this.supName = value; }
        }
        private double money;
        /// <summary>
        ///[To_OrderPayDetial]�� [money]��
        /// </summary>
        public double Money
        {
            get { return money; }
            set { this.money = value; }
        }
        private string payConfirm;
        /// <summary>
        ///[To_OrderPayDetial]�� [payConfirm]��
        /// </summary>
        public string PayConfirm
        {
            get { return payConfirm; }
            set { this.payConfirm = value; }
        }
        private string payStatus;
        /// <summary>
        ///[To_OrderPayDetial]�� [payStatus]��
        /// </summary>
        public string PayStatus
        {
            get { return payStatus; }
            set { this.payStatus = value; }
        }
        private double payAmount;
        /// <summary>
        ///[To_OrderPayDetial]�� [payAmount]��
        /// </summary>
        public double PayAmount
        {
            get { return payAmount; }
            set { this.payAmount = value; }
        }

        /// <summary>
        /// PayType�У��������
        /// </summary>
        public string PayType
        { get; set; }

        /// <summary>
        /// ��ϵ����Ϣid
        /// </summary>
        public int LinkID
        { get; set; }

        /// <summary>
        /// ��ϵ������
        /// </summary>
        public string LinkName
        { get; set; }

        /// <summary>
        /// ���ע
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int PayNum { get; set; }

        /// <summary>
        /// ��ͯ��
        /// </summary>
        public int PayChildNum { get; set; }
    }
}
