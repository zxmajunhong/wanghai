using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Financial.RegPayment
{
    public partial class RegPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string paymentID = Request.QueryString["payid"];
                LoadPaymentData(paymentID);

                if (Request.QueryString["payid"] == null || Request.QueryString["payid"].ToString().Trim() == string.Empty)
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');location.href='RegPaymentList.aspx';", true);
                    return;
                }
                LoadData();
            }



        }

        /// <summary>
        /// 加载付款信息
        /// </summary>
        /// <param name="paymentID"></param>
        private void LoadPaymentData(string paymentID)
        {
            To_PaymentManager bPayment = new To_PaymentManager();

            DataTable dtPayment = bPayment.GetViewPaymentList(string.Format("and id='{0}'", paymentID));

            if (dtPayment.Rows.Count > 0)
            {
                DataRow row = dtPayment.Rows[0];
                lblSerialNumber.Text = row["serialNum"].ToString(); //申请单号
                lblRequestDate.Text = DateTime.Parse(row["requestDate"].ToString()).ToString("yyyy-MM-dd"); //申请日期
                lblMaker.Text = row["makerName"].ToString(); //制单员
                lblpayType.Text = row["payType"].ToString(); //支付方式
                lblPayerName.Text = row["payerName"].ToString(); //收款单位名称
                lblPayFor.Text = row["paymentType"].ToString(); //付款类别
                lblSumAmount.Text = decimal.Parse(row["totalAmount"].ToString()).ToString("N2"); //支付金额合计
                lblPayBank.Text = row["bankName"].ToString(); //付款银行
                lblPayAccount.Text = row["bankAccount"].ToString(); //付款帐号
                lblPayAccountName.Text = row["bankAccountName"].ToString(); //付款账户人
                lblBank.Text = row["getBank"].ToString(); //收款银行
                lblBankAccount.Text = row["getAccount"].ToString(); //收款帐号
                lblBankAccountName.Text = row["getAccountName"].ToString(); //收款账户人

                sumBox.InnerText = lblSumAmount.Text; //金额合计

                LoadPaymentDetail(paymentID);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "load", "alert('数据不存在或没有权限查看');location.href='PaymentList.aspx';", true);
            }
        }


        /// <summary>
        /// 加载支付明细数据
        /// </summary>
        /// <param name="paymentID"></param>
        /// <param name="fieldName"></param>
        private void LoadPaymentDetail(string paymentID)
        {
            To_PaymentDetailManager bPaymentDetail = new To_PaymentDetailManager();

            RpPaymentDetail.DataSource = bPaymentDetail.GetList(" paymentid ='" + paymentID + "'");
            RpPaymentDetail.DataBind();
        }


        protected string CalcAmount(object a1, object a2)
        {
            if (a1 == DBNull.Value)
            {
                return string.Empty;
            }

            if (a2 == DBNull.Value)
            {
                return a1.ToString();
            }

            return (double.Parse(a1.ToString()) - double.Parse(a2.ToString())).ToString("F2");
        }


        /// <summary>
        /// 获取财物登记页面数据
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private void LoadData()
        {
            #region 无用代码
            //if (Request.QueryString["payid"] != null)
            //{

            //    string regID = Request.QueryString["payid"].ToString().Trim();

            //    RegPaymentManager bRegP = new RegPaymentManager();

            //    EtNet_Models.RegPayment mRegP = bRegP.GetModel(regID);

            //    if (null == mRegP)
            //    {
            //        return;
            //    }

            //    if (mRegP.hasInvoice == 1)
            //    {

            //        //invoiceTable.Visible = true;

            //        ddlHasInvoiceNum.SelectedValue = mRegP.hasInvoice.ToString();

            //        //invoiceTypeRow.Visible = true;
            //        txtHasInvoceDate.Text = mRegP.hasInvoiceDate.ToShortDateString();
            //        invoiceTypeRow.Visible = true;
            //        this.hidInvoiceType.Value = mRegP.invoiceType.ToString();
            //        this.ddlPaymentMode.SelectedValue = mRegP.paymentMode.ToString();
            //        if (mRegP.invoiceType == 2)
            //        {
            //            ddlInvoiceType.SelectedValue = mRegP.invoiceType.ToString();

            //        }
            //        txtHasInvoceDate.Text = DateTime.Parse(mRegP.hasInvoiceDate.ToString()).ToString("yyyy-MM-dd");
            //        ClientScript.RegisterStartupScript(Page.GetType(), "show", "$('#invoiceTable').show();$('#txtHasInvoceDate').removeClass('readonly');", true);
            //        RegPaymentInvoiceManager bRI = new RegPaymentInvoiceManager();
            //        //if (ddlInvoiceType.SelectedValue == "1")
            //        //{
            //        //    rpInvoiceList.DataSource = bRI.GetList(string.Format("regID='{0}'", mRegP.paymentID));
            //        //    rpInvoiceList.DataBind();
            //        //}
            //        //else
            //        //{
            //        //    rpInvoice.DataSource = bRI.GetList(string.Format("regID='{0}'", mRegP.paymentID));
            //        //    rpInvoice.DataBind();
            //        //}
            //    }

            //}
            #endregion

            this.txtPayer.Text = ((LoginInfo)Session["login"]).Cname; //支付人就默认为当前登录人员
            this.txtPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); //支付时间默认为当前时间
        }


        #region 无用代码
        /// <summary>
        /// 加载发票信息
        /// </summary>
        //private void LoadDetialData()
        //{

        //    string regID = Request.QueryString["payid"].ToString().Trim();
        //    RegPaymentManager bRegP = new RegPaymentManager();
        //    EtNet_Models.RegPayment mRegP = bRegP.GetModel(regID);
        //    EtNet_BLL.RegPaymentInvoiceManager regPaymentInvoiceManager = new RegPaymentInvoiceManager();
        //    string sql = "regID='" + mRegP.paymentID + "'";
        //    DataTable tbl = regPaymentInvoiceManager.GetList(sql);
        //    HtmlTableRow row = null;
        //    HtmlTableCell cell = null;
        //    string strnumeral = "";

        //    if (mRegP.invoiceType == 1)
        //    {
        //        for (int i = 0; i < tbl.Rows.Count; i++)
        //        {
        //            if (i == 0)
        //            {

        //                row = this.czinvoicetable.Rows[1];
        //                cell = row.Cells[0];
        //                cell.InnerHtml = "<img onclick='addInvoice(this);' alt='添加' title='添加发票' src='../../../Images/public/add.png' />&nbsp;<img onclick='removeInvoice(this);' alt='移除' title='移除发票' src='../../../Images/public/icondelete.png' />";

        //                cell = row.Cells[1];
        //                cell.Attributes.Add("onclick", "document.getElementById('hidnum').value=$(this).find('input').attr('id')");

        //                cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["invoiceNum"] + "' id='num1' style='text-align: center' class='num'/>";

        //                cell = row.Cells[2];
        //                cell.Attributes.Add("onclick", "document.getElementById('hidremark').value=$(this).find('input').attr('id')");
        //                cell.InnerHtml = "<input type='text' class='remark' value='" + tbl.Rows[i]["remark"].ToString() + "' id='remark1'/>";
        //            }
        //            else
        //            {
        //                row = new HtmlTableRow();

        //                cell = new HtmlTableCell();
        //                cell.InnerHtml = "<img onclick='addInvoice(this);' alt='添加' title='添加发票' src='../../../Images/public/add.png' />&nbsp;<img onclick='removeInvoice(this);' alt='移除' title='移除发票' src='../../../Images/public/icondelete.png' />";
        //                row.Controls.Add(cell);

        //                cell = new HtmlTableCell();
        //                cell.Attributes.Add("onclick", "document.getElementById('hidnum').value=$(this).find('input').attr('id')");
        //                strnumeral = tbl.Rows[i]["invoiceNum"].ToString();
        //                cell.InnerHtml = "<input type='text' class='num' value='" + (string)tbl.Rows[i]["invoiceNum"] + "' id='num" + (Convert.ToInt32(i) + 1) + "' style='text-align: center' class='num'/>";
        //                row.Controls.Add(cell);

        //                cell = new HtmlTableCell();
        //                cell.Attributes.Add("onclick", "document.getElementById('hidremark').value=$(this).find('input').attr('id')");
        //                cell.InnerHtml = "<input type='text' class='remark' value='" + tbl.Rows[i]["remark"].ToString() + "' id='remark" + (Convert.ToInt32(i) + 1)  + "' class='remark'/>";
        //                row.Controls.Add(cell);


        //                this.czinvoicetable.Controls.Add(row);
        //            }
        //            this.hidnumrow.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
        //            this.hidremarkrow.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
        //        }


        //    }
        //    else
        //    {
        //        for (int i = 0; i < tbl.Rows.Count; i++)
        //        {
        //            if (i == 0)
        //            {

        //                row = this.invoiceTable.Rows[1];
        //                cell = row.Cells[0];
        //                cell.InnerHtml = "<img onclick='addInvoice(this);' alt='添加' title='添加发票' src='../../../Images/public/add.png' />&nbsp;<img onclick='removeInvoice(this);' alt='移除' title='移除发票' src='../../../Images/public/icondelete.png' />";

        //                cell = row.Cells[1];
        //                cell.Attributes.Add("onclick", "document.getElementById('hidnum').value=$(this).find('input').attr('id'),artDialog.open('../../Common/InvoiceSet.aspx')");

        //                cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["invoiceNum"] + "' id='num1' style='text-align: center' class='num'/>";

        //                cell = row.Cells[2];

        //                cell.InnerHtml = "<input type='text' class='remark' value='" + tbl.Rows[i]["remark"].ToString() + "' id='remark1'/>";
        //            }
        //            else
        //            {
        //                row = new HtmlTableRow();

        //                cell = new HtmlTableCell();
        //                cell.InnerHtml = "<img onclick='addInvoice(this);' alt='添加' title='添加发票' src='../../../Images/public/add.png' />&nbsp;<img onclick='removeInvoice(this);' alt='移除' title='移除发票' src='../../../Images/public/icondelete.png' />";
        //                row.Controls.Add(cell);

        //                cell = new HtmlTableCell();
        //                cell.Attributes.Add("onclick", "document.getElementById('hidnum').value=$(this).find('input').attr('id'),artDialog.open('../../Common/InvoiceSet.aspx')");
        //                strnumeral = tbl.Rows[i]["invoiceNum"].ToString();
        //                cell.InnerHtml = "<input type='text' class='num' value='" + (string)tbl.Rows[i]["invoiceNum"] + "' id='num" + (Convert.ToInt32(i) + 1)  + "' style='text-align: center' class='num'/>";
        //                row.Controls.Add(cell);

        //                cell = new HtmlTableCell();

        //                cell.InnerHtml = "<input type='text' class='remark' value='" + tbl.Rows[i]["remark"].ToString() + "' id='remark" +(Convert.ToInt32(i) + 1)  + "' class='remark'/>";
        //                row.Controls.Add(cell);


        //                this.invoiceTable.Controls.Add(row);
        //            }
        //            this.hidnumrow.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
        //            this.hidremarkrow.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
        //        }

        //    }


        //}
        #endregion

        /// <summary>
        /// 读取节点对象
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private List<InvoiceData> ReadJson(string jsonString)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            object aa = js.Deserialize(jsonString, typeof(string[]));

            string[] itemArr = aa as string[];

            InvoiceData invoiceData = new InvoiceData();
            List<InvoiceData> list = new List<InvoiceData>();
            for (int i = 1; i < itemArr.Count(); i++)
            {
                invoiceData = js.Deserialize<InvoiceData>(itemArr[i]);

                list.Add(invoiceData);
            }

            return list;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            RegPaymentManager bRegP = new RegPaymentManager();
            RegPaymentInvoiceManager regPaymentInvoiceManager = new RegPaymentInvoiceManager();
            To_PaymentManager to_PaymentManager = new To_PaymentManager();

            //更新财务支付
            to_PaymentManager.UpdateReg(Request.QueryString["payid"], chkIsPay.Checked ? "1" : "0");
            //财务登记页面数据赋值
            LoginInfo currentUser = Session["login"] as LoginInfo;

            #region 发票信息的更新。目前不需要。
            ////删除数据
            //int num = regPaymentInvoiceManager.GetCount(Request.QueryString["payid"]);
            //if (num != 0)
            //{
            //    regPaymentInvoiceManager.DeleteByRegID(Request.QueryString["payid"]);
            //}
            ////添加数据
            //string jsonString = hidInvoice.Value;

            //List<InvoiceData> invoiceList = ReadJson(jsonString);
            //RegPaymentInvoice regPaymentInvoice = new RegPaymentInvoice();

            //for (int i = 0, len = invoiceList.Count(); i < len; i++)
            //{

            //    InvoiceData invoiceData = invoiceList[i];
            //    if (invoiceData.Num != "" || invoiceData.Remark != "")
            //    {
            //        regPaymentInvoice.id = Request.QueryString["payid"];
            //        regPaymentInvoice.invoiceNum = invoiceData.Num;
            //        regPaymentInvoice.remark = invoiceData.Remark;
            //        regPaymentInvoiceManager.Add(regPaymentInvoice);
            //    }
            //}
            #endregion

            if (!string.IsNullOrEmpty(Request.QueryString["payid"]))
            {
                string paymentID = Request.QueryString["payid"].ToString().Trim();
                EtNet_Models.RegPayment regpay = bRegP.GetModel(paymentID);
                bool isAdd = true;
                if (regpay != null)
                {
                    isAdd = false;
                }
                else
                {
                    regpay = new EtNet_Models.RegPayment();
                    regpay.id = Guid.NewGuid().ToString();
                }
                regpay.hasInvoice = int.Parse(ddlHasInvoiceNum.SelectedValue.Trim());
                regpay.hasInvoiceDate = txtHasInvoceDate.Text.Trim() != "" ? DateTime.Parse(txtHasInvoceDate.Text.Trim()) : DateTime.Parse("1900-01-01");
                regpay.makerID = LoginInfoManager.getLoginIDByname(lblMaker.Text.Trim());//制单人员的关联id
                regpay.makerName = lblMaker.Text;//该付款申请单的制单人员
                regpay.makeTime = DateTime.Parse(lblRequestDate.Text.Trim()); //制单日期
                regpay.payerID = currentUser.Id; //支付人员管理id
                regpay.payerName = currentUser.Cname; //支付人员
                regpay.paymentDate = DateTime.Parse(txtPaymentDate.Text.Trim()); //支付日期
                regpay.payRemark = txtpz.Value; //支付凭证
                regpay.paymentID = paymentID;
                regpay.payStatus = chkIsPay.Checked ? 1 : 0;
                if (isAdd)
                {
                    bRegP.Add(regpay);
                }
                else
                    bRegP.Update(regpay);
            }

            ClientScript.RegisterStartupScript(Page.GetType(), "a", "alert('保存成功');self.location.href='RegPaymentList.aspx';", true);
        }


        /// <summary>
        /// 得到订单id
        /// </summary>
        /// <param name="orderPayid">付款信息明细表id</param>
        /// <returns></returns>
        public string getOrderidpay(string orderPayid)
        {
            int id = 0;
            int.TryParse(orderPayid, out id);
            To_OrderPayDetial model = To_OrderPayDetialManager.getTo_OrderPayDetialById(id);
            if (model != null)
                return model.Orderid.ToString();
            else
                return "";
        }
    }

    [Serializable]
    public class InvoiceData
    {
        public string Num { get; set; }
        public string Remark { get; set; }
    }

}