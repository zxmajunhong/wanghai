using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages.SysSet
{
    public partial class ModifyDepart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartData();
            }
        }


        //加载部门数据
        private void LoadDepartData()
        {
            int departid = int.Parse(Request.Params["id"]);
            EtNet_Models.DepartmentInfo model = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(departid);
            if (model != null)
            {
                this.iptcname.Value = model.Departcname;
                this.iptename.Value = model.Departename;
                this.autocode.Value = model.AutoCode;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modload", "<script>alert('加载失败')</script>", false);
                this.imgbtnmodify.Enabled = false;
            }
        }

        //返回部门显示页面
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowDepart.aspx");
        }



        //检验是否可以修改，如中文名已存在不能添加
        //private bool TestModIfy()
        //{
        //    string strsql = " departcname= '" + this.iptcname.Value.Trim() + "' ";
        //    IList<EtNet_Models.DepartmentInfo> list = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoAll();
        //    if (list.Count == 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}




        //修改
        protected void imgbtnmodify_Click(object sender, ImageClickEventArgs e)
        {
            //if (TestModIfy())
            //{
            int departid = int.Parse(Request.Params["id"]);
            EtNet_Models.DepartmentInfo model = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(departid);
            if (model != null)
            {
                model.Departcname = this.iptcname.Value.Trim();
                model.Departename = this.iptename.Value.Trim();
                model.AutoCode = this.autocode.Value.Trim();
                int result = EtNet_BLL.DepartmentInfoManager.updateDepartmentInfo(model);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('修改成功');window.location='ShowDepart.aspx'</script>", false);
            }
            //}
            //else
            //{
            // Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('修改失败,该部门已存在')</script>", false);
            //}
            LoadDepartData();
        }
    }
}