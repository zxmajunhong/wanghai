using System;
using System.Collections.Generic;
using System.Text;

namespace EtNet_Models.View
{
    public  class ViewSign
    {
        public ViewSign()
        { }
        #region Model

        private int _id;
        private string _loginid;
        private DateTime _signtimein;
        private string _signremark;
        private int _signtagin;
        private int _signtagout;
        private DateTime _signtimeout;
        private string _latetype;
        private string _leavetype;
        private string _signdate;
        private string _ename;
        private string _cname;
        private string _departename;
        private string _departcname;


        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string loginid
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime signtimein
        {
            set { _signtimein = value; }
            get { return _signtimein; }
        }
        /// <summary>
        /// 签到与签退说明
        /// </summary>
        public string signremark
        {
            set { _signremark = value; }
            get { return _signremark; }
        }
        /// <summary>
        /// 签到的状态，0表示未签到，1表示已签到，2表示迟到
        /// </summary>
        public int signtagin
        {
            set { _signtagin = value; }
            get { return _signtagin; }
        }
        /// <summary>
        /// 签退的状态，0表示未签退，1表示正常签退，2表示早退
        /// </summary>
        public int signtagout
        {
            set { _signtagout = value; }
            get { return _signtagout; }
        }
        /// <summary>
        /// 签退的时间
        /// </summary>
        public DateTime signtimeout
        {
            set { _signtimeout = value; }
            get { return _signtimeout; }
        }
        /// <summary>
        /// 迟到的原因
        /// </summary>
        public string latetype
        {
            set { _latetype = value; }
            get { return _latetype; }
        }
        /// <summary>
        /// 早退的原因
        /// </summary>
        public string leavetype
        {
            set { _leavetype = value; }
            get { return _leavetype; }
        }

        /// <summary>
        /// 签到日期
        /// </summary>
        public string signdate
        {
            set { _signdate = value; }
            get { return _signdate; }
        }

        /// <summary>
        /// 登录用户的英文名
        /// </summary>
        public string ename
        {
            set { _ename = value; }
            get { return _ename; }
        }

        /// <summary>
        ///登录用户的中文名
        /// </summary>
        public string cname
        {
            set { _cname = value; }
            get { return _cname; }
        }

        /// <summary>
        /// 部门的中文名
        /// </summary>
        public string departename
        {
            set { _departename = value; }
            get { return _departename; }
        }

        /// <summary>
        /// 部门的英文名
        /// </summary>
        public string departcname
        {
            set { _departcname = value; }
            get { return _departcname; }
        }


        #endregion Model





    }
}
