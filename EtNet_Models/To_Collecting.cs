using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_Collecting
    {
        //To_Collecting���Ĭ�Ϲ��췽��
        public To_Collecting()
        {

        }
        private int iD;
        /// <summary>
        ///[To_Collecting]������
        /// </summary>
        public int ID
        {
            get { return iD; }
            set { this.iD = value; }
        }
        private string receiptNum;
        /// <summary>
        ///[To_Collecting]�� [receiptNum]��
        /// </summary>
        public string ReceiptNum
        {
            get { return receiptNum; }
            set { this.receiptNum = value; }
        }
        private double receiptAmount;
        /// <summary>
        ///[To_Collecting]�� [receiptAmount]��
        /// </summary>
        public double ReceiptAmount
        {
            get { return receiptAmount; }
            set { this.receiptAmount = value; }
        }
        private DateTime receiptDate;
        /// <summary>
        ///[To_Collecting]�� [receiptDate]��
        /// </summary>
        public DateTime ReceiptDate
        {
            get { return receiptDate; }
            set { this.receiptDate = value; }
        }
        private string businessUnit;
        /// <summary>
        ///[To_Collecting]�� [businessUnit]��
        /// </summary>
        public string BusinessUnit
        {
            get { return businessUnit; }
            set { this.businessUnit = value; }
        }
        private int businessUnitID;
        /// <summary>
        ///[To_Collecting]�� [businessUnitID]��
        /// </summary>
        public int BusinessUnitID
        {
            get { return businessUnitID; }
            set { this.businessUnitID = value; }
        }
        private string paymentUnit;
        /// <summary>
        ///[To_Collecting]�� [paymentUnit]��
        /// </summary>
        public string PaymentUnit
        {
            get { return paymentUnit; }
            set { this.paymentUnit = value; }
        }
        private int paymentUnitID;
        /// <summary>
        ///[To_Collecting]�� [paymentUnitID]��
        /// </summary>
        public int PaymentUnitID
        {
            get { return paymentUnitID; }
            set { this.paymentUnitID = value; }
        }
        private int paymentMode;
        /// <summary>
        ///[To_Collecting]�� [paymentMode]��
        /// </summary>
        public int PaymentMode
        {
            get { return paymentMode; }
            set { this.paymentMode = value; }
        }
        private string marker;
        /// <summary>
        ///[To_Collecting]�� [marker]��
        /// </summary>
        public string Marker
        {
            get { return marker; }
            set { this.marker = value; }
        }
        private int markerID;
        /// <summary>
        ///[To_Collecting]�� [markerID]��
        /// </summary>
        public int MarkerID
        {
            get { return markerID; }
            set { this.markerID = value; }
        }
        private string markerDepartment;
        /// <summary>
        ///[To_Collecting]�� [markerDepartment]��
        /// </summary>
        public string MarkerDepartment
        {
            get { return markerDepartment; }
            set { this.markerDepartment = value; }
        }
        private int markerDepartmentID;
        /// <summary>
        ///[To_Collecting]�� [markerDepartmentID]��
        /// </summary>
        public int MarkerDepartmentID
        {
            get { return markerDepartmentID; }
            set { this.markerDepartmentID = value; }
        }
        private DateTime markDate;
        /// <summary>
        ///[To_Collecting]�� [markDate]��
        /// </summary>
        public DateTime MarkDate
        {
            get { return markDate; }
            set { this.markDate = value; }
        }
        private string receiptMark;
        /// <summary>
        ///[To_Collecting]�� [receiptMark]��
        /// </summary>
        public string ReceiptMark
        {
            get { return receiptMark; }
            set { this.receiptMark = value; }
        }
        private string payBank;
        /// <summary>
        ///[To_Collecting]�� [payBank]��
        /// </summary>
        public string PayBank
        {
            get { return payBank; }
            set { this.payBank = value; }
        }
        private string payBankAcount;
        /// <summary>
        ///[To_Collecting]�� [payBankAcount]��
        /// </summary>
        public string PayBankAcount
        {
            get { return payBankAcount; }
            set { this.payBankAcount = value; }
        }
        private int confirmReceipt;
        /// <summary>
        ///[To_Collecting]�� [confirmReceipt]��
        /// </summary>
        public int ConfirmReceipt
        {
            get { return confirmReceipt; }
            set { this.confirmReceipt = value; }
        }
        public int receiptStatusCode
        {
            get;
            set;
        }
        /// <summary>
        /// ��ˮ��[orderNum]��
        /// </summary>
        public string orderNum
        {
            get;
            set;
        }

        /// <summary>
        /// �������[codeFormart]��
        /// </summary>
        public string codeFormat
        {
            get;
            set;
        }

        public int payBankId { get; set; }
    }
}
