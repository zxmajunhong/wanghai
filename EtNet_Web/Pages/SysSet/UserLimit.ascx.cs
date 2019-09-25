using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using EtNet_BLL;
using EtNet_Models;

namespace Pages.SysSet
{
    public partial class UserLimit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayUserLimitMenu();//显示角色权限菜单
            }
        }

        private void DisplayUserLimitMenu()
        {
            //得到父节点Id
            int nodeid = int.Parse(hidParentMenu.Value);
            //得到当前角色Id
            int id = int.Parse(hidId.Value);

            ArrayList arrUserChildMenu = new ArrayList();
            //根据角色Id和父节点Id得到RoleRight表中已经存在的子菜单信息\
            IList<EtNet_Models.LoginUserLimit> UserChildLimit = LoginUserLimitManager.GetUserLimitByIdAndParentNodeId(id, nodeid);
            foreach (LoginUserLimit userLimit in UserChildLimit)
            {
                arrUserChildMenu.Add(userLimit.Nodeid.Nodeid.ToString());
            }
            //根据父节点Id得到对应的所有子节点信息
            IList<EtNet_Models.Menu> menus = MenuManager.getMenuByParentId(nodeid);

            //将子节点循环追加到CheckBoxList控件中
            foreach (EtNet_Models.Menu menu in menus)
            {
                ListItem list = new ListItem();
                list.Value = menu.Nodeid.ToString();
                list.Text = menu.Name.ToString();
                if (arrUserChildMenu.Contains(list.Value))
                {
                    list.Selected = true;
                }
                chklstChildMenu.Items.Add(list);
            }
        }
    }
}