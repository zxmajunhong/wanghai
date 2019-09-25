using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{

	/// <summary>
	/// AnnouncementInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AnnouncementInfo
	{
		public AnnouncementInfo()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _statusid;
		private int _sortid;
		private int _period;
		private DateTime _starttime;
		private DateTime _endtime;
		private int _visiblecode;
		private string _visibletxt;
		private string _txt;
		private string _departlist;
		private string _departtxtlist;
		private string _peoplelist;
		private DateTime _createtime;
		private int _createrid;
		private int _firmid;
		private string _yearnow;
		private string _filenum;
		private DateTime _filetime;
		private string _themeword;
		private string _carboncopy;
		private string _carboncopytxt;
		private int _imgid;
		private DateTime _printtime;
		private int _checkpid;
		private int _signpid;
		private int _jobflowid;
		private string _opiniontxt;


		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}


		/// <summary>
		/// 公告的标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}


		/// <summary>
		/// 公告的状态（草稿/发布），关联AnnouncementStatus表
		/// </summary>
		public int statusid
		{
			set{ _statusid=value;}
			get{return _statusid;}
		}


		/// <summary>
		/// 公告的分类(公司公告/部门公告)，关联AnnouncementSort表
		/// </summary>
		public int sortid
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}


		/// <summary>
		/// 公告的有效天数
		/// </summary>
		public int period
		{
			set{ _period=value;}
			get{return _period;}
		}


		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime starttime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}

		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime endtime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}


		/// <summary>
		/// 是否可见（1可见/0不可见）
		/// </summary>
		public int visiblecode
		{
			set{ _visiblecode=value;}
			get{return _visiblecode;}
		}


		/// <summary>
		/// 可见/不可见
		/// </summary>
		public string visibletxt
		{
			set{ _visibletxt=value;}
			get{return _visibletxt;}
		}


		/// <summary>
		/// 公告的内容
		/// </summary>
		public string txt
		{
			set{ _txt=value;}
			get{return _txt;}
		}


		/// <summary>
		/// 部门的id列表值
		/// </summary>
		public string departlist
		{
			set{ _departlist=value;}
			get{return _departlist;}
		}
		/// <summary>
		/// 部门的名称列表
		/// </summary>
		public string departtxtlist
		{
			set{ _departtxtlist=value;}
			get{return _departtxtlist;}
		}


		/// <summary>
		/// 人员的id列表值(可查看公告的人员,备用字段)
		/// </summary>
		public string peoplelist
		{
			set{ _peoplelist=value;}
			get{return _peoplelist;}
		}


		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}


		/// <summary>
		/// 创建人员(拟稿)的id值
		/// </summary>
		public int createrid
		{
			set{ _createrid=value;}
			get{return _createrid;}
		}


		/// <summary>
		/// 公司的id值
		/// </summary>
		public int firmid
		{
			set{ _firmid=value;}
			get{return _firmid;}
		}


		/// <summary>
		/// 当前年的文本值
		/// </summary>
		public string yearnow
		{
			set{ _yearnow=value;}
			get{return _yearnow;}
		}
		/// <summary>
		/// 公告文件的标志序号
		/// </summary>
		public string filenum
		{
			set{ _filenum=value;}
			get{return _filenum;}
		}


		/// <summary>
		/// 公告文件的时间
		/// </summary>
		public DateTime filetime
		{
			set{ _filetime=value;}
			get{return _filetime;}
		}


		/// <summary>
		/// 主题词
		/// </summary>
		public string themeword
		{
			set{ _themeword=value;}
			get{return _themeword;}
		}


		/// <summary>
		/// 抄送部门的id值列表
		/// </summary>
		public string carboncopy
		{
			set{ _carboncopy=value;}
			get{return _carboncopy;}
		}
		/// <summary>
		/// 抄送部门的文本值
		/// </summary>
		public string carboncopytxt
		{
			set{ _carboncopytxt=value;}
			get{return _carboncopytxt;}
		}
		/// <summary>
		/// 盖章图片的id值
		/// </summary>
		public int imgid
		{
			set{ _imgid=value;}
			get{return _imgid;}
		}


		/// <summary>
		/// 印发时间
		/// </summary>
		public DateTime printtime
		{
			set{ _printtime=value;}
			get{return _printtime;}
		}


		/// <summary>
		/// 校对人员的id值
		/// </summary>
		public int checkpid
		{
			set{ _checkpid=value;}
			get{return _checkpid;}
		}


		/// <summary>
		/// 签发人员的id值
		/// </summary>
		public int signpid
		{
			set{ _signpid=value;}
			get{return _signpid;}
		}


		/// <summary>
		/// 工作流的id值
		/// </summary>
		public int jobflowid
		{
			set{ _jobflowid=value;}
			get{return _jobflowid;}
		}


		/// <summary>
		/// 审批意见
		/// </summary>
		public string opiniontxt
		{
			set{ _opiniontxt=value;}
			get{return _opiniontxt;}
		}
		#endregion Model

	}
		   
	
}

