using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_PolicyDetail
    {
        //To_PolicyDetail表的默认构造方法
        public To_PolicyDetail()
        {

        }
        private int id;
        /// <summary>
        ///[To_PolicyDetail]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int policyId;
        /// <summary>
        ///[To_PolicyDetail]表 [policyId]列
        /// </summary>
        public int PolicyId
        {
            get { return policyId; }
            set { this.policyId = value; }
        }
        #region
        private int productId;
        /// <summary>
        ///[To_PolicyDetail]表 [productId]列
        /// </summary>
        public int ProductId
        {
            get { return productId; }
            set { this.productId = value; }
        }
        private double coverage;
        /// <summary>
        ///[To_PolicyDetail]表 [coverage]列
        /// </summary>
        public double Coverage
        {
            get { return coverage; }
            set { this.coverage = value; }
        }
        private double premium;
        /// <summary>
        ///[To_PolicyDetail]表 [premium]列
        /// </summary>
        public double Premium
        {
            get { return premium; }
            set { this.premium = value; }
        }
        #endregion
        private string mark;
        /// <summary>
        /// 备注列
        /// </summary>
        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        private string salesman;
        /// <summary>
        /// [To_PolicyDetail]表 [salesman]列 业务员
        /// </summary>
        public string Salesman
        {
            get { return salesman; }
            set { salesman = value; }
        }

        private string departname;
        /// <summary>
        /// [To_PolicyDetail]表 [departname]列 部门
        /// </summary>
        public string DepartName
        {
            get { return departname; }
            set { departname = value; }
        }

        private decimal numrate;
        /// <summary>
        /// [To_PolicyDetail]表 [numrate]列 比率
        /// </summary>
        public decimal NumRate
        {
            get { return numrate; }
            set { numrate = value; }
        }

        private decimal fmone;
        /// <summary>
        /// [To_PolicyDetail]表 [fmone]列 在该保单下所占的费用
        /// </summary>
        public decimal Fmone
        {
            get { return fmone; }
            set { fmone = value; }
        }

        /// <summary>
        /// 贴费列
        /// </summary>
        public decimal Rich { get; set; } 
    }
}
