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

namespace EtNet_Web.Pages.Common
{
    public partial class AnnouncementDeleteFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getType();
        }

        private void getType()
        {
            IList<AusTypeInfo> austype = AusTypeInfoManager.GetAllList();
            this.type.DataSource = austype;
            this.type.DataBind();
        }

        protected void type_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                string id = e.CommandArgument.ToString();

                IList<AusTypeInfo> cop = AusTypeInfoManager.getAusRottenInfo(Convert.ToInt32(id));

                if (cop.Count >0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('正在使用中的类型不能删除！');", true);
                }
                else
                {
                    AusTypeInfoManager.Delete(Convert.ToInt32(id));
                }
            }
            getType();
        }

    

      
    }
}