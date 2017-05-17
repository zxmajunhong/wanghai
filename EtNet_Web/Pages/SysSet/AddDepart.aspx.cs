using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pages.SysSet
{
    public partial class AddDepart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //返回部门显示页面
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowDepart.aspx");
        }



        //检验是否可以添加，如中文名已存在不能添加
        private bool TestAdd()
        {
            string strsql = " departcname= '" + this.iptcname.Value.Trim() + "' ";
            IList<EtNet_Models.DepartmentInfo> list = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoAll();
            if (list.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //添加部门
        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {

            EtNet_Models.DepartmentInfo model = new EtNet_Models.DepartmentInfo();
            model.Departcname = this.iptcname.Value.Trim();
            model.Departename = this.iptename.Value.Trim();
            model.AutoCode = this.autocode.Value.Trim();
            int result = EtNet_BLL.DepartmentInfoManager.addDepartmentInfo(model);
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功');window.location='ShowDepart.aspx'</script>", false);


            this.iptcname.Value = "";
            this.iptename.Value = "";
        }

        //添加部门不返回
        protected void imgbtnSaveadd_Click(object sender, ImageClickEventArgs e)
        {

            EtNet_Models.DepartmentInfo model = new EtNet_Models.DepartmentInfo();
            model.Departcname = this.iptcname.Value.Trim();
            model.Departename = this.iptename.Value.Trim();
            model.AutoCode = this.autocode.Value.Trim();
            int result = EtNet_BLL.DepartmentInfoManager.addDepartmentInfo(model);
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功')'</script>", false);


            this.iptcname.Value = "";
            this.iptename.Value = "";
        }
    }
}