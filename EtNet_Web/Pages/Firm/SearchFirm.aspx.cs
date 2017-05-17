using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.Firm
{
    public partial class SearchFirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSelFirm();
                RightFirmData();
                LeftFirmData();
                LoadTxtFirm();
            }
        }


        /// <summary>
        /// 加载已有公司的id列表值
        /// </summary>
        private void LoadSelFirm()
        {
            if (Request.Params["firmlist"] == null)
            {
                this.hidselfirm.Value = "";
            }
            else
            {
                this.hidselfirm.Value = Request.Params["firmlist"];
            }
        }


        //加载已有公司的名称列表
        private void LoadTxtFirm()
        {
            string strsql = "";
            if (this.hidselfirm.Value != "")
            {
                this.hidtxtfirm.Value = "";
                strsql += " id in(" + this.hidselfirm.Value + ")";
                DataTable tbl = EtNet_BLL.FirmInfoManager.GetList(strsql);
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (this.hidtxtfirm.Value == "")
                    {
                        this.hidtxtfirm.Value = tbl.Rows[i]["cname"].ToString();
                    }
                    else
                    {
                        this.hidtxtfirm.Value += "," + tbl.Rows[i]["cname"].ToString();
                    }
                }
            }
            else
            {
                this.hidtxtfirm.Value = "";
            }

        }



        /// <summary>
        /// 显示选中的公司
        /// </summary>
        private void RightFirmData()
        {
            string strsql = "";
            if (this.hidselfirm.Value != "")
            {
                strsql += " id in(" + this.hidselfirm.Value + ")";
            }
            DataTable tbl = EtNet_BLL.FirmInfoManager.GetList(strsql);
            if (this.hidselfirm.Value == "")
            {
                tbl.Rows.Clear();
            }
            this.listright.DataSource = tbl;
            this.listright.DataTextField = "cname";
            this.listright.DataValueField = "id";
            this.listright.DataBind();
        }



        /// <summary>
        /// 显示未选中的公司
        /// </summary>
        private void LeftFirmData()
        {
            string strsql = "";
            if (this.hidselfirm.Value != "")
            {
                strsql += "AND  id not in(" + this.hidselfirm.Value + ") ";
            }
            if (this.iptcname.Value.Trim() != "")
            {
                strsql += "AND  cname like '%" + this.iptcname.Value + "%' ";
            }
            if (this.iptaddress.Value !="")
            {
                strsql += "AND  caddress like '%" + this.iptaddress.Value + "%' ";
            }
            if (strsql != "")
            {
                strsql = strsql.Substring(4);
            }
            DataTable tbl = EtNet_BLL.FirmInfoManager.GetList(strsql);
            this.listleft.DataSource = tbl;
            this.listleft.DataTextField = "cname";
            this.listleft.DataValueField = "id";
            this.listleft.DataBind();
        }




        //查询
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            LeftFirmData();
        }


        //添加公司
        protected void addbtn_Click(object sender, EventArgs e)
        {
            int len = this.listleft.Items.Count;
            if (len != 0)
            {
                for (int i = 0; i < len; i++)
                {
                    if (this.listleft.Items[i].Selected)
                    {
                        if (this.hidselfirm.Value == "")
                        {
                            this.hidselfirm.Value = this.listleft.Items[i].Value;
                        }
                        else
                        {
                            this.hidselfirm.Value += "," + this.listleft.Items[i].Value;
                        }
                    }
                }
                RightFirmData();
                LeftFirmData();
                LoadTxtFirm();
            }
        }


        //删除公司
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
                this.hidselfirm.Value = savelist;
                RightFirmData();
                LeftFirmData();
                LoadTxtFirm();
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
                    if (this.hidselfirm.Value == "")
                    {
                        this.hidselfirm.Value = this.listleft.Items[i].Value;
                    }
                    else
                    {
                        this.hidselfirm.Value += "," + this.listleft.Items[i].Value;
                    }
                }

                RightFirmData();
                LeftFirmData();
                LoadTxtFirm();
            }

        }



        //全部删除
        protected void selallbtn_Click(object sender, EventArgs e)
        {
            this.hidselfirm.Value = "";
            RightFirmData();
            LeftFirmData();
            LoadTxtFirm();
        }



    }
}