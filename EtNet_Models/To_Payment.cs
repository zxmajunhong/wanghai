using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //To_Payment
    public class To_Payment
    {

        /// <summary>
        /// id
        /// </summary>		
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }	

        private string _serialnum;
        /// <summary>
        /// 申请单号
        /// </summary>	
        public string serialNum
        {
            get { return _serialnum; }
            set { _serialnum = value; }
        }
        	
        private DateTime _requestdate;
        /// <summary>
        /// 申请日期
        /// </summary>	
        public DateTime requestDate
        {
            get { return _requestdate; }
            set { _requestdate = value; }
        }
        	
        private string _makername;
        /// <summary>
        /// 制单员
        /// </summary>	
        public string makerName
        {
            get { return _makername; }
            set { _makername = value; }
        }
        	
        private int _makerid;
        /// <summary>
        /// 制单员ID
        /// </summary>	
        public int makerID
        {
            get { return _makerid; }
            set { _makerid = value; }
        }
        		
        private string _payfor;
        /// <summary>
        /// 付款资金类别
        /// </summary>
        public string payFor
        {
            get { return _payfor; }
            set { _payfor = value; }
        }
        	
        private string _paymenttype;
        /// <summary>
        /// 付款类别
        /// </summary>	
        public string paymentType
        {
            get { return _paymenttype; }
            set { _paymenttype = value; }
        }
        		
        private string _payername;
        /// <summary>
        /// 付款单位名称
        /// </summary>
        public string payerName
        {
            get { return _payername; }
            set { _payername = value; }
        }
        	
        private string _payercode;
        /// <summary>
        /// 付款单位代码
        /// </summary>	
        public string payerCode
        {
            get { return _payercode; }
            set { _payercode = value; }
        }
        		
        private int _payerid;
        /// <summary>
        /// 付款单位ID
        /// </summary>
        public int payerID
        {
            get { return _payerid; }
            set { _payerid = value; }
        }

        /// <summary>
        /// 付款单位类别，0：客户；1：公司 
        /// </summary>
        public int payerType
        { get; set; }

        private decimal _totalamount;
        /// <summary>
        /// 支付金额合计
        /// </summary>
        public decimal totalAmount
        {
            get { return _totalamount; }
            set { _totalamount = value; }
        }
        	
        private DateTime _expecteddate;
        /// <summary>
        /// 预计付款日期
        /// </summary>	
        public DateTime expectedDate
        {
            get { return _expecteddate; }
            set { _expecteddate = value; }
        }
        		
        private string _bankname;
        /// <summary>
        /// 开户银行
        /// </summary>
        public string bankName
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
        		
        private int _bankid;
        /// <summary>
        /// 银行ID
        /// </summary>
        public int bankID
        {
            get { return _bankid; }
            set { _bankid = value; }
        }
        	
        private string _bankaccount;
        /// <summary>
        /// 银行账号
        /// </summary>	
        public string bankAccount
        {
            get { return _bankaccount; }
            set { _bankaccount = value; }
        }
        		
        private string _bankaccountname;
        /// <summary>
        /// 开户户名
        /// </summary>
        public string bankAccountName
        {
            get { return _bankaccountname; }
            set { _bankaccountname = value; }
        }
        	
        private string _bankmark;
        /// <summary>
        /// 银行信息备注
        /// </summary>	
        public string bankMark
        {
            get { return _bankmark; }
            set { _bankmark = value; }
        }
        		
        private string _ordernum;
        /// <summary>
        /// orderNum
        /// </summary>
        public string orderNum
        {
            get { return _ordernum; }
            set { _ordernum = value; }
        }
        		
        private string _codeformat;
        /// <summary>
        /// codeFormat
        /// </summary>
        public string codeFormat
        {
            get { return _codeformat; }
            set { _codeformat = value; }
        }
        	
        private int _jobflowid;
        /// <summary>
        /// 工作流ID
        /// </summary>	
        public int jobFlowID
        {
            get { return _jobflowid; }
            set { _jobflowid = value; }
        }
        		
        private string _approvalopinion;
        /// <summary>
        /// 审批意见
        /// </summary>
        public string approvalOpinion
        {
            get { return _approvalopinion; }
            set { _approvalopinion = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime makeTime
        { get; set; }

        /// <summary>
        /// 支付方式 
        /// </summary>
        public int regtype
        { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string payType
        { get; set; }

        /// <summary>
        /// 是否确认
        /// </summary>
        public string isConfirm
        { get; set; }

        /// <summary>
        /// 收款银行
        /// </summary>
        public string getBank
        { get; set; }

        /// <summary>
        /// 收款帐号
        /// </summary>
        public string getAccount
        { get; set; }

        /// <summary>
        /// 收款帐号开户名
        /// </summary>
        public string getAccountName
        { get; set; }

        /// <summary>
        /// 确认人
        /// </summary>
        public string confirmMan
        { get; set; }

        /// <summary>
        /// 确认日期
        /// </summary>
        public DateTime confirmDate
        { get; set; }
    }
}