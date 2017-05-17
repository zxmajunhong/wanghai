using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	//PanelMenuList
	public class PanelMenuList
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
		/// 编号
        /// </summary>		
		private string _num;
        public string num
        {
            get{ return _num; }
            set{ _num = value; }
        }        
		/// <summary>
		/// 名称
        /// </summary>		
		private string _cname;
        public string cname
        {
            get{ return _cname; }
            set{ _cname = value; }
        }        
		/// <summary>
		/// 菜单条目的表示图片的路径
        /// </summary>		
		private string _imageload;
        public string imageload
        {
            get{ return _imageload; }
            set{ _imageload = value; }
        }        
		   
	}
}

