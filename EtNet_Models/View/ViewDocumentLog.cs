using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models.View
{
    public class ViewDocumentLog
    {
        private int _id;
        /// <summary>
        /// 主键
        /// </summary>
        public int id
        {
          get { return _id; }
          set { _id = value; }
        }


        private int _operatorsid;
        /// <summary>
        /// 操作人id值
        /// </summary>
        public int operatorsid
        {
            get { return _operatorsid; }
            set { _operatorsid = value; }
        }


        private string _loginid;
        /// <summary>
        /// 登录名
        /// </summary>
        public string loginid
        {
            get { return _loginid; }
            set { _loginid = value; }
        }


        private string _cname;
        /// <summary>
        ///用户名
        /// </summary>
        public string cname
        {
            get { return _cname; }
            set { _cname = value; }
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


        private int _documentid;
        /// <summary>
        /// 文档的id值
        /// </summary>
        public int documentid
        {
            get { return _documentid; }
            set { _documentid = value; }
        }

        private string _myotype;
        /// <summary>
        /// 操作的类型
        /// </summary>
        public string myotype
        {
            get { return _myotype; }
            set { _myotype = value; }
        }

        private DateTime _operatime;
        /// <summary>
        /// 操作的时间
        /// </summary>
        public DateTime operatime
        {
            get { return _operatime; }
            set { _operatime = value; }
        }



    }
}
