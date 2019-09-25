using System;
namespace EtNet_Models
{
	/// <summary>
	/// AusRottenInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AusRottenInfo
	{
		public AusRottenInfo()
		{}
		#region Model
		private int _id;
		private DateTime _applydate;
		private int _applycantid;
		private decimal _totalmoney;
		private string _remark;
		private string _txt;
		private int _reimbursedsort;
        private int _jobflowid;
        private int _belongsort;
        private int _billstate;
        private string _itemtype;
        private string _person;

		/// <summary>
		/// 主键,自动增长
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 报销申请的日期
		/// </summary>
		public DateTime applydate
		{
			set{ _applydate=value;}
			get{return _applydate;}
		}
		/// <summary>
		/// 报销人，关联LoginInfo的id号
		/// </summary>
		public int applycantid
		{
			set{ _applycantid=value;}
			get{return _applycantid;}
		}
		/// <summary>
		/// 报销的总金额
		/// </summary>
		public decimal totalmoney
		{
			set{ _totalmoney=value;}
			get{return _totalmoney;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 审核人员的意见
		/// </summary>
		public string txt
		{
			set{ _txt=value;}
			get{return _txt;}
		}
		/// <summary>
		/// 报销的分类
		/// </summary>
		public int reimbursedsort
		{
			set{ _reimbursedsort=value;}
			get{return _reimbursedsort;}
		}

        /// <summary>
        /// 项目类别
        /// </summary>
        public string itemtype
        {
            set { _itemtype = value; }
            get { return _itemtype; }
        }


        /// <summary>
        /// 工作流的id值
        /// </summary>
        public int jobflowid
        {
            get { return _jobflowid; }
            set { _jobflowid = value; }
        }

        /// <summary>
        /// 费用的归属（1属于个人/2属于公司）
        /// </summary>
        public int belongsort
        {
            get { return _belongsort; }
            set { _belongsort = value; }
        }

        /// <summary>
        /// 是否有票据，分为有票报销与无票报销
        /// </summary>
        public int billstate
        {
            get { return _billstate; }
            set { _billstate = value; }
        }

        /// <summary>
        /// 人员汇总数据
        /// </summary>
        public string person
        {
            get { return _person; }
            set { _person = value; }
        }

		#endregion Model

        /// <summary>
        /// 开户人
        /// </summary>
        public string Banker { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 开户帐号
        /// </summary>
        public string bankNum { get; set; }
    }
}

