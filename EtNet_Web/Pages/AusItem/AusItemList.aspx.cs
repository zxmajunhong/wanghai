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

namespace EtNet_Web.Pages.AusItem
{
    public partial class AusItemList : System.Web.UI.Page
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
            DataSet ds = data.DataPage("View_ItemMoney", "id", "*", "", "id", true, ptiem, pcount, pages);
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
            strsql += " AND pagenum='022'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "022";
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
            
            switch (e.CommandName)
            {
                case "Update":
                    string id = e.CommandArgument.ToString();
                    Response.Redirect("UpdateAusItem.aspx?id=" + id);
                    break;
                case "Delete":
                    string ID = e.CommandArgument.ToString();
                    bool del = AusItemInfoManager.Delete(Convert.ToInt32(ID));
                    if (del == true)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('删除成功');window.location='AusItemList.aspx'</script>", false);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('删除失败')</script>", true);
                    }
                    break;
                case "money":
                    string itemname = e.CommandArgument.ToString();
                    Response.Redirect("DepartMoneyList.aspx?itemname=" + itemname);
                    break;
            }
        }

        /// <summary>
        /// 得到可支付金额
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="has"></param>
        /// <returns></returns>
        public string canpay(string sum, string has)
        {
            decimal amount;
            decimal haspay;
            decimal canpay;
            try
            {
                amount = sum == "" ? 0 : Convert.ToDecimal(sum);
                haspay = has == "" ? 0 : Convert.ToDecimal(has);
                canpay = amount - haspay;
                if (canpay == 0)
                {
                    return "";
                }
                else
                {
                    return canpay.ToString("0.00");
                }
            }
            catch (Exception e)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "except", "<script>alter('" + e.Message + "');</script>", true);
                return "";
            }
        }

        /// <summary>
        /// 得到两位小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string two(string str)
        {
            try
            {
                if (str != "")
                {
                    return String.Format("{0:F}", Convert.ToDouble(str));
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "except", "<script>alter('" + e.Message + "');</script>", true);
                return "";
            }
        }
    }
}