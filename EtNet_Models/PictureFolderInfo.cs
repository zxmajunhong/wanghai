using System;
namespace EtNet_Models
{
	/// <summary>
	/// PictureFolderInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PictureFolderInfo
	{
		public PictureFolderInfo()
		{}
		#region Model
		private int _id;
		private int _upid;
		private string _cname;
		private int _capacity;
		private int _capacityused;
		private int _typecode;
		private string _typetxt;
        private int _creater;

      
		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 上级文件夹的id值
		/// </summary>
		public int upid
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// 文件夹名称
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 文件夹容量
		/// </summary>
		public int capacity
		{
			set{ _capacity=value;}
			get{return _capacity;}
		}
		/// <summary>
		/// 已用容量
		/// </summary>
		public int capacityused
		{
			set{ _capacityused=value;}
			get{return _capacityused;}
		}
		/// <summary>
		/// 文件夹类型的数值表示(0/1/2)
		/// </summary>
		public int typecode
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 文件夹类型的文本表示方式(个人/他人共享/公共)
		/// </summary>
		public string typetxt
		{
			set{ _typetxt=value;}
			get{return _typetxt;}
		}

        /// <summary>
        /// 创建人
        /// </summary>
        public int creater
        {
            get { return _creater; }
            set { _creater = value; }
        }
		#endregion Model

	}
}

