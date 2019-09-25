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
    public partial class SearchLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadLink();
            }
        }

        /// <summary>
        /// 加载联系人信息
        /// </summary>
        private void loadLink()
        {
            string witch = Request.QueryString["witch"]; //用于判断是查看收款单位还是付款单位的联系人
            string linkId = Request.QueryString["linkid"]; //联系人id
            string payid = Request.QueryString["payid"]; //付款单位id
            if (linkId == "0")
            {
                Factory model = FactoryManager.getFactoryById(int.Parse(payid));
                linkName.Value = model.LinkeName; //联系人名称
                linkPost.Value = model.Duty; //职位
                linkMobile.Value = model.Mobile; //手机号码
                linkTel.Value = model.Telephone; //联系电话
                linkFax.Value = model.Fax; //联系传真
                linkEmail.Value = model.Email; //邮箱地址
                linkMsn.Value = model.QQ; //qq
                linkSkype.Value = model.Skype; //skype
            }
            else
            {
                FactLinkman model = FactLinkmanManager.getFactLinkmanById(int.Parse(linkId));
                linkName.Value = model.LinkName; //联系人名称
                linkPost.Value = model.Duty; //职位
                linkMobile.Value = model.Mobile; //手机号码
                linkTel.Value = model.Telephone; //联系电话
                linkFax.Value = model.Fax; //联系传真
                linkEmail.Value = model.Email; //邮箱地址
                linkMsn.Value = model.QQ; //qq
                linkSkype.Value = model.Skype; //skype
            }

        }
    }
}