using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;
using EtNet_BLL.DataPage;
using System.Text;

namespace EtNet_Web.Pages.Order
{
    public partial class FileOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
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
            if (Session["PageNum"].ToString() != "013")
            {
                Session["PageNum"] = "013";
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
        ///  订单列表
        /// </summary>
        private void OrderListBind()
        {
            string sqlstr = " and fileStatus=1 ";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
                sqlstr += " and (markid = " + login.Id + " or inputerId= " + login.Id + ") ";
            else
                sqlstr += " and (markid in (" + ids + ") or inputerId= " + login.Id + ") ";
            //sqlstr += " or inputerID = " + login.Id; //操作员也能看到其对应的订单信息
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 013);
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
            cuslist.DataSource = dt;
            cuslist.DataBind();
            LoadZtreeData();
        }

        /// <summary>
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            OrderListBind();
        }

        //树形控件
        public string result = "";
        public string LoadZtreeData()
        {
            result += "[{id:999, pId: 999, name:'全部订单" + "', icon:'../../Images/public/bfolder.gif', open: true },";
            result += "{id:1, pId: 999, name:'常规订单" + "',icon:'../../Images/public/folder.gif'},";
            result += "{id:2, pId: 999, name:'非常规订单" + "',icon:'../../Images/public/folder.gif' }]";
            return result;

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

            int id = 999;
            if (hidsort.Value.Trim() != "")
            {
                int.TryParse(hidsort.Value.Trim(), out id);
                if (id != 999)
                {
                    sqlstr.AppendFormat(" and orderType = " + id);
                }
            }

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

        /// <summary>
        /// 重置方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {

            ddlRequestDate.SelectedIndex = -1;
            txtNature.Value = "";
            txtOrderNum.Value = "";
            ddlLine.SelectedIndex = -1;
            hidsort.Value = "";
            hidDateValue.Value = "";
            Session["query"] = "";
            txtTourRemark.Value = "";
            ddloperator.SelectedIndex = 0;
            ddlsavestatus.SelectedIndex = 0;
            ddlaudtistatus.SelectedIndex = 0;
            OrderListBind();

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
        /// 订单收款状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string colStatus(string orderId)
        {
            int id = 0;
            int.TryParse(orderId, out id);
            DataTable orderdt = To_OrderCollectDetialManager.getList(id);
            List<string> status = new List<string>();
            for (int i = 0; i < orderdt.Rows.Count; i++)
            {
                status.Add(getStatus(orderdt.Rows[i]["id"].ToString(), orderdt.Rows[i]["money"].ToString()));
            }

            if (status.All<string>(x => x == "0")) //判断是否都为0
            {
                return "<font color='red'>未收款</font>";
            }
            else if (status.All<string>(x => x == "2")) //判断是否都为2
            {
                return "<font color='green'>完成收款</font>";
            }
            else
                return "<font color='blue'>部分收款</font>";
        }

        /// <summary>
        /// 得到收款状态
        /// </summary>
        /// <param name="ordercolid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public string getStatus(string ordercolid, string money)
        {
            To_ClaimDetailManager manager = new To_ClaimDetailManager();
            double hasAmount = manager.GetHasAmount(ordercolid);
            double shouldAmount = 0;
            double.TryParse(money, out shouldAmount);
            if (hasAmount == 0)
            {
                return "0";
            }
            else
            {
                if (shouldAmount > hasAmount)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "File":
                    To_OrderInfoManager.updateFileStatus(0, Convert.ToInt32(e.CommandArgument));
                    break;

            }
            OrderListBind();
        }
    }
}