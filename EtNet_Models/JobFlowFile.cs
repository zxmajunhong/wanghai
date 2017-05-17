using System;
namespace EtNet_Models
{
	/// <summary>
	/// JobFlowFile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class JobFlowFile
	{
		public JobFlowFile()
		{}
		#region Model
		private int _id;
		private string _filename;
		private string _fileload;
		private int _jobflowid;
		private int _filesize;
		private string _createtime;
		/// <summary>
		/// 主键，自动增长
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文件的名称
		/// </summary>
		public string filename
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 文件的路径
		/// </summary>
		public string fileload
		{
			set{ _fileload=value;}
			get{return _fileload;}
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
		/// 文件的大小
		/// </summary>
		public int filesize
		{
			set{ _filesize=value;}
			get{return _filesize;}
		}
		/// <summary>
		/// 文件的上传时间
		/// </summary>
		public string createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

