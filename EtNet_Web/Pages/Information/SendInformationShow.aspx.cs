using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using EtNet_BLL.DataPage;

namespace EtNet_Web.Pages.Information
{
    public partial class SendInformationShow : System.Web.UI.Page
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
                    LoadInformationSortData();
                    LoadInformationData();
                    // SiftIsOpen();
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
            if (Session["PageNum"].ToString() != "008")
            {
                Session["PageNum"] = "008";
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
            string strsqldata = "";
            string createtime = " convert(varchar(10),createtime,120) ";
            if (this.ddlsort.SelectedIndex != 0)
            {
                strsqldata += "  AND sortid =" + this.ddlsort.SelectedValue;
            }
            if (this.ddlstatus.SelectedIndex != 0)
            {
                if (this.ddlstatus.SelectedValue == "已发")
                {
                    strsqldata += "  AND  sendtime < '" + DateTime.Now.ToString() + "'";
                }
                else
                {
                    strsqldata += "  AND  sendtime >= '" + DateTime.Now.ToString() + "'";
                }
            }
            if (this.hidcdate.Value != "")
            {
                string[] list = this.hidcdate.Value.Split(',');
                if (list[0] != "" && list[1] != "")
                {
                    strsqldata += " AND  ( " + createtime + " >= '" + list[0] + "' AND  " + createtime + " <= '" + list[1] + "')";
                }
                else if (list[0] != "" && list[1] == "")
                {
                    strsqldata += " AND " + createtime + " >= '" + list[0] + "'";
                }
                else
                {
                    strsqldata += " AND " + createtime + " <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.ddldate.SelectedValue)
                {
                    case "1":
                        strsqldata += " AND " + createtime + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "2":
                        strsqldata += " AND " + createtime + " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "3":
                        strsqldata += " AND " + createtime + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                        break;

                    case "4":
                        strsqldata += " AND ( " + createtime + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        strsqldata += " AND " + createtime + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "5":
                        strsqldata += " AND ( " + createtime + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        strsqldata += " AND " + createtime + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;
                }
            }
   
            Session["query"] = strsqldata;

        }



        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='008'";
            DataTable tbl =  EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "008";
                pageset.Pagecount = 10;
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
        /// 绑定消息的分类
        /// </summary>
        private void LoadInformationSortData()
        {
            DataTable tbl = EtNet_BLL.InformationSortManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);

            this.ddlsort.DataSource = tbl;
            this.ddlsort.DataValueField = "id";
            this.ddlsort.DataTextField = "txt";
            this.ddlsort.DataBind();
     
        }




        /// <summary>
        /// 加载消息的数据列表
        /// </summary>
        private void LoadInformationData()
        {
            DataTable strtbl = Exists();
            string strfixed = " AND founderid=" +  ((EtNet_Models.LoginInfo)Session["login"]).Id;
            string str = Session["query"].ToString();
              
            int pitem = int.Parse(strtbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(strtbl.Rows[0]["pagecount"].ToString());

            EtNet_BLL.DataPage.Data data = new Data();
            DataSet tbl = data.DataPage("ViewInformation", "id", "*",strfixed + str, "id", true, pitem, pcount, pages);
            this.rptinformation.DataSource = tbl;
            this.rptinformation.DataBind();
        }




        /// <summary>
        ///取得消息的附件
        /// </summary>
        /// <param name="informationid">消息的id值</param>
        private void GetFiles(string informationid)
        {
            string strsql = " informationid=" + informationid;
            DataTable tbl =  EtNet_BLL.InformationFileManager.GetList(strsql);
            string str = "";
            if (tbl.Rows.Count >= 1)
            {
                string strtable = "<table>";
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    strtable += "<tr><td style=\"width:50px; \">" + "附件" + (i + 1) + ":" + "</td>"; ;
                    strtable += "<td><a target=\"_blank\" href=\" InformationFiles.aspx?id=" + tbl.Rows[i]["id"].ToString()+ "\">" + tbl.Rows[i]["filename"].ToString() + "</a></td></tr>";
                }
                strtable += "</table>";
                str += "<script> $(function () { $('<div>" + strtable + "</div>')";
                str += ".window({title: '附件列表',width:300, height:200, minimizable: false,maximizable: false,";
                str += "draggable:false,resizable:false, modal: true });})</script>";
            }
            else
            {
                str = "<script>alert('此消息无附件!')</script>";
            }

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "fs" + DateTime.Now.ToString(), str, false);
        }



        /// <summary>
        /// 依据消息的id值，查询是否具有附件
        /// </summary>
        public string clsfile(string informationid)
        {
            string strsql = " informationid=" + informationid;
            DataTable tbl =  EtNet_BLL.InformationFileManager.GetList(strsql);
            string cls = "";
            if (tbl.Rows.Count >= 1)
            {
                cls = "clsfileshow";
            }
            else
            {
                cls = "clsfilehide";
            }
            return cls;
        }


        /// <summary>
        /// 删除服务器上的文件，以及数据库中的附件表中数据
        /// </summary>
        private void DelFile(int informationid)
        {
            string str = " informationid = " + informationid;
            DataTable tbl =  EtNet_BLL.InformationFileManager.GetList(str);
            if (tbl.Rows.Count >= 1)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string strfile = tbl.Rows[i]["fileload"].ToString();
                    File.Delete(Server.MapPath(strfile));
                     EtNet_BLL.InformationFileManager.Delete(int.Parse(tbl.Rows[i]["id"].ToString()));
                }
            }

        }
       


        protected void rptinformation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch(e.CommandName)
            {

                case "lookfile":
                    string informationid = e.CommandArgument.ToString();//取得消息的id值
                    GetFiles(informationid);
                    break;
               
                case "del":                
                   int id = int.Parse(e.CommandArgument.ToString());//取得消息的id值
                   DelFile(id);
                   EtNet_BLL.InformationNoticeManager.Del(" informationid=" + id);
                   EtNet_BLL.InformationManager.Delete(id);
                   LoadInformationData();     
                   break;  
            }
        }
  
 


        //查询
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            pages.Visible = true;
            ModifyQueryBuilder();
            LoadInformationData();
        }


        //重置
        protected void imgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            pages.Visible = true;
            this.ddlsort.SelectedIndex = 0;
            this.ddlstatus.SelectedIndex = 0;
            this.ddldate.SelectedIndex = 0;
            this.hidcdate.Value = "";
            Session["query"] = "";
            LoadInformationData();
            
        }



  


       


        protected void imgdel_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = null;
            CheckBox chk = null;
            int len = this.rptinformation.Controls.Count;
            int id = 0;
            for (int i = 0; i < len; i++ )
            {
                chk = this.rptinformation.Controls[i].Controls[1] as CheckBox;
                imgbtn = this.rptinformation.Controls[i].Controls[5] as ImageButton;
                if (chk.Checked && imgbtn.CommandArgument != "")
                {
                    id = int.Parse(imgbtn.CommandArgument);
                    DelFile(id);
                    EtNet_BLL.InformationNoticeManager.Del(" informationid=" + id);
                    EtNet_BLL.InformationManager.Delete(id);
                }
            }
            LoadInformationData();
        }



      

    }
}