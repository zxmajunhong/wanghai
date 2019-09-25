using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Common
{
    public partial class PostAddType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAddPost();
        }

        private void getAddPost()
        {
            IList<To_Post> post = To_PostManager.getTo_PostAll();
            this.rpPost.DataSource = post;
            this.rpPost.DataBind();
        }

        protected void rpPost_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                string id = e.CommandArgument.ToString();

                int Count = LoginInfoManager.getTo_PostByid(Convert.ToInt32(id));

                if (Count > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('正在使用中的岗位不能删除！');", true);
                }
                else
                {
                    LoginInfoManager.deleteTo_PostById(Convert.ToInt32(id));
                }
            }
            getAddPost();
        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {

            if (tbxTypeName.Text.ToString() =="")
            {
                this.lblTypename.Text = "<span style='Color:red'>岗位名称不能为空！<span>";
            }else if (Checktypename(tbxTypeName.Text.ToString()) > 0)
            {
                this.lblTypename.Text = "<span style='Color:red'>岗位名称已存在<span>";
            }
            else
            {

                To_Post post = new To_Post();
                post.Postname = this.tbxTypeName.Text.ToString();

                To_PostManager.addTo_Post(post);
                getAddPost();
                this.tbxTypeName.Text ="";
                this.lblTypename.Text = "";
            }
            
        }
        public int Checktypename(string postname)
        {
            int count = To_PostManager.getLoginInfoByPostname(postname);
            return count;
        }

    }
}