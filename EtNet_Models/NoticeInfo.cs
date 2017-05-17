using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class NoticeInfo
    {
        //NoticeInfo表的默认构造方法
        public NoticeInfo()
        {

        }
        private int noticeid;
        /// <summary>
        ///[NoticeInfo]表主键
        /// </summary>
        public int Noticeid
        {
            get { return noticeid; }
            set { this.noticeid = value; }
        }
        private string title;
        /// <summary>
        ///[NoticeInfo]表 [title]列
        /// </summary>
        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }
        private SortInfo sortid;
        /// <summary>
        ///[NoticeInfo]表外键
        ///原列名[sortid]
        ///原类型[int]
        ///主键表[SortInfo]
        ///关联列[sortid]
        /// </summary>
        public SortInfo Sortid
        {
            get { return sortid; }
            set { this.sortid = value; }
        }
        private int ifpublic;
        /// <summary>
        ///[NoticeInfo]表 [ifpublic]列
        /// </summary>
        public int Ifpublic
        {
            get { return ifpublic; }
            set { this.ifpublic = value; }
        }
        private string fromuser;
        /// <summary>
        ///[NoticeInfo]表 [fromuser]列
        /// </summary>
        public string Fromuser
        {
            get { return fromuser; }
            set { this.fromuser = value; }
        }
        private DateTime begintime;
        /// <summary>
        ///[NoticeInfo]表 [begintime]列
        /// </summary>
        public DateTime Begintime
        {
            get { return begintime; }
            set { this.begintime = value; }
        }
        private DateTime endtime;
        /// <summary>
        ///[NoticeInfo]表 [endtime]列
        /// </summary>
        public DateTime Endtime
        {
            get { return endtime; }
            set { this.endtime = value; }
        }
        private int attribute;
        /// <summary>
        ///[NoticeInfo]表 [attribute]列
        /// </summary>
        public int Attribute
        {
            get { return attribute; }
            set { this.attribute = value; }
        }
        private string accressory;
        /// <summary>
        ///[NoticeInfo]表 [accressory]列
        /// </summary>
        public string Accressory
        {
            get { return accressory; }
            set { this.accressory = value; }
        }
        private string context;
        /// <summary>
        ///[NoticeInfo]表 [context]列
        /// </summary>
        public string Context
        {
            get { return context; }
            set { this.context = value; }
        }
    }
}
