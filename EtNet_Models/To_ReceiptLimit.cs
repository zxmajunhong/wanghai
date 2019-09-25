using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //To_ReceiptLimit
    public class To_ReceiptLimit
    {

        /// <summary>
        /// id
        /// </summary>		
        private int _userID;
        public int userID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        /// <summary>
        /// receiptList
        /// </summary>		
        private string _receiptlist;
        public string receiptList
        {
            get { return _receiptlist; }
            set { _receiptlist = value; }
        }

    }
}
