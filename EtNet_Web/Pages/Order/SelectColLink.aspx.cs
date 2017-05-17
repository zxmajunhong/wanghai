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
    public partial class SelectColLink : System.Web.UI.Page
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
            string colid = Request.QueryString["colid"]; //收款单位id
            this.hidlink.Value = Request.QueryString["link"]; //存储营业部名称的列的id
            this.hidlinkid.Value = Request.QueryString["linkid"]; //存储营业部id的列的id
            this.hidlinkname.Value = Request.QueryString["linkname"]; //存储营业部联系人的列的id
            string sql = " and customerId = " + colid;
            Data data = new Data();
            DataSet ds = data.DataPage("CusLinkman", "id", "*", sql, "id", true, 10, 5, pages);
            RpCustomerList.DataSource = ds;
            RpCustomerList.DataBind();
        }
    }
}