using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	 	//InformationNotice
	public class InformationNotice
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
		/// 接收人的id值
        /// </summary>		
		private int _recipientid;
        public int recipientid
        {
            get{ return _recipientid; }
            set{ _recipientid = value; }
        }


        private string _remind;
        /// <summary>
        /// 设置提醒
        /// </summary>
        public string remind
        {
            get { return _remind; }
            set { _remind = value; }
        }

	}
}

