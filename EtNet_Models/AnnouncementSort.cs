using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	
    //AnnouncementSort
    [Serializable]
	public class AnnouncementSort
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
		/// 公司公告/部门公告
        /// </summary>		
		private string _txt;
        public string txt
        {
            get{ return _txt; }
            set{ _txt = value; }
        }        
		   
	}
}

