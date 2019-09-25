using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Pages.SysSet.AuditRole
{
    public partial class ShowAuditRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAuditRoleData();
            }
        }

        /// <summary>
        /// 加载审核规则数据
        /// </summary>
        private void LoadAuditRoleData()
        {
            string strsql = " id=" + Request.QueryString["id"];
            DataTable tbl = EtNet_BLL.ViewBLL.ViewApprovalRuleManager.getList(strsql);
            if (tbl.Rows.Count == 1)
            {
                this.iptcname.Text = tbl.Rows[0]["cname"].ToString();
                this.iptsort.Text = tbl.Rows[0]["sort"].ToString();
                this.iptjobflow.Text = tbl.Rows[0]["jobsorttxt"].ToString();
                this.iptremark.Text = tbl.Rows[0]["txt"].ToString();
                this.iptdepart.Text = tbl.Rows[0]["departidtxt"].ToString();
                this.auditpic.InnerHtml = File.ReadAllText(Server.MapPath(tbl.Rows[0]["rolepic"].ToString()));

            }
            else
            {
                string str = "<script>alert('加载失败'); window.location = 'SearchAuditRole.aspx'</script> ";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "laod", str, false);
            }

        }

        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SearchAuditRole.aspx");
        }

    }
}