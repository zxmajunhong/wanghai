using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models.View
{
    public class ViewApplyOfficeSupply
    {
        private int _id;

        /// <summary>
        /// 办公用品申请单的id值
        /// </summary>
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }


        private DateTime _applydate; 
 
        /// <summary>
        /// 申请日期
        /// </summary>

        public DateTime applydate
        {
            get { return _applydate; }
            set { _applydate = value; }
        }

        private string _remark; 

        /// <summary>
        /// 申请时的备注
        /// </summary>
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }



        private string _txt;   
        /// <summary>
        /// 审核人员的意见
        /// </summary>
        public string txt
        {
            get { return _txt; }
            set { _txt = value; }
        }

        private int _jobflowid;
        /// <summary>
        /// 工作流的id值
        /// </summary>
        public int jobflowid
        {
            get { return _jobflowid; }
            set { _jobflowid = value; }
        }

        private string _cname;
        /// <summary>
        ///审核单据的单据号
        /// </summary>
        public string cname
        {
            get { return _cname; }
            set { _cname = value; }
        }

        private string _savestatus;
        /// <summary>
        /// 保存的状态
        /// </summary>
        public string savestatus
        {
            get { return _savestatus; }
            set { _savestatus = value; }
        }

        private string _sort;
        /// <summary>
        ///工作流的分类
        /// </summary>
        public string sort
        {
            get { return _sort; }
            set { _sort = value; }
        }



        private string _sorttxt;
        /// <summary>
        ///工作流分类的文本    
        /// </summary>
        public string sorttxt
        {
            get { return _sorttxt; }
            set { _sorttxt = value; }
        }


        private string _auditstatus;
        /// <summary>
        /// 审核的状态
        /// </summary>
        public string auditstatus
        {
            get { return _auditstatus; }
            set { _auditstatus = value; }
        }



        private string _auditstutastxt;
        /// <summary>
        /// 审核的状态的文本表示
        /// </summary>
        public string auditstutastxt
        {
            get { return _auditstutastxt; }
            set { _auditstutastxt = value; }
        }


        private int _founderid;
        /// <summary>
        /// 创建人的id值
        /// </summary>
        public int founderid
        {
            get { return _founderid; }
            set { _founderid = value; }
        }



        private string _logincname;
        /// <summary>
        /// 创建人的名称
        /// </summary>
        public string logincname
        {
            get { return _logincname; }
            set { _logincname = value; }
        }

        private string _departcname;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string departcname
        {
            get { return _departcname; }
            set { _departcname = value; }
        }


        private int _ruleid;
        /// <summary>
        ///审核规则的id值
        /// </summary>
        public int ruleid
        {
            get { return _ruleid; }
            set { _ruleid = value; }
        }


        private string _rulesort;
        /// <summary>
        /// 审核的类型,单审，会签，选审
        /// </summary>
        public string rulesort
        {
            get { return _rulesort; }
            set { _rulesort = value; }
        }


        private string _idgourp;
        /// <summary>
        ///审核人员的id序列
        /// </summary>
        public string idgourp
        {
            get { return _idgourp; }
            set { _idgourp = value; }
        }



        private string _rolepic;
        /// <summary>
        /// 审核流程图
        /// </summary>
        public string rolepic
        {
            get { return _rolepic; }
            set { _rolepic = value; }
        }







    }
}
