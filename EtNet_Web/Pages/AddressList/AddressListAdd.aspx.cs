using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace Pages.AddressList
{
    public partial class AddressListAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartList();
                LoadStaffList();
            }
        }
        /// <summary>
        /// 加载部门列表数据
        /// </summary>
        private void LoadDepartList()
        {
            //IList<EtNet_Models.DepartmentInfo> list = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoAll();
            //this.ddldepart.DataTextField = "departcname";
            //this.ddldepart.DataValueField = "departid";

            //ListItem ltem = new ListItem("请选择", "-1");//添加第一行默认值
            //this.ddldepart.Items.Insert(0, ltem);//添加第一行默认值

            //this.ddldepart.DataSource = list;
            //this.ddldepart.DataBind();


            this.ddldepart.Items.Clear();
            IList<EtNet_Models.DepartmentInfo> typelist = DepartmentInfoManager.getDepartmentInfoAll();
            foreach (var item in typelist)
            {
                ListItem list = new ListItem(item.Departcname, item.Departid.ToString());
                this.ddldepart.Items.Add(list);
            }
            ListItem ltem = new ListItem("选择部门", "-1");//添加第一行默认值
            this.ddldepart.Items.Insert(0, ltem);//添加第一行默认值



        }

        /// <summary>
        /// 加载员工人员列表数据
        /// </summary>
        private void LoadStaffList()
        {
            string strsql = "id not in(select staffid from AddressListInfo where linkstaff =1)";
            DataTable tbl = EtNet_BLL.StaffInfoManager.GetList(strsql);
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["cname"] = "——请选择——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlstaff.DataSource = tbl;
            this.ddlstaff.DataTextField = "cname";
            this.ddlstaff.DataValueField = "id";
            this.ddlstaff.DataBind();
        }

        protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlstaff.SelectedIndex != 0)
            {
                LoadSatff(int.Parse(this.ddlstaff.SelectedValue));
            }
            else
            {
                ResetContent();
            }
        }

        /// <summary>
        /// 加载指定的员工资料
        /// </summary>
        private void LoadSatff(int staffid)
        {
            EtNet_Models.StaffInfo model = EtNet_BLL.StaffInfoManager.GetModel(staffid);
            if (model == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "show", "<script>alert('加载失败，该用户可能已删除')</script>");
                LoadStaffList();
                ResetContent();

            }
            else
            {
                this.iptcname.Value = model.cname;
                this.iptename.Value = model.ename;
                this.iptposition.Value = model.positiontxt;
                this.radsex.SelectedValue = model.sex;
                this.iptphone.Value = model.phone;
                this.iptcellphone.Value = model.cellphone;
                this.ddldepart.SelectedValue = model.departid.ToString();
                if (model.mailbox != "" && model.mailbox.IndexOf(',') != -1)
                {
                    this.iptmailtxt.Value = model.mailbox.Split(',')[0];
                }
                else
                {
                    this.iptmailtxt.Value = "";
                }
                this.trearemark.Value = model.remark;
            }

        }

        /// <summary>
        /// 重置
        /// </summary>
        private void ResetContent()
        {
            this.iptcname.Value = "";
            this.iptename.Value = "";
            this.iptmailtxt.Value = "";
            this.iptphone.Value = "";
            this.iptcellphone.Value = "";
            this.iptposition.Value = "";
            this.iptscellphone.Value = "";
            this.radsex.SelectedValue = "男";

        }

        //检测是否可以添加
        private bool TestAdd()
        {
            bool isadd = true;
            if (this.ddlstaff.SelectedIndex != 0)
            {
                int staffid = int.Parse(this.ddlstaff.SelectedValue);
                string strsql = " staffid=" + staffid;
                DataTable tbl = EtNet_BLL.AddressListInfoManager.GetList(strsql);
                if (tbl.Rows.Count != 0)
                {
                    isadd = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "show", "<script>alert('该员工已添加通讯录');</script>");
                }
                else
                {
                    EtNet_Models.StaffInfo model = EtNet_BLL.StaffInfoManager.GetModel(staffid);
                    if (model == null)
                    {
                        isadd = false;
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "show", "<script>alert('该员工已删除，无法添加通讯录')</script>");
                        LoadStaffList();
                        ResetContent();
                    }
                }
            }
            return isadd;
        }


        //保存
        private void Save()
        {
            if (TestAdd())
            {
                EtNet_Models.AddressListInfo model = new EtNet_Models.AddressListInfo();
                model.cname = this.iptcname.Value;
                model.ename = this.iptename.Value;
                model.createtime = DateTime.Now;
                model.departid = int.Parse(this.ddldepart.SelectedValue);
                model.cellphone = this.iptcellphone.Value;
                model.scellphone = this.iptscellphone.Value;         
                model.founder = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                model.positiontxt = this.iptposition.Value;
                model.mailbox = this.iptmailtxt.Value;
                model.phone = this.iptphone.Value;
                model.sex = this.radsex.SelectedValue;
                model.remark = Server.UrlDecode(this.trearemark.Value);
                if (this.ddlstaff.SelectedIndex == 0)
                {
                    model.linkstaff = 0;
                    model.staffid = 0;
                }
                else
                {
                    model.linkstaff = 1;
                    model.staffid = int.Parse(this.ddlstaff.SelectedValue);
                }
                if (EtNet_BLL.AddressListInfoManager.Add(model))
                {
                    EtNet_Models.StaffInfo staff = EtNet_BLL.StaffInfoManager.GetModel(int.Parse(this.ddlstaff.SelectedValue));
                    if (staff != null)
                    {
                        staff.cname = this.iptcname.Value;
                        staff.ename = this.iptename.Value;
                        staff.positiontxt = this.iptposition.Value;
                        staff.sex = this.radsex.SelectedValue;
                        staff.phone = this.iptphone.Value;
                        staff.cellphone = this.iptcellphone.Value;
                        staff.departid = int.Parse(this.ddldepart.SelectedValue);
                        staff.mailbox = this.iptmailtxt.Value;
                        staff.remark = Server.UrlDecode(this.trearemark.Value);
                        EtNet_BLL.StaffInfoManager.Update(staff);
                    }
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('添加成功');window.location='AddressListShow.aspx';</script>", false);
                }
            }
        }

        //保存添加通讯录
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            Save();
        }

        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddressListShow.aspx");
        }
    }
}