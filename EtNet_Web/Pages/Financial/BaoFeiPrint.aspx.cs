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
    public partial class BaoFeiPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["payid"] == null || Request.QueryString["payid"].ToString() == "")
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');", true);
                return;
            }
            string policyId = Request.QueryString["payid"];
            loadPolicyData(policyId);
        }

        private void loadPolicyData(string policyId)
        {
            DataTable dt = To_PolicyManager.GetList(int.Parse(policyId));

            int makerid;
            int.TryParse(dt.Rows[0]["policy_makerId"].ToString(), out makerid);
            LoginInfo login = LoginInfoManager.getLoginInfoById(makerid);

            DepartmentInfo department = DepartmentInfoManager.getDepartmentInfoById(login.Departid);
            txtdepart.Value = department.Departcname;

            txttime.Value = DateTime.Now.ToString("yyyy年MM月dd日");
            lblkhmc.Text = dt.Rows[0]["cusCName"].ToString(); //客户名称
            lblcm.Text = dt.Rows[0]["shipName"].ToString();//船名
            lbltbrq.Text = Convert.IsDBNull(dt.Rows[0]["policy_date"]) ? "" : Convert.ToDateTime(dt.Rows[0]["policy_date"]).ToString("yyyy年MM月dd日"); //投保日期
            lblbxgs.Text = dt.Rows[0]["comCname"].ToString(); //保险公司
            lblbxxz.Text = dt.Rows[0]["ProdTypeName"].ToString(); //险种
            lblbfhj.Text = dt.Rows[0]["totalPremium"].ToString();//总保费

            bank.InnerHtml = "公司名称：" + dt.Rows[0]["cardName"].ToString() + "<br />开 户 行：" + dt.Rows[0]["bank"].ToString() + "<br />账 &nbsp;&nbsp; 号：" + dt.Rows[0]["cardId"].ToString(); //银行信息

            lblbpr.Text = dt.Rows[0]["policy_maker"].ToString();//报批人
        }
    }
}