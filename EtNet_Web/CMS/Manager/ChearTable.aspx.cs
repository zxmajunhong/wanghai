using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.CMS.Manager
{
    public partial class ChearTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 清空指定分类的工作流与工作流的审批情况
        /// </summary>
        /// <param name="sort">工作流的分类</param>
        private void ClearAuditAndJobflow(string sort)
        {
            string strsql = " sort='" + sort + "'";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(strsql);
            if (tbl.Rows.Count != 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    EtNet_BLL.AuditJobFlowManager.Delete(int.Parse(tbl.Rows[i]["id"].ToString()));
                }
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    EtNet_BLL.JobFlowFileManager.Delete(int.Parse(tbl.Rows[j]["jobflowid"].ToString()));
                    EtNet_BLL.JobFlowManager.Delete(int.Parse(tbl.Rows[j]["jobflowid"].ToString()));
                }
            }

            EtNet_BLL.JobFlowManager.DeleteList(strsql);//删除错误数据
            
        }








        /// <summary>
        /// 提示清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnDeleteAll_Click(object sender, ImageClickEventArgs e)
        {
            string str = "";
            if (cbAnnouncement.Checked == true)
            {
                AnnouncementInfoManager.Clear();
                ClearAuditAndJobflow("04");
                str += "公告管理清空完成;\\n";

            }
            if (cbCalendar.Checked == true)
            {
                CalendarsManager.Clear();
                str += "日程管理清空完成;\\n";

            }
            if (cbCompany.Checked == true)
            {
                FactoryManager.Clear();

                str += "付款单位清空完成;\\n";

            }
            if (cbCustomer.Checked == true)
            {
              
                CustomerManager.Clear();
                ClearAuditAndJobflow("03");
                str += "收款单位清空完成;\\n";

            }
            if (cbFinancial.Checked == true)
            {
                To_CollectingManager.Clear();

                str += "收款管理清空完成;\\n";

            }
            if (cbInfomation.Checked == true)
            {
                InformationManager.Clear();

                str += "消息管理清空完成;\\n";

            }
            if (cbInvocie.Checked == true)
            {
                To_InvoiceManager.Clear();

                str += "发票管理清空完成;\\n";

            }
            if (cbLinkInfo.Checked == true)
            {
                AddressListInfoManager.Clear();

                str += "通讯录清空完成;\\n";

            }
            if (cbPicture.Checked == true)
            {
                PictureInfoManager.Clear();

                str += "图片管理清空完成;\\n";

            }
            if (cbPolicy.Checked == true)
            {
               
                To_OrderInfoManager.Clear();
                // ClearAuditAndJobflow("02");
                str += "保单管理清空完成;\\n";

            }
            if (cbReimbursed.Checked == true)
            {
                ClearAuditAndJobflow("01");
                AusRottenInfoManager.Clear();
                str += "报销管理清空完成;\\n";

            }
            // ClientScript.RegisterStartupScript(this.GetType(), "", " <script lanuage=javascript> alert('"+ str +"');</script>"); 
            ClientScript.RegisterClientScriptBlock(this.GetType(), "page", string.Format("alert('{0}');", str), true);
        }





    }
}