using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderInfo
    {
        //To_OrderInfo���Ĭ�Ϲ��췽��
        public To_OrderInfo()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderInfo]������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string orderNum;
        /// <summary>
        ///[To_OrderInfo]�� [orderNum]��
        /// </summary>
        public string OrderNum
        {
            get { return orderNum; }
            set { this.orderNum = value; }
        }
        private string orderType;
        /// <summary>
        ///[To_OrderInfo]�� [orderType]��
        /// </summary>
        public string OrderType
        {
            get { return orderType; }
            set { this.orderType = value; }
        }
        private DateTime outTime;
        /// <summary>
        ///[To_OrderInfo]�� [outTime]��
        /// </summary>
        public DateTime OutTime
        {
            get { return outTime; }
            set { this.outTime = value; }
        }
        private string teamNum;
        /// <summary>
        ///[To_OrderInfo]�� [teamNum]��
        /// </summary>
        public string TeamNum
        {
            get { return teamNum; }
            set { this.teamNum = value; }
        }
        private string natrue;
        /// <summary>
        ///[To_OrderInfo]�� [natrue]��
        /// </summary>
        public string Natrue
        {
            get { return natrue; }
            set { this.natrue = value; }
        }
        private string tour;
        /// <summary>
        ///[To_OrderInfo]�� [tour]��
        /// </summary>
        public string Tour
        {
            get { return tour; }
            set { this.tour = value; }
        }
        private string tourRemark;
        /// <summary>
        ///[To_OrderInfo]�� [tourRemark]��
        /// </summary>
        public string TourRemark
        {
            get { return tourRemark; }
            set { this.tourRemark = value; }
        }
        private int markId;
        /// <summary>
        ///[To_OrderInfo]�� [markId]��
        /// </summary>
        public int MarkId
        {
            get { return markId; }
            set { this.markId = value; }
        }
        private string makerName;
        /// <summary>
        ///[To_OrderInfo]�� [makerName]��
        /// </summary>
        public string MakerName
        {
            get { return makerName; }
            set { this.makerName = value; }
        }
        private DateTime makerTime;
        /// <summary>
        ///[To_OrderInfo]�� [makerTime]��
        /// </summary>
        public DateTime MakerTime
        {
            get { return makerTime; }
            set { this.makerTime = value; }
        }
        private double gross;
        /// <summary>
        ///[To_OrderInfo]�� [gross]��
        /// </summary>
        public double Gross
        {
            get { return gross; }
            set { this.gross = value; }
        }
        private int jobflowID;
        /// <summary>
        ///[To_OrderInfo]�� [jobflowID]��
        /// </summary>
        public int JobflowID
        {
            get { return jobflowID; }
            set { this.jobflowID = value; }
        }
        private int verify;
        /// <summary>
        ///[To_OrderInfo]�� [verify]��
        /// </summary>
        public int Verify
        {
            get { return verify; }
            set { this.verify = value; }
        }
        private int approvalID;
        /// <summary>
        ///[To_OrderInfo]�� [approvalID]��
        /// </summary>
        public int ApprovalID
        {
            get { return approvalID; }
            set { this.approvalID = value; }
        }
        private double collectAmount;
        /// <summary>
        ///[To_OrderInfo]�� [collectAmount]��
        /// </summary>
        public double CollectAmount
        {
            get { return collectAmount; }
            set { this.collectAmount = value; }
        }
        private string collectCusID;
        /// <summary>
        ///[To_OrderInfo]�� [collectCusID]��
        /// </summary>
        public string CollectCusID
        {
            get { return collectCusID; }
            set { this.collectCusID = value; }
        }
        private double payAmount;
        /// <summary>
        ///[To_OrderInfo]�� [payAmount]��
        /// </summary>
        public double PayAmount
        {
            get { return payAmount; }
            set { this.payAmount = value; }
        }
        private string payCusID;
        /// <summary>
        ///[To_OrderInfo]�� [payCusID]��
        /// </summary>
        public string PayCusID
        {
            get { return payCusID; }
            set { this.payCusID = value; }
        }
        private double refundAmount;
        /// <summary>
        ///[To_OrderInfo]�� [refundAmount]��
        /// </summary>
        public double RefundAmount
        {
            get { return refundAmount; }
            set { this.refundAmount = value; }
        }
        private string refundID;
        /// <summary>
        ///[To_OrderInfo]�� [refundID]��
        /// </summary>
        public string RefundID
        {
            get { return refundID; }
            set { this.refundID = value; }
        }
        private double reimAmount;
        /// <summary>
        ///[To_OrderInfo]�� [reimAmount]��
        /// </summary>
        public double ReimAmount
        {
            get { return reimAmount; }
            set { this.reimAmount = value; }
        }
        private string reimID;
        /// <summary>
        ///[To_OrderInfo]�� [reimID]��
        /// </summary>
        public string ReimID
        {
            get { return reimID; }
            set { this.reimID = value; }
        }
        private string codeformat;
        /// <summary>
        ///[To_OrderInfo]�� [codeformat]��
        /// </summary>
        public string Codeformat
        {
            get { return codeformat; }
            set { this.codeformat = value; }
        }
        private string codenum;
        /// <summary>
        ///[To_OrderInfo]�� [codenum]��
        /// </summary>
        public string Codenum
        {
            get { return codenum; }
            set { this.codenum = value; }
        }

        /// <summary>
        /// �����Զ������ʶ��
        /// </summary>
        public string DepartAutoCode { get; set; }

        /// <summary>
        /// �����Ƿ����ϱ�ʶ����N�����ϣ�Y���ϣ�
        /// </summary>
        public string IsCancel { get; set; }

        /// <summary>
        /// ������Ա
        /// </summary>
        public string Inputer { get; set; }

        /// <summary>
        /// ������Աid
        /// </summary>
        public int InputerID { get; set; }

        /// <summary>
        /// ����Ա����ɽ��
        /// </summary>
        public double InputerTc { get; set; }

        /// <summary>
        /// ����Ա����ɷ���״̬
        /// </summary>
        public string InputerTc_status { get; set; }    }
}
