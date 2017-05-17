using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	 	//Information
	public class Information
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
		/// 消息的内容
        /// </summary>		
		private string _contents;
        public string contents
        {
            get{ return _contents; }
            set{ _contents = value; }
        }        
		/// <summary>
		/// 消息的分类
        /// </summary>		
		private int _sortid;
        public int sortid
        {
            get{ return _sortid; }
            set{ _sortid = value; }
        }        
		/// <summary>
		/// 消息分类关联的id值,邮件的id值,文档的id值
        /// </summary>		
		private int _associationid;
        public int associationid
        {
            get{ return _associationid; }
            set{ _associationid = value; }
        }        
	
		/// <summary>
		/// 创建人id值
        /// </summary>		
		private int _founderid;
        public int founderid
        {
            get{ return _founderid; }
            set{ _founderid = value; }
        }        
		/// <summary>
		/// 创建时间
        /// </summary>		
		private DateTime _createtime;
        public DateTime createtime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// 发送时间
        /// </summary>		
		private DateTime _sendtime;
        public DateTime sendtime
        {
            get{ return _sendtime; }
            set{ _sendtime = value; }
        }        
		   
	}
}

