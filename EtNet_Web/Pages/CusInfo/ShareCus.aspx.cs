using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class ShareCus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCusData();
            }
        }


        /// <summary>
        /// 加载具有查看客户权限的用户
        /// </summary>
        /// <param name="strlist">用户的id值列表</param>
        /// <param name="strlistxt">用户的名称列表</param>
        private void LoadViewCus(string strlist, string strlistxt)
        {
            this.hidlist.Value = strlist;
            this.hidtxtlist.Value = strlistxt;
            string strsql ="";
            if (strlist != "")
            {
              strsql = " id in (" + strlist + ")";
            }
            DataTable tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            if (strlist == "")
            {
                tbl.Rows.Clear();
            }
            this.listright.DataSource = tbl;
            this.listright.DataTextField = "cname";
            this.listright.DataValueField = "id";
            this.listright.DataBind();

            if (strlist != "")
            {
               strsql = " id not in (" + strlist + ")";
            }
            tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            this.listleft.DataSource = tbl;
            this.listleft.DataTextField = "cname";
            this.listleft.DataValueField = "id";
            this.listleft.DataBind();
        }


        /// <summary>
        /// 加载具操作客户权限的用户
        /// </summary>
        /// <param name="strlist">用户的id值</param>
        /// <param name="strlistxt">用户的名列表</param>
        private void LoadAuthCus(string strlist,string strlistxt)
        {
            this.hidulist.Value = strlist;
            this.hidtxtulist.Value = strlistxt;
            string strsql = "";
            if (strlist != "")
            {
                strsql = " id in (" + strlist + ")";
            }
            DataTable tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            if (strlist == "")
            {
                tbl.Rows.Clear();
            }
            this.listuright.DataSource = tbl;
            this.listuright.DataTextField = "cname";
            this.listuright.DataValueField = "id";
            this.listuright.DataBind();

            if (strlist != "")
            {
                strsql = " id not in (" + strlist + ")";
            }
            tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            this.listuleft.DataSource = tbl;
            this.listuleft.DataTextField = "cname";
            this.listuleft.DataValueField = "id";
            this.listuleft.DataBind();
        }


        /// <summary>
        /// 加载客户
        /// </summary>
        private void LoadCusData()
        {
            int id = int.Parse(Request.QueryString["id"]);
            EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(id);
            if (cus == null)
            {
                this.imgbtnsave.Enabled = false;
            }
            else
            {
                LoadViewCus(cus.Viewidlist,cus.Viewidtxt);
                LoadAuthCus(cus.Authidlist,cus.Authidtxt);
            }
        }


        //保存
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(id);
            if (cus == null)
            {
                this.imgbtnsave.Enabled = false;
            }
            else
            {
                cus.Viewidlist = this.hidlist.Value;
                cus.Viewidtxt = this.hidtxtlist.Value;
                cus.Authidlist = this.hidulist.Value;
                cus.Authidtxt = this.hidtxtulist.Value;
                if(EtNet_BLL.CustomerManager.updateCustomer(cus) >= 1)
                {
                    LoadCusData();
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "save", "<script>closecus()</script>", false);
                }
                
            }
        }

      
    }
}