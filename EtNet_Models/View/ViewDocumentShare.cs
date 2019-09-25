using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models.View
{
    public class ViewDocumentShare
    {


        private int _id;
        /// <summary>
        /// 文档分享的主键
        /// </summary>
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }



        private int _acceptpeopleid;
        /// <summary>
        /// 接受分享的人员的id值
        /// </summary>
        public int acceptpeopleid
        {
            get { return _acceptpeopleid; }
            set { _acceptpeopleid = value; }
        }


        private string _acceptpeopleloginid;
        /// <summary>
        /// 接受分享的人员的登录号
        /// </summary>
        public string acceptpeopleloginid
        {
            get { return _acceptpeopleloginid; }
            set { _acceptpeopleloginid = value; }
        }



        private string _acceptpeoplecname;
        /// <summary>
        /// 接受分享的人员的名称
        /// </summary>
        public string acceptpeoplecname
        {
            get { return _acceptpeoplecname; }
            set { _acceptpeoplecname = value; }
        }


        private int _departid;
        /// <summary>
        /// 接受分享人员的部门
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


        private int _documentid;
        /// <summary>
        /// 文档分享的主键
        /// </summary>
        public int documentid
        {
            get { return _documentid; }
            set { _documentid = value; }
        }


        private int _founderid;

        /// <summary>
        /// 文档创建人的id值
        /// </summary>

        public int founderid
        {
            get { return _founderid; }
            set { _founderid = value; }
        }

        private string _founderloginid;
        /// <summary>
        /// 文档创建人的登录号
        /// </summary>

        public string founderloginid
        {
            get { return _founderloginid; }
            set { _founderloginid = value; }

        }

        private string _foundercname;
        /// <summary>
        /// 文档创建人的名称
        /// </summary>
        public string foundercname
        {
            get { return _foundercname; }
            set { _foundercname = value; }
        }




        private int _directoryid;
        /// <summary>
        /// 文件夹的id值
        /// </summary>
        public int directoryid
        {
            get { return _directoryid; }
            set { _directoryid = value; }
        }


        private string _directorycname;
        /// <summary>
        /// 文件夹的名称
        /// </summary>
        public string directorycname
        {
            get { return _directorycname; }
            set { _directorycname = value; }
        }


        private string _cname;
        /// <summary>
        /// 文档的名称
        /// </summary>
        public string cname
        {
            get { return _cname; }
            set { _cname = value; }
        }


        private string _contents;
        /// <summary>
        /// 文档的内容
        /// </summary>
        public string contents
        {
            get { return _contents; }
            set { _contents = value; }
        }

        private DateTime _createtime;
        /// <summary>
        /// 文档的创建时间
        /// </summary>
        public DateTime createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }


        private DateTime _modifytime;
        /// <summary>
        /// 文档的修改时间
        /// </summary>
        public DateTime modifytime
        {
            get { return _modifytime; }
            set { _modifytime = value; }
        }


        private int _sort;
        /// <summary>
        /// 文档的分类
        /// </summary>
        public int sort
        {
            get { return _sort; }
            set { _sort = value; }
        }


        private string _sorttxt;
        /// <summary>
        /// 文档的分类的文本
        /// </summary>
        public string sorttxt
        {
            get { return _sorttxt; }
            set { _sorttxt = value; }
        }


        private int _founderdepartid;
        /// <summary>
        /// 文档创建人的部门id值
        /// </summary>
        public int founderdepartid
        {
            get { return _founderdepartid; }
            set { _founderdepartid = value; }
        }


        private string _founderdepartcname;
        /// <summary>
        /// 文档创建人的部门名称
        /// </summary>
        public string founderdepartcname
        {
            get { return _founderdepartcname; }
            set { _founderdepartcname = value; }
        }

        private string _sharestatus;
        /// <summary>
        /// 分享的状态值分为私有,分享
        /// </summary>
        public string sharestatus
        {
            get { return _sharestatus; }
            set { _sharestatus = value; }
        }

        private string _doctype;
        /// <summary>
        /// 文档归属于个人文档还是公共文档
        /// </summary>
        public string doctype
        {
            get { return _doctype; }
            set { _doctype = value; }
        }



    }
}
