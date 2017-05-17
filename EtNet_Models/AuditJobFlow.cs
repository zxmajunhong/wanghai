using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	 	//AuditJobFlow
	public class AuditJobFlow
	{
   		     
      	/// <summary>
		/// 主键，自动增长
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 审核人的id号，关联LoginInfo表中的id号
        /// </summary>		
		private int _reviewerid;
        public int reviewerid
        {
            get{ return _reviewerid; }
            set{ _reviewerid = value; }
        }        
		/// <summary>
		/// 工作流的id号，关联JobFlow表
        /// </summary>		
		private int _jobflowid;
        public int jobflowid
        {
            get{ return _jobflowid; }
            set{ _jobflowid = value; }
        }        
		/// <summary>
		/// 是否是主要的审批人T代表是，F代表不是
        /// </summary>		
		private string _mainreviewer;
        public string mainreviewer
        {
            get{ return _mainreviewer; }
            set{ _mainreviewer = value; }
        }        
		/// <summary>
		/// 是否是当前审批人T代表是，F代表不是
        /// </summary>		
		private string _nowreviewer;
        public string nowreviewer
        {
            get{ return _nowreviewer; }
            set{ _nowreviewer = value; }
        }        
		/// <summary>
		/// 序号（1,2,3）代表审批的顺序
        /// </summary>		
		private int _numbers;
        public int numbers
        {
            get{ return _numbers; }
            set{ _numbers = value; }
        }        
		/// <summary>
		/// 审核的时间
        /// </summary>		
		private DateTime _audittime;
        public DateTime audittime
        {
            get{ return _audittime; }
            set{ _audittime = value; }
        }        
		/// <summary>
		/// 审批操作，通过/未通过/未操作
        /// </summary>		
		private string _auditoperat;
        public string auditoperat
        {
            get{ return _auditoperat; }
            set{ _auditoperat = value; }
        }        
		/// <summary>
		/// 未审批/已审批
        /// </summary>		
		private string _operatstatus;
        public string operatstatus
        {
            get{ return _operatstatus; }
            set{ _operatstatus = value; }
        }


        /// <summary>
        /// 审批意见
        /// </summary>
        private string _opiniontxt;
        public string opiniontxt
        {
            get { return _opiniontxt; }
            set { _opiniontxt = value; }
        }

		   
	}
}

