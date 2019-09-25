using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Order
{
    public partial class SearchDepart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDepart();
            }
        }

        /// <summary>
        /// 加载营业部信息
        /// </summary>
        private void loadDepart()
        {
            string departid = Request.QueryString["departid"]; //营业部id
            CusLinkman model = CusLinkmanManager.getCusLinkmanById(int.Parse(departid));
            departName.Value = model.DepartName; //营业部名称
            linkTel.Value = model.Telephone; //电话
            linkFax.Value = model.Fax; //传真
            linkEmail.Value = model.Email; //邮箱
            linkMsn.Value = model.Msn; //qq
            linkSkype.Value = model.Skype; //skype
        }
    }
}