using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class CusLinkman
    {
        //CusLinkman���Ĭ�Ϲ��췽��
        public CusLinkman()
        {

        }
        private int id;
        /// <summary>
        ///[CusLinkman]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int customerId;
        /// <summary>
        ///[CusLinkman]�� [customerId]��
        /// </summary>
        public int CustomerId
        {
            get { return customerId; }
            set { this.customerId = value; }
        }
        private string linkName;
        /// <summary>
        ///[CusLinkman]�� [linkName]��
        /// </summary>
        public string LinkName
        {
            get { return linkName; }
            set { this.linkName = value; }
        }
        private string post;
        /// <summary>
        ///[CusLinkman]�� [post]��
        /// </summary>
        public string Post
        {
            get { return post; }
            set { this.post = value; }
        }
        private string telephone;
        /// <summary>
        ///[CusLinkman]�� [telephone]��
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set { this.telephone = value; }
        }
        private string fax;
        /// <summary>
        ///[CusLinkman]�� [fax]��
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { this.fax = value; }
        }
        private string mobile;
        /// <summary>
        ///[CusLinkman]�� [mobile]��
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { this.mobile = value; }
        }
        private string email;
        /// <summary>
        ///[CusLinkman]�� [email]��
        /// </summary>
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        private string msn;
        /// <summary>
        ///[CusLinkman]�� [msn]��
        /// </summary>
        public string Msn
        {
            get { return msn; }
            set { this.msn = value; }
        }
        private string skype;
        /// <summary>
        ///[CusLinkman]�� [skype]��
        /// </summary>
        public string Skype
        {
            get { return skype; }
            set { this.skype = value; }
        }

        /// <summary>
        /// Ӫҵ������[departName]��
        /// </summary>
        public string DepartName { get; set; }
    }
}
