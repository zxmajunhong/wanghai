using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //ReimbursementInvoice
    public class ReimbursementInvoice
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

        private string _reimbursementid;
        /// <summary>
        /// reimbursementID
        /// </summary>	
        public string reimbursementID
        {
            get { return _reimbursementid; }
            set { _reimbursementid = value; }
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
