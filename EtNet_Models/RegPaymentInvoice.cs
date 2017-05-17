using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //RegPaymentInvoice
    public class RegPaymentInvoice
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

        private string _regid;
        /// <summary>
        /// regID
        /// </summary>	
        public string regID
        {
            get { return _regid; }
            set { _regid = value; }
        }

        private int _invoiceid;
        /// <summary>
        /// invoiceID
        /// </summary>	
        public int invoiceID
        {
            get { return _invoiceid; }
            set { _invoiceid = value; }
        }

        private string _invoicenum;
        /// <summary>
        /// invoiceNum
        /// </summary>	
        public string invoiceNum
        {
            get { return _invoicenum; }
            set { _invoicenum = value; }
        }

        private string _remark;
        /// <summary>
        /// remark
        /// </summary>	
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

    }
}