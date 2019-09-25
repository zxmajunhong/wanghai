using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Collections;
using System.Data;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class AusFin : System.Web.UI.Page
    {
        string strwhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            getFin();
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void getFin()
        {
            DataTable ausFin = AusFinInfoManager.GetList(strwhere);

            this.type.DataSource = ausFin;
            this.type.DataBind();
        }
    }
}