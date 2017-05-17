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
using System.Text;

namespace EtNet_Web.Pages.Order
{
    public partial class MyOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalesman();
                LoadCusName();
                QueryBulider();
                LoadOrderCollect();
            }
        }

        /// <summary>
        /// 绑定业务员信息
        /// </summary>
        private void LoadSalesman()
        {
            this.ddlsalesman.Items.Clear();
            this.ddlsalesman.Items.Add(new ListItem("——请选择——", "0"));
            LoginInfo current = (LoginInfo)Session["login"];
            string ids = LoginDataLimitManager.GetLimit(current.Id);
            if (string.IsNullOrEmpty(ids))
            {
                this.ddlsalesman.Items.Add(new ListItem(current.Cname, current.Id.ToString()));
            }
            else
            {
                DataTable dt = LoginInfoManager.getList(" id in (" + ids + ")");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem adItem = new ListItem();
                    adItem.Value = dt.Rows[i]["id"].ToString();
                    adItem.Text = dt.Rows[i]["cname"].ToString();
                    this.ddlsalesman.Items.Add(adItem);
                }
            }
        }

        /// <summary>
        /// 绑定收款单位
        /// </summary>
        private void LoadCusName()
        {
            this.ddlcus.Items.Clear();
            this.ddlcus.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = CustomerManager.GetList(0, "", "cusshortName");
            foreach (DataRow dr in dt.Rows)
            {
                ListItem adItem = new ListItem();
                adItem.Value = dr["id"].ToString();
                adItem.Value = dr["cusshortName"].ToString();
                ddlcus.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 保存数据列表
        /// </summary>
        private void QueryBulider()
        {
            if (Session["MyOrderQuery"] == null)
            {
                Session["MyOrderQuery"] = "";
            }
            else
            {
                //string value = Session["MyOrderQuery"].ToString();
                //if (value != "")
                //{
                //    string selectvalue = value.Substring(value.IndexOf('=') + 1).Trim();
                //    this.ddlsalesman.SelectedValue = selectvalue;
                //}
            }
        }

        /// <summary>
        /// 加载订单数据
        /// </summary>
        private void LoadOrderCollect()
        {
            if (Session["MyOrderQuery"].ToString() != "")
            {
                string sqlstr = " and iscancel='N'";//0510 修改作废的订单不显示
                sqlstr += Session["MyOrderQuery"].ToString();
                if (Session["login"] == null)
                    Response.Redirect("~/Login.aspx", true);
                else
                {
                    LoginInfo login = (LoginInfo)Session["login"];
                    //string ids = LoginDataLimitManager.GetLimit(login.Id);
                    //if (string.IsNullOrEmpty(ids))
                    //    sqlstr += " and salemanid = " + login.Id;
                    //else
                    //    sqlstr += " and salemanid in (" + ids + ")";
                    SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 034);
                    Data data = new Data();
                    AspNetPager1.RecordCount = data.GetCount("View_OrderAndClollect", sqlstr);
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
                    DataTable dt = data.GetList("View_OrderAndClollect", "outTime", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
                    orderRepeater.DataSource = dt;
                    orderRepeater.DataBind();

                    //计算合计
                    DataTable dtsum = To_OrderInfoManager.GetViewOrderAndCollect(" sum(adultNum) as adult_sum,sum(childNum) as child_sum,sum(withNum) as with_sum,sum(pNum) as pnum_sum,sum(lirun) as lirun_sum,sum(money) as money_sum ", " 1=1 " + sqlstr);
                    if (dtsum.Rows.Count > 0)
                    {
                        this.adult_sum.InnerHtml = dtsum.Rows[0]["adult_sum"].ToString();
                        this.child_sum.InnerHtml = dtsum.Rows[0]["child_sum"].ToString();
                        this.with_sum.InnerHtml = dtsum.Rows[0]["with_sum"].ToString();
                        this.pnum_sum.InnerHtml = dtsum.Rows[0]["pnum_sum"].ToString();
                        this.lirun_sum.InnerHtml = dtsum.Rows[0]["lirun_sum"].ToString();
                        this.money_sum.InnerHtml = dtsum.Rows[0]["money_sum"].ToString();
                    }
                }
            }
            else
            {
                orderRepeater.DataSource = null;
                orderRepeater.DataBind();
                this.adult_sum.InnerHtml = this.child_sum.InnerHtml = this.with_sum.InnerHtml = this.pnum_sum.InnerHtml = this.lirun_sum.InnerHtml = this.money_sum.InnerHtml = "";
            }
        }

        /// <summary>
        /// 业务员改变时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlsalesman_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (this.ddlsalesman.SelectedIndex != 0)
            {
                sqlstr = " and salemanid=" + this.ddlsalesman.SelectedValue;
                if (this.ddlcolstatus.SelectedIndex != 0)
                {
                    sqlstr += " and collectStatus='" + this.ddlcolstatus.SelectedValue + "'";
                }
            }
            Session["MyOrderQuery"] = sqlstr;
            LoadOrderCollect();
        }

        /// <summary>
        /// 收款状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlcolstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (this.ddlsalesman.SelectedIndex != 0)
            {
                sqlstr = " and salemanid=" + this.ddlsalesman.SelectedValue;
                if (this.ddlcolstatus.SelectedIndex != 0)
                {
                    sqlstr += " and collectStatus='" + this.ddlcolstatus.SelectedValue + "'";
                }
            }
            Session["MyOrderQuery"] = sqlstr;
            LoadOrderCollect();
        }

        /// <summary>
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadOrderCollect();
        }

        /// <summary>
        /// 显示旅游线路
        /// </summary>
        /// <param name="lineid"></param>
        /// <returns></returns>
        public string TourLine(int lineid)
        {
            if (lineid > 0)
            {
                return Tb_lineManager.getTb_lineById(lineid).Line.ToString();
            }
            else
            {
                return "线路出现错误";
            }

        }

        /// <summary>
        /// 保存状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string OrderStatus(string status)
        {
            if (status == "草稿")
            {
            }
            else
            {
                status = "<span style='color:blue'>已提交</span>";
            }
            return status;
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        /// <param name="statusid"></param>
        /// <returns></returns>
        public static string AuditsStatus(string statusid)
        {
            string status = JobAuditStatusManager.GetModelByNUM(statusid).txt;

            if (status == "进行中")
            {
                status = "<span style='color:blue'>" + status + "</span>";
            }
            if (status == "被拒绝")
            {
                status = "<span style='color:red'>" + status + "</span>";
            }
            if (status == "已通过")
            {
                status = "<span style='color:green'>" + status + "</span>";
            }
            return status;
        }

        /// <summary>
        /// 收款状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string CollectStatus(string status)
        {
            switch (status)
            {
                case "未收款":
                    return "<font color='red'>未收款</font>";
                case "完成收款":
                    return "<font color='green'>完成收款</font>";
                case "部分收款":
                    return "<font color='blue'>部分收款</font>";
                default:
                    return "参数错误";
            }
        }

        /// <summary>
        /// 得到剩余金额
        /// </summary>
        /// <param name="m"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static string GetSymoney(object m, object h)
        {
            double money = 0;
            double has = 0;
            double.TryParse(m.ToString(), out money);
            double.TryParse(h.ToString(), out has);
            return (money - has).ToString("F2");
        }

        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();
            if (this.ddlsalesman.SelectedIndex > 0)
            {
                sqlstr.Append(" and salemanid = " + this.ddlsalesman.SelectedValue);
            }
            if (this.ddlcolstatus.SelectedIndex > 0)
            {
                sqlstr.Append(" and collectStatus='" + this.ddlcolstatus.SelectedValue + "'");
            }
            if (this.ddlcus.SelectedIndex > 0)
            {
                sqlstr.Append(" and cusId=" + this.ddlcus.SelectedValue);
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" AND outTime >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" AND outTime <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND outTime < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }
            Session["MyOrderQuery"] = sqlstr;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadOrderCollect();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.ddlsalesman.SelectedIndex = 0;
            this.ddlcolstatus.SelectedIndex = 0;
            this.ddlcus.SelectedIndex = 0;
            this.ddlRequestDate.SelectedIndex = -1;
            this.hidDateValue.Value = "";
            Session["MyOrderQuery"] = "";
            LoadOrderCollect();
        }
    }
}