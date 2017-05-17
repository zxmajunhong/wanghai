using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderCollectDetial
    {
        //To_OrderCollectDetial表的默认构造方法
        public To_OrderCollectDetial()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderCollectDetial]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int orderid;
        /// <summary>
        ///[To_OrderCollectDetial]表 [orderid]列
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
        ///[To_OrderCollectDetial]表 [cusName]列
        /// </summary>
        public string CusName
        {
            get { return cusName; }
            set { this.cusName = value; }
        }
        private string salesman;
        /// <summary>
        ///[To_OrderCollectDetial]表 [salesman]列
        /// </summary>
        public string Salesman
        {
            get { return salesman; }
            set { this.salesman = value; }
        }
        private int salemanid;
        /// <summary>
        ///[To_OrderCollectDetial]表 [salemanid]列
        /// </summary>
        public int Salemanid
        {
            get { return salemanid; }
            set { this.salemanid = value; }
        }
        private int adultNum;
        /// <summary>
        ///[To_OrderCollectDetial]表 [adultNum]列
        /// </summary>
        public int AdultNum
        {
            get { return adultNum; }
            set { this.adultNum = value; }
        }
        private int childNum;
        /// <summary>
        ///[To_OrderCollectDetial]表 [childNum]列
        /// </summary>
        public int ChildNum
        {
            get { return childNum; }
            set { this.childNum = value; }
        }
        private int withNum;
        /// <summary>
        ///[To_OrderCollectDetial]表 [withNum]列
        /// </summary>
        public int WithNum
        {
            get { return withNum; }
            set { this.withNum = value; }
        }
        private double money;
        /// <summary>
        ///[To_OrderCollectDetial]表 [money]列
        /// </summary>
        public double Money
        {
            get { return money; }
            set { this.money = value; }
        }
        private string collectStatus;
        /// <summary>
        ///[To_OrderCollectDetial]表 [collectStatus]列
        /// </summary>
        public string CollectStatus
        {
            get { return collectStatus; }
            set { this.collectStatus = value; }
        }
        private double collectAmount;
        /// <summary>
        ///[To_OrderCollectDetial]表 [collectAmount]列
        /// </summary>
        public double CollectAmount
        {
            get { return collectAmount; }
            set { this.collectAmount = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        { get; set; }

        /// <summary>
        /// 收款单位联系人id
        /// </summary>
        public int LinkID { get; set; }

        /// <summary>
        /// 营业部联系人名称
        /// </summary>
        public string LinkName { get; set; }

        /// <summary>
        /// 营业部名称
        /// </summary>
        public string DepartName { get; set; }
    }
}
