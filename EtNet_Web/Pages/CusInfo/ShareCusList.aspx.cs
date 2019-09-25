using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class ShareCusList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContainsCusList();
                NContainsCusList();
            }
        }


        /// <summary>
        /// 加载已分配的客户
        /// </summary>
        public  void ContainsCusList()
        {
            string id = Request.QueryString["id"];
            this.hidlist.Value = "";
            this.hidtxtlist.Value = "";

            // string strsql = " used=1 AND ( madefrom = " + id + " OR ";
            string strsql = " auditstatus='04' AND ( madefrom = " + id + " OR ";
            strsql += " ',' + viewidlist + ',' like " + "'%," + id + ",%') ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
            this.listright.DataSource = tbl;
            this.listright.DataTextField = "cusCname";
            this.listright.DataValueField = "id";
            this.listright.DataBind();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (this.hidlist.Value =="")
                {
                    this.hidlist.Value = tbl.Rows[i]["id"].ToString();
                    this.hidtxtlist.Value = tbl.Rows[i]["cusCname"].ToString();
                }
                else
                {
                    this.hidlist.Value += "," + tbl.Rows[i]["id"].ToString();
                    this.hidtxtlist.Value += "," + tbl.Rows[i]["cusCname"].ToString();
                }
            }    
        }


        /// <summary>
        /// 加载未分配的客户
        /// </summary>
        public void NContainsCusList()
        {
            string id = Request.QueryString["id"];
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
                strsql += "AND id not in( " + cuslist + " )";
            }
            tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
            this.listleft.DataSource = tbl;
            this.listleft.DataTextField = "cusCname";
            this.listleft.DataValueField = "id";
            this.listleft.DataBind();

           
        }



      
        private void ModifyCus(int cid,string idlist)
        {
            int id =  int.Parse(Request.QueryString["id"]);
            EtNet_Models.Customer cus = null;
            string viewlist = "";
            string viewtxt = "";
            string login = "";
            string logincame = "";
            EtNet_Models.LoginInfo model= EtNet_BLL.LoginInfoManager.getLoginInfoById(id);

            string list = "," + idlist + ",";
            string cusid = "," + cid + ",";
            if (list.IndexOf(cusid) != -1)
            {
                cus = EtNet_BLL.CustomerManager.getCustomerById(cid);
                viewlist = "," + cus.Viewidlist + ",";
                login = "," + id.ToString() + ",";

                if (viewlist.IndexOf(login) == -1)
                {
                    if (cus.Viewidlist != "")
                    {
                        cus.Viewidlist += "," + model.Id.ToString();
                        cus.Viewidtxt += "," + model.Cname;
                    }
                    else
                    {
                        cus.Viewidlist =  model.Id.ToString();
                        cus.Viewidtxt =  model.Cname;
                    }
                    EtNet_BLL.CustomerManager.updateCustomer(cus);
                }

            }
            else
            {
               
                cus = EtNet_BLL.CustomerManager.getCustomerById(cid);
                viewlist = "," + cus.Viewidlist + ",";
                viewtxt = "," + cus.Viewidtxt + ",";
                login = "," + id.ToString() + ",";
                logincame = "," + model.Cname + ",";
                if (viewlist.IndexOf(login) != -1)
                { 
                   cus.Viewidlist = viewlist.Replace(login, "").Trim(',');
                   cus.Viewidtxt =  viewtxt.Replace(logincame, "").Trim(',');
                   EtNet_BLL.CustomerManager.updateCustomer(cus);
                }


            }
          
        }



        private void Save()
        {
            // string strsql = " used=1 ";
            string strsql = " auditstatus='04' ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
            int cusid = 0;
            string idlist = this.hidlist.Value;
            for (int i = 0; i < tbl.Rows.Count; i++ )
            { 
              cusid = int.Parse(tbl.Rows[i]["id"].ToString());
              ModifyCus(cusid, idlist);   
            }

        }




        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            Save();
            ContainsCusList();
            NContainsCusList();
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "save", "<script>closecus()</script>", false);

        }
    }
}