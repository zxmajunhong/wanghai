using System;
namespace EtNet_Models
{
	/// <summary>
	/// StaffInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class StaffInfo
	{
		public StaffInfo()
		{}
		#region Model
		private int _id;
		private string _cname;
		private string _ename;
		private int _paperssort;
		private string _papersnum;
		private string _sex;
		private string _nationality;
		private string _nativeplace;
        private string _nationtxt;
		private DateTime _birth;
		private string _age;
		private string _cardaddress;
		private string _marriage;
		private string _politics;
		private string _degree;
		private string _titletxt;
		private string _school;
		private string _major;
		private DateTime _gdate;
		private int _creater;
		private string _imgpath;
		private DateTime _createdate;
		private string _contactaddress;
		private string _phone;
		private string _cellphone;
		private string _wagecard;
		private string _mailbox;
		private string _remark;
        private string _status;
        private int _departid;
        private string _positiontxt;

       
 
		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 员工中文名称
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 员工英文名称
		/// </summary>
		public string ename
		{
			set{ _ename=value;}
			get{return _ename;}
		}
		/// <summary>
		/// 证件类型（关联证件类型表）
		/// </summary>
		public int paperssort
		{
			set{ _paperssort=value;}
			get{return _paperssort;}
		}
		/// <summary>
		/// 证件号
		/// </summary>
		public string papersnum
		{
			set{ _papersnum=value;}
			get{return _papersnum;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 国籍
		/// </summary>
		public string nationality
		{
			set{ _nationality=value;}
			get{return _nationality;}
		}
		/// <summary>
		/// 籍贯
		/// </summary>
		public string nativeplace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// 民族类型
		/// </summary>
        public string nationtxt
		{
            set { _nationtxt = value; }
            get { return _nationtxt; }
		}
		/// <summary>
		/// 出生年月
		/// </summary>
		public DateTime birth
		{
			set{ _birth=value;}
			get{return _birth;}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public string age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 身份证地址
		/// </summary>
		public string cardaddress
		{
			set{ _cardaddress=value;}
			get{return _cardaddress;}
		}
		/// <summary>
		/// 婚姻状态
		/// </summary>
		public string marriage
		{
			set{ _marriage=value;}
			get{return _marriage;}
		}
		/// <summary>
		/// 政治面貌
		/// </summary>
		public string politics
		{
			set{ _politics=value;}
			get{return _politics;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string degree
		{
			set{ _degree=value;}
			get{return _degree;}
		}
		/// <summary>
		/// 职称
		/// </summary>
		public string titletxt
		{
			set{ _titletxt=value;}
			get{return _titletxt;}
		}
		/// <summary>
		/// 毕业院校
		/// </summary>
		public string school
		{
			set{ _school=value;}
			get{return _school;}
		}
		/// <summary>
		/// 专业
		/// </summary>
		public string major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 毕业时间
		/// </summary>
		public DateTime gdate
		{
			set{ _gdate=value;}
			get{return _gdate;}
		}
		/// <summary>
		/// 创建人的id值
		/// </summary>
		public int creater
		{
			set{ _creater=value;}
			get{return _creater;}
		}
		/// <summary>
		/// 员工图像
		/// </summary>
		public string imgpath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 通讯地址
		/// </summary>
		public string contactaddress
		{
			set{ _contactaddress=value;}
			get{return _contactaddress;}
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
		/// 工资卡
		/// </summary>
		public string wagecard
		{
			set{ _wagecard=value;}
			get{return _wagecard;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}



        /// <summary>
        /// 员工状态
        /// </summary>
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 部门的id值
        /// </summary>
        public int departid
        {
            get { return _departid; }
            set { _departid = value; }
        }

        /// <summary>
        /// 职务
        /// </summary>
        public string positiontxt
        {
            get { return _positiontxt; }
            set { _positiontxt = value; }
        }


		#endregion Model

	}
}

