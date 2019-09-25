using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class CusListAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUesrData();
            }
        }


        /// <summary>
        /// 加载用户
        /// </summary>
        private void LoadUesrData()
        {
            DataTable tbl = EtNet_BLL.LoginInfoManager.getList("");
            this.rptdata.DataSource = tbl;
            this.DataBind();  
        }


        /// <summary>
        /// 显示部门
        /// </summary>
        /// <param name="id">部门的id值</param>
        public string ShowDepart(string id)
        {
            string result = "";
            int departid = int.Parse(id);
            EtNet_Models.DepartmentInfo model = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(departid);
            if (model != null)
            { 
              result = model.Departcname;
            }

            return result;     
        }


        /// <summary>
        /// 加载已分配的客户
        /// </summary>
        /// <param name="id">用户的id值</param>
        public string ContainsCusList(string id)
        {
            string result = "";

            // string strsql = " used=1 AND ( madefrom = " + id + " OR ";
            string strsql = " auditstatus='04' AND ( madefrom = " + id + " OR ";
            strsql += " ',' + viewidlist + ',' like " + "'%," + id + ",%') ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("",strsql);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (result == "")
                {
                    result = tbl.Rows[i]["cusCname"].ToString();
                }
                else
                {
                    result += "；" + tbl.Rows[i]["cusCname"].ToString();
                }
            }

            return result;
        }


        /// <summary>
        /// 加载未分配的客户
        /// </summary>
        /// <param name="id">用户的id值</param>
        public string NContainsCusList(string id)
        {
            string result = "";

            string cuslist = ""; //客户的id值
            // string strsql = " used=1 AND ( madefrom = " + id + " OR ";
            string strsql = " auditstatus='04' AND ( madefrom = " + id + " OR ";
            strsql += " ',' + viewidlist + ',' like " + "'%," + id + ",%') ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
            if (tbl.Rows.Count >= 1)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (cuslist == "")
                    {
                        cuslist = tbl.Rows[i]["id"].ToString();
                    }
                    else
                    {
                        cuslist += "," + tbl.Rows[i]["id"].ToString();
                    }
                }
            }

            // strsql = " used=1 ";
            strsql = " auditstatus='04' ";
            if (cuslist != "")
            {
              strsql +=  "AND id not in( " + cuslist + " )";
            }
            tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (result == "")
                {
                    result =  tbl.Rows[i]["cusCname"].ToString();
                }
                else
                {
                    result += "；" + tbl.Rows[i]["cusCname"].ToString();
                }
            }

            return result;
        }


        /// <summary>
        /// 分享客户资料
        /// </summary>
        /// <param name="id">用户的id值</param>
        private void ShareCustomerList(int id)
        {  
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(),"share", "<script> sharelist(" + id.ToString() + ")</script>");
        }





        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString()); //用户的id值
            ShareCustomerList(id);
        }


    }
}