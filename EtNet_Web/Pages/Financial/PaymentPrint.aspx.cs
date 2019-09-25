using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Financial
{
    public partial class PaymentPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["payid"] == null || Request.QueryString["payid"].ToString().Trim() == string.Empty)
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "argerror", "alert('参数错误');", true);
                return;
            }

            string paymentID = Request.QueryString["payid"];
            LoadPaymentData(paymentID);
        }

        private void LoadPaymentData(string paymentID)
        {
            To_PaymentManager bPayment = new To_PaymentManager();

            DataTable dtPayment = bPayment.GetViewPaymentList(string.Format("and id='{0}'", paymentID));

            if (dtPayment.Rows.Count > 0)
            {
                DataRow row = dtPayment.Rows[0];
                lblBank.Text = row["bankName"].ToString();
                lblBankAccount.Text = row["bankAccount"].ToString();
                lblBankAccountName.Text = row["bankAccountName"].ToString();
                lblExpectedDate.Text = DateTime.Parse(row["expectedDate"].ToString()).ToShortDateString();
                lblMaker.Text = row["makerName"].ToString();
                lblPayerCode.Text = row["payerCode"].ToString();
                lblPayerName.Text = row["payerName"].ToString();
                lblPayFor.Text = GetPayForName(row["payFor"]);
                //lblPaymentType.Text = row["paymentType"].ToString() == "0" ? "无票付款" : "邮票付款";
                lblRegType.Text = row["regType"].ToString() == "0" ? "转账" : "现金";
                lblRequestDate.Text = DateTime.Parse(row["requestDate"].ToString()).ToShortDateString();
                lblSerialNumber.Text = row["serialNum"].ToString();
                lblSumAmount.Text = row["totalAmount"].ToString();
                lblSum.Text = row["totalAmount"].ToString();
                lblRMB.Text = MoneyToChinese(row["totalAmount"].ToString());
                //sumBox.InnerText = lblSumAmount.Text;
                ltrBankMark.Text = row["bankMark"].ToString();

                hidPaymentType.Value = row["paymentType"].ToString();

                LoadPaymentDetail(paymentID, row["payFor"].ToString());

                if (row["jobFlowID"] != DBNull.Value)
                    ltrOptinion.Text = ShowOpiniontxt(Convert.ToInt32(row["jobFlowID"]));
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "load", "alert('数据不存在或没有权限查看');location.href='PaymentList.aspx';", true);
            }
        }


        private void LoadPaymentDetail(string paymentID, string fieldName)
        {
            //To_PaymentDetailManager bPaymentDetail = new To_PaymentDetailManager();

            //DataTable dtpaymentDetail = bPaymentDetail.GetPaymentDetail(paymentID, fieldName);
            //RpPaymentDetail.DataSource = dtpaymentDetail;
            //RpPaymentDetail.DataBind();
        }


        /// <summary>
        /// 获取付款名称
        /// </summary>
        /// <param name="payForField"></param>
        /// <returns></returns>
        protected string GetPayForName(object payForField)
        {
            string payForName = "未知";
            if (payForField == DBNull.Value || payForField == null) { return payForName; }

            string payFor = payForField.ToString();

            switch (payFor)
            {
                case "exp_premium":
                    payForName = "代垫保费";
                    break;
                case "exp_commission":
                    payForName = "佣金";
                    break;
                case "exp_tiefei":
                    payForName = "贴费";
                    break;
                case "exp_consultingFees":
                    payForName = "咨询费";
                    break;
                case "exp_serviceCharge":
                    payForName = "服务费";
                    break;
                case "exp_managementFees":
                    payForName = "管理费";
                    break;
                case "exp_other1":
                    payForName = "其他1";
                    break;
                case "exp_other2":
                    payForName = "其他2";
                    break;
                case "exp_other3":
                    payForName = "其他3";
                    break;
                case "exp_other4":
                    payForName = "其他4";
                    break;
                case "exp_other5":
                    payForName = "其他5";
                    break;
                default:
                    break;
            }

            return payForName;
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

        public static string MoneyToChinese(string strAmount)
        {
            string functionReturnValue = null;
            bool IsNegative = false; // 是否是负数
            if (strAmount.Trim().Substring(0, 1) == "-")
            {
                // 是负数则先转为正数
                strAmount = strAmount.Trim().Remove(0, 1);
                IsNegative = true;
            }
            string strLower = null;
            string strUpart = null;
            string strUpper = null;
            int iTemp = 0;
            // 保留两位小数 123.489→123.49　　123.4→123.4
            strAmount = Math.Round(double.Parse(strAmount), 2).ToString();
            if (strAmount.IndexOf(".") > 0)
            {
                if (strAmount.IndexOf(".") == strAmount.Length - 2)
                {
                    strAmount = strAmount + "0";
                }
            }
            else
            {
                strAmount = strAmount + ".00";
            }
            strLower = strAmount;
            iTemp = 1;
            strUpper = "";
            while (iTemp <= strLower.Length)
            {
                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {
                    case ".":
                        strUpart = "圆";
                        break;
                    case "0":
                        strUpart = "零";
                        break;
                    case "1":
                        strUpart = "壹";
                        break;
                    case "2":
                        strUpart = "贰";
                        break;
                    case "3":
                        strUpart = "叁";
                        break;
                    case "4":
                        strUpart = "肆";
                        break;
                    case "5":
                        strUpart = "伍";
                        break;
                    case "6":
                        strUpart = "陆";
                        break;
                    case "7":
                        strUpart = "柒";
                        break;
                    case "8":
                        strUpart = "捌";
                        break;
                    case "9":
                        strUpart = "玖";
                        break;
                }

                switch (iTemp)
                {
                    case 1:
                        strUpart = strUpart + "分";
                        break;
                    case 2:
                        strUpart = strUpart + "角";
                        break;
                    case 3:
                        strUpart = strUpart + "";
                        break;
                    case 4:
                        strUpart = strUpart + "";
                        break;
                    case 5:
                        strUpart = strUpart + "拾";
                        break;
                    case 6:
                        strUpart = strUpart + "佰";
                        break;
                    case 7:
                        strUpart = strUpart + "仟";
                        break;
                    case 8:
                        strUpart = strUpart + "万";
                        break;
                    case 9:
                        strUpart = strUpart + "拾";
                        break;
                    case 10:
                        strUpart = strUpart + "佰";
                        break;
                    case 11:
                        strUpart = strUpart + "仟";
                        break;
                    case 12:
                        strUpart = strUpart + "亿";
                        break;
                    case 13:
                        strUpart = strUpart + "拾";
                        break;
                    case 14:
                        strUpart = strUpart + "佰";
                        break;
                    case 15:
                        strUpart = strUpart + "仟";
                        break;
                    case 16:
                        strUpart = strUpart + "万";
                        break;
                    default:
                        strUpart = strUpart + "";
                        break;
                }

                strUpper = strUpart + strUpper;
                iTemp = iTemp + 1;
            }

            strUpper = strUpper.Replace("零拾", "零");
            strUpper = strUpper.Replace("零佰", "零");
            strUpper = strUpper.Replace("零仟", "零");
            strUpper = strUpper.Replace("零零零", "零");
            strUpper = strUpper.Replace("零零", "零");
            strUpper = strUpper.Replace("零角零分", "整");
            strUpper = strUpper.Replace("零分", "整");
            strUpper = strUpper.Replace("零角", "零");
            strUpper = strUpper.Replace("零亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("零亿零万", "亿");
            strUpper = strUpper.Replace("零万零圆", "万圆");
            strUpper = strUpper.Replace("零亿", "亿");
            strUpper = strUpper.Replace("零万", "万");
            strUpper = strUpper.Replace("零圆", "圆");
            strUpper = strUpper.Replace("零零", "零");

            // 对壹圆以下的金额的处理
            if (strUpper.Substring(0, 1) == "圆")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "零")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "角")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "分")
            {
                strUpper = strUpper.Substring(1, strUpper.Length - 1);
            }
            if (strUpper.Substring(0, 1) == "整")
            {
                strUpper = "零圆整";
            }
            functionReturnValue = strUpper;

            if (IsNegative == true)
            {
                return "负" + functionReturnValue;
            }
            else
            {
                return functionReturnValue;
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
            for (int i = 0, len = tbl.Rows.Count; i < len; i++)
            {
                //result += "<span style=\"height:30px;line-height:30px;width:100%;display:block;\">" + tbl.Rows[i]["reviewername"] + "：</span><br/>";

                result += "<span style=\"height:30px;line-height:30px;width:100%;display:block;\">" + tbl.Rows[i]["reviewername"] + "的审批意见:";
                result += tbl.Rows[i]["opiniontxt"] + "</span><span style='margin-left:5px;'>(审批时间:";
                result += DateTime.Parse(tbl.Rows[i]["audittime"].ToString()).ToString("yyyy-MM-dd hh:mm:ss") + ")</span><br/>";
            }
            return result;
        }
    }
}