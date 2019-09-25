using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EtNet_Web.Pages.Personnel
{
    public partial class SearchPersonnel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartmentData();
                LoadSelPeople();
                RightPersonData();
                LeftPersonData();
                LoadTxtPeople();

            }
        }




        //加载部门列表数据
        private void LoadDepartmentData()
        {
           IList<EtNet_Models.DepartmentInfo> list = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoAll();
           this.ddldepartment.DataSource = list;
           this.ddldepartment.DataTextField = "departcname";
           this.ddldepartment.DataValueField = "departid";
           this.ddldepartment.DataBind();
           ListItem sitem = new ListItem("所有全部", "0");
           this.ddldepartment.Items.Insert(0, sitem);

        }

        /// <summary>
        /// 加载已有人员的id列表值
        /// </summary>
        private void LoadSelPeople()
        {
            if (Request.Params["plist"] == null)
            {
                this.hidselpeople.Value = "";
            }
            else
            {
                this.hidselpeople.Value = Request.Params["plist"];
            }
        }


        //加载已有人员的名称列表
        private void LoadTxtPeople()
        {
            string strsql = "";
            if (this.hidselpeople.Value != "")
            {
                this.hidtxtpeople.Value = "";
                strsql += " id in(" + this.hidselpeople.Value + ")";
                DataTable tbl =  EtNet_BLL.LoginInfoManager.getList(strsql);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (this.hidtxtpeople.Value == "")
                    {
                        this.hidtxtpeople.Value = tbl.Rows[i]["cname"].ToString();
                    }
                    else
                    {
                        this.hidtxtpeople.Value += "," + tbl.Rows[i]["cname"].ToString();
                    }
                }
            }
            else
            {
                this.hidtxtpeople.Value = "";
            }
        
        }



        /// <summary>
        /// 显示选中人员
        /// </summary>
        private void RightPersonData()
        {    
            string strsql = "";
            if (this.hidselpeople.Value != "")
            {
                strsql += " id in(" + this.hidselpeople.Value + ")";
            }
            DataTable tbl =  EtNet_BLL.LoginInfoManager.getList(strsql);
            if (this.hidselpeople.Value == "")
            {
                tbl.Rows.Clear();
            }
            this.listright.DataSource = tbl;
            this.listright.DataTextField = "cname";
            this.listright.DataValueField = "id";
            this.listright.DataBind();          
        }


        /// <summary>
        /// 显示未选中人员
        /// </summary>
        private void LeftPersonData()
        {
            string strsql = "";
            if (this.hidselpeople.Value != "")
            {
                strsql += "AND  id not in(" + this.hidselpeople.Value + ") ";
            }
            if (this.iptcname.Value.Trim() != "")
            {
                strsql += "AND  cname like '%" + this.iptcname.Value + "%' ";
            }
            if (this.ddldepartment.SelectedIndex != 0)
            {
                strsql += "AND  departid=" + this.ddldepartment.SelectedValue;
            }
            if (strsql != "")
            {
                strsql = strsql.Substring(4);
            }
            DataTable tbl = EtNet_BLL.LoginInfoManager.getList(strsql);
            this.listleft.DataSource = tbl;
            this.listleft.DataTextField = "cname";
            this.listleft.DataValueField = "id";
            this.listleft.DataBind();
        }



        /// <summary>
        /// 添加一个人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addbtn_Click(object sender, EventArgs e)
        {
            int len = this.listleft.Items.Count;         
            if (len!= 0)
            {
                for (int i = 0; i < len; i++)
                {
                    if (this.listleft.Items[i].Selected)
                    {
                        if (this.hidselpeople.Value == "")
                        {
                            this.hidselpeople.Value = this.listleft.Items[i].Value;
                        }
                        else
                        {
                            this.hidselpeople.Value += "," + this.listleft.Items[i].Value;
                        }
                    }
                }
                RightPersonData();
                LeftPersonData();
                LoadTxtPeople();
            }
        }


        //删除一个人员
        protected void delbtn_Click(object sender, EventArgs e)
        {
            int len = this.listright.Items.Count;
            string savelist = ""; //未删除人员的id值列表
            if (len != 0)
            {
                for (int i = 0; i < len; i++)
                {
                    if (!this.listright.Items[i].Selected)
                    {
                        if (savelist == "")
                        {
                            savelist = this.listright.Items[i].Value;
                        }
                        else
                        {
                            savelist += "," + this.listright.Items[i].Value;
                        }
                    }
                }
                this.hidselpeople.Value = savelist;
                RightPersonData();
                LeftPersonData();
                LoadTxtPeople();
            }
        }


        //全部添加
        protected void addallbtn_Click(object sender, EventArgs e)
        {
            int len = this.listleft.Items.Count;
            if (len != 0)
            {
                for (int i = 0; i < len; i++)
                {             
                   if (this.hidselpeople.Value == "")
                   {
                       this.hidselpeople.Value = this.listleft.Items[i].Value;
                   }
                   else
                   {
                      this.hidselpeople.Value += "," + this.listleft.Items[i].Value;
                   }                
                }
                RightPersonData();
                LeftPersonData();
                LoadTxtPeople();
            }

        }


        //全部删除
        protected void selallbtn_Click(object sender, EventArgs e)
        {
            this.hidselpeople.Value = "";
            RightPersonData();
            LeftPersonData();
            LoadTxtPeople();
        }


        //查询
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            LeftPersonData();
        }





    }
}