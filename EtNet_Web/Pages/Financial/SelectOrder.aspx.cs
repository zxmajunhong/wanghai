using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Text;

namespace EtNet_Web.Pages.Financial
{
    public partial class SelectOrder : System.Web.UI.Page
    {
        string strsql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object objPayer = Request.QueryString["payer"];//收款单位
                string paytyer = Request.QueryString["type"].Trim(); //付款类别
                if (objPayer == null || objPayer.ToString().Trim() == string.Empty)
                {
                    form1.InnerHtml = "<font color=\"red\">参数信息错误</font>";
                    return;
                }
                if (paytyer == null || paytyer == string.Empty)
                {
                    form1.InnerHtml = "<font color=\"red\">参数信息错误</font>";
                    return;
                }

                string payer = objPayer.ToString().Trim();//收款单位ID

                To_OrderCollectDetial();//View_OrderPay&Clollect
                // LoadPolicyList(payer);
            }
        }

        /// <summary>
        /// 得到订单信息
        /// </summary>
        /// <param name="payer"></param>
        /// <param name="paytype"></param>
        private void To_OrderCollectDetial()
        {
            string payer = Request.QueryString["payer"];
            string paytype = Request.QueryString["type"];
            string sql = " factid = " + payer + " and payType='" + paytype + "' and iscancel='N' ";
            sql += this.cbxshowfile.Checked ? "" : " and fileStatus=0 ";
            sql += strsql;
            sql += " order by outTime desc";
            RpPolicyList.DataSource = To_OrderInfoManager.GetViewOrder("", sql.ToString());
            RpPolicyList.DataBind();
        }



        /// <summary>
        /// 得到已经支付的金额
        /// </summary>
        /// <param name="collecId"></param>
        /// <returns></returns>
        protected string GetHasAmount(object paydetailID)
        {
            To_PaymentDetailManager tpdm = new To_PaymentDetailManager();

            double hasAmount = tpdm.GetHasAmount(paydetailID.ToString());
            return hasAmount.ToString("F2");
        }

        /// <summary>
        /// 得到可支付金额
        /// </summary>
        /// <param name="money"></param>
        /// <param name="collecId"></param>
        /// <param name="CusId"></param>
        /// <returns></returns>
        protected string GetCanAmount(object money, object paydetailID)
        {
            To_PaymentDetailManager tpdm = new To_PaymentDetailManager();
            double hasAmount = tpdm.GetHasAmount(paydetailID.ToString());
            double Amount = double.Parse(money.ToString());
            if (Amount != 0)
            {
                return (Amount - hasAmount).ToString("F2");
            }
            else
            {
                return Amount.ToString();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, ImageClickEventArgs e)
        {
            modify();
            To_OrderCollectDetial();
        }

        public void modify()
        {
            strsql = "";
            if (this.txtordernum.Value != "")
            {
                strsql += " and orderNum like '%" + this.txtordernum.Value.Trim() + "%'";
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            this.txtordernum.Value = "";
            strsql = "";
            To_OrderCollectDetial();
        }

        protected void cbxshowfile_CheckedChanged(object sender, EventArgs e)
        {
            To_OrderCollectDetial();
        }
    }
}