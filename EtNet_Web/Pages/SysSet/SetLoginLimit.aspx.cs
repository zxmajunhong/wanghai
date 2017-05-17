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
    public partial class SetLoginLimit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            if (!IsPostBack)
            {
                LoginInfo login = LoginInfoManager.getLoginInfoById(id);
                lblCurrentUser.Text = login.Cname.ToString();
            }
            DisplayUserLimit(id);
        }

        /// <summary>
        /// 初始化权限
        /// </summary>
        /// <param name="id"></param>
        private void DisplayUserLimit(int id)
        {
            IList<LoginUserLimit> currentUserParentNodes = LoginUserLimitManager.getParentNodesById(id);
            ArrayList arrUserParentNodes = new ArrayList();
            foreach (LoginUserLimit userLimit in currentUserParentNodes)
            {
                arrUserParentNodes.Add(userLimit.Nodeid.Nodeid.ToString());
            }

            IList<EtNet_Models.Menu> menus = EtNet_BLL.MenuManager.getAllParentNode();

            foreach (EtNet_Models.Menu menu in menus)
            {
                string nodeid = menu.Nodeid.ToString();

                string nodename = menu.Name.ToString();

                UserLimit userLimit = (UserLimit)LoadControl(@"UserLimit.ascx");

                HtmlInputHidden hidParentNode = (HtmlInputHidden)userLimit.FindControl("hidParentMenu");

                hidParentNode.Value = nodeid;

                HtmlInputHidden hidUser = (HtmlInputHidden)userLimit.FindControl("hidId");

                hidUser.Value = id.ToString();

                CheckBox chkParentMenu = (CheckBox)userLimit.FindControl("chkParentMenu");


                chkParentMenu.Text = nodename;

                if (arrUserParentNodes.Contains(nodeid))
                {
                    chkParentMenu.Checked = true;
                }

                this.phUserDistribute.Controls.Add(userLimit);
            }
        }

        /// <summary>
        /// 设置保存
        /// </summary>
        private void SaveLimit()
        {
            //获取ID
            int id = int.Parse(Request.QueryString["id"].ToString());
            IList<LoginUserLimit> currentUserLimit = LoginUserLimitManager.getAllNodeById(id);
            ArrayList arrUserNodes = new ArrayList();
            foreach (LoginUserLimit userLimit in currentUserLimit)
            {
                arrUserNodes.Add(userLimit.Nodeid.Nodeid.ToString());
            }


            foreach (Control ct in this.phUserDistribute.Controls)
            {
                CheckBox chk = (CheckBox)ct.FindControl("chkParentMenu");
                HtmlInputHidden hih = (HtmlInputHidden)ct.FindControl("hidParentMenu");

                if (chk.Checked)
                {
                    if (!arrUserNodes.Contains(hih.Value))
                    {
                        LoginUserLimitManager.InsertUserLimt(id.ToString(), hih.Value);
                    }
                }
                else
                {
                    if (arrUserNodes.Contains(hih.Value))
                    {
                        LoginUserLimitManager.DeleteUserLimit(id.ToString(), hih.Value);
                    }
                }


                CheckBoxList chklist = (CheckBoxList)ct.FindControl("chklstChildMenu");
                foreach (ListItem listItem in chklist.Items)
                {
                    if (listItem.Selected)
                    {
                        if (!arrUserNodes.Contains(listItem.Value))
                        {
                            LoginUserLimitManager.InsertUserLimt(id.ToString(), listItem.Value);
                        }
                    }
                    else
                    {
                        if (arrUserNodes.Contains(listItem.Value))
                        {
                            LoginUserLimitManager.DeleteUserLimit(id.ToString(), listItem.Value);
                        }
                    }
                }
            }
            Response.Write("<script>alert('权限下次登录时生效！！');self.document.location.href='LoginSet.aspx'</script>");
        }


        /// <summary>
        /// 提交信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            SaveLimit();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("LoginSet.aspx");
        }

    }
}