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
using System.IO;

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
            // 获取金额合计
            double amount = To_OutcomeManager.GetMoneyAmount(sqlstr);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        zje += dt.Rows[i]["outComeMoney"].ToString() == "" ? 0.00 : Convert.ToDouble(dt.Rows[i]["outComeMoney"]);
            //    }
            //}
            this.zje.Text = amount.ToString("0.00");
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
                    //Response.Redirect("OutComeUpdate.aspx?id=" + Id);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirect", "<script>window.open('../../Pages/expense/OutComeUpdate.aspx?id=" + Id + "', '_blank')</script>");
                    break;
                case "Detail":
                    //Response.Redirect("OutComeDetail.aspx?id=" + Id);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirect", "<script>window.open('../../Pages/expense/OutComeDetail.aspx?id=" + Id + "', '_blank')</script>");
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

        protected void ibtexport_Click(object sender, ImageClickEventArgs e)
        {
          // excel 头部
          StringBuilder sb = new StringBuilder();
          sb.Append("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
          sb.Append(" <head>");
          sb.Append(" <!--[if gte mso 9]><xml>");
          sb.Append("<x:ExcelWorkbook>");
          sb.Append("<x:ExcelWorksheets>");
          sb.Append("<x:ExcelWorksheet>");
          sb.Append("<x:Name></x:Name>");
          sb.Append("<x:WorksheetOptions>");
          sb.Append("<x:Print>");
          sb.Append("<x:ValidPrinterInfo />");
          sb.Append(" </x:Print>");
          sb.Append("</x:WorksheetOptions>");
          sb.Append("</x:ExcelWorksheet>");
          sb.Append("</x:ExcelWorksheets>");
          sb.Append("</x:ExcelWorkbook>");
          sb.Append("</xml>");
          sb.Append("<![endif]-->");
          sb.Append(" </head>");
          sb.Append("<body>");

          sb.Append("<table><tr><td>支付状态</td><td>付款日期</td><td>付款类别</td><td>收款单位</td><td>付款金额</td><td>付款银行</td><td>所属部门</td><td>制单员</td><td>备注</td></tr>");

          // 生成列表数据
          string sqlstr = " 1=1 ";
          sqlstr += Session["query"].ToString();
          sqlstr += " order by outComeDate desc";
          DataTable dt = To_OutcomeManager.GetList(sqlstr);
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            sb.Append("<tr>");
            sb.Append("<td>" + (dt.Rows[i]["outComeStatus"].ToString() == "1" ? "已支付" : "未支付") + "</td>");
            sb.Append("<td>" + Convert.ToDateTime(dt.Rows[i]["outComeDate"]).ToString("yyyy-MM-dd") + "</td>");
            sb.Append("<td>" + dt.Rows[i]["outComeItem"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["comeUnit"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["outComeMoney"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["outComeBankName"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["outComeDepart"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["makeName"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["remark"] + "</td>");
            sb.Append("</tr>");
          }
          // 增加合计行
          sb.Append("<tr><td>合计</td><td></td><td></td><td></td><td>" + this.zje.Text + "</td></tr>");

          // 增加表尾
          sb.Append("</table></body></html>");

          // 导出
          StringWriter sw = new StringWriter();
          sw.WriteLine(sb.ToString());
          sw.Close();
          Response.Clear();
          Response.Charset = "utf-8";
          System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=其他付款列表.xls");
          System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
          System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
          System.Web.HttpContext.Current.Response.Write(sw);
          System.Web.HttpContext.Current.Response.End();
        }
    }
}