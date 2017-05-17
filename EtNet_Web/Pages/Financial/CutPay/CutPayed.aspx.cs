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
    public partial class CutPayed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cList = (CutPayList)Context.Handler;
                LoadOrderInfo();
            }
        }

        public CutPayList cList;

        /// <summary>
        /// 加载订单收款信息
        /// </summary>
        private void LoadOrderInfo()
        {
            //CutPayList cList = (CutPayList)Context.Handler;
            string id = Request.QueryString["id"];
            id = "(" + id + ")";
            string sort = Request.QueryString["sort"];
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            switch (sort)
            {
                case "0":
                    this.czy.Visible = false;
                    string sql = " and collectId in " + id;
                    DataSet ds = data.DataPage("View_OrderAndClollect", "collectId", "*", sql, "orderNum", false, 5, 5, pages);
                    payRepeater.DataSource = ds;
                    payRepeater.DataBind();
                    sql = " 1=1 " + sql;
                    DataTable dt0 = To_OrderInfoManager.GetViewOrderAndCollect("sum(adultNum)+sum(childNum) as num,sum(lirun) as lirun", sql);
                    if (dt0.Rows.Count > 0)
                    {
                        this.sumNum.InnerText = dt0.Rows[0]["num"].ToString();
                        this.sumlirun.InnerText = dt0.Rows[0]["lirun"].ToString();
                    }
                    break;
                case "1":
                    this.ywy.Visible = false;
                    string str = " and id in " + id;
                    DataSet dt = data.DataPage("To_orderInfo", "id", "*", str, "orderNum", false, 5, 5, pages);
                    czyRepeater.DataSource = dt;
                    czyRepeater.DataBind();
                    str = " 1=1 " + str;
                    DataTable dt1 = To_OrderInfoManager.getList("sum(inputerTc) as inputerTc", str);
                    if (dt1.Rows.Count > 0)
                    {
                        this.suminputerTc.InnerText = dt1.Rows[0]["inputerTc"].ToString();
                    }
                    break;
            }

        }

        /// <summary>
        /// 更新收款信息的提成发放状态
        /// </summary>
        private void UpdateOrderCollect()
        {
            string id = Request.QueryString["id"];
            string sort = Request.QueryString["sort"];
            id = "(" + id + ")";
            string status = this.tc_yes.Checked ? "是" : "否";
            string strWhere = " id in " + id;
            switch (sort)
            {
                case"0":
                    To_OrderCollectDetialManager.updateDetialCutStatus(strWhere, status);
                    break;
                case"1":
                    To_OrderInfoManager.updateInputerTcStatus(strWhere, status);
                    break;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert('更新成功');", true);
        }



        /// <summary>
        /// 得到提成金额
        /// </summary>
        /// <param name="money">收款金额</param>
        /// <param name="number">成人数</param>
        /// <param name="cusID">收款单位id</param>
        /// <returns></returns>
        public string GetMoney(string money, string number, string cusID)
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

                double dmoney = 0;
                double dnumber = 0;
                double.TryParse(money, out dmoney);
                double.TryParse(number, out dnumber);

                double cutmoney = dnumber * ratio * dmoney; //得到提成金额
                return cutmoney.ToString("F2");
            }
            else
                return "参数错误，找不到指定单位";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            UpdateOrderCollect();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CutPayList.aspx");
        }

    }
}