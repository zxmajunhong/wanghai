using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using EtNet_Models;
using System.Web.UI.HtmlControls;
using System.IO;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class CusDetial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCus();
            }

        }

        private void loadCus()
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Customer customer = CustomerManager.getCustomerById(Convert.ToInt32(id));
            //基本信息
            this.lblcuscode.Text = customer.CusCode.ToString() + "　";
            this.lblshortname.Text = customer.CusshortName.ToString() + "　";
            this.lbladdress.Text = customer.Province.ToString() + " " + customer.City.ToString() + "　";
            this.lblcname.Text = customer.CusCName.ToString() + "　";
            this.lblcompanyurl.Text = customer.CompanyURL.ToString() + "　";

            if (customer.CusType == 0)
            {
                this.lblcustype.Text = "暂未选择";
            }
            else
            {
                this.lblcustype.Text = LoginInfoManager.getLoginInfoById(customer.CusType).Cname;
            }

            //if (customer.Used == 0)
            //{
            //    this.lblused.Text = "暂未启用";
            //}
            //else
            //{
            //    this.lblused.Text = "已启用";
            //}


            if (customer.CusPro == 0)
            {
                this.lblcuspro.Text = "新客户";
            }
            else
            {
                this.lblcuspro.Text = "老客户";
            }


            this.lblcaddress.Text = customer.CusCAddress.ToString() + "　";

            //主要联系人
            //this.lbllinkname.Text = customer.LinkName.ToString() + "　";
            //this.lbllinkpost.Text = customer.Post.ToString() + "　";
            //this.lbllinkfax.Text = customer.Fax.ToString() + "　";
            //this.lbllinkemail.Text = customer.Email.ToString() + "　";
            //this.lbllinkmobile.Text = customer.Mobile.ToString() + "　";
            //this.lbllinktel.Text = customer.Telephone.ToString() + "　";
            //this.lbllinkskype.Text = customer.Skype.ToString() + "　";
            //this.lbllinkmsn.Text = customer.Msn.ToString() + "　";

            //主要银行信息
            this.lblbank.Text = customer.Bank.ToString() + "　";
            this.lblbankcard.Text = customer.CardId.ToString() + "　";
            this.lblbankman.Text = customer.CardName.ToString() + "　";
            this.lblremark.Text = customer.Remark.ToString() + "　";

            //提成系数
            this.lblnewRatio.Text = customer.newRatio.ToString();
            this.lbloldRatio.Text = customer.oldRatio.ToString(); 


            this.lblMadeFrom.Text = LoginInfoManager.getLoginInfoById(customer.Madefrom).Cname;
            this.lblMadeTime.Text = customer.MadeTime.ToString("yyyy-MM-dd");

            //加载修改人员和修改日期
            DataTable dt = CustomerManager.GetList(" id = " + id);
            this.lbleditman.Text = dt.Rows[0]["lasteditman"].ToString();
            this.lbleditdate.Text = Convert.IsDBNull(dt.Rows[0]["lasteditdate"]) ? "" : Convert.ToDateTime(dt.Rows[0]["lasteditdate"]).ToString("yyyy-MM-dd");

            loadOtherLink();
            loadOtherBank();
            //LoadAuditImg(customer.Jobflowid);
            //LoadNowAudit(customer.Jobflowid);
        }

        //读取营业部信息
        private void loadOtherBank()
        {
            string id = Request.QueryString["id"].ToString();
            DataTable dt = CusLinkmanManager.getList(Convert.ToInt32(id));
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["departName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["linkName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["telephone"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["fax"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["mobile"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["email"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["msn"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["skype"].ToString();
                    row.Controls.Add(cell);

                    // this.tablelanguage.Controls.Add(row);
                    this.tablelink.Controls.Add(row);
                }
            }


        }
        //读取其他银行信息
        private void loadOtherLink()
        {
            string id = Request.QueryString["id"].ToString();
            DataTable dt = CusBankManager.getList(Convert.ToInt32(id));
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["bank"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["cardId"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["cardName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["remark"].ToString();
                    row.Controls.Add(cell);

                    this.tablebank.Controls.Add(row);
                }
            }
        }

        /// <summary>
        /// 加载当前审核人员的情况
        /// </summary>
        //private void LoadNowAudit(int jfid)
        //{
        //    string strsql = " auditstatus in('03','04') AND id=" + jfid.ToString();
        //    DataTable tbl = EtNet_BLL.JobFlowManager.GetList(strsql);
        //    if (tbl.Rows.Count == 0)
        //    {
        //        strsql = "nowreviewer='T' AND jobflowid=" + jfid;
        //        tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList("reviewerid", strsql);
        //        for (int i = 0; i < tbl.Rows.Count; i++)
        //        {
        //            if (this.hidlist.Value == "")
        //            {
        //                this.hidlist.Value = tbl.Rows[i]["reviewerid"].ToString();
        //            }
        //            else
        //            {
        //                this.hidlist.Value += "," + tbl.Rows[i]["reviewerid"].ToString();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        this.hidlist.Value = "0"; //代表审核结束
        //    }
        //}



        ////加载审核流程图
        //public void LoadAuditImg(int jfid)
        //{
        //    EtNet_Models.JobFlow jobflowmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
        //    EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(jobflowmodel.ruleid);
        //    if (model != null)
        //    {
        //        string strpath = Server.MapPath(model.rolepic);
        //        if (File.Exists(strpath))
        //        {
        //            this.auditpic.InnerHtml = File.ReadAllText(strpath);
        //        }
        //    }
        //}

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            string sqsh = Request.QueryString["sqsh"];
            if (sqsh == "sq")
            {
                Response.Redirect("../CusInfo/Customer.aspx");
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["pageindex"] != null)
                {
                    int page = int.Parse(HttpContext.Current.Request.QueryString["pageindex"]);
                    Response.Redirect("../Job/AuditJobFlow.aspx?page=" + page + "");
                }
                else
                Response.Redirect("../Job/AuditJobFlow.aspx");
            }
        }
    }
}