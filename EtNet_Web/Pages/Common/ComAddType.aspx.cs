using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Collections;

namespace EtNet_Web.Pages.Common
{
    public partial class ComAddType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getType();
        }

        private void getType()
        {
            IList<ComType> com = ComTypeManager.getComTypeAll();
            this.type.DataSource = com;
            this.type.DataBind();
        }

        protected void type_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                string id = e.CommandArgument.ToString();

                IList<Company> cop = CompanyManager.getCompanyType(Convert.ToInt32(id));

                if (cop.Count > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('正在使用中的类型不能删除！');", true);
                }
                else
                {
                    ComTypeManager.deleteComType(Convert.ToInt32(id));
                }
            }
            getType();
        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {


          
            if (tbxTypeName.Text.ToString() == "")
            {
                this.lblTypename.Text = "<span style='Color:red'>类别名称不能为空！<span>";
            }else if (CheckTypeName(tbxTypeName.Text.ToString()) > 0)
            {
                this.lblTypename.Text = "<span style='Color:red'>类别名称已存在<span>";
            }
            else
            {
                if (CheckTypeName(tbxTypeName.Text.ToString())>0)
                {
                    //Response.Write("<script language=javascript>alert( '类别名称已存在！');window.location.href='ComAddType.aspx';</script>");
                    this.lblTypename.Text = "<span style='color:red'>类别名称已存在！</span>";
                }
                else
                {
                    ComType type = new ComType();
                    type.TypeName = this.tbxTypeName.Text.ToString();
                    type.Typeremark = this.tbxTypeRemark.Text.ToString();
                    ComTypeManager.addComType(type);
                    getType();
                    this.tbxTypeName.Text = "";
                    this.lblTypename.Text = "";
                }
                
            }


            
        }

        private int  CheckTypeName(string typename)
        {
            int count = ComTypeManager.getComTypeByTypename(typename);
            return count;
        }
    }
}