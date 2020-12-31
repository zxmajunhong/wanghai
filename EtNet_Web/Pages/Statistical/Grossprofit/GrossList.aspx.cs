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

namespace EtNet_Web.Pages.Statistical.Grossprofit
{
    public partial class GrossList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLine();
                BindInputer();
                QueryBulider();
                LoadData();
            }
        }

        /// <summary>
        /// 绑定线路
        /// </summary>
        private void BindLine()
        {
            ddlline.Items.Clear();
            IList<Tb_line> linelist = Tb_lineManager.getTb_lineAll();
            ddlline.Items.Add(new ListItem("选择线路", "-1")); //添加第一行默认
            foreach (Tb_line line in linelist)
            {
                ListItem adItem = new ListItem();
                adItem.Text = line.Line;
                adItem.Value = line.Line;
                ddlline.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 绑定操作人员
        /// </summary>
        private void BindInputer()
        {
            ddlinputer.Items.Clear();
            IList<LoginInfo> loginlist = LoginInfoManager.getLoginInfoAll();
            ddlinputer.Items.Add(new ListItem("选择人员", "-1"));
            foreach (LoginInfo login in loginlist)
            {
                ListItem adItem = new ListItem();
                adItem.Text = login.Cname;
                adItem.Value = login.Id.ToString();
                ddlinputer.Items.Add(adItem);
            }
        }


        /// <summary>
        /// 初始化筛选条件
        /// </summary>
        private void QueryBulider()
        {
            if (Session["orderGrossQuery"] == null)
            {
                Session["orderGrossQuery"] = getCurYearFilter();
            }
        }

        /// <summary>
        /// 获取当前年份的筛选条件
        /// </summary>
        /// <returns></returns>
        private string getCurYearFilter()
        {
          int year = DateTime.Now.Year;
          string filter = " and (outTime >= '" + year.ToString() + "-01-01 00:00:00' and outTime <= '" + year.ToString() + "-12-31 23:59:59')";
          return filter;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            string sqlstr = " and iscancel = 'N' ";
            sqlstr += this.cbxFileShow.Checked ? " " : " and fileStatus=0 ";
            sqlstr += Session["orderGrossQuery"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 036);
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("ViewOrderGrossList", sqlstr);
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
            DataTable dt = data.GetList("ViewOrderGrossList", "id", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            rpgrossdata.DataSource = dt;
            rpgrossdata.DataBind();

            //计算金额合计
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("select sum(collectShould) as scshould,sum(collectAmount) as scamount,sum(collectSy) as scsy,");
            sqlSelect.Append("sum(payShould) as spshould,sum(payAmount) as spamount,sum(paySy) as spsy,");
            sqlSelect.Append("sum(refuShould) as srshould,sum(refundAmount) as sramount,sum(refuSy) as srsy,");
            sqlSelect.Append("sum(reimShould) as sbx,sum(gross_bx) as sml ");
            string tblname = "ViewOrderGrossList";
            DataTable dtSum = data.GetSumMoney(sqlSelect.ToString(), tblname, sqlstr);
            if (dtSum.Rows.Count > 0)
            {
                DataRow dr = dtSum.Rows[0];
                scshould.InnerText = Convert.IsDBNull(dr["scshould"]) ? "" : (Convert.ToDouble(dr["scshould"])).ToString("N2");
                scamount.InnerText = Convert.IsDBNull(dr["scamount"]) ? "" : (Convert.ToDouble(dr["scamount"])).ToString("N2");
                scsy.InnerText = Convert.IsDBNull(dr["scsy"]) ? "" : (Convert.ToDouble(dr["scsy"])).ToString("N2");
                spshould.InnerText = Convert.IsDBNull(dr["spshould"]) ? "" : (Convert.ToDouble(dr["spshould"])).ToString("N2");
                spamount.InnerText = Convert.IsDBNull(dr["spamount"]) ? "" : (Convert.ToDouble(dr["spamount"])).ToString("N2");
                spsy.InnerText = Convert.IsDBNull(dr["spsy"]) ? "" : (Convert.ToDouble(dr["spsy"])).ToString("N2");
                srshould.InnerText = Convert.IsDBNull(dr["srshould"]) ? "" : (Convert.ToDouble(dr["srshould"])).ToString("N2");
                sramount.InnerText = Convert.IsDBNull(dr["sramount"]) ? "" : (Convert.ToDouble(dr["sramount"])).ToString("N2");
                srsy.InnerText = Convert.IsDBNull(dr["srsy"]) ? "" : (Convert.ToDouble(dr["srsy"])).ToString("N2");
                sbx.InnerText = Convert.IsDBNull(dr["sbx"]) ? "" : (Convert.ToDouble(dr["sbx"])).ToString("N2");
                sml.InnerText = Convert.IsDBNull(dr["sml"]) ? "" : (Convert.ToDouble(dr["sml"])).ToString("N2");
            }

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

        /// <summary>
        /// 得到收款明细信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getCollectDetail(object orderid)
        {
            //return "得到收款明细";
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' >");
            str.Append("<tr><th width='200px'>收款单位</th><th width='50px'>成人</th><th width='50px'>儿童</th><th width='50px'>陪同</th><th width='80px'>应收团款</th><th width='80px'>已收团款</th><th width='80px'>未收团款</th><th width='80px'>业务提成</th></tr>");
            DataTable dt = To_OrderCollectDetialManager.getList(int.Parse(orderid.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double money = Convert.IsDBNull(dt.Rows[i]["money"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["money"]);
                double collectAmount = Convert.IsDBNull(dt.Rows[i]["collectAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["collectAmount"]);
                str.Append("<tr><td>" + dt.Rows[i]["cusName"].ToString() + "</td>"); //收款单位
                str.Append("<td>" + dt.Rows[i]["adultNum"].ToString() + "</td>"); //成人数
                str.Append("<td>" + dt.Rows[i]["childNum"].ToString() + "</td>"); //儿童数
                str.Append("<td>" + dt.Rows[i]["withNum"].ToString() + "</td>"); //陪同数
                str.Append("<td>" + money.ToString() + "</td>"); //应收团款
                str.Append("<td>" + collectAmount.ToString() + "</td>"); //已收团款
                str.Append("<td>" + (money - collectAmount).ToString() + "</td>"); //未收团款
                str.Append("<td>" + dt.Rows[i]["cutPayStatus"].ToString() + "</td></tr>"); //业务提成
            }

            str.Append("</table>");

            return str.ToString();
        }

        /// <summary>
        /// 得到付款明细
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getPayDetail(object orderid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' >");
            str.Append("<tr><th width='200px'>付款单位</th><th width='80px'>付款类别</th><th width='80px'>应付金额</th><th width='80px'>已付金额</th><th width='80px'>未付金额</th></tr>");
            DataTable dt = To_OrderPayDetialManager.getList(int.Parse(orderid.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double money = Convert.IsDBNull(dt.Rows[i]["money"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["money"]); //应付金额
                double payAmount = Convert.IsDBNull(dt.Rows[i]["payAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["payAmount"]);
                str.Append("<tr><td>" + dt.Rows[i]["supName"].ToString() + "</td>"); //付款单位
                str.Append("<td>" + dt.Rows[i]["payType"].ToString() + "</td>"); //付款类别
                str.Append("<td>" + money.ToString() + "</td>"); //应付金额
                str.Append("<td>" + payAmount.ToString() + "</td>"); //已付金额
                str.Append("<td>" + (money - payAmount).ToString() + "</td></tr>"); //未付金额
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 得到退款明细
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getRefDetail(object orderid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1' >");
            str.Append("<tr><th width='200px'>退款单位</th><th width='80px'>应退金额</th><th width='80px'>已退金额</th><th width='80px'>未退金额</th></tr>");
            DataTable dt = To_OrderRefunDetialManager.getList(int.Parse(orderid.ToString()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double money = Convert.IsDBNull(dt.Rows[i]["money"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["money"]);
                double refAmount = Convert.IsDBNull(dt.Rows[i]["refundAmount"]) ? 0.0 : Convert.ToDouble(dt.Rows[i]["refundAmount"]);
                str.Append("<tr><td>" + dt.Rows[i]["cusName"].ToString() + "</td>"); //退款单位
                str.Append("<td>" + money.ToString() + "</td>"); //应退金额
                str.Append("<td>" + refAmount.ToString() + "</td>"); //已退金额
                str.Append("<td>" + (money - refAmount).ToString() + "</td>"); //未退金额
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 得到报销明细
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string getReimDetail(object orderid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border='1'>");
            str.Append("<tr><th width='100px'>报销单号</th><th width='80px'>报销金额</th><th width='100px'>项目类别</th></tr>");
            DataTable dt = AusRottenInfoManager.GetViewList("  orderid= " + orderid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str.Append("<tr><td>" + dt.Rows[i]["jobflowcname"].ToString() + "</td>"); //报销单号
                str.Append("<td>" + dt.Rows[i]["totalmoney"].ToString() + "</td>");
                str.Append("<td>" + dt.Rows[i]["itemtype"].ToString() + "</td>");
            }
            str.Append("</table>");
            return str.ToString();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            if (txtOrderNum.Value != "")
            {
                sqlstr.Append(" and orderNum like '%" + txtOrderNum.Value + "%'");
            }
            if (ddlline.SelectedIndex != 0)
            {
                sqlstr.Append(" and line ='" + ddlline.SelectedValue + "'");
            }
            if (txtDepart.Value != "")
            {
                sqlstr.Append(" and departautocode like '%" + txtDepart.Value + "%'");
            }
            if (ddlnature.SelectedIndex != 0)
            {
                sqlstr.Append(" and natrue ='" + ddlnature.SelectedValue + "'");
            }
            if (ddlinputer.SelectedIndex != 0)
            {
                sqlstr.Append(" and inputerID =" + ddlinputer.SelectedValue);
            }
            if (ddlcollectstatus.SelectedIndex != 0)
            {
                sqlstr.Append(" and collectStatus = '" + ddlcollectstatus.SelectedValue + "'");
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
            else
            {
              sqlstr.AppendFormat(getCurYearFilter());
            }

            Session["orderGrossQuery"] = sqlstr;
        }

        /// <summary>
        /// 筛选
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
            txtOrderNum.Value = "";
            txtDepart.Value = "";
            ddlline.SelectedIndex = 0;
            ddlnature.SelectedIndex = 0;
            ddlinputer.SelectedIndex = 0;
            ddlcollectstatus.SelectedIndex = 0;
            ddlRequestDate.SelectedIndex = 0;
            hidDateValue.Value = "";
            Session["orderGrossQuery"] = "";
            LoadData();
        }

        protected void cbxFileShow_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void daochu1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "GB2312";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("毛利表统计") + "" + System.DateTime.Now.Date + ".xls");

            // 如果设置为 GetEncoding("GB2312");导出的文件将会出现乱码！！！
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。

            //Response.ContentType = "application/vnd.ms-excel";//输出类型
            //Response.Charset = "";

            //关闭 ViewState
            flexigrid.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();//将信息写入字符串
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);//在WEB窗体页上写出一系列连续的HTML特定字符和文本。
            //此类提供ASP.NET服务器控件在将HTML内容呈现给客户端时所使用的格式化功能
            //获取control的HTML

            flexigrid.RenderControl(hw);//将table中的内容输出到HtmlTextWriter对象中

            // 把HTML写回浏览器
            Response.Write(tw.ToString());
            Response.Flush();
            Response.End();

        }
    }
}