using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Order
{
    public partial class SelectPayLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void dataBind()
        {
            string payid = Request.QueryString["payid"];//付款单位id
            this.hidlinkname.Value = Request.QueryString["link"]; //存储联系人的列的id
            this.hidlinkid.Value = Request.QueryString["linkid"]; //存储联系人id的列的id
            string sql = " and factId = " + payid;
            Data data = new Data();
            DataSet ds = data.DataPage("FactLinkman", "id", "*", sql, "id", true, 10, 5, pages);
            RpCustomerList.DataSource = ds;
            RpCustomerList.DataBind();
        }
    }
}