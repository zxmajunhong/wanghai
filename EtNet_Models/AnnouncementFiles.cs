using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	//AnnouncementFiles
    [Serializable]
    public class AnnouncementFiles
	{
   		     
      	/// <summary>
		/// id主键
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 公告的id值
        /// </summary>		
		private int _announcementid;
        public int announcementid
        {
            get{ return _announcementid; }
            set{ _announcementid = value; }
        }        
		/// <summary>
		/// 附件的名称
        /// </summary>		
		private string _cname;
        public string cname
        {
            get{ return _cname; }
            set{ _cname = value; }
        }        
		/// <summary>
		/// 路径
        /// </summary>		
		private string _path;
        public string path
        {
            get{ return _path; }
            set{ _path = value; }
        }        
		/// <summary>
		/// 上传时间
        /// </summary>		
		private DateTime _uptime;
        public DateTime uptime
        {
            get{ return _uptime; }
            set{ _uptime = value; }
        }        
		/// <summary>
		/// 上传附件人员的id值
        /// </summary>		
		private int _founderid;
        public int founderid
        {
            get{ return _founderid; }
            set{ _founderid = value; }
        }        
		/// <summary>
		/// 备注
        /// </summary>		
		private string _remark;
        public string remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		   
	}
}

