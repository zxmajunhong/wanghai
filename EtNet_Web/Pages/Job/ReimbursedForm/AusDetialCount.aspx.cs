using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class AusDetialCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    PageSymbolNum();
                    QueryBuilder();
                    loadstatus();
                    loadperson();
                    loaditem();
                    loadtype();
                    loaddepart();
                    LoadAllAusDetial();
                }
            }

        }

        /// <summary>
        /// 加载审核状态
        /// </summary>
        private void loadstatus()
        {
            this.ddlauditstatus.Items.Clear();
            DataTable tbl = EtNet_BLL.JobAuditStatusManager.GetList("");
            DataRow row = tbl.NewRow();
            row["num"] = "00";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);

            row = tbl.NewRow();
            row["num"] = "-1";
            row["txt"] = "全部状态";
            tbl.Rows.InsertAt(row, 1);

            this.ddlauditstatus.DataSource = tbl;
            this.ddlauditstatus.DataTextField = "txt";
            this.ddlauditstatus.DataValueField = "num";
            this.ddlauditstatus.DataBind();
        }

        /// <summary>
        /// 加载人员数据
        /// </summary>
        private void loadperson()
        {
            this.ddlcname.Items.Clear();
            this.ddlperson.Items.Clear();
            IList<EtNet_Models.LoginInfo> list = EtNet_BLL.LoginInfoManager.getLoginInfoAll();

            this.ddlcname.DataSource = list;
            this.ddlcname.DataTextField = "cname";
            this.ddlcname.DataValueField = "cname";
            this.ddlcname.DataBind();
            this.ddlcname.Items.Insert(0, "——请选中——");

            this.ddlperson.DataSource = list;
            this.ddlperson.DataTextField = "cname";
            this.ddlperson.DataValueField = "cname";
            this.ddlperson.DataBind();
            this.ddlperson.Items.Insert(0, "——请选中——");
        }

        /// <summary>
        /// 加载项目类别
        /// </summary>
        private void loaditem()
        {
            this.ddlitem.Items.Clear();
            DataTable tbl = EtNet_BLL.AusItemInfoManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["itemname"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlitem.DataSource = tbl;
            this.ddlitem.DataTextField = "itemname";
            this.ddlitem.DataValueField = "itemname";
            this.ddlitem.DataBind();
        }

        /// <summary>
        /// 加载发票内容
        /// </summary>
        private void loadtype()
        {
            this.ddltype.Items.Clear();
            DataTable tbl = EtNet_BLL.AusTypeInfoManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["typename"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddltype.DataSource = tbl;
            this.ddltype.DataTextField = "typename";
            this.ddltype.DataValueField = "typename";

            this.ddltype.DataBind();
            
        }

        /// <summary>
        /// 加载部门数据
        /// </summary>
        private void loaddepart()
        {
            this.ddldepart.Items.Clear();

            IList<DepartmentInfo> depart = DepartmentInfoManager.getDepartmentAll();
            this.ddldepart.DataSource = depart;
            this.ddldepart.DataTextField = "departcname";
            this.ddldepart.DataValueField = "departcname";
            this.ddldepart.DataBind();
            this.ddldepart.Items.Insert(0, "——请选中——");
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBulider()
        {
            string sqlstr = "";
            string applydate = " convert(varchar(10),applydate,120) "; //报销日期
            string happendate = " convert(varchar(10),happendate,120) ";//发生日期
            if (this.txtje.Value != "")
            {
                sqlstr += " and ausmoney = " + this.txtje.Value.Trim();
            }
            if (this.ddlauditstatus.SelectedIndex != 0)
            {
                if (this.ddlauditstatus.SelectedIndex == 1 || this.ddlauditstatus.SelectedIndex == 0)
                {
                    sqlstr += " AND  auditstatus in('01','02','03','04') ";
                }
                else
                {
                    sqlstr += " AND  auditstatus='" + this.ddlauditstatus.SelectedValue + "'";
                }
            }
            else
            {
                sqlstr += " AND  auditstatus in('01','02','04') ";
            }
            if (this.ddlsavestatus.SelectedIndex != 0)
            {
                sqlstr += " and savestatus = '" + this.ddlsavestatus.SelectedValue + "'";
            }
            if (this.tbxnumber.Text != "")
            {
                sqlstr += " and bxdh like '%" + this.tbxnumber.Text.Trim() + "%' ";
            }
            if (this.ddlcname.SelectedIndex != 0)
            {
                sqlstr += " and applycantcname = '" + this.ddlcname.SelectedValue + "'";
            }
            if (this.ddlperson.SelectedIndex != 0)
            {
                sqlstr += " and Salesman = '" + this.ddlperson.SelectedValue + "'";
            }
            if (this.ddlitem.SelectedIndex != 0)
            {
                sqlstr += " and ausname = '" + this.ddlitem.SelectedValue + "'";
            }
            if (this.ddltype.SelectedIndex != 0)
            {
                sqlstr += " and austype = '" + this.ddltype.SelectedValue + "'";
            }
            if (this.ddldepart.SelectedIndex != 0)
            {
                sqlstr += " and belongsort = '" + this.ddldepart.SelectedValue + "'";
            }
            if (this.hidcdate.Value != "")
            {
                string[] list = this.hidcdate.Value.Split(',');
                if (list[0] != "" && list[1] != "")
                {
                    sqlstr += " and (" + applydate + " >= '" + list[0] + "' and " + applydate + " <= '" + list[1] + "')";
                }
                else if (list[0] != "" && list[1] == "")
                {
                    sqlstr += " and " + applydate + " >= '" + list[0] + "'";
                }
                else
                {
                    sqlstr += " and " + applydate + " <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.ddldate.SelectedValue)
                {
                    case "1":
                        sqlstr += " AND " + applydate + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "2":
                        sqlstr += " AND " + applydate + " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "3":
                        sqlstr += " AND " + applydate + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                        break;

                    case "4":
                        sqlstr += " AND ( " + applydate + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        sqlstr += " AND " + applydate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "5":
                        sqlstr += " AND ( " + applydate + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        sqlstr += " AND " + applydate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                }
            }

            if (this.hidhapendate.Value != "")
            {
                string[] list = this.hidhapendate.Value.Split(',');
                if (list[0] != "" && list[1] != "")
                {
                    sqlstr += " and (" + happendate + " >= '" + list[0] + "' and " + happendate + " <= '" + list[1] + "')";
                }
                else if (list[0] != "" && list[1] == "")
                {
                    sqlstr += " and " + happendate + " >= '" + list[0] + "'";
                }
                else
                {
                    sqlstr += " and " + happendate + " <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.happendate.SelectedValue)
                {
                    case "1":
                        sqlstr += " AND " + happendate + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "2":
                        sqlstr += " AND " + happendate + " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "3":
                        sqlstr += " AND " + happendate + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                        break;

                    case "4":
                        sqlstr += " AND ( " + happendate + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        sqlstr += " AND " + happendate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "5":
                        sqlstr += " AND ( " + happendate + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        sqlstr += " AND " + happendate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;
                }
            }

            Session["query"] = sqlstr;
        }

        /// <summary>
        /// 查询显示所有报销明细数据
        /// </summary>
        private void LoadAllAusDetial()
        {
            this.pages.Visible = true;
            double zje = 0;
            DataTable tbl = Exists();
            string str = "";
            int login = ((LoginInfo)Session["login"]).Id;
            string strlist = LoginDataLimitManager.GetLimit(login);
            if (strlist == null || strlist.Trim() == "")
            {
                str = " AND founderid in (" + login + ")";
            }
            else
            {
                str = " AND founderid in (" + login + "," + strlist + ")";
            }

            str += Session["query"];
            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet set = data.DataPage("View_AllAusDetial", "bxdh", "*", str, "applydate", true, pitem, pcount, pages);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                zje += set.Tables[0].Rows[i]["ausmoney"].ToString() == "" ? 0.00 : Convert.ToDouble(set.Tables[0].Rows[i]["ausmoney"]);
            }


            this.rptdata.DataSource = set;
            this.rptdata.DataBind();

            this.zje.Text = zje.ToString("0.00");
        }

        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='025'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "025";
                pageset.Pagecount = 5;
                pageset.Pageitem = 15;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }

        /// <summary>
        /// 页面数字标识
        /// </summary>
        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = ""; //如无PageNum，先生成一个
            }
            if (Session["PageNum"].ToString() != "025")
            {
                Session["PageNum"] = "025";
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 显示时间
        /// </summary>
        public string ShowDate(string strdate)
        {
            return Convert.ToDateTime(strdate).ToString("yyyy-MM-dd");

        }

        /// <summary>
        /// 依据不同的审批状态，显示不同颜色
        /// </summary>
        public string ShowColor(string str)
        {
            string result = "";
            switch (str)
            {
                case "未开始":
                case "被拒绝":
                    result = "<span style='color:Red'>" + str + "</span>";
                    break;

                case "已通过":
                    result = "<span style='color:Green'>" + str + "</span>";
                    break;
                default:
                    result = str;
                    break;
            }
            return result;
        }


        /// <summary>
        /// 显示金额
        /// </summary>
        public string ShowMoney(string strmoney)
        {
            string result = "";
            result += Decimal.Round(Decimal.Parse(strmoney), 2).ToString();
            return result;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBulider();
            LoadAllAusDetial();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.txtje.Value = "";
            this.ddlauditstatus.SelectedIndex = 0;
            this.ddlsavestatus.SelectedIndex = 0;
            this.tbxnumber.Text = "";
            this.ddlcname.SelectedIndex = 0;
            this.ddlperson.SelectedIndex = 0;
            this.ddlitem.SelectedIndex = 0;
            this.ddltype.SelectedIndex = 0;
            this.ddldepart.SelectedIndex = 0;
            this.ddldate.SelectedIndex = 0;
            this.hidcdate.Value = "";
            this.happendate.SelectedIndex = 0;
            this.hidhapendate.Value = "";
            Session["query"] = "";
            LoadAllAusDetial();
        }

    }
}