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
    public partial class AddAusItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AusItemInfo ausItemInfo = new AusItemInfo();
            ausItemInfo.itemname = this.txtTypeName.Text.ToString();

            AusItemInfo ausItemInfocount = AusItemInfoManager.GetModelByName(this.txtTypeName.Text);

            if (ausItemInfocount == null)
            {
                bool count = AusItemInfoManager.Add(ausItemInfo);
                if (count == true)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功');window.location='AusItemList.aspx'</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败')</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('类型名称不能重复！');", true);
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AusItemList.aspx");
        }
    }
}