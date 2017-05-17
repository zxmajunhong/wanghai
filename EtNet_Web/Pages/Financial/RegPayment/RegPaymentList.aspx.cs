using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EtNet_BLL;
using EtNet_Models;
using EtNet_BLL.DataPage;
using System.Data;

namespace EtNet_Web.Pages.Financial.RegPayment
{
    public partial class RegPaymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPaymentType();
                BindPaymentList();
            }
        }

        private void LoadPaymentType()
        {
            ddlPaymentType.Items.Clear();
            DataTable dt = AusFinInfoManager.GetList("");
            ddlPaymentType.Items.Add(new ListItem("——请选择——", ""));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Text = dt.Rows[i]["itemname"].ToString();
                adItem.Value = dt.Rows[i]["itemname"].ToString();
                ddlPaymentType.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 绑定付费列表数据
        /// </summary>
        private void BindPaymentList()
        {
            double zje = 0;
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 020);
           string sql = " and isconfirm = 1";
            sql += FilterSql;
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("View_PaymentList", sql);
            if (sps == null)
            {
                AspNetPager1.NumericButtonCount = 10;
                AspNetPager1.PageSize = 10;
            }
            else
            {
                AspNetPager1.NumericButtonCount = sps.Pagecount;
                AspNetPager1.PageSize = sps.Pageitem;
            }
            //0419，修改首页列表中未支付优先显示
            //DataTable dt = new EtNet_BLL.RegReimbursementManager().GetListpage(" isconfirm = 1" + FilterSql, "regType asc,requestDate DESC", AspNetPager1.StartRecordIndex, AspNetPager1.CurrentPageIndex);
            //原方法 DataTable dt = data.GetList("View_PaymentList", " regType"," DESC ", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sql);
            //0512 修改存储过程之后 多条件排序方法
            DataTable dt = data.GetpageList("View_PaymentList", " regType asc,requestDate DESC ", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                zje += dt.Rows[i]["totalAmount"].ToString() == "" ? 0.00 : Convert.ToDouble(dt.Rows[i]["totalAmount"]);
            }

            RpPaymentList.DataSource = dt;
            RpPaymentList.DataBind();
            this.zje.Text = zje.ToString("0.00");
        }

        protected void RpPaymentList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            object objArg = e.CommandArgument;
            string cmdName = e.CommandName;

            if (cmdName == "EDIT")//编辑
            {
                string paymentID = objArg.ToString();
                Response.Redirect("RegPayment.aspx?payid=" + paymentID);
                return;
            }
            if (cmdName == "cancel")//撤销
            {
                string regID = e.CommandArgument.ToString().Trim();
                EtNet_BLL.RegReimbursementManager bReg = new EtNet_BLL.RegReimbursementManager();
                EtNet_BLL.RegPaymentManager regpay = new EtNet_BLL.RegPaymentManager();
                bReg.UpdatePayerType(0, regID);
                regpay.UpdatePayStatus(0, regID);
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "cancel", "alert(\"撤销成功\");", true);


            }
            if (cmdName == "Search")//查看
            {
                string paymentID = objArg.ToString();
                Response.Redirect("SearchRegPayment.aspx?payid=" + paymentID);
                return;
            }

            BindPaymentList();
        }


        protected string GetApprovalHtml(object statusCode)
        {
            if (statusCode != DBNull.Value)
            {
                string code = statusCode.ToString();
                if (code == "未开始")
                {
                    return "<font color='red'>未开始</font>";
                }

                if (code == "已通过")
                {
                    return "<font color='green'>已通过</font>";
                }
                if (code == "被拒绝")
                {
                    return "<font color='red'>被拒绝</font>";
                }

                return code;
            }
            else
            {
                return "<font color='red'>未知</font>";
            }
        }


        /// <summary>
        /// 构建筛选sql
        /// </summary>
        private void BuildFilterSql()
        {
            StringBuilder filterBuilder = new StringBuilder();

            if (txtSerialNum.Text.Trim() != string.Empty)//申请单号
                filterBuilder.AppendFormat(" AND serialNum = '{0}' ", txtSerialNum.Text.Trim());

            if (ddlPaymentType.SelectedValue.Trim() != "")//付款类别
                filterBuilder.AppendFormat(" AND paymentType = '{0}' ", ddlPaymentType.SelectedValue.Trim());

            //if (ddlPayfor.SelectedValue.Trim() != "0")//付款名称
            //    filterBuilder.AppendFormat(" AND payFor = '{0}' ", ddlPayfor.SelectedValue.Trim());

            if (txtPayerUnit.Text.Trim() != string.Empty)//收款单位
                filterBuilder.AppendFormat(" AND payerName like '%{0}%' ", txtPayerUnit.Text.Trim());

            if (txtPayAmount.Text.Trim() != string.Empty)//付款金额
                filterBuilder.AppendFormat(" AND totalAmount ={0} ", txtPayAmount.Text.Trim());

            if (txtMaker.Text.Trim() != string.Empty)//制单员
                filterBuilder.AppendFormat(" AND makerName like '{0}' ", txtMaker.Text.Trim());

            if (ddlAuditStaus.SelectedValue.Trim() != "-1")//审核状态
                filterBuilder.AppendFormat(" AND auditstatus = '{0}' ", ddlAuditStaus.SelectedValue.Trim());

            if (ddlSaveSatus.SelectedValue.Trim() != "-1")//保存状态
                filterBuilder.AppendFormat(" AND savestatus = '{0}' ", ddlSaveSatus.SelectedValue.Trim());

            //申请日期
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        filterBuilder.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        filterBuilder.AppendFormat(" AND requestDate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        filterBuilder.AppendFormat(" AND requestDate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            filterBuilder.AppendFormat(" AND requestDate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            filterBuilder.AppendFormat(" AND requestDate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            filterBuilder.AppendFormat(" AND requestDate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            filterBuilder.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            filterBuilder.AppendFormat(" AND ( requestDate >= '{0}' AND requestDate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }

            FilterSql = filterBuilder.ToString();
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }


        /// <summary>
        /// 点击筛选时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, ImageClickEventArgs e)
        {
            BuildFilterSql();

            BindPaymentList();
        }


        /// <summary>
        /// 点击重置时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterSql = string.Empty;

            BindPaymentList();

            txtMaker.Text = txtPayAmount.Text = txtPayerUnit.Text = txtSerialNum.Text = string.Empty;

            ddlAuditStaus.SelectedIndex = ddlPaymentType.SelectedIndex = ddlRequestDate.SelectedIndex = ddlSaveSatus.SelectedIndex = 0;
        }
        /// <summary>
        /// 支付按钮的隐藏显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static bool Edit(string pay)
        {
            if (pay == "1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 撤销按钮的隐藏显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static bool off(string pay)
        {
            if (pay == "1")
                return true;
            else
                return false;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindPaymentList();
        }
    }
}