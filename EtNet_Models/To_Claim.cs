using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //To_Claim
    public class To_Claim
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
        /// 收款记录ID
        /// </summary>		
        private int _collectingid;
        public int collectingID
        {
            get { return _collectingid; }
            set { _collectingid = value; }
        }
        /// <summary>
        /// 收款单号
        /// </summary>
        private string _collectingNum;
        public string collectingNum
        {
            get { return _collectingNum; }
            set { _collectingNum = value; }
        }
        /// <summary>
        /// 制单员
        /// </summary>		
        private string _makerman;
        public string makerman
        {
            get { return _makerman; }
            set { _makerman = value; }
        }
        /// <summary>
        /// 制单员ID
        /// </summary>		
        private int _makerID;
        public int MakerID
        {
            get { return _makerID; }
            set { _makerID = value; }
        }
        /// <summary>
        /// 支付单位
        /// </summary>		
        private string _payer;
        public string payer
        {
            get { return _payer; }
            set { _payer = value; }
        }
        /// <summary>
        /// 支付单位ID
        /// </summary>		
        private int _payerid;
        public int payerID
        {
            get { return _payerid; }
            set { _payerid = value; }
        }
        /// <summary>
        /// 收款金额
        /// </summary>
        private double _collectAmount;
        public double collectAmount
        {
            get { return _collectAmount; }
            set { _collectAmount = value; }
        }

    }
}
