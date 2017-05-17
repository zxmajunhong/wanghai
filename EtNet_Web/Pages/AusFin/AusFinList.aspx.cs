using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL.DataPage;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.AusFin
{
    public partial class AusFinList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void dataBind()
        {
            DataTable strtbl = Exists();
            int ptiem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new Data();
            DataSet ds = data.DataPage("AusFinInfo", "id", "*", "", "id", true, ptiem, pcount, pages);
            cuslist.DataSource = ds;
            cuslist.DataBind();
        }


        /// <summary>
        /// 检验页面设置是否存在
        /// </summary>
        /// <returns></returns>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='024'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "024";
                pageset.Pagecount = 10;
                pageset.Pageitem = 10;


                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }

        //编辑删除
        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Update":
                    Response.Redirect("UpdateAusFin.aspx?id=" + id);
                    break;
                case "Delete":
                    bool del = AusFinInfoManager.Delete(Convert.ToInt32(id));
                    if (del == true)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('删除成功');window.location='AusFinList.aspx'</script>", false);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('删除失败')</script>", true);
                    }
                    break;
            }
        }
    }
}