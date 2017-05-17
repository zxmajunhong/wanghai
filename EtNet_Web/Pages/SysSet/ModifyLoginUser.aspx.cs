using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Pages.SysSet
{
    public partial class ModifyLoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.tbxPostid.Attributes.Add("ReadOnly", "true");
                DepartBind();
                LoadLoginData();
                LoadRule();
            }
        }

        protected void DepartBind()
        {
            this.ddlDepart.Items.Clear();
            IList<EtNet_Models.DepartmentInfo> departlist = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoAll();
            foreach (var item in departlist)
            {
                ListItem list = new ListItem(item.Departcname, item.Departid.ToString());
                this.ddlDepart.Items.Add(list);
            }
            ListItem ltem = new ListItem("——选择部门——", "-1");//添加第一行默认值
            this.ddlDepart.Items.Insert(0, ltem);//添加第一行默认值
        }

        private void LoadLoginData()
        {
            //this.tbxPWD.TextMode = TextBoxMode.Password;
            int id = int.Parse(Request.Params["id"]);
            hiddenid.Value = id.ToString();
            EtNet_Models.LoginInfo model = EtNet_BLL.LoginInfoManager.getLoginInfoById(id);
            if (model != null)
            {
                this.tbxCname.Text = model.Cname;
                this.tbxEname.Text = model.Ename;
                this.tbxLoginID.Text = model.Loginid;
                //this.tbxPWD.Attributes.Add("value",model.Loginpwd);
                this.ddlDepart.SelectedValue = model.Departid.ToString().Trim();
                //this.tbxrole.Text = RoleInfoManager.getRoleInfoById(model.Roleid).Rolenname.ToString();
                //this.tbxrole.Enabled = false;
                this.tbxEmail.Text = model.Email;
                this.tbxTel.Text = model.Tel;
                this.tbxFax.Text = model.Fax;
                this.tbxFirm.Text = model.Firmtxtlist;
                this.hidfirm.Value = model.Firmidlist;
                EtNet_Models.To_Post post = EtNet_BLL.To_PostManager.getTo_PostById(model.Postid);
                this.tbxPostid.Text = post.Postname;
                this.hidPostid.Value = post.Id.ToString();

                this.ddtc.Value = model.orderRate.ToString(); 
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", "<script>alert('加载失败!');window.location = 'LoginSet.aspx'</script>");

            }
        }

        /// <summary>
        /// 检验是否可以添加新用户
        /// </summary>
        private bool TestModify()
        {
            string id = Request.Params["id"].Trim();
            string strsql = " loginid= '" + this.tbxLoginID.Text.Trim() + "' AND id not in(" + id + ") ";
            System.Data.DataTable tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            if (tbl.Rows.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //修改
        protected void ibtnmodify_Click(object sender, ImageClickEventArgs e)
        {
            if (TestModify())
            {
                int id = int.Parse(Request.Params["id"]);
                EtNet_Models.LoginInfo loginInfo = EtNet_BLL.LoginInfoManager.getLoginInfoById(id);
                loginInfo.Loginid = this.tbxLoginID.Text;
                // loginInfo.Loginpwd = this.tbxPWD.Text;
                loginInfo.Cname = this.tbxCname.Text;
                loginInfo.Ename = this.tbxEname.Text;
                loginInfo.Tel = this.tbxTel.Text;
                loginInfo.Fax = this.tbxFax.Text;
                loginInfo.Email = this.tbxEmail.Text;
                loginInfo.Departid = Convert.ToInt32(this.ddlDepart.SelectedValue);
                loginInfo.Firmtxtlist = this.tbxFirm.Text;
                loginInfo.Firmidlist = this.hidfirm.Value;

                loginInfo.Postid = Convert.ToInt32(this.hidPostid.Value);

                loginInfo.orderRate = this.ddtc.Value == "" ? 0 : Convert.ToDouble(this.ddtc.Value);

                int count = EtNet_BLL.LoginInfoManager.updateLoginInfo(loginInfo);
                if (count > 0)
                {
                    Session["login"] = loginInfo;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改成功!');window.location='LoginSet.aspx'</script>", false);
                }
                else
                {
                    this.tbxLoginID.Text = "";
                    //  this.tbxPWD.Text = "";
                    this.tbxCname.Text = "";
                    this.tbxEname.Text = "";
                    this.tbxTel.Text = "";
                    this.tbxFax.Text = "";
                    this.tbxEmail.Text = "";
                    this.tbxFirm.Text = "";
                    this.hidfirm.Value = "";
                    this.tbxPostid.Text = "";
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改失败!');</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('修改失败,登录用户名已存在!');</script>", false);
            }
        }

        //返回
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("LoginSet.aspx");
        }

        //重置
        protected void ibtnreset_Click(object sender, ImageClickEventArgs e)
        {
            LoadLoginData();
        }


        /// <summary>
        /// 加载用户拥有的审核规则
        /// </summary>
        private void LoadRule()
        {
            string id = Request.Params["id"];
            string strsql = " ',' + idgourp + ',' like '%," + id + ",%' ";
            DataTable tbl = EtNet_BLL.ApprovalRuleManager.GetList(strsql);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                row = new HtmlTableRow();

                cell = new HtmlTableCell();
                cell.InnerText = tbl.Rows[i]["cname"].ToString();
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerText = tbl.Rows[i]["txt"].ToString();
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerText = tbl.Rows[i]["sort"].ToString();
                row.Cells.Add(cell);

                this.rule.Rows.Add(row);

            }

        }


    }
}