using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    //To_PolicyFile
    public class To_PolicyFile
    {

        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// policyID
        /// </summary>		
        private int _policyid;
        public int policyID
        {
            get { return _policyid; }
            set { _policyid = value; }
        }
        /// <summary>
        /// filename
        /// </summary>		
        private string _filename;
        public string filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
        /// <summary>
        /// filepath
        /// </summary>		
        private string _filepath;
        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }
        /// <summary>
        /// createTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime createTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

        public int Filesize
        {
            get;
            set;
        }

    }
}