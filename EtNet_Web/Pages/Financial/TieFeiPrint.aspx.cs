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
    public partial class TieFeiPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["payid"] == null || Request.QueryString["payid"].ToString().Trim() == string.Empty)
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');", true);
                Response.Write("<script>window.opener=null;window.close();</script>");
            }

            string policyid = Request.QueryString["payid"];
            LoadPolicyData(policyid);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="policyid"></param>
        private void LoadPolicyData(string policyid)
        {
            DataTable dt = To_PolicyManager.GetList(int.Parse(policyid));

            int makerid ;
            int.TryParse(dt.Rows[0]["policy_makerId"].ToString(), out makerid);
            LoginInfo login = LoginInfoManager.getLoginInfoById(makerid);

            DepartmentInfo depart = DepartmentInfoManager.getDepartmentInfoById(login.Departid);
            txtdepart.Value = depart.Departcname; //制单部门名称
            txttime.Value = DateTime.Now.ToString("yyyy年MM月dd日"); //显示提交的时间

            lblkhmc.Text = dt.Rows[0]["cusCName"].ToString(); //客户名称
            lblxz.Text = dt.Rows[0]["ProdTypeName"].ToString();//险种

            txtzbf.Value = dt.Rows[0]["totalPremium"].ToString();//总保费
            txtjjf.Value = dt.Rows[0]["totalEconomic"].ToString();//经济费

            lblzffs.Text = Request.QueryString["type"].ToString(); //支付方式

            lblbxgs.Text = dt.Rows[0]["comCname"].ToString();//保险公司
            txtzxf.Value = dt.Rows[0]["totalRich"].ToString();//咨询费


            lblbpr.Text = dt.Rows[0]["policy_maker"].ToString();//报批人
        }
    }
}