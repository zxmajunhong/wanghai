using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.Common
{
    public partial class FactAddType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAddType();
        }

        private void getAddType()
        {
            IList<FactType> com = FactTypeManager.getFactTypeAll();
            this.rpCusType.DataSource = com;
            this.rpCusType.DataBind();
        }

        protected void rpCusType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                string id = e.CommandArgument.ToString();

                IList<Factory> cop = FactoryManager.getFactoryType(Convert.ToInt32(id));

                if (cop.Count > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('正在使用中的类型不能删除！');", true);
                }
                else
                {
                    FactTypeManager.deleteFactType(Convert.ToInt32(id));
                }
            }
            getAddType();
        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {

            if (tbxTypeName.Text.ToString() == "")
            {
                this.lblTypename.Text = "<span style='Color:red'>类别名称不能为空！<span>";
            }
            else if (Checktypename(tbxTypeName.Text.ToString()) > 0)
            {
                this.lblTypename.Text = "<span style='Color:red'>类别名称已存在<span>";
            }
            else
            {

                FactType type = new FactType();
                type.TypeName = this.tbxTypeName.Text.ToString();
                type.Typeremark = this.tbxTypeRemark.Text.ToString();
                FactTypeManager.addFactType(type);
                getAddType();
                this.tbxTypeName.Text = "";
                this.lblTypename.Text = "";
            }

        }
        public int Checktypename(string typename)
        {
            int count = FactTypeManager.getFactTypeBytypename(typename);
            return count;
        }

    }
}