using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.SysSet
{
    public partial class AddLoginUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
           
                DepartBind();
                RoleBind();
                this.tbxPostid.Attributes.Add("ReadOnly", "true");
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


        protected void RoleBind()
        {
            //this.ddlRole.Items.Clear();
            //IList<EtNet_Models.RoleInfo> rolelist = EtNet_BLL.RoleInfoManager.getRoleInfoAll();//.getDepartmentInfoAll();
            //foreach (var item in rolelist)
            //{
            //    ListItem list = new ListItem(item.Rolenname, item.Roleid.ToString());
            //    this.ddlRole.Items.Add(list);
            //}
            //ListItem ltem = new ListItem("——选择角色——", "-1");//添加第一行默认值
            //this.ddlRole.Items.Insert(0, ltem);//添加第一行默认值
        }




        private void InsertIntoLoginLimit(int id, int roleid)
        {
            EtNet_BLL.LoginUserLimitManager.InsertLoginLimt(id, roleid);
        }



        /// <summary>
        /// 检验是否可以添加新用户
        /// </summary>
        private bool TestAdd()
        {
            string strsql = " loginid= '" + this.tbxLoginID.Text.Trim() + "' ";
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


        //添加登录用户 
        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (Save())
            {
                Response.Redirect("LoginSet.aspx");
            }
        }

        //添加登录用户不返回 
        protected void ibtnSaveAdd_Click(object sender, ImageClickEventArgs e)
        {
            Save();
            this.tbxLoginID.Text = "";
            this.tbxPWD.Text = "";
            this.tbxCname.Text = "";
            this.tbxEname.Text = "";
            this.tbxTel.Text = "";
            this.tbxFax.Text = "";
            this.tbxEmail.Text = "";
            this.tbxFirm.Text = "";
            this.hidfirm.Value = "";
            this.tbxPostid.Text = "";
        }


        /// <summary>
        /// 创建面板菜单的列数的记录
        /// </summary>
        private void PanelMenuRecord(int founderid, int totalcols)
        {
            EtNet_Models.PanelMenuRecord model = new EtNet_Models.PanelMenuRecord();
            model.founderid = founderid;
            model.totalcols = totalcols;
            model.userempty = "F";//面板条目不设置为    
            EtNet_BLL.PanelMenuRecordManager.Add(model);
        }


        /// <summary>
        /// 首次打开主页面板时创建的默认的条目
        /// </summary>
        private void FirstPanelItem(int founderid, string panel)
        {
            string strSql = " id in(" + panel + ")";
            DataTable tbl = EtNet_BLL.PanelMenuListManager.GetList(strSql);

            EtNet_Models.PanelMenu model = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                model = new EtNet_Models.PanelMenu();
                model.colsnum = 1;
                model.rowsnum = i + 1;
                model.title = tbl.Rows[i]["cname"].ToString();
                model.imageload = tbl.Rows[i]["imageload"].ToString();
                model.founderid = founderid;
                model.direction = tbl.Rows[i]["num"].ToString();
                EtNet_BLL.PanelMenuManager.Add(model);
            }
        }


        /// <summary>
        /// 创建用户的初始化参数
        /// </summary>
        /// <param name="ownersid">用户的id值</param>
        private void CreateInitializeData(int ownersid)
        {
            DataTable tbl = EtNet_BLL.InitializeSetManager.GetList(1, "", "id");
            if (tbl.Rows.Count == 1)
            {
                string strpagenum = "001,002,003,004,008,011,013,014,019,020,021,022,024,025,030,";
                strpagenum += "100,101,102,105,111,140,201";
                string[] list = strpagenum.Split(',');
                EtNet_Models.SearchPageSet model = null;
                for (int i = 0; i < list.Length; i++)
                {
                    model = new EtNet_Models.SearchPageSet();
                    model.Ownersid = ownersid;
                    model.Pagenum = list[i];
                    model.Pagecount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
                    model.Pageitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
                    EtNet_BLL.SearchPageSetManager.addSearchPageSet(model);
                }
    
                EtNet_Models.InitializeUserSet usermodel = new EtNet_Models.InitializeUserSet();
                usermodel.cname = tbl.Rows[0]["cname"].ToString();
                usermodel.createtime = DateTime.Now;
                usermodel.infocycle = int.Parse(tbl.Rows[0]["infocycle"].ToString());
                usermodel.inforemind = int.Parse(tbl.Rows[0]["inforemind"].ToString());
                usermodel.newinforemind = int.Parse(tbl.Rows[0]["newinforemind"].ToString());
                usermodel.pagecount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
                usermodel.pageitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
                usermodel.panelcols = int.Parse(tbl.Rows[0]["panelcols"].ToString());
                usermodel.panelcount = tbl.Rows[0]["panelcount"].ToString();
                usermodel.panellist = tbl.Rows[0]["panellist"].ToString();
                usermodel.panellistall = tbl.Rows[0]["panellistall"].ToString();
                usermodel.createrid = ownersid;
                EtNet_BLL.InitializeUserSetManager.Add(usermodel);
                PanelMenuRecord(ownersid, usermodel.panelcols);
                FirstPanelItem(ownersid, usermodel.panellist);
            }

        }






        private bool Save()
        {
            if (TestAdd())
            {
                EtNet_Models.LoginInfo loginInfo = new EtNet_Models.LoginInfo();
                loginInfo.Loginid = this.tbxLoginID.Text;
                loginInfo.Loginpwd = EtNet_BLL.CodeMD5.GetMD5(this.tbxPWD.Text.ToString());
                loginInfo.Cname = this.tbxCname.Text;
                loginInfo.Ename = this.tbxEname.Text;
                loginInfo.Tel = this.tbxTel.Text;
                loginInfo.Fax = this.tbxFax.Text;
                loginInfo.Email = this.tbxEmail.Text;
                loginInfo.Departid = int.Parse(this.ddlDepart.SelectedValue);

                loginInfo.Postid = Convert.ToInt32(this.hidPostid.Value); //Convert.ToInt32(EtNet_BLL.LoginInfoManager.getTo_PostByPostname(this.tbxPostid.Text));
                loginInfo.Roleid = 0;
                loginInfo.Firmidlist = this.hidfirm.Value;
                loginInfo.Firmtxtlist = this.tbxFirm.Text;
                loginInfo.orderRate = this.ddtc.Value == "" ? 0 : Convert.ToDouble(this.ddtc.Value);
            
                int count = EtNet_BLL.LoginInfoManager.addLoginInfo(loginInfo);

                int id = EtNet_BLL.LoginInfoManager.getLoginNewId();
                if (count > 0)
                {
                    CreateInitializeData(id);
                    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功!');window.location='LoginSet.aspx'</script>", false);
                    return true;
                }
                else
                {
                    this.tbxLoginID.Text = "";
                    this.tbxPWD.Text = "";
                    this.tbxCname.Text = "";
                    this.tbxEname.Text = "";
                    this.tbxTel.Text = "";
                    this.tbxFax.Text = "";
                    this.tbxEmail.Text = "";
                    this.tbxFirm.Text = "";
                    this.hidfirm.Value = "";
                    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败!');</script>", false);
                    return false;
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加失败,该用户已存在!');</script>", false);
                return false;
            }
        }


        //返回
        protected void ibtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("LoginSet.aspx");
        }
    }
}