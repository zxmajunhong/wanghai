using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_Models;
using EtNet_BLL;

namespace Pages.Firm
{
    public partial class ShowFirm : System.Web.UI.Page
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
                    LoadFirmData();

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
            if (Session["PageNum"].ToString() != "019")
            {
                Session["PageNum"] = "019";
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
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strsql = "";

            if (this.iptcadr.Value.Trim() != "")
            {
                strsql += "  AND caddress like '%" + this.iptcadr.Value.Trim() + "%'";
            }
            if (this.iptcname.Value.Trim() != "")
            {
                strsql += "  AND cname like '%" + this.iptcname.Value.Trim() + "%'";
            }

            Session["query"] = strsql;
            this.pages.Visible = true;
        }

        //加载公司数据
        private void LoadFirmData()
        {
            DataTable strtbl = Exists();
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            //SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 201);
            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet tbl = data.DataPage("FirmInfo", "id", "*", sqlstr, "id", true, pitem, pcount, pages);
            this.rptfirm.DataSource = tbl;
            this.rptfirm.DataBind();
        }



        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='201'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "201";
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


        //查询
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadFirmData();
        }

        //重置
        protected void imgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.pages.Visible = true;
            this.iptcadr.Value = "";
            this.iptcname.Value = "";
            Session["query"] = "";
            LoadFirmData();
        }
        ///<summary>
        /// 删除公司资料
        /// </summary>
        /// <param name="id">公司id值</param>
        private void DelFirm(int id)
        {
            string result = "";
            string strsql = " ',' + firmidlist + ',' like '%," + id.ToString() + ",%'";
            DataTable tbl = LoginInfoManager.getList(strsql);
            if (tbl.Rows.Count == 0)
            {
                string strdel = " firmid=" + id.ToString();
                FirmAccountInfoManager.Del(strdel);
                if (FirmInfoManager.Delete(id))
                {
                    result = "<script>alert('删除成功')</script>";
                }
                else
                {
                    result = "<script>alert('删除失败')</script>";
                }
            }
            else
            {
                result = "<script>alert('删除失败,有关联的用户资料')</script>";
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", result, false);

        }







        protected void rptfirm_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "searchuser":
                    Response.Redirect("FirmUser.aspx?id=" + e.CommandArgument.ToString());
                    break;
                case "del":
                    int id = int.Parse(e.CommandArgument.ToString());
                    DelFirm(id);
                    LoadFirmData();
                    break;
                case "search":
                    Response.Redirect("DetailFirm.aspx?id=" + e.CommandArgument.ToString());
                    break;
                case "edit":
                    Response.Redirect("ModifyFirm.aspx?id=" + e.CommandArgument.ToString());
                    break;
            }
        }
    }
}