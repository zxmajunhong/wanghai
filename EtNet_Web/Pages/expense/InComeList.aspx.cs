using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;
using EtNet_BLL.DataPage;
using System.Text;
using System.IO;

namespace EtNet_Web.Pages.expense
{
    public partial class InComeList : System.Web.UI.Page
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
                BindType();
                Load_IncomeList();
            }
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

        /// <summary>
        /// 绑定收款类别
        /// </summary>
        private void BindType()
        {
            ddlsktype.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = IncomeTypeManager.GetList("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Text = dt.Rows[i]["typename"].ToString();
                adItem.Value = dt.Rows[i]["id"].ToString();
                ddlsktype.Items.Add(adItem);
            }
        }

        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = "";
            }
            if (Session["PageNum"].ToString() != "035")
            {
                Session["PageNum"] = "035";
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
        /// 绑定收款列表
        /// </summary>
        private void Load_IncomeList()
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
            AspNetPager1.RecordCount = data.GetCount("To_Income", sqlstr);
            DataTable dt = data.GetList("To_Income", "comeDate", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            inList.DataSource = dt;
            inList.DataBind();
            // 获取收款金额合计
            double amount = To_IncomeManager.GetMoneyAmount(sqlstr);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        zje += dt.Rows[i]["comeMoney"].ToString() == "" ? 0.00 : Convert.ToDouble(dt.Rows[i]["comeMoney"]);
            //    }
            //}
            this.zje.Text = amount.ToString("0.00");

        }

        /// <summary>
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Load_IncomeList();
        }

        protected void inList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirect", "<script>window.open('../../Pages/expense/InComeUpdate.aspx?id=" + Id + "', '_blank')</script>");
                    break;
                case "Detail":
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirect", "<script>window.open('../../Pages/expense/InComeDetail.aspx?id=" + Id + "', '_blank')</script>");
                    //Response.Redirect("InComeDetail.aspx?id=" + Id);
                    break;
                case "Delete":
                    Del(int.Parse(Id));
                    break;
            }
            Load_IncomeList();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        private void Del(int id)
        {
            int result = To_IncomeManager.Delete(id);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            Load_IncomeList();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            ddlRequestDate.SelectedIndex = -1;
            hidDateValue.Value = "";
            ddlAcount.SelectedIndex = 0;
            ddlDepart.SelectedIndex = 0;
            ddlsktype.SelectedIndex = 0;
            textMakeName.Value = "";
            Session["query"] = "";
            Load_IncomeList();
        }

        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            if (this.ddlAcount.SelectedIndex > 0)
            {
                sqlstr.AppendFormat(" and comeBankId = {0}", this.ddlAcount.SelectedValue);
            }
            if (this.ddlDepart.SelectedIndex > 0)
            {
                sqlstr.AppendFormat(" and comeDepartId = {0}", this.ddlDepart.SelectedValue);
            }
            if (this.txtFkUnit.Value.Trim() != "")
            {
                sqlstr.AppendFormat(" and comeUnit like '%{0}%' ", this.txtFkUnit.Value.Trim());
            }
            if (this.ddlsktype.SelectedIndex > 0)
            {
                sqlstr.AppendFormat(" and comeTypeid ={0}", this.ddlsktype.SelectedValue);
            }
            if (this.textMakeName.Value != "")
            {
                sqlstr.AppendFormat(" and makeName = '{0}'", this.textMakeName.Value.Trim());
            }
            if (this.txtremark.Value != "")
            {
                sqlstr.AppendFormat(" and remark like '%{0}%' ", this.txtremark.Value.Trim());
            }
            if(this.iptmoney.Value!="")//0419,增加内容：可根据收款金额进行模糊搜索
            {
                sqlstr.AppendFormat(" and comeMoney like '%{0}%' ", this.iptmoney.Value.Trim());
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');
                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" and ( comeDate >= '{0}' and comeDate <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" and comeDate >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" and comeDate <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND comeDate = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND comeDate < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND comeDate = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( comeDate >= '{0}' AND comeDate<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( comeDate >= '{0}' AND comeDate<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
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
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

          sb.Append("<table><tr><td>收款日期</td><td>收款金额</td><td>付款单位</td><td>入账银行</td><td>所属部门</td><td>收款类别</td><td>制单员</td><td>备注</td></tr>");
          
          // 生成列表数据
          string sqlstr = " 1=1 ";
          sqlstr += Session["query"].ToString();
          sqlstr += " order by comeDate desc";
          DataTable dt = To_IncomeManager.GetList(sqlstr);
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            sb.Append("<tr>");
            sb.Append("<td>" + Convert.ToDateTime(dt.Rows[i]["comeDate"]).ToString("yyyy-MM-dd") + "</td>");
            sb.Append("<td>" + dt.Rows[i]["comeMoney"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["comeUnit"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["comeBankName"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["comeDepart"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["comeType"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["makeName"] + "</td>");
            sb.Append("<td>" + dt.Rows[i]["remark"] + "</td>");
            sb.Append("</tr>");
          }
          // 增加合计行
          sb.Append("<tr><td>合计</td><td>" + this.zje.Text + "</td></tr>");

          // 增加表尾
          sb.Append("</table></body></html>");

          // 导出
          StringWriter sw = new StringWriter();
          sw.WriteLine(sb.ToString());
          sw.Close();
          Response.Clear();
          Response.Charset = "utf-8";
          System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=其他收款列表.xls");
          System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
          System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
          System.Web.HttpContext.Current.Response.Write(sw);
          System.Web.HttpContext.Current.Response.End();
        }
    }
}