using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_Models;
using EtNet_BLL.DataPage;
using System.Text;

namespace EtNet_Web.Pages.expense
{
    public partial class OutComeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                    Response.Redirect("~/Login.aspx");
                QueryBuilder();
                PageSymbolNum();
                BindBank();
                BindDepart();
                BindOutComeType();
                Load_OutcomeList();
            }
        }

        /// <summary>
        /// 绑定付款类别
        /// </summary>
        private void BindOutComeType()
        {
            ddlpayitem.Items.Clear();
            DataTable dt = AusFinInfoManager.GetList("");
            DataRow dr = dt.NewRow();
            dr["itemname"] = "——请选择——";
            dr["id"] = "0";
            dt.Rows.InsertAt(dr, 0);
            ddlpayitem.DataTextField = "itemname";
            ddlpayitem.DataValueField = "id";
            ddlpayitem.DataSource = dt;
            ddlpayitem.DataBind();
        }

        /// <summary>
        /// 绑定银行
        /// </summary>
        private void BindBank()
        {
            ddlAcount.Items.Clear();
            DataTable dt = FirmAccountInfoManager.GetList("");
            DataRow dr = dt.NewRow();
            dr["bankname"] = "——请选择——";
            dr["id"] = "0";
            dt.Rows.InsertAt(dr, 0);
            ddlAcount.DataTextField = "bankname";
            ddlAcount.DataValueField = "id";
            ddlAcount.DataSource = dt;
            ddlAcount.DataBind();
        }

        /// <summary>
        /// 绑定部门
        /// </summary>
        private void BindDepart()
        {
            ddlDepart.Items.Clear();
            ddlDepart.Items.Add(new ListItem("——请选择——", "0"));
            IList<DepartmentInfo> L = DepartmentInfoManager.getDepartmentAll();
            foreach (DepartmentInfo D in L)
            {
                ListItem adItem = new ListItem();
                adItem.Text = D.Departcname;
                adItem.Value = D.Departid.ToString();
                ddlDepart.Items.Add(adItem);
            }

        }

        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = "";
            }
            if (Session["PageNum"].ToString() != "036")
            {
                Session["PageNum"] = "036";
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
        /// 绑定付款列表
        /// </summary>
        private void Load_OutcomeList()
        {
            double zje = 0;
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 035);
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
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("To_Outcome", sqlstr);
            DataTable dt = data.GetList("To_Outcome", "outComeDate", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    zje += dt.Rows[i]["outComeMoney"].ToString() == "" ? 0.00 : Convert.ToDouble(dt.Rows[i]["outComeMoney"]);
                }
            }
            this.zje.Text = zje.ToString("0.00");
            outList.DataSource = dt;
            outList.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Load_OutcomeList();
        }

        protected void outList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Response.Redirect("OutComeUpdate.aspx?id=" + Id);
                    break;
                case "Detail":
                    Response.Redirect("OutComeDetail.aspx?id=" + Id);
                    break;
                case "Delete":
                    Del(int.Parse(Id));
                    break;
                case "confirm":
                    To_OutcomeManager.UpdateStatus(Id, "1");
                    break;
                case "CANCEL":
                    To_OutcomeManager.UpdateStatus(Id, "0");
                    break;
            }
            Load_OutcomeList();
        }



        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        private void Del(int id)
        {
            int result = To_OutcomeManager.Delete(id);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            Load_OutcomeList();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            if (this.ddlPayStatus.SelectedIndex > 0)
            {
                sqlstr.AppendFormat(" and outComeStatus ='{0}'", this.ddlPayStatus.SelectedValue);
            }
            if (this.ddlpayitem.SelectedIndex > 0)
            {
                sqlstr.AppendFormat(" and outComeItemid = {0} ", this.ddlpayitem.SelectedValue);
            }
            if (this.txtSkUnit.Value != "")
            {
                sqlstr.AppendFormat(" and comeUnit like '%{0}%'" , this.txtSkUnit.Value.Trim());
            }
            if (this.ddlAcount.SelectedIndex > 0)
            {
                sqlstr.AppendFormat(" and outComeBankId = {0}", this.ddlAcount.SelectedValue);
            }
            if (this.ddlDepart.SelectedIndex > 0)
            {
                sqlstr.AppendFormat(" and outComeDepartId = {0}", this.ddlDepart.SelectedValue);
            }
            if (this.textMakeName.Value != "")
            {
                sqlstr.AppendFormat(" and makeName = '{0}'", this.textMakeName.Value.Trim());
            }
            if (this.txtremark.Value != "")
            {
                sqlstr.AppendFormat(" and remark like '%{0}%' ", this.txtremark.Value.Trim());
            }
            if (this.iptmoney.Value != "")//0419,增加内容：可根据收款金额进行模糊搜索
            {
                sqlstr.AppendFormat(" and outComeMoney like '%{0}%' ", this.iptmoney.Value.Trim());
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');
                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" and ( outComeDate >= '{0}' and outComeDate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" and outComeDate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" and outComeDate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND outComeDate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND outComeDate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND outComeDate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( outComeDate >= '{0}' AND outComeDate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( outComeDate >= '{0}' AND outComeDate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
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
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            ddlPayStatus.SelectedIndex = 0;
            ddlpayitem.SelectedIndex = 0;
            txtSkUnit.Value = "";
            ddlAcount.SelectedIndex = 0;
            ddlDepart.SelectedIndex = 0;
            textMakeName.Value = "";
            ddlRequestDate.SelectedIndex = -1;
            Session["query"] = "";
            Load_OutcomeList();
        }
    }
}