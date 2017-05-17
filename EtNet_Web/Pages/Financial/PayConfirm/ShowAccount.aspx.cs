using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Financial
{
    public partial class ShowAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAccountInfo();
        }

        private void LoadAccountInfo()
        {
            string jfid = Request.QueryString["jfid"];
            To_PaymentManager paymentManager = new To_PaymentManager();
            To_Payment paymentModel = paymentManager.GetModelByjfid(jfid);

            if (paymentModel != null)
            {
                payType.Value = paymentModel.payType;
                collectInfo.Value = "开户银行:" + paymentModel.getBank + ", 银行帐号:" + paymentModel.getAccount + ", 开户名称:" + paymentModel.getAccountName;
                payInfo.Value = "开户银行:" + paymentModel.bankName + ", 银行帐号:" + paymentModel.bankAccount + ", 开户名称:" + paymentModel.bankAccountName;

            }
        }
    }
}