using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using System.Data;
using EtNet_BLL.DataPage;
using EtNet_BLL;

namespace EtNet_Web.Pages.Supplier
{
    public partial class Supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("../../Login.aspx");
                    LoadZtreeData();
                }
                else
                {

                    QueryBuilder();
                    PageSymbolNum();
                    dataBind();

                }

            }
            LoadZtreeData();
        }



        private void dataBind()
        {
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            // string ids = LoginDataLimitManager.GetLimit(login.Id);
            // if (string.IsNullOrEmpty(ids))
            // {
            //     sqlstr += " and madefrom = " + login.Id;

            // }
            // else
            // {
            //    sqlstr += " and madefrom in (" + ids + "," + login.Id + ")";
            // }


            //sqlstr += "  madefrom = " + login.Id;

            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 014);
            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Factory", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
                cuslist.DataSource = ds;
                cuslist.DataBind();
            }

            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Factory", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                cuslist.DataSource = ds;
                cuslist.DataBind();
            }


        }

        public static string ifused(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>未启用</span>";
            }
            else
            {
                return args = "<span style='color:blue'>已启用</span>";
            }
        }

        public static string cuspro(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>已成交</span>";
            }
            else
            {
                return args = "<span style='color:blue'>未成交</span>";
            }
        }



        /// <summary>
        /// 修改供应商资料
        /// </summary>
        /// <param name="id">供应商的id值</param>
        private void UpdateCustomer(int id)
        {
            string strsql = " id=" + id;
            // string strfields = " savestatus,auditstatus ";
            DataTable tbl = EtNet_BLL.FactoryManager.getList(strsql);
            if (tbl.Rows.Count != 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('未能加载该供应商资料')</script>", false);
            }
            else
            {
                string localUrl = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.IndexOf(':') + 3);
                string URL = localUrl.Substring(localUrl.LastIndexOf("/")).Replace("/", "");

                Response.Redirect("UpdateSupplier.aspx?id=" + id + "&backURL=" + URL);
            }

        }

        /// <summary>
        ///供应商详情
        /// </summary>
        /// <param name="id">供应商的id值</param>
        private void DetialCustomer(int id)
        {
            string strsql = " id=" + id;
            //string strfields = " jobflowcode ";
            DataTable tbl = EtNet_BLL.FactoryManager.getList(strsql);
            if (tbl.Rows.Count != 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('未能加载该供应商资料')</script>", false);
            }
            else
            {
                string localUrl = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.IndexOf(':') + 3);
                string URL = localUrl.Substring(localUrl.LastIndexOf("/")).Replace("/", "");
                Response.Redirect("SupplierDetial.aspx?id=" + id + "&backURL=" + URL);
            }
        }


        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="id">供应商的id值</param>
        private void DelCustomer(int id)
        {
            string strsql = " id=" + id;
            FactoryManager.deleteFactory(Convert.ToInt32(id));
        }





        /// <summary>
        /// 分享供应商资料
        /// </summary>
        /// <param name="id">供应商的id值</param>
        private void ShareCustomer(int id)
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string strsql = " id=" + id;
            //string strfields = " auditstatus,madefrom,authidlist ";
            DataTable tbl = EtNet_BLL.FactoryManager.getList(strsql);
            if (tbl.Rows[0]["auditstatus"].ToString() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "share", "<script>alert('供应商缺失导致无法设置权限')</script>");
            }
            else
            {
                string compare = "," + login.Id.ToString() + ",";
                string strlist = tbl.Rows[0]["madefrom"].ToString();
                if (tbl.Rows[0]["authidlist"].ToString() != "")
                {
                    strlist += "," + tbl.Rows[0]["authidlist"].ToString();
                }
                strlist = "," + strlist + ",";
                if (strlist.IndexOf(compare) != -1)
                {
                    string tp = "dt" + DateTime.Now.ToString();
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), tp, "<script> share(" + id.ToString() + ")</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "share", "<script>alert('无此权限')</script>");
                }
            }
        }







        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                DelCustomer(id);
            }

            if (e.CommandName == "Update")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                UpdateCustomer(id);
            }
            if (e.CommandName == "Detial")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                DetialCustomer(id);
            }
            if (e.CommandName == "Copy")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("CopyCus.aspx?id=" + id);
            }
            if (e.CommandName == "Share")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                ShareCustomer(id);
            }
            dataBind();
        }



        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            string localUrl = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.IndexOf(':') + 3);
            string URL = localUrl.Substring(localUrl.LastIndexOf("/")).Replace("/", "");
            Response.Redirect("AddSupplier.aspx?&backURL=" + URL);
        }


        /// <summary>
        /// 保存数据列表
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
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
            if (Session["PageNum"].ToString() != "014")
            {
                Session["PageNum"] = "014";
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string cname = this.cname.Value.ToString().Trim();
            string caddress = this.caddress.Value.ToString();
            string clinkname = this.clinkname.Value.ToString();
            string cshortname = this.cshortname.Value.ToString().Trim();


            string sqlstr = "and factCName like '%" + cname + "%' and factCAddress like '%" + caddress + "%' and linkeName like '%" + clinkname + "%' and factshortName like '%" + cshortname + "%'";
            if (this.rbUsed.SelectedValue != "")
            {
                if (this.rbUsed.SelectedValue == "1")
                {
                    sqlstr += " AND  used='1'";
                }
                else if (this.rbUsed.SelectedValue == "0")
                {
                    sqlstr += " AND  used='0'";
                }
            }


            Session["query"] = sqlstr;
        }



        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            dataBind();
        }


        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {

            this.cname.Value = "";
            this.caddress.Value = "";
            this.rbUsed.SelectedItem.Selected = false;
            this.cshortname.Value = "";
            Session["query"] = "";
            dataBind();
        }


        //判断是否自己的记录
        public bool IsSelf(object id)
        {
            //LoginInfo login = Session["login"] as LoginInfo;
            //if (login != null)
            //{
            //    return id.Equals(login.Id);
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        //树形控件
        public string result = "";
        public string LoadZtreeData()
        {
            result += "[{id:999, pId: 0, name:'全部分类" + "', icon:'../../Images/public/bfolder.gif', open: true },";

            IList<FactType> typelist = FactTypeManager.getFactTypeAll();

            foreach (FactType ct in typelist)
            {
                result += "{id:" + ct.Id + ", pId: 999, name: '" + ct.TypeName + "',icon:'../../Images/public/folder.gif'},";
            }
            result = result.TrimEnd(',') + "]";
            return result;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string sqlstr;
            int id = int.Parse(hidsort.Value.Trim());
            if (id == 999)
            {
                sqlstr = "";
            }
            else
            {
                sqlstr = "and factType='" + id + "'";
            }
            Session["query"] = sqlstr;
            dataBind();
        }
    }
}