using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using EtNet_BLL.DataPage;
using System.Data;

namespace Pages.SysSet
{
    public partial class LoginSet : System.Web.UI.Page
    {
        public static string str = ""; //筛选条件
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                str = "";
                bindData();

            }
        }


        /// <summary>
        /// 绑定
        /// </summary>
        private void bindData()
        {
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 027);

            if (sps == null)
            {
                EtNet_BLL.DataPage.Data data = new Data();
                DataSet ds = data.DataPage("LoginInfo", "id", "*", str, "loginid", false, 10, 10, pages);
                rploginUser.DataSource = ds;
                rploginUser.DataBind();
            }
            else
            {
                EtNet_BLL.DataPage.Data data = new Data();
                DataSet ds = data.DataPage("LoginInfo", "id", "*", str, "loginid", false, sps.Pageitem, sps.Pagecount, pages);
                rploginUser.DataSource = ds;
                rploginUser.DataBind();
            }
        }
        /// <summary>
        /// 绑定所在岗位
        /// </summary>
        public string ShowPostname(string postid)
        {
         
            int id = int.Parse(postid);
            string model = EtNet_BLL.DepartmentInfoManager.getPostname(id);
            return model;
        }
        /// <summary>
        /// 返回部门显示
        /// </summary>
        /// <param name="departid">部门的id值</param>
        public string ShowDepart(string departid)
        {
            string result = "";
            int id = int.Parse(departid);
            EtNet_Models.DepartmentInfo model =  EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(id);
            if (model != null)
            {
                result = model.Departcname;
            }
            return result;
        }



        /// <summary>
        /// repeater
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rploginUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Limit")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                //Response.Redirect("SetLoginLimit.aspx?id=" + id);
                Response.Redirect("../Permission/SetPermission.aspx?id=" + id);
            }

            //编辑
            if (e.CommandName == "Edit")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("ModifyLoginUser.aspx?id=" + id);
            }
            //删除
            if (e.CommandName == "Delete")
            {
                string id = e.CommandArgument.ToString();
                if (IfInAudit(Convert.ToInt32(id)))
                {
                    try
                    {

                        int del = LoginInfoManager.deleteLoginInfo(Convert.ToInt32(id));
                        if (del > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('删除成功！')", true);// 信息提示
                            DeleteUserPremission(Convert.ToInt32(id));
                            bindData();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('删除失败！请联系管理员！')", true);// 信息提示
                        }

                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('角色当前在使用，不能删除。')", true);// 信息提示
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('当前用户拥有审批权，请先删除相应审批流程。')", true);// 信息提示
                }

            }
        }



        private void DeleteUserPremission(int userId)
        {
            LoginDataLimit ldlModel = new LoginDataLimit();
            ldlModel.DataIds = "";
            ldlModel.LoginId = userId;
            //删除用户数据权限
            LoginDataLimitManager.Setlimit(ldlModel);
            //删除用户角色权限
            LoginUserLimitManager.DeleteLoginLimitByUser(userId);
        }


        private bool IfInAudit(int id)
        {
            DataTable rule = ApprovalRuleManager.GetList("");

            string inrule = ",";

            for (int i = 0; i < rule.Rows.Count; i++)
            {
                inrule += rule.Rows[i]["idgourp"].ToString() + ",";
            }

            if (inrule.IndexOf("," + id + ",") < 0)
            {
                return true;
            }
            return false;



        }

        /// <summary>
        /// 判断是否存在权限
        /// </summary>
        /// <returns></returns>
        private int LoginLimitIsEmpty(string Id)
        {
            LoginInfo login = LoginInfoManager.getLoginInfoById(Convert.ToInt32(Id));
            return LoginUserLimitManager.GetLimitCount(login.Id);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            str = "";
            ModifyQueryBuilder();
            bindData();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            if (this.Txtdlzh.Value.Trim() != "")
            {
                str += " and loginid = '" + this.Txtdlzh.Value.Trim() + "'";
            }
            if (this.Txtxm.Value.Trim() != "")
            {
                str += " and cname = '" + this.Txtxm.Value.Trim() + "'";
            }
            if (this.Txtssbm.Value.Trim() != "")
            {
                str += " and departid = " + getDepartid(this.Txtssbm.Value.Trim());
            }
            if (this.Txtszgw.Value.Trim() != "")
            {
                str += " and postid = " + getPostid(this.Txtszgw.Value.Trim());
            }
        }

        /// <summary>
        /// 查询重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click1(object sender, ImageClickEventArgs e)
        {
            this.Txtdlzh.Value = "";
            this.Txtxm.Value = "";
            this.Txtssbm.Value = "";
            this.Txtszgw.Value = "";
            str = "";
            bindData();
        }

        /// <summary>
        /// 根据部门名称得到部门ID
        /// </summary>
        /// <param name="departid">部门的id值</param>
        public int getDepartid(string departname)
        {
            EtNet_Models.DepartmentInfo model = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoBydepartcname(departname);
            if (model != null)
            {
                return model.Departid;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 根据岗位名称得到岗位ID
        /// </summary>
        /// <param name="departid">岗位的id值</param>
        public int getPostid(string postname)
        {
            int id = EtNet_BLL.DepartmentInfoManager.getPostid(postname);
            return id;
        }
    }
}