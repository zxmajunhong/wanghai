using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class LoginInfo
    {
        //LoginInfo���Ĭ�Ϲ��췽��
        public LoginInfo()
        {

        }
        private int id;
        /// <summary>
        ///[LoginInfo]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string loginid;
        /// <summary>
        ///[LoginInfo]�� [loginid]��
        /// </summary>
        public string Loginid
        {
            get { return loginid; }
            set { this.loginid = value; }
        }
        private string loginpwd;
        /// <summary>
        ///[LoginInfo]�� [loginpwd]��
        /// </summary>
        public string Loginpwd
        {
            get { return loginpwd; }
            set { this.loginpwd = value; }
        }
        private string cname;
        /// <summary>
        ///[LoginInfo]�� [cname]��
        /// </summary>
        public string Cname
        {
            get { return cname; }
            set { this.cname = value; }
        }
        private string ename;
        /// <summary>
        ///[LoginInfo]�� [ename]��
        /// </summary>
        public string Ename
        {
            get { return ename; }
            set { this.ename = value; }
        }
        private string email;
        /// <summary>
        ///[LoginInfo]�� [email]��
        /// </summary>
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        private int roleid;
        /// <summary>
        ///[LoginInfo]�� [roleid]��
        /// </summary>
        public int Roleid
        {
            get { return roleid; }
            set { this.roleid = value; }
        }
        private int departid;
        /// <summary>
        ///[LoginInfo]�� [departid]��
        /// </summary>
        public int Departid
        {
            get { return departid; }
            set { this.departid = value; }
        }
        private string tel;
        /// <summary>
        ///[LoginInfo]�� [tel]��
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { this.tel = value; }
        }
        private string fax;
        /// <summary>
        ///[LoginInfo]�� [fax]��
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { this.fax = value; }
        }
        private string firmidlist;
        /// <summary>
        ///[LoginInfo]�� [firmidlist]��
        /// </summary>
        public string Firmidlist
        {
            get { return firmidlist; }
            set { this.firmidlist = value; }
        }
        private string firmtxtlist;
        /// <summary>
        ///[LoginInfo]�� [firmtxtlist]��
        /// </summary>
        public string Firmtxtlist
        {
            get { return firmtxtlist; }
            set { this.firmtxtlist = value; }
        }

        private int postid;

        public int Postid
        {
            get { return postid; }
            set { this.postid = value; }
        }

        /// <summary>
        /// ����Ա�ڶ����е����ϵ��
        /// </summary>
        public double orderRate
        {
            get;
            set;
        }

        /// <summary>
        /// �ж��û��Ƿ��ܹ��鿴�ҵĶ����б������һ�� 0���ܣ�1����
        /// </summary>
        public int isShowProfit
        {
            get;
            set;
        }
    }
}
