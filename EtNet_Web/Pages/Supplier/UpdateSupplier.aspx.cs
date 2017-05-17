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

namespace EtNet_Web.Pages.Supplier
{
    public partial class UpdateSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bindList();
                // LoadRule();
                loadcus();
                loadlink();
                loadbank();

            }
        }


        //绑定公司类别
        //private void bindList()
        //{
        //    this.ddlList.Items.Clear();
        //    IList<CusType> typelist = CusTypeManager.getCusTypeAll();
        //    foreach (var item in typelist)
        //    {
        //        ListItem list = new ListItem(item.TypeName, item.Id.ToString());
        //        this.ddlList.Items.Add(list);
        //    }
        //    ListItem ltem = new ListItem("选择类别", "-1");//添加第一行默认值
        //    this.ddlList.Items.Insert(0, ltem);//添加第一行默认值
        //}


        ///// <summary>
        ///// 审核流规则
        ///// </summary>
        //private void LoadRule()
        //{
        //    EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
        //    string fields = " id,(sort + '—' + cname  ) as rulename ";
        //   // string strsql = " jobflowsort='03' AND  ',' + departidlist + ',' like '%," + login.Departid.ToString() + ",%' ";        
        //    //DataTable tbl = EtNet_BLL.ViewBLL.ViewApprovalRuleManager.getList(fields, strsql);
        //    DataRow row = tbl.NewRow();
        //    row["id"] = "0";
        //    row["rulename"] = "——请选中——";
        //    tbl.Rows.InsertAt(row, 0);
        //    this.ddlrule.DataSource = tbl;
        //    this.ddlrule.DataValueField = "id";
        //    this.ddlrule.DataTextField = "rulename";
        //    this.ddlrule.DataBind();
        //}



        //加载基本信息
        private void loadcus()
        {
            string factid = Request.QueryString["id"].ToString();
            EtNet_Models.Factory fact = FactoryManager.getFactoryById(Convert.ToInt32(factid));
            this.cusshortname.Value = fact.FactshortName.ToString();
            this.cusCName.Value = fact.FactCName.ToString();
            this.cusCode.Value = fact.FactCode.ToString();
            this.hidordernum.Value = fact.Ordernum;
            this.hidcodeformat.Value = fact.Codeformat;
            this.cusCAddress.Value = fact.FactCAddress.ToString();
            this.address.Text = fact.Province.ToString() + " " + fact.City.ToString();
            this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(fact.Inputname).Cname;
            this.lblMadeTime.Value = fact.Inputdate.ToString("yyyy-MM-dd");
            this.rbUsed.SelectedValue = fact.Used.ToString();
            //this.txtcustype.Text = CusTypeManager.getCusTypeById(cus.CusType).TypeName.ToString();
            int id = fact.FactType;
            if (id > 0)
            {
                this.TxtType.Text = FactTypeManager.getFactTypeById(fact.FactType).TypeName;
            }
            else
            {
                this.TxtType.Text = "";
            }


            this.HidTypeID.Value = fact.FactType.ToString();
            //主要联系人
            this.linkName.Value = fact.LinkeName.ToString();
            this.linkPost.Value = fact.Duty.ToString();
            this.linkTel.Value = fact.Telephone.ToString();
            this.linkMobile.Value = fact.Mobile.ToString();
            this.linkFax.Value = fact.Fax.ToString();
            this.linkEmail.Value = fact.Email.ToString();
            this.linkMsn.Value = fact.QQ.ToString();
            this.linkSkype.Value = fact.Skype.ToString();

            //主要银行信息
            this.bankName.Value = fact.Bank.ToString();
            this.bankCard.Value = fact.AccountID.ToString();
            this.bankMan.Value = fact.AccountName.ToString();
            this.bankremark.Value = fact.Remark.ToString();
            //加载修改信息
            DataTable dt = FactoryManager.getList(" id =" + factid);
            this.lblEditMan.Value = dt.Rows[0]["lasteditman"].ToString();
            this.lblEditDate.Value = Convert.IsDBNull(dt.Rows[0]["lasteditdate"]) ? "" : Convert.ToDateTime(dt.Rows[0]["lasteditdate"]).ToString("yyyy-MM-dd");

            //SpecialSet(cusid);
        }

        //加载联系人信息
        private void loadlink()
        {
            string id = Request.QueryString["id"].ToString();

            DataTable tbl = FactLinkmanManager.getList(Convert.ToInt32(id));
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
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["duty"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[2] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["telephone"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[3] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["fax"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[4] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["mobile"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[5] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["email"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[6] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["qq"] + "' class='clsblurtxt clsedit' />";
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
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["duty"] + "' class='clsblurtxt clsedit' />";
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
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["qq"] + "' class='clsblurtxt clsedit' />";
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


        //加载银行信息
        private void loadbank()
        {
            string id = Request.QueryString["id"].ToString();

            DataTable tbl = FactBankManager.getList(Convert.ToInt32(id));
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
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["accountId"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[2] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["accountName"] + "' class='clsblurtxt clsedit' />";
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
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["accountId"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["accountName"] + "' class='clsblurtxt clsedit' />";
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
        /// 设置按钮与规则显示以及供应商启用状态是否可编辑
        /// </summary>
        /// <param name="id">供应商的id值</param>
        private void SpecialSet(string id)
        {

        }





        /// <summary>
        /// 保存草稿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {

            string cusCode = this.cusCode.Value.ToString();
            string cusshortname = this.cusshortname.Value.ToString();
            string cusCName = this.cusCName.Value.ToString();
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string str = "";

            if (FactoryManager.getSName(cusshortname, id))
            {
                str += "供应商简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;

            }
            if (FactoryManager.getCName(cusCName, id))
            {
                str += "供应商全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            ImageButton imgbtn = sender as ImageButton;
            AddBase(imgbtn.CommandName);
        }







        //保存修改后的资料(未审核)
        private void AddBase(string sort)
        {
            string factid = Request.QueryString["id"].ToString();
            EtNet_Models.Factory fact = FactoryManager.getFactoryById(Convert.ToInt32(factid));


            //基本信息
            // EtNet_Models.Customer cus = new EtNet_Models.Customer();
            fact.Id = Convert.ToInt32(Request.QueryString["id"].ToString());
            fact.FactCode = this.cusCode.Value.ToString();
            fact.Codeformat = this.hidcodeformat.Value;
            fact.Ordernum = this.hidordernum.Value;
            fact.FactshortName = this.cusshortname.Value.ToString();

            fact.FactType = Convert.ToInt32(this.HidTypeID.Value);
            string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
            fact.Province = addre[0].ToString();
            fact.City = addre[1].ToString();
            fact.FactCName = this.cusCName.Value.ToString();
            fact.FactCAddress = this.cusCAddress.Value.ToString();
            fact.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value);
            //联系人                                                                                 
            fact.LinkeName = this.linkName.Value.ToString();
            fact.Duty = this.linkPost.Value.ToString();
            fact.Telephone = this.linkTel.Value.ToString();
            fact.Mobile = this.linkMobile.Value.ToString();
            fact.Fax = this.linkFax.Value.ToString();
            fact.Email = this.linkEmail.Value.ToString();
            fact.QQ = this.linkMsn.Value.ToString();
            fact.Skype = this.linkSkype.Value.ToString();


            //银行信息
            fact.Bank = this.bankName.Value.ToString();
            fact.AccountID = this.bankCard.Value.ToString();
            fact.AccountName = this.bankMan.Value.ToString();
            fact.Remark = this.bankremark.Value.ToString();
            //fact.Inputname = ((LoginInfo)Session["Login"]).Id;
            //fact.Inputdate = DateTime.Now;
            fact.LastEditMan = ((LoginInfo)Session["login"]).Cname;
            fact.LastEditDate = DateTime.Now;
            int count = FactoryManager.updateFactory(fact);
            if (count > 0)
            {
                addbank();
                addlink();

                if (sort == "save")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('付款单位修改成功！');location.href='../Supplier/" + Request.QueryString["backURL"] + "'", true);
                }
            }

        }





        private void addbank()
        {
            string id = Request.QueryString["id"].ToString();
            FactBankManager.deleteFactBankByfactId(Convert.ToInt32(id));

            string banklist = this.hidbank.Value;

            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.FactBank factbank = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                for (int i = 0; i < row.Length; i++)
                {
                    factbank = new EtNet_Models.FactBank();
                    cell = row[i].Split('|');
                    factbank.Bank = cell[0];
                    factbank.AccountId = cell[1];
                    factbank.AccountName = cell[2];
                    factbank.Remark = cell[3];
                    factbank.FactId = Convert.ToInt32(id);
                    FactBankManager.addFactBank(factbank);
                }
            }
        }



        private void addlink()
        {
            string id = Request.QueryString["id"].ToString();
            FactLinkmanManager.deleteFactLinkmanByfactId(Convert.ToInt32(id));

            string strList = this.hidlink.Value;
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.FactLinkman cusLink = null;
                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); }
                else { row = new string[1] { strList }; }
                for (int i = 0; i < row.Length; i++)
                {
                    cusLink = new EtNet_Models.FactLinkman();
                    cell = row[i].Split('|');
                    cusLink.LinkName = cell[0];
                    cusLink.Duty = cell[1];
                    cusLink.Telephone = cell[2];
                    cusLink.Fax = cell[3];
                    cusLink.Mobile = cell[4];
                    cusLink.Email = cell[5];
                    cusLink.QQ = cell[6];
                    cusLink.Skype = cell[7];
                    cusLink.FactId = Convert.ToInt32(id);
                    FactLinkmanManager.addFactLinkman(cusLink);

                }
            }
        }


        /// <summary>
        /// 送审
        /// </summary>
        protected void imgbtnaudisend_Click(object sender, ImageClickEventArgs e)
        {
            string cusCode = this.cusCode.Value.ToString();
            string cusshortname = this.cusshortname.Value.ToString();
            string cusCName = this.cusCName.Value.ToString();
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string str = "";

            if (FactoryManager.getSName(cusshortname, id))
            {
                str += "供应商简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;

            }
            if (FactoryManager.getCName(cusCName, id))
            {
                str += "供应商全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            ImageButton imgbtn = sender as ImageButton;
            AddBase(imgbtn.CommandName);
        }


        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Supplier/" + Request.QueryString["backURL"]);
        }


        //修改(已审核)
        protected void imgbtnmodify_Click(object sender, ImageClickEventArgs e)
        {

            string cusCode = this.cusCode.Value.ToString();
            string cusshortname = this.cusshortname.Value.ToString();
            string cusCName = this.cusCName.Value.ToString();
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string str = "";

            if (FactoryManager.getSName(cusshortname, id))
            {
                str += "供应商简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;

            }
            if (FactoryManager.getCName(cusCName, id))
            {
                str += "供应商全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }

            string cusid = Request.QueryString["id"].ToString();
            EtNet_Models.Factory cus = FactoryManager.getFactoryById(Convert.ToInt32(cusid));

            //基本信息
            // EtNet_Models.Customer cus = new EtNet_Models.Customer();
            cus.Id = Convert.ToInt32(Request.QueryString["id"].ToString());
            cus.FactCode = this.cusCode.Value.ToString();
            cus.Codeformat = this.hidcodeformat.Value;
            cus.Ordernum = this.hidordernum.Value;
            cus.FactshortName = this.cusshortname.Value.ToString();
            // cus.Province = this.ddlProvince.SelectedValue;
            //cus.City = this.ddlCity.SelectedValue;
            cus.FactType = Convert.ToInt32(this.HidTypeID.Value);
            string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
            cus.Province = addre[0].ToString();
            cus.City = addre[1].ToString();
            cus.FactCName = this.cusCName.Value.ToString();
            cus.FactCAddress = this.cusCAddress.Value.ToString();
            cus.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value);
            //联系人                                                                                 
            cus.LinkeName = this.linkName.Value.ToString();
            cus.Duty = this.linkPost.Value.ToString();
            cus.Telephone = this.linkTel.Value.ToString();
            cus.Mobile = this.linkMobile.Value.ToString();
            cus.Fax = this.linkFax.Value.ToString();
            cus.Email = this.linkEmail.Value.ToString();
            cus.QQ = this.linkMsn.Value.ToString();
            cus.Skype = this.linkSkype.Value.ToString();


            //银行信息
            cus.Bank = this.bankName.Value.ToString();
            cus.AccountID = this.bankCard.Value.ToString();
            cus.AccountName = this.bankMan.Value.ToString();
            cus.Remark = this.bankremark.Value.ToString();
            cus.Inputname = ((LoginInfo)Session["Login"]).Id;
            cus.Inputdate = DateTime.Now;
            int count = FactoryManager.updateFactory(cus);
            if (count > 0)
            {
                addbank();
                addlink();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('供应商修改成功！');location.href='../Supplier/" + Request.QueryString["backURL"] + "'", true);

            }

        }
    }
}