using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace EtNet_Models
{
	 	//ApprovalRule
    public class ApprovalRule
    {

        /// <summary>
        /// 主键id值
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 审批的类别
        /// </summary>		
        private string _sort;
        public string sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        /// <summary>
        /// 审核人员的id字段
        /// </summary>		
        private string _idgourp;
        public string idgourp
        {
            get { return _idgourp; }
            set { _idgourp = value; }
        }
        /// <summary>
        /// 审核人员清单
        /// </summary>		
        private string _txt;
        public string txt
        {
            get { return _txt; }
            set { _txt = value; }
        }

        /// <summary>
        /// 所属的工作流分类
        /// </summary>
        private string _jobflowsort;
        public string jobflowsort
        {
            get { return _jobflowsort; }
            set { _jobflowsort = value; }
        }

        /// <summary>
        /// 规则的名称
        /// </summary>
        private string _cname;
        public string cname
        {
            get { return _cname; }
            set { _cname = value; }
        }


        /// <summary>
        /// 规则的表格形式
        /// </summary>
        private string _rolepic;
        public string rolepic
        {
            get { return _rolepic; }
            set { _rolepic = value; }
        }


        /// <summary>
        /// 部门的id值列表
        /// </summary>
        private string _departidlist;
        public string departidlist
        {
            get { return _departidlist; }
            set { _departidlist = value; }
        }

        
        /// <summary>
        /// 部门文本值
        /// </summary>
        private string _departidtxt;
        public string departidtxt
        {
            get { return _departidtxt; }
            set { _departidtxt = value; }
        }
        /// <summary>
        /// 隐藏显示
        /// </summary>
        private int _hide;
        public int hide
        {
            get { return _hide; }
            set { _hide = value; }
        }
        /// <summary>
        /// 流程图显示方式
        /// </summary>
        private int _showpattern;
        public int showpattern
        {
            get { return _showpattern; }
            set { _showpattern = value; }
        }

       

    } 
}

