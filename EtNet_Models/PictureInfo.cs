using System;
namespace EtNet_Models
{
	/// <summary>
	/// PictureInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public  class PictureInfo
	{
		public PictureInfo()
		{}
		#region Model
		private int _id;
		private string _cname;
		private string _imgpath;
		private int _size;
		private string _format;
		private DateTime _createtime;
		private DateTime _modifytime;
		private int _visiblecode;
		private string _visibletxt;
		private int _folderid;
		private int _creater;
		private int _sharecode;
		private string _sharestxt;
		private string _viewidlist;
		private string _viewtxtlist;
		private string _editidlist;
		private string _edittxtlist;
		private string _delidlist;
		private string _deltxtlist;

		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 图片的名称
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 图片的路径
		/// </summary>
		public string imgpath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		/// <summary>
		/// 图片的大小
		/// </summary>
		public int size
		{
			set{ _size=value;}
			get{return _size;}
		}
		/// <summary>
		/// 格式(gif,png,bmp,jpg)
		/// </summary>
		public string format
		{
			set{ _format=value;}
			get{return _format;}
		}
		/// <summary>
		/// 创建时间(及上传时间)
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime modifytime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 是否可见的数值表示方式(0/1)
		/// </summary>
		public int visiblecode
		{
			set{ _visiblecode=value;}
			get{return _visiblecode;}
		}
		/// <summary>
		/// 可见性的文本表示方式(可见/隐藏)
		/// </summary>
		public string visibletxt
		{
			set{ _visibletxt=value;}
			get{return _visibletxt;}
		}
		/// <summary>
		/// 所属文件夹的id值
		/// </summary>
		public int folderid
		{
			set{ _folderid=value;}
			get{return _folderid;}
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
		/// 是否分享的数值表示(0/1)
		/// </summary>
		public int sharecode
		{
			set{ _sharecode=value;}
			get{return _sharecode;}
		}
		/// <summary>
		/// 私有/分享
		/// </summary>
		public string sharestxt
		{
			set{ _sharestxt=value;}
			get{return _sharestxt;}
		}
		/// <summary>
		/// 可查看人员的id列表值
		/// </summary>
		public string viewidlist
		{
			set{ _viewidlist=value;}
			get{return _viewidlist;}
		}
		/// <summary>
		/// 可查看人员的文本列表值
		/// </summary>
		public string viewtxtlist
		{
			set{ _viewtxtlist=value;}
			get{return _viewtxtlist;}
		}
		/// <summary>
		/// 可编辑人员的id列表值
		/// </summary>
		public string editidlist
		{
			set{ _editidlist=value;}
			get{return _editidlist;}
		}
		/// <summary>
		/// 可编辑人员的文本列表值
		/// </summary>
		public string edittxtlist
		{
			set{ _edittxtlist=value;}
			get{return _edittxtlist;}
		}
		/// <summary>
		/// 可删除人员的id列表值
		/// </summary>
		public string delidlist
		{
			set{ _delidlist=value;}
			get{return _delidlist;}
		}
		/// <summary>
		/// 可删除人员的文本列表值
		/// </summary>
		public string deltxtlist
		{
			set{ _deltxtlist=value;}
			get{return _deltxtlist;}
		}
		#endregion Model

	}
}

