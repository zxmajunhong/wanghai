using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using EtNet_Models;
using System.IO;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class RegreimbursedFormDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAusRottenData();
            }
        }

        private void LoadAusRottenData()
        {
            string regId = Request.QueryString["regId"];
            string strWhere = " regID = '" + regId + "'";
            DataTable tbl = new RegReimbursementManager().GetViewList(strWhere);
            if (tbl.Rows.Count > 0)
            {
                this.lblnumbers.Text = tbl.Rows[0]["jobflowcname"].ToString();   //报销申请单编号
                this.lblcanme.Text = tbl.Rows[0]["applycantcname"].ToString();   //报销申请人
                this.lblapplydate.Text = Convert.ToDateTime(tbl.Rows[0]["applydate"].ToString()).ToString("yyyy-MM-dd");
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString());
                //收款账户信息
                this.lblbanker.Text = tbl.Rows[0]["skbanker"].ToString();
                this.lblbankname.Text = tbl.Rows[0]["skbankname"].ToString();
                this.lblbanknum.Text = tbl.Rows[0]["skbanknum"].ToString();

                //报销支付数据
                this.lblpaystatus.Text = tbl.Rows[0]["payStatus"].ToString() == "1" ? "已支付" : "未支付";
                string paymentmodel = tbl.Rows[0]["paymentMode"].ToString();
                //this.lblpaymodel.Text = paymentmodel == "2" ? "网银" : (paymentmodel == "1" ? "转账" : "现金");
                this.lblpayer.Text = tbl.Rows[0]["payerName"].ToString();
                this.lblpaydate.Text = Convert.IsDBNull(tbl.Rows[0]["paymentDate"]) ? "" : Convert.ToDateTime(tbl.Rows[0]["paymentDate"]).ToString("yyyy-MM-dd");
                this.lblpaybank.Text = tbl.Rows[0]["bankname"].ToString();
                this.lblpayaccount.Text = tbl.Rows[0]["banknum"].ToString();
                this.lblpayremark.Text = tbl.Rows[0]["payremark"].ToString();

                int jfid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                this.optiniontxt.Attributes.Add("ReadOnly", "true");
                LoadNowAudit(jfid);

                int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                LoadAuditImg(ruleid);
                LoadOrderDetail(tbl.Rows[0]["jobflowid"].ToString());
                LoadDetialData(tbl.Rows[0]["jobflowid"].ToString());
                LoadFile(tbl.Rows[0]["jobflowid"].ToString());
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
        /// 加载订单明细数据
        /// </summary>
        private void LoadOrderDetail(string jfid)
        {
            DataTable dt = EtNet_BLL.AusOrderInfoManager.GetList(jfid);
            rpOrderlist.DataSource = dt;
            rpOrderlist.DataBind();
        }

        /// <summary>
        /// 加载报销明细
        /// </summary>
        private void LoadDetialData(string jfid)
        {
            DataTable tbl = EtNet_BLL.AusDetialInfoManager.GetLists(jfid);
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

            //this.hidausfin.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();

        }

        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        private void LoadFile(string jfid)
        {
            string strsql = " jobflowid=" + jfid;
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

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegReimbursedFormList.aspx");
        }
    }
}