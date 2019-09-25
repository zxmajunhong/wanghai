using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models.View
{
    public class ViewInformation
    {
        private int _id; 
        /// <summary>
        ///消息的id值
        /// </summary>
        public int id
        {
            get { return _id; }
            set { _id = value; }
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
