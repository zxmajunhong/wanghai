using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class CusLinkman
    {
        //CusLinkman表的默认构造方法
        public CusLinkman()
        {

        }
        private int id;
        /// <summary>
        ///[CusLinkman]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int customerId;
        /// <summary>
        ///[CusLinkman]表 [customerId]列
        /// </summary>
        public int CustomerId
        {
            get { return customerId; }
            set { this.customerId = value; }
        }
        private string linkName;
        /// <summary>
        ///[CusLinkman]表 [linkName]列
        /// </summary>
        public string LinkName
        {
            get { return linkName; }
            set { this.linkName = value; }
        }
        private string post;
        /// <summary>
        ///[CusLinkman]表 [post]列
        /// </summary>
        public string Post
        {
            get { return post; }
            set { this.post = value; }
        }
        private string telephone;
        /// <summary>
        ///[CusLinkman]表 [telephone]列
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set { this.telephone = value; }
        }
        private string fax;
        /// <summary>
        ///[CusLinkman]表 [fax]列
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { this.fax = value; }
        }
        private string mobile;
        /// <summary>
        ///[CusLinkman]表 [mobile]列
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { this.mobile = value; }
        }
        private string email;
        /// <summary>
        ///[CusLinkman]表 [email]列
        /// </summary>
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        private string msn;
        /// <summary>
        ///[CusLinkman]表 [msn]列
        /// </summary>
        public string Msn
        {
            get { return msn; }
            set { this.msn = value; }
        }
        private string skype;
        /// <summary>
        ///[CusLinkman]表 [skype]列
        /// </summary>
        public string Skype
        {
            get { return skype; }
            set { this.skype = value; }
        }

        /// <summary>
        /// 营业部名称[departName]列
        /// </summary>
        public string DepartName { get; set; }
    }
}
