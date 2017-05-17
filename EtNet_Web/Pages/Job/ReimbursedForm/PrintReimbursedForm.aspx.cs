using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class PrintReimbursedForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAusRottenData();
            }
        }

        /// <summary>
        /// 加载报销单数据
        /// </summary>
        private void LoadAusRottenData()
        {
            object objID = Request.QueryString["id"];
            if (objID == null)
                return;

            int id;
            if (!int.TryParse(objID.ToString(), out id))
                return;

            string str = " id=" + objID.ToString();

            DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(str);
            if (tbl.Rows.Count >= 1)
            {
                this.lblnumbers.Text = tbl.Rows[0]["jobflowcname"].ToString();   //报销申请单编号
                this.lblcanme.Text = tbl.Rows[0]["applycantcname"].ToString();   //填单人员
                //this.lbldepart.Text = tbl.Rows[0]["applycantdepart"].ToString(); //报销申请人的所属的部门
                this.lblapplydate.Text = Convert.ToDateTime(tbl.Rows[0]["applydate"].ToString()).ToString("yyyy-MM-dd");
                //this.lblreimbursedsort.Text = tbl.Rows[0]["typename"].ToString();
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString());
                //this.lblbelongsort.Text = tbl.Rows[0]["belongtxt"].ToString();
                //this.lblbillstate.Text = tbl.Rows[0]["billstatetxt"].ToString();
                int jfid = int.Parse(tbl.Rows[0]["jobflowid"].ToString());
                ltrOptinion.Text = ShowOpiniontxt(jfid);


                int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());

                LoadDetialData(jfid);

            }
        }

        /// <summary>
        /// 加载报销明细
        /// </summary>
        private void LoadDetialData(int jfid)
        {
            DataTable tbl = EtNet_BLL.AusDetialInfoManager.GetLists(jfid.ToString());

            rpAusDetail.DataSource = tbl;
            rpAusDetail.DataBind();

            double total = 0;
            for (int i = 0, length = tbl.Rows.Count; i < length; i++)
            {
                object objAmount = tbl.Rows[i]["ausmoney"];
                if (objAmount != DBNull.Value && objAmount != null)
                    total += Convert.ToDouble(objAmount);
            }

            lblSum.Text = total.ToString("C");
            lblSum1.Text = total.ToString("C");
            lblRMB.Text = MoneyToChinese(total.ToString());
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
            for (int i = 0,len=tbl.Rows.Count; i < len; i++)
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