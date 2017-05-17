using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.AusItem
{
    public partial class DepartMoneyList : System.Web.UI.Page
    {
        string sqlstr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                string itemname = Request.QueryString["itemname"];
                this.hiditem.Value = itemname;
                PageSymbolNum();
                QueryBuilder();
                Session["query"] += " and itemname='" + itemname + "'";
                this.biaoti.InnerText = itemname + "金额预算";
                LoadMoney();
            }
        }

        /// <summary>
        /// 页面数字标识
        /// </summary>
        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = ""; //如无PageNum，先生成一个
            }
            if (Session["PageNum"].ToString() != "030")
            {
                Session["PageNum"] = "030";
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
            }
            if (Session["query"].ToString() != "")
            {
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='030'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "030";
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

        /// <summary>
        /// 加载金额预算信息
        /// </summary>
        private void LoadMoney()
        {
            decimal zje = 0; //总金额
            decimal zyzf = 0; //总已支付金额
            decimal zkzf = 0; //总可支付金额
            this.pages.Visible = true;
            DataTable tbl = Exists();
            sqlstr += Session["query"].ToString();
            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet set = data.DataPage("DepartMoney", "ID", "*", sqlstr, "ID", true, pitem, pcount, pages);
            this.moneylist.DataSource = set;
            this.moneylist.DataBind();

            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                zje += set.Tables[0].Rows[i]["amount"].ToString() == "" ? 0 : Convert.ToDecimal(set.Tables[0].Rows[i]["amount"]); //累加总金额
                zyzf += set.Tables[0].Rows[i]["haspay"].ToString() == "" ? 0 : Convert.ToDecimal(set.Tables[0].Rows[i]["haspay"]); //累加总可支付金额
            }
            zkzf = zje - zyzf;
            this.zzje.Text = zje.ToString("0.00");
            this.zyzf.Text = zyzf.ToString("0.00");
            this.zkzf.Text = zkzf.ToString("0.00");
        }

        /// <summary>
        /// 编辑删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void moneylist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            string itemname = Request.QueryString["itemname"];
            switch (e.CommandName)
            {
                case "Update":
                    Response.Redirect("UpdateAusMoney.aspx?id=" + id + "&itemname=" + itemname);
                    break;
                case "Delete":
                    bool del = AusMoneyManager.Delete(Convert.ToInt32(id));
                    if (del)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('删除成功');window.location='DepartMoneyList.aspx?itemname=" + this.hiditem.Value + "';</script>", false);
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "add", "<script>alert('删除失败')</script>", true);
                    }
                    break;
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void back_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AusItemList.aspx");
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
                return canpay.ToString("0.00");
            }
            catch (Exception e)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "except", "<script>alter('" + e.Message + "');</script>", true);
                return "";
            }
        }
    }
}