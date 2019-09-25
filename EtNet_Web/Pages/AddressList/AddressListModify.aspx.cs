using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;

namespace Pages.AddressList
{
    public partial class AddressListModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartList();
                LoadAddressListData();
            }
        }



        /// <summary>
        /// 加载部门列表数据
        /// </summary>
        private void LoadDepartList()
        {
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
        /// 加载通讯录数据
        /// </summary>
        private void LoadAddressListData()
        {
            int id = int.Parse(Request.Params["id"]);
            EtNet_Models.AddressListInfo model = EtNet_BLL.AddressListInfoManager.GetModel(id);
            if (model != null)
            {
                this.iptcname.Value = model.cname;
                this.iptename.Value = model.ename;
                this.iptposition.Value = model.positiontxt;
                this.radsex.SelectedValue = model.sex;
                this.iptphone.Value = model.phone;
                this.iptcellphone.Value = model.cellphone;
                this.iptscellphone.Value = model.scellphone;
                this.ddldepart.SelectedValue = model.departid.ToString();
                this.iptmailtxt.Value = model.mailbox.Split(',')[0];
               
                this.trearemark.Value = model.remark;           
            }
            else
            {
                string str = "<script>alert('加载出错');window.location='AddressListShow.aspx';</script>";
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "load",str,false );
            }
         
        }



        /// <summary>
        /// 修改通讯录关联的员工
        /// </summary>
        private bool ModifyStaff(int staffid)
        {     
            EtNet_Models.StaffInfo staff = EtNet_BLL.StaffInfoManager.GetModel(staffid);
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
                return EtNet_BLL.StaffInfoManager.Update(staff);

            }
            else
            {
                return false;
            }
        }
      


       
        //修改
        private void Modify()
        {
            string str = "";
            int id = int.Parse(Request.Params["id"]);
            EtNet_Models.AddressListInfo model = EtNet_BLL.AddressListInfoManager.GetModel(id);
            if (model != null)
            {
                model.cname = this.iptcname.Value;
                model.ename = this.iptename.Value;
                model.positiontxt = this.iptposition.Value;
                model.sex = this.radsex.SelectedValue;
                model.phone = this.iptphone.Value;
                model.cellphone = this.iptcellphone.Value;
                model.scellphone = this.iptscellphone.Value;
                model.departid = int.Parse(this.ddldepart.SelectedValue);
                model.mailbox = this.iptmailtxt.Value;
                model.remark = Server.UrlDecode(this.trearemark.Value);
                if (model.linkstaff == 1)
                {
                     if(!ModifyStaff(model.staffid))
                     {
                        model.linkstaff = 0;
                        model.staffid = 0;
                     }             
                }
                if (EtNet_BLL.AddressListInfoManager.Update(model))
                {
                    str = "<script>alert('修改成功');window.location='AddressListShow.aspx';</script>";
                }
                else
                {
                    str = "<script>alert('修改失败');window.location='AddressListShow.aspx';</script>";
                }
                       
            }
            else
            {
                str = "<script>alert('修改失败,该通讯录已删除');window.location='AddressListShow.aspx';</script>";
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "modify", str, false);
        }




        //保存修改
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            Modify();
        }


        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddressListShow.aspx");
        }
    }
}