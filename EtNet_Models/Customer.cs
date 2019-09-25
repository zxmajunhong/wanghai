using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class Customer
    {
        //Customer表的默认构造方法
        public Customer()
        {

        }
        private int id;
        /// <summary>
        ///[Customer]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string cusCode;
        /// <summary>
        ///[Customer]表 [cusCode]列
        /// </summary>
        public string CusCode
        {
            get { return cusCode; }
            set { this.cusCode = value; }
        }
        private int cusType;
        /// <summary>
        ///[Customer]表 [cusType]列
        /// </summary>
        public int CusType
        {
            get { return cusType; }
            set { this.cusType = value; }
        }
        private int cusPro;
        /// <summary>
        ///[Customer]表 [cusPro]列
        /// </summary>
        public int CusPro
        {
            get { return cusPro; }
            set { this.cusPro = value; }
        }
        private string cusshortName;
        /// <summary>
        ///[Customer]表 [cusshortName]列
        /// </summary>
        public string CusshortName
        {
            get { return cusshortName; }
            set { this.cusshortName = value; }
        }
        private string cusCName;
        /// <summary>
        ///[Customer]表 [cusCName]列
        /// </summary>
        public string CusCName
        {
            get { return cusCName; }
            set { this.cusCName = value; }
        }
        private string cusCAddress;
        /// <summary>
        ///[Customer]表 [cusCAddress]列
        /// </summary>
        public string CusCAddress
        {
            get { return cusCAddress; }
            set { this.cusCAddress = value; }
        }
        private string province;
        /// <summary>
        ///[Customer]表 [province]列
        /// </summary>
        public string Province
        {
            get { return province; }
            set { this.province = value; }
        }
        private string city;
        /// <summary>
        ///[Customer]表 [city]列
        /// </summary>
        public string City
        {
            get { return city; }
            set { this.city = value; }
        }
        private string companyURL;
        /// <summary>
        ///[Customer]表 [companyURL]列
        /// </summary>
        public string CompanyURL
        {
            get { return companyURL; }
            set { this.companyURL = value; }
        }
        private int used;
        /// <summary>
        ///[Customer]表 [used]列
        /// </summary>
        public int Used
        {
            get { return used; }
            set { this.used = value; }
        }
        private string linkName;
        /// <summary>
        ///[Customer]表 [linkName]列
        /// </summary>
        public string LinkName
        {
            get { return linkName; }
            set { this.linkName = value; }
        }
        private string post;
        /// <summary>
        ///[Customer]表 [post]列
        /// </summary>
        public string Post
        {
            get { return post; }
            set { this.post = value; }
        }
        private string telephone;
        /// <summary>
        ///[Customer]表 [telephone]列
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set { this.telephone = value; }
        }
        private string fax;
        /// <summary>
        ///[Customer]表 [fax]列
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { this.fax = value; }
        }
        private string mobile;
        /// <summary>
        ///[Customer]表 [mobile]列
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { this.mobile = value; }
        }
        private string email;
        /// <summary>
        ///[Customer]表 [email]列
        /// </summary>
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        private string msn;
        /// <summary>
        ///[Customer]表 [msn]列
        /// </summary>
        public string Msn
        {
            get { return msn; }
            set { this.msn = value; }
        }
        private string skype;
        /// <summary>
        ///[Customer]表 [skype]列
        /// </summary>
        public string Skype
        {
            get { return skype; }
            set { this.skype = value; }
        }
        private string bank;
        /// <summary>
        ///[Customer]表 [bank]列
        /// </summary>
        public string Bank
        {
            get { return bank; }
            set { this.bank = value; }
        }
        private string cardId;
        /// <summary>
        ///[Customer]表 [cardId]列
        /// </summary>
        public string CardId
        {
            get { return cardId; }
            set { this.cardId = value; }
        }
        private string cardName;
        /// <summary>
        ///[Customer]表 [cardName]列
        /// </summary>
        public string CardName
        {
            get { return cardName; }
            set { this.cardName = value; }
        }
        private string remark;
        /// <summary>
        ///[Customer]表 [remark]列
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { this.remark = value; }
        }
        private string ordernum;
        /// <summary>
        ///[Customer]表 [ordernum]列
        /// </summary>
        public string Ordernum
        {
            get { return ordernum; }
            set { this.ordernum = value; }
        }
        private string codeformat;
        /// <summary>
        ///[Customer]表 [codeformat]列
        /// </summary>
        public string Codeformat
        {
            get { return codeformat; }
            set { this.codeformat = value; }
        }
        private int madefrom;
        /// <summary>
        ///[Customer]表 [madefrom]列
        /// </summary>
        public int Madefrom
        {
            get { return madefrom; }
            set { this.madefrom = value; }
        }
        private DateTime madeTime;
        /// <summary>
        ///[Customer]表 [madeTime]列
        /// </summary>
        public DateTime MadeTime
        {
            get { return madeTime; }
            set { this.madeTime = value; }
        }



        /// <summary>
        /// 工作流的id值
        /// </summary>
        private int jobflowid;
        public int Jobflowid
        {
            get { return jobflowid; }
            set { jobflowid = value; }
        }


        /// <summary>
        ///审核人员填写
        /// </summary>
        private string txt;
        public string Txt
        {
            get { return txt; }
            set { txt = value; }
        }


        /// <summary>
        ///查看人员的id值
        /// </summary>
        private string viewidlist;
        public string Viewidlist
        {
            get { return viewidlist; }
            set { viewidlist = value; }
        }

        /// <summary>
        /// 查看人员的文本值
        /// </summary>
        private string viewidtxt;
        public string Viewidtxt
        {
            get { return viewidtxt; }
            set { viewidtxt = value; }
        }

        /// <summary>
        /// 权限人员的id值
        /// </summary>
        private string authidlist;
        public string Authidlist
        {
            get { return authidlist; }
            set { authidlist = value; }
        }

        /// <summary>
        /// 权限人员的文本值
        /// </summary>
        private string authidtxt;
        public string Authidtxt
        {
            get { return authidtxt; }
            set { authidtxt = value; }
        }
        /// <summary>
        /// 新客户提成系数
        /// </summary>
        public double newRatio { get; set; }

        /// <summary>
        /// 老客户提成系数
        /// </summary>
        public double oldRatio { get; set; }

        /// <summary>
        /// 最后修改人员
        /// </summary>
        public string LastEditMan { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastEditDate { get; set; }
    }
}
