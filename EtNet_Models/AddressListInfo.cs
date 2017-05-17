using System;
namespace EtNet_Models
{
	/// <summary>
	/// AddressListInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class AddressListInfo
	{
		public AddressListInfo()
		{}
		#region Model
		private int _id;
		private string _cname;
		private string _ename;
		private string _sex;
		private string _phone;
		private string _cellphone;
        private string _scellphone;
		private string _mailbox;
		private string _positiontxt;
		private int _departid;
		private int _linkstaff;
		private int _staffid;
		private int _founder;
		private DateTime _createtime;
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
		/// 中文名
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 英文名
		/// </summary>
		public string ename
		{
			set{ _ename=value;}
			get{return _ename;}
		}
		/// <summary>
		/// 性别(男/女)
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}


		/// <summary>
		/// 手机
		/// </summary>
		public string cellphone
		{
			set{ _cellphone=value;}
			get{return _cellphone;}
		}

        /// <summary>
        /// 手机短号
        /// </summary>
        public string scellphone
        {
            get { return _scellphone; }
            set { _scellphone = value; }
        }

		/// <summary>
		/// 邮箱
		/// </summary>
		public string mailbox
		{
			set{ _mailbox=value;}
			get{return _mailbox;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string positiontxt
		{
			set{ _positiontxt=value;}
			get{return _positiontxt;}
		}
		/// <summary>
		/// 部门的id值
		/// </summary>
		public int departid
		{
			set{ _departid=value;}
			get{return _departid;}
		}
		/// <summary>
		/// 关联员工(0表示不关联员工/1表示关联员工)
		/// </summary>
        public int linkstaff
		{
            set { _linkstaff = value; }
            get { return _linkstaff; }
		}
		/// <summary>
		/// 关联员工的id值,不关联员工为0
		/// </summary>
        public int staffid
		{
            set { _staffid = value; }
            get { return _staffid; }
		}

		/// <summary>
		/// 创建人的id值
		/// </summary>
		public int founder
		{
			set{ _founder=value;}
			get{return _founder;}
		}

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}

		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

