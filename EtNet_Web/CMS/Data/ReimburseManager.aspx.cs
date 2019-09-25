using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data;

namespace EtNet_Web.CMS.Data
{
    public partial class ReimburseManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private void BindData()
        {
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["CMSCount"]);
            int page = Convert.ToInt32(ConfigurationManager.AppSettings["CMSPage"]);
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("ViewAusRottenInfo", "id", "*", "", "id", true, count, page, pages);
            rpPoliy.DataSource = ds;
            rpPoliy.DataBind();
        }

        /// <summary>
        /// 删除报销单
        /// </summary>
        /// <param name="id">报销单id</param>
        private void Del(int id)
        {
            AusRottenInfo info = AusRottenInfoManager.GetModel(id);
            if (info != null)
            {
                int jobflowid = info.jobflowid;
                string strdel = " jobflowid=" + jobflowid;
                AuditJobFlowManager.Delete(strdel);
                JobFlowManager.Delete(jobflowid);
                JobFlowFileManager.Delete(jobflowid);
                AusDetialInfoManager.Del(jobflowid);
                //RegReimbursementManager.Delete(id.ToString());
                //ReimbursementInvoiceManager;
                AusRottenInfoManager.Delete(id);
            }
        }

        protected void rpPoliy_Command(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Del(id);
            }
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 删除选中的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnDeleteAll_Click(object sender, ImageClickEventArgs e)
        {
            string delId = "";
            //先遍历取得选中项

            for (int i = 0; i < this.rpPoliy.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)(rpPoliy.Items[i].FindControl("cbx"));
                Label lbl = (Label)rpPoliy.Items[i].FindControl("lbl");
                if (cbx != null || cbx.Text != "")
                {
                    if (cbx.Checked)
                    {
                        delId += lbl.Text + ",";
                    }
                }
            }

            //去掉最后一个
            delId = (delId + ")").Replace(",)", "");
            IList check = delId.Split(',');

            for (int i = 0; i < check.Count; i++)
            {
                Del(Convert.ToInt32(check[i]));
            }

            BindData();
        }

        /// <summary>
        /// 显示时间
        /// </summary>
        public string ShowDate(string strdate)
        {
            return Convert.ToDateTime(strdate).ToString("yyyy-MM-dd");

        }

        /// <summary>
        /// 依据不同的审批状态，显示不同颜色
        /// </summary>
        public string ShowColor(string str)
        {
            string result = "";
            switch (str)
            {
                case "未开始":
                case "被拒绝":
                    result = "<span style='color:Red'>" + str + "</span>";
                    break;

                case "已通过":
                    result = "<span style='color:Green'>" + str + "</span>";
                    break;
                default:
                    result = str;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 显示金额
        /// </summary>
        public string ShowMoney(string strmoney)
        {
            string result = "";
            result += Decimal.Round(Decimal.Parse(strmoney), 2).ToString();
            return result;
        }
    }
}