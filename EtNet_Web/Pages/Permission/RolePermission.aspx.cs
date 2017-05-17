using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using EtNet_BLL;
using System.Text;
using EtNet_Models;
using System.Collections;

namespace EtNet_Web.Pages.Permission
{
    public partial class RolePremission : System.Web.UI.Page
    {
        public string NodesData = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx", true);
            }
            LoginInfo login = new LoginInfo();
            login = Session["login"] as LoginInfo;
            object objRoleId = Request.QueryString["id"];
            int roleId = 0;
            if (int.TryParse(objRoleId == null ? null : objRoleId.ToString(), out roleId))
            {
                InitMenuTree(roleId);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('出错了！');self.location.href='../../Login.aspx'</script>");
            }
        }

        /// <summary>
        /// 点击保存按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, ImageClickEventArgs e)
        {
            SaveRolePremission();
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        private void SaveRolePremission()
        {
            List<MyTreeNode> menuList = HidMenu.Value == string.Empty ? null : ReadNode(HidMenu.Value);
            List<MyTreeNode> noMenuList = HidNoMenu.Value == string.Empty ? null : ReadNode(HidNoMenu.Value);

            int roleId = Convert.ToInt32(Request.QueryString["id"]);

            IList<LoginLimit> roleList = LoginLimitManager.getAllNodeByRoleId(roleId);

            ArrayList arrNodes = new ArrayList();
            foreach (LoginLimit roleLimit in roleList)
            {
                arrNodes.Add(roleLimit.Nodeid.ToString());
            }

            foreach (MyTreeNode mtn in menuList)
            {
                if (!arrNodes.Contains(mtn.Id.ToString()))
                {
                    LoginLimitManager.InsertLoginLimt(roleId.ToString(), mtn.Id.ToString());
                }
            }

            foreach (MyTreeNode mtn in noMenuList)
            {
                if (arrNodes.Contains(mtn.Id.ToString()))
                {
                    LoginLimitManager.DeleteLoginLimit(roleId.ToString(), mtn.Id.ToString());
                }
            }

            SetPersmissionByRole(menuList);

            Response.Redirect("../SysSet/RoleSet.aspx");
        }

        /// <summary>
        /// 同步角色下的用户权限
        /// </summary>
        /// <param name="menus">要同步的菜单权限</param>
        private void SetPersmissionByRole(List<MyTreeNode> menus)
        {
            int roleID = Convert.ToInt32(Request.QueryString["id"]);

            //角色下的用户ID，已“，”分隔
            string users= LoginDataLimitManager.GetUsersByRole(roleID);
            if (users != string.Empty)
            {
                string[] usersArr = users.Split(',');
                //删除用户权限
                for (int i = 0; i < usersArr.Length; i++)
                {
                    LoginUserLimitManager.DeleteLoginLimitByUser(int.Parse(usersArr[i]));
                }

                LoginUserLimit userLimit = new LoginUserLimit();
                //添加用户权限
                for (int i = 0; i < usersArr.Length; i++)
                {
                    for (int j = 0; j < menus.Count(); j++)
                    {
                        LoginUserLimitManager.InsertUserLimt(usersArr[i], menus[j].Id.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 加载菜单树
        /// </summary>
        /// <param name="loginId"></param>
        private void InitMenuTree(int loginId)
        {
            List<string> treenodes = new List<string>();

            IList<EtNet_Models.Menu> menus = MenuManager.getMenuAll();

            StringBuilder sbMenu = new StringBuilder();
            string[] menuArr = null;
            IList<LoginLimit> roleList = LoginLimitManager.getAllNodeByRoleId(loginId);
            if (roleList.Count > 0)
            {
                foreach (LoginLimit role in roleList)
                {
                    sbMenu.Append(role.Nodeid);
                    sbMenu.Append(",");
                }

                menuArr = sbMenu.ToString().TrimEnd(',').Split(',');
            }

            foreach (EtNet_Models.Menu menu in menus)
            {
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}', 'open':'false','checked':'{3}'}}",
                    menu.Nodeid, menu.Parentnodeid, menu.Name, menuArr == null ? false : (menuArr.Contains(menu.Nodeid.ToString())));
                treenodes.Add(node);
            }

            NodesData = string.Join(",", treenodes.ToArray());
        }

        /// <summary>
        /// 读取节点对象
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private List<MyTreeNode> ReadNode(string nodes)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string[] nodeArr = js.Deserialize(nodes, typeof(string[])) as string[];
            MyTreeNode mtn = new MyTreeNode();
            List<MyTreeNode> list = new List<MyTreeNode>();
            for (int i = 0; i < nodeArr.Count(); i++)
            {
                mtn = js.Deserialize<MyTreeNode>(nodeArr[i]);

                list.Add(mtn);
            }

            return list;
        }
    }
}