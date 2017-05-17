using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using EtNet_BLL.DataPage;
using System.Data;
using System.Collections;
using System.Configuration;

namespace EtNet_Web.CMS.Data
{
    public partial class CompanysManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }

        }

        public void dataBind()
        {
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["CMSCount"]);
            int page = Convert.ToInt32(ConfigurationManager.AppSettings["CMSPage"]);
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("Factory", "Id", "*", "", "Id", true, count, page, pages);
            rpCompany.DataSource = ds;
            rpCompany.DataBind();
        }

        public static string toMadeFrom(int id)
        {
            LoginInfo login = LoginInfoManager.getLoginInfoById(id);
            return login.Cname;
        }

        protected void rpCompany_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                FactBankManager.deleteFactBankByfactId(id);
                FactLinkmanManager.deleteFactLinkmanByfactId(id);
                int count = FactoryManager.deleteFactory(id);
                if (count <= 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('删除失败')", true);
                    return;
                }

            }
            dataBind();
        }

        protected void ibtnDeleteAll_Click(object sender, ImageClickEventArgs e)
        {

            string delId = "";
            //先遍历取得选中项    

            for (int i = 0; i < this.rpCompany.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)(rpCompany.Items[i].FindControl("cbx"));
                Label lbl = (Label)rpCompany.Items[i].FindControl("lbl");
                if (cbx != null || cbx.Text != "")
                {
                    if (cbx.Checked)
                    {
                        delId += lbl.Text + ",";
                    }
                }
            }
            //去掉最后一个,    
            delId = (delId + ")").Replace(",)", "");
            IList check = delId.Split(',');

            for (int i = 0; i < check.Count; i++)
            {
                Factory factory = FactoryManager.getFactoryById(Convert.ToInt32(check[i]));
                if (factory != null)
                {
                    FactBankManager.deleteFactBankByfactId(factory.Id);
                    FactLinkmanManager.deleteFactLinkmanByfactId(factory.Id);
                    FactoryManager.deleteFactory(Convert.ToInt32(check[i]));
                }
            }
            dataBind();
        }


    }
}