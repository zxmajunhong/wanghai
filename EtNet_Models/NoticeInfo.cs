using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class NoticeInfo
    {
        //NoticeInfo���Ĭ�Ϲ��췽��
        public NoticeInfo()
        {

        }
        private int noticeid;
        /// <summary>
        ///[NoticeInfo]������
        /// </summary>
        public int Noticeid
        {
            get { return noticeid; }
            set { this.noticeid = value; }
        }
        private string title;
        /// <summary>
        ///[NoticeInfo]�� [title]��
        /// </summary>
        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }
        private SortInfo sortid;
        /// <summary>
        ///[NoticeInfo]�����
        ///ԭ����[sortid]
        ///ԭ����[int]
        ///������[SortInfo]
        ///������[sortid]
        /// </summary>
        public SortInfo Sortid
        {
            get { return sortid; }
            set { this.sortid = value; }
        }
        private int ifpublic;
        /// <summary>
        ///[NoticeInfo]�� [ifpublic]��
        /// </summary>
        public int Ifpublic
        {
            get { return ifpublic; }
            set { this.ifpublic = value; }
        }
        private string fromuser;
        /// <summary>
        ///[NoticeInfo]�� [fromuser]��
        /// </summary>
        public string Fromuser
        {
            get { return fromuser; }
            set { this.fromuser = value; }
        }
        private DateTime begintime;
        /// <summary>
        ///[NoticeInfo]�� [begintime]��
        /// </summary>
        public DateTime Begintime
        {
            get { return begintime; }
            set { this.begintime = value; }
        }
        private DateTime endtime;
        /// <summary>
        ///[NoticeInfo]�� [endtime]��
        /// </summary>
        public DateTime Endtime
        {
            get { return endtime; }
            set { this.endtime = value; }
        }
        private int attribute;
        /// <summary>
        ///[NoticeInfo]�� [attribute]��
        /// </summary>
        public int Attribute
        {
            get { return attribute; }
            set { this.attribute = value; }
        }
        private string accressory;
        /// <summary>
        ///[NoticeInfo]�� [accressory]��
        /// </summary>
        public string Accressory
        {
            get { return accressory; }
            set { this.accressory = value; }
        }
        private string context;
        /// <summary>
        ///[NoticeInfo]�� [context]��
        /// </summary>
        public string Context
        {
            get { return context; }
            set { this.context = value; }
        }
    }
}
