using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_Models;
using System.Collections;

namespace EtNet_Web.Pages.InsureCompany
{
    public partial class Coverage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StvProTypeBindData(stvProType.Nodes, "0");

            }
        }

        private void stvBind()
        {
            CompanyProd cprod = CompanyProdManager.getCompanyProdByComId(Convert.ToInt32(Request.QueryString["id"]));

        }


        //绑定险种树
        private void StvProTypeBindData(TreeNodeCollection nds, string parentId)
        {
            ProductTypeManager proType = new ProductTypeManager();

            TreeNode tn = null;

            DataTable dt = proType.GetAllList();
            DataRow[] rows = dt.Select(string.Format("ParentId='{0}'", parentId));


            int comid = Convert.ToInt32(Request.QueryString["id"].ToString());

            IList<CompanyProd> cplist = CompanyProdManager.GetListByPro(comid);

            foreach (DataRow row in rows)
            {

                tn = new TreeNode(row["ProdTypeName"].ToString(), row["ProdTypeNo"].ToString());
                foreach (CompanyProd item in cplist)
                {
                    if (tn.Value == item.ProdTypeId)
                    {
                        tn.Checked = true;
                    }
                }
                nds.Add(tn);
                StvProTypeBindData(tn.ChildNodes, row["ProdTypeNo"].ToString());
            }
        }



        private void addsource()
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            CompanyProdManager.deleteCompanyProdByComId(id);

            foreach (TreeNode select in this.stvProType.CheckedNodes)
            {
                CompanyProd cp = new CompanyProd();
                cp.CompanyId = id;
                cp.ProdTypeId = select.Value.ToString();
                CompanyProdManager.addCompanyProd(cp);
            }
        }


        /// <summary>
        /// 添加页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            addsource();

            Response.Redirect("../InsureCompany/Insure.aspx");
        }

        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../InsureCompany/Insure.aspx");
        }
    }
}