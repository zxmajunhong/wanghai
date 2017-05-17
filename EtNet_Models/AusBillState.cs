using System;
namespace EtNet_Models
{
	/// <summary>
	/// AusBillState:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AusBillState
	{
		public AusBillState()
		{}
		#region Model
		private int _id;
		private string _txt;
		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 类别（有票报销，无票报销）
		/// </summary>
		public string txt
		{
			set{ _txt=value;}
			get{return _txt;}
		}
		#endregion Model

	}
}

