using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;
using EtNet_BLL.DataPage;

namespace EtNet_Web.Pages.Product
{
    public partial class TargetManager1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DdlTargetTypeBindData();
                HidNum.Value = GetNum(Convert.ToInt32(ddlTargetType.SelectedValue));
                RpPropertyBindData(Convert.ToInt32(ddlTargetType.SelectedValue));
            }
        }

        /// <summary>
        /// 绑定标的种类列表（repeater控件）
        /// </summary>
        private void DdlTargetTypeBindData()
        {
            TargetTypeManager targetType = new TargetTypeManager();
            DataTable data = targetType.GetAllList();

            ddlTargetType.DataTextField = "TypeName";
            ddlTargetType.DataValueField = "TargetTypeID";
            ddlTargetType.DataSource = data;
            ddlTargetType.DataBind();
        }

        /// <summary>
        /// 绑定标的属性列表（repeater控件）
        /// </summary>
        private void RpPropertyBindData(int targetTypeId)
        {
            TargetPropertyManager tpManager = new TargetPropertyManager();
            string where = string.Format("TargetTypeId = {0}", targetTypeId);
            AspNetPager1.RecordCount = tpManager.GetRecordCount(where);
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 011);
            if (sps != null)
            {
                AspNetPager1.PageSize = sps.Pageitem;
                AspNetPager1.NumericButtonCount = sps.Pagecount;
            }
            else
            {
                AspNetPager1.PageSize = 10;
                AspNetPager1.NumericButtonCount = 10;
            }
            rpTargetProperty.DataSource = tpManager.GetListByPage(where, "TargetTypeId", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            rpTargetProperty.DataBind();

        }

        private string GetNum(int id)
        {
            TargetTypeManager targetType = new TargetTypeManager();
            return targetType.GetModel(id).TypeNo;
        }

        private bool ExitsNum(string num)
        {
            TargetTypeManager targetType = new TargetTypeManager();
            DataTable dt = targetType.GetList(string.Format("TypeNo='{0}'", num));
            return dt.Rows.Count > 0 ? true : false;
        }

        protected void ddlTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RpPropertyBindData(Convert.ToInt32(ddlTargetType.SelectedValue));
            HidNum.Value = GetNum(Convert.ToInt32(ddlTargetType.SelectedValue));
        }

        /// <summary>
        /// 新增标的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            string url = string.Format("TargetEdit.aspx?action=new&typeid={0}", ddlTargetType.SelectedValue);
            Response.Redirect(url);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            RpPropertyBindData(Convert.ToInt32(ddlTargetType.SelectedValue));
        }

        protected void BtnSaveType_Click(object sender, ImageClickEventArgs e)
        {
            switch (HidCmdName.Value)
            {
                case "ADD":
                    AddType();
                    break;
                case "MODIFY":
                    UpdateType();
                    break;
                default:
                    break;
            }
        }

        private void UpdateType()
        {
            TargetTypeManager typeBLL = new TargetTypeManager();
            TargetType typeModel = new TargetType();

            typeModel.TypeName = txtTypeName.Text;
            typeModel.TypeNo = txtTypeNum.Text;
            typeModel.TargetTypeID = Convert.ToInt32(ddlTargetType.SelectedValue);

            if (!ExitsNum(txtTypeNum.Text))
            {
                if (typeBLL.Update(typeModel))
                    DdlTargetTypeBindData();
            }
        }

        /// <summary>
        /// 添加标的种类
        /// </summary>
        private void AddType()
        {
            TargetTypeManager typeBLL = new TargetTypeManager();
            TargetType typeModel = new TargetType();

            typeModel.TypeName = txtTypeName.Text;
            typeModel.TypeNo = txtTypeNum.Text;

            if (!ExitsNum(txtTypeNum.Text))
            {
                if (typeBLL.Add(typeModel))
                    DdlTargetTypeBindData();
            }
            else
            {
                txtTypeNum.Text = txtTypeName.Text = "";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('编号已存在')</script>");
            }
        }

        protected void BtnDelType_Click(object sender, ImageClickEventArgs e)
        {
            TargetTypeManager typeBLL = new TargetTypeManager();
            TargetPropertyManager tpBLL = new TargetPropertyManager();
            string where = string.Format("TargetTypeId = {0}", ddlTargetType.SelectedValue);
            if (tpBLL.GetList(where).Rows.Count > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('该分类下含有标的，不能删除')</script>");
            }
            else
            {
                typeBLL.Delete(Convert.ToInt32(ddlTargetType.SelectedValue));
                //tpBLL.Delete(Convert.ToInt32(ddlTargetType.SelectedValue));
                DdlTargetTypeBindData();
            }
        }

        protected void rpTargetProperty_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DEL")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                TargetPropertyManager tpBLL = new TargetPropertyManager();
                tpBLL.Delete(Convert.ToInt32(ddlTargetType.SelectedValue), id);
                RpPropertyBindData(Convert.ToInt32(ddlTargetType.SelectedValue));
            }
        }
    }
}