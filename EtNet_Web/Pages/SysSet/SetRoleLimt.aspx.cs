using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Collections;
using System.Web.UI.HtmlControls;

namespace Pages.SysSet
{
    public partial class SetRoleLimt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int roleId = int.Parse(Request["id"].ToString());//获得指定的角色id
            if (!IsPostBack)
            {
                RoleInfo role = RoleInfoManager.getRoleInfoById(roleId);
                lblCurrentRole.Text = role.Rolenname;
            }
            DisplayRoleRightInfo(roleId);//加载角色信息、    注意：加载角色信息的方法要放在IsPostBack之外
        }

        //加载角色信息
        protected void DisplayRoleRightInfo(int roleId)
        {
            IList<LoginLimit> currentRoleParentNodes = LoginLimitManager.GetParentNodesByRoleId(roleId);
            ArrayList arrRoleParentNodes = new ArrayList();
            foreach (LoginLimit loginLimit in currentRoleParentNodes)
            {
                arrRoleParentNodes.Add(loginLimit.Nodeid.ToString());
            }
            //得到所有父级节点信息
            IList<EtNet_Models.Menu> menus = EtNet_BLL.MenuManager.getAllParentNode();
            //根据父节点得到对应子节点,把父子节点生成用户控件,然后循环插入到PlaceHolder容器中
            foreach (EtNet_Models.Menu menu in menus)
            {
                //父节点ID
                string nodeid = menu.Nodeid.ToString();
                //父节点名称
                string nodename = menu.Name.ToString();
                //实例化用户控件
                RoleLimit rolelimit = (RoleLimit)LoadControl(@"RoleLimit.ascx");

                //实例化隐藏域用于存储父节点ID
                HtmlInputHidden hidParentNode = (HtmlInputHidden)rolelimit.FindControl("hidParentMenu");
                hidParentNode.Value = nodeid;
                //实例化隐藏域用于存储角色ID
                HtmlInputHidden hidRole = (HtmlInputHidden)rolelimit.FindControl("hidRoleId");
                hidRole.Value = roleId.ToString();

                //实例化空间CheckBox
                CheckBox chkParentMenu = (CheckBox)rolelimit.FindControl("chkParentMenu");

                //显示父节点名称
                chkParentMenu.Text = nodename;
                if (arrRoleParentNodes.Contains(nodeid))
                {
                    chkParentMenu.Checked = true;
                }
                //添加到用户控件
                phRoleDistribute.Controls.Add(rolelimit);
            }
        }

        /// <summary>
        /// 角色权限
        /// </summary>
        private void SaveRoleLimit()
        {
            //获取ID
            int roleid = int.Parse(Request.QueryString["id"].ToString());
            IList<LoginLimit> currentLoginLimit = LoginLimitManager.getAllNodeByRoleId(roleid);
            ArrayList arrRoleNodes = new ArrayList();
            foreach (LoginLimit loginLimit in currentLoginLimit)
            {
                arrRoleNodes.Add(loginLimit.Nodeid.ToString());
            }


            foreach (Control ct in this.phRoleDistribute.Controls)
            {
                CheckBox chk = (CheckBox)ct.FindControl("chkParentMenu");
                HtmlInputHidden hih = (HtmlInputHidden)ct.FindControl("hidParentMenu");

                if (chk.Checked)
                {
                    if (!arrRoleNodes.Contains(hih.Value))
                    {
                        LoginLimitManager.InsertLoginLimt(roleid.ToString(), hih.Value);
                    }
                }
                else
                {
                    if (arrRoleNodes.Contains(hih.Value))
                    {
                        LoginLimitManager.DeleteLoginLimit(roleid.ToString(), hih.Value);
                    }
                }


                CheckBoxList chklist = (CheckBoxList)ct.FindControl("chklstChildMenu");
                foreach (ListItem listItem in chklist.Items)
                {
                    if (listItem.Selected)
                    {
                        if (!arrRoleNodes.Contains(listItem.Value))
                        {
                            LoginLimitManager.InsertLoginLimt(roleid.ToString(), listItem.Value);
                        }
                    }
                    else
                    {
                        if (arrRoleNodes.Contains(listItem.Value))
                        {
                            LoginLimitManager.DeleteLoginLimit(roleid.ToString(), listItem.Value);
                        }
                    }
                }
            }
            Response.Write("<script>alert('权限下次登录时生效！！');self.document.location.href='RoleSet.aspx'</script>");
        }
        /// <summary>
        /// 确认提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            SaveRoleLimit();
        }

        /// <summary>
        /// 返回上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RoleSet.aspx");
        }
    }
}