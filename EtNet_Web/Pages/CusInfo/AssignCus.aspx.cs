using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class AssignCus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadCusList();
            }
        }


        /// <summary>
        /// 加载客户数据
        /// </summary>
        private void LoadCusList()
        {
            string strfields = " id, cusCName";
            string strsql = " auditstatus='04' ";

            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList(strfields,strsql);
            this.ddlcus.DataSource = tbl;

            DataRow row = tbl.NewRow();
            row["id"] = "-1";
            row["cusCName"] = "——请选择——";
            tbl.Rows.InsertAt(row, 0);

            this.ddlcus.DataTextField = "cusCName";
            this.ddlcus.DataValueField = "id";
            this.ddlcus.DataBind();
            
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
        private void LoadAuthCus(string strlist, string strlistxt)
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
            if (this.ddlcus.SelectedIndex != 0)
            {
                int id = int.Parse(this.ddlcus.SelectedValue);
                EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(id);
                if (cus == null)
                {
                    this.imgbtnsave.Enabled = false;
                }
                else
                {
                    LoadViewCus(cus.Viewidlist, cus.Viewidtxt);
                    LoadAuthCus(cus.Authidlist, cus.Authidtxt);
                }
            }
            else
            {
                this.hidlist.Value = "";
                this.hidtxtlist.Value = "";
                this.hidulist.Value = "";
                this.hidtxtulist.Value = "";
                this.listleft.Items.Clear();
                this.listright.Items.Clear();
                this.listuleft.Items.Clear();
                this.listuright.Items.Clear();
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "save", "<script>alert('未选中任何客户!')</script>", false);
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void SaveCus()
        {
            if (this.ddlcus.SelectedIndex != 0)
            {
                int id = int.Parse(this.ddlcus.SelectedValue);
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
                    if (EtNet_BLL.CustomerManager.updateCustomer(cus) >= 1)
                    {
                        LoadCusData();
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "save", "<script>alert('保存成功!')</script>", false);
                    }

                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "save", "<script>alert('未选中任何客户!')</script>", false);
            }
        }



        //保存客户查看与权限的设置
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            SaveCus();
        }


        //选客户
        protected void ddlcus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCusData();
        }


    }
}