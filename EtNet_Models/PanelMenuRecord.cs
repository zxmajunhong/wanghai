using System;
namespace EtNet_Models
{
	/// <summary>
	/// PanelMenuRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PanelMenuRecord
	{
		public PanelMenuRecord()
		{}
		#region Model
		private int _id;
		private int _founderid;
		private int _totalcols;
		private string _userempty;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 创建人的id值
		/// </summary>
		public int founderid
		{
			set{ _founderid=value;}
			get{return _founderid;}
		}
		/// <summary>
		/// 面板菜单显示时的列数
		/// </summary>
		public int totalcols
		{
			set{ _totalcols=value;}
			get{return _totalcols;}
		}
		/// <summary>
		/// 是否设置面板菜单为空
		/// </summary>
		public string userempty
		{
			set{ _userempty=value;}
			get{return _userempty;}
		}
		#endregion Model

	}
}

