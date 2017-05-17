using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtNet_Web.Pages.Policy
{
    public partial class Jump : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PolicyList.aspx");
        }

        /// <summary>
        /// 添加盈亏测算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBudget_Click(object sender, EventArgs e)
        {
            object objPolicyID = Request.QueryString["policy"];
            int policyID = 0; //保单id
            if (objPolicyID != null || int.TryParse(objPolicyID.ToString(), out policyID))
            {
                Response.Redirect(string.Format("../Finance/BudgetAdd.aspx?policy={0}", Convert.ToInt32(objPolicyID)));
            }
        }
    }
}