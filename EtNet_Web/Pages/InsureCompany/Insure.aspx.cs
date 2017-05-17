using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL.DataPage;
using System.Data;
using EtNet_BLL;
using EtNet_Models;

namespace EtNet_Web.Pages.InsureCompany
{
    public partial class Insure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
                //getDdl();
                binddata();
               
            }
            LoadZtreeData();
        }

        //绑定列表显示
        //private void getDdl()
        //{
        //    this.ddlType.Items.Clear();
        //    IList<ComType> typelist = ComTypeManager.getComTypeAll();
        //    foreach (var item in typelist)
        //    {
        //        ListItem list = new ListItem(item.TypeName, item.Id.ToString());
        //        this.ddlType.Items.Add(list);
        //    }
        //    ListItem ltem = new ListItem("选择类别", "-1");//添加第一行默认值
        //    this.ddlType.Items.Insert(0, ltem);//添加第一行默认值
        //}

        public string result = "";

        public string LoadZtreeData()
        {
          
            result += "[{id:1, pId: 0, name:'全部分类" + "', icon:'../../Images/public/bfolder.gif', open: true },";

            IList<ComType> typelist = ComTypeManager.getComTypeAll();

            foreach (ComType ct in typelist)
            {
                result += "{id:" + ct.Id + ", pId: 1, name: '" + ct.TypeName + "',icon:'../../Images/public/folder.gif'},";
            }
            result = result.TrimEnd(',') + "]";
            return result;

        }

        //public string StrCount(string sort)
        //{
        //    string result = "";
        //    int count = 0;
        //    int past = 0;
        //    string strsql = " reviewerid =" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND (nowreviewer ='T' OR nowreviewer='p') ";
        //    switch (sort)
        //    {
        //        case "01":
        //            strsql += " AND comType='9' "; //中心
        //            break;

        //        case "02":
        //            strsql += " AND comType='14' "; //测试
        //            break;
                    


        //    }
        //    DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(strsql);
        //    count = tbl.Rows.Count;
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (tbl.Rows[i]["nowreviewer"].ToString() == "T")
        //        {
        //            past++;
        //        }
        //    }
        //    result = past.ToString() + "_" + count.ToString();
        //    return result;

        //}

        //绑定数据
        private void binddata()
        {
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];


            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
            {
                sqlstr += " and madefrom = " + login.Id;

            }
            else
            {
                sqlstr += " and madefrom in (" + ids + "," + login.Id + ")";
            }

            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 002);
            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Company", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
                comList.DataSource = ds;
                comList.DataBind();
            }
            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Company", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                comList.DataSource = ds;
                comList.DataBind();
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


        public static string comtype(string args)
        {

            if (args == "0")
            {
                return args = "<span style='color:red'>未选择类别</span>";
            }
            else
            {
                try
                {
                    return args = ComTypeManager.getComTypeById(Convert.ToInt32(args)).TypeName.ToString();
                }
                catch (Exception)
                {

                    return null;
                }

            }
        }




        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddCom.aspx");
        }

        protected void comList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                string id = e.CommandArgument.ToString();

                int count = To_PolicyManager.getTo_PolicyCountByCompanyID(id);
                if (count > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('该保险公司有保单数据，不能删除。')", true);
                    return;
                }
                else
                {
                    CompanyManager.deleteCompany(Convert.ToInt32(id));
                }

            }
            if (e.CommandName == "Update")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("UpdateCom.aspx?id=" + id);
            }
            if (e.CommandName == "Detial")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("ComDetial.aspx?id=" + id);
            }
            if (e.CommandName == "Read")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Coverage.aspx?id=" + id);
            }
            if (e.CommandName == "Copy")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("CopyCom.aspx?id=" + id);
            }

            binddata();

        }

        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            binddata();
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
            if (Session["PageNum"].ToString() != "010")
            {
                Session["PageNum"] = "010";
                Session["query"] = "";
            }
        }




        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string cname = this.comname.Value.ToString().Trim();
            string caddress = this.comaddress.Value.ToString();
            string linkname = this.clinkname.Value.ToString();
            string cnshortname = this.comshortename.Value.ToString();
            string  rbused = this.rbUsed.SelectedValue.ToString();
            //int cpro;
            //if (this.ddlType.SelectedIndex < 0)
            //{
            //    cpro = -1;
            //}
            //else
            //{
            //    cpro = Convert.ToInt32(this.ddlType.SelectedIndex);
            //}


            string sqlstr = "and comCname like '%" + cname + "%' and comCAddress like '%" + caddress + "%' and linkName like '%" + linkname + "%' and comShortName like '%" + cnshortname + "%'and used like'%"+rbused+"%'";

            //if (cpro != -1)
            //{
            //    sqlstr += " and comPro = " + cpro;
            //}
            //else
            //{
            //    sqlstr += "";
            //}
            //if (this.hidsort.Value != "" && this.hidsort.Value != "1")
            //{
            //    sqlstr += " AND comType='9" + (int.Parse(this.hidsort.Value) - 1).ToString() + "' ";
            //}
            Session["query"] = sqlstr;
        }

        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            string sqlstr = "";
            Session["query"] = null;
            LoginInfo login = (LoginInfo)Session["login"];
            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
            {
                sqlstr += " and madefrom = " + login.Id;

            }
            else
            {
                sqlstr += " and madefrom in (" + ids + "," + login.Id + ")";
            }
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 010);
            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Company", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
                comList.DataSource = ds;
                comList.DataBind();
            }
            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("Company", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                comList.DataSource = ds;
                comList.DataBind();
            }
        }

        //判断是否自己的记录
        public bool IsSelf(object id)
        {
            LoginInfo login = Session["login"] as LoginInfo;
            if (login != null)
            {
                return id.Equals(login.Id);
            }
            else
            {
                return false;
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string sqlstr;
            int id = int.Parse(hidsort.Value.Trim());
            if (id == 1)
            {
                sqlstr = "";
            }
            else
            {
                sqlstr = "and comType='" + id + "'";
            }
            Session["query"] = sqlstr;
            binddata();
        }

    }
}