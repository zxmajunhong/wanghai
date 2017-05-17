using System;
namespace EtNet_Models
{
	/// <summary>
	/// InitializeSet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InitializeSet
	{
		public InitializeSet()
		{}
		#region Model
		private int _id;
		private string _cname;
		private int _siftopen;
		private int _pagecount;
		private int _pageitem;
        private int _inforemind;
        private int _newinforemind;
		private int _infocycle;
        private string _panellistall;
        private string _panellist;
        private string _panelcount;
        private int _panelcols;
		private DateTime _createtime;

		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户初始化设置时使用模板名称
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 筛选栏是否打开(0不打开/1打开)
		/// </summary>
		public int siftopen
		{
			set{ _siftopen=value;}
			get{return _siftopen;}
		}
		/// <summary>
		/// 数据列表的索引数量(即数据列表下面的带有数字的导航按钮的个数)
		/// </summary>
		public int pagecount
		{
			set{ _pagecount=value;}
			get{return _pagecount;}
		}
		/// <summary>
		/// 数据列表显示的数据量(即每页显示的数据的条数)
		/// </summary>
		public int pageitem
		{
			set{ _pageitem=value;}
			get{return _pageitem;}
		}

        /// <summary>
        /// 0代表不提醒/1代表提醒(此消息提醒是指登录后是否提醒全部未读消息)
        /// </summary>
        public int inforemind
        {
            set { _inforemind = value; }
            get { return _inforemind; }
        }

        /// <summary>
        /// 0代表不提醒/1代表提醒(此消息提醒是指新产生的消息)
        /// </summary>
        public int newinforemind
        {
            set { _newinforemind = value; }
            get { return _newinforemind; }
        }

		/// <summary>
		/// 获取消息的周期,已秒计算
		/// </summary>
		public int infocycle
		{
			set{ _infocycle=value;}
			get{return _infocycle;}
		}

        /// <summary>
        /// 可用的主页列表菜单的id值
        /// </summary>
        public string panellistall
        {
            set { _panellistall = value; }
            get { return _panellistall; }
        }

        /// <summary>
        /// 主页显示的列表菜单的id值
        /// </summary>
        public string panellist
        {
            set { _panellist = value; }
            get { return _panellist; }
        }

        /// <summary>
        /// 主页列表菜单显示的数据量
        /// </summary>
        public string panelcount
        {
            set { _panelcount = value; }
            get { return _panelcount; }
        }

        /// <summary>
        /// 主页列表菜单默认的列数
        /// </summary>
        public int panelcols
        {
            set { _panelcols = value; }
            get { return _panelcols; }
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

