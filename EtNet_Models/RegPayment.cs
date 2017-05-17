using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //RegPayment
    public class RegPayment
    {


        private string _id;
        /// <summary>
        /// id
        /// </summary>	
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _paymentid;
        /// <summary>
        /// paymentID 付款申请的关联id
        /// </summary>	
        public string paymentID
        {
            get { return _paymentid; }
            set { _paymentid = value; }
        }

        private int _paystatus;
        /// <summary>
        /// payStatus 支付状态
        /// </summary>	
        public int payStatus
        {
            get { return _paystatus; }
            set { _paystatus = value; }
        }

        private int _paymentmode;
        /// <summary>
        /// paymentMode 支付方式
        /// </summary>	
        public int paymentMode
        {
            get { return _paymentmode; }
            set { _paymentmode = value; }
        }

        private int _payerid;
        /// <summary>
        /// payerID 支付人关联id
        /// </summary>	
        public int payerID
        {
            get { return _payerid; }
            set { _payerid = value; }
        }

        private string _payername;
        /// <summary>
        /// payerName 支付人
        /// </summary>	
        public string payerName
        {
            get { return _payername; }
            set { _payername = value; }
        }

        private DateTime _paymentdate;
        /// <summary>
        /// paymentDate 支付时间
        /// </summary>	
        public DateTime paymentDate
        {
            get { return _paymentdate; }
            set { _paymentdate = value; }
        }

        private int _hasinvoice;
        /// <summary>
        /// 收到发票表示（0：未收到；1：已收到）
        /// </summary>	
        public int hasInvoice
        {
            get { return _hasinvoice; }
            set { _hasinvoice = value; }
        }

        private DateTime _hasinvoicedate;
        /// <summary>
        /// hasInvoiceDate 收到发票的时间
        /// </summary>	
        public DateTime hasInvoiceDate
        {
            get { return _hasinvoicedate; }
            set { _hasinvoicedate = value; }
        }

        private int _invoicetype;
        /// <summary>
        /// invoiceType 发票类型
        /// </summary>	
        public int invoiceType
        {
            get { return _invoicetype; }
            set { _invoicetype = value; }
        }

        private DateTime _maketime;
        /// <summary>
        /// makeTime制单时间
        /// </summary>	
        public DateTime makeTime
        {
            get { return _maketime; }
            set { _maketime = value; }
        }

        private int _makerid;
        /// <summary>
        /// makerID制单人关联id
        /// </summary>	
        public int makerID
        {
            get { return _makerid; }
            set { _makerid = value; }
        }

        private string _makername;
        /// <summary>
        /// makerName 制单人
        /// </summary>	
        public string makerName
        {
            get { return _makername; }
            set { _makername = value; }
        }

        private string _payRemark;
        /// <summary>
        /// 支付凭证
        /// </summary>
        public string payRemark
        {
            get { return _payRemark; }
            set { _payRemark = value; }
        }

    }
}