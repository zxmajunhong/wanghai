using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using System.Data;
using System.Web.UI.HtmlControls;
using EtNet_Models;

namespace EtNet_Web.Pages.InsureCompany
{
    public partial class UpdateCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindList();
                loadcom();
                loadlink();
                loadbank();

            }

        }


        private void loadcom()
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Company com = CompanyManager.getCompanyById(Convert.ToInt32(id));

            this.comCName.Value = com.ComCname.ToString();
            this.comCode.Value = com.ComCode.ToString();

            if (com.ComType == 0)
            {
                this.TxtType.Text = "";
            }
            else
            {
                this.TxtType.Text = ComTypeManager.getComTypeById(com.ComType).TypeName.ToString();
            }
            this.HidTypeID.Value = com.ComType.ToString();
            this.comCAddress.Value = com.ComCAddress.ToString();
            this.companyURL.Value = com.ComUrl.ToString();
            this.address.Text = com.Province.ToString() + " " + com.City.ToString();
            this.comshort.Value = com.ComShortName.ToString();
            this.rbUsed.SelectedValue = com.Used.ToString();
            //主要联系人
            this.linkName.Value = com.LinkName.ToString();
            this.linkPost.Value = com.Post.ToString();
            this.linkTel.Value = com.Telephone.ToString();
            this.linkMobile.Value = com.Mobile.ToString();
            this.linkFax.Value = com.Fax.ToString();
            this.linkEmail.Value = com.Email.ToString();
            this.linkMsn.Value = com.Msn.ToString();
            this.linkSkype.Value = com.Skype.ToString();

            this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(com.Madefrom).Cname;
            this.lblMadeTime.Value = com.MadeTime.ToString("yyyy-MM-dd");
            //主要银行信息
            this.bankName.Value = com.Bank.ToString();
            this.bankCard.Value = com.CardId.ToString();
            this.bankMan.Value = com.CardName.ToString();
            this.bankremark.Value = com.Remark.ToString();
        }


        //加载联系人信息
        private void loadlink()
        {
            string id = Request.QueryString["id"].ToString();

            DataTable tbl = ComLinkmanManager.getList(Convert.ToInt32(id));
            if (tbl.Rows.Count >= 1)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        row = this.tablelink.Controls[1] as HtmlTableRow;
                        cell = row.Controls[0] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkName"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[1] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["post"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[2] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["telephone"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[3] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["fax"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[4] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["mobile"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[5] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["email"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[6] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["msn"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[7] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["skype"] + "' class='clsblurtxt clsedit' />";
                    }
                    else
                    {
                        row = new HtmlTableRow();
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkName"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["post"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["telephone"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["fax"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["mobile"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["email"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["msn"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["skype"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();

                        cell.InnerHtml = "<div title='删除' class='clsimgdel'>&nbsp;</div>";
                        row.Controls.Add(cell);
                        this.tablelink.Controls.Add(row);
                    }
                }
            }
        }

        private void loadbank()
        {
            string id = Request.QueryString["id"].ToString();

            DataTable tbl = ComBankManager.getList(Convert.ToInt32(id));
            if (tbl.Rows.Count >= 1)
            {
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        row = this.tablebank.Controls[1] as HtmlTableRow;
                        cell = row.Controls[0] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["bank"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[1] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cardId"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[2] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cardName"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[3] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"] + "' class='clsblurtxt clsedit' />";
                    }
                    else
                    {
                        row = new HtmlTableRow();
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["bank"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cardId"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cardName"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<div title='删除' class='clsimgdel'>&nbsp;</div>";
                        row.Controls.Add(cell);
                        this.tablebank.Controls.Add(row);
                    }
                }
            }
        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            string comCode = this.comCode.Value.ToString();
            string comShortName = this.comshort.Value.ToString();
            string comCname = this.comCName.Value.ToString();

            int id = Convert.ToInt32(Request.QueryString["id"]);

            string str = "";

            if (CompanyManager.getSName(comShortName, id))
            {
                str += "客户简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            if (CompanyManager.getCName(comCname, id))
            {
                str += "客户全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            addupdateBase();
        }



        //添加基本信息
        private void addupdateBase()
        {
            //基本信息
            EtNet_Models.Company com = new EtNet_Models.Company();
            com.ComCode = this.comCode.Value.ToString();

            string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
            com.Province = addre[0].ToString();
            com.City = addre[1].ToString();


            com.ComShortName = this.comshort.Value.ToString();
            com.ComCname = this.comCName.Value.ToString();
            com.ComUrl = this.companyURL.Value.ToString();
            com.ComCAddress = this.comCAddress.Value.ToString();

            com.ComType = Convert.ToInt32(this.HidTypeID.Value);

            com.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value);
            
            //联系人                                                                                 
            com.LinkName = this.linkName.Value.ToString();
            com.Post = this.linkPost.Value.ToString();
            com.Telephone = this.linkTel.Value.ToString();
            com.Mobile = this.linkMobile.Value.ToString();
            com.Fax = this.linkFax.Value.ToString();
            com.Email = this.linkEmail.Value.ToString();
            com.Msn = this.linkMsn.Value.ToString();
            com.Skype = this.linkSkype.Value.ToString();

            //银行信息
            com.Bank = this.bankName.Value.ToString();
            com.CardId = this.bankCard.Value.ToString();
            com.CardName = this.bankMan.Value.ToString();
            com.Remark = this.bankremark.Value.ToString();
            com.Id = Convert.ToInt32(Request.QueryString["id"].ToString());

            com.Madefrom = ((LoginInfo)Session["login"]).Id;
            com.MadeTime = DateTime.Now;

            com.Ordernum = "";
            com.Codeformat = "";

            int count = CompanyManager.updateCompany(com);
            if (count > 0)
            {
                addcomlink();
                addcombank();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功！');location.href='../InsureCompany/Insure.aspx'", true);
            }
        }

        private void addcombank()
        {
            string id = Request.QueryString["id"].ToString();
            ComBankManager.deleteComBankByComId(Convert.ToInt32(id));

            string banklist = this.hidbank.Value;

            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.ComBank combank = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                for (int i = 0; i < row.Length; i++)
                {
                    combank = new ComBank();
                    cell = row[i].Split('|');
                    combank.Bank = cell[0];
                    combank.CardId = cell[1];
                    combank.CardName = cell[2];
                    combank.Remark = cell[3];
                    combank.CompanyId = Convert.ToInt32(id);
                    ComBankManager.addComBank(combank);
                }
            }
        }

        private void addcomlink()
        {
            string id = Request.QueryString["id"].ToString();
            ComLinkmanManager.deleteComLinkmanByComId(Convert.ToInt32(id));

            string strList = this.hidlink.Value;
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.ComLinkman comlink = null;
                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); }
                else { row = new string[1] { strList }; }
                for (int i = 0; i < row.Length; i++)
                {
                    comlink = new EtNet_Models.ComLinkman();
                    cell = row[i].Split('|');
                    comlink.LinkName = cell[0];
                    comlink.Post = cell[1];
                    comlink.Telephone = cell[2];
                    comlink.Fax = cell[3];
                    comlink.Mobile = cell[4];
                    comlink.Email = cell[5];
                    comlink.Msn = cell[6];
                    comlink.Skype = cell[7];
                    comlink.CompanyId = Convert.ToInt32(id);
                    ComLinkmanManager.addComLinkman(comlink);

                }
            }
        }

        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../InsureCompany/Insure.aspx");
        }
    }
}