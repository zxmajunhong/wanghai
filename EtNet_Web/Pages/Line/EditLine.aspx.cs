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
    public partial class EditLine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        /// <summary>
        /// Edit
        /// </summary>
        private void loadData() 
        {
            Tb_line line = Tb_lineManager.getTb_lineById(Convert.ToInt32(Request.QueryString["id"]));
            this.txtlinename.Text = line.Line;
            this.txtlineremark.Text = line.LineRemark;
            this.txtautocode.Text = line.AutoCode;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Tb_line line = Tb_lineManager.getTb_lineById(Convert.ToInt32(Request.QueryString["id"]));
            line.Line = this.txtlinename.Text;
            line.LineRemark = this.txtlineremark.Text;
            line.AutoCode = this.txtautocode.Text;
            int count = Tb_lineManager.updateTb_line(line);

            if (count>0)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", "<script>alert('保存成功');window.location='LineList.aspx'</script>", false);
            }
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("LineList.aspx");
        }
    }
}