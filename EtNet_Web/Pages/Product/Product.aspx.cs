using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using System.Text;
using System.Web.Services;

namespace EtNet_Web.Pages.Product
{
    public partial class Product : System.Web.UI.Page
    {
        public static string ScrollValue = string.Empty;//滚动条位置
        protected void Page_Load(object sender, EventArgs e)
        {
            ScrollValue = divScrollValue.Value; //得到滚动条位置
            if (!IsPostBack)
            {
                StvProTypeBindData(stvProType.Nodes, "0");
                DdlTypeBindData();
                DdlTargetBindData();
                stvProType.Nodes[0].Selected = true;
                ReadyProductData(stvProType.SelectedValue);
            }
        }


        public static void BindTree()
        {
            Pages.Product.Product p = new Product();
            p.StvProTypeBindData(p.stvProType.Nodes, "0");
        }

        #region 绑定数据
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


        /// <summary>
        /// 绑定险种大类
        /// </summary>
        private void DdlTypeBindData()
        {
            ProdClassManager proClass = new ProdClassManager();

            ddlType.DataValueField = "ProdClassNo";
            ddlType.DataTextField = "ProdClassName";
            ddlType.DataSource = proClass.GetAllList();
            ddlType.DataBind();
        }

        /// <summary>
        /// 绑定标的分类
        /// </summary>
        private void DdlTargetBindData()
        {
            TargetTypeManager targetType = new TargetTypeManager();

            ddlTarget.DataValueField = "TargetTypeID";
            ddlTarget.DataTextField = "TypeName";
            ddlTarget.DataSource = targetType.GetAllList();
            ddlTarget.DataBind();
        }

        #endregion

        /// <summary>
        /// 根据险种ID绑定右侧数据
        /// </summary>
        /// <param name="prodTypeID"></param>
        private void ReadyProductData(string prodTypeID)
        {
            EtNet_Models.ProductType productTypeModel = new EtNet_Models.ProductType();
            ProductTypeManager productTypeBLL = new ProductTypeManager();

            productTypeModel = productTypeBLL.GetModel(prodTypeID);
           
            txtName.Text = productTypeModel.ProdTypeName;
            hidNum.Value = productTypeModel.ProdTypeNo;
            if (productTypeModel.ParentId.Trim() != "0")
            {
                StringBuilder parentName = new StringBuilder();
                parentName.Append(GetParent(productTypeModel.ParentId).ProdTypeNo);
                parentName.Append("-");
                parentName.Append(GetParent(productTypeModel.ParentId).ProdTypeName);
                txtParent.Text = parentName.ToString();
                //lblParentNo.Text = GetParent(productTypeModel.ParentId).ProdTypeNo;
            }
            else
            {
                txtParent.Text = "";
                //lblParentNo.Text = "";
            }

            hidParent.Value = productTypeModel.ProdTypeNo + "-" + productTypeModel.ProdTypeName;

            SetDdlTargetSelectIndex(productTypeModel.TargetTypeId.ToString());
            SetDdlTypeSelectIndex(productTypeModel.ProdClass);
        }

        /// <summary>
        /// 设置险种大类选中项
        /// </summary>
        /// <param name="prodClassID"></param>
        private void SetDdlTypeSelectIndex(string prodClassID)
        {
            try
            {
                foreach (ListItem item in ddlType.Items)
                {
                    if (item.Value.Trim() == prodClassID.Trim())
                    {
                        ddlType.SelectedIndex = ddlType.Items.IndexOf(item);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("初始化险种分类时发生异常:", ex);
            }
        }

        /// <summary>
        /// 设置标的分类选中项
        /// </summary>
        /// <param name="targetTypeID"></param>
        private void SetDdlTargetSelectIndex(string targetTypeID)
        {
            try
            {
                ListItem item = ddlTarget.Items.FindByValue(targetTypeID);
                if (item != null)
                    ddlTarget.SelectedIndex = ddlTarget.Items.IndexOf(item);
            }
            catch (Exception ex)
            {
                throw new Exception("初始化标的分类时发生异常:", ex);
            }
        }

        /// <summary>
        /// 获取父级实体
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private EtNet_Models.ProductType GetParent(string parentID)
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            return productTypeBLL.GetModel(parentID);
        }

        /// <summary>
        /// 绑定项目列表
        /// </summary>
        /// <param name="prodTypeID"></param>
        private void RpProListBindData(string prodTypeID)
        {
            try
            {
                EtNet_BLL.ProductManager product = new EtNet_BLL.ProductManager();
                string where = string.Format("ProdTypeID='{0}'", prodTypeID);
                rpProList.DataSource = product.GetList(where);
                rpProList.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("初始化项目列表时发生异常:", ex);
            }
        }

        /// <summary>
        /// 险种树选中项发生改变时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void stvProType_SelectedNodeChanged(object sender, EventArgs e)
        {
            ReadyProductData(stvProType.SelectedValue);
            RpProListBindData(stvProType.SelectedValue);

            //btnAdd.Enabled = btnChange.Enabled = true;
            //btnSave.Enabled = false;
            txtName.Enabled = false;

            //btnSave.CommandName = "";
        }

        /// <summary>
        /// 点击新增按钮时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (stvProType.SelectedValue == string.Empty)
                return;
            //btnAdd.Enabled = btnChange.Enabled = false;
            //btnSave.Enabled = true;
            txtName.Text = "";

            EtNet_Models.ProductType proTypeModel = GetParent(stvProType.SelectedValue);
            txtParent.Text = proTypeModel.ProdTypeNo + "-" + proTypeModel.ProdTypeName;

            //btnSave.CommandName = "ADD";
        }

        /// <summary>
        /// 点击修改按钮时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (stvProType.SelectedValue == string.Empty)
                return;
            //btnAdd.Enabled = btnChange.Enabled = false;
            //btnSave.Enabled = true;

            //btnSave.CommandName = "MODIFY";
        }

        /// <summary>
        /// 点击保存按钮时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //switch (btnSave.CommandName)
                //{
                //    case "ADD":
                //        AddProType();
                //        break;
                //    case "MODIFY":
                //        ModifyProType();
                //        break;
                //    default:
                //        throw new Exception("命令参数无效");
                //}
                //switch (hidCMD.Value)
                //{
                //    case "ADD":
                //        AddProType();
                //        break;
                //    case "MODIFY":
                //        ModifyProType();
                //        break;
                //    default:
                //        throw new Exception("命令参数无效");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("保存数据时发生异常", ex);
            }
            finally
            {
                //btnAdd.Enabled = true;
                //btnChange.Enabled = true;
                //btnSave.Enabled = false;
                txtName.Enabled = ddlTarget.Enabled = ddlType.Enabled = false;
            }
        }

        /// <summary>
        /// 判断是否存在该险种
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool ExitsNum(string num)
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            productTypeBLL.GetList(string.Format("ProdTypeNo = '{0}'", num));
            DataTable dt = productTypeBLL.GetList(string.Format("ProdTypeNo = '{0}'", num));
            return dt.Rows.Count > 0 ? true : false;
        }

        private string MakeNum()
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            EtNet_Models.ProductType productTypeModel = new EtNet_Models.ProductType();
            productTypeModel = GetParent(stvProType.SelectedValue);

            StringBuilder num = new StringBuilder();
            for (int i = 1; i < 1000; i++)
            {
                num.Append(productTypeModel.ProdTypeNo);
                switch (i.ToString().Length)
                {
                    case 1:
                        num.Append("00");
                        break;
                    case 2:
                        num.Append("0");
                        break;
                    default:
                        break;
                }
                num.Append(i.ToString());
                if (!ExitsNum(num.ToString()))
                    break;
                else
                    num.Clear();
            }
            return num.ToString();


        }

        /// <summary>
        /// 添加险种
        /// </summary>
        private void AddProType()
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            EtNet_Models.ProductType productTypeModel = new EtNet_Models.ProductType();

            productTypeModel.ParentId = stvProType.SelectedValue.Trim() == string.Empty ? "0" : stvProType.SelectedValue;
            productTypeModel.ProdClass = ddlType.SelectedValue;
            productTypeModel.ProdTypeName = txtName.Text;
            productTypeModel.ProdTypeNo = MakeNum();
            productTypeModel.TargetTypeId = Convert.ToInt32(ddlTarget.SelectedValue);

            if (productTypeBLL.Add(productTypeModel))
            {
                stvProType.Nodes.Clear();
                StvProTypeBindData(stvProType.Nodes, "0");
                stvProType.ExpandAll();
            }

            StvProTypeBindData(stvProType.Nodes, "0");
        }

        /// <summary>
        /// 修改险种
        /// </summary>
        private void ModifyProType()
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            EtNet_Models.ProductType productTypeModel = new EtNet_Models.ProductType();

            if (stvProType.SelectedValue.Trim() != string.Empty)
                productTypeModel.ParentId = stvProType.SelectedNode.Parent.Value;
            else
                productTypeModel.ParentId = "                                ";
            productTypeModel.ProdClass = ddlType.SelectedValue;
            productTypeModel.ProdTypeName = txtName.Text;
            productTypeModel.ProdTypeNo = GetParent(stvProType.SelectedValue).ProdTypeNo;
            productTypeModel.TargetTypeId = Convert.ToInt32(ddlTarget.SelectedValue);

            if (productTypeBLL.Update(productTypeModel))
            {
                stvProType.SelectedNode.Text = txtName.Text;
            }
        }

        /// <summary>
        /// 删除险种
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (stvProType.CheckedNodes.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "key", "alert('请选择要删除的险种')", true);
                return;
            }

            EtNet_BLL.ProductManager product = new EtNet_BLL.ProductManager();
            EtNet_BLL.ProductTypeManager productType = new ProductTypeManager();
            foreach (TreeNode node in stvProType.CheckedNodes)
            {
                string where = string.Format("ProdTypeID='{0}'", node.Value);
                if (product.GetList(where).Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "key", "alert('所选险种下含有项目数据，不能删除')", true);
                    return;
                }
            }

            StringBuilder ids = new StringBuilder();
            foreach (TreeNode node in stvProType.CheckedNodes)
            {
                ids.Append("'");
                ids.Append(node.Value);
                ids.Append("'");
                ids.Append(",");
            }
            if (ids.ToString().EndsWith(","))
                ids.Remove(ids.Length - 1, 1);
            if (productType.DeleteList(ids.ToString()))
            {
                stvProType.Nodes.Clear();
                StvProTypeBindData(stvProType.Nodes, "0");
                stvProType.ExpandAll();
            }
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="ids"></param>
        private void DelProduct(string[] ids)
        {
            EtNet_BLL.ProductManager proBLL = new EtNet_BLL.ProductManager();
            StringBuilder idlist = new StringBuilder();
            foreach (string id in ids)
            {
                idlist.Append(id);
                idlist.Append(",");
            }
            if (idlist.ToString().EndsWith(","))
                idlist.Remove(idlist.Length - 1, 1);
            if (proBLL.DeleteList(idlist.ToString()))
                RpProListBindData(stvProType.SelectedValue);
        }




        protected void rpProList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DEL":
                    string[] ids = new string[] { e.CommandArgument.ToString() };
                    DelProduct(ids);
                    break;
                default:
                    break;
            }
        }

        protected void btnType_Click(object sender, EventArgs e)
        {
            string resultStr = hidResult.Value;
            if (resultStr.Trim() == string.Empty)
                return;
            string[] result = resultStr.Split('$');
            switch (result[0])
            {
                case "ADD":
                    TreeNode newNode = new TreeNode(result[2], result[1]);
                    newNode.ShowCheckBox = true;
                    stvProType.SelectedNode.ChildNodes.Add(newNode);
                    break;
                case "MODIFY":
                    stvProType.SelectedNode.Text = result[1];
                    break;
                default:
                    break;
            }
        }

        protected void btnPro_Click(object sender, EventArgs e)
        {
            RpProListBindData(stvProType.SelectedValue);
        }

        protected void stvProType_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            TreeNode node = sender as TreeNode;
            if (node.ChildNodes.Count > 0)
            {
                foreach (TreeNode cnode in node.ChildNodes)
                {
                    cnode.Checked = true;
                }
            }
        }
    }
}