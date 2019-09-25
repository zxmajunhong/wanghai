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

namespace EtNet_Web.Pages.Statistical.PayCount
{
    public partial class PayAmountList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBulider();
                LoadData();
            }
        }

        private void QueryBulider()
        {
            if (Session["payAmountQuery"] == null)
            {
                Session["payAmountQuery"] = "";
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string sqlstr = " ";
            string tablename = this.cbxFileShow.Checked ? "ViewOrderPayAmount" : "ViewOrderPayAmountFile";
            sqlstr += Session["payAmountQuery"].ToString();
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
            DataTable dt = data.GetList(tablename, "factid", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            rptdata.DataSource = dt;
            rptdata.DataBind();

            //计算合计
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("select sum(money) as shouldAmount,sum(payAmount) as payAmount,sum(syAmount) as syAmount,sum(reMoney) as reMoney,sum(reAmount) as reAmount,sum(reSyAmount) as reSyAmount ");
            string tblname = tablename;
            DataTable dtSum = data.GetSumMoney(sqlSelect.ToString(), tblname, sqlstr);
            if (dtSum.Rows.Count > 0)
            {
                DataRow dr = dtSum.Rows[0];
                shouldamount.InnerText = Convert.IsDBNull(dr["shouldAmount"]) ? "" : Convert.ToDouble(dr["shouldAmount"]).ToString("N2");
                hasamount.InnerText = Convert.IsDBNull(dr["payAmount"]) ? "" : Convert.ToDouble(dr["payAmount"]).ToString("N2");
                syamount.InnerText = Convert.IsDBNull(dr["syAmount"]) ? "" : Convert.ToDouble(dr["syAmount"]).ToString("N2");
                refundshouldamount.InnerText = Convert.IsDBNull(dr["reMoney"]) ? "" : Convert.ToDouble(dr["reMoney"]).ToString("N2");
                rehasamount.InnerText = Convert.IsDBNull(dr["reAmount"]) ? "" : Convert.ToDouble(dr["reAmount"]).ToString("N2");
                resyamount.InnerText = Convert.IsDBNull(dr["reSyAmount"]) ? "" : Convert.ToDouble(dr["reSyAmount"]).ToString("N2");
            }
            //double a = 0;
            //double b = 0;
            //double c = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    a += Convert.IsDBNull(dt.Rows[i]["money"]) ? 0 : Convert.ToDouble(dt.Rows[i]["money"]);
            //    b += Convert.IsDBNull(dt.Rows[i]["payAmount"]) ? 0 : Convert.ToDouble(dt.Rows[i]["payAmount"]);
            //    c += Convert.IsDBNull(dt.Rows[i]["syAmount"]) ? 0 : Convert.ToDouble(dt.Rows[i]["syAmount"]);
            //}
            //this.shouldamount.InnerText = a.ToString("F2");
            //this.hasamount.InnerText = b.ToString("F2");
            //this.syamount.InnerText = c.ToString("F2");

        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            if (txtunit.Value.Trim() != "")
            {
                sqlstr.Append(" and supName like '%" + this.txtunit.Value.Trim() + "%'");
            }
            if (ddlsyamount.SelectedIndex != 0)
            {
                if (ddlsyamount.SelectedValue == "=")
                {
                    sqlstr.Append(" and syAmount = 0 or syAmount is null ");
                }
                else
                {
                    sqlstr.Append(" and syAmount " + ddlsyamount.SelectedValue + " 0 ");
                }
            }
            //if (txtFilterSatrtTime.Text.Trim() == string.Empty)
            //{
            //    if (txtFilterEndTime.Text.Trim() != string.Empty)
            //    {
            //        sqlstr.AppendFormat(" AND receiptDate <= '{0}' ", txtFilterEndTime.Text.Trim());
            //    }
            //}

            //if (txtFilterEndTime.Text.Trim() == string.Empty)
            //{
            //    if (txtFilterSatrtTime.Text.Trim() != string.Empty)
            //    {
            //        sqlstr.AppendFormat(" AND receiptDate >= '{0}' ", txtFilterSatrtTime.Text.Trim());
            //    }
            //}

            //if (txtFilterSatrtTime.Text.Trim() != string.Empty && txtFilterEndTime.Text.Trim() != string.Empty)
            //    sqlstr.AppendFormat(" AND ( receiptDate BETWEEN '{0}' AND '{1}' ) ", txtFilterSatrtTime.Text.Trim(), txtFilterEndTime.Text.Trim());


            Session["payAmountQuery"] = sqlstr;
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
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.txtunit.Value = "";
            this.ddlsyamount.SelectedIndex = 0;
            Session["payAmountQuery"] = "";
            LoadData();
        }

        /// <summary>
        /// 分页改变事件
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