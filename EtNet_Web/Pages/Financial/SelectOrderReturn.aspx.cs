using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectOrderReturn : System.Web.UI.Page
    {
        string strsql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object objpayer = Request.QueryString["payer"]; //收款单位
                if (objpayer == null || objpayer.ToString().Trim() == string.Empty)
                {
                    form1.InnerHtml = "<font color='red'>参数信息错误</font>";
                    return;
                }
                LoadOrderReturnDetail();
            }
        }

        /// <summary>
        /// 绑定订单信息中的退款信息
        /// </summary>
        /// <param name="payer"></param>
        private void LoadOrderReturnDetail()
        {
            string payer = Request.QueryString["payer"];
            string sql = " cusid= " + payer + " and iscancel='N' ";
            sql += this.cbxshowfile.Checked ? "" : " and fileStatus=0 ";
            sql += " order by outTime desc";
            sql += strsql;
            RpPolicyList.DataSource = To_OrderInfoManager.GetViewOrderReturn("", sql);
            RpPolicyList.DataBind();
        }

        /// <summary>
        /// 得到已经退过款的金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payerId"></param>
        /// <returns></returns>
        protected string GetHasAmount(object orderRetID)
        {
            double hasAmount = To_PaymentReturnManager.GetHasAmount(orderRetID.ToString());
            return hasAmount.ToString("F2");
        }

        /// <summary>
        /// 得到可退款金额
        /// </summary>
        /// <param name="money"></param>
        /// <param name="orderId"></param>
        /// <param name="payerId"></param>
        /// <returns></returns>
        protected string GetCanAmount(object money, object orderRetID)
        {
            double hasAmount = To_PaymentReturnManager.GetHasAmount(orderRetID.ToString());
            double amount = double.Parse(money.ToString());
            if (amount != 0)
            {
                return (amount - hasAmount).ToString("F2");
            }
            else
            {
                return amount.ToString();
            }
        }

        protected void btnFilter_Click(object sender, ImageClickEventArgs e)
        {
            modify();
            LoadOrderReturnDetail();
        }
        public void modify()
        {
            strsql = "";
            if (this.txtordernum.Value != "")
            {
                strsql += " and orderNum like '%" + this.txtordernum.Value.Trim() + "%'";
            }
        }

        protected void btnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            this.txtordernum.Value = "";
            strsql = "";
            LoadOrderReturnDetail();
        }

        protected void cbxshowfile_CheckedChanged(object sender, EventArgs e)
        {
            LoadOrderReturnDetail();
        }
    }
}