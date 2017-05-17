using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	 	//JobFlowSort
	public class JobFlowSort
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
		/// 工作流状态的分类的编号
        /// </summary>		
		private string _num;
        public string num
        {
            get{ return _num; }
            set{ _num = value; }
        }        
		/// <summary>
		/// 工作流状态的文本
        /// </summary>		
		private string _txt;
        public string txt
        {
            get{ return _txt; }
            set{ _txt = value; }
        }        
		   
	}
}

