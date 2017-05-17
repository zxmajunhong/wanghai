using System;
namespace EtNet_Models
{
	/// <summary>
	/// StaffExperience:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class StaffExperience
	{
		public StaffExperience()
		{}
		#region Model
		private int _id;
		private int _staffid;
		private DateTime _stime;
		private DateTime _etime;
		private int _yearsnum;
		private string _workunit;
		private string _post;
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
		/// 员工的id值(关联StaffInfo表)
		/// </summary>
		public int staffid
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime stime
		{
			set{ _stime=value;}
			get{return _stime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime etime
		{
			set{ _etime=value;}
			get{return _etime;}
		}
		/// <summary>
		/// 工作年限
		/// </summary>
		public int yearsnum
		{
			set{ _yearsnum=value;}
			get{return _yearsnum;}
		}
		/// <summary>
		/// 工作单位
		/// </summary>
		public string workunit
		{
			set{ _workunit=value;}
			get{return _workunit;}
		}
		/// <summary>
		/// 工作岗位
		/// </summary>
		public string post
		{
			set{ _post=value;}
			get{return _post;}
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

