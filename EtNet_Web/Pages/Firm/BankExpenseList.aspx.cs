using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Firm
{
    public partial class BankExpenseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAccountData(1);
            }
        }

        /// <summary>
        /// 加载银行账户资料
        /// </summary>
        /// <param name="firmid">公司的id值</param>
        private void LoadAccountData(int firmid)
        {
            string strsql = " firmid=" + firmid.ToString();
           // DataTable tbl = EtNet_BLL.FirmAccountInfoManager.GetList(strsql);//原方法 0510修改为
            DataTable tbl = EtNet_BLL.FirmAccountInfoManager.GetList(0, strsql, "ystime desc");
            rptAccount.DataSource = tbl;
            rptAccount.DataBind();
        }

        public string getamount(object id)
        {
            int firmid = 0;
            int.TryParse(id.ToString(), out firmid);
            FirmAccountInfo model = FirmAccountInfoManager.GetModel(firmid);
            decimal collect = FirmAccountInfoManager.GetMoneySum(id.ToString(), "1", model.ystime.ToString("yyyy-MM-dd"));
            decimal pay = FirmAccountInfoManager.GetMoneySum(id.ToString(), "0", model.ystime.ToString("yyyy-MM-dd"));

            return (model.amount + collect - pay).ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadAccountData(1);
        }

    }
}