using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Supplier
{
    public partial class SupplierDetial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCus();
            }

        }

        private void loadCus()
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Factory fact = FactoryManager.getFactoryById(Convert.ToInt32(id));
            //基本信息
            this.lblcuscode.Text = fact.FactCode.ToString() + "　";
            this.lblshortname.Text = fact.FactshortName.ToString() + "　";
            this.lbladdress.Text = fact.Province.ToString() + " " + fact.City.ToString() + "　";
            this.lblcname.Text = fact.FactCName.ToString() + "　";

            if (fact.FactType == 0)
            {
                this.lblcustype.Text = "暂未选择类别";
            }
            else
            {
                this.lblcustype.Text = FactTypeManager.getFactTypeById(fact.FactType).TypeName.ToString();
            }

            if (fact.Used == 0)
            {
                this.lblused.Text = "暂未启用";
            }
            else
            {
                this.lblused.Text = "已启用";
            }


            this.lblcaddress.Text = fact.FactCAddress.ToString() + "　";

            //主要联系人
            this.lbllinkname.Text = fact.LinkeName.ToString() + "　";
            this.lbllinkpost.Text = fact.Duty.ToString() + "　";
            this.lbllinkfax.Text = fact.Fax.ToString() + "　";
            this.lbllinkemail.Text = fact.Email.ToString() + "　";
            this.lbllinkmobile.Text = fact.Mobile.ToString() + "　";
            this.lbllinktel.Text = fact.Telephone.ToString() + "　";
            this.lbllinkskype.Text = fact.Skype.ToString() + "　";
            this.lbllinkmsn.Text = fact.QQ.ToString() + "　";

            //主要银行信息
            this.lblbank.Text = fact.Bank.ToString() + "　";
            this.lblbankcard.Text = fact.AccountID.ToString() + "　";
            this.lblbankman.Text = fact.AccountName.ToString() + "　";
            this.lblremark.Text = fact.Remark.ToString() + "　";


            this.lblMadeFrom.Text = LoginInfoManager.getLoginInfoById(fact.Inputname).Cname;
            this.lblMadeTime.Text = fact.Inputdate.ToString("yyyy-MM-dd");

            //加载修改信息
            DataTable dt = FactoryManager.getList(" id =" + id);
            this.lblEditMan.Text = dt.Rows[0]["lasteditman"].ToString();
            this.lblEditDate.Text = Convert.IsDBNull(dt.Rows[0]["lasteditdate"]) ? "" : Convert.ToDateTime(dt.Rows[0]["lasteditdate"]).ToString("yyyy-MM-dd");

            loadOtherLink();
            loadOtherBank();
        }

        //读取其他联系人信息
        private void loadOtherBank()
        {
            string id = Request.QueryString["id"].ToString();
            DataTable dt = FactLinkmanManager.getList(Convert.ToInt32(id));
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["linkName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["duty"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["telephone"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["fax"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["mobile"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["email"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["qq"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["skype"].ToString();
                    row.Controls.Add(cell);

                    // this.tablelanguage.Controls.Add(row);
                    this.tablelink.Controls.Add(row);
                }
            }


        }
        //读取其他银行信息
        private void loadOtherLink()
        {
            string id = Request.QueryString["id"].ToString();
            DataTable dt = FactBankManager.getList(Convert.ToInt32(id));
            if (dt.Rows.Count > 0)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["bank"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["accountId"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["accountName"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["remark"].ToString();
                    row.Controls.Add(cell);

                    this.tablebank.Controls.Add(row);
                }
            }
        }



        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Supplier/" + Request.QueryString["backURL"]);
        }
    }
}