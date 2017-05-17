using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using EtNet_Models;
using EtNet_BLL;

namespace Pages.Message
{
    public partial class AddNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindtreeview();
                binddropdown();
                checkUser();
                if (Session["login"] == null)
                {
                    Response.Redirect("../../Login.aspx");
                    LoginInfo login = (LoginInfo)Session["login"];
                }
            }
        }


        //绑定TreeView
        protected void bindtreeview()
        {
            IList<DepartmentInfo> Depart = DepartmentInfoManager.getDepartmentInfoAll();

            foreach (DepartmentInfo dept in Depart)
            {
                TreeNode node = new TreeNode(dept.Departcname, dept.Departid.ToString());
                node.SelectAction = TreeNodeSelectAction.Expand;
                IList<LoginInfo> list = LoginInfoManager.getLoginInfoByDeptId(dept.Departid);
                foreach (LoginInfo user in list)
                {
                    TreeNode usernode = new TreeNode(user.Cname, user.Id.ToString());
                    node.ChildNodes.Add(usernode);
                }
                this.tvuser.Nodes.Add(node);
            }

        }

        //绑定公告分类
        protected void binddropdown()
        {
            this.ddlSor.Items.Clear();
            IList<SortInfo> sortlist = SortInfoManager.getSortInfoAll();
            foreach (var item in sortlist)
            {
                ListItem list = new ListItem(item.Sortname, item.Sortid.ToString());
                this.ddlSor.Items.Add(list);
            }
            ListItem ltem = new ListItem("选择类型", "-1");//添加第一行默认值
            this.ddlSor.Items.Insert(0, ltem);//添加第一行默认值

        }
        /// <summary>
        /// 添加
        /// </summary>
        private void AddMNew()
        {
            LoginInfo login = (LoginInfo)Session["login"];
            NoticeInfo notice = new NoticeInfo();
            notice.Title = this.txtTitle.Text.ToString();
            notice.Begintime = DateTime.Parse(this.txtBegin.Text.ToString());
            notice.Endtime = DateTime.Parse(this.txtEnd.Text.ToString());
            notice.Context =   Request.Form["content"].ToString();
            notice.Fromuser = login.Cname.ToString();
            notice.Accressory = null;
            notice.Sortid = new SortInfo() { Sortid = int.Parse(this.ddlSor.SelectedValue) };
            notice.Accressory = this.FileUrl.ToString();
            if (this.rbtn1.Checked)
            {
                notice.Attribute = 0;
            }
            else
            {
                notice.Attribute = 1;
            }



            if (rbAll.Checked)
            {
                notice.Ifpublic = 0;
            }
            else
            {
                notice.Ifpublic = 1;
            }


            int conut = NoticeInfoManager.addNoticeInfo(notice);
            string strSql = "select top 1 *  from NoticeInfo  order by noticeid desc";
            int maxid = 0;
            EtNet_Models.NoticeInfo model = EtNet_BLL.NoticeInfoManager.getNoticeInfoBySql(strSql);
            if (model != null)
            {
                maxid = model.Noticeid;
                EtNet_Models.NoticeShare modelshare = null;
                for (int i = 0; i < this.lbToUser.Items.Count; i++)
                {
                    modelshare = new NoticeShare();
                    modelshare.acceptid = int.Parse(this.lbToUser.Items[i].Value);
                    modelshare.noticeid = maxid;
                    EtNet_BLL.NoticeShareManager.Add(modelshare);
                }

            }




            if (conut > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');location.href='../Message/Notice.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('添加失败！')", true);
            }
        }


        //选择发送范围
        protected void checkUser()
        {

            //if (this.rbAll.Checked == true)
            //{
            //    this.tvuser.Visible = false;
            //    this.lbToUser.Visible = false;
            //    this.ibntToUser.Visible = false;
            //}
            //else
            //{
            //    this.tvuser.Visible = true;
            //    this.lbToUser.Visible = true;
            //    this.ibntToUser.Visible = true;
            //}
            this.lbToUser.Visible = this.ibntToUser.Visible = this.btnDelSelect.Visible = this.tvuser.Visible = !this.rbAll.Checked;
        }


        /// <summary>
        /// 复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rbClick(object sender, EventArgs e)
        {
            checkUser();
        }

        //添加人员按钮显示隐藏
        protected void ibntToUser_Click(object sender, ImageClickEventArgs e)
        {
            if (tvuser.Visible)
            {
                this.tvuser.Visible = false;
            }
            else
            {
                this.tvuser.Visible = true;
            }
        }



        //添加分类信息
        protected void btnAddType_Click(object sender, EventArgs e)
        {

            if (btnAddType.Text.ToString() == "新增")
            {
                this.btnAddType.Text = "添加";
                this.txtSort.Visible = true;
                this.btnNo.Visible = true;
            }
            else
            {

                SortInfo sort = new SortInfo();
                if (txtSort.Text.ToString() != "")
                {
                    sort.Sortname = this.txtSort.Text.ToString();
                    int count = SortInfoManager.addSortInfo(sort);
                    if (count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "key", "alert('添加成功！')", true);
                        binddropdown();
                        this.txtSort.Visible = false;
                        this.btnAddType.Text = "新增";
                        this.btnNo.Visible = false;
                    }
                    else
                    {

                    }
                }
            }

        }

        //取消按钮
        protected void btnNo_Click(object sender, EventArgs e)
        {
            this.btnNo.Visible = false;
            this.txtSort.Visible = false;
            this.btnAddType.Text = "新增";
        }


        //选择人员
        protected void tvuser_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = tvuser.SelectedNode;
            LoginInfo user = LoginInfoManager.getLoginInfoById(Convert.ToInt32(tvuser.SelectedValue));
            if (user.Id.ToString() == node.Value)
            {
                string count = node.Parent.Text + "-" + node.Text;
                string loginid = node.Value;
                foreach (ListItem item in this.lbToUser.Items)
                {
                    if (item.Text.Equals(count))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您已经添加该预约人！');</script>");
                        return;
                    }
                }

                ListItem items = new ListItem();
                items.Text = count;
                items.Value = node.Value;
                this.lbToUser.Items.Add(items);
            }
        }
        
        
        //上传按钮提交
        protected void btnUpload_Click(object sender, EventArgs e)
        {

            upFile();
            //UpLoad();
        }
        

        /// <summary>
        /// 上传方法
        /// </summary>
        protected void upFile()
        {
            string saveUrl = "../../UploadFile/Message/";
            string filename = FileUpload1.FileName;
            string fileExt = Path.GetExtension(filename).ToLower();
            if (String.IsNullOrEmpty(fileExt))
            {
                Response.Write("<script>alert('上传失败');</script>");
            }
            else
            {
                string newFile = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                FileUpload1.SaveAs(HttpContext.Current.Server.MapPath(saveUrl + newFile));
                ViewState["FileUrl"] = saveUrl + newFile;
                Response.Write("<script>alert('上传成功');</script>");
            }

        }


        //删除选中的人员
        protected void btnDelSelect_Click(object sender, EventArgs e)
        {
            int count = lbToUser.Items.Count;
            if (lbToUser.Items.Count != 0)
            {
                int index = 0;
                if (lbToUser.Items[index].Selected == true)
                {
                    ListItem item = lbToUser.Items[index];
                    lbToUser.Items.Remove(item);
                }
            }

        }


        //文件路径
        public string FileUrl
        {
            get { return  ViewState["FileUrl"] != null ? ViewState["FileUrl"].ToString():""; }
            set { ViewState["FileUrl"] = value; }
        }


        //重置数据
        private void resert()
        {
            this.txtTitle.Text = "";
            this.txtSort.Text = "";
            this.txtBegin.Text = "";
            this.txtEnd.Text = "";
            this.ddlSor.SelectedIndex = 0;
            this.rbtn1.Checked = true;
            this.rbtn2.Checked = false;
            this.rbAll.Checked = true;
            this.rbToUser.Checked = false;
            this.tvuser.Visible = false;            
            this.lbToUser.Items.Clear();
            this.content.Value = "";

        }

        protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AddMNew();
        }

        protected void ibtnNew_Click(object sender, ImageClickEventArgs e)
        {
            resert();
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Notice.aspx");
        }





    }
}