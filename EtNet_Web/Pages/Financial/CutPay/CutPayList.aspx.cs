using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Financial.CutPay
{
    public partial class CutPayList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalesman();
                QueryBuilder();
                LoadOrderList();
                LoadInputerList();
            }
        }

        /// <summary>
        /// 保存数据列表
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["cutPay"] == null)
            {
                Session["cutPay"] = "";
            }
            else
            {
                string value = Session["cutPay"].ToString();
                if (value != "")
                {
                    string selectvalue = (value.Split('='))[1].Trim();
                    this.salesmans.SelectedValue = selectvalue;
                }
            }
            if (Session["inputercutPay"] == null)
            {
                Session["inputercutPay"] = "";
            }
            else
            {
                string value = Session["inputercutPay"].ToString();
                if (value != "")
                {
                    string selectvalue = (value.Split('='))[1].Trim();
                    this.inputers.SelectedValue = selectvalue;
                }
            }
        }

        /// <summary>
        /// 加载业务员和操作员信息信息
        /// </summary>
        private void LoadSalesman()
        {
            this.salesmans.Items.Clear();
            this.inputers.Items.Clear();
            this.salesmans.Items.Add(new ListItem("——请选择——", "0"));
            this.inputers.Items.Add(new ListItem("——请选择——", "0"));
            IList<LoginInfo> logins = LoginInfoManager.getLoginInfoAll();
            foreach (LoginInfo login in logins)
            {
                ListItem adItem = new ListItem();
                adItem.Value = login.Id.ToString();
                adItem.Text = login.Cname;
                this.salesmans.Items.Add(adItem);
                this.inputers.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 业务员改变时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void salesmans_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = this.ywu_status.SelectedValue;
            string strWhere = " and salemanid = " + this.salesmans.SelectedValue;
            if (status != "全部")
                strWhere += " and cutPayStatus = '" + status + "'";
            Session["cutPay"] = strWhere;
            LoadOrderList();
        }


        /// <summary>
        /// 业务员发放状态改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ywu_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = this.ywu_status.SelectedValue;
            string strWhere = " and salemanid = " + this.salesmans.SelectedValue;
            if (status != "全部")
                strWhere += " and cutPayStatus = '" + status + "'";
            Session["cutPay"] = strWhere;
            LoadOrderList();
        }

        /// <summary>
        /// 操作员改变时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void inputers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = this.czy_status.SelectedValue;
            string strWhere = " and inputerId = " + this.inputers.SelectedValue;
            if (status != "全部")
                strWhere += " and inputerTc_status = '" + status + "'";
            Session["inputercutPay"] = strWhere;
            LoadInputerList();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script>document.getElementById('a2').click()</script>");
        }

        /// <summary>
        /// 操作员发放状态改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void czy_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = this.czy_status.SelectedValue;
            string strWhere = " and inputerId = " + this.inputers.SelectedValue;
            if (status != "全部")
                strWhere += " and inputerTc_status = '" + status + "'";
            Session["inputercutPay"] = strWhere;
            LoadInputerList();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ggg", "<script>document.getElementById('a2').click()</script>");
        }

        /// <summary>
        /// 加载订单数据
        /// </summary>
        private void LoadOrderList()
        {
            if (Session["login"] == null)
                Response.Redirect("~/Login.aspx", true);
            else
            {
                LoginInfo login = Session["login"] as LoginInfo;
                if (Session["cutPay"].ToString() != "")
                {
                    string sql = " collectStatus='完成收款' ";
                    sql += Session["cutPay"].ToString();
                    EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
                    SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 033);
                    if (sps != null)
                    {
                        this.j_pagesize.Value = sps.Pageitem.ToString();
                        this.j_pagecount.Value = sps.Pagecount.ToString();
                    }
                    this.payRepeater.DataSource = To_OrderInfoManager.GetViewOrderAndCollect("*", sql);
                    this.payRepeater.DataBind();
                }
            }
        }

        /// <summary>
        /// 加载操作员的提成数据
        /// </summary>
        private void LoadInputerList()
        {
            if (Session["inputercutPay"].ToString() != "")
            {
                string sql = " 1=1 ";
                sql += Session["inputercutPay"];
                this.inputerTc.DataSource = To_OrderInfoManager.GetList(0, sql, "outTime");
                this.inputerTc.DataBind();
            }
        }


        /// <summary>
        /// 提成发放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgread_Click(object sender, ImageClickEventArgs e)
        {
            string conid = "";
            //先遍历取得选中项
            if (hidtcsort.Value == "0")
            {
                for (int i = 0; i < this.payRepeater.Items.Count; i++)
                {
                    CheckBox cbx = (CheckBox)payRepeater.Items[i].FindControl("cbx");
                    Label lbl = (Label)payRepeater.Items[i].FindControl("lbl");
                    if (cbx != null || lbl != null)
                    {
                        if (cbx.Checked)
                        {
                            conid += lbl.Text + ",";
                        }
                    }
                }
            }
            if (hidtcsort.Value == "1")
            {
                for (int i = 0; i < this.inputerTc.Items.Count; i++)
                {
                    CheckBox cbx = (CheckBox)inputerTc.Items[i].FindControl("cbx1");
                    Label lbl = (Label)inputerTc.Items[i].FindControl("lbl1");
                    if (cbx != null || lbl != null)
                    {
                        if (cbx.Checked)
                        {
                            conid += lbl.Text + ",";
                        }
                    }
                }
            }
            //去掉最后一个，
            conid = (conid + ")").Replace(",)", "");
            //Id = conid;
            //sort = hidtcsort.Value;
            //Server.Transfer("CutPayed.aspx", true);

            Response.Redirect("CutPayed.aspx?id=" + conid + "&sort=" + hidtcsort.Value);
        }



        public string Id
        {
            get;
            set;
        }

        public string sort
        {
            get;
            set;
        }

        /// <summary>
        /// 得到提成金额
        /// </summary>
        /// <param name="money">收款金额</param>
        /// <param name="number">成人数</param>
        /// <param name="cusID">收款单位id</param>
        /// <returns></returns>
        public string GetMoney(string number, string cusID)
        {
            Customer model = CustomerManager.getCustomerById(int.Parse(cusID));
            if (model != null)
            {
                //计算客户等级
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(model.CompanyURL);
                int Days = ts.Days;
                double ratio = 0; //提成系数
                if (Days > 365)
                {
                    if (model.CusPro != 1)
                    {
                        CustomerManager.updateCustomenPro(cusID, "1");
                    }
                    ratio = model.oldRatio; //老客户提成系数
                }
                else
                    ratio = model.newRatio;

                double dnumber = 0;
                double.TryParse(number, out dnumber);

                double cutmoney = dnumber * ratio; //得到提成金额
                return cutmoney.ToString("F2");
            }
            else
                return "参数错误，找不到指定单位";
        }
    }
}