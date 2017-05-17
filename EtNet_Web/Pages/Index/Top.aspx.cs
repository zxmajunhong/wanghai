using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using System.Data;

namespace EtNet_Web.Pages.Index
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((LoginInfo)Session["login"]).Loginid == "admin")
            {
                this.houtai.Visible = true; //如果是管理员，显示进入后台的接口
            }
            else
            {
                this.houtai.Visible = false; //不是就不显示
            }
           this.login.InnerText = "当前登录用户： " +((LoginInfo)Session["login"]).Cname;
           this.Page.DataBind();
        }


        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            Session["login"] = null;
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "exit", "<script>window.parent.location = '../../Login.aspx'</script>;", false);
        }

        protected void btnhoutai_Click(object sender, ImageClickEventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "houtai", "<script>window.parent.location = '../../CMS/index.aspx'</script>;", false);
        }


        /// <summary>
        /// 消息的循环周期
        /// </summary>
        public string InfoCycleSet()
        {
            string loginid = ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            string strsetsql = " createrid=" + loginid;
            DataTable tbl = EtNet_BLL.InitializeUserSetManager.GetList(strsetsql);  //获取用户参数
            int count = int.Parse(tbl.Rows[0]["infocycle"].ToString());
            if (count == 0)
            {
                count = 24 * 60 * 60 * 1000;
            }
            else
            {
                count = count * 60 * 1000;
            }
            return count.ToString();

        }

        
        /// <summary>
        /// 消息最大值
        /// </summary>
        public string MaxInfoId()
        {
            string result = "0";
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            string fields = " max(id) as maxid ";
            string str = " recipientid=" + login.Id.ToString();
            DataTable tbl = EtNet_BLL.ViewBLL.ViewInformationNoticeManager.getList(fields, str);
            if (tbl.Rows.Count != 0 && tbl.Rows[0]["maxid"].ToString() != "")
            {
                result = tbl.Rows[0]["maxid"].ToString();
            }
            return result;
        }


      
    }
}