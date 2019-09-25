using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.AusFin
{
    public partial class UpdateAusFin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAusFin();
            }
        }

        /// <summary>
        /// 加载第一步数据
        /// </summary>
        private void loadAusFin()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            AusFinInfo ausFin = AusFinInfoManager.GetModel(id);
            txtTypeName.Text = ausFin.itemname;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AusFinInfo ausFinInfo = new AusFinInfo();
            ausFinInfo.id = Convert.ToInt32(Request.QueryString["id"]);
            ausFinInfo.itemname = this.txtTypeName.Text.ToString();

            AusFinInfo ausFinInfocount = AusFinInfoManager.GetModelByName(this.txtTypeName.Text);

            if (ausFinInfocount == null)
            {
                bool count = AusFinInfoManager.Update(ausFinInfo);
                if (count == true)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='AusFinList.aspx'</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
                }
            }
            else
            {
                if (ausFinInfocount.id == ausFinInfo.id) //判断其与所需要更新的类别的ID是否一样，如果一样可以更新。如果不一样就不能更新
                {
                    bool count = AusFinInfoManager.Update(ausFinInfo);

                    if (count == true)
                    {

                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='AusFinList.aspx'</script>", false);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('类型名称不能重复！');", true);
                }
            }
        }

        /// <summary>
        ///  返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AusFinList.aspx");
        }
    }
}