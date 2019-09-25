using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_PolicyDetail
    {
        //To_PolicyDetail���Ĭ�Ϲ��췽��
        public To_PolicyDetail()
        {

        }
        private int id;
        /// <summary>
        ///[To_PolicyDetail]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private int policyId;
        /// <summary>
        ///[To_PolicyDetail]�� [policyId]��
        /// </summary>
        public int PolicyId
        {
            get { return policyId; }
            set { this.policyId = value; }
        }
        #region
        private int productId;
        /// <summary>
        ///[To_PolicyDetail]�� [productId]��
        /// </summary>
        public int ProductId
        {
            get { return productId; }
            set { this.productId = value; }
        }
        private double coverage;
        /// <summary>
        ///[To_PolicyDetail]�� [coverage]��
        /// </summary>
        public double Coverage
        {
            get { return coverage; }
            set { this.coverage = value; }
        }
        private double premium;
        /// <summary>
        ///[To_PolicyDetail]�� [premium]��
        /// </summary>
        public double Premium
        {
            get { return premium; }
            set { this.premium = value; }
        }
        #endregion
        private string mark;
        /// <summary>
        /// ��ע��
        /// </summary>
        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        private string salesman;
        /// <summary>
        /// [To_PolicyDetail]�� [salesman]�� ҵ��Ա
        /// </summary>
        public string Salesman
        {
            get { return salesman; }
            set { salesman = value; }
        }

        private string departname;
        /// <summary>
        /// [To_PolicyDetail]�� [departname]�� ����
        /// </summary>
        public string DepartName
        {
            get { return departname; }
            set { departname = value; }
        }

        private decimal numrate;
        /// <summary>
        /// [To_PolicyDetail]�� [numrate]�� ����
        /// </summary>
        public decimal NumRate
        {
            get { return numrate; }
            set { numrate = value; }
        }

        private decimal fmone;
        /// <summary>
        /// [To_PolicyDetail]�� [fmone]�� �ڸñ�������ռ�ķ���
        /// </summary>
        public decimal Fmone
        {
            get { return fmone; }
            set { fmone = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public decimal Rich { get; set; } 
    }
}
