using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class AusMoney
    {
        public AusMoney()
        { }
        #region
        private int _id;
        private string _itemname;
        private string _username;
        private double _amount;
        private double _haspay;
        private int _year;

        /// <summary>
        /// 主键，自动增长
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string itemname
        {
            set { _itemname = value; }
            get { return _itemname; }
        }

        /// <summary>
        /// 人员名称
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        /// 总金额
        /// </summary>
        public double amount
        {
            set { _amount = value; }
            get { return _amount; }
        }

        /// <summary>
        /// 已支付金额
        /// </summary>
        public double haspay
        {
            set { _haspay = value; }
            get { return _haspay; }
        }

        /// <summary>
        /// 年份
        /// </summary>
        public int year
        {
            set { _year = value; }
            get { return _year; }
        }
        #endregion
    }
}
