using System;
namespace EtNet_Models
{
	/// <summary>
	/// TargetType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TargetType
	{
		public TargetType()
		{}
		#region Model
		private int _targettypeid;
		private string _typeno;
		private string _typename;
		/// <summary>
		/// 
		/// </summary>
		public int TargetTypeID
		{
			set{ _targettypeid=value;}
			get{return _targettypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeNo
		{
			set{ _typeno=value;}
			get{return _typeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		#endregion Model

	}
}

