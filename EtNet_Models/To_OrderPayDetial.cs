using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderPayDetial
    {
        //To_OrderPayDetial表的默认构造方法
        public To_OrderPayDetial()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderPayDetial]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int orderid;
        /// <summary>
        ///[To_OrderPayDetial]表 [orderid]列
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
        ///[To_OrderPayDetial]表 [supName]列
        /// </summary>
        public string SupName
        {
            get { return supName; }
            set { this.supName = value; }
        }
        private double money;
        /// <summary>
        ///[To_OrderPayDetial]表 [money]列
        /// </summary>
        public double Money
        {
            get { return money; }
            set { this.money = value; }
        }
        private string payConfirm;
        /// <summary>
        ///[To_OrderPayDetial]表 [payConfirm]列
        /// </summary>
        public string PayConfirm
        {
            get { return payConfirm; }
            set { this.payConfirm = value; }
        }
        private string payStatus;
        /// <summary>
        ///[To_OrderPayDetial]表 [payStatus]列
        /// </summary>
        public string PayStatus
        {
            get { return payStatus; }
            set { this.payStatus = value; }
        }
        private double payAmount;
        /// <summary>
        ///[To_OrderPayDetial]表 [payAmount]列
        /// </summary>
        public double PayAmount
        {
            get { return payAmount; }
            set { this.payAmount = value; }
        }

        /// <summary>
        /// PayType列，付款类别
        /// </summary>
        public string PayType
        { get; set; }

        /// <summary>
        /// 联系人信息id
        /// </summary>
        public int LinkID
        { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        public string LinkName
        { get; set; }

        /// <summary>
        /// 付款备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 成人数
        /// </summary>
        public int PayNum { get; set; }

        /// <summary>
        /// 儿童数
        /// </summary>
        public int PayChildNum { get; set; }
    }
}
