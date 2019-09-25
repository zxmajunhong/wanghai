using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	//InformationSort
	public class InformationSort
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
		/// 消息的分类,邮件消息，个人消息，文档消息
        /// </summary>		
		private string _txt;
        public string txt
        {
            get{ return _txt; }
            set{ _txt = value; }
        }        
		   
	}
}

