using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;
using System.Collections;
using System.Configuration;

namespace EtNet_Web.CMS.Data
{
    public partial class InsurancesManager : System.Web.UI.Page
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
        public void dataBind()
        {
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["CMSCount"]);
            int page = Convert.ToInt32(ConfigurationManager.AppSettings["CMSPage"]);
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("To_Invoice", "Id", "*", "", "Id", true, count, page, pages);
            rpInvoice.DataSource = ds;
            rpInvoice.DataBind();
        }


        /// <summary>
        /// 显示名字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string CName(int id)
        {
            LoginInfo cname = LoginInfoManager.getLoginInfoById(id);
            return cname.Cname.ToString();
        }
        /// <summary>
        /// 显示时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string changeTime(string str)
        {
            string time = str.Substring(0, Convert.ToInt32(str.IndexOf(" ")));
            return time;
        }

        protected void rpInvoice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int count = To_InvoiceManager.deleteTo_Invoice(id);
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

            for (int i = 0; i < this.rpInvoice.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)(rpInvoice.Items[i].FindControl("cbx"));
                Label lbl = (Label)rpInvoice.Items[i].FindControl("lbl");
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

                To_Invoice to_Invoice = To_InvoiceManager.getTo_InvoiceById(Convert.ToInt32(check[i]));
                if (to_Invoice != null)
                {

                    To_InvoiceManager.deleteTo_Invoice(Convert.ToInt32(check[i]));
                }
            }
            dataBind();
        }
    }
}