using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using EtNet_BLL;

namespace EtNet_Web.Pages.InsureCompany
{
    public partial class ComDetial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCom();
            }
        }


        private void loadCom()
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Company company = CompanyManager.getCompanyById(Convert.ToInt32(id));
            //基本信息
            this.lblcomcode.Text = company.ComCode.ToString();

            if (company.ComType == 0)
            {
                this.lblcomtype.Text = "暂未选择类别";
            }
            else
            {
                this.lblcomtype.Text = ComTypeManager.getComTypeById(company.ComType).TypeName.ToString();
            }

            if (company.Used == 0)
            {
                this.lblused.Text = "暂未启用";
            }
            else
            {
                this.lblused.Text = "已启用";
            }


            this.lbladdress.Text = company.Province.ToString() + " " + company.City.ToString() + "　";
            this.lblcname.Text = company.ComCname.ToString() + "　";
            this.lblcompanyurl.Text = company.ComUrl.ToString() + "　";

            this.lblcaddress.Text = company.ComCAddress.ToString() + "　";
            this.lblshort.Text = company.ComShortName.ToString() + "　";

            //主要联系人
            this.lbllinkname.Text = company.LinkName.ToString() + "　";
            this.lbllinkpost.Text = company.Post.ToString() + "　";
            this.lbllinkfax.Text = company.Fax.ToString() + "　";
            this.lbllinkemail.Text = company.Email.ToString() + "　";
            this.lbllinkmobile.Text = company.Mobile.ToString() + "　";
            this.lbllinktel.Text = company.Telephone.ToString() + "　";
            this.lbllinkskype.Text = company.Skype.ToString() + "　";
            this.lbllinkmsn.Text = company.Msn.ToString() + "　";

            //主要银行信息
            this.lblbank.Text = company.Bank.ToString() + "　";
            this.lblbankcard.Text = company.CardId.ToString() + "　";
            this.lblbankman.Text = company.CardName.ToString() + "　";
            this.lblremark.Text = company.Remark.ToString() + "　";
            this.lblMadeFrom.Text = LoginInfoManager.getLoginInfoById(company.Madefrom).Cname;
            this.lblMadeTime.Text = company.MadeTime.ToString("yyyy-MM-dd");

            loadOtherLink();
            loadOtherBank();
        }


        //读取其他联系人信息
        private void loadOtherBank()
        {
            string id = Request.QueryString["id"].ToString();
            DataTable dt = ComLinkmanManager.getList(Convert.ToInt32(id));
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
                    cell.InnerHtml = dt.Rows[i]["post"].ToString();
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
                    cell.InnerHtml = dt.Rows[i]["msn"].ToString();
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
            DataTable dt = ComBankManager.getList(Convert.ToInt32(id));
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
                    cell.InnerHtml = dt.Rows[i]["cardId"].ToString();
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = dt.Rows[i]["cardName"].ToString();
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
            Response.Redirect("../InsureCompany/Insure.aspx");
        }
    }
}