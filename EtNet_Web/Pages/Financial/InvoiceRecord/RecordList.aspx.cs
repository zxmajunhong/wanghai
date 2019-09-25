using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;
using System.Text;

namespace EtNet_Web.Pages.Financial.InvoiceRecord
{
    public partial class RecordList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMakeMan();
                QueryBuilder();
                PageSymbolNum();
                LoadInvoiceRecordList();
            }
        }

        /// <summary>
        /// 绑定登记人
        /// </summary>
        public void BindMakeMan()
        {
            ddlMakeMan.Items.Clear();
            ddlMakeMan.Items.Add(new ListItem("——请选择——", "0"));
            IList<LoginInfo> list = LoginInfoManager.getLoginInfoAll();
            foreach (LoginInfo l in list)
            {
                ListItem adItem = new ListItem();
                adItem.Text = l.Cname;
                adItem.Value = l.Id.ToString();
                ddlMakeMan.Items.Add(adItem);
            }
        }

        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = "";
            }
            if (Session["PageNum"].ToString() != "032")
            {
                Session["PageNum"] = "032";
                Session["query"] = "";
            }
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

        ///// <summary>
        ///// 加载收款单位
        ///// </summary>
        //private void LoadColUnit()
        //{
        //    this.collectUnit.Items.Clear();
        //    this.collectUnit.Items.Add(new ListItem("——请选择——", "0"));
        //    IList<Customer> customers = CustomerManager.getCustomerAll();
        //    foreach (Customer customer in customers)
        //    {
        //        ListItem adItem = new ListItem();
        //        adItem.Value = customer.Id.ToString();
        //        adItem.Text = customer.CusshortName;
        //        this.collectUnit.Items.Add(adItem);
        //    }
        //}

        /// <summary>
        /// 加载订单数据
        /// </summary>
        private void LoadInvoiceRecordList()
        {
            LoginInfo login = Session["login"] as LoginInfo;
            string sql = " ";
            sql += Session["query"];
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            AspNetPager1.RecordCount = data.GetCount("InvoiceRecord", sql);
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 032);
            if (sps == null)
            {
                AspNetPager1.NumericButtonCount = 5;
                AspNetPager1.PageSize = 5;
            }
            else
            {
                AspNetPager1.NumericButtonCount = sps.Pagecount;
                AspNetPager1.PageSize = sps.Pageitem;
            }
            DataTable dt = data.GetList("InvoiceRecord", "makeDate", "asc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sql);
            this.payRepeater.DataSource = dt;
            this.payRepeater.DataBind();
        }

        /// <summary>
        /// 开票登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgread_Click(object sender, ImageClickEventArgs e)
        {
            string conid = "";
            //先遍历取得选中项
            for (int i = 0; i < this.payRepeater.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)payRepeater.Items[i].FindControl("cbx");
                Label lbl = (Label)payRepeater.Items[i].FindControl("lbl");
                if (cbx != null || lbl != null)
                {
                    if (cbx.Checked)
                    {
                        conid += lbl.Text + ",";
                    }
                }
            }
            //去掉最后一个，
            conid = (conid + ")").Replace(",)", "");

            Response.Redirect("Record.aspx?id=" + conid);
        }

        /// <summary> 
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadInvoiceRecordList();
        }

        protected void payRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "edit":
                    Response.Redirect("EditRecord.aspx?Id=" + Id);
                    break;
                case "search":
                    Response.Redirect("SearchRecord.aspx?Id=" + Id);
                    break;
                case "del":
                    Del(Id);
                    break;
            }

            LoadInvoiceRecordList();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id"></param>
        public void Del(string Id)
        {
            bool result = InvoiceRecordManager.Del(Id);
            InvoiceRecordDetailManager.DeleteByInoviceId(int.Parse(Id));
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();
            if (this.txtUnit.Value != "")
            {
                sqlstr.Append(" and cusName like '%" + txtUnit.Value.Trim() + "%' ");
            }
            if (ddlMakeMan.SelectedIndex != 0)
            {
                sqlstr.Append(" and makeId=" + ddlMakeMan.SelectedValue);
            }

            if (ddlInvoiceDate.SelectedValue.Trim() != "-1")
            {
                if (hidInvoiceDate.Value.Trim() != string.Empty)
                {
                    string[] list = hidInvoiceDate.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" AND ( recordDate >= '{0}' AND recordDate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" AND recordDate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" AND recordDate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlInvoiceDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND recordDate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND recordDate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND recordDate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( recordDate >= '{0}' AND recordDate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( recordDate >= '{0}' AND recordDate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }

            if (ddlMakeDate.SelectedValue.Trim() != "-1")
            {
                if (hidMakeDate.Value.Trim() != string.Empty)
                {
                    string[] list = hidMakeDate.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" AND ( makeDate >= '{0}' AND makeDate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" AND makeDate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" AND makeDate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlMakeDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND makeDate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND makeDate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND makeDate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( makeDate >= '{0}' AND makeDate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( makeDate >= '{0}' AND makeDate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }

            Session["query"] = sqlstr;
        }

        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadInvoiceRecordList();
        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            ddlInvoiceDate.SelectedIndex = 0;
            ddlMakeDate.SelectedIndex = 0;
            ddlMakeMan.SelectedIndex = 0;
            hidInvoiceDate.Value = "";
            hidMakeDate.Value = "";
            txtUnit.Value = "";
            Session["query"] = "";
            LoadInvoiceRecordList();
        }
    }
}