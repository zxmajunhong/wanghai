using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderCollectDetial
    {
        //To_OrderCollectDetial���Ĭ�Ϲ��췽��
        public To_OrderCollectDetial()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderCollectDetial]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int orderid;
        /// <summary>
        ///[To_OrderCollectDetial]�� [orderid]��
        /// </summary>
        public int Orderid
        {
            get { return orderid; }
            set { this.orderid = value; }
        }


        private int cusId;

        public int CustId 
        {
            get { return cusId; }
            set { this.cusId = value; }
        }
        private string cusName;
        /// <summary>
        ///[To_OrderCollectDetial]�� [cusName]��
        /// </summary>
        public string CusName
        {
            get { return cusName; }
            set { this.cusName = value; }
        }
        private string salesman;
        /// <summary>
        ///[To_OrderCollectDetial]�� [salesman]��
        /// </summary>
        public string Salesman
        {
            get { return salesman; }
            set { this.salesman = value; }
        }
        private int salemanid;
        /// <summary>
        ///[To_OrderCollectDetial]�� [salemanid]��
        /// </summary>
        public int Salemanid
        {
            get { return salemanid; }
            set { this.salemanid = value; }
        }
        private int adultNum;
        /// <summary>
        ///[To_OrderCollectDetial]�� [adultNum]��
        /// </summary>
        public int AdultNum
        {
            get { return adultNum; }
            set { this.adultNum = value; }
        }
        private int childNum;
        /// <summary>
        ///[To_OrderCollectDetial]�� [childNum]��
        /// </summary>
        public int ChildNum
        {
            get { return childNum; }
            set { this.childNum = value; }
        }
        private int withNum;
        /// <summary>
        ///[To_OrderCollectDetial]�� [withNum]��
        /// </summary>
        public int WithNum
        {
            get { return withNum; }
            set { this.withNum = value; }
        }
        private double money;
        /// <summary>
        ///[To_OrderCollectDetial]�� [money]��
        /// </summary>
        public double Money
        {
            get { return money; }
            set { this.money = value; }
        }
        private string collectStatus;
        /// <summary>
        ///[To_OrderCollectDetial]�� [collectStatus]��
        /// </summary>
        public string CollectStatus
        {
            get { return collectStatus; }
            set { this.collectStatus = value; }
        }
        private double collectAmount;
        /// <summary>
        ///[To_OrderCollectDetial]�� [collectAmount]��
        /// </summary>
        public double CollectAmount
        {
            get { return collectAmount; }
            set { this.collectAmount = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        { get; set; }

        /// <summary>
        /// �տλ��ϵ��id
        /// </summary>
        public int LinkID { get; set; }

        /// <summary>
        /// Ӫҵ����ϵ������
        /// </summary>
        public string LinkName { get; set; }

        /// <summary>
        /// Ӫҵ������
        /// </summary>
        public string DepartName { get; set; }
    }
}
