using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Common
{
    public partial class PageSearchSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }

        }


        /// <summary>
        /// 取原有的数据
        /// </summary>
        private void GetData()
        {
            LoginInfo login = (LoginInfo)Session["login"];
            string pagenum = Request.QueryString["pagenum"].ToString();
            SearchPageSet pageset = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, Convert.ToInt32(pagenum));
            if (pageset == null)
            {
                this.tbxitem.Text = "";
                this.tbxcount.Text = "";
            }
            else
            {
                this.tbxcount.Text = pageset.Pagecount.ToString();
                this.tbxitem.Text = pageset.Pageitem.ToString();
            }

        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            LoginInfo login = (LoginInfo)Session["login"];
            string pagenum = Request.QueryString["pagenum"].ToString();
            SearchPageSet pageset = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, Convert.ToInt32(pagenum));
            SearchPageSet sps = new SearchPageSet();
            sps.Ownersid = ((LoginInfo)Session["login"]).Id;
            sps.Pagecount = Convert.ToInt32(this.tbxcount.Text.ToString());
            sps.Pageitem = Convert.ToInt32(this.tbxitem.Text.ToString());
            sps.Pagenum = pagenum;

            if (pageset == null)
            {
                int count = SearchPageSetManager.addSearchPageSet(sps);
                if (count > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "", true);
                }
            }
            else
            {
                sps.Id = pageset.Id;
                int count = SearchPageSetManager.updateSearchPageSet(sps);
                if (count > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "", true);
                }
            }


        }
    }
}