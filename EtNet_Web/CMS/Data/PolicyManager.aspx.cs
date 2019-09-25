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
    public partial class PolicyManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }



        private void BindData()
        {
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["CMSCount"]);
            int page = Convert.ToInt32(ConfigurationManager.AppSettings["CMSPage"]);
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet ds = data.DataPage("ViewOrder", "Id", "*", "", "Id", true, count, page, pages);
            rpPoliy.DataSource = ds;
            rpPoliy.DataBind();
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

        public string GetDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }


        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id">订单的id值</param>
        private void Del(int id)
        {
            To_OrderInfo orderinfo = To_OrderInfoManager.getTo_OrderInfoById(id);
            if (orderinfo != null)
            {
                int jobflowid = orderinfo.JobflowID;
                JobFlow model = JobFlowManager.GetModel(jobflowid);

                string strdel = " jobflowid=" + jobflowid;
                AuditJobFlowManager.Delete(strdel);
                JobFlowManager.Delete(jobflowid);
                To_OrderInfoManager.deleteTo_OrderInfo(Convert.ToInt32(id));
                To_OrderCollectDetialManager.deleteTo_OrderCollectDetialByOrderID(Convert.ToInt32(id));
                To_OrderPayDetialManager.deleteTo_OrderPayDetialByOrderID(Convert.ToInt32(id));
                To_OrderRefunDetialManager.deleteTo_OrderRefunDetialByOrderID(Convert.ToInt32(id));
            }

        }

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
            //去掉最后一个,    
            delId = (delId + ")").Replace(",)", "");
            IList check = delId.Split(',');


            for (int i = 0; i < check.Count; i++)
            {

                To_OrderInfo orderinfo = To_OrderInfoManager.getTo_OrderInfoById(Convert.ToInt32(check[i]));
                if (orderinfo != null)
                {
                    int jobflowid = orderinfo.JobflowID;
                    JobFlow model = JobFlowManager.GetModel(jobflowid);

                    string strdel = " jobflowid=" + jobflowid;
                    AuditJobFlowManager.Delete(strdel);
                    JobFlowManager.Delete(jobflowid);
                    To_OrderInfoManager.deleteTo_OrderInfo(Convert.ToInt32(check[i]));
                    To_OrderCollectDetialManager.deleteTo_OrderCollectDetialByOrderID(Convert.ToInt32(check[i]));
                    To_OrderPayDetialManager.deleteTo_OrderPayDetialByOrderID(Convert.ToInt32(check[i]));
                    To_OrderRefunDetialManager.deleteTo_OrderRefunDetialByOrderID(Convert.ToInt32(check[i]));
                }
            }

            BindData();
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        /// <param name="statusid"></param>
        /// <returns></returns>
        public static string AuditsStatus(string statusid)
        {
            string status = JobAuditStatusManager.GetModelByNUM(statusid).txt;

            if (status == "进行中")
            {
                status = "<span style='color:blue'>" + status + "</span>";
            }
            if (status == "被拒绝")
            {
                status = "<span style='color:red'>" + status + "</span>";
            }
            if (status == "已通过")
            {
                status = "<span style='color:green'>" + status + "</span>";
            }
            return status;
        }


        public static string OrderStatus(string status)
        {
            if (status == "草稿")
            {
            }
            else
            {
                status = "<span style='color:blue'>已提交</span>";
            }
            return status;
        }
        /// <summary>
        /// 订单收款状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string colStatus(string orderId)
        {
            int id = 0;
            int.TryParse(orderId, out id);
            DataTable orderdt = To_OrderCollectDetialManager.getList(id);
            List<string> status = new List<string>();
            for (int i = 0; i < orderdt.Rows.Count; i++)
            {
                status.Add(getStatus(orderdt.Rows[i]["id"].ToString(), orderdt.Rows[i]["money"].ToString()));
            }

            if (status.All<string>(x => x == "0")) //判断是否都为0
            {
                return "<font color='red'>未收款</font>";
            }
            else if (status.All<string>(x => x == "2")) //判断是否都为2
            {
                return "<font color='green'>完成收款</font>";
            }
            else
                return "<font color='blue'>部分收款</font>";
        }



        /// <summary>
        /// 得到状态
        /// </summary>
        /// <param name="ordercolid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public string getStatus(string ordercolid, string money)
        {
            To_ClaimDetailManager manager = new To_ClaimDetailManager();
            double hasAmount = manager.GetHasAmount(ordercolid);
            double shouldAmount = 0;
            double.TryParse(money, out shouldAmount);
            if (hasAmount == 0)
            {
                return "0";
            }
            else
            {
                if (shouldAmount > hasAmount)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
        }
        public string TourLine(int lineid)
        {
            if (lineid > 0)
            {
                return Tb_lineManager.getTb_lineById(lineid).Line.ToString();
            }
            else
            {
                return "线路出现错误";
            }

        }

        public static string madefrom(int madefromid)
        {
            return LoginInfoManager.getLoginInfoById(madefromid).Cname.ToString();
        }
    }
}