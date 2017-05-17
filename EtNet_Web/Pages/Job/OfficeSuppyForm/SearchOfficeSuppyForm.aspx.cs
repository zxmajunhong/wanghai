using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

namespace PJOAUI.View.Job.OfficeSuppyForm
{
    public partial class SearchOfficeSuppyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadAuditJobFlowData();
                LoadSupplySetialData();
            }
        }



        /// <summary>
        /// 加载办公用品申请单数据
        /// </summary>
        private void LoadAuditJobFlowData()
        {

            int jobflowid = int.Parse(Request.QueryString["id"]);
            string str = " jobflowid=" + jobflowid ;
            DataTable tbl = EtNet_BLL.ViewBLL.ViewApplyOfficeSupplyManager.getList(str);
            if (tbl.Rows.Count >= 1)
            {
                this.lblnumbers.Text = tbl.Rows[0]["cname"].ToString();       //公章申请单编号
                this.lblcanme.Text = tbl.Rows[0]["logincname"].ToString();  //公章申请人
                this.lbldepart.Text = tbl.Rows[0]["departcname"].ToString(); //公章申请人的所属的部门
                this.lblapplydate.Text = tbl.Rows[0]["applydate"].ToString().Substring(0, 10);     //请假单的申请时间
             
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString());
                string[] audittxt = tbl.Rows[0]["txt"].ToString().Split('|');

                for (int i = 0; i < audittxt.Length; i++)
                {
                    this.lblaudittxt.Text += CommonlyUsed.Conversion.StrConversion(audittxt[i]) + "<br/>";
                }

                LoadFile(jobflowid); //加载原有附件
                string auditfilepath = tbl.Rows[0]["rolepic"].ToString();
                this.auditpic.InnerHtml = File.ReadAllText(Server.MapPath(auditfilepath));
                LoadAuditPic(jobflowid);

                this.iptauditsort.Value = tbl.Rows[0]["rulesort"].ToString();
                this.iptauditstatus.Value = tbl.Rows[0]["auditstatus"].ToString();

            }


        }


        /// <summary>
        /// 加载办公用品申请单的明细的数据
        /// </summary>
        private void LoadSupplySetialData()
        {
            int id = int.Parse(Request.QueryString["id"]); //获取工作流的id值
            string str = " jobflowid=" + id;
            DataTable tbl = EtNet_BLL.ApplyOfficeDetailManager.GetList(str);
            string[] strlist = null;
            if (tbl.Rows.Count >= 1)
            {
                strlist = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    strlist[i] = tbl.Rows[i]["supplybnum"] + "_" + tbl.Rows[i]["suppliesid"] + "_" + tbl.Rows[i]["supplycname"] +"_";
                    strlist[i] += tbl.Rows[i]["sendstatus"].ToString();
                }
                this.iptdetial.Value = String.Join(",", strlist);
            }



        }


        /// <summary>
        /// 加载审核规则显示的数据，在LoadAuditJobFlowData方法中调用
        /// </summary>
        private void LoadAuditPic(int id)
        {
            string strpeople = ""; //审核人的列表
            string strpeoplestatus = ""; //审核人是否为当前审核人的列表
            string str = " jobflowid = " + id + " order by numbers asc";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(str);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                strpeople += (tbl.Rows[i]["reviewerid"].ToString() + ",");
                strpeoplestatus += (tbl.Rows[i]["nowreviewer"].ToString() + ",");

            }

            strpeople = strpeople.Substring(0, strpeople.Length - 1);
            strpeoplestatus = strpeoplestatus.Substring(0, strpeoplestatus.Length - 1);
            this.iptpeople.Value = strpeople;
            this.iptpeopelstatus.Value = strpeoplestatus;




        }




        /// <summary>
        /// 加载原有附件的列表,依据工作流的id值
        /// </summary>
        public void LoadFile(int id)
        {

            string strfile = " jobflowid =" + id;
            DataTable tblfile = EtNet_BLL.JobFlowFileManager.GetList(strfile);
            HtmlTable tbl = new HtmlTable();
            HtmlTableRow filetr = null;
            HtmlTableCell filetd = null;
            HtmlAnchor filea = null;

            if (tblfile.Rows.Count >= 1)
            {

                for (int i = 0; i < tblfile.Rows.Count; i++)
                {
                    filetr = new HtmlTableRow();
                    filetd = new HtmlTableCell();
                    filea = new HtmlAnchor();
                    filea.InnerText = tblfile.Rows[i]["filename"].ToString();
                    filea.HRef = tblfile.Rows[i]["fileload"].ToString();

                    filetd.Controls.Add(filea);
                    filetr.Controls.Add(filetd);
                    tbl.Controls.Add(filetr);

                }
            }
            else
            {
                filetr = new HtmlTableRow();
                filetd = new HtmlTableCell();
                filetd.InnerText = "无附件";
                filetr.Controls.Add(filetd);
                tbl.Controls.Add(filetr);
            }

            this.jobflowfile.Controls.Add(tbl);
        }








        /// <summary>
        /// 返回
        /// </summary>
        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowOfficeSuppyForm.aspx");
        }
    }
}