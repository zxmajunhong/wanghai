using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pages.AddressList
{
    public partial class AddressListSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAddressList();
            }
        }



        //显示邮箱
        public string ShowMailbox(string strmail)
        {
            string result = "";
            if (strmail.IndexOf(',') != -1 && strmail.Length > 1)
            {
                result = strmail.Replace(',', '@');
            }
            else
            {
                result = strmail;
            }
            return result;
        }

        /// <summary>
        /// 加载通讯录
        /// </summary>
        private void LoadAddressList()
        {
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAddressListManager.getList("", "");
            this.rptdata.DataSource = tbl;
            this.rptdata.DataBind();
        }


    }
}