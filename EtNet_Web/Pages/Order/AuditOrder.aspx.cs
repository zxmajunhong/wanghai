﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using EtNet_BLL;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Order
{
    public partial class AuditOrder : System.Web.UI.Page
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
            string jfId = Request.QueryString["jobflowid"].ToString();
            string sqlstring = " jobflowID=" + jfId;
            DataTable dtOrder = To_OrderInfoManager.GetLists(sqlstring);
            if (dtOrder.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "audit", "alert('数据出错，订单可能已删除！');location.href='../Job/AuditJobFlow.aspx'", true);
                return;
            }

            int id = Convert.ToInt32(dtOrder.Rows[0]["id"]);

            To_OrderInfo order = To_OrderInfoManager.getTo_OrderInfoById(id);

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
        /// 通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnPass_Click(object sender, ImageClickEventArgs e)
        {
            OrderPass();
        }

        private void OrderPass()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string comparedata = " reviewerid=" + login.Id + " AND jobflowid=" + jobflowid.ToString();
            if (EtNet_BLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../Job/AuditError.aspx?error=0");
            }
            else if (EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../Job/AuditError.aspx?error=1");
            }
            else
            {
                string ruletxt = ""; //审核的分类
                string strsql = " jobflowID=" + jobflowid.ToString();

                DataTable tbl = EtNet_BLL.To_OrderInfoManager.getList("", strsql);//获取视图数据
                if (tbl.Rows.Count == 1)
                {
                    int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                    EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
                    ruletxt = rule.sort;

                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + login.Id;
                    DataTable audittbl = EtNet_BLL.AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                    int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                    string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                    auditmodel = new EtNet_Models.AuditJobFlow();
                    auditmodel.auditoperat = "通过";
                    auditmodel.audittime = DateTime.Now;
                    auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                    auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                    auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                    auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                    auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                    auditmodel.operatstatus = "已审批";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                    if (this.iptcomment.Value != "")
                    {
                        auditmodel.opiniontxt = Server.UrlDecode(this.iptcomment.Value.Trim());
                    }
                    else
                    {
                        auditmodel.opiniontxt = "   ";
                    }

                    EtNet_BLL.AuditJobFlowManager.Update(auditmodel);

                    EtNet_Models.JobFlow jobflowmodel = new EtNet_Models.JobFlow();
                    jobflowmodel = EtNet_BLL.JobFlowManager.GetModel(jobflowid);

                    //依据不同的审核类型进行操作
                    switch (ruletxt)
                    {
                        case "单审":
                            if (mainreviewer != "T")
                            {
                                auditmodel = new EtNet_Models.AuditJobFlow(); //设置下一个审核人的数据记录
                                string nextauditstr = " jobflowid=" + jobflowid.ToString() + " AND numbers=" + (num + 1).ToString();
                                DataTable nextaudittbl = EtNet_BLL.AuditJobFlowManager.GetList(nextauditstr);
                                auditmodel.auditoperat = nextaudittbl.Rows[0]["auditoperat"].ToString();
                                auditmodel.audittime = DateTime.Parse(nextaudittbl.Rows[0]["audittime"].ToString());
                                auditmodel.id = int.Parse(nextaudittbl.Rows[0]["id"].ToString());
                                auditmodel.jobflowid = int.Parse(nextaudittbl.Rows[0]["jobflowid"].ToString());
                                auditmodel.mainreviewer = nextaudittbl.Rows[0]["mainreviewer"].ToString();
                                auditmodel.nowreviewer = "T"; //设置其为审核人员
                                auditmodel.numbers = int.Parse(nextaudittbl.Rows[0]["numbers"].ToString());
                                auditmodel.operatstatus = nextaudittbl.Rows[0]["operatstatus"].ToString();
                                auditmodel.reviewerid = int.Parse(nextaudittbl.Rows[0]["reviewerid"].ToString());
                                auditmodel.opiniontxt = nextaudittbl.Rows[0]["opiniontxt"].ToString();
                                EtNet_BLL.AuditJobFlowManager.Update(auditmodel);

                                jobflowmodel.auditstatus = "02"; //工作流的审核状态为“进行中”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);

                            }
                            else
                            {
                                jobflowmodel.endtime = DateTime.Now;
                                jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                                EtNet_BLL.To_OrderInfoManager.updateOrdersjGross(jobflowid.ToString(), this.lblsjml.Text);

                            }
                            break;

                        case "选审":

                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "04"; //工作流的审核状态为“已通过”
                            EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            EtNet_BLL.To_OrderInfoManager.updateOrdersjGross(jobflowid.ToString(), this.lblsjml.Text);
                            //审核通过后，删除其他审核人员的审核流数据
                            AuditJobFlowManager.UpdateOther(" reviewerid != " + login.Id + " and jobflowid=" + jobflowid.ToString());
                            break;

                        case "会审":
                            bool pass = true;
                            string straudit = " jobflowid=" + jobflowid.ToString();
                            DataTable auditjobtbl = EtNet_BLL.AuditJobFlowManager.GetList(straudit);
                            for (int i = 0; i < auditjobtbl.Rows.Count; i++)
                            {
                                if (auditjobtbl.Rows[i]["auditoperat"].ToString() != "通过")
                                {
                                    pass = false; //说明还有其他审核人员未开始审核
                                    break;
                                }

                            }

                            if (pass)
                            {
                                jobflowmodel.endtime = DateTime.Now;
                                jobflowmodel.auditstatus = "04"; //工作流的状审核状态为“已通过”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                                EtNet_BLL.To_OrderInfoManager.updateOrdersjGross(jobflowid.ToString(), this.lblsjml.Text);
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; //工作流的状审核状态为“进行中”
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            break;

                    }



                    string strad = "编号为" + jobflowmodel.cname + "的订单，【" + login.Cname + "】通过审批!";
                    SendInfo(strad, jobflowmodel.id);

                    SendNextAudit(jobflowmodel.id);

                    //修改客户的审核意见与启用状态
                    //int cusid = int.Parse(tbl.Rows[0]["id"].ToString());
                    EtNet_Models.AuditJobFlow cus = EtNet_BLL.AuditJobFlowManager.GetModelByJFID(jobflowid);
                    cus.opiniontxt = cus.opiniontxt + login.Cname + "的审批意见：" + Server.UrlDecode(this.iptcomment.Value.Trim()) + "|";
                    //if (jobflowmodel.auditstatus == "04")
                    //{
                    //    cus.Used = 1;
                    //}
                    EtNet_BLL.AuditJobFlowManager.Update(cus);
                    if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                    {
                        int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                        Response.Redirect("../Job/AuditJobFlow.aspx?page=" + page + "");
                    }
                    else
                    Response.Redirect("../Job/AuditJobFlow.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
        }

        /// <summary>
        /// 发送审批消息给下一个审批人员
        /// </summary>
        public void SendNextAudit(int jfid)
        {
            EtNet_Models.LoginInfo login = ((EtNet_Models.LoginInfo)Session["login"]);
            EtNet_Models.JobFlow jfmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (jfmodel != null)
            {
                EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(jfmodel.ruleid);
                string[] list = rule.idgourp.Split(',');
                if (rule.sort != "单审" || list.Length == 1)
                {
                    return;
                }
                if (list[list.Length - 1] == login.Id.ToString())
                {
                    return;
                }

                int recipientid = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == login.Id.ToString() && i != list.Length - 1)
                    {
                        recipientid = int.Parse(list[i + 1]);
                    }
                }
                EtNet_Models.Information model = new EtNet_Models.Information();
                model.sortid = 9;
                model.associationid = jfid;
                model.createtime = DateTime.Now;
                model.sendtime = DateTime.Now;
                model.founderid = jfmodel.founderid;
                model.contents = "名称为" + jfmodel.cname + "的客户需要您审批!"; ;
                EtNet_BLL.InformationManager.Add(model);
                int maxid = EtNet_BLL.InformationManager.GetMaxId(jfmodel.founderid.ToString());

                EtNet_Models.InformationNotice infnotic = new EtNet_Models.InformationNotice();
                infnotic.informationid = maxid;
                infnotic.recipientid = recipientid;
                infnotic.remind = "是";
                EtNet_BLL.InformationNoticeManager.Add(infnotic);
            }
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="straud">审核单据编号及意见</param>
        /// <param name="jobflowid">工作流id值</param>
        public void SendInfo(string straud, int jobflowid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jobflowid);
            if (model != null)
            {
                int infoid = CreateInfo(straud);
                CreateInfoNotice(infoid, model.founderid);
            }

        }


        /// <summary>
        /// 创建消息,返回消息的id值
        /// </summary>
        public int CreateInfo(string straudit)
        {

            EtNet_Models.Information model = new EtNet_Models.Information();
            model.sortid = 1;
            model.associationid = 1;
            model.createtime = DateTime.Now;
            model.sendtime = DateTime.Now;
            model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            model.contents = straudit;
            EtNet_BLL.InformationManager.Add(model);
            int maxid = EtNet_BLL.InformationManager.GetMaxId(((EtNet_Models.LoginInfo)Session["login"]).Id.ToString());
            return maxid;
        }



        /// <summary>
        /// 创建消息通知
        /// </summary>
        /// <param name="infoid">消息的id值</param>
        /// <param name="acceptid">接受人员的id值</param>
        public void CreateInfoNotice(int infoid, int acceptid)
        {
            EtNet_Models.InformationNotice model = new EtNet_Models.InformationNotice();
            model.informationid = infoid;
            model.recipientid = acceptid;
            model.remind = "是";
            EtNet_BLL.InformationNoticeManager.Add(model);
        }


        /// <summary>
        /// 拒绝审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnRefuse_Click(object sender, ImageClickEventArgs e)
        {
            OrderRefuse();
        }
        /// <summary>
        /// 拒绝
        /// </summary>
        private void OrderRefuse()
        {
            int jobflowid = int.Parse(Request.QueryString["jobflowid"].ToString()); //工作流的id
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string comparedata = " reviewerid=" + login.Id + " AND jobflowid=" + jobflowid.ToString();
            if (EtNet_BLL.AuditJobFlowManager.GetList(comparedata).Rows.Count == 0)
            {
                //该工作流被收回或删除导致审批提交失败
                Response.Redirect("../Job/AuditError.aspx?error=0");
            }
            else if (EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "03" || EtNet_BLL.JobFlowManager.GetModel(jobflowid).auditstatus == "04")
            {
                //该工作流是审核方式是选审或会签所以在提交审核时，工作流已由他人审核通过
                Response.Redirect("../Job/AuditError.aspx?error=1");
            }

            else
            {
                string ruletxt = ""; //审核的分类
                string strsql = " jobflowid=" + jobflowid.ToString();
                DataTable tbl = EtNet_BLL.To_OrderInfoManager.getList("", strsql);
                if (tbl.Rows.Count == 1)
                {
                    int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                    EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
                    ruletxt = rule.sort;

                    //修改当前审核人的记录
                    EtNet_Models.AuditJobFlow auditmodel = null;
                    string auditstr = " jobflowid=" + jobflowid.ToString() + " AND reviewerid=" + login.Id;
                    DataTable audittbl = EtNet_BLL.AuditJobFlowManager.GetList(auditstr); // 查找到当前审核人员的记录
                    int num = int.Parse(audittbl.Rows[0]["numbers"].ToString()); //当前审核人员编号
                    string mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString(); //当前审核人是不是最终审核人

                    auditmodel = new EtNet_Models.AuditJobFlow();
                    auditmodel.auditoperat = "拒绝";
                    auditmodel.audittime = DateTime.Now;
                    auditmodel.id = int.Parse(audittbl.Rows[0]["id"].ToString());
                    auditmodel.jobflowid = int.Parse(audittbl.Rows[0]["jobflowid"].ToString());
                    auditmodel.mainreviewer = audittbl.Rows[0]["mainreviewer"].ToString();
                    auditmodel.nowreviewer = "P"; //能查找到工作流记录，但不能进行审核操作
                    auditmodel.numbers = int.Parse(audittbl.Rows[0]["numbers"].ToString());
                    auditmodel.operatstatus = "已审批";
                    auditmodel.reviewerid = int.Parse(audittbl.Rows[0]["reviewerid"].ToString());
                    auditmodel.opiniontxt = Server.UrlDecode(this.iptcomment.Value.Trim());
                    EtNet_BLL.AuditJobFlowManager.Update(auditmodel);

                    EtNet_Models.JobFlow jobflowmodel = new EtNet_Models.JobFlow();
                    jobflowmodel = EtNet_BLL.JobFlowManager.GetModel(jobflowid);

                    //依据不同的审核类型进行操作
                    switch (ruletxt)
                    {
                        case "单审":
                        case "会审":
                            jobflowmodel.endtime = DateTime.Now;
                            jobflowmodel.auditstatus = "03"; //工作流的审核状态为“被拒绝”
                            EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            break;

                        case "选审":
                            string st = " jobflowid=" + jobflowid.ToString();
                            DataTable tbla = EtNet_BLL.AuditJobFlowManager.GetList(st);
                            bool refuse = true;

                            for (int j = 0; j < tbla.Rows.Count; j++)
                            {
                                if (tbla.Rows[j]["auditoperat"].ToString() != "拒绝")
                                {
                                    refuse = false; //还有其他审核人员未审
                                    break;
                                }
                            }
                            if (refuse)
                            {
                                jobflowmodel.endtime = DateTime.Now;
                                jobflowmodel.auditstatus = "03"; // 工作流的审核状态为被拒绝
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            else
                            {
                                jobflowmodel.auditstatus = "02"; // 工作流的审核状态为进行中
                                EtNet_BLL.JobFlowManager.Update(jobflowmodel);
                            }
                            break;
                    }


                    string strad = "编号为" + jobflowmodel.cname + "的订单，【" + login.Cname + "】审批被拒绝!";
                    SendInfo(strad, jobflowmodel.id);

                    SendNextAudit(jobflowmodel.id);

                    //修改客户的审核意见与启用状态
                    //int cusid = int.Parse(tbl.Rows[0]["id"].ToString());
                    EtNet_Models.AuditJobFlow cus = EtNet_BLL.AuditJobFlowManager.GetModelByJFID(jobflowid);
                    cus.opiniontxt = cus.opiniontxt + login.Cname + "的审批意见：" + Server.UrlDecode(this.iptcomment.Value.Trim()) + "|";
                    //if (jobflowmodel.auditstatus == "04")
                    //{
                    //    cus.Used = 1;
                    //}
                    EtNet_BLL.AuditJobFlowManager.Update(cus);
                    if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                    {
                        int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                        Response.Redirect("../Job/AuditJobFlow.aspx?page=" + page + "");
                    }
                    else
                    Response.Redirect("../Job/AuditJobFlow.aspx");


                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script> alert('审批出错！')</script>", false);
                }

            }
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