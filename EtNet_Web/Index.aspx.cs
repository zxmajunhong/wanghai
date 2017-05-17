using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtNet_Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (Session["messageType"] != null)
                    {
                        switch (Session["messageType"].ToString())
                        {
                            case "个人消息":
                                this.mainFrame.Attributes["src"] = "Pages/Information/ReceiveInformationShow.aspx";
                                break;
                            case "报销申请":
                                this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                                break;
                            case "客户审核消息":
                                this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                                break;
                            case "保单审核消息":
                                this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                                break;
                            case "公告审核消息":
                                this.mainFrame.Attributes["src"] = "Pages/Job/AuditJobFlow.aspx";
                                break;
                            case "公告消息":
                                this.mainFrame.Attributes["src"] = "Pages/Announcement/AnnouncementSearch.aspx";
                                break;
                            default:
                                this.mainFrame.Attributes["src"] = "Pages/Index/Welcome.aspx";
                                break;
                        }
                        Session["messageType"] = null;
                    }
                }
            }
        }

    }
}