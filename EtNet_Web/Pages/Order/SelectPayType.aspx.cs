using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.Order
{
    public partial class SelectPayType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPayType();
        }

        /// <summary>
        /// 绑定付款类别数据
        /// </summary>
        private void GetPayType()
        {
            #region 控制相同单位不能选择相同类别的代码（目前不用）
            //string u = Request.QueryString["unit"];
            //string it = Request.QueryString["item"];
            //string[] unit = u.Remove(u.LastIndexOf(','), 1).Split(','); //得到单位id值集合
            //string[] item = it.Remove(it.LastIndexOf(','), 1).Split(','); //得到类别集合
            //string thisUnit = Request.QueryString["thisUnit"].Trim();
            //string sqlitem = ""; //筛选类别的条件
            //DataTable payType = null;
            //if (unit.Contains(thisUnit)) //如果所选择的那行的单位，已经选择过
            //{
            //    for (int i = 0; i < unit.Length; i++)
            //    {
            //        if (unit[i] == thisUnit)
            //        {
            //            sqlitem += item[i] + "','";
            //        }
            //    }
            //    string sql = " itemname not in('" + sqlitem + "')";
            //    payType = AusFinInfoManager.GetList(sql);
            //}
            //else
            //{
            //    payType = AusFinInfoManager.GetList("");
            //}
            //this.type.DataSource = payType;
            //this.type.DataBind();
            #endregion
            this.type.DataSource = AusFinInfoManager.GetList("");
            this.type.DataBind();
        }
    }
}