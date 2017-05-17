using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.ProductRate
{
    public partial class SelectProdType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StvProTypeBindData(stvProType.Nodes, "0");
            }
        }

        /// <summary>
        /// 绑定险种树
        /// </summary>
        /// <param name="nds">结点集合</param>
        /// <param name="parentId">父结点id</param>
        private void StvProTypeBindData(TreeNodeCollection nds, string parentId)
        {
            ProductTypeManager proType = new ProductTypeManager();

            TreeNode tn = null;

            DataTable dt = proType.GetAllList(); //得到险种类别数据列表
            DataRow[] rows = dt.Select(string.Format("ParentId='{0}'", parentId));
            foreach (DataRow row in rows)
            {
                tn = new TreeNode(row["ProdTypeName"].ToString(), row["ProdTypeNo"].ToString());

                //if (parentId.Trim() != string.Empty)
                //{
                //    tn.ShowCheckBox = true;
                //}
                nds.Add(tn);

                StvProTypeBindData(tn.ChildNodes, row["ProdTypeNo"].ToString());
            }
        }

        protected void stvProType_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode tn = stvProType.SelectedNode;
            if (tn.ChildNodes.Count == 0)
            {
                this.hidprodname.Value = tn.Text; //险种名称
                this.hidprodId.Value = tn.Value; //险种id
            }
            else
            {
                this.hidprodId.Value = this.hidprodname.Value = "";
            }
            //if (tn.ChildNodes.Count == 0)
            //{
                
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script>alert('" + tn.Text + tn.Value + tn.Parent.Value + "')</script>", false);
            //}
        }
    }
}