using System;
namespace EtNet_Models
{
	/// <summary>
	/// StaffLanguageLevel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class StaffLanguageLevel
	{
		public StaffLanguageLevel()
		{}
		#region Model
		private int _id;
		private int _staffid;
		private string _kinds;
		private string _gradetxt;
		private string _remark;
		/// <summary>
		/// 
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
		/// 语种
		/// </summary>
		public string kinds
		{
			set{ _kinds=value;}
			get{return _kinds;}
		}
		/// <summary>
		/// 级别
		/// </summary>
		public string gradetxt
		{
			set{ _gradetxt=value;}
			get{return _gradetxt;}
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

