using System;
namespace EtNet_Models
{
	/// <summary>
	/// ModuleCodingInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ModuleCodingInfo
	{
		public ModuleCodingInfo()
		{}
		#region Model
		private int _id;
		private string _num;
		private string _cname;
		private string _txtformat;
		private int _orderlen;
		private int _usecode;
		private string _usetxt;
		private DateTime _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模块的编号
		/// </summary>
		public string num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 模块的名称
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 自动编码的表达式的格式
		/// </summary>
		public string txtformat
		{
			set{ _txtformat=value;}
			get{return _txtformat;}
		}
		/// <summary>
		/// 流水号的长度
		/// </summary>
		public int orderlen
		{
			set{ _orderlen=value;}
			get{return _orderlen;}
		}
		/// <summary>
		/// 是否启用(0表示不启用/1表示启用)
		/// </summary>
		public int usecode
		{
			set{ _usecode=value;}
			get{return _usecode;}
		}
		/// <summary>
		/// 表示启用与禁用
		/// </summary>
		public string usetxt
		{
			set{ _usetxt=value;}
			get{return _usetxt;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

