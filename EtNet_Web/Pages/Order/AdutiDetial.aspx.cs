using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using System.IO;
using EtNet_BLL;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Order
{
    public partial class AdutiDetial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrderLoad();
            }

        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void OrderLoad()
        {
            //string jfId = Request.QueryString["jobflowid"].ToString();
            //string sqlstring = " jobflowID=" + jfId;
            //DataTable dtOrder = To_OrderInfoManager.GetLists(sqlstring);
            //if (dtOrder.Rows.Count == 0)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "audit", "alert('数据出错，订单可能已删除！');location.href='../Job/AuditJobFlow.aspx'", true);
            //    return;
            //}
            int id = Convert.ToInt32(Request.QueryString["id"]);
            //int id = Convert.ToInt32(dtOrder.Rows[0]["id"]);

            To_OrderInfo order = To_OrderInfoManager.getTo_OrderInfoById(id);

            DataTable dt = To_OrderInfoManager.GetLists(" id = " + id);

            this.lblOrderCode.Text = order.OrderNum.ToString();
            this.lblOrderType.Text = Convert.ToInt32(order.OrderType) == 1 ? "常规订单" : "非常规订单";
            this.lblOutDate.Text = order.OutTime.ToShortDateString();
            this.lblTotal.Text = order.TeamNum.ToString();
            this.lblnature.Text = order.Natrue.ToString();
            this.lblyjml.Text = order.Gross.ToString("F2"); //预计毛利
            this.lblLine.Text = GetLineName(order.Tour); //线路
            this.lblLineremark.Text = order.TourRemark; //线路描述
            this.lblMarkTime.Text = order.MakerTime.ToShortDateString();
            this.lblMakeID.Text = order.MakerName.ToString();
            this.lblinputer.Text = order.Inputer; //操作人员
            //收款
            decimal col = LoadCol(id);
            //付款
            decimal pay = LoadPay(id);
            //退款
            decimal ret = LoadRet(id);
            //报销
            decimal reim = LoadRem(id);

            this.lblsjml.Text = (col - pay + ret - reim).ToString("F2");

            LoadAuditImg(int.Parse(dt.Rows[0]["ruleid"].ToString()));
            optiniontxt.InnerHtml = ShowOpiniontxt(int.Parse(dt.Rows[0]["jobflowid"].ToString()));//审核人意见
            LoadNowAudit(dt.Rows[0]["jobflowid"].ToString());


        }

        /// <summary>
        /// 得到线路名称
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string GetLineName(string line)
        {
            int lineId = 0;
            int.TryParse(line, out lineId);
            Tb_line lineModel = Tb_lineManager.getTb_lineById(lineId);
            if (lineModel != null)
            {
                return lineModel.Line;
            }
            else
            {
                return "线路未知";
            }
        }


        /// <summary>
        /// 加载当前审核人员的情况
        /// </summary>
        private void LoadNowAudit(string jfid)
        {
            string strsql = " auditstatus in('03','04') AND id=" + jfid;
            DataTable tbl = EtNet_BLL.JobFlowManager.GetList(strsql);
            if (tbl.Rows.Count == 0)
            {
                strsql = "nowreviewer='T' AND jobflowid=" + jfid;
                tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList("reviewerid", strsql);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (this.hidlist.Value == "")
                    {
                        this.hidlist.Value = tbl.Rows[i]["reviewerid"].ToString();
                    }
                    else
                    {
                        this.hidlist.Value += "," + tbl.Rows[i]["reviewerid"].ToString();
                    }
                }
            }
            else
            {
                this.hidlist.Value = "0"; //代表审核结束
            }
        }
        /// <summary>
        /// 报销
        /// </summary>
        /// <param name="id"></param>
        private decimal LoadRem(int id)
        {
            ////tablerem
            //DataTable dt = To_OrderReimDetialManager.getList(id);

            //DataTable dtRem = AusOrderInfoManager.GetListBysql(" orderid =" + id);

            decimal moneyAmount = 0;
            decimal reimMoney = 0;
            decimal hasAmount = 0;
            DataTable dt = AusRottenInfoManager.GetViewList("  orderid= " + id);
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.Attributes.CssStyle.Add("height", "20px");
                    cell.InnerHtml = dt.Rows[i]["jobflowcname"].ToString();
                    row.Controls.Add(cell);


                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["itemtype"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    reimMoney = 0;
                    decimal.TryParse((dt.Rows[i]["totalmoney"]).ToString(), out reimMoney);
                    cell.InnerHtml = reimMoney.ToString("F2");
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["remark"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["auditstutastxt"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["payStatus"].ToString() == "1" ? "已支付" : "未支付";
                    row.Controls.Add(cell);

                    this.tablerem.Controls.Add(row);

                    moneyAmount += reimMoney;
                    if (dt.Rows[i]["payStatus"].ToString() == "1")
                    {
                        hasAmount += reimMoney;
                    }
                }

                this.lblReimAmount.InnerText = moneyAmount.ToString("F2");
            }

            return hasAmount;
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="id"></param>
        private decimal LoadRet(int id)
        {
            decimal moneyAmount = 0;
            decimal outmoney = 0;
            decimal hasAmount = 0;
            DataTable dt = To_OrderRefunDetialManager.getList(id);
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string[] result = GetReturnStatusAndMoney(dt.Rows[i]["orderid"].ToString(), dt.Rows[i]["cusid"].ToString(), dt.Rows[i]["money"].ToString());
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell(); //退款单位
                    cell.Attributes.CssStyle.Add("height", "20px");
                    cell.InnerHtml = dt.Rows[i]["cusName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //应退金额
                    cell.InnerHtml = dt.Rows[i]["money"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //退款状态
                    cell.InnerHtml = dt.Rows[i]["refundStatus"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //实际退款金额
                    cell.InnerHtml = dt.Rows[i]["refundAmount"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //备注
                    cell.InnerHtml = dt.Rows[i]["remark"].ToString();
                    row.Controls.Add(cell);

                    this.tableback.Controls.Add(row);

                    //应退金额合计
                    outmoney = 0;
                    decimal.TryParse(dt.Rows[i]["money"].ToString(), out outmoney);
                    moneyAmount += outmoney;

                    //实际退款金额合计
                    outmoney = 0;
                    decimal.TryParse(dt.Rows[i]["refundAmount"].ToString(), out outmoney);
                    hasAmount += outmoney;
                }
                this.lblBackAmount.InnerText = moneyAmount.ToString("F2");
                this.lblBackHasAmount.InnerText = hasAmount.ToString("F2");
            }
            return hasAmount;
        }
        /// <summary>
        /// 付款
        /// </summary>
        /// <param name="id"></param>
        private decimal LoadPay(int id)
        {
            decimal moneyAmount = 0;
            decimal outmoney = 0;
            decimal hasAmount = 0;
            DataTable dt = To_OrderPayDetialManager.getList(id);
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string[] result = GetPayStatusAndMoney(dt.Rows[i]["orderid"].ToString(), dt.Rows[i]["factid"].ToString(), dt.Rows[i]["payType"].ToString(), dt.Rows[i]["money"].ToString());
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell(); //单位名称
                    //cell.Style.Add("height", "20px");
                    cell.Attributes.CssStyle.Add("height", "20px");
                    cell.InnerHtml = dt.Rows[i]["supName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //付款类别
                    cell.InnerHtml = dt.Rows[i]["payType"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //联系人
                    cell.Attributes.Add("onclick", "getLink('" + dt.Rows[i]["factid"].ToString() + "','" + dt.Rows[i]["linkID"].ToString() + "')");
                    cell.InnerHtml = dt.Rows[i]["linkName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //成人数
                    cell.InnerHtml = dt.Rows[i]["payNum"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //儿童数
                    cell.InnerHtml = dt.Rows[i]["payChildNum"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //金额
                    cell.InnerHtml = dt.Rows[i]["money"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //付款申请单
                    cell.InnerHtml = dt.Rows[i]["payConfirm"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //支付状态
                    cell.InnerHtml = dt.Rows[i]["payStatus"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //已支付金额
                    cell.InnerHtml = dt.Rows[i]["payAmount"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //剩余金额
                    double symoney = getSurplus(dt.Rows[i]["money"].ToString(), dt.Rows[i]["payAmount"].ToString());
                    cell.InnerHtml = symoney.ToString("F2");
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //备注
                    cell.InnerHtml = dt.Rows[i]["remark"].ToString();
                    row.Controls.Add(cell);

                    this.tablebank.Controls.Add(row);

                    //应付金额合计
                    outmoney = 0;
                    decimal.TryParse(dt.Rows[i]["money"].ToString(), out outmoney);
                    moneyAmount += outmoney;

                    //实际支付金额合计
                    outmoney = 0;
                    decimal.TryParse(dt.Rows[i]["payAmount"].ToString(), out outmoney);
                    hasAmount += outmoney;
                }
                this.lblPayAmount.InnerText = moneyAmount.ToString("F2");
                this.lblPayHasAmount.InnerText = hasAmount.ToString("F2");
            }
            return hasAmount;
        }
        /// <summary>
        /// 收款
        /// </summary>
        /// <param name="id"></param>
        private decimal LoadCol(int id)
        {
            decimal moneyAmount = 0;
            decimal hasAmount = 0;
            decimal outmoney = 0;
            DataTable dt = To_OrderCollectDetialManager.getList(id);
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string statusAndMoney = GetColStatusAndAmount(dt.Rows[i]["orderid"].ToString(), dt.Rows[i]["cusId"].ToString(), dt.Rows[i]["money"].ToString());
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell(); //收款单位名称
                    cell.Attributes.CssStyle.Add("height", "20px");
                    cell.InnerHtml = dt.Rows[i]["cusName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //业务员
                    cell.InnerHtml = dt.Rows[i]["salesman"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //营业部
                    cell.Attributes.Add("onclick", "getdepart('" + dt.Rows[i]["linkid"].ToString() + "')");
                    cell.InnerHtml = dt.Rows[i]["departName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //联系人
                    cell.InnerHtml = dt.Rows[i]["linkname"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //成人数
                    cell.InnerHtml = dt.Rows[i]["adultNum"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //儿童数
                    cell.InnerHtml = dt.Rows[i]["childNum"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //陪同
                    cell.InnerHtml = dt.Rows[i]["withNum"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //金额
                    cell.InnerHtml = dt.Rows[i]["money"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //收款状态
                    cell.InnerHtml = dt.Rows[i]["collectStatus"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //实际收款金额
                    cell.InnerHtml = dt.Rows[i]["collectAmount"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //剩余金额
                    double symoney = getSurplus(dt.Rows[i]["money"].ToString(), dt.Rows[i]["collectAmount"].ToString());
                    cell.InnerHtml = symoney.ToString("F2");
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell(); //备注
                    cell.InnerHtml = dt.Rows[i]["remark"].ToString();
                    row.Controls.Add(cell);

                    this.tablelink.Controls.Add(row);
                    //应收金额合计
                    outmoney = 0;
                    decimal.TryParse(dt.Rows[i]["money"].ToString(), out outmoney);
                    moneyAmount += outmoney;

                    //实际金额合计
                    outmoney = 0;
                    decimal.TryParse(dt.Rows[i]["collectAmount"].ToString(), out outmoney);
                    hasAmount += outmoney;
                }
            }

            this.lblCollAmount.InnerText = moneyAmount.ToString("F2");
            this.lblColHasAmount.InnerText = hasAmount.ToString("F2");

            return hasAmount;
        }

        /// <summary>
        /// 得到收款状态和收款金额
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="cusid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        private string GetColStatusAndAmount(string colid, string money)
        {
            To_ClaimDetailManager claimDetailManager = new To_ClaimDetailManager();
            double hasAmount = claimDetailManager.GetHasAmount(colid);
            double shouldAmount = 0;
            double.TryParse(money, out shouldAmount);
            if (hasAmount == 0)
            {
                return "未收款," + hasAmount.ToString("F2");
            }
            else
            {
                if (shouldAmount > hasAmount)
                {
                    return "部分收款," + hasAmount.ToString("F2");
                }
                else
                    return "完成收款," + hasAmount.ToString("F2");
            }
        }

        /// <summary>
        /// 得到付款单位的确认，支付状态，支付金额等信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="factid"></param>
        /// <param name="payType"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        private string[] GetPayStatusAndMoney(string orderPayId, string money)
        {
            string[] result = new string[3]; //0，可否修改；1，支付状态；2，支付金额
            To_PaymentDetailManager paymentDetailManager = new To_PaymentDetailManager();
            DataTable dt = paymentDetailManager.GetOrderPayDetail("orderPayId=" + orderPayId);
            double shouldpay = double.Parse(money);
            double haspay = 0;
            double ispay = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["regType"].ToString() == "1") //表示该付款申请已登记
                    {
                        double.TryParse(dt.Rows[i]["payAmount"].ToString(), out ispay);
                        haspay += ispay;
                    }
                }

                result[0] = "有"; //表示这张付款信息做过付款申请，不能再在订单中修改应付金额

                if (haspay == 0)
                    result[1] = "未支付";
                else if (shouldpay > haspay)
                    result[1] = "部分支付";
                else
                    result[1] = "完成支付";

                result[2] = haspay.ToString("F2");
            }
            else
            {
                result[0] = "无";
                result[1] = "未支付";
                result[2] = haspay.ToString("F2");
            }

            return result;
        }

        /// <summary>
        /// 得到退款信息的退款状态和退款金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payerId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        private string[] GetReturnStatusAndMoney(string orderRetID, string money)
        {
            string[] result = new string[3]; //0，可否修改；1，支付状态；2，支付金额
            DataTable dt = To_PaymentReturnManager.GetOrderReturnDetail("orderRetID=" + orderRetID);
            double shouldReturn = double.Parse(money);
            double hasReturn = 0;
            double isReturn = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["regType"].ToString() == "1") //表示该付款申请已登记
                    {
                        double.TryParse(dt.Rows[i]["returnAmount"].ToString(), out isReturn);
                        hasReturn += isReturn;
                    }
                }

                result[0] = "有"; //表示这张退款信息做过付款申请，不能再在订单中修改应退金额

                if (hasReturn == 0)
                    result[1] = "未退款";
                else if (shouldReturn > hasReturn)
                    result[1] = "部分退款";
                else
                    result[1] = "完成退款";

                result[2] = hasReturn.ToString("F2");
            }
            else
            {
                result[0] = "无";
                result[1] = "未退款";
                result[2] = hasReturn.ToString("F2");
            }

            return result;
        }


        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["pageindex"] != null)
            {
                int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                Response.Redirect("../Job/AuditJobFlow.aspx?page=" + page + "");
            }
            else
            Response.Redirect("../Job/AuditJobFlow.aspx");
        }
        /// <summary>
        /// 加载审核流程图
        /// </summary>
        private void LoadAuditImg(int ruleid)
        {
            ApprovalRule model = ApprovalRuleManager.GetModel(ruleid);
            if (model != null)
            {
                string strpath = Server.MapPath(model.rolepic);
                if (File.Exists(strpath))
                {
                    this.auditpic.InnerHtml = File.ReadAllText(strpath);
                }
                else
                {
                    this.auditpic.InnerText = "找不到指定的审批流程图";
                }
            }
        }

        /// <summary>
        /// 审批意见
        /// </summary>
        /// <param name="jfid">工作流的id值</param>
        private string ShowOpiniontxt(int jfid)
        {
            string result = "";
            string strsql = " jobflowid=" + jfid.ToString();
            strsql += " AND nowreviewer='P'";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(strsql);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                result += tbl.Rows[i]["reviewername"] + "的审批意见:";
                result += tbl.Rows[i]["opiniontxt"] + "(审批时间:";
                result += DateTime.Parse(tbl.Rows[i]["audittime"].ToString()).ToString("yyyy-MM-dd hh:mm:ss") + ")<br/>";
            }
            return result;
        }

        /// <summary>
        /// 得到剩余金额
        /// </summary>
        /// <param name="money"></param>
        /// <param name="hasmoney"></param>
        /// <returns></returns>
        public double getSurplus(string money, string hasmoney)
        {
            double m1 = 0; //应金额
            double m2 = 0; //实际金额
            double.TryParse(money, out m1);
            double.TryParse(hasmoney, out m2);
            return (m1 - m2);
        }
    }
}