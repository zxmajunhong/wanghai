using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Pages.SysSet.AuditRole
{
    public partial class SearchAuditRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    QueryBuilder();
                    PageSymbolNum();
                    LoadJobflowSort();
                    LoadAuditRoleData();
                }
            }

        }



        /// <summary>
        /// 页面数字标识
        /// </summary>
        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = ""; //如无PageNum，先生成一个
            }
            if (Session["PageNum"].ToString() != "028")
            {
                Session["PageNum"] = "028";
                Session["query"] = "";
            }
        }


        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
            }
        }




        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " Ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND Pagenum='028'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "028";
                pageset.Pagecount = 10;
                pageset.Pageitem = 10;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }








        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strSql = "";
            if (this.iptrolename.Value.Trim() != "")
            {
                strSql += "AND  cname like '%" + this.iptrolename.Value + "%' ";
            }

            if (this.selauditsort.SelectedIndex != 0)
            {
                strSql += "AND  sort='" + this.selauditsort.Value + "' ";
            }

            if (this.seljobflowsort.SelectedIndex != 0)
            {
                strSql += "AND  jobflowsort='" + this.seljobflowsort.Value + "' ";
            } if (this.ddlhide.SelectedValue != "-1")
            {
                strSql += "AND  hide='" + this.ddlhide.SelectedValue + "' ";
            }
            Session["query"] = strSql;

        }


        /// <summary>
        /// 加载工作流的分类
        /// </summary>
        private void LoadJobflowSort()
        {
            DataTable tbl = EtNet_BLL.JobFlowSortManager.GetList("");
            DataRow row = tbl.NewRow();
            row["num"] = "00";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.seljobflowsort.DataSource = tbl;
            this.seljobflowsort.DataTextField = "txt";
            this.seljobflowsort.DataValueField = "num";
            this.seljobflowsort.DataBind();


        }




        /// <summary>
        /// 查询审核规则的数据
        /// </summary>
        private void LoadAuditRoleData()
        {

            DataTable tbl = Exists();
            string str = Session["query"].ToString();
            if (str == "")
            {
                str += " and hide =1";
            }
            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());

            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet set = data.DataPage("ViewApprovalRule", "id", "*", str, "id", true, pitem, pcount, pages);
            this.rptauditrole.DataSource = set;
            this.rptauditrole.DataBind();

        }



        //查询
        protected void ibtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            pages.Visible = true;
            ModifyQueryBuilder();
            LoadAuditRoleData();
        }


        //重置
        protected void ibtnreset_Click(object sender, ImageClickEventArgs e)
        {
            pages.Visible = true;
            this.iptrolename.Value = "";
            this.selauditsort.SelectedIndex = 0;
            this.seljobflowsort.SelectedIndex = 0;
            this.ddlhide.SelectedIndex = 0;
            Session["query"] = "";
            LoadAuditRoleData();
        }



        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptauditrole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                    string str = "ruleid = " + e.CommandArgument.ToString();
                    DataTable tbl = EtNet_BLL.JobFlowManager.GetList(str);
                    if (tbl.Rows.Count >= 1)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "rule", "<script>alert('该规则在使用不能删除！')</script>", false);
                    }
                    else
                    {
                        EtNet_BLL.ApprovalRuleManager.Delete(int.Parse(e.CommandArgument.ToString()));
                        LoadAuditRoleData();
                    }
                    break;
                case "search":
                    Response.Redirect("ShowAuditRole.aspx?id=" + e.CommandArgument.ToString());
                    break;

                case "edit":
                    string stredit = "ruleid = " + e.CommandArgument.ToString();
                    DataTable tbledit = EtNet_BLL.JobFlowManager.GetList(stredit);
                    if (tbledit.Rows.Count >= 1)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ruledit", "<script>alert('该规则有关联的工作流,不能修改！')</script>", false);
                    }
                    else
                    {
                        Response.Redirect("ModifyAddAuditRole.aspx?id=" + e.CommandArgument.ToString());
                    }

                    break;
                case "hide":
                    VisibleAnnouncement(int.Parse(e.CommandArgument.ToString()));
                    break;

            }
        }

        /// <summary>
        /// 隐藏公告
        /// </summary>
        /// <param name="id">公告的id值</param>
        private void VisibleAnnouncement(int id)
        {
            string str = "";
            EtNet_Models.ApprovalRule approvalRule = EtNet_BLL.ApprovalRuleManager.GetModel(id);
            if (approvalRule.hide == 2)
            {
                approvalRule.hide = 1;
                str = "显示成功";
            }
            else
            {
                approvalRule.hide = 2;
                str = "隐藏成功";
            }
            if (!EtNet_BLL.ApprovalRuleManager.UpdateHide(approvalRule))
            {
                str = "隐藏或修改失败";
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "publish", "<script>alert('" + str + "')</script>", false);
            LoadAuditRoleData();
        }


        /// <summary>
        /// 导出数据列表
        /// </summary>
        private DataTable ExportInfoData(string strfields)
        {
            DataTable tblexists = Exists();

            string strSql = CommonlyUsed.Conversion.ExistsEmpty(tblexists.Rows[0]["searchsift"].ToString());
            strSql += tblexists.Rows[0]["searchsift"].ToString();

            DataTable tbl = EtNet_BLL.ViewBLL.ViewApprovalRuleManager.getList(strfields, strSql);
            tbl.Columns["cname"].ColumnName = "名称";
            tbl.Columns["sort"].ColumnName = "审核类型";
            tbl.Columns["jobsorttxt"].ColumnName = "所属工作流";
            tbl.Columns["txt"].ColumnName = "描述";
            return tbl;
        }





        //导出数据
        protected void imgbtndata_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = false;
            Response.ContentEncoding = System.Text.Encoding.Default; //注意编码
            Response.AppendHeader("Content-Disposition", "attachment;filename=Auditrule.xls");
            //设置输出流HttpMiME类型(导出文件格式)
            Response.ContentType = "application/ms-excel"; //image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
            //关闭ViewState
            Page.EnableViewState = false;
            GridView gv = new GridView();
            string strfields = "  cname,sort,jobsorttxt,txt ";
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