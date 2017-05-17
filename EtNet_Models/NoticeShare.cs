using System;
namespace EtNet_Models
{
	/// <summary>
	/// NoticeShare:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class NoticeShare
	{
		public NoticeShare()
		{}
		#region Model
		private int _id;
		private int _noticeid;
		private int _acceptid;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 公告的id值
		/// </summary>
		public int noticeid
		{
			set{ _noticeid=value;}
			get{return _noticeid;}
		}
		/// <summary>
		/// 接受人员的id值
		/// </summary>
		public int acceptid
		{
			set{ _acceptid=value;}
			get{return _acceptid;}
		}
		#endregion Model

	}
}

