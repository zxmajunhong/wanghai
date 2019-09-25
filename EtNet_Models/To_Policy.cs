using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_Policy
    {
        //To_Policy���Ĭ�Ϲ��췽��
        public To_Policy()
        {

        }
        private int id;
        /// <summary>
        ///[To_Policy]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string serialnum;
        /// <summary>
        ///[To_Policy]�� [serialnum]��
        /// </summary>
        public string Serialnum
        {
            get { return serialnum; }
            set { this.serialnum = value; }
        }
        private DateTime policy_date;
        /// <summary>
        ///[To_Policy]�� [policy_date]��
        /// </summary>
        public DateTime Policy_date
        {
            get { return policy_date; }
            set { this.policy_date = value; }
        }
        private string policy_maker;
        /// <summary>
        ///[To_Policy]�� [policy_maker]��
        /// </summary>
        public string Policy_maker
        {
            get { return policy_maker; }
            set { this.policy_maker = value; }
        }
        private int policy_makerId;
        /// <summary>
        ///[To_Policy]�� [policy_maker]��
        /// </summary>
        public int Policy_makerId
        {
            get { return policy_makerId; }
            set { this.policy_makerId = value; }
        }
        private string policy_num;
        /// <summary>
        ///[To_Policy]�� [policy_num]��
        /// </summary>
        public string Policy_num
        {
            get { return policy_num; }
            set { this.policy_num = value; }
        }
        private string policy_startdate;
        /// <summary>
        ///[To_Policy]�� [policy_startdate]��
        /// </summary>
        public string Policy_startdate
        {
            get { return policy_startdate; }
            set { this.policy_startdate = value; }
        }
        private string policy_enddate;
        /// <summary>
        ///[To_Policy]�� [policy_enddate]��
        /// </summary>
        public string Policy_enddate
        {
            get { return policy_enddate; }
            set { this.policy_enddate = value; }
        }
        private int policy_state;
        /// <summary>
        ///[To_Policy]�� [policy_state]��
        /// </summary>
        public int Policy_state
        {
            get { return policy_state; }
            set { this.policy_state = value; }
        }
        private string assured;
        /// <summary>
        ///[To_Policy]�� [assured]��
        /// </summary>
        public string Assured
        {
            get { return assured; }
            set { this.assured = value; }
        }
        private int customer;
        /// <summary>
        ///[To_Policy]�� [customer]��
        /// </summary>
        public int Customer
        {
            get { return customer; }
            set { this.customer = value; }
        }
        private int company;
        /// <summary>
        ///[To_Policy]�� [company]��
        /// </summary>
        public int Company
        {
            get { return company; }
            set { this.company = value; }
        }
        private string protype;
        /// <summary>
        ///[To_Policy]�� [protype]��
        /// </summary>
        public string Protype
        {
            get { return protype; }
            set { this.protype = value; }
        }
        private double totalPremium;
        /// <summary>
        ///[To_Policy]�� [totalPremium]�� �ܱ���
        /// </summary>
        public double TotalPremium
        {
            get { return totalPremium; }
            set { this.totalPremium = value; }
        }
        private double totalBrokerage;
        /// <summary>
        ///[To_Policy]�� [totalBrokerage]�� �ܱ���
        /// </summary>
        public double TotalBrokerage
        {
            get { return totalBrokerage; }
            set { this.totalBrokerage = value; }
        }
        private int isVerify;
        /// <summary>
        ///[To_Policy]�� [isVerify]��
        /// </summary>
        public int IsVerify
        {
            get { return isVerify; }
            set { this.isVerify = value; }
        }
        private string verifyUser;
        /// <summary>
        ///[To_Policy]�� [verifyUser]��
        /// </summary>
        public string VerifyUser
        {
            get { return verifyUser; }
            set { this.verifyUser = value; }
        }
        private DateTime verifydate;
        /// <summary>
        ///[To_Policy]�� [verifydate]��
        /// </summary>
        public DateTime Verifydate
        {
            get { return verifydate; }
            set { this.verifydate = value; }
        }
        private int salesman;
        /// <summary>
        ///[To_Policy]�� [salesman]��
        /// </summary>
        public int Salesman
        {
            get { return salesman; }
            set { this.salesman = value; }
        }
        private int isRenewal;
        public int IsRenewal
        {
            get { return isRenewal; }
            set { this.isRenewal = value; }
        }

        private string usercompany;
        /// <summary>
        /// [To_Policy]��[UserCompany]�С�������˾
        /// </summary>
        public string UserCompany
        {
            get { return usercompany; }
            set { this.usercompany = value; }
        }

        private int isDaidian;
        /// <summary>
        /// �Ƿ���汣��
        /// </summary>
        public int IsDaidian
        {
            get { return isDaidian; }
            set { this.isDaidian = value; }
        }

        private string txt;
        /// <summary>
        /// ������
        /// </summary>
        public string Txt
        {
            get { return txt; }
            set { this.txt = value; }
        }

        private string orderNum;
        /// <summary>
        /// ��ˮ��
        /// </summary>
        public string OrderNum
        {
            get { return orderNum; }
            set { this.orderNum = value; }
        }

        private string codeFormart;
        /// <summary>
        /// �������
        /// </summary>
        public string CodeFormart
        {
            get { return codeFormart; }
            set { this.codeFormart = value; }
        }

        private double totalEcoRate;
        /// <summary>
        /// �ܾ��÷ѱ���
        /// </summary>
        public double TotalEcoRate
        {
            get { return totalEcoRate; }
            set { this.totalEcoRate = value; }
        }

        private double totalEconomic;
        /// <summary>
        /// �ܾ��÷�
        /// </summary>
        public double TotalEconomic
        {
            get { return totalEconomic; }
            set { this.totalEconomic = value; }
        }

        private double totalRich;
        /// <summary>
        /// ������
        /// </summary>
        public double TotalRich
        {
            get { return totalRich; }
            set { this.totalRich = value; }
        }

        private string shipName;
        /// <summary>
        /// ����
        /// </summary>
        public string ShipName
        {
            get { return shipName; }
            set { this.shipName = value; }
        }

        private string persons;
        /// <summary>
        /// ҵ��Ա����
        /// </summary>
        public string Persons
        {
            get { return persons; }
            set { this.persons = value; }
        }
    }
}
