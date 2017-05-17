using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Collections;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class RegReimbursedForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string paystatus = Request.QueryString["pay"];
                LoadAusRottenData();

                LoadFile();

                LoadData();

                if (paystatus == "1") //已经支付了
                {
                    string regid = Request.QueryString["regID"].ToString().Trim();
                    RegReimbursementManager rem = new RegReimbursementManager();
                    RegReimbursement reg = rem.GetModel(regid);
                    this.txtPayer.Text = reg.payerName;
                    this.txtPaymentDate.Text = reg.paymentDate.ToString("yyyy-MM-dd");
                    //this.ddlPaymentMode.SelectedValue = reg.paymentMode.ToString();
                    this.iptremark.Value = reg.payremark.ToString();

                    this.btnSave.Visible = false;

                    this.chkIsPay.Checked = true;
                    this.chkIsPay.Enabled = false;
                    //this.ddlPaymentMode.Enabled = false;
                    this.iptremark.Disabled = true;
                    this.iptbankname.Disabled = true;
                    this.iptbanknum.Disabled = true;
                    this.txtPaymentDate.Attributes.Add("onfocus", "");
                    
                }
                else
                {
                    txtPayer.Text = (Session["login"] as LoginInfo).Cname;

                    txtPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.txtPaymentDate.CssClass = "inputLine readonly Wdate";
                }
            }
        }


        /// <summary>
        /// 加载报销单数据
        /// </summary>
        private void LoadAusRottenData()
        {
            int jobflowid = int.Parse(Request.QueryString["id"]);
            string str = " jobflowid=" + jobflowid.ToString();

            DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(str);
            if (tbl.Rows.Count >= 1)
            {
                this.lblnumbers.Text = tbl.Rows[0]["jobflowcname"].ToString();   //报销申请单编号
                this.lblcanme.Text = tbl.Rows[0]["applycantcname"].ToString();   //报销申请人
                this.lblapplydate.Text = Convert.ToDateTime(tbl.Rows[0]["applydate"].ToString()).ToString("yyyy-MM-dd");
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString());
                //收款账户信息
                this.lblbanker.Text = tbl.Rows[0]["banker"].ToString();
                this.lblbankname.Text = tbl.Rows[0]["bankname"].ToString();
                this.lblbanknum.Text = tbl.Rows[0]["banknum"].ToString();

                int jfid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                this.optiniontxt.Attributes.Add("ReadOnly", "true");
                LoadNowAudit(jfid);

                int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                LoadAuditImg(ruleid);
                LoadDetialData();
                LoadOrderDetail();
            }
        }


        /// <summary>
        /// 加载审批流程图
        /// </summary>
        public void LoadAuditImg(int ruleid)
        {
            EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
            if (model != null)
            {
                string strpath = Server.MapPath(model.rolepic);
                if (File.Exists(strpath))
                {
                    this.auditpic.InnerHtml = File.ReadAllText(strpath);
                }
            }
        }

        /// <summary>
        /// 加载订单明细数据
        /// </summary>
        private void LoadOrderDetail()
        {
            string jbid = Request.QueryString["id"];
            DataTable dt = EtNet_BLL.AusOrderInfoManager.GetList(jbid);
            rpOrderlist.DataSource = dt;
            rpOrderlist.DataBind();
        }

        /// <summary>
        /// 加载报销明细
        /// </summary>
        private void LoadDetialData()
        {
            string jbid = Request.QueryString["id"]; //获取工作流的id值
            DataTable tbl = EtNet_BLL.AusDetialInfoManager.GetLists(jbid);
            this.detailList.DataSource = tbl;
            this.detailList.DataBind();

            double billenum = 0;
            double money = 0;

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                billenum += Convert.ToDouble(tbl.Rows[i]["billnum"]);
                money += Convert.ToDouble(tbl.Rows[i]["ausmoney"]);
            }

            //得到张数和金额的合计
            this.lblnum.Text = billenum.ToString("N0");
            this.lblmoney.Text = money.ToString("N2");
            #region 无用代码
            //HtmlTableRow row = null;
            //HtmlTableCell cell = null;
            //string strnumeral = "";
            //for (int i = 0; i < tbl.Rows.Count; i++)
            //{
            //    row = new HtmlTableRow();
            //    cell = new HtmlTableCell();

            //    cell.InnerHtml = DateTime.Parse(tbl.Rows[i]["happendate"].ToString()).ToString("yyyy-MM-dd");
            //    cell.Attributes.Add("class", "clshdate");
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    cell.InnerHtml = tbl.Rows[i]["ausname"].ToString();
            //    cell.Attributes.Add("class", "clshdate");
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    cell.InnerHtml = tbl.Rows[i]["austype"].ToString();
            //    cell.Attributes.Add("class", "clshdate");
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    cell.InnerHtml = tbl.Rows[i]["belongsort"].ToString();
            //    cell.Attributes.Add("class", "clshdate");
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    cell.InnerHtml = tbl.Rows[i]["Salesman"].ToString();
            //    cell.Attributes.Add("class", "clshdate");
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    strnumeral = tbl.Rows[i]["billnum"].ToString();
            //    cell.Attributes.Add("class", "clsdigit");
            //    cell.InnerHtml = ShowNumeral(strnumeral);
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    strnumeral = tbl.Rows[i]["ausmoney"].ToString();
            //    cell.Attributes.Add("class", "clsmoney");
            //    cell.InnerHtml = ShowNumeral(strnumeral);
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    cell.Attributes.Add("class", "clshdate");
            //    cell.InnerHtml = tbl.Rows[i]["remark"].ToString();
            //    row.Controls.Add(cell);

            //    cell = new HtmlTableCell();
            //    cell.Attributes.Add("class", "clshdate");
            //    string fin = Convert.IsDBNull(tbl.Rows[i]["financetype"]) ? "" : (string)tbl.Rows[i]["financetype"];
            //    cell.Attributes.Add("onclick", "document.getElementById('hidausfin').value=$(this).find('input').attr('id'),artDialog.open('AusFin.aspx')");
            //    cell.InnerHtml = "<input type = 'text' value = '" + fin + "'id='fin" + Convert.ToInt32(Convert.ToInt32(i) + 1) + 1 + "' style='text-align: center'/>";
            //    this.HidFinId.Value = fin;
            //    row.Controls.Add(cell);

            //    this.hidmxid.Value += tbl.Rows[i]["id"].ToString() + ",";

            //    this.tblprocess.Controls.Add(row);

            //}
            #endregion

            this.hidausfin.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();

        }

        /// <summary>
        /// 显示票据张数或金额
        /// </summary>
        /// <returns></returns>
        public string ShowNumeral(string strnumeral)
        {
            string result = "";
            result = strnumeral.Replace("0", "");
            result = result.Replace(".", "");
            if (result != "")
            {
                result = Decimal.Round(Decimal.Parse(strnumeral), 2).ToString();
            }
            return result;
        }





        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        private void LoadFile()
        {
            string strsql = " jobflowid=" + Request.QueryString["id"];
            DataTable tblfile = EtNet_BLL.JobFlowFileManager.GetList(strsql);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string str = "";
            if (tblfile.Rows.Count >= 1)
            {

                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();

                    cell.InnerHtml = FileIcon(tblfile.Rows[i]["fileload"].ToString());
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = tblfile.Rows[i]["filename"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    str = "<a target='_blank' href='../JobFlowFiles.aspx?id=" + tblfile.Rows[i]["id"].ToString() + "'>";
                    str += "<img alt='下载' src='../../../Images/public/download.png' /></a>";
                    cell.InnerHtml = str;
                    cell.Attributes.Add("align", "center");
                    row.Controls.Add(cell);
                    this.originalfile.Controls.Add(row);

                }
            }

        }



        /// <summary>
        /// 返回文件显示的图标
        /// </summary>
        private string FileIcon(string path)
        {
            string result = "<img src='../../../Images/public/";
            string[] extend = new string[5] { "txt", "xls", "doc", "ppt", "pic" };
            string suffix = "";
            if (path.Trim() != "" && path.LastIndexOf('.') != -1)
            {
                int start = path.LastIndexOf('.');
                suffix = path.Substring(start + 1).ToLower();
                switch (suffix)
                {
                    case "txt":
                        result += "txtfile.png' />";
                        break;

                    case "xls":
                    case "xlsx":
                        result += "xlsfile.png' />";
                        break;

                    case "doc":
                    case "docx":
                        result += "docfile.png' />";
                        break;

                    case "ppt":
                    case "pptx":
                        result += "pptfile.png' />";
                        break;

                    case "png":
                    case "gif":
                    case "jpg":
                    case "bmp":
                        result += "picfile.png' />";
                        break;
                    default:
                        result += "dftfile.png' />";
                        break;
                }
            }
            else
            {
                result += "dftfile.png' />";
            }
            return result;
        }





        /// <summary>
        /// 加载当前审批人员的情况
        /// </summary>
        private void LoadNowAudit(int jfid)
        {
            string strsql = " id=" + jfid.ToString();
            DataTable tbl = EtNet_BLL.JobFlowManager.GetList(strsql);
            string audit = tbl.Rows[0]["auditstatus"].ToString(); //审批状态
            string save = tbl.Rows[0]["savestatus"].ToString(); //保存状态
            if (audit == "01" && save == "草稿")
            {
                this.hidlist.Value = "-1"; //代表审批未开始
            }
            else if (audit == "02" || (audit == "01" && save == "已提交"))
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
                result += "<span>" + tbl.Rows[i]["reviewername"] + "的审批意见:";
                result += tbl.Rows[i]["opiniontxt"] + "</span><span style='margin-left:5px;'>(审批时间:";
                result += DateTime.Parse(tbl.Rows[i]["audittime"].ToString()).ToString("yyyy-MM-dd hh:mm:ss") + ")</span><br/>";
            }
            return result;
        }



        /// <summary>
        /// 返回查询页面
        /// </summary>
        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegReimbursedFormList.aspx");
        }

        private void LoadData()
        {
            if (Request.QueryString["ausID"] != null)
            {

                int ausID;
                int.TryParse(Request.QueryString["ausID"].ToString(), out ausID);

                RegReimbursementManager bReg = new RegReimbursementManager();

                EtNet_Models.RegReimbursement mReg = bReg.GetModelByAusID(ausID);
                if (mReg != null)
                {
                    this.iptbankname.Value = mReg.bankName;
                    this.iptbanknum.Value = mReg.bankNum;
                    this.iptremark.Value = mReg.payremark;
                    this.hidbankid.Value = mReg.bankId.ToString();
                }

                if (null == mReg)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 保存报销登记，保存的信息有（其他信息保存到RegReimbursement表中）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            #region  无用代码
            ///////////
            //EtNet_Models.RegReimbursement mReg = new RegReimbursement();

            //LoginInfo currentUser = Session["login"] as LoginInfo;
            //mReg.id = Guid.NewGuid().ToString();
            //mReg.makerID = currentUser.Id;
            //mReg.makerName = currentUser.Cname;
            //mReg.makeTime = DateTime.Now;
            //mReg.payerID = currentUser.Id;
            //mReg.payerName = currentUser.Cname;
            //mReg.paymentDate = DateTime.Parse(txtPaymentDate.Text.Trim());
            //mReg.paymentMode = int.Parse(ddlPaymentMode.SelectedValue.Trim());
            //mReg.payStatus = chkIsPay.Checked ? 1 : 0;
            //mReg.hasInvoice = int.Parse(ddlHasInvoiceNum.SelectedValue.Trim());


            //if (txtHasInvoceDate.Text.Trim() != "") //收到发票日期
            //{
            //    mReg.hasInvoiceDate = Convert.ToDateTime(txtHasInvoceDate.Text);

            //}

            //if (Request.QueryString["ausID"] != null)
            //{
            //    int ausID;
            //    int.TryParse(Request.QueryString["ausID"].ToString(), out ausID);
            //    mReg.ausID = ausID;
            //}

            //RegReimbursementManager bReg = new RegReimbursementManager();

            //ReimbursementInvoice mRI = new ReimbursementInvoice();

            //ReimbursementInvoiceManager bRI = new ReimbursementInvoiceManager();

            //if (Request.QueryString["regID"] != null && Request.QueryString["regID"].ToString().Trim() != string.Empty)
            //{

            //    string regID = Request.QueryString["regID"].ToString().Trim();


            //    if (string.Empty != regID)
            //    {
            //        mReg = bReg.GetModel(regID);

            //        if (mReg != null)
            //        {
            //            mReg.paymentDate = DateTime.Parse(txtPaymentDate.Text.Trim());
            //            mReg.paymentMode = int.Parse(ddlPaymentMode.SelectedValue.Trim());
            //            mReg.payStatus = chkIsPay.Checked ? 1 : 0;
            //            mReg.hasInvoice = int.Parse(ddlHasInvoiceNum.SelectedValue.Trim());
            //            if (this.txtHasInvoceDate.Text.Trim() != "")
            //            {
            //                mReg.hasInvoiceDate = Convert.ToDateTime(this.txtHasInvoceDate.Text);
            //            }

            //            bReg.Update(mReg);

            //            bRI.DeleteByRegID(regID);
            //        }
            //    }
            //}
            //else
            //    bReg.Add(mReg);

            //string jsonString = hidInvoiceDate.Value;

            //List<InvoiceData> invoiceList = ReadJson(jsonString);


            //mRI.reimbursementID = mReg.id;

            //for (int i = 0, len = invoiceList.Count(); i < len; i++)
            //{
            //    InvoiceData invoiceData = invoiceList[i];

            //    mRI.id = Guid.NewGuid().ToString();
            //    mRI.invoiceNum = invoiceData.Num;
            //    mRI.remark = invoiceData.Remark;

            //    if (mRI.invoiceNum.Trim() == string.Empty && mRI.remark.Trim() == string.Empty)
            //        break;

            //    bRI.Add(mRI);
            //}

            //ClientScript.RegisterStartupScript(Page.GetType(), "a", "alert('保存成功');self.location.href='RegReimbursedFormList.aspx';", true);

            #endregion

            EtNet_Models.RegReimbursement reg = new RegReimbursement();
            LoginInfo payUser = Session["login"] as LoginInfo;

            
            if (Request.QueryString["ausID"] != null)
            {
                int ausID;
                int.TryParse(Request.QueryString["ausID"].ToString(), out ausID);
                reg.ausID = ausID;
            }
            reg.makerName = this.lblcanme.Text; //报销人员
            reg.makeTime = DateTime.Parse(this.lblapplydate.Text.Trim());//报销日期
            reg.makerID = LoginInfoManager.getLoginIDByname(this.lblcanme.Text.Trim());//得到报销人员关联id
            reg.payStatus = chkIsPay.Checked ? 1 : 0; //费用是否支付
            reg.paymentMode = 1; /* int.Parse(ddlPaymentMode.SelectedValue.Trim()); //支付方式*/
            reg.payerID = payUser.Id;//支付人关联id
            reg.payerName = payUser.Cname;//支付人名字
            reg.paymentDate = DateTime.Parse(txtPaymentDate.Text.Trim());//支付时间
            reg.payremark = this.iptremark.Value;//支付备注
            reg.bankName = this.iptbankname.Value; //支付银行
            reg.bankNum = this.iptbanknum.Value; //支付帐号
            reg.bankId = int.Parse(this.hidbankid.Value); //支付银行对应id
            RegReimbursementManager regmanager = new RegReimbursementManager();

            if (Request.QueryString["regID"] != null && Request.QueryString["regID"].ToString().Trim() != string.Empty)
            {

                string regID = Request.QueryString["regID"].ToString().Trim();


                if (string.Empty != regID)
                {
                    reg = regmanager.GetModel(regID);

                    if (reg != null)
                    {
                        reg.paymentDate = DateTime.Parse(txtPaymentDate.Text.Trim());
                        reg.paymentMode = 1; /* int.Parse(ddlPaymentMode.SelectedValue.Trim());*/
                        reg.payStatus = chkIsPay.Checked ? 1 : 0;
                        reg.payremark = this.iptremark.Value;
                        reg.bankName = this.iptbankname.Value;
                        reg.bankNum = this.iptbanknum.Value;
                        reg.bankId = int.Parse(this.hidbankid.Value);
                        regmanager.Update(reg);
                    }
                }
            }
            else
            {
                reg.id = Guid.NewGuid().ToString(); //id主键
                regmanager.Add(reg);
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "a", "alert('保存成功');self.location.href='RegReimbursedFormList.aspx';", true);

        }


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
            for (int i = 0; i < itemArr.Count(); i++)
            {
                invoiceData = js.Deserialize<InvoiceData>(itemArr[i]);

                list.Add(invoiceData);
            }

            return list;
        }
    }

    [Serializable]
    public class InvoiceData
    {
        public string Num { get; set; }
        public string Remark { get; set; }
    }
}