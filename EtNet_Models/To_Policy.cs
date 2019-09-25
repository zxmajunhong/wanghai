using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_Policy
    {
        //To_Policy表的默认构造方法
        public To_Policy()
        {

        }
        private int id;
        /// <summary>
        ///[To_Policy]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string serialnum;
        /// <summary>
        ///[To_Policy]表 [serialnum]列
        /// </summary>
        public string Serialnum
        {
            get { return serialnum; }
            set { this.serialnum = value; }
        }
        private DateTime policy_date;
        /// <summary>
        ///[To_Policy]表 [policy_date]列
        /// </summary>
        public DateTime Policy_date
        {
            get { return policy_date; }
            set { this.policy_date = value; }
        }
        private string policy_maker;
        /// <summary>
        ///[To_Policy]表 [policy_maker]列
        /// </summary>
        public string Policy_maker
        {
            get { return policy_maker; }
            set { this.policy_maker = value; }
        }
        private int policy_makerId;
        /// <summary>
        ///[To_Policy]表 [policy_maker]列
        /// </summary>
        public int Policy_makerId
        {
            get { return policy_makerId; }
            set { this.policy_makerId = value; }
        }
        private string policy_num;
        /// <summary>
        ///[To_Policy]表 [policy_num]列
        /// </summary>
        public string Policy_num
        {
            get { return policy_num; }
            set { this.policy_num = value; }
        }
        private string policy_startdate;
        /// <summary>
        ///[To_Policy]表 [policy_startdate]列
        /// </summary>
        public string Policy_startdate
        {
            get { return policy_startdate; }
            set { this.policy_startdate = value; }
        }
        private string policy_enddate;
        /// <summary>
        ///[To_Policy]表 [policy_enddate]列
        /// </summary>
        public string Policy_enddate
        {
            get { return policy_enddate; }
            set { this.policy_enddate = value; }
        }
        private int policy_state;
        /// <summary>
        ///[To_Policy]表 [policy_state]列
        /// </summary>
        public int Policy_state
        {
            get { return policy_state; }
            set { this.policy_state = value; }
        }
        private string assured;
        /// <summary>
        ///[To_Policy]表 [assured]列
        /// </summary>
        public string Assured
        {
            get { return assured; }
            set { this.assured = value; }
        }
        private int customer;
        /// <summary>
        ///[To_Policy]表 [customer]列
        /// </summary>
        public int Customer
        {
            get { return customer; }
            set { this.customer = value; }
        }
        private int company;
        /// <summary>
        ///[To_Policy]表 [company]列
        /// </summary>
        public int Company
        {
            get { return company; }
            set { this.company = value; }
        }
        private string protype;
        /// <summary>
        ///[To_Policy]表 [protype]列
        /// </summary>
        public string Protype
        {
            get { return protype; }
            set { this.protype = value; }
        }
        private double totalPremium;
        /// <summary>
        ///[To_Policy]表 [totalPremium]列 总保费
        /// </summary>
        public double TotalPremium
        {
            get { return totalPremium; }
            set { this.totalPremium = value; }
        }
        private double totalBrokerage;
        /// <summary>
        ///[To_Policy]表 [totalBrokerage]列 总保额
        /// </summary>
        public double TotalBrokerage
        {
            get { return totalBrokerage; }
            set { this.totalBrokerage = value; }
        }
        private int isVerify;
        /// <summary>
        ///[To_Policy]表 [isVerify]列
        /// </summary>
        public int IsVerify
        {
            get { return isVerify; }
            set { this.isVerify = value; }
        }
        private string verifyUser;
        /// <summary>
        ///[To_Policy]表 [verifyUser]列
        /// </summary>
        public string VerifyUser
        {
            get { return verifyUser; }
            set { this.verifyUser = value; }
        }
        private DateTime verifydate;
        /// <summary>
        ///[To_Policy]表 [verifydate]列
        /// </summary>
        public DateTime Verifydate
        {
            get { return verifydate; }
            set { this.verifydate = value; }
        }
        private int salesman;
        /// <summary>
        ///[To_Policy]表 [salesman]列
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
        /// [To_Policy]表[UserCompany]列。开户公司
        /// </summary>
        public string UserCompany
        {
            get { return usercompany; }
            set { this.usercompany = value; }
        }

        private int isDaidian;
        /// <summary>
        /// 是否代垫保费
        /// </summary>
        public int IsDaidian
        {
            get { return isDaidian; }
            set { this.isDaidian = value; }
        }

        private string txt;
        /// <summary>
        /// 审核意见
        /// </summary>
        public string Txt
        {
            get { return txt; }
            set { this.txt = value; }
        }

        private string orderNum;
        /// <summary>
        /// 流水号
        /// </summary>
        public string OrderNum
        {
            get { return orderNum; }
            set { this.orderNum = value; }
        }

        private string codeFormart;
        /// <summary>
        /// 编码规则
        /// </summary>
        public string CodeFormart
        {
            get { return codeFormart; }
            set { this.codeFormart = value; }
        }

        private double totalEcoRate;
        /// <summary>
        /// 总经济费比率
        /// </summary>
        public double TotalEcoRate
        {
            get { return totalEcoRate; }
            set { this.totalEcoRate = value; }
        }

        private double totalEconomic;
        /// <summary>
        /// 总经济费
        /// </summary>
        public double TotalEconomic
        {
            get { return totalEconomic; }
            set { this.totalEconomic = value; }
        }

        private double totalRich;
        /// <summary>
        /// 总贴费
        /// </summary>
        public double TotalRich
        {
            get { return totalRich; }
            set { this.totalRich = value; }
        }

        private string shipName;
        /// <summary>
        /// 船名
        /// </summary>
        public string ShipName
        {
            get { return shipName; }
            set { this.shipName = value; }
        }

        private string persons;
        /// <summary>
        /// 业务员汇总
        /// </summary>
        public string Persons
        {
            get { return persons; }
            set { this.persons = value; }
        }
    }
}
