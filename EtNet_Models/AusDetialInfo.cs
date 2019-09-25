using System;
using System.Collections.Generic;
using System.Text;

namespace EtNet_Models
{
    public class AusDetialInfo
    {
        public AusDetialInfo()
        { }
        #region Model
        private int _id;
        private string _ausname;
        private decimal _ausmoney;
        private string _remark;
        private int _jobflowid;
        private DateTime _happendate;
        private int _billnum;
        /// <summary>
        /// 自动增长，主键
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string ausname
        {
            set { _ausname = value; }
            get { return _ausname; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal ausmoney
        {
            set { _ausmoney = value; }
            get { return _ausmoney; }
        }
        /// <summary>
        /// 具体的说明
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }


        /// <summary>
        /// 工作流的id值
        /// </summary>
        public int jobflowid
        {
            set { _jobflowid = value; }
            get { return _jobflowid; }
        }

        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime happendate
        {
            set { _happendate = value; }
            get { return _happendate; }
        }

        /// <summary>
        /// 票据张数
        /// </summary>
        public int billnum
        {
            set { _billnum = value; }
            get { return _billnum; }
        }

        /// <summary>
        /// 费用类别
        /// </summary>
        private string _austype;
        public string austype
        {
            set { _austype = value; }
            get { return _austype; }
        }

        /// <summary>
        /// 费用归属
        /// </summary>
        private string _belongsort;
        public string belongsort
        {
            set { _belongsort = value; }
            get { return _belongsort; }
        }
        /// <summary>
        /// 业务员
        /// </summary>
        private string _Salesman;
        public string Salesman
        {
            set { _Salesman = value; }
            get { return _Salesman; }
        }
        #endregion Model




    }
}
