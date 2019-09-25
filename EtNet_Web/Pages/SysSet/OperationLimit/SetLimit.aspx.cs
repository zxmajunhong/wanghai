using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.SysSet.OperationLimit
{
    public partial class SetLimit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrderEditLimit();
            }
        }

        /// <summary>
        /// 加载当前的订单编辑权限人员
        /// </summary>
        private void LoadOrderEditLimit()
        {
            LoginOperationLimit model = LoginOperationLimitManager.getLoginOperationLimitByType("1");
            if (model != null)
            {
                if (model.LimitIds.Trim() != "")
                {
                    string sql = " id in (" + model.LimitIds + ")";
                    DataTable dt = LoginInfoManager.getList(sql);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (this.iptuserlist.Value == "")
                        {
                            this.iptuserlist.Value = dt.Rows[i]["cname"].ToString();
                        }
                        else
                        {
                            this.iptuserlist.Value += "," + dt.Rows[i]["cname"].ToString();
                        }
                    }
                }
                else
                {
                    this.iptuserlist.Value = "";
                }
                this.hiduserlist.Value = model.LimitIds;
            }
        }

        /// <summary>
        /// 设置订单编辑权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnuser_Click(object sender, ImageClickEventArgs e)
        {
            LoginOperationLimit model = LoginOperationLimitManager.getLoginOperationLimitByType("1");
            model.LimitIds = this.hiduserlist.Value;
            int result = LoginOperationLimitManager.updateLoginOperationLimit(model);
            if (result > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "order", "alert('设置成功')", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "alert('设置失败')", true);
            }
        }
    }
}