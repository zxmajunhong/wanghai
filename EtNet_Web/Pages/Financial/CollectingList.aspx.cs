using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Text;
using System.Data;

namespace EtNet_Web.Pages.Financial
{
    public partial class CollectingList : System.Web.UI.Page
    {
        #region ****************************Page_Load方法****************************
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx", true);
            }

            if (!IsPostBack)
            {
                BindRpList();
            }
        }
        #endregion

        #region ****************************方法****************************

        IList<To_Collecting> collectingList = null;
        /// <summary>
        /// 绑定收款单据列表数据
        /// </summary>
        private void BindRpList()
        {
            double zje = 0;
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx", true);
            }
            else
            {
                LoginInfo login = Session["login"] as LoginInfo;

                AspNetPager1.RecordCount = To_CollectingManager.GetTotalCount(FilterSql, login.Id);

                SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 019);
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
                if (HttpContext.Current.Request.QueryString["page"]!=null)
                {
                    AspNetPager1.CurrentPageIndex = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                }
               
                collectingList = To_CollectingManager.GetListByPage(FilterSql, login.Id, AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
               //5.31 增加总计的计算
                if (collectingList.Count > 0 && collectingList!=null)
                {
                    foreach (To_Collecting cl in collectingList)
                    {
                        zje += cl.ReceiptAmount.ToString() == "" ? 0.00 : Convert.ToDouble(cl.ReceiptAmount.ToString());
                    }
                }
                RpList.DataSource = collectingList;
                RpList.DataBind();
                this.zje.Text = "￥"+zje.ToString("0.00");
            }
        }

        /// <summary>
        /// 根据单据ID删除收款数据
        /// </summary>
        /// <param name="id">要删除的单据ID</param>
        private void DeleteCollecting(int id)
        {
            To_CollectingManager.deleteTo_Collecting(id);
            BindRpList();
        }

        /// <summary>
        /// 根据条件筛选单据
        /// </summary>
        private void FilterReceipt()
        {
            StringBuilder filterBuilder = new StringBuilder();

            if (txtFilterNum.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND receiptNum LIKE '%{0}%' ", txtFilterNum.Text.Trim());
            if (DdlFilterPayMode.SelectedValue != string.Empty)
                filterBuilder.AppendFormat(" AND paymentMode = '{0}' ", DdlFilterPayMode.SelectedValue);
            if (txtFilterPolicyAmount.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND receiptAmount = {0} ", txtFilterPolicyAmount.Text.Trim());
            if (txtFilterUnit.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND paymentUnit LIKE '%{0}%' ", txtFilterUnit.Text.Trim());
            if (txtinbank.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND payBank like '%{0}%' ", txtinbank.Text.Trim());

            if (txtFilterSatrtTime.Text.Trim() == string.Empty)
            {
                if (txtFilterEndTime.Text.Trim() != string.Empty)
                {
                    filterBuilder.AppendFormat(" AND receiptDate <= '{0}' ", txtFilterEndTime.Text.Trim());
                }
            }

            if (txtFilterEndTime.Text.Trim() == string.Empty)
            {
                if (txtFilterSatrtTime.Text.Trim() != string.Empty)
                {
                    filterBuilder.AppendFormat(" AND receiptDate >= '{0}' ", txtFilterSatrtTime.Text.Trim());
                }
            }

            if (txtFilterSatrtTime.Text.Trim() != string.Empty && txtFilterEndTime.Text.Trim() != string.Empty)
                filterBuilder.AppendFormat(" AND ( receiptDate BETWEEN '{0}' AND '{1}' ) ", txtFilterSatrtTime.Text.Trim(), txtFilterEndTime.Text.Trim());

            FilterSql = filterBuilder.ToString();
        }

        /// <summary>
        /// 转换收款方式
        /// </summary>
        /// <param name="mode">0：现金；1：转账；2：网银</param>
        /// <returns></returns>
        protected string ChangePaymentMode(string mode)
        {
            switch (mode)
            {
                case "0":
                    return "现金";
                case "1":
                    return "转账";
                case "2":
                    return "网银";
                default:
                    return "未知";
            }
        }

        /// <summary>
        /// 获取一个值表示按钮是否可见
        /// </summary>
        /// <param name="makerID"></param>
        /// <returns></returns>
        protected bool GetVisible()
        {
            LoginInfo currentUser = Session["login"] as LoginInfo;
            string departname = DepartmentInfoManager.getDepartmentInfoById(currentUser.Departid).Departcname;
            if (departname == "财务部") //财务部的人员才能撤销确认
                return true;
            else
                return false;
        }

        public string IsShow(object value)
        {
            string returnval = "";
            if (value.ToString() == "0")
            {
                returnval = "";
            }
            else
                returnval = "display:none";
            return returnval;
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

        #endregion

        #region ****************************事件****************************

        protected void RpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //参数数组，0：单据ID，1：是否确认,2：制单员
            string[] cmdArgs = e.CommandArgument.ToString().Split(',');

            string cmdName = e.CommandName;

            //表示单据是否已确认
            bool confirmReceipt = false;
            bool ismaker = false;
            LoginInfo login = Session["login"] as LoginInfo;
            if (cmdArgs.Length > 1)
            {
                confirmReceipt = cmdArgs[1] == "1";
                ismaker = cmdArgs[2] == login.Cname;
            }

            string msg = "";
            switch (cmdName)
            {
                case "EDIT":
                    if (confirmReceipt)
                    {
                        msg = "已确认单据不能修改";
                        break;
                    }
                    if (!ismaker)
                    {
                        msg = "不是本人所做的收款单不能修改";
                        break;
                    }
                    if (HttpContext.Current.Request.QueryString["page"] != null)
                    {
                        int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                        Server.Transfer(string.Format("CollectingEdit.aspx?pageindex=" + page + "&id={0}", cmdArgs[0]));

                    }
                    else
                    Server.Transfer(string.Format("CollectingEdit.aspx?id={0}", cmdArgs[0]));
                    break;

                case "search":
                    if (AspNetPager1.CurrentPageIndex > 1)
                    {
                        int page = AspNetPager1.CurrentPageIndex;
                        Response.Redirect("Collecting.aspx?pageindex=" + page + "&id=" + e.CommandArgument.ToString());//参数sqsh判断当前所跳转到预览界面的是申请还是审核

                    }
                    else
                        Response.Redirect("Collecting.aspx?id=" + e.CommandArgument.ToString());
                    break;
                case "DELETE":
                    if (confirmReceipt)
                    {
                        msg = "已确认单据不能删除";
                        break;
                    }
                    if (!ismaker)
                    {
                        msg = "不是本人所做的收款单不能删除";
                        break;
                    }
                    DeleteCollecting(int.Parse(cmdArgs[0]));
                    break;
                case "CANCEL":
                    To_ClaimManager claimBLL = new To_ClaimManager();
                    if (claimBLL.ExitsCollecting(int.Parse(cmdArgs[0])))
                    {
                        msg = "该条收款记录已被认领，不能取消确认";
                        break;
                    }
                    To_CollectingManager.CancelConfirm(int.Parse(cmdArgs[0]));
                    BindRpList();
                    break;
                case "confirm":
                    To_CollectingManager.updateConfirm(cmdArgs[0], login.Cname, DateTime.Now.ToString());
                    BindRpList();
                    break;
                case "CHANGE":
                    To_Income income = new To_Income();
                    DataTable mytable = To_CollectingManager.GetList(1, "id=" + cmdArgs[0],"id desc");
                    if (mytable != null)
                    {
                        income.ComeBankAccount = mytable.Rows[0]["payBankAcount"].ToString();
                        income.ComeBankId = int.Parse(mytable.Rows[0]["payBankId"].ToString());
                        income.ComeBankName = mytable.Rows[0]["payBank"].ToString();
                        income.ComeDate = DateTime.Parse(mytable.Rows[0]["receiptDate"].ToString());
                        income.ComeDepart = mytable.Rows[0]["markerDepartment"].ToString();
                        income.ComeDepartId = int.Parse(mytable.Rows[0]["markerDepartmentID"].ToString());
                        income.ComeMoney = double.Parse(mytable.Rows[0]["receiptAmount"].ToString());
                        income.ComeUnit = mytable.Rows[0]["paymentUnit"].ToString();
                        income.MakeDate = DateTime.Parse(mytable.Rows[0]["markDate"].ToString());
                        income.MakeId = int.Parse(mytable.Rows[0]["markerID"].ToString());
                        income.MakeName = mytable.Rows[0]["marker"].ToString();
                        income.Remark = mytable.Rows[0]["receiptMark"].ToString() +" 由原收款单号为"+ mytable.Rows[0]["receiptNum"].ToString()+"转化而来";
                        income.SKType = "";
                        income.SKTypeId = 0;
                        if (To_IncomeManager.Add(income) > 0)
                        {
                            msg = "该条收款记录已成功转化为其他收款";
                            To_CollectingManager.deleteTo_Collecting(int.Parse(cmdArgs[0]));//转化完成之后对起进行删除
                        }

                    }
                     BindRpList();
                    break;
                default:
                    break;
            }

            if (msg != string.Empty)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "page", string.Format("alert('{0}');", msg), true);
            }
        }

        /// <summary>
        /// 当前页索引发生变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindRpList();
        }

        /// <summary>
        /// 点击查询按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterReceipt();
            BindRpList();
        }

        /// <summary>
        /// 点击重置筛选条件时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnResetFilter_Click(object sender, ImageClickEventArgs e)
        {
            FilterSql = string.Empty;
            txtFilterUnit.Text = string.Empty;
            txtFilterSatrtTime.Text = string.Empty;
            txtFilterPolicyAmount.Text = string.Empty;
            txtFilterNum.Text = string.Empty;
            txtFilterEndTime.Text = string.Empty;
            DdlFilterPayMode.SelectedValue = string.Empty;
            txtinbank.Text = string.Empty;

            BindRpList();
        }

        #endregion

        #region ****************************属性****************************

        /// <summary>
        /// 筛选条件
        /// </summary>
        private string FilterSql
        {
            get { return ViewState["filter"] == null ? "" : ViewState["filter"].ToString(); }
            set { ViewState["filter"] = value; }
        }

        #endregion

    }
}