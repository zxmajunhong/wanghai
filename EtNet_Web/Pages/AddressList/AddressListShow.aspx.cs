using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL.DataPage;
using EtNet_Models;
using EtNet_BLL;

namespace Pages.AddressList
{
    public partial class AddressListShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
                LoadDepartList();
                LoadAddressList();

            }
        }

        /// <summary>
        /// 加载部门列表数据
        /// </summary>
        private void LoadDepartList()
        {
            IList<EtNet_Models.DepartmentInfo> list = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoAll();
            EtNet_Models.DepartmentInfo model = new EtNet_Models.DepartmentInfo();
            model.Departid = 0;
            model.Departcname = "——请选择——";
            list.Insert(0, model);
            this.ddldepart.DataTextField = "departcname";
            this.ddldepart.DataValueField = "departid";
            this.ddldepart.DataSource = list;
            this.ddldepart.DataBind();

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
            if (Session["PageNum"].ToString() != "002")
            {
                Session["PageNum"] = "002";
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
            string strsql = " ";
            if (this.iptcname.Value.Trim() != "")
            {
                strsql += "AND  cname like '%" + this.iptcname.Value.Trim() + "%' ";
            }
            if (this.iptename.Value.Trim() != "")
            {
                strsql += "AND  ename like '%" + this.iptename.Value.Trim() + "%' ";
            }
            if (this.iptscellphone.Value != "")
            {
                strsql += "AND  scellphone like '%" + this.iptscellphone.Value.Trim() + "%' ";
            }
            if (this.iptcellphone.Value.Trim() != "")
            {
                strsql += "AND  cellphone like '%" + this.iptcellphone.Value.Trim() + "%' ";
            }
            if (this.iptphone.Value.Trim() != "")
            {
                strsql += "AND  phone like '%" + this.iptphone.Value.Trim() + "%' ";
            }
            if (this.iptmailbox.Value.Trim() != "")
            {
                strsql += "AND  mailbox like '%" + this.iptmailbox.Value.Trim() + "%' ";
            }
            if (this.ddldepart.SelectedIndex != 0)
            {
                strsql += "AND  departid='" + this.ddldepart.SelectedValue + "' ";
            }

            Session["query"] = strsql;
        }




        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='002'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "002";
                pageset.Pagecount = 5;
                pageset.Pageitem = 15;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
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
        /// 加载通讯录数据
        /// </summary>
        private void LoadAddressList()
        {
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 002);
            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("ViewAddressList", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
                rptdata.DataSource = ds;
                rptdata.DataBind();
            }
            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("ViewAddressList", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                rptdata.DataSource = ds;
                rptdata.DataBind();
            }

        }


        ////显示邮箱
        //public string ShowMailbox(string strmail)
        //{
        //    string result = "";
        //    if (strmail.IndexOf(',') != -1 && strmail.Length > 1)
        //    {
        //        result = strmail.Replace(',', '@');
        //    }

        //    return result;
        //}


        //查询
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadAddressList();
        }


        //重置
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            this.iptcname.Value = "";
            this.iptcellphone.Value = "";
            this.iptename.Value = "";
            this.iptmailbox.Value = "";
            this.iptphone.Value = "";
            this.ddldepart.SelectedIndex = 0;
            this.iptscellphone.Value = "";
            Session["query"] = "";
            LoadAddressList();
        }


        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                    EtNet_BLL.AddressListInfoManager.Delete(int.Parse(e.CommandArgument.ToString()));
                    LoadAddressList();
                    break;

                case "edit":
                    Response.Redirect("AddressListModify.aspx?id=" + e.CommandArgument.ToString());
                    break;

            }
        }



        public static string IntToDepartName(string id)
        {
            if (id == "-1")
            {
                return id = "未选择部门";
            }
            else
            {

                DepartmentInfo Depart = DepartmentInfoManager.getDepartmentInfoById(Convert.ToInt32(id));
                return id = Depart.Departcname;

            }
        }
    }
}