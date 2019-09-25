using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using EtNet_BLL;
using System.Text;

namespace EtNet_Web.Pages.Financial.PayConfirm
{
    public partial class payConfirmList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadColUnit();
                QueryBuilder();
                PageSymbolNum();
                LoadPayList();
            }
        }

        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = "";
            }
            if (Session["PageNum"].ToString() != "040")
            {
                Session["PageNum"] = "040";
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 保存数据列表
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
                Session["query"] = "";
            if (Session["payQuery"] == null)
            {
                Session["payQuery"] = "";
            }
            else
            {
                string value = Session["payQuery"].ToString();
                if (value != "")
                {
                    string selectvalue = (value.Split('\''))[1];
                    this.collectUnit.SelectedValue = selectvalue;
                }
            }
        }

        /// <summary>
        /// 加载付款单位（显示出来需要做付款确认的单位）
        /// </summary>
        private void LoadColUnit()
        {
            this.collectUnit.Items.Clear();
            this.collectUnit.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = FactoryManager.getFactoryWhichHasPayment();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Value = dt.Rows[i]["id"].ToString();
                adItem.Text = dt.Rows[i]["factshortName"].ToString();
                this.collectUnit.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 付款单位改变时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void collectUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["payQuery"] = " and payerID = '" + this.collectUnit.SelectedValue + "'";
            LoadPayList();
        }

        /// <summary>
        /// 加载付款申请数据
        /// </summary>
        private void LoadPayList()
        {
            LoginInfo login = Session["login"] as LoginInfo;
            if (!string.IsNullOrEmpty(Session["payQuery"].ToString())||!string.IsNullOrEmpty(Session["query"].ToString()))//--0429 更改
            {

            //}
            //if (Session["payQuery"].ToString() != "" || Session["query"].ToString() != "")//原方法报错
            //{
                string sql = " and auditstatus = '04' ";
                sql += Session["payQuery"];
                sql += Session["query"];
                EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
                AspNetPager1.RecordCount = data.GetCount("View_PaymentList", sql);
                SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 040);
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
                //0429 修改 为了排序顺序
               // DataTable dt = new EtNet_BLL.RegReimbursementManager().GetListpage(" auditstatus = '04'" + Session["payQuery"] + Session["query"], "regType asc,confirmDate DESC", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
                DataTable dt = data.GetpageList("View_PaymentList", " regType asc,confirmDate DESC ", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sql);

               // DataTable dt = data.GetList("View_PaymentList", "isConfirm", "asc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sql);//原方法
                this.payRepeater.DataSource = dt;
                this.payRepeater.DataBind();
            }
            else
            {
                this.payRepeater.DataSource = null;
                this.payRepeater.DataBind();
            }
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgread_Click(object sender, ImageClickEventArgs e)
        {
            string conId = "";
            //先遍历取得选中项
            for (int i = 0; i < this.payRepeater.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)payRepeater.Items[i].FindControl("cbx");
                Label lbl = (Label)payRepeater.Items[i].FindControl("lbl");
                if (cbx != null || lbl != null)
                {
                    if (cbx.Checked)
                    {
                        conId += lbl.Text + ",";
                    }
                }
            }

            //去掉最后一个，
            conId = (conId + ")").Replace(",)", "");

            Response.Redirect("PayConfirmed.aspx?id=" + conId + "&&factid=" + this.collectUnit.SelectedValue);
        }

        /// <summary> 
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadPayList();
        }

        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadPayList(); 
        }

        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();
            if (this.iptSKDW.Value != "")
            {
                sqlstr.AppendFormat(" and payerName like '%{0}%' ", this.iptSKDW.Value.Trim());
            }
            if (this.iptmoney.Value != "")
            {
                sqlstr.AppendFormat(" and totalAmount = {0} ", this.iptmoney.Value.Trim());
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" AND requestDate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" AND requestDate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND requestDate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND requestDate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND requestDate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
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

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.iptSKDW.Value = "";
            this.iptmoney.Value = "";
            this.ddlRequestDate.SelectedIndex = -1;
            Session["query"] = "";
            LoadPayList();
        }

        
    }
}