using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.AusItem
{
    public partial class UpdateAusMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPerson();
                LoadNowMoney();
            }
        }

        /// <summary>
        /// 加载用户数据
        /// </summary>
        private void LoadPerson()
        {
            this.person.Items.Clear();
            IList<LoginInfo> list = EtNet_BLL.LoginInfoManager.getLoginInfoAll();
            this.person.DataSource = list;
            this.person.DataTextField = "cname";
            this.person.DataValueField = "cname";
            this.person.DataBind();
            this.person.Items.Insert(0, "——请选中——");
        }

        /// <summary>
        /// 加载当前数据
        /// </summary>
        private void LoadNowMoney()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string itemname = Request.QueryString["itemname"];

            AusMoney ausmoney = AusMoneyManager.GetModel(id);
            this.person.SelectedValue = ausmoney.username;
            this.txtmoney.Text = ausmoney.amount.ToString();
            this.person.Enabled = false;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string itemname = Request.QueryString["itemname"];

            AusMoney ausmoney = AusMoneyManager.GetModel(id);
            double haspay = ausmoney.haspay;
            if (Convert.ToDouble(this.txtmoney.Text.Trim()) < haspay)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script>alert('更新失败,该人员在该项目下的总预算不能小于已支付的预算')</script>", false);
            }
            if (this.txtmoney.Text != "")
            {
                //bool has = AusMoneyManager.Exists(itemname, this.person.SelectedValue);
                //if (has)
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script>alert('更新失败,该人员在该项目下已存在预算')</script>", false);
                //}
                //else
                //{
                //ausmoney.username = this.person.SelectedValue;
                ausmoney.amount = Convert.ToDouble(this.txtmoney.Text.Trim());
                bool count = AusMoneyManager.Update(ausmoney);
                if (count)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('更新成功');window.location='DepartMoneyList.aspx?itemname=" + itemname + "';</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
                }
                //}
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('请检查人员和金额是否已经填写');", true);
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            string itemname = Request.QueryString["itemname"];
            Response.Redirect("DepartMoneyList.aspx?itemname=" + itemname);
        }
    }
}