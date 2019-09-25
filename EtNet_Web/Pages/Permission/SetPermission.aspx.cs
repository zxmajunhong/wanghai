using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Web.Script.Serialization;
using System.Text;
using System.Collections;


namespace EtNet_Web.Pages.Permission
{
    public partial class SetPermission : System.Web.UI.Page
    {
        public string NodesData = "";
        public string NodesMenu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            object loginId = Request.QueryString["id"];
            int id = 0;
            if (loginId != null && int.TryParse(loginId.ToString(), out id) && Convert.ToInt32(loginId) > 0)
            {
                if (!IsPostBack)
                {
                    InitDataTree(Convert.ToInt32(loginId));
                    InitMenuTree(Convert.ToInt32(loginId));
                    InitDdlRoleList(Convert.ToInt32(loginId));

                    ltrUserInfo.Text = string.Format("<font color='red'>{0}</font>", LoginInfoManager.getLoginInfoById(Convert.ToInt32(loginId)).Cname);
                }
            }
        }

        private void InitDdlRoleList(int loginId)
        {
            IList<RoleInfo> roleList = RoleInfoManager.getRoleInfoAll();
            RoleInfo role = new RoleInfo();
            role.Roleid = 0;
            role.Rolenname = "自定义";
            role.Remark = "";
            roleList.Insert(0, role);

            DdlRoleList.DataTextField = "rolenname";
            DdlRoleList.DataValueField = "roleid";
            DdlRoleList.DataSource = roleList;
            DdlRoleList.DataBind();

            string roleId = LoginDataLimitManager.GetRoleId(loginId);

            DdlRoleList.SelectedIndex = DdlRoleList.Items.IndexOf(DdlRoleList.Items.FindByValue(roleId));
        }

        private void InitDataTree(int loginId)
        {
            List<string> treenodes = new List<string>();

            IList<DepartmentInfo> departmentList = DepartmentInfoManager.getDepartmentInfoAll();
            //IList<DepartmentInfo> departmentList = DepartmentInfoManager.getDepartmentInfoAllById(loginId);


            foreach (DepartmentInfo deparment in departmentList)
            {
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}', 'open':'true','halfCheck':'false','isParent':'true','icon':'../../images/public/folder_user.gif'}}",
                                       "dp" + deparment.Departid, 0, deparment.Departcname);
                treenodes.Add(node);
            }

            IList<LoginInfo> loginList = LoginInfoManager.getLoginInfoAll();

            string ids = "," + LoginDataLimitManager.GetLimit(loginId) + ",";

            foreach (LoginInfo login in loginList)
            {
                string node = string.Format("{{ 'id':'{0}', 'pId':'{1}', 'name':'{2}', 'checked':'{3}','icon':'../../images/public/group.gif'}}",
                    login.Id, "dp" + login.Departid, login.Cname, ids.IndexOf("," + login.Id.ToString() + ",") < 0 ? false : true);
                treenodes.Add(node);
            }

            NodesData = string.Join(",", treenodes.ToArray());
        }

        private void InitMenuTree(int loginId)
        {

            List<string> treenodes = new List<string>();

            IList<EtNet_Models.Menu> menus = MenuManager.getMenuAll();
            //IList<EtNet_Models.Menu> menus = MenuManager.getMenuAllbyID(loginId);
            StringBuilder sbMenu = new StringBuilder();
            string[] menuArr = null;
            IList<LoginUserLimit> lulList = LoginUserLimitManager.getAllNodeById(loginId);
            if (lulList.Count > 0)
            {
                foreach (LoginUserLimit lul in lulList)
                {
                    sbMenu.Append(lul.Nodeid.Nodeid);
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

            NodesMenu = string.Join(",", treenodes.ToArray());
        }

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

        protected void BtnSave_Click(object sender, ImageClickEventArgs e)
        {
            List<MyTreeNode> dataList = HidData.Value == string.Empty ? null : ReadNode(HidData.Value);
            List<MyTreeNode> menuList = HidMenu.Value == string.Empty ? null : ReadNode(HidMenu.Value);
            List<MyTreeNode> noMenuList = HidNoMenu.Value == string.Empty ? null : ReadNode(HidNoMenu.Value);

            object loginId = Request.QueryString["id"];
            int id = 0;
            if (loginId == null || !int.TryParse(loginId.ToString(), out id) || Convert.ToInt32(loginId) <= 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('参数错误')</script>");
                return;
            }
            LoginDataLimit ldl = new LoginDataLimit();
            if (dataList == null)
            {
                ldl.DataIds = string.Empty;
            }
            else
            {
                StringBuilder dataIds = new StringBuilder();
                foreach (MyTreeNode node in dataList)
                {
                    if (!node.IsParent)
                    {
                        dataIds.Append(node.Id);
                        dataIds.Append(",");
                    }
                }

                ldl.DataIds = dataIds.ToString().TrimEnd(',');
            }
            ldl.LoginId = Convert.ToInt32(loginId);
            ldl.RoleId = int.Parse(DdlRoleList.SelectedValue);

            if (LoginDataLimitManager.Setlimit(ldl))
            {
                InitDataTree(Convert.ToInt32(loginId));
            }

            IList<LoginUserLimit> lulList = LoginUserLimitManager.getAllNodeById(Convert.ToInt32(loginId));

            ArrayList arrNodes = new ArrayList();
            foreach (LoginUserLimit userLimit in lulList)
            {
                arrNodes.Add(userLimit.Nodeid.Nodeid.ToString());
            }

            foreach (MyTreeNode mtn in menuList)
            {
                if (!arrNodes.Contains(mtn.Id.ToString()))
                {
                    LoginUserLimitManager.InsertUserLimt(loginId.ToString(), mtn.Id.ToString());
                }
            }

            foreach (MyTreeNode mtn in noMenuList)
            {
                if (arrNodes.Contains(mtn.Id.ToString()))
                {
                    LoginUserLimitManager.DeleteUserLimit(loginId.ToString(), mtn.Id.ToString());
                }
            }

            InitMenuTree(Convert.ToInt32(loginId));


            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存成功');self.location.href='../SysSet/LoginSet.aspx'</script>");

        }

        protected void DdlRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void SetDefault()
        {
            List<string> treenodes = new List<string>();
            LoginInfo login = Session["login"] as LoginInfo;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (int.Parse(DdlRoleList.SelectedValue) == 0)
            {
                InitDataTree(id);
                InitMenuTree(id);
                return;
            }

            IList<EtNet_Models.Menu> menus = MenuManager.getMenuAll();

            StringBuilder sbMenu = new StringBuilder();
            string[] menuArr = null;
            int roleId = int.Parse(DdlRoleList.SelectedValue);
            IList<LoginLimit> loginList = LoginLimitManager.getAllNodeByRoleId(roleId);
            if (loginList.Count > 0)
            {
                foreach (LoginLimit lul in loginList)
                {
                    sbMenu.Append(lul.Nodeid);
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

            NodesMenu = string.Join(",", treenodes.ToArray());


            InitDataTree(Convert.ToInt32(Request.QueryString["id"]));

        }

    }

    public class MyTreeNode
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            set;
            get;
        }

        public bool IsParent
        {
            get;
            set;
        }
    }
}