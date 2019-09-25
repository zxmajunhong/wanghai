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
    public partial class UpdateAusItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAusItem();
            }
        }

        /// <summary>
        /// 加载第一步数据
        /// </summary>
        private void loadAusItem()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            AusItemInfo ausItem = AusItemInfoManager.GetModel(id);
            txtTypeName.Text = ausItem.itemname;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AusItemInfo ausItemInfo = new AusItemInfo();
            ausItemInfo.id = Convert.ToInt32(Request.QueryString["id"]);
            ausItemInfo.itemname = this.txtTypeName.Text.ToString();

            AusItemInfo ausItemInfocount = AusItemInfoManager.GetModelByName(this.txtTypeName.Text);

            if (ausItemInfocount == null)
            {
                bool count = AusItemInfoManager.Update(ausItemInfo);
                if (count == true)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='AusItemList.aspx'</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新失败')</script>", false);
                }
            }
            else
            {
                if (ausItemInfocount.id == ausItemInfo.id) //判断其与所需要更新的类别的ID是否一样，如果一样可以更新。如果不一样就不能更新
                {
                    bool count = AusItemInfoManager.Update(ausItemInfo);

                    if (count == true)
                    {

                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('更新成功');window.location='AusItemList.aspx'</script>", false);
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
            Response.Redirect("AusItemList.aspx");
        }
    }
}