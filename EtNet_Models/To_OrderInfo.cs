using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
    [Serializable]
    public class To_OrderInfo
    {
        //To_OrderInfo表的默认构造方法
        public To_OrderInfo()
        {

        }
        private int id;
        /// <summary>
        ///[To_OrderInfo]表主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string orderNum;
        /// <summary>
        ///[To_OrderInfo]表 [orderNum]列
        /// </summary>
        public string OrderNum
        {
            get { return orderNum; }
            set { this.orderNum = value; }
        }
        private string orderType;
        /// <summary>
        ///[To_OrderInfo]表 [orderType]列
        /// </summary>
        public string OrderType
        {
            get { return orderType; }
            set { this.orderType = value; }
        }
        private DateTime outTime;
        /// <summary>
        ///[To_OrderInfo]表 [outTime]列
        /// </summary>
        public DateTime OutTime
        {
            get { return outTime; }
            set { this.outTime = value; }
        }
        private string teamNum;
        /// <summary>
        ///[To_OrderInfo]表 [teamNum]列
        /// </summary>
        public string TeamNum
        {
            get { return teamNum; }
            set { this.teamNum = value; }
        }
        private string natrue;
        /// <summary>
        ///[To_OrderInfo]表 [natrue]列
        /// </summary>
        public string Natrue
        {
            get { return natrue; }
            set { this.natrue = value; }
        }
        private string tour;
        /// <summary>
        ///[To_OrderInfo]表 [tour]列
        /// </summary>
        public string Tour
        {
            get { return tour; }
            set { this.tour = value; }
        }
        private string tourRemark;
        /// <summary>
        ///[To_OrderInfo]表 [tourRemark]列
        /// </summary>
        public string TourRemark
        {
            get { return tourRemark; }
            set { this.tourRemark = value; }
        }
        private int markId;
        /// <summary>
        ///[To_OrderInfo]表 [markId]列
        /// </summary>
        public int MarkId
        {
            get { return markId; }
            set { this.markId = value; }
        }
        private string makerName;
        /// <summary>
        ///[To_OrderInfo]表 [makerName]列
        /// </summary>
        public string MakerName
        {
            get { return makerName; }
            set { this.makerName = value; }
        }
        private DateTime makerTime;
        /// <summary>
        ///[To_OrderInfo]表 [makerTime]列
        /// </summary>
        public DateTime MakerTime
        {
            get { return makerTime; }
            set { this.makerTime = value; }
        }
        private double gross;
        /// <summary>
        ///[To_OrderInfo]表 [gross]列
        /// </summary>
        public double Gross
        {
            get { return gross; }
            set { this.gross = value; }
        }
        private int jobflowID;
        /// <summary>
        ///[To_OrderInfo]表 [jobflowID]列
        /// </summary>
        public int JobflowID
        {
            get { return jobflowID; }
            set { this.jobflowID = value; }
        }
        private int verify;
        /// <summary>
        ///[To_OrderInfo]表 [verify]列
        /// </summary>
        public int Verify
        {
            get { return verify; }
            set { this.verify = value; }
        }
        private int approvalID;
        /// <summary>
        ///[To_OrderInfo]表 [approvalID]列
        /// </summary>
        public int ApprovalID
        {
            get { return approvalID; }
            set { this.approvalID = value; }
        }
        private double collectAmount;
        /// <summary>
        ///[To_OrderInfo]表 [collectAmount]列
        /// </summary>
        public double CollectAmount
        {
            get { return collectAmount; }
            set { this.collectAmount = value; }
        }
        private string collectCusID;
        /// <summary>
        ///[To_OrderInfo]表 [collectCusID]列
        /// </summary>
        public string CollectCusID
        {
            get { return collectCusID; }
            set { this.collectCusID = value; }
        }
        private double payAmount;
        /// <summary>
        ///[To_OrderInfo]表 [payAmount]列
        /// </summary>
        public double PayAmount
        {
            get { return payAmount; }
            set { this.payAmount = value; }
        }
        private string payCusID;
        /// <summary>
        ///[To_OrderInfo]表 [payCusID]列
        /// </summary>
        public string PayCusID
        {
            get { return payCusID; }
            set { this.payCusID = value; }
        }
        private double refundAmount;
        /// <summary>
        ///[To_OrderInfo]表 [refundAmount]列
        /// </summary>
        public double RefundAmount
        {
            get { return refundAmount; }
            set { this.refundAmount = value; }
        }
        private string refundID;
        /// <summary>
        ///[To_OrderInfo]表 [refundID]列
        /// </summary>
        public string RefundID
        {
            get { return refundID; }
            set { this.refundID = value; }
        }
        private double reimAmount;
        /// <summary>
        ///[To_OrderInfo]表 [reimAmount]列
        /// </summary>
        public double ReimAmount
        {
            get { return reimAmount; }
            set { this.reimAmount = value; }
        }
        private string reimID;
        /// <summary>
        ///[To_OrderInfo]表 [reimID]列
        /// </summary>
        public string ReimID
        {
            get { return reimID; }
            set { this.reimID = value; }
        }
        private string codeformat;
        /// <summary>
        ///[To_OrderInfo]表 [codeformat]列
        /// </summary>
        public string Codeformat
        {
            get { return codeformat; }
            set { this.codeformat = value; }
        }
        private string codenum;
        /// <summary>
        ///[To_OrderInfo]表 [codenum]列
        /// </summary>
        public string Codenum
        {
            get { return codenum; }
            set { this.codenum = value; }
        }

        /// <summary>
        /// 部门自动编码标识符
        /// </summary>
        public string DepartAutoCode { get; set; }

        /// <summary>
        /// 订单是否作废标识符（N不作废，Y作废）
        /// </summary>
        public string IsCancel { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string Inputer { get; set; }

        /// <summary>
        /// 操作人员id
        /// </summary>
        public int InputerID { get; set; }

        /// <summary>
        /// 操作员的提成金额
        /// </summary>
        public double InputerTc { get; set; }

        /// <summary>
        /// 操作员的提成发放状态
        /// </summary>
        public string InputerTc_status { get; set; }    }
}
