using System;
namespace EtNet_Models
{
	/// <summary>
	/// PanelMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class PanelMenu
	{
		public PanelMenu()
		{}
		#region Model
		private int _id;
		private int _founderid;
		private int _colsnum;
		private int _rowsnum;
		private string _title;
		private string _imageload;
		private string _direction;
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
		/// 所属列的位置
		/// </summary>
		public int colsnum
		{
			set{ _colsnum=value;}
			get{return _colsnum;}
		}
		/// <summary>
		/// 所属行的位置
		/// </summary>
		public int rowsnum
		{
			set{ _rowsnum=value;}
			get{return _rowsnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imageload
		{
			set{ _imageload=value;}
			get{return _imageload;}
		}
		/// <summary>
		/// 内容加载的指向如文档，公告
		/// </summary>
		public string direction
		{
			set{ _direction=value;}
			get{return _direction;}
		}
		#endregion Model

	}
}

