using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_Models;

namespace EtNet_Web.Pages.Product
{
    public partial class ProTypeClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProTypeClassBindData();
                HidNum.Value = ddlProTypeClass.SelectedValue;
            }
        }

        private void ProTypeClassBindData()
        {
            ProdClassManager proClassBLL = new ProdClassManager();

            ddlProTypeClass.DataTextField = "ProdClassName";
            ddlProTypeClass.DataValueField = "ProdClassNo";
            ddlProTypeClass.DataSource = proClassBLL.GetAllList();
            ddlProTypeClass.DataBind();
        }

        private bool ExistNum(string num)
        {
            ProdClassManager proClassBLL = new ProdClassManager();
            DataTable data = proClassBLL.GetList(string.Format("ProdClassNo='{0}'", num));

            return data.Rows.Count > 0 ? true : false;
        }

        private void Save()
        {
            ProdClass proClass = new ProdClass();
            proClass.Prior = 0;//暂时无用
            proClass.ProdClassName = txtTypeName.Text;
            proClass.ProdClassNo = txtTypeNum.Text;
            proClass.ViewInReport = false;//暂时无用

            switch (HidCmdName.Value)
            {
                case "ADD":
                    AddType(proClass);
                    break;
                case "MODIFY":
                    UpdateType(proClass);
                    break;
                default:
                    break;
            }
        }

        private void UpdateType(ProdClass proClass)
        {
            ProdClassManager proClassBLL = new ProdClassManager();
            if (proClassBLL.Update(proClass))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('修改成功')</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('修改失败')</script>");
            }
        }

        private void AddType(ProdClass proClass)
        {
            if (ExistNum(txtTypeNum.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('编号已存在')</script>");
                return;
            }
            ProdClassManager proClassBLL = new ProdClassManager();
            if (proClassBLL.Add(proClass))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加成功')</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加失败')</script>");
            }
        }

        private void DeleteType(string num)
        {
            ProdClassManager proClassBLL = new ProdClassManager();
            if (proClassBLL.Delete(num))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('删除成功')</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('删除失败')</script>");
            }
        }

        protected void ddlProTypeClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            HidNum.Value = ddlProTypeClass.SelectedValue;
        }

        protected void BtnSaveType_Click(object sender, ImageClickEventArgs e)
        {
            Save();
            ProTypeClassBindData();
            HidNum.Value = ddlProTypeClass.SelectedValue;
            txtTypeName.Text = txtTypeNum.Text = "";
        }

        protected void BtnDelType_Click(object sender, ImageClickEventArgs e)
        {
            DeleteType(ddlProTypeClass.SelectedValue);
            ProTypeClassBindData();
            HidNum.Value = ddlProTypeClass.SelectedValue;
            txtTypeName.Text = txtTypeNum.Text = "";
        }
    }
}