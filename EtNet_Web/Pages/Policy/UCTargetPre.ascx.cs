using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Policy
{
    public partial class UCTargetPre : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindTarget(int policyID)
        {
            IList<To_PolicyTarget> targetList = To_PolicyTargetManager.GetListByPolicy(policyID);

            if (targetList.Count > 0)
            {
                rpTargetProperty.DataSource = targetList;
                rpTargetProperty.DataBind();

                TargetTypeManager tpBLL = new TargetTypeManager();
                TargetType tpModel = tpBLL.GetModel(targetList[0].PropertyTypeID);
                if (tpModel != null)
                {
                    ltrTargetType.Text = tpModel.TypeName;
                }
            }
        }
    }
}