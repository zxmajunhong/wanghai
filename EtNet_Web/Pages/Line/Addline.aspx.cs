using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Line
{
    public partial class Addline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Tb_line lineModel = new Tb_line();
            lineModel.Line = this.txtlinename.Text;
            lineModel.LineRemark = this.txtlineremark.Text;
            lineModel.AutoCode = this.txtautocode.Text;

            int count = Tb_lineManager.addTb_line(lineModel);

            if (count >0)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功');window.location='LineList.aspx'</script>", false);
            }
        }
        /// <summary>
        /// Back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("LineList.aspx");
        }
    }
}