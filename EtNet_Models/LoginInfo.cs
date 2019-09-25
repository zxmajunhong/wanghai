using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class LoginInfo
    {
        //LoginInfo表的默认构造方法
        public LoginInfo()
        {

        }
        private int id;
        /// <summary>
        ///[LoginInfo]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string loginid;
        /// <summary>
        ///[LoginInfo]表 [loginid]列
        /// </summary>
        public string Loginid
        {
            get { return loginid; }
            set { this.loginid = value; }
        }
        private string loginpwd;
        /// <summary>
        ///[LoginInfo]表 [loginpwd]列
        /// </summary>
        public string Loginpwd
        {
            get { return loginpwd; }
            set { this.loginpwd = value; }
        }
        private string cname;
        /// <summary>
        ///[LoginInfo]表 [cname]列
        /// </summary>
        public string Cname
        {
            get { return cname; }
            set { this.cname = value; }
        }
        private string ename;
        /// <summary>
        ///[LoginInfo]表 [ename]列
        /// </summary>
        public string Ename
        {
            get { return ename; }
            set { this.ename = value; }
        }
        private string email;
        /// <summary>
        ///[LoginInfo]表 [email]列
        /// </summary>
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        private int roleid;
        /// <summary>
        ///[LoginInfo]表 [roleid]列
        /// </summary>
        public int Roleid
        {
            get { return roleid; }
            set { this.roleid = value; }
        }
        private int departid;
        /// <summary>
        ///[LoginInfo]表 [departid]列
        /// </summary>
        public int Departid
        {
            get { return departid; }
            set { this.departid = value; }
        }
        private string tel;
        /// <summary>
        ///[LoginInfo]表 [tel]列
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { this.tel = value; }
        }
        private string fax;
        /// <summary>
        ///[LoginInfo]表 [fax]列
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { this.fax = value; }
        }
        private string firmidlist;
        /// <summary>
        ///[LoginInfo]表 [firmidlist]列
        /// </summary>
        public string Firmidlist
        {
            get { return firmidlist; }
            set { this.firmidlist = value; }
        }
        private string firmtxtlist;
        /// <summary>
        ///[LoginInfo]表 [firmtxtlist]列
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
        /// 操作员在订单中的提成系数
        /// </summary>
        public double orderRate
        {
            get;
            set;
        }

        /// <summary>
        /// 判断用户是否能够查看我的订单列表的利润一列 0不能，1可以
        /// </summary>
        public int isShowProfit
        {
            get;
            set;
        }
    }
}
