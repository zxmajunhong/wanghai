using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EtNet_BLL;
using System.Web.UI.HtmlControls;
using EtNet_Models;

namespace EtNet_Web.Pages.InsureCompany
{
    public partial class CopyCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadcom();
                loadlink();
                loadbank();
                IsEditCuscode();
            }
        }











        private void loadcom()
        {
            string id = Request.QueryString["id"].ToString();
            EtNet_Models.Company com = CompanyManager.getCompanyById(Convert.ToInt32(id));

            this.comCName.Value = com.ComCname.ToString();
            //this.comCode.Value = com.ComCode.ToString();
            this.TxtType.Text = ComTypeManager.getComTypeById(com.ComType).TypeName;
            this.HidTypeID.Value = ComTypeManager.getComTypeById(com.ComType).Id.ToString();
            this.comCAddress.Value = com.ComCAddress.ToString();
            this.companyURL.Value = com.ComUrl.ToString();
            this.address.Text = com.Province.ToString() + " " + com.City.ToString();
            this.comshort.Value = com.ComShortName.ToString();


            this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(((LoginInfo)Session["Login"]).Id).Cname;
            this.lblMadeTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
            //主要联系人
            this.linkName.Value = com.LinkName.ToString();
            this.linkPost.Value = com.Post.ToString();
            this.linkTel.Value = com.Telephone.ToString();
            this.linkMobile.Value = com.Mobile.ToString();
            this.linkFax.Value = com.Fax.ToString();
            this.linkEmail.Value = com.Email.ToString();
            this.linkMsn.Value = com.Msn.ToString();
            this.linkSkype.Value = com.Skype.ToString();

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



        /// <summary>
        /// 客户代码字段是否填写
        /// </summary>
        private void IsEditCuscode()
        {
            DataTable tbl = GetModuleCoding();
            if (tbl.Rows[0]["usecode"].ToString() == "1") //流水号
            {
                this.comCode.Disabled = true;
                this.txtshow.InnerHtml = "(自动生成)";
            }
            else
            {
                this.txtshow.InnerHtml = "*";
            }
        }



        /// <summary>
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = " num = '00002'";
            DataTable tbl = ModuleCodingInfoManager.GetList(strsql);
            if (tbl.Rows.Count == 1)
            {
                return tbl;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 检验是否能成功产生公司代码名称
        /// </summary>
        /// <param name="cuscode">输入的公司代码</param>
        /// <param name="cname">公司代码全称</param>
        /// <param name="attachment">>公司代码不包含流水号</param>
        /// <param name="txt">流水号</param>
        private bool StrNumbers(string strcuscode, out string cuscode, out string codeformat, out string ordernum)
        {
            bool result = true;
            cuscode = ""; //公司代码全称
            codeformat = ""; //名称，不包含流水号
            ordernum = ""; //流水号

            DataTable tbl = GetModuleCoding(); //自动编码
            string txtformat = tbl.Rows[0]["txtformat"].ToString(); //名称的格式
            string usecode = tbl.Rows[0]["usecode"].ToString(); //流水号
            int len = int.Parse(tbl.Rows[0]["orderlen"].ToString()); //流水号长度


            DataTable custbl = null;
            string strsql = ""; //查询字符窜
            if (usecode == "0")
            {
                if (strcuscode.Trim() != "")
                {
                    strsql = "  comCode ='" + strcuscode + "'";
                    custbl = CompanyManager.GetList(strsql);
                    if (custbl.Rows.Count != 0)
                    {
                        result = false;
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('复制失败,公司代码已存在!')</script>");
                    }
                    else
                    {
                        cuscode = strcuscode; //公司代码全称
                    }
                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('复制失败,公司代码不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                codeformat = Numbers(txtformat); //名称
                strsql = "  codeformat= '" + codeformat + "' AND LEN(ordernum) =" + len.ToString();
                custbl = CompanyManager.GetList(1, strsql, " id desc ");

                if (custbl.Rows.Count >= 1)
                {
                    if (custbl.Rows[0]["ordernum"].ToString() != "")
                    {
                        num = int.Parse(custbl.Rows[0]["ordernum"].ToString()) + 1; //流水号
                        if (num.ToString().Length > len)
                        {
                            result = false;
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('复制失败,流水号长度不够!')</script>");
                        }

                    }
                }
                ordernum = num.ToString().PadLeft(len, '0'); //流水号
                cuscode = codeformat + ordernum; //公司代码全称
            }
            return result;
        }





        /// <summary>
        /// 返回名称,不包含流水号
        /// </summary>
        private string Numbers(string txtformat)
        {
            string result = ""; //返回的名称        
            if (txtformat.Contains("[YYYY]"))
            {
                txtformat = txtformat.Replace("[YYYY]", DateTime.Now.ToString("yyyy"));
            }
            if (txtformat.Contains("[YY]"))
            {
                txtformat = txtformat.Replace("[YY]", DateTime.Now.ToString("yy"));
            }
            if (txtformat.Contains("[MM]"))
            {
                txtformat = txtformat.Replace("[MM]", DateTime.Now.ToString("MM"));
            }
            if (txtformat.Contains("[DD]"))
            {
                txtformat = txtformat.Replace("[DD]", DateTime.Now.ToString("dd"));
            }
            result = txtformat;
            return result;
        }













        //添加基本信息
        private void addBase()
        {
            string cuscode ="";
            string codeformat ="";
            string ordernum = "";

            if (StrNumbers(this.comCode.Value, out cuscode, out codeformat, out ordernum))
            {

                //基本信息
                EtNet_Models.Company com = new Company();
                com.ComCode = cuscode;
                com.Codeformat = codeformat;
                com.Ordernum = ordernum;
                // com.Province = this.ddlProvince.SelectedValue;
                //com.City = this.ddlCity.SelectedValue;
                string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
                com.Province = addre[0].ToString();
                com.City = addre[1].ToString();


                com.ComShortName = this.comshort.Value.ToString();
                com.ComCname = this.comCName.Value.ToString();
                com.ComUrl = this.companyURL.Value.ToString();
                com.ComCAddress = this.comCAddress.Value.ToString();
                //com.ComPro = Convert.ToInt32(this.ddlList.SelectedItem.Value);
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

                com.Madefrom = ((LoginInfo)Session["login"]).Id;
                com.MadeTime = DateTime.Now;

                int count = CompanyManager.addCompany(com);
                if (count > 0)
                {
                    addcomlink();
                    addcombank();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('复制成功！');location.href='../InsureCompany/Insure.aspx'", true);
                }
            }
        }





        //添加次要联系人
        private void addcomlink()
        {
            string strList = this.hidlink.Value;
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.ComLinkman comLink = null;
                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); }
                else { row = new string[1] { strList }; }
                for (int i = 0; i < row.Length; i++)
                {
                    comLink = new ComLinkman();
                    cell = row[i].Split('|');
                    comLink.LinkName = cell[0];
                    comLink.Post = cell[1];
                    comLink.Telephone = cell[2];
                    comLink.Fax = cell[3];
                    comLink.Mobile = cell[4];
                    comLink.Email = cell[5];
                    comLink.Msn = cell[6];
                    comLink.Skype = cell[7];
                    comLink.CompanyId = CompanyManager.getLastOneID().Id;
                    ComLinkmanManager.addComLinkman(comLink);

                }
            }
        }


        //添加其他银行
        private void addcombank()
        {
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
                    combank.CompanyId = CompanyManager.getLastOneID().Id;
                    ComBankManager.addComBank(combank);

                }
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {

            string comCode = this.comCode.Value.ToString();
            string comShortName = this.comshort.Value.ToString();
            string comCname = this.comCName.Value.ToString();
            string str = "";
            //if (CompanyManager.getCode(comCode))
            //{
            //    str += "公司代码已存在\\n";
            //}
            if (CompanyManager.getSName(comShortName,0))
            {
                str += "公司简称已存在\\n";
            }
            if (CompanyManager.getCName(comCname,0))
            {
                str += "公司名称已存在\\n";
            }

            int count = CompanyManager.getCount3(comCode, comShortName, comCname);
            if (count <= 0)
            {
                addBase();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            }

        }

        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Insure.aspx");
        }
    }
}