using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtNet_Web.Pages.Product
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object id = Request.QueryString["id"];
            if (id == null || id.ToString() == string.Empty)
                return;
            if (!IsPostBack)
                InitData(Convert.ToInt32(id));
        }

        private void InitData(int id)
        {
            EtNet_BLL.ProductManager proBLL = new EtNet_BLL.ProductManager();
            EtNet_Models.Product proModel = proBLL.GetModel(id);

            txtBrief.Value = Server.UrlDecode(proModel.Brief);
            txtMark.Value = proModel.Remark;
            txtName.Value = proModel.ProdName;
            chkMain.Checked = proModel.FlagMain;

            EtNet_BLL.ProductTypeManager proType = new EtNet_BLL.ProductTypeManager();
            txtType.Value = proType.GetModel(proModel.ProdTypeID).ProdTypeName;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            object id = Request.QueryString["id"];
            if (id == null || id.ToString() == string.Empty)
                return;
            AddProd(Convert.ToInt32(id));
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>goBack();</script>");

            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "back", "<script>back()</script>", true);
        }
        public bool aa()
        {
            return true;
        }
        //添加项目
        private bool AddProd(int id)
        {
            EtNet_BLL.ProductManager proBLL = new EtNet_BLL.ProductManager();
            EtNet_Models.Product proModel = new EtNet_Models.Product();

            proModel = proBLL.GetModel(id);

            proModel.Brief = hidHtml.Value;
            proModel.FlagMain = chkMain.Checked;
            proModel.ProdName = txtName.Value;
            proModel.Remark = txtMark.Value;
            try
            {

                return proBLL.Update(proModel);
            }
            catch
            {
                return false;
            }
        }
    }
}