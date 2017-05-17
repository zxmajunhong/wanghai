using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_Collecting
    {
        //To_Collecting表的默认构造方法
        public To_Collecting()
        {

        }
        private int iD;
        /// <summary>
        ///[To_Collecting]表主键
        /// </summary>
        public int ID
        {
            get { return iD; }
            set { this.iD = value; }
        }
        private string receiptNum;
        /// <summary>
        ///[To_Collecting]表 [receiptNum]列
        /// </summary>
        public string ReceiptNum
        {
            get { return receiptNum; }
            set { this.receiptNum = value; }
        }
        private double receiptAmount;
        /// <summary>
        ///[To_Collecting]表 [receiptAmount]列
        /// </summary>
        public double ReceiptAmount
        {
            get { return receiptAmount; }
            set { this.receiptAmount = value; }
        }
        private DateTime receiptDate;
        /// <summary>
        ///[To_Collecting]表 [receiptDate]列
        /// </summary>
        public DateTime ReceiptDate
        {
            get { return receiptDate; }
            set { this.receiptDate = value; }
        }
        private string businessUnit;
        /// <summary>
        ///[To_Collecting]表 [businessUnit]列
        /// </summary>
        public string BusinessUnit
        {
            get { return businessUnit; }
            set { this.businessUnit = value; }
        }
        private int businessUnitID;
        /// <summary>
        ///[To_Collecting]表 [businessUnitID]列
        /// </summary>
        public int BusinessUnitID
        {
            get { return businessUnitID; }
            set { this.businessUnitID = value; }
        }
        private string paymentUnit;
        /// <summary>
        ///[To_Collecting]表 [paymentUnit]列
        /// </summary>
        public string PaymentUnit
        {
            get { return paymentUnit; }
            set { this.paymentUnit = value; }
        }
        private int paymentUnitID;
        /// <summary>
        ///[To_Collecting]表 [paymentUnitID]列
        /// </summary>
        public int PaymentUnitID
        {
            get { return paymentUnitID; }
            set { this.paymentUnitID = value; }
        }
        private int paymentMode;
        /// <summary>
        ///[To_Collecting]表 [paymentMode]列
        /// </summary>
        public int PaymentMode
        {
            get { return paymentMode; }
            set { this.paymentMode = value; }
        }
        private string marker;
        /// <summary>
        ///[To_Collecting]表 [marker]列
        /// </summary>
        public string Marker
        {
            get { return marker; }
            set { this.marker = value; }
        }
        private int markerID;
        /// <summary>
        ///[To_Collecting]表 [markerID]列
        /// </summary>
        public int MarkerID
        {
            get { return markerID; }
            set { this.markerID = value; }
        }
        private string markerDepartment;
        /// <summary>
        ///[To_Collecting]表 [markerDepartment]列
        /// </summary>
        public string MarkerDepartment
        {
            get { return markerDepartment; }
            set { this.markerDepartment = value; }
        }
        private int markerDepartmentID;
        /// <summary>
        ///[To_Collecting]表 [markerDepartmentID]列
        /// </summary>
        public int MarkerDepartmentID
        {
            get { return markerDepartmentID; }
            set { this.markerDepartmentID = value; }
        }
        private DateTime markDate;
        /// <summary>
        ///[To_Collecting]表 [markDate]列
        /// </summary>
        public DateTime MarkDate
        {
            get { return markDate; }
            set { this.markDate = value; }
        }
        private string receiptMark;
        /// <summary>
        ///[To_Collecting]表 [receiptMark]列
        /// </summary>
        public string ReceiptMark
        {
            get { return receiptMark; }
            set { this.receiptMark = value; }
        }
        private string payBank;
        /// <summary>
        ///[To_Collecting]表 [payBank]列
        /// </summary>
        public string PayBank
        {
            get { return payBank; }
            set { this.payBank = value; }
        }
        private string payBankAcount;
        /// <summary>
        ///[To_Collecting]表 [payBankAcount]列
        /// </summary>
        public string PayBankAcount
        {
            get { return payBankAcount; }
            set { this.payBankAcount = value; }
        }
        private int confirmReceipt;
        /// <summary>
        ///[To_Collecting]表 [confirmReceipt]列
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
        /// 流水号[orderNum]列
        /// </summary>
        public string orderNum
        {
            get;
            set;
        }

        /// <summary>
        /// 编码规则[codeFormart]列
        /// </summary>
        public string codeFormat
        {
            get;
            set;
        }

        public int payBankId { get; set; }
    }
}
