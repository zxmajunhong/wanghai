using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
	//RegReimbursement 
	public class RegReimbursement 
	{
			 
			
		private string _id;
		/// <summary>
		/// id主键
		/// </summary>	
		public string id
		{
			get{ return _id; }
			set{ _id = value; }
		}        
			
		private int _paystatus;
		/// <summary>
		/// 支付状态（0：未支付，1：已支付）
		/// </summary>	
		public int payStatus
		{
			get{ return _paystatus; }
			set{ _paystatus = value; }
		}        
			
		private int _paymentmode;
		/// <summary>
		/// paymentMode支付方式
		/// </summary>	
		public int paymentMode
		{
			get{ return _paymentmode; }
			set{ _paymentmode = value; }
		}        
			
		private int _payerid;
		/// <summary>
		/// payerID支付人关联id
		/// </summary>	
		public int payerID
		{
			get{ return _payerid; }
			set{ _payerid = value; }
		}        
			
		private string _payername;
		/// <summary>
		/// payerName支付人名字
		/// </summary>	
		public string payerName
		{
			get{ return _payername; }
			set{ _payername = value; }
		}        
			
		private DateTime _paymentdate;
		/// <summary>
		/// paymentDate支付时间
		/// </summary>	
		public DateTime paymentDate
		{
			get{ return _paymentdate; }
			set{ _paymentdate = value; }
		}        
			
		private DateTime _maketime;
		/// <summary>
		/// makeTime申请时间
		/// </summary>	
		public DateTime makeTime
		{
			get{ return _maketime; }
			set{ _maketime = value; }
		}        
			
		private int _makerid;
		/// <summary>
		/// makerID申请人关联id
		/// </summary>	
		public int makerID
		{
			get{ return _makerid; }
			set{ _makerid = value; }
		}        
			
		private string _makername;
		/// <summary>
		/// makerName申请人名字
		/// </summary>	
		public string makerName
		{
			get{ return _makername; }
			set{ _makername = value; }
		}

		/// <summary>
		/// 收到发票表示（0：未收到；1：已收到）
		/// </summary>
		public int hasInvoice
		{
			get;
			set;
		}

        private int _ausID;
        /// <summary>
        /// 报销单号
        /// </summary>
		public int ausID
		{
            get { return _ausID; }
            set { _ausID = value; }
		}

		public DateTime? hasInvoiceDate
		{
			get;
			set;
		}

        private string _payremark;

        /// <summary>
        /// 支付备注
        /// </summary>
        public string payremark
        {
            get { return _payremark; }
            set { _payremark = value; }
        }

        /// <summary>
        /// 支付银行
        /// </summary>
        public string bankName { get; set; }

        /// <summary>
        /// 支付帐号
        /// </summary>
        public string bankNum { get; set; }

        /// <summary>
        /// 支付银行对应id
        /// </summary>
        public int bankId { get; set; }
    }
}
