using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models.View
{
    public class ViewInformationNotice
    {
       
        private int _id;
        /// <summary>
        ///通知列表的id值
        /// </summary>
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        
       
        private int _recipientid;
        /// <summary>
        ///接收人员的id值
        /// </summary>
        public int recipientid
        {
            get { return _recipientid; }
            set { _recipientid = value; }
        }
        

    
        private string _recipientloginid;
        /// <summary>
        ///接收人员的登录号
        /// </summary>
        public string recipientloginid
        {
            get { return _recipientloginid; }
            set { _recipientloginid = value; }
        }
        
        
      
        private string _recipientcname;
        /// <summary>
        ///接收人员的名称
        /// </summary>
        public string recipientcname
        {
            get { return _recipientcname; }
            set { _recipientcname = value; }
        } 


       
        private string _recipientdepartcname;
        /// <summary>
        ///接收人员的部门的名称 
        /// </summary>
        public string recipientdepartcname
        {
            get { return _recipientdepartcname; }
            set { _recipientdepartcname = value; }
        }
        

      
        private int _informationid;
        /// <summary>
        ///消息的id值
        /// </summary>
        public int informationid
        {
            get { return _informationid; }
            set { _informationid = value; }
        }

        private string _contents;
        /// <summary>
        ///消息的内容
        /// </summary>
        public string contents
        {
            get { return _contents; }
            set { _contents = value; }
        }

        private int _sortid;
        /// <summary>
        ///消息的分类的id值
        /// </summary>
        public int sortid
        {
            get { return _sortid; }
            set { _sortid = value; }
        }


        private string _txt;
        /// <summary>
        ///消息的文本值
        /// </summary>
        public string txt
        {
            get { return _txt; }
            set { _txt = value; }
        }


        private int _associationid;
        /// <summary>
        ///消息的分类关联的id值，如文档的id值等
        /// </summary>
        public int associationid
        {
            get { return _associationid; }
            set { _associationid = value; }
        }



        private string _remind;
        /// <summary>
        ///是否为提醒
        /// </summary>
        public string remind
        {
            get { return _remind; }
            set { _remind = value; }
        }


        private int _founderid;
        /// <summary>
        /// 消息创建人的id值
        /// </summary>
        public int founderid
        {
            get { return _founderid; }
            set { _founderid = value; }
        }


        private string _loginid;
        /// <summary>
        ///消息创建人的登录名
        /// </summary>
        public string loginid
        {
            get { return _loginid; }
            set { _loginid = value; }
        }


        private string _cname;
        /// <summary>
        ///消息创建人的名称
        /// </summary>
        public string cname
        {
            get { return _cname; }
            set { _cname = value; }
        }


        private string _departcname;
        /// <summary>
        ///消息创建人的部门的名称
        /// </summary>
        public string departcname
        {
            get { return _departcname; }
            set { _departcname = value; }
        }


        private DateTime _createtime;
        /// <summary>
        ///消息的创建时间 
        /// </summary>
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }


        private DateTime _sendtime;
        /// <summary>
        ///消息的发送时间
        /// </summary>
        public DateTime sendtime
        {
            get { return _sendtime; }
            set { _sendtime = value; }
        }











    }
}
