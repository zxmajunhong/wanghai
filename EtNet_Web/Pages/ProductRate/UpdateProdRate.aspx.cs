using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;


namespace EtNet_Web.Pages.ProductRate
{
    public partial class UpdateProdRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                this.txtuser.Enabled = false;
                this.txtprod.Enabled = false;
            }
        }

        /// <summary>
        /// 加载第一步数据
        /// </summary>
        public void loadData()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            LoginProdRate model = LoginProdRateManager.GetModel(id);
            txtuser.Text = model.UserName;
            hiduserId.Value = model.UserId;
            txtprod.Text = model.ProdName;
            hidprodId.Value = model.ProdId;
            txtrate.Text = model.Rate.ToString();
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            //if (LoginProdRateManager.Exists(txtprod.Text.Trim(), txtuser.Text.Trim()))
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "<script>alert('修改失败,该人员在该险种下以存在比率')</script>", false);
            //}
            //else 
            //{
                int id = Convert.ToInt32(Request.QueryString["id"]);
                LoginProdRate model = LoginProdRateManager.GetModel(id);
                model.ProdName = txtprod.Text.Trim(); //险种名称 
                model.ProdId = this.hidprodId.Value; //险种id
                model.UserName = txtuser.Text.Trim(); //人员名称
                model.UserId = this.hiduserId.Value; //人员id
                model.Rate = double.Parse(txtrate.Text.Trim()); //比率

                bool result = LoginProdRateManager.Update(model);
                if (result)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('修改成功');window.location='ProdRateList.aspx';</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改失败')</script>", false);
                }
            //}
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ProdRateList.aspx");
        }
    }
}