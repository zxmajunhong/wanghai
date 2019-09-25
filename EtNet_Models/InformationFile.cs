using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	 	//InformationFile
	public class InformationFile
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 消息的id值
        /// </summary>		
		private int _informationid;
        public int informationid
        {
            get{ return _informationid; }
            set{ _informationid = value; }
        }        
		/// <summary>
		/// 文件的路径
        /// </summary>		
		private string _fileload;
        public string fileload
        {
            get{ return _fileload; }
            set{ _fileload = value; }
        }        
		/// <summary>
		/// 附件的名称
        /// </summary>		
		private string _filename;
        public string filename
        {
            get{ return _filename; }
            set{ _filename = value; }
        }        
		/// <summary>
		/// 附件的大小
        /// </summary>		
		private int _filesize;
        public int filesize
        {
            get{ return _filesize; }
            set{ _filesize = value; }
        }        
		/// <summary>
		/// 附件的下载次数
        /// </summary>		
		private int _downloadnum;
        public int downloadnum
        {
            get{ return _downloadnum; }
            set{ _downloadnum = value; }
        }        
		/// <summary>
		/// 附件的创建时间
        /// </summary>		
		private DateTime _createtime;
        public DateTime createtime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		   
	}
}

