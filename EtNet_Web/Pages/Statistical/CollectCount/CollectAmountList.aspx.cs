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

namespace EtNet_Web.Pages.Statistical.CollectCount
{
    public partial class CollectAmountList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SalesmanLoad();
                QueryBulider();
                LoadData();
            }
        }

        /// <summary>
        /// 绑定业务员选择项
        /// </summary>
        private void SalesmanLoad()
        {
            ddlsalesman.Items.Clear();
            ddlsalesman.Items.Add(new ListItem("——请选择——", "0"));
            IList<LoginInfo> list = LoginInfoManager.getLoginInfoAll();
            foreach (LoginInfo login in list)
            {
                ListItem adItem = new ListItem();
                adItem.Text = login.Cname;
                adItem.Value = login.Id.ToString();
                ddlsalesman.Items.Add(adItem);
            }
        }

        private void QueryBulider()
        {
            if (Session["CollectAmountQuery"] == null)
            {
                Session["CollectAmountQuery"] = "";
            }
            if (Session["CollectDetailQuery"] == null || Session["CollectDetailQuery"].ToString() != "")
            {
                Session["CollectDetailQuery"] = "";
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string sqlstr = " ";
            string tablename = this.cbxFileShow.Checked ? "ViewOrderCollectAmountFile": "ViewOrderCollectAmount" ;
            sqlstr += Session["CollectAmountQuery"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 032);
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount(tablename, sqlstr);
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
            DataTable dt = data.GetList(tablename, "cusId", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            rptdata.DataSource = dt;
            rptdata.DataBind();

            //计算金额合计
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("select sum(money) as shouldAmount,sum(collectAmount) as collectAmount,sum(syAmount) as syAmount,sum(countNum) as countamount,sum(adultNum) as adultamount ");
            string tblname = tablename;
            DataTable dtSum = data.GetSumMoney(sqlSelect.ToString(), tblname, sqlstr);
            if (dtSum.Rows.Count > 0)
            {
                DataRow dr = dtSum.Rows[0];
                shouldamount.InnerText = Convert.IsDBNull(dr["shouldAmount"]) ? "" : Convert.ToDouble(dr["shouldAmount"]).ToString("N2");
                hasamount.InnerText = Convert.IsDBNull(dr["collectAmount"]) ? "" : Convert.ToDouble(dr["collectAmount"]).ToString("N2");
                syamount.InnerText = Convert.IsDBNull(dr["syAmount"]) ? "" : Convert.ToDouble(dr["syAmount"]).ToString("N2");
                countamount.InnerText = Convert.IsDBNull(dr["countamount"]) ? "" : Convert.ToDouble(dr["countamount"]).ToString("N2");
                adultamount.InnerText = Convert.IsDBNull(dr["adultamount"]) ? "" : Convert.ToDouble(dr["adultamount"]).ToString("N2");
            }

            //double a = 0;
            //double b = 0;
            //double c = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    a += Convert.IsDBNull(dt.Rows[i]["money"]) ? 0 : Convert.ToDouble(dt.Rows[i]["money"]);
            //    b += Convert.IsDBNull(dt.Rows[i]["collectAmount"]) ? 0 : Convert.ToDouble(dt.Rows[i]["collectAmount"]);
            //    c += Convert.IsDBNull(dt.Rows[i]["syAmount"]) ? 0 : Convert.ToDouble(dt.Rows[i]["syAmount"]);
            //}
            //this.shouldamount.InnerText = a.ToString("F2");
            //this.hasamount.InnerText = b.ToString("F2");
            //this.syamount.InnerText = c.ToString("F2");
        }

        //0511 修改获取收款单位的详细信息
        public string CustD(object custid)
        {
            string returnV = "";
            DataTable dt = CustomerManager.GetList("id=" + custid.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["linkName"].ToString()==""&&dt.Rows[0]["telephone"].ToString()=="")
                {
                    returnV = "暂无该单位的联系信息";
                }
                else
                returnV = !string.IsNullOrEmpty(dt.Rows[0]["linkName"].ToString()) ? dt.Rows[0]["linkName"].ToString() : "暂无该单位的联系人信息" + ":" +  (!string.IsNullOrEmpty(dt.Rows[0]["telephone"].ToString()) ? dt.Rows[0]["telephone"].ToString() : "暂无该单位的联系方式");
            }
            else
                returnV = "暂无该单位的联系信息";
            return returnV;
        }


        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            if (txtunit.Value.Trim() != "")
            {
                sqlstr.Append(" and cusName like '%" + this.txtunit.Value.Trim() + "%'");
            }
            if (ddlsalesman.SelectedIndex != 0)
            {
                sqlstr.Append(" and salesmanid=" + ddlsalesman.SelectedValue);
            }
            if (ddlsyamount.SelectedIndex != 0)
            {
                if (ddlsyamount.SelectedValue == "=")
                {
                    sqlstr.Append(" and syAmount = 0 or syAmount is null ");
                }
                else
                {
                    sqlstr.Append(" and syAmount " + ddlsyamount.SelectedValue + " 0");
                }
            }
            //if (ddlRequestDate.SelectedValue.Trim() != "-1")
            //{
            //    if (hidDateValue.Value.Trim() != string.Empty)
            //    {
            //        string[] list = hidDateValue.Value.Trim().Split(',');

            //        if (list[0].Trim() != "" && list[1].Trim() != "")
            //        {
            //            sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime <= '{1}' ) ", list[0].Trim(), list[1].Trim());
            //        }
            //        else if (list[0].Trim() != "" && list[1].Trim() == "")
            //        {
            //            sqlstr.AppendFormat(" AND outTime >= '{0}' ", list[0].Trim());
            //        }
            //        else
            //        {
            //            sqlstr.AppendFormat(" AND outTime <= '{0}' ", list[1].Trim());
            //        }
            //    }
            //    else
            //    {
            //        switch (ddlRequestDate.SelectedValue.Trim())
            //        {
            //            case "0"://今天
            //                sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
            //                break;
            //            case "1"://今天之前
            //                sqlstr.AppendFormat(" AND outTime < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
            //                break;
            //            case "2"://昨天
            //                sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
            //                break;
            //            case "3"://7天内
            //                sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
            //                break;
            //            case "4"://15天内
            //                sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
            //                break;
            //            case "5"://指定范围
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}

            Session["CollectAmountQuery"] = sqlstr;
        }


        /// <summary>
        /// 筛选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadData();
        }

        /// <summary>
        /// 重置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.txtunit.Value = "";
            this.ddlsyamount.SelectedIndex = 0;
            this.ddlsalesman.SelectedIndex = 0;
            //ddlRequestDate.SelectedIndex = 0;
            //hidDateValue.Value = "";
            Session["CollectAmountQuery"] = "";
            LoadData();
        }

        /// <summary>
        /// 分也改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void cbxFileShow_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}