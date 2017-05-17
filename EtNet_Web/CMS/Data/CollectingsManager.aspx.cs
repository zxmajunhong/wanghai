using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using System.Collections;
using EtNet_Models;
using System.Configuration;

namespace EtNet_Web.CMS.Data
{
    public partial class CollectingsManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        private void dataBind()
        {
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["CMSCount"]);
            int page = Convert.ToInt32(ConfigurationManager.AppSettings["CMSPage"]);
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("To_Collecting", "Id", "*", "", "Id", true, count, page, pages);
            rpCollecting.DataSource = ds;
            rpCollecting.DataBind();
        }

        protected void rpCollecting_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int count = To_CollectingManager.deleteTo_Collecting(id);
                To_ClaimManager b_claim = new To_ClaimManager();
                To_ClaimDetailManager b_claimDetail = new To_ClaimDetailManager();

                if (count <= 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('删除失败')", true);
                    return;
                }
                string claimID = b_claim.GetID(id);
                if (claimID != "" && b_claim.Delete(int.Parse(claimID)))
                {
                    b_claimDetail.DeleteByClaim(claimID);
                }


            }
            dataBind();
        }



        protected void ibtnDeleteAll_Click(object sender, ImageClickEventArgs e)
        {
            string delId = "";
            //先遍历取得选中项    

            for (int i = 0; i < this.rpCollecting.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)(rpCollecting.Items[i].FindControl("cbx"));
                Label lbl = (Label)rpCollecting.Items[i].FindControl("lbl");
                if (cbx != null || cbx.Text != "")
                {
                    if (cbx.Checked)
                    {
                        delId += lbl.Text + ",";
                    }

                }
            }
            //去掉最后一个,    
            delId = (delId + ")").Replace(",)", "");
            IList check = delId.Split(',');

            To_ClaimManager b_claim = new To_ClaimManager();
            To_ClaimDetailManager b_claimDetail = new To_ClaimDetailManager();

            for (int i = 0; i < check.Count; i++)
            {

                To_Collecting to_Collecting = To_CollectingManager.getTo_CollectingById(Convert.ToInt32(check[i]));
                if (to_Collecting != null)
                {
                    To_CollectingManager.deleteTo_Collecting(Convert.ToInt32(check[i]));
                }
                string claimID = b_claim.GetID(Convert.ToInt32(check[i]));
                if (claimID != "" && b_claim.Delete(int.Parse(claimID)))
                {
                    b_claimDetail.DeleteByClaim(claimID);
                }
            }
            dataBind();
        }


        /// <summary>
        /// 转换收款方式
        /// </summary>
        /// <param name="mode">0：现金；1：转账；2：网银</param>
        /// <returns></returns>
        protected string ChangePaymentMode(string mode)
        {
            switch (mode)
            {
                case "0":
                    return "现金";
                case "1":
                    return "转账";
                case "2":
                    return "网银";
                default:
                    return "未知";
            }
        }
    }
}