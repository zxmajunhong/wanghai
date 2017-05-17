using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Customers
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addNewLink_Click(object sender, EventArgs e)
        {
            addlinkinfo();
        }

        private void addlinkinfo() 
        {
            //联系人信息
            EtNet_Models.CusLinkman cusLink = new CusLinkman();
            cusLink.CustomerId = CustomerManager.getLastOneID().Id;
            cusLink.LinkName = this.linkname.Value.ToString();
            cusLink.Post = this.linkpost.Value.ToString();
            cusLink.Telephone = this.linktel.Value.ToString();
            cusLink.Fax = this.linkfax.Value.ToString();
            cusLink.Email = this.linkemail.Value.ToString();
            cusLink.Mobile = this.linkmobile.Value.ToString();
            cusLink.Msn = this.linkmsn.Value.ToString();
            cusLink.Skype = this.linkskype.Value.ToString();
            CusLinkmanManager.addCusLinkman(cusLink);
        }
    }
}