using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;

namespace Pages.Message
{
    public partial class Detial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //主要是先进了这里  然后就没有userId了  
                if (Request.QueryString["NoticeId"] != null)//判断是否是第一次加载
                {
                    int id = int.Parse(Request.QueryString["NoticeId"]);
                    NoticeInfo notice = NoticeInfoManager.getNoticeInfoById(id);

                    this.lblTitle.Text = notice.Title.ToString();
                    this.lblCreateMan.Text = notice.Fromuser.ToString();
                    this.lblBegin.Text = notice.Begintime.ToString();
                    this.lblEnd.Text = notice.Endtime.ToString();
                    this.lblContent.Text = notice.Context.ToString();
                    

                }
            }
            

        }
    }
}