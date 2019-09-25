using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models.View
{
    public class ViewDocumentComment
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
		/// 文档的id值
        /// </summary>		
		private int _documentid;
        public int documentid
        {
            get{ return _documentid; }
            set{ _documentid = value; }
        }        
		/// <summary>
		/// 回复人的id值
        /// </summary>		
		private int _replypersonsid;
        public int replypersonsid
        {
            get{ return _replypersonsid; }
            set{ _replypersonsid = value; }
        }        

        private string _cname;
        /// <summary>
        /// 回复人的姓名
        /// </summary>
        public string cname
        {
           get { return _cname; }
           set { _cname = value; }
        }

        private int _departid;
        /// <summary>
        /// 部门的id值
        /// </summary>
        public int departid
        {
            get { return _departid; }
            set { _departid = value; }
        }


        private string _departcname;
        /// <summary>
        /// 部门的名称
        /// </summary>
        public string departcname
        {
            get { return _departcname; }
            set { _departcname = value; }
        }



		/// <summary>
		/// 回复的内容
        /// </summary>		
		private string _replytxt;
        public string replytxt
        {
            get{ return _replytxt; }
            set{ _replytxt = value; }
        }        
		/// <summary>
		/// 回复的时间
        /// </summary>		
		private DateTime _replftime;
        public DateTime replftime
        {
            get{ return _replftime; }
            set{ _replftime = value; }
        }        
		   


    }
}
