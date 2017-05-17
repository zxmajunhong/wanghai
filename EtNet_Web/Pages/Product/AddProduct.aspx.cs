using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace EtNet_Web.Pages.Product
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object typeid = Request.QueryString["typeid"];
            if (typeid == null || typeid.ToString() == string.Empty)
                return;
            EtNet_BLL.ProductTypeManager proType = new EtNet_BLL.ProductTypeManager();
            txtType.Value = proType.GetModel(typeid.ToString()).ProdTypeName;
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            object typeid = Request.QueryString["typeid"];
            if (typeid == null || typeid.ToString() == string.Empty)
                return;
            AddProd(typeid.ToString());
            
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>goBack();</script>");

        }

        //添加项目
        private bool AddProd(string typeID)
        {
            EtNet_BLL.ProductManager proBLL = new EtNet_BLL.ProductManager();
            EtNet_Models.Product proModel = new EtNet_Models.Product();

            proModel.Brief = hidHtml.Value;
            proModel.FlagMain = chkMain.Checked;
            proModel.ProdName = txtName.Value;
            proModel.ProdNo = MakeNum(typeID);
            proModel.ProdTypeID = typeID;
            proModel.Remark = txtMark.Value;
            try
            {
                if (proBLL.Add(proModel) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        private bool ExitsNum(string num)
        {
            EtNet_BLL.ProductManager productTypeBLL = new EtNet_BLL.ProductManager();
            DataTable dt = productTypeBLL.GetList(string.Format("ProdNo = '{0}'", num));
            return dt.Rows.Count > 0 ? true : false;
        }

        private string MakeNum(string typeID)
        {

            StringBuilder num = new StringBuilder();
            for (int i = 1; i < 1000; i++)
            {
                num.Append(typeID);
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
    }
}