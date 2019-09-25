using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.SysSet.SetInitialize
{
    public partial class InitializeUserSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserInitializeData();
            }

        }


        /// <summary>
        /// 加载面板菜单
        /// </summary>
        /// <param name="strlist">面板菜单的id值</param>
        private string LoadPanenMenu(string strlist)
        {
            string result = "";
            string strsql = " id in (" + strlist + ")";
            DataTable tbl =  EtNet_BLL.PanelMenuListManager.GetList(strsql);
            for (int i = 0; i < tbl.Rows.Count; i++ )
            {
                if (result == "")
                {
                    result = tbl.Rows[i]["cname"].ToString();
                }
                else
                {
                    result += "," + tbl.Rows[i]["cname"].ToString();
                }
            }
            return result;
        }



        /// <summary>
        /// 加载用户自定义参数设置
        /// </summary>
        private void LoadUserInitializeData()
        {
            EtNet_Models.LoginInfo model = ((EtNet_Models.LoginInfo)Session["login"]);
            string strsql = " createrid =" + model.Id;
            DataTable tbl =  EtNet_BLL.InitializeUserSetManager.GetList(strsql);
            if (tbl.Rows.Count != 0)
            {
                this.hidval.Value = tbl.Rows[0]["id"].ToString();
                this.iptpagecount.Value = tbl.Rows[0]["pagecount"].ToString();
                this.iptpageitem.Value = tbl.Rows[0]["pageitem"].ToString();
                this.ddlnewinforemind.SelectedValue = tbl.Rows[0]["newinforemind"].ToString();
                this.iptinfocycle.Value = tbl.Rows[0]["infocycle"].ToString();
                this.ddlpanelcols.SelectedValue = tbl.Rows[0]["panelcols"].ToString();
                this.iptpanelcount.Value = tbl.Rows[0]["panelcount"].ToString();
                this.iptlistpanel.Value= LoadPanenMenu(tbl.Rows[0]["panellist"].ToString());
            }
            else
            {
                this.imgbtnsave.Enabled = false;
            }
        }



        /// <summary>
        /// 修改数据列表的显示
        /// </summary>
        /// <param name="sift">是否打筛选栏</param>
        /// <param name="count">导航页数</param>
        /// <param name="item">数据条数</param>
        private void ModifyDataList(int sift,int count,int item)
        {
            EtNet_Models.LoginInfo model = ((EtNet_Models.LoginInfo)Session["login"]);
            string strsql = " ownersid=" + model.Id;
            DataTable tbl =  EtNet_BLL.SearchPageSetManager.GetList(strsql);
            EtNet_Models.SearchPageSet pageset = null;
            int id =0;
            for (int i = 0; i < tbl.Rows.Count; i++)
            { 
                 id = int.Parse(tbl.Rows[i]["id"].ToString());
                 pageset =  EtNet_BLL.SearchPageSetManager.GetModel(id);
                 pageset.Pagecount = count;
                 pageset.Pageitem = item;
                 EtNet_BLL.SearchPageSetManager.updateSearchPageSet(pageset);        
            }       
        }



        //保存修改
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            int id = int.Parse(this.hidval.Value);
            EtNet_Models.InitializeUserSet model =  EtNet_BLL.InitializeUserSetManager.GetModel(id);
            if (this.chkdata.Checked)
            {
                model.pagecount = int.Parse(this.iptpagecount.Value);
                model.pageitem = int.Parse(this.iptpageitem.Value);
                ModifyDataList(model.siftopen, model.pagecount, model.pageitem);
            }
            if (this.chkinformation.Checked)
            {
                model.newinforemind = int.Parse(this.ddlnewinforemind.SelectedValue);
                model.infocycle = int.Parse(this.iptinfocycle.Value);
            }
            if (this.chkpanel.Checked)
            {
                model.panelcount = this.iptpanelcount.Value;
                //model.panelcols = int.Parse(this.ddlpanelcols.SelectedValue);
            }
            if (EtNet_BLL.InitializeUserSetManager.Update(model))
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(),"modify","<script>alert('保存成功!')</script>",false);
            }
        }



    }
}