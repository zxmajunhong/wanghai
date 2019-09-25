using System;
namespace EtNet_Models
{
	/// <summary>
	/// FirmAccountInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class FirmAccountInfo
	{
		public FirmAccountInfo()
		{}
		#region Model
		private int _id;
		private int _firmid;
		private string _bankname;
		private string _account;
		private string _remark;

		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}

		/// <summary>
		/// 公司的id值
		/// </summary>
		public int firmid
		{
			set{ _firmid=value;}
			get{return _firmid;}
		}
		/// <summary>
		/// 开户行名称
		/// </summary>
		public string bankname
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 账号
		/// </summary>
		public string account
		{
			set{ _account=value;}
			get{return _account;}
		}

        /// <summary>
        /// 账户预设余额
        /// </summary>
        public decimal amount { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        /// <summary>
        /// 预设时间
        /// </summary>
        public DateTime ystime { get; set; }
		#endregion Model




        
    }
}

