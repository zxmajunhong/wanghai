using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using System.Text;

namespace EtNet_Web.Pages.Product
{
    public partial class AddProType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DdlTargetBindData();
                DdlTypeBindData();
                InitData();

                if (Request.QueryString["hasTemp"] != null)
                {
                    TempData tempData = TempData.GetTempData();
                    txtName.Text = tempData.Name;
                    ddlTarget.SelectedIndex = ddlTarget.Items.IndexOf(ddlTarget.Items.FindByValue(tempData.TargetType));
                    ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByValue(tempData.ProClass));
                    txtParent.Text = tempData.Parent;
                }
            }

        }

        private void InitData()
        {
            ProductTypeManager proBLL = new ProductTypeManager();
            EtNet_Models.ProductType proModel = new EtNet_Models.ProductType();
            object id = Request.QueryString["id"];
            if (id == null || id.ToString() == string.Empty)
                return;
            object action = Request.QueryString["action"];
            if (action != null && action.ToString() == "MODIFY")
            {
                proModel = proBLL.GetModel(Request.QueryString["id"].ToString().Split('-')[0]);
                txtName.Text = proModel.ProdTypeName;
                SetDdlTargetSelectIndex(proModel.TargetTypeId.ToString());
                SetDdlTypeSelectIndex(proModel.ProdClass);
                if (proBLL.GetModel(proModel.ParentId) != null)
                    txtParent.Text = proBLL.GetModel(proModel.ParentId).ProdTypeName;
            }
            else if (action != null && action.ToString() == "ADD")
            {
                txtParent.Text = Request.QueryString["id"].ToString();
            }

        }

        //绑定险种大类
        private void DdlTypeBindData()
        {
            ProdClassManager proClass = new ProdClassManager();

            ddlType.DataValueField = "ProdClassNo";
            ddlType.DataTextField = "ProdClassName";
            ddlType.DataSource = proClass.GetAllList();
            ddlType.DataBind();
        }

        //绑定标的分类
        private void DdlTargetBindData()
        {
            TargetTypeManager targetType = new TargetTypeManager();

            ddlTarget.DataValueField = "TargetTypeID";
            ddlTarget.DataTextField = "TypeName";
            ddlTarget.DataSource = targetType.GetAllList();
            ddlTarget.DataBind();
        }

        //点击保存按钮时发生
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                object action = Request.QueryString["action"];
                object id = Request.QueryString["id"];
                TempData tempData = TempData.GetTempData();
                if (action == null || action.ToString() == string.Empty)
                {
                    if (tempData.Action != null && tempData.Action.ToString() != string.Empty)
                        action = tempData.Action;
                    else
                        return;
                }
                if (id == null || id.ToString() == string.Empty)
                {
                    if (tempData.ParentId != null && tempData.ParentId.ToString() != string.Empty)
                        id = tempData.ParentId;
                    else
                        return;
                }
                switch (action.ToString())
                {
                    case "ADD":
                        AddProdType(id.ToString().Split('-')[0]);
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>goBack();</script>");
                        break;
                    case "MODIFY":
                        ModifyProType(id.ToString().Split('-')[0]);
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>goBack();</script>");
                        break;
                    default:
                        throw new Exception("命令参数无效");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("保存数据时发生异常", ex);
            }
        }

        //添加险种
        private void AddProdType(string parent)
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            EtNet_Models.ProductType productTypeModel = new EtNet_Models.ProductType();

            productTypeModel.ParentId = parent;
            productTypeModel.ProdClass = ddlType.SelectedValue;
            productTypeModel.ProdTypeName = txtName.Text;
            productTypeModel.ProdTypeNo = MakeNum(parent);
            productTypeModel.TargetTypeId = Convert.ToInt32(ddlTarget.SelectedValue);
            productTypeBLL.Add(productTypeModel);

            hidId.Value = "ADD" + "$" + productTypeModel.ProdTypeNo + "$" + productTypeModel.ProdTypeName;
        }

        //修改险种
        private void ModifyProType(string proID)
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            EtNet_Models.ProductType productTypeModel = new EtNet_Models.ProductType();
            productTypeModel = productTypeBLL.GetModel(proID);

            productTypeModel.ProdClass = ddlType.SelectedValue;
            productTypeModel.ProdTypeName = txtName.Text;
            productTypeModel.TargetTypeId = Convert.ToInt32(ddlTarget.SelectedValue);

            productTypeBLL.Update(productTypeModel);
            hidId.Value = "MODIFY" + "$" + productTypeModel.ProdTypeName;
        }


        private bool ExitsNum(string num)
        {
            ProductTypeManager productTypeBLL = new ProductTypeManager();
            productTypeBLL.GetList(string.Format("ProdTypeNo = '{0}'", num));
            DataTable dt = productTypeBLL.GetList(string.Format("ProdTypeNo = '{0}'", num));
            return dt.Rows.Count > 0 ? true : false;
        }

        private string MakeNum(string parent)
        {
            StringBuilder num = new StringBuilder();
            for (int i = 1; i < 1000; i++)
            {
                num.Append(parent);
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

        //设置险种大类选中项
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

        //设置标的分类选中项
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

        protected void BtnManage_Click(object sender, ImageClickEventArgs e)
        {
            TempData tempData = TempData.GetTempData();
            tempData.Name = txtName.Text;
            tempData.ProClass = ddlType.SelectedValue;
            tempData.TargetType = ddlTarget.SelectedValue;
            tempData.Parent = txtParent.Text;
            tempData.Action = Request.QueryString["action"];
            tempData.ParentId = Request.QueryString["id"];

            Response.Redirect("ProTypeClass.aspx");
        }

    }

    public class TempData
    {
        public static TempData tempData = null;

        public static TempData GetTempData()
        {
            if (tempData == null)
                tempData = new TempData();
            return tempData;
        }

        public string Parent
        { get; set; }

        public string Name
        { get; set; }

        public string ProClass
        { get; set; }

        public string TargetType
        { get; set; }

        public object Action
        { get; set; }

        public object ParentId
        { get; set; }
    }
}