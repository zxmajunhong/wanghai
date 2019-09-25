using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class Customer
    {
        //Customer���Ĭ�Ϲ��췽��
        public Customer()
        {

        }
        private int id;
        /// <summary>
        ///[Customer]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string cusCode;
        /// <summary>
        ///[Customer]�� [cusCode]��
        /// </summary>
        public string CusCode
        {
            get { return cusCode; }
            set { this.cusCode = value; }
        }
        private int cusType;
        /// <summary>
        ///[Customer]�� [cusType]��
        /// </summary>
        public int CusType
        {
            get { return cusType; }
            set { this.cusType = value; }
        }
        private int cusPro;
        /// <summary>
        ///[Customer]�� [cusPro]��
        /// </summary>
        public int CusPro
        {
            get { return cusPro; }
            set { this.cusPro = value; }
        }
        private string cusshortName;
        /// <summary>
        ///[Customer]�� [cusshortName]��
        /// </summary>
        public string CusshortName
        {
            get { return cusshortName; }
            set { this.cusshortName = value; }
        }
        private string cusCName;
        /// <summary>
        ///[Customer]�� [cusCName]��
        /// </summary>
        public string CusCName
        {
            get { return cusCName; }
            set { this.cusCName = value; }
        }
        private string cusCAddress;
        /// <summary>
        ///[Customer]�� [cusCAddress]��
        /// </summary>
        public string CusCAddress
        {
            get { return cusCAddress; }
            set { this.cusCAddress = value; }
        }
        private string province;
        /// <summary>
        ///[Customer]�� [province]��
        /// </summary>
        public string Province
        {
            get { return province; }
            set { this.province = value; }
        }
        private string city;
        /// <summary>
        ///[Customer]�� [city]��
        /// </summary>
        public string City
        {
            get { return city; }
            set { this.city = value; }
        }
        private string companyURL;
        /// <summary>
        ///[Customer]�� [companyURL]��
        /// </summary>
        public string CompanyURL
        {
            get { return companyURL; }
            set { this.companyURL = value; }
        }
        private int used;
        /// <summary>
        ///[Customer]�� [used]��
        /// </summary>
        public int Used
        {
            get { return used; }
            set { this.used = value; }
        }
        private string linkName;
        /// <summary>
        ///[Customer]�� [linkName]��
        /// </summary>
        public string LinkName
        {
            get { return linkName; }
            set { this.linkName = value; }
        }
        private string post;
        /// <summary>
        ///[Customer]�� [post]��
        /// </summary>
        public string Post
        {
            get { return post; }
            set { this.post = value; }
        }
        private string telephone;
        /// <summary>
        ///[Customer]�� [telephone]��
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set { this.telephone = value; }
        }
        private string fax;
        /// <summary>
        ///[Customer]�� [fax]��
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { this.fax = value; }
        }
        private string mobile;
        /// <summary>
        ///[Customer]�� [mobile]��
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { this.mobile = value; }
        }
        private string email;
        /// <summary>
        ///[Customer]�� [email]��
        /// </summary>
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        private string msn;
        /// <summary>
        ///[Customer]�� [msn]��
        /// </summary>
        public string Msn
        {
            get { return msn; }
            set { this.msn = value; }
        }
        private string skype;
        /// <summary>
        ///[Customer]�� [skype]��
        /// </summary>
        public string Skype
        {
            get { return skype; }
            set { this.skype = value; }
        }
        private string bank;
        /// <summary>
        ///[Customer]�� [bank]��
        /// </summary>
        public string Bank
        {
            get { return bank; }
            set { this.bank = value; }
        }
        private string cardId;
        /// <summary>
        ///[Customer]�� [cardId]��
        /// </summary>
        public string CardId
        {
            get { return cardId; }
            set { this.cardId = value; }
        }
        private string cardName;
        /// <summary>
        ///[Customer]�� [cardName]��
        /// </summary>
        public string CardName
        {
            get { return cardName; }
            set { this.cardName = value; }
        }
        private string remark;
        /// <summary>
        ///[Customer]�� [remark]��
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { this.remark = value; }
        }
        private string ordernum;
        /// <summary>
        ///[Customer]�� [ordernum]��
        /// </summary>
        public string Ordernum
        {
            get { return ordernum; }
            set { this.ordernum = value; }
        }
        private string codeformat;
        /// <summary>
        ///[Customer]�� [codeformat]��
        /// </summary>
        public string Codeformat
        {
            get { return codeformat; }
            set { this.codeformat = value; }
        }
        private int madefrom;
        /// <summary>
        ///[Customer]�� [madefrom]��
        /// </summary>
        public int Madefrom
        {
            get { return madefrom; }
            set { this.madefrom = value; }
        }
        private DateTime madeTime;
        /// <summary>
        ///[Customer]�� [madeTime]��
        /// </summary>
        public DateTime MadeTime
        {
            get { return madeTime; }
            set { this.madeTime = value; }
        }



        /// <summary>
        /// ��������idֵ
        /// </summary>
        private int jobflowid;
        public int Jobflowid
        {
            get { return jobflowid; }
            set { jobflowid = value; }
        }


        /// <summary>
        ///�����Ա��д
        /// </summary>
        private string txt;
        public string Txt
        {
            get { return txt; }
            set { txt = value; }
        }


        /// <summary>
        ///�鿴��Ա��idֵ
        /// </summary>
        private string viewidlist;
        public string Viewidlist
        {
            get { return viewidlist; }
            set { viewidlist = value; }
        }

        /// <summary>
        /// �鿴��Ա���ı�ֵ
        /// </summary>
        private string viewidtxt;
        public string Viewidtxt
        {
            get { return viewidtxt; }
            set { viewidtxt = value; }
        }

        /// <summary>
        /// Ȩ����Ա��idֵ
        /// </summary>
        private string authidlist;
        public string Authidlist
        {
            get { return authidlist; }
            set { authidlist = value; }
        }

        /// <summary>
        /// Ȩ����Ա���ı�ֵ
        /// </summary>
        private string authidtxt;
        public string Authidtxt
        {
            get { return authidtxt; }
            set { authidtxt = value; }
        }
        /// <summary>
        /// �¿ͻ����ϵ��
        /// </summary>
        public double newRatio { get; set; }

        /// <summary>
        /// �Ͽͻ����ϵ��
        /// </summary>
        public double oldRatio { get; set; }

        /// <summary>
        /// ����޸���Ա
        /// </summary>
        public string LastEditMan { get; set; }

        /// <summary>
        /// ����޸�ʱ��
        /// </summary>
        public DateTime LastEditDate { get; set; }
    }
}
