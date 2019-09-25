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

namespace EtNet_Web.Pages.AusType
{
    public partial class AusTypeList : System.Web.UI.Page
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
            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new Data();
            DataSet ds = data.DataPage("AusTypeInfo", "id", "*", "", "id", true, pitem, pcount, pages);
            cuslist.DataSource = ds;
            cuslist.DataBind();
        }
        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='023'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "023";
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
      

        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Delete":
                    AusTypeInfo typeInfo = AusTypeInfoManager.getAusTypesById(Convert.ToInt32(id));
                    string typeName=typeInfo.typename;
                    int count = AusDetialInfoManager.getAusDetialInfoByAusType(typeName);
                    if (count>0)
                    {
                        
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('费用类别正在使用中，无法删除！');", true);
                    }
                    else
                    {
                       bool del= AusTypeInfoManager.Delete(Convert.ToInt32(id));
                       if (del == true)
                       {
                           Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('删除成功');window.location='AusTypeList.aspx'</script>", false);
                       }
                       else
                       {
                           Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('删除失败')</script>", true);
                       }
                    }
                    break;

                case "Update":
                    Response.Redirect("UpdateAusType.aspx?id=" + id);
                    break;
                case "Tick":
                    AusTypeInfo typeInfo1 = AusTypeInfoManager.getAusTypesById(Convert.ToInt32(id));
                    typeInfo1.iscy = "y";
                    AusTypeInfoManager.Update(typeInfo1);
                    break;
                case "TurnBack":
                    AusTypeInfo typeInfo2 = AusTypeInfoManager.getAusTypesById(Convert.ToInt32(id));
                    typeInfo2.iscy = "n";
                    AusTypeInfoManager.Update(typeInfo2);
                    break;
            }
            dataBind();
        }

        /// <summary>
        /// 是否常用(常用)
        /// </summary>
        public bool isCy1(string id)
        {
            AusTypeInfo typeInfo = AusTypeInfoManager.getAusTypesById(Convert.ToInt32(id));
            if (typeInfo.iscy == "n" || typeInfo.iscy == "" || typeInfo.iscy == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 是否常用(不常用)
        /// </summary>
        public bool isCy2(string id)
        {
            AusTypeInfo typeInfo = AusTypeInfoManager.getAusTypesById(Convert.ToInt32(id));
            if (typeInfo.iscy == "y")
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