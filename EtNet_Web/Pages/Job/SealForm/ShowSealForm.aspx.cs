using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace PJOAUI.View.Job.SealForm
{
    public partial class ShowSealForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadAuditStatus();
                LoadSealFormData();
                SiftIsOpen();
            }
        }



        /// <summary>
        /// 加载审核状态
        /// </summary>
        private void LoadAuditStatus()
        {
            DataTable tbl = PJOABLL.JobAuditStatusManager.GetList("");
            DataRow row = tbl.NewRow();
            row["num"] = "00";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);

            row = tbl.NewRow();
            row["num"] = "1234";
            row["txt"] = "全部状态";
            tbl.Rows.InsertAt(row, 1);

            this.ddlauditstatus.DataSource = tbl;
            this.ddlauditstatus.DataTextField = "txt";
            this.ddlauditstatus.DataValueField = "num";
            this.ddlauditstatus.DataBind();

        }


        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((PJOAModels.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='012'";
            DataTable tbl = PJOABLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                PJOAModels.SearchPageSet pageset = new PJOAModels.SearchPageSet();
                pageset.ownersid = ((PJOAModels.LoginInfo)Session["login"]).Id;
                pageset.pagenum = "012";
                pageset.pagecount = 2;
                pageset.pageitem = 2;
                pageset.searchsift = " AND  auditstatus in ('01','02')";
                pageset.siftfence = 0;
                PJOABLL.SearchPageSetManager.Add(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }


        /// <summary>
        /// 是否打开筛选栏
        /// </summary>
        private void SiftIsOpen()
        {
            DataTable tbl = Exists();
            if (tbl.Rows[0]["siftfence"].ToString() == "1")
            {
                this.hidsift.Value = "1";
            }
            else
            {
                this.hidsift.Value = "0";
            }

        }





        /// <summary>
        /// 查询显示请假单的数据
        /// </summary>
        private void LoadSealFormData()
        {
            DataTable tbl = Exists();
            string str = " AND founderid=" + ((PJOAModels.LoginInfo)Session["login"]).Id + " ";
            string strSql = "";
            if (this.tbxnumber.Text.Trim() != "")
            {
                strSql += " AND  jobflowcname like '%" + this.tbxnumber.Text  + "%' ";
            }
            if (this.ddlauditstatus.SelectedIndex != 0)
            {
                if (this.ddlauditstatus.SelectedIndex != 1)
                {
                    strSql += " AND  auditstatus='" + this.ddlauditstatus.SelectedValue + "' ";
                }
                else
                { 
                  strSql += " AND  auditstatus in('01','02','03','04') ";
                }
            }
            if (this.ddlsavestatus.SelectedIndex != 0)
            {
                strSql += " AND  savestatus='" + this.ddlsavestatus.SelectedValue + "' ";
            }

            if (this.iptstartdate.Value.Trim() != "" && this.iptenddate.Value.Trim() != "")
            {
                strSql += " AND  (applydate >= '" + this.iptstartdate.Value + "' AND  applydate <= '" + this.iptenddate.Value + "') ";

            }
            else if (this.iptstartdate.Value.Trim() != "" && this.iptenddate.Value.Trim() == "")
            {
                strSql += " AND  applydate >= '" + this.iptstartdate.Value + "' ";
            }
            else if (this.iptstartdate.Value.Trim() == "" && this.iptenddate.Value.Trim() != "")
            {
                strSql += " AND  applydate <= '" + this.iptenddate.Value + "' ";
            }
            else
            { }
            if (strSql == "")
            {
                strSql = tbl.Rows[0]["searchsift"].ToString();
            }
            else
            {
                int id = int.Parse(tbl.Rows[0]["id"].ToString());
                PJOAModels.SearchPageSet upmodel = PJOABLL.SearchPageSetManager.GetModel(id);
                if (upmodel != null)
                {
                    upmodel.searchsift = strSql;
                    PJOABLL.SearchPageSetManager.Update(upmodel);
                }
            }

            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());

            PJOABLL.DataPage.Data data = new PJOABLL.DataPage.Data();
            DataSet set = data.DataPage("ViewApplySeal", "id", "*", str + strSql, "id", true, pitem, pcount, pages);
            this.rptsealform.DataSource = set;
            this.rptsealform.DataBind();

        }


        /// <summary>
        /// 删除服务器上的文件
        /// </summary>
        private void DelFile(int jobflowid)
        {
            string str = " jobflowid = " + jobflowid;
            DataTable tbl = PJOABLL.JobFlowFileManager.GetList(str);
            if (tbl.Rows.Count >= 1)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string strfile = tbl.Rows[i]["fileload"].ToString();
                    File.Delete(Server.MapPath(strfile));
                }
            }
        
        }


        /// <summary>
        /// 依据不同的审核状态，显示不同颜色
        /// </summary>
        public  string StatusColor(string str)
        {
            string strcolor = "";
            switch (str)
            {
                case "已通过":
                    strcolor = "<span style='color:green'>" + str + "<span>";
                    break;

                case "未开始":
                case "进行中":
                    strcolor = str;
                    break;

                case "被拒绝":
                    strcolor = "<span style='color:red'>" + str + "<span>";
                    break;

            }
            return strcolor;
        }


       

        protected void rptsealform_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    int jobflowid = int.Parse(e.CommandArgument.ToString());
                    PJOAModels.JobFlow model = PJOABLL.JobFlowManager.GetModel(jobflowid);
                    if (model != null && model.savestatus == "草稿")
                    {
                        Response.Redirect("ModifySealForm.aspx?id=" + e.CommandArgument.ToString());
                    }
                    else
                    {
                        LoadSealFormData();
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", "<script>alert('不能修改该公章申请单！')</script>", false);

                    }

                    break;

                case "search":
                    Response.Redirect("SearchSealForm.aspx?id="+ e.CommandArgument.ToString());
                    break;

                case "del":

                    int jfid = int.Parse(e.CommandArgument.ToString());
                    PJOAModels.JobFlow jfmodel = PJOABLL.JobFlowManager.GetModel(jfid);

                    if (jfmodel == null || jfmodel.auditstatus != "01")
                    {
                        LoadSealFormData();
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('删除失败,已删除或审核员已审核！')</script>", false);
                    }
                    else
                    {
                        string strSql = " jobflowid = " + e.CommandArgument.ToString();
                        PJOABLL.AuditJobFlowManager.Delete(strSql);

                        int id = int.Parse(PJOABLL.ApplySealManager.GetList(strSql).Rows[0]["id"].ToString());

                        PJOABLL.ApplySealManager.Delete(id);

                        DelFile(Convert.ToInt32(e.CommandArgument.ToString())); //删除上传的附件
                        PJOABLL.JobFlowFileManager.Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                        //删除工作流
                        PJOABLL.JobFlowManager.Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                        LoadSealFormData();
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('删除成功！')</script>", false);
                    }
                    break;



                case "refresh":
                    int refreshjfid = int.Parse(e.CommandArgument.ToString());
                 
                    PJOAModels.JobFlow refreshmodel = PJOABLL.JobFlowManager.GetModel(refreshjfid);
                    if (refreshmodel != null && (refreshmodel.auditstatus == "01" || refreshmodel.auditstatus == "03"))
                    {
                        string strfresh = " jobflowid = " + e.CommandArgument.ToString();
                        PJOABLL.AuditJobFlowManager.Delete(strfresh); //删除审核人员的数据，公章申请单回到草稿状态
                        refreshmodel.savestatus = "草稿";
                        refreshmodel.auditstatus = "01";

                       
                        string strname = refreshmodel.cname; //公章申请单编号
                        if (PJOABLL.JobFlowManager.Update(refreshmodel))
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "reone", "<script>alert('成功收回单据号为" + strname + "的公章申请单！')</script>", false);
                        }

                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "retwo", "<script>alert('该公章申请单不能回收，原因可能审核人员在审核或审核已通过！')</script>", false);
                    }

                    LoadSealFormData();
                    break;

            }
        }





        protected void ddlsavestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            pages.Visible = true;
            LoadSealFormData();
        }

        protected void tbxnumber_TextChanged(object sender, EventArgs e)
        {
            pages.Visible = true;
            LoadSealFormData();
        }

        protected void ddlauditstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            pages.Visible = true;
            LoadSealFormData();
        }

        protected void ibtnsearchjob_Click(object sender, ImageClickEventArgs e)
        {
            pages.Visible = true;
            LoadSealFormData();
        }

        /// <summary>
        /// 重置查询条件
        protected void ibtnjobreset_Click(object sender, ImageClickEventArgs e)
        {
            pages.Visible = true;
            this.tbxnumber.Text = "";
            this.ddlauditstatus.SelectedIndex = 0;
            this.ddlsavestatus.SelectedIndex = 0;
            this.iptenddate.Value = "";
            this.iptstartdate.Value = "";
            DataTable tbl = Exists();
            int id = int.Parse(tbl.Rows[0]["id"].ToString());
            PJOAModels.SearchPageSet upmodel = PJOABLL.SearchPageSetManager.GetModel(id);
            if (upmodel != null)
            {
                upmodel.searchsift = " AND  auditstatus in ('01','02')";
                PJOABLL.SearchPageSetManager.Update(upmodel);
            }
            LoadSealFormData();
        }



        //公章申请单数据导出
        private DataTable ExportInfoData(string strfields)
        {
            DataTable tblexists = Exists();
            string strSql = " founderid=" + ((PJOAModels.LoginInfo)Session["login"]).Id + " ";
                   strSql += tblexists.Rows[0]["searchsift"].ToString();
 
            DataTable tbl = PJOABLL.ViewBLL.ViewApplySealManager.Getlist(strfields, strSql);
            tbl.Columns["jobflowcname"].ColumnName = "公章单编号";
            tbl.Columns["applydate"].ColumnName = "申请日期";
            tbl.Columns["applicantcname"].ColumnName = "申请人";
            tbl.Columns["auditstutastxt"].ColumnName = "审核状态";
            tbl.Columns["savestatus"].ColumnName = "保存状态";
                 
            return tbl;
        }


        
        //数据导出
        protected void imgbtndata_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8; //注意编码
            Response.AppendHeader("Content-Disposition", "attachment;filename=sealform.xls");
            //设置输出流HttpMiME类型(导出文件格式)
            Response.ContentType = "application/ms-excel"; //image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
            Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">");
            //关闭ViewState
            Page.EnableViewState = false;
            GridView gv = new GridView();
            string strfields = " jobflowcname,applydate,applicantcname,auditstutastxt,savestatus ";

            DataTable tbl = ExportInfoData(strfields);

            gv.DataSource = tbl;
            gv.DataBind();

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter);
            gv.RenderControl(textWriter);
            //把HTML写回游览器
            Response.Write(stringWriter.ToString());
            Response.End();

        }

      




      
    }
}