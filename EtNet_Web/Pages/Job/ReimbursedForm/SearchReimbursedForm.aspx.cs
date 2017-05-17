using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class SearchReimbursedForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sqsh = Request.QueryString["sqsh"];
                if (sqsh == "sq")
                {
                    this.ibtnprint.Visible = false;
                    this.ibtnBack1.Visible = false;
                }
                else
                {
                    this.ibtnBack.Visible = false;
                }
                LoadAusRottenData();
                   
                LoadFile();
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
                this.lblcanme.Text = tbl.Rows[0]["applycantcname"].ToString();   //填单人员
                this.lblapplydate.Text = Convert.ToDateTime(tbl.Rows[0]["applydate"].ToString()).ToString("yyyy-MM-dd"); //填单日期
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString()); //备注
                int jfid = int.Parse(tbl.Rows[0]["jobflowid"].ToString()); //得到工作流id
                this.optiniontxt.InnerHtml = ShowOpiniontxt(jfid); //加载审核意见
                //收款账户信息
                this.lblbanker.Text = tbl.Rows[0]["banker"].ToString();
                this.lblbankname.Text = tbl.Rows[0]["bankname"].ToString();
                this.lblbanknum.Text = tbl.Rows[0]["banknum"].ToString();
                LoadNowAudit(jfid);

                int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString()); //审批流程图关联id
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
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string strnumeral = "";
            for (int i = 0; i < tbl.Rows.Count; i++)
            { 
                row = new HtmlTableRow();
                cell = new HtmlTableCell();
                cell.InnerHtml = DateTime.Parse(tbl.Rows[i]["happendate"].ToString()).ToString("yyyy-MM-dd");
                cell.Attributes.Add("class", "clshdate");
                cell.Height = "30px";
                row.Controls.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = (string)tbl.Rows[i]["ausname"];
                cell.Attributes.Add("class", "clshdate");
                cell.Height = "30px";
                row.Controls.Add(cell);

                //EtNet_Models.DepartmentInfo departmentInfo = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(Convert.ToInt32(tbl.Rows[i]["belongsort"]));
                cell = new HtmlTableCell();
                cell.Height = "30px";
                cell.InnerHtml = (string)tbl.Rows[i]["belongsort"];
                cell.Attributes.Add("class", "clshdate");
                row.Controls.Add(cell);

                //EtNet_Models.LoginInfo loginInfo = EtNet_BLL.LoginInfoManager.getLoginInfoById(Convert.ToInt32(tbl.Rows[i]["Salesman"]));
                cell = new HtmlTableCell();
                cell.Height = "30px";
                cell.InnerHtml = (string)tbl.Rows[i]["Salesman"];
                cell.Attributes.Add("class", "clshdate");
                row.Controls.Add(cell);

                cell = new HtmlTableCell();
                cell.Height = "30px";
                strnumeral = tbl.Rows[i]["billnum"].ToString();
                cell.Attributes.Add("class", "clsdigit");
                cell.InnerHtml =  ShowNumeral(strnumeral);
                row.Controls.Add(cell);

                cell = new HtmlTableCell();
                cell.Height = "30px";
                strnumeral = tbl.Rows[i]["ausmoney"].ToString();
                cell.Attributes.Add("class", "clsmoney");
                cell.InnerHtml = ShowNumeral(strnumeral);
                row.Controls.Add(cell);

               

                cell = new HtmlTableCell();
                cell.Height = "30px";
                cell.InnerHtml =  tbl.Rows[i]["remark"].ToString();
                row.Controls.Add(cell);


                this.tblprocess.Controls.Add(row);
               
            }

        }

        /// <summary>
        /// 显示票据张数或金额
        /// </summary>
        /// <returns></returns>
        private string ShowNumeral(string strnumeral)
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
            DataTable tblfile =  EtNet_BLL.JobFlowFileManager.GetList(strsql);
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
            Response.Redirect("ShowReimbursedForm.aspx");
        }

        ///<summary>
        ///返回审核管理页面
        ///</summary>
        protected void ibtnBack_Click1(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["pageindex"] != null)
            {
                int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                Response.Redirect("../AuditJobFlow.aspx?page=" + page + "");
            }
            else
            Response.Redirect("../AuditJobFlow.aspx");
        }

        ///<summary>
        ///跳转到打印界面
        ///</summary>
        protected void ibtnprint_Click(object sender, ImageClickEventArgs e)
        {
            int jobflowid = int.Parse(Request.QueryString["id"]);
            string str = " jobflowid=" + jobflowid.ToString();
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(str);
            string printsh = tbl.Rows[0]["auditstatus"].ToString();
            string printid = tbl.Rows[0]["id"].ToString();
            if (printsh != "04")
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "aa", "alert('未通过审核申请不能打印')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(pages.GetType(), "print", string.Format("printForm(\"{0}\");", printid), true);
            }
        }
    }
}