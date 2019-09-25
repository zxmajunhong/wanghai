using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Policy
{
    public partial class Preview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqsh = Request.QueryString["sqsh"]; //判断是从申请还是审核到预览界面的
            if (sqsh == "sq")
            {
                this.sqyl.Visible = true;
                this.shyl.Visible = false;
            }
            else
            {
                this.sqyl.Visible = false;
                this.shyl.Visible = true;
            }
            object id = Request.QueryString["id"];
            if (id == null || id.ToString() == "")
                return;
            int rid = 0;
            if (int.TryParse(id.ToString(), out rid))
                InitData(Convert.ToInt32(id));
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
        /// 加载原有附件的列表
        /// </summary>
        private void LoadFile()
        {

            string strfile = " policyID=" + Request.QueryString["id"].ToString();
            EtNet_BLL.To_PolicyFileManager file = new To_PolicyFileManager();
            DataTable tblfile = file.GetList(strfile);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string str = "";
            if (tblfile.Rows.Count >= 1)
            {

                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();

                    cell.InnerHtml = FileIcon(tblfile.Rows[i]["filepath"].ToString());
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = tblfile.Rows[i]["filename"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    str = "<a target='_blank' href='PolicyFiles.aspx?id=" + tblfile.Rows[i]["id"].ToString() + "'>";
                    str += "<img src='../../Images/Public/download.png' /></a>";

                    cell.InnerHtml = str;
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
            string result = "<img src='../../Images/public/";
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
        /// 加载当前保单信息
        /// </summary>
        /// <param name="id"></param>
        private void InitData(int id)
        {
            To_Policy policyModel = new To_Policy();

            DataTable data = To_PolicyManager.GetList(id);

            if (data.Rows.Count > 0)
            {
                LblAssured.Text = data.Rows[0]["assured"].ToString();//被保险人
                //LblBrokerage.Text = data.Rows[0][""].ToString();//经纪费
                LblCompany.Text = data.Rows[0]["comshortname"].ToString();//保险公司
                LblCustomer.Text = data.Rows[0]["cusshortName"].ToString();//投保客户
                LblIsRenewal.Text = Convert.ToInt32(data.Rows[0]["IsRenewal"]) == 0 ? "否" : "是";//是否续保
                
                LblPolicyDate.Text = Convert.ToDateTime(data.Rows[0]["policy_date"]).ToString("yyyy-MM-dd");//保单日期
                LblPolicyMaker.Text = data.Rows[0]["policy_maker"].ToString();//制单人
                LblPolicyNum.Text = data.Rows[0]["policy_num"].ToString();//保单编号
                LblPolicyState.Text = Convert.ToInt32(data.Rows[0]["policy_state"]) == 0 ? "无效" : "有效";//保单状态
                //LblPremium.Text = data.Rows[0][""].ToString();//保费合计

                //LblSalesman.Text = data.Rows[0]["cname"].ToString();//所属业务员
                LoginInfo userInfo = LoginInfoManager.getLoginInfoById(Convert.ToInt32(data.Rows[0]["policy_makerId"]));
                if (userInfo != null)
                {
                    DepartmentInfo department = DepartmentInfoManager.getDepartmentInfoById(userInfo.Departid);
                    if (department != null)
                    {
                        LblMakerDepart.Text = department.Departcname; //制单部门
                    }
                }
                zjjfrate.Text = data.Rows[0]["totalEcoRate"].ToString();//总经济费比率
                zbf.Text = data.Rows[0]["totalPremium"].ToString(); //总保费
                zjjf.Text = data.Rows[0]["totalEconomic"].ToString();//总经济费
                zbe.Text = data.Rows[0]["totalBrokerage"].ToString();//总保额
                ztf.Text = data.Rows[0]["totalRich"].ToString();//总贴费
                cm.Text = data.Rows[0]["shipName"].ToString();//船名

                LblSerialNum.Text = data.Rows[0]["serialnum"].ToString();//内部流水号
                LblTimeEnd.Text = Convert.ToDateTime(data.Rows[0]["policy_enddate"]).ToString("yyyy-MM-dd");//保单日期结束日期
                LblTimeStart.Text = Convert.ToDateTime(data.Rows[0]["policy_startdate"]).ToString("yyyy-MM-dd");//保单日期开始日期
                ltrYearsCount.Text = (Convert.ToDateTime(data.Rows[0]["policy_enddate"]).Year - Convert.ToDateTime(data.Rows[0]["policy_startdate"]).Year).ToString();
                LblType.Text = data.Rows[0]["ProdTypeName"].ToString();//险种        
                optiniontxt.InnerHtml = ShowOpiniontxt(int.Parse(data.Rows[0]["isVerify"].ToString()));//审核人意见
                lblUserCompany.Text = data.Rows[0]["userCompany"].ToString();
                LoadAuditImg(int.Parse(data.Rows[0]["ruleid"].ToString()));

                InitProductType(id);

                LoadNowAudit(data.Rows[0]["isVerify"].ToString());

                BudgetPre1.InitData(id);

                UCTarget1.BindTarget(id);
                
                LoadFile();
            }

         
        }

        /// <summary>
        /// 加载具体保险信息
        /// </summary>
        /// <param name="pid"></param>
        private void InitProductType(int pid)
        {
            ProductManager proBLL = new ProductManager();
            DataTable data = To_PolicyDetailManager.GetListByPolicyid(pid);


            RpProType.DataSource = data;
            RpProType.DataBind();


            decimal coverage = 0;
            decimal premium = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i]["fmone"] != null && data.Rows[i]["rich"] != null)
                {
                    coverage += Convert.ToDecimal(data.Rows[i]["fmone"]);
                    premium += Convert.ToDecimal(data.Rows[i]["rich"]);
                }
            }

            totalCoverage.InnerText = coverage.ToString("C");
            totalPremium.InnerText = premium.ToString("C");
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
        /// 转换文件大小单位
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        protected string ChangeSize(int size)
        {
            decimal newSize = size / 1024;

            if ((newSize / 1024) >= 1)
                return (newSize / 1024).ToString("F2") + "M";
            return newSize.ToString("F2") + "KB";
        }
    }
}