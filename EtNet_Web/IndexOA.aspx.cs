using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Web.Security;
using System.Configuration;
using System.Text;
using System.Data;

namespace EtNet_Web
{
    public partial class IndexOA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userLogin();
            }
        }

        protected void userLogin()
        {
            string userId = Request.QueryString["uid"]; //账号
            string pwd = Request.QueryString["pwd"]; //密码
            string mtype = Request.QueryString["mtype"]; //消息类型

            LoginInfo login = LoginInfoManager.Login(userId, pwd);

            if (login != null)
            {
                if (LoginLimitIsEmpty() > 0)
                {
                    Session["login"] = login;
                    //switch (mtype)
                    //{
                    //    case "个人消息":
                    //        this.mainFrame.Attributes["src"] = "Pages/Information/ReceiveInformationShow.aspx";
                    //        break;
                    //    case "报销申请":
                    //        this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                    //        break;
                    //    case "客户审核消息":
                    //        this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                    //        break;
                    //    case "保单审核消息":
                    //        this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                    //        break;
                    //    case "公告审核消息":
                    //        this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                    //        break;
                    //    case "公告消息":
                    //        this.mainFrame.Attributes["src"] = "Pages/Announcement/AnnouncementSearch.aspx";
                    //        break;
                    //    default:
                    //        this.mainFrame.Attributes["src"] = "Pages/Index/Welcome.aspx";
                    //        break;
                    //}
                    Session["messageType"] = mtype;
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('当前用户没有设置使用权限,请与系统管理员联系！');location.href='Login.aspx';</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "error", "alert('当前用户不存在，请重新确认登录！');location.href='Login.aspx';</script>", false);
            }
        }

        /// <summary>
        /// 检测是否有权限查看数据
        /// </summary>
        /// <returns></returns>
        private int LoginLimitIsEmpty()
        {
            string userId = Request.QueryString["uid"];
            LoginInfo login = LoginInfoManager.getLoginInfoByLoginID(userId);
            return LoginUserLimitManager.GetLimitCount(login.Id);
        }

        /// <summary>
        /// 检测是否有用户登录
        /// </summary>
        /// <returns></returns>
        private bool LoginIsEmpty()
        {
            if (Session["login"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}