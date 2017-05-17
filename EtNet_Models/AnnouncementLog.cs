using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	//AnnouncementLog
    [Serializable]
	public class AnnouncementLog
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
		/// ip地址
        /// </summary>		
		private string _ipaddress;
        public string ipaddress
        {
            get{ return _ipaddress; }
            set{ _ipaddress = value; }
        }        
		/// <summary>
		/// 操作数值表示(1创建/2查看/3修改/4删除)
        /// </summary>		
		private int _operatecode;
        public int operatecode
        {
            get{ return _operatecode; }
            set{ _operatecode = value; }
        }        
		/// <summary>
		/// 操作的文本表示(创建/查看/修改/删除)
        /// </summary>		
		private string _operatetxt;
        public string operatetxt
        {
            get{ return _operatetxt; }
            set{ _operatetxt = value; }
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
		/// 操作人员的id值
        /// </summary>		
		private int _founderid;
        public int founderid
        {
            get{ return _founderid; }
            set{ _founderid = value; }
        }        
		   
	}
}

