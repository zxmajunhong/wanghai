using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	//AnnouncementStatus
    [Serializable]
	public class AnnouncementStatus
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
		/// 草稿/发布
        /// </summary>		
		private string _txt;
        public string txt
        {
            get{ return _txt; }
            set{ _txt = value; }
        }        
		   
	}
}

