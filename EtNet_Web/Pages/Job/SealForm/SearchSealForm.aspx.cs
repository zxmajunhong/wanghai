using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

namespace PJOAUI.View.Job.SealForm
{
    public partial class SearchSealForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadAuditJobFlowData();
            }
        }



        /// <summary>
        /// 加载公章申请单数据
        /// </summary>
        private void LoadAuditJobFlowData()
        {

            int jobflowid = int.Parse(Request.QueryString["id"]);

            DataTable tbl = PJOABLL.ViewBLL.ViewApplySealManager.getlist(jobflowid);
            if (tbl.Rows.Count >= 1)
            {
                this.lblnumbers.Text = tbl.Rows[0]["jobflowcname"].ToString();       //公章申请单编号
                this.lblcanme.Text = tbl.Rows[0]["applicantcname"].ToString();  //公章申请人
                this.lbldepart.Text = tbl.Rows[0]["applicantdepartcname"].ToString(); //公章申请人的所属的部门
                this.lblapplydate.Text = tbl.Rows[0]["applydate"].ToString().Substring(0, 10);     //请假单的申请时间
                this.lblsealsort.Text = tbl.Rows[0]["sealsorttxt"].ToString(); //请假的类型
                this.lblusetime.Text = tbl.Rows[0]["borrowstarttime"].ToString() + " —— " + tbl.Rows[0]["borrowsendtime"].ToString();
                this.lblremark.Text = CommonlyUsed.Conversion.StrConversion(tbl.Rows[0]["remark"].ToString());
                string[] audittxt = tbl.Rows[0]["sealtxt"].ToString().Split('|');

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
        /// 加载改变审核规则显示的数据，在LoadAuditJobFlowData方法中调用
        /// </summary>
        private void LoadAuditPic(int id)
        {
            string strpeople = ""; //审核人的列表
            string strpeoplestatus = ""; //审核人是否为当前审核人的列表
            string str = " jobflowid = " + id + " order by numbers asc";
            DataTable tbl = PJOABLL.ViewBLL.ViewAuditJobFlowManager.getList(str);
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
            DataTable tblfile = PJOABLL.JobFlowFileManager.GetList(strfile);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowSealForm.aspx");
        }
    }
}