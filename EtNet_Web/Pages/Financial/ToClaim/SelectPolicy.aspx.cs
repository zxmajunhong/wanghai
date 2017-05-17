using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Financial.ToClaim
{
    public partial class SelectPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrderList();
            }
        }

        /// <summary>
        /// 加载所要选择的认领订单
        /// </summary>
        private void LoadOrderList()
        {
            string payerId = Request.QueryString["payer"];
            string sql = " iscancel='N'";
            sql += this.cbxshowfile.Checked ? "" : " and fileStatus=0 ";
            if (payerId != "")
                sql += " and cusId = " + payerId;
            sql += " order by outTime desc ";
            DataTable dt = new DataTable();
            dt = To_OrderInfoManager.GetViewOrderAndCollect("*", sql);
            RpPolicyList.DataSource = dt;
            RpPolicyList.DataBind();

        }


        protected string GetReceiptType()
        {
            return Request.QueryString["type"].ToString();
        }

        /// <summary>
        /// 得到已经认领的金额
        /// </summary>
        /// <param name="collecId"></param>
        /// <returns></returns>
        protected string GetHasAmount(object collectid)
        {
            To_ClaimDetailManager to_claimDetail = new To_ClaimDetailManager();
            double hasAmount = to_claimDetail.GetHasAmount(collectid.ToString());
            return hasAmount.ToString("F2");
        }

        /// <summary>
        /// 得到可认领金额
        /// </summary>
        /// <param name="money"></param>
        /// <param name="collecId"></param>
        /// <param name="CusId"></param>
        /// <returns></returns>
        protected string GetCanAmount(object money, object collectid)
        {
            To_ClaimDetailManager to_claimDetail = new To_ClaimDetailManager();
            double hasAmount = to_claimDetail.GetHasAmount(collectid.ToString());
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

        protected void cbxshowfile_CheckedChanged(object sender, EventArgs e)
        {
            LoadOrderList();
        }
    }
}