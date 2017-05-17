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
    public partial class AddMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPerson();
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
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            string itemname = Request.QueryString["itemname"];
            string username = this.person.SelectedValue;
            int year = DateTime.Now.Year;
            if (this.person.SelectedIndex != 0 && this.txtmoney.Text != "")
            {
                if (AusMoneyManager.Exists(itemname, username, year))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script>alert('添加失败,该人员在该项目下已存在预算')</script>", false);
                }
                else
                {
                    AusMoney ausmoney = new AusMoney();
                    ausmoney.itemname = itemname;
                    ausmoney.username = username;
                    ausmoney.amount = double.Parse(this.txtmoney.Text.Trim());
                    ausmoney.year = year;

                    bool count = AusMoneyManager.Add(ausmoney);
                    if (count)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('添加成功');window.location='DepartMoneyList.aspx?itemname=" + itemname +"';</script>", false);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败')</script>", false);
                    }
                }
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