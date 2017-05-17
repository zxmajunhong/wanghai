using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Invoice
{
    public partial class IncoiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("../../Login.aspx");
                }
                else
                {
                    QueryBuilder();
                    PageSymbolNum();
                    bindDatasource();
                }
            }

        }



        private void bindDatasource()
        {
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
            {
                sqlstr += " and invoiceCMan = " + login.Id;

            }
            else
            {
                sqlstr += " and invoiceCMan in (" + ids + "," + login.Id + ")";
            }
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 016);

            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("to_Invoice", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
                rpInvoice.DataSource = ds;
                rpInvoice.DataBind();
            }
            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("to_Invoice", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                rpInvoice.DataSource = ds;
                rpInvoice.DataBind();
            }

        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {

        }

        public string CName(int id)
        {
            LoginInfo cname = LoginInfoManager.getLoginInfoById(id);
            return cname.Cname.ToString();
        }

        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddInvoice.aspx");
        }

        /// <summary>
        /// 保存数据列表
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
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
            if (Session["PageNum"].ToString() != "016")
            {
                Session["PageNum"] = "016";
                Session["query"] = "";
            }
        }

        protected void rpInvoice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string id = e.CommandArgument.ToString();

            //参数数组，0：单据ID，1：是否确认
            string[] cmdArgs = e.CommandArgument.ToString().Split(',');

            //表示单据是否已确认
            bool confirmReceipt = false;
            if (cmdArgs.Length > 1)
            {
                confirmReceipt = cmdArgs[1] == "1";
            }

            string msg = "";

            switch (e.CommandName)
            {
                case "Delete":
                    if (confirmReceipt)
                    {
                        msg = "已确认发票不能删除";
                        break;
                    }
                    To_InvoiceManager.deleteTo_Invoice(Convert.ToInt32(cmdArgs[0]));
                    bindDatasource();
                    break;
                case "Update":
                    if (confirmReceipt)
                    {
                        msg = "已确认发票不能修改";
                        break;
                    }
                    Response.Redirect("UpdateInvoice.aspx?id=" + cmdArgs[0]);
                    break;
                case "Detial":
                    Response.Redirect("InvoiceInfo.aspx?id=" + cmdArgs[0]);
                    break;

                case "CANCEL":
                    To_InvoiceManager.CancelIsSure(Convert.ToInt32(cmdArgs[0]));
                    bindDatasource();
                    break;
                default:
                    break;
            }


            if (msg != string.Empty)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", string.Format("alert('{0}');", msg), true);
            }
        }

        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            bindDatasource();
            Session["query"] = "";
        }


        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string invoID = this.txtInvoiceID.Value.ToString();
            string invoType = this.ddlType.SelectedValue.ToString();
            string invoUnit = this.txtUnit.Value.ToString();
            string price = this.txtPrice.Value.ToString();
            string beginTime = this.txtBeginDate.Value.ToString();
            string endTime = this.txtEndDate.Value.ToString();

            string sqlstring = "";

            if (invoID != "")
            {
                sqlstring += " and invoiceID like '%" + invoID + "%'";
            }
            if (invoType != "-1")
            {
                sqlstring += " and invoiceType like '%" + invoType + "%'";
            }
            if (invoUnit != "")
            {
                sqlstring += " and invoiceUnit like '%" + invoUnit + "%'";
            }
            if (price != "")
            {
                sqlstring += " and sum like '%" + price + "%'";
            }
            if (beginTime != "" & endTime != "")
            {
                sqlstring += " and invoiceDate between '" + beginTime + "' and '" + endTime + "'";
            }
            Session["query"] = sqlstring;
        }

        protected void mgbtnreset_Click1(object sender, ImageClickEventArgs e)
        {
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
            {
                sqlstr += " and invoiceCMan = " + login.Id;

            }
            else
            {
                sqlstr += " and invoiceCMan in (" + ids + "," + login.Id + ")";
            }
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 016);
            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("to_Invoice", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
                rpInvoice.DataSource = ds;
                rpInvoice.DataBind();
            }
            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("to_Invoice", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                rpInvoice.DataSource = ds;
                rpInvoice.DataBind();
            }


            this.txtBeginDate.Value = ""; this.txtEndDate.Value = ""; this.txtInvoiceID.Value = ""; this.txtPrice.Value = ""; this.txtUnit.Value = "";
        }


        public static string changeTime(string str)
        {
            string time = str.Substring(0, Convert.ToInt32(str.IndexOf(" ")));
            return time;
        }

        //判断是否自己的记录
        public bool IsSelf(object id)
        {
            LoginInfo login = Session["login"] as LoginInfo;
            if (login != null)
            {
                return id.Equals(login.Id);
            }
            else
            {
                return false;
            }
        }

    }
}