using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtNet_Web.Job
{
    public partial class AuditError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMessage();
        }



        /// <summary>
        /// 显示审核结果提交失败的原因
        /// </summary>
        private void ShowMessage()
        {
            string str = Request.QueryString["error"].Trim();
            if (str == "2" )
            {
                this.msg.InnerHtml = "审批受限制!";
            }
            else if (str == "0")
            {
                this.msg.InnerHtml = "审批结果提交失败，单据可能被删除或收回!";
              
            }
            else if (str == "1")
            {
                this.msg.InnerHtml = "审批结果提交失败，原因可能是该单据的审批方式是选审或会签,单据已由他人审批!";
            }          
            else
            { 
            
            }
        }

    }
}