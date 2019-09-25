using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtNet_Web.Pages.Financial.FundAllocation
{
    public partial class Step1 : System.Web.UI.Page
    {
        #region ****************************Page_Load方法****************************

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtPayer.Attributes.Add("readonly", "readonly");
                TxtSalesman.Attributes.Add("readonly", "readonly");
            }
        }

        #endregion

        #region ****************************属性****************************

        /// <summary>
        /// 业务员
        /// </summary>
        public string Salesman
        {
            get { return TxtSalesman.Text; }
        }

        /// <summary>
        /// 业务员ID
        /// </summary>
        public int SalesmanID
        {
            get
            {
                int salesmanID;
                int.TryParse(HidSalesman.Value.Trim(), out salesmanID);
                return salesmanID;
            }
        }

        /// <summary>
        ///付款单位
        /// </summary>
        public string Payer
        {
            get { return TxtPayer.Text; }
        }

        /// <summary>
        /// 付款单位ID
        /// </summary>
        public int PayerID
        {
            get
            {
                int payerID;
                int.TryParse(HidPayerID.Value.Trim(), out payerID);
                return payerID;
            }
        }

        /// <summary>
        /// 付款单位类别
        /// 0：投保客户；1：保险公司
        /// </summary>
        public int PayerType
        {
            get
            {
                int payerType;
                int.TryParse(HidPayerType.Value.Trim(), out payerType);
                return payerType;
            }
        }

        /// <summary>
        /// 收款费用类别
        /// </summary>
        public string ReceiptType
        {
            get { return DdlReceiptType.SelectedValue.Trim(); }
        }

        /// <summary>
        /// 收款费用类别名称
        /// </summary>
        public string ReceiptTypeName
        {
            get { return DdlReceiptType.SelectedItem.Text.Trim(); }
        }

        #endregion


        #region ****************************事件****************************

        /// <summary>
        /// 点击提交时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            JumpSetp2();
        }

        #endregion

        #region ****************************方法****************************

        /// <summary>
        /// 跳转到第二步
        /// </summary>
        private void JumpSetp2()
        {
            string msg = string.Empty;
            if (SalesmanID == 0)
                msg = "业务员信息已损坏，请重新选择";
            if (PayerID == 0)
                msg = "投保客户/保险公司信息已损坏，请重新选择";
            if (msg == string.Empty)
                Server.Transfer("Step2.aspx");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "page", string.Format("alert('{0}');", msg), true);
        }

        #endregion

    }
}