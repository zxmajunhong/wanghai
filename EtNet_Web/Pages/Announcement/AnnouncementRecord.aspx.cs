using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Announcement
{
    public partial class AnnouncementRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAnnouncementList();
            }
        }


        //加载文档列表
        private void LoadAnnouncementList()
        {
            if (Request.Params["id"] != null && Request.Params["id"] != "")
            {
                string strsql = " AND announcementcode=" + Request.Params["id"];
                int pitem = 5;
                int pcount = 10;

                EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
                DataSet set = data.DataPage("ViewAnnouncementLog", "id", "*", strsql, "id", true, pitem, pcount, pages);
                this.rptrecord.DataSource = set;
                this.rptrecord.DataBind();

            }
        }

    }
}