using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.SysSet
{
    public partial class SearchDepart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                LoadSelDepart();
                RightDepartData();
                LeftDepartData();
                LoadTxtDepart();

            }
        }




     
        /// <summary>
        /// 加载已有部门的id列表值
        /// </summary>
        private void LoadSelDepart()
        {
            if (Request.Params["dlist"] == null)
            {
                this.hidseldepart.Value = "";  
            }
            else
            {
                this.hidseldepart.Value = Request.Params["dlist"];
            }
        }


        //加载已有部门的名称列表
        private void LoadTxtDepart()
        {
            string strsql = "";
            if (this.hidseldepart.Value != "")
            {
                this.hidtxtdepart.Value = "";
                strsql += " departid in(" + this.hidseldepart.Value + ")";
                DataTable tbl =  EtNet_BLL.DepartmentInfoManager.GetList(strsql);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (this.hidtxtdepart.Value == "")
                    {
                        this.hidtxtdepart.Value = tbl.Rows[i]["departcname"].ToString();
                    }
                    else
                    {
                        this.hidtxtdepart.Value += "," + tbl.Rows[i]["departcname"].ToString();
                    }
                }
            }
            else
            {
                this.hidtxtdepart.Value = "";
            }

        }



        /// <summary>
        /// 显示选中部门
        /// </summary>
        private void RightDepartData()
        {
            string strsql = "";
            if (this.hidseldepart.Value != "")
            {
                strsql += " departid in(" + this.hidseldepart.Value + ")";
            }
            DataTable tbl =  EtNet_BLL.DepartmentInfoManager.GetList(strsql);
            if (this.hidseldepart.Value == "")
            {
                tbl.Rows.Clear();
            }
            this.listright.DataSource = tbl;
            this.listright.DataTextField = "departcname";
            this.listright.DataValueField = "departid";
            this.listright.DataBind();
        }


        /// <summary>
        /// 显示未选中部门
        /// </summary>
        private void LeftDepartData()
        {
            string strsql = "";
            if (this.hidseldepart.Value != "")
            {
                strsql += " departid not in(" + this.hidseldepart.Value + ") ";
            }      
            DataTable tbl = EtNet_BLL.DepartmentInfoManager.GetList(strsql);
            this.listleft.DataSource = tbl;
            this.listleft.DataTextField = "departcname";
            this.listleft.DataValueField = "departid";
            this.listleft.DataBind();
        }



        /// <summary>
        /// 添加一个部门
        /// </summary>
        protected void addbtn_Click(object sender, EventArgs e)
        {
            int len = this.listleft.Items.Count;
            if (len != 0)
            {
                for (int i = 0; i < len; i++)
                {
                    if (this.listleft.Items[i].Selected)
                    {
                        if (this.hidseldepart.Value == "")
                        {
                            this.hidseldepart.Value = this.listleft.Items[i].Value;
                        }
                        else
                        {
                            this.hidseldepart.Value += "," + this.listleft.Items[i].Value;
                        }
                    }
                }
                RightDepartData();
                LeftDepartData();
                LoadTxtDepart();
            }
        }


        //删除一个部门
        protected void delbtn_Click(object sender, EventArgs e)
        {
            int len = this.listright.Items.Count;
            string savelist = ""; //未删除部门的id值列表
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
                this.hidseldepart.Value = savelist;
                RightDepartData();
                LeftDepartData();
                LoadTxtDepart();
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
                    if (this.hidseldepart.Value == "")
                    {
                        this.hidseldepart.Value = this.listleft.Items[i].Value;
                    }
                    else
                    {
                        this.hidseldepart.Value += "," + this.listleft.Items[i].Value;
                    }
                }
                RightDepartData();
                LeftDepartData();
                LoadTxtDepart();
            }

        }


        //全部删除
        protected void selallbtn_Click(object sender, EventArgs e)
        {
            this.hidseldepart.Value = "";
            RightDepartData();
            LeftDepartData();
            LoadTxtDepart();
        }


      
    }
}