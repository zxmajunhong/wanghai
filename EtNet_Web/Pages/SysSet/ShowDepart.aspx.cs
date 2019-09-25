using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL.DataPage;
using System.Data;

namespace Pages.SysSet
{
    public partial class ShowDepart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindDepartData();
                }
            }
        }




        //绑定部门列表数据
        private void BindDepartData()
        {
            IList<EtNet_Models.DepartmentInfo> list = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoAll();
            this.rptdepartdata.DataSource = list;
            this.rptdepartdata.DataBind();
        }

        //导航到新增部门页面
        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddDepart.aspx");
        }


        //删除部门是检验是否有相关的员工或登录用户与之相关联
        private bool DelDepartTset(int departid)
        {
            bool result = true;
            string strsql = "";
            strsql += " departid=" + departid;
            DataTable tbl = EtNet_BLL.StaffInfoManager.GetList(strsql);
            if (tbl.Rows.Count != 0)
            {
                result = false;
            }
            tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            if (tbl.Rows.Count != 0)
            {
                result = false;
            }
            return result;
        }


        protected void rptdepartdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "showuser":
                    Response.Redirect("DepartUsers.aspx?id=" + id.ToString());
                    break;

                case "edit":
                    Response.Redirect("ModifyDepart.aspx?id=" + id.ToString());
                    break;
                case "del":
                    if (DelDepartTset(id))
                    {
                        EtNet_BLL.DepartmentInfoManager.deleteDepartmentInfo(id);
                        BindDepartData();
                    }
                    else
                    {
                        string delstr = "<script>alert('删除失败！原因:有与该部门相关联的用户或员工资料')</script>";
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", delstr, false);
                    }
                    break;
            }
        }
    }
}