using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using System.Data;
using EtNet_Models;
using System.Text;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class SelectOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
               // LoadOrderList();原方法0606修改下
                OrderListBind();
                BindApprovalProcess();
                BindOperator();
                BindAuditStatus();
            }
        }
        /// <summary>
        /// 绑定线路
        /// </summary>
        public void BindApprovalProcess()
        {
            ddlLine.Items.Clear();

            IList<Tb_line> typelist = Tb_lineManager.getTb_lineAll();
            for (int i = 0; i < typelist.Count; i++)
            {
                ListItem list = new ListItem(typelist[i].Line.ToString(), typelist[i].Id.ToString());
                ddlLine.Items.Add(list);
            }
            ListItem ltem = new ListItem("选择线路", "-1");//添加第一行默认值
            ddlLine.Items.Insert(0, ltem);//添加第一行默认值

        }

        /// <summary>
        /// 绑定操作员
        /// </summary>
        public void BindOperator()
        {
            ddloperator.Items.Clear();
            ddloperator.Items.Add(new ListItem("——请选择——", "0"));
            IList<LoginInfo> list = LoginInfoManager.getLoginInfoAll();
            foreach (LoginInfo l in list)
            {
                ListItem adItem = new ListItem();
                adItem.Text = l.Cname;
                adItem.Value = l.Id.ToString();
                ddloperator.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 绑定结算状态
        /// </summary>
        public void BindAuditStatus()
        {
            ddlaudtistatus.Items.Clear();
            ddlaudtistatus.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = JobAuditStatusManager.GetList("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Text = dt.Rows[i]["txt"].ToString();
                adItem.Value = dt.Rows[i]["num"].ToString();
                ddlaudtistatus.Items.Add(adItem);
            }
        }

        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = "";
            }
            if (Session["PageNum"].ToString() != "090")
            {
                Session["PageNum"] = "090";
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


        /// <summary>
        /// 加载订单信息
        /// </summary>
        //private void LoadOrderList()
        //{
        //    DataTable dt = To_OrderInfoManager.GetLists(" iscancel = 'N' ");
        //    rpOrderList.DataSource = dt;
        //    rpOrderList.DataBind();
        //}
        /// <summary>
        ///  订单列表
        /// </summary>
        private void OrderListBind()
        {
            string sqlstr = " and iscancel = 'N'";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
                sqlstr += " and (markid = " + login.Id + " or inputerId= " + login.Id + ") ";
            else
                sqlstr += " and (inputerId in (" + ids + ") or markid= " + login.Id + ") ";//0419修改，将查看数据权限更改为可查看操作员数据
            //sqlstr += " or inputerID = " + login.Id; //操作员也能看到其对应的订单信息

            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 090);
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("ViewOrder", sqlstr);
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
            DataTable dt = data.GetList("ViewOrder", "makerTime", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            rpOrderList.DataSource = dt;
            rpOrderList.DataBind();
        }

        /// <summary>
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
           // LoadOrderList();
            OrderListBind();
        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            OrderListBind();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            if (this.ddlLine.SelectedValue != "-1")
            {
                sqlstr.AppendFormat(" and tour = " + this.ddlLine.SelectedValue);
            }

            if (this.txtNature.Value != "")
            {
                sqlstr.AppendFormat(" and natrue like '%" + this.txtNature.Value + "%'");
            }

            if (this.txtOrderNum.Value != "")
            {
                sqlstr.AppendFormat(" and orderNum like '%" + this.txtOrderNum.Value + "%'");
            }
            if (this.txtTourRemark.Value != "")
            {
                sqlstr.Append(" and tourRemark like '%" + this.txtTourRemark.Value + "%'");
            }
            if (this.ddloperator.SelectedIndex != 0)
            {
                sqlstr.Append(" and inputerID=" + this.ddloperator.SelectedValue);
            }
            if (this.ddlsavestatus.SelectedIndex != 0)
            {
                sqlstr.Append(" and savestatus = '" + this.ddlsavestatus.SelectedValue + "'");
            }
            if (this.ddlaudtistatus.SelectedIndex != 0)
            {
                sqlstr.Append(" and auditstatus = '" + this.ddlaudtistatus.SelectedValue + "'");
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
            Session["query"] = sqlstr;
        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {

            ddlRequestDate.SelectedIndex = -1;
            txtNature.Value = "";
            txtOrderNum.Value = "";
            ddlLine.SelectedIndex = -1;
            hidDateValue.Value = "";
            Session["query"] = "";
            txtTourRemark.Value = "";
            ddloperator.SelectedIndex = 0;
            ddlsavestatus.SelectedIndex = 0;
            ddlaudtistatus.SelectedIndex = 0;
            OrderListBind();

        }

    }
}