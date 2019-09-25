using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	 	//JobFlow
	public class JobFlow
	{
   		     
      	/// <summary>
		/// 主键,自动增长
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 工作流的名称
        /// </summary>		
		private string _cname;
        public string cname
        {
            get{ return _cname; }
            set{ _cname = value; }
        }        
		/// <summary>
		/// 工作流分类，关联JobFlowSort表中的num字段
        /// </summary>		
		private string _sort;
        public string sort
        {
            get{ return _sort; }
            set{ _sort = value; }
        }        
		/// <summary>
		/// createtime
        /// </summary>		
		private DateTime _createtime;
        public DateTime createtime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// endtime
        /// </summary>		
		private DateTime _endtime;
        public DateTime endtime
        {
            get{ return _endtime; }
            set{ _endtime = value; }
        }        
		/// <summary>
		/// 创建人的id，关联LoginInfo表中的id字段
        /// </summary>		
		private int _founderid;
        public int founderid
        {
            get{ return _founderid; }
            set{ _founderid = value; }
        }        
		/// <summary>
		/// 审核类型，关联JobAuditStatus表中的num字段
        /// </summary>		
		private string _auditsort;
        public string auditsort
        {
            get{ return _auditsort; }
            set{ _auditsort = value; }
        }        
		/// <summary>
		/// auditstatus
        /// </summary>		
		private string _auditstatus;
        public string auditstatus
        {
            get{ return _auditstatus; }
            set{ _auditstatus = value; }
        }        
		/// <summary>
		/// 草稿/可执行
        /// </summary>		
		private string _savestatus;
        public string savestatus
        {
            get{ return _savestatus; }
            set{ _savestatus = value; }
        }        
		/// <summary>
		/// 附件上传
        /// </summary>		
		private string _attachment;
        public string attachment
        {
            get{ return _attachment; }
            set{ _attachment = value; }
        }        
		/// <summary>
		/// 文本，关于工作流的一些描述或提示
        /// </summary>		
		private string _txt;
        public string txt
        {
            get{ return _txt; }
            set{ _txt = value; }
        }

        /// <summary>
        /// 审核规则的id值
        /// </summary>
        private int _ruleid;
        public int ruleid
        {
            get { return _ruleid; }
            set { _ruleid = value; }
        }
		   
	}
}

