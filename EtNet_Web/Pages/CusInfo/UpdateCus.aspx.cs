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
using EtNet_BLL.DataPage;
using System.IO;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class UpdateCus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bindList();
                // LoadRule();
                DdlToUserBindData();
                loadcus();
                loadlink();
                loadbank();
                
            }
        }




        //加载基本信息
        private void loadcus()
        {
            string cusid = Request.QueryString["id"].ToString();
            EtNet_Models.Customer cus = CustomerManager.getCustomerById(Convert.ToInt32(cusid));
            this.cusshortname.Value = cus.CusshortName.ToString();
            this.cusCName.Value = cus.CusCName.ToString();
            this.cusCode.Value = cus.CusCode.ToString();
            //this.hidordernum.Value = cus.Ordernum;
            //this.hidcodeformat.Value = cus.Codeformat;
            this.cusCAddress.Value = cus.CusCAddress.ToString();
            this.companyURL.Value = cus.CompanyURL.ToString();
            //this.rbPro.SelectedValue = cus.CusPro.ToString();
            this.address.Text = cus.Province.ToString() + " " + cus.City.ToString();
            this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(cus.Madefrom).Cname;
            this.lblMadeTime.Value = cus.MadeTime.ToString("yyyy-MM-dd");
            this.ddlToUser.SelectedValue = cus.CusType.ToString();
            //this.rbUsed.SelectedValue = cus.Used.ToString();
            //this.txtcustype.Text = CusTypeManager.getCusTypeById(cus.CusType).TypeName.ToString();
            int id = cus.CusType;


            this.HidTypeID.Value = cus.CusType.ToString();
            //主要联系人
            //this.linkName.Value = cus.LinkName.ToString();
            //this.linkPost.Value = cus.Post.ToString();
            //this.linkTel.Value = cus.Telephone.ToString();
            //this.linkMobile.Value = cus.Mobile.ToString();
            //this.linkFax.Value = cus.Fax.ToString();
            //this.linkEmail.Value = cus.Email.ToString();
            //this.linkMsn.Value = cus.Msn.ToString();
            //this.linkSkype.Value = cus.Skype.ToString();

            //主要银行信息
            this.bankName.Value = cus.Bank.ToString();
            this.bankCard.Value = cus.CardId.ToString();
            this.bankMan.Value = cus.CardName.ToString();
            this.bankremark.Value = cus.Remark.ToString();

            //提成系数
            this.newRatio.Value = cus.newRatio.ToString();
            this.oldRatio.Value = cus.oldRatio.ToString();

            //显示修改人员和修改日期
            DataTable dt = CustomerManager.GetList(" id = " + cusid);
            this.editman.Value = dt.Rows[0]["lasteditman"].ToString();
            this.editdate.Value = Convert.IsDBNull(dt.Rows[0]["lasteditdate"]) ? "" : Convert.ToDateTime(dt.Rows[0]["lasteditdate"]).ToString("yyyy-MM-dd");

            //SpecialSet(cusid);
        }

        //加载营业部信息
        private void loadlink()
        {
            string id = Request.QueryString["id"].ToString();

            DataTable tbl = CusLinkmanManager.getList(Convert.ToInt32(id));
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
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["departName"] + "' class='clsblurtxt clsedit' />";
                        cell = row.Controls[1] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkName"] + "' class='clsblurtxt clsedit' />";
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
                        cell = row.Controls[8] as HtmlTableCell;
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"] + "' class='clsedit clsdisplay clsLinkID' /><div title='删除' class='clsimgdel'>&nbsp;</div>";
                    }
                    else
                    {
                        row = new HtmlTableRow();
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["departName"] + "' class='clsblurtxt clsedit' />";
                        row.Controls.Add(cell);
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkName"] + "' class='clsblurtxt clsedit' />";
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

                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"] + "' class='clsedit clsdisplay clsLinkID' /><div title='删除' class='clsimgdel'>&nbsp;</div>";
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

            DataTable tbl = CusBankManager.getList(Convert.ToInt32(id));
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
        /// 设置按钮与规则显示以及客户启用状态是否可编辑
        /// </summary>
        /// <param name="id">客户的id值</param>
        //private void SpecialSet(string id)
        //{
        //    string strsql = " id=" + id;    
        //    DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
        //    if (tbl.Rows[0]["savestatus"].ToString() == "草稿"){

        //        this.imgmodify.Visible = false;
        //        this.rbUsed.Enabled = false;
        //    }
        //    else if (tbl.Rows[0]["savestatus"].ToString() == "已提交")
        //    {
        //        this.imgsave.Visible = false;
        //        this.imgaudisend.Visible = false;
        //        //this.trauditrule.Visible = false;
        //        //this.trauditpic.Visible = false;
        //        //this.ddlrule.Enabled = false;
        //        //this.auditpic.InnerHtml = "";
        //    }
        //    else
        //    {
        //        this.imgsave.Visible = false;
        //        this.imgmodify.Visible = false;
        //        this.imgaudisend.Visible = false;
        //        this.imgback.Visible = false;
        //    }
        //    int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString()); // 审核规则的id值         
        //   // this.ddlrule.SelectedValue = ruleid.ToString();
        //    //LoadAuditImg(ruleid);
        //}


        //加载审核流程图
        //public void LoadAuditImg(int ruleid)
        //{

        //    EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
        //    if (model != null)
        //    {
        //        string strpath = Server.MapPath(model.rolepic);
        //        if (File.Exists(strpath))
        //        {
        //            this.auditpic.InnerHtml = File.ReadAllText(strpath);
        //        }
        //    }
        //}





        /// <summary>
        /// 绑定标的种类列表（repeater控件）
        /// </summary>
        private void DdlToUserBindData()
        {
            DataTable data = LoginInfoManager.getList("");
            ddlToUser.DataTextField = "cname";
            ddlToUser.DataValueField = "id";
            ddlToUser.DataSource = data;
            ddlToUser.DataBind();
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

            if (CustomerManager.getSName(cusshortname, id))
            {
                str += "客户简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;

            }
            if (CustomerManager.getCName(cusCName, id))
            {
                str += "客户全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            ImageButton imgbtn = sender as ImageButton;
            AddBase(imgbtn.CommandName);
        }




        /// <summary>
        ///  创建审批序列
        /// </summary>
        ///<param name="ruleid">审核规则id值</param>
        /// <param name="id">工作流的id号</param>
        private void CreateApproval(int ruleid, int id)
        {
            EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
            string stafflist = rule.idgourp;
            string auditsort = rule.sort;
            string[] staff = null;
            int len = 0; //审批人员的个数
            EtNet_Models.AuditJobFlow model = null;
            if (stafflist.IndexOf(",") == -1)
            {
                staff = new string[1];
                staff[0] = stafflist;
                len = 1;
            }
            else
            {
                staff = stafflist.Split(',');
                len = staff.Length;
            }

            switch (auditsort)
            {
                case "单审":
                    for (int i = 0; i < staff.Length; i++)
                    {
                        model = new EtNet_Models.AuditJobFlow();
                        model.auditoperat = "未操作";
                        model.operatstatus = "未审批";
                        model.audittime = new DateTime(1900, 1, 1);
                        if (i == 0)
                        {
                            model.nowreviewer = "T";//第一个审核的人员 
                        }
                        else
                        {
                            model.nowreviewer = "F";
                        }

                        if ((i + 1) == len)
                        {
                            model.mainreviewer = "T";//最终审核的人员 
                        }
                        else
                        {
                            model.mainreviewer = "F";
                        }
                        model.numbers = i + 1;
                        model.jobflowid = id;
                        model.reviewerid = int.Parse(staff[i]);
                        model.opiniontxt = "";
                        EtNet_BLL.AuditJobFlowManager.Add(model);
                    }
                    break;

                case "选审":
                case "会审":
                    for (int i = 0; i < staff.Length; i++)
                    {
                        model = new EtNet_Models.AuditJobFlow();
                        model.audittime = new DateTime(1900, 1, 1);
                        model.nowreviewer = "T";
                        model.mainreviewer = "T";
                        model.numbers = 1;
                        model.jobflowid = id;
                        model.auditoperat = "未操作";
                        model.operatstatus = "未审批";
                        model.reviewerid = int.Parse(staff[i]);
                        model.opiniontxt = "";
                        EtNet_BLL.AuditJobFlowManager.Add(model);
                    }
                    break;

            }
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendInformation(int jobflowid, int ruleid)
        {
            EtNet_Models.ApprovalRule rule = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
            string[] list = rule.idgourp.Split(',');
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jobflowid);
            EtNet_Models.Information informodel = null;
            if (model != null)
            {
                informodel = new EtNet_Models.Information();
                informodel.sortid = 9;
                informodel.associationid = jobflowid;
                informodel.contents = "编号为" + model.cname + "的客户需要您审批!";
                informodel.createtime = DateTime.Now;
                informodel.sendtime = DateTime.Now;
                informodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                if (EtNet_BLL.InformationManager.Add(informodel))
                {
                    int maxid = EtNet_BLL.InformationManager.GetMaxId();
                    EtNet_Models.InformationNotice infnotic = null;
                    int len = (rule.sort == "单审") ? 1 : list.Length;

                    for (int j = 0; j < len; j++)
                    {
                        infnotic = new EtNet_Models.InformationNotice();
                        infnotic.informationid = maxid;
                        infnotic.recipientid = int.Parse(list[j].ToString());
                        infnotic.remind = "是";
                        EtNet_BLL.InformationNoticeManager.Add(infnotic);

                    }

                }
            }

        }




        //保存修改后的资料(未审核)
        private void AddBase(string sort)
        {
            string cusid = Request.QueryString["id"].ToString();
            EtNet_Models.Customer cus = CustomerManager.getCustomerById(Convert.ToInt32(cusid));

            //基本信息
            // EtNet_Models.Customer cus = new EtNet_Models.Customer();
            cus.Id = Convert.ToInt32(Request.QueryString["id"].ToString());
            cus.CusCode = this.cusCode.Value.ToString();
            //cus.Codeformat = this.hidcodeformat.Value;
            //cus.Ordernum = this.hidordernum.Value;
            cus.CusshortName = this.cusshortname.Value.ToString();
            // cus.Province = this.ddlProvince.SelectedValue;
            //cus.City = this.ddlCity.SelectedValue;
            cus.CusType = Convert.ToInt32(this.ddlToUser.SelectedValue);
            string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
            cus.Province = addre[0].ToString();
            cus.City = addre[1].ToString();
            cus.CusCName = this.cusCName.Value.ToString();
            cus.CompanyURL = this.companyURL.Value.ToString();
            cus.CusCAddress = this.cusCAddress.Value.ToString();
            //修改客户等级
            TimeSpan ts = DateTime.Now - Convert.ToDateTime(this.companyURL.Value);
            int Days = ts.Days;

            //0为新客户。1为老客户。
            if (Days > 365)
            {
                cus.CusPro = 1;
            }
            else
            {
                cus.CusPro = 0;
            }
            //cus.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value);
            //联系人                                                                                 
            //cus.LinkName = this.linkName.Value.ToString();
            //cus.Post = this.linkPost.Value.ToString();
            //cus.Telephone = this.linkTel.Value.ToString();
            //cus.Mobile = this.linkMobile.Value.ToString();
            //cus.Fax = this.linkFax.Value.ToString();
            //cus.Email = this.linkEmail.Value.ToString();
            //cus.Msn = this.linkMsn.Value.ToString();
            //cus.Skype = this.linkSkype.Value.ToString();
            cus.LinkName = "";
            cus.Post = "";
            cus.Telephone = "";
            cus.Mobile = "";
            cus.Fax = "";
            cus.Email = "";
            cus.Msn = "";
            cus.Skype = "";

            //银行信息
            cus.Bank = this.bankName.Value.ToString();
            cus.CardId = this.bankCard.Value.ToString();
            cus.CardName = this.bankMan.Value.ToString();
            cus.Remark = this.bankremark.Value.ToString();
            //cus.Madefrom = ((LoginInfo)Session["Login"]).Id;
            //cus.MadeTime = DateTime.Now;
            //提成系数
            double ratio = 0;
            double.TryParse(this.newRatio.Value, out ratio);
            cus.newRatio = ratio; //新客户提成系数
            ratio = 0;
            double.TryParse(this.oldRatio.Value, out ratio);
            cus.oldRatio = ratio; //老客户提成系数
            cus.LastEditMan = ((LoginInfo)Session["login"]).Cname;
            cus.LastEditDate = DateTime.Now;
            int count = CustomerManager.updateCustomer(cus);
            if (count > 0)
            {
                addbank();
                addlink();

                if (sort == "save")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功！');location.href='../CusInfo/Customer.aspx'", true);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('送审成功！');location.href='../CusInfo/Customer.aspx'", true);
                }
            }

        }





        private void addbank()
        {
            string id = Request.QueryString["id"].ToString();
            CusBankManager.deleteCusBankByCusId(Convert.ToInt32(id));

            string banklist = this.hidbank.Value;

            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.CusBank cusbank = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                for (int i = 0; i < row.Length; i++)
                {
                    cusbank = new EtNet_Models.CusBank();
                    cell = row[i].Split('|');
                    cusbank.Bank = cell[0];
                    cusbank.CardId = cell[1];
                    cusbank.CardName = cell[2];
                    cusbank.Remark = cell[3];
                    cusbank.CustomerId = Convert.ToInt32(id);
                    CusBankManager.addCusBank(cusbank);
                }
            }
        }


        /// <summary>
        /// 更新营业部信息
        /// </summary>
        private void addlink()
        {
            string id = Request.QueryString["id"].ToString();
            //CusLinkmanManager.deleteCusLinkmanByCusId(Convert.ToInt32(id));

            string strList = this.hidlink.Value;
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;

                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); }
                else { row = new string[1] { strList }; }
                if (row.Count() > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        cell = row[i].Split('|');
                        int linkid = 0;
                        int.TryParse(cell[8], out linkid);
                        EtNet_Models.CusLinkman cusLink = CusLinkmanManager.getCusLinkmanById(linkid);
                        if (cusLink == null) //如果没有就新增
                        {
                            cusLink = new EtNet_Models.CusLinkman();
                            cusLink.DepartName = cell[0]; //营业部名称
                            cusLink.LinkName = cell[1]; //联系人
                            cusLink.Telephone = cell[2]; //电话
                            cusLink.Fax = cell[3]; //传真
                            cusLink.Mobile = cell[4]; //手机
                            cusLink.Email = cell[5]; //邮箱
                            cusLink.Msn = cell[6]; //msn
                            cusLink.Skype = cell[7]; //skype
                            cusLink.CustomerId = Convert.ToInt32(id);
                            CusLinkmanManager.addCusLinkman(cusLink);
                        }
                        else
                        {
                            cusLink.DepartName = cell[0];
                            cusLink.LinkName = cell[1];
                            cusLink.Telephone = cell[2]; //电话
                            cusLink.Fax = cell[3]; //传真
                            cusLink.Mobile = cell[4]; //手机
                            cusLink.Email = cell[5]; //邮箱
                            cusLink.Msn = cell[6]; //msn
                            cusLink.Skype = cell[7]; //skype
                            cusLink.CustomerId = Convert.ToInt32(id);
                            CusLinkmanManager.updateCusLinkman(cusLink);
                        }
                    }
                }
            }

            string ids = this.hidlinkdelid.Value.TrimEnd(',');
            //删除数据
            if (ids != "")
            {
                string sql = " id in (" + ids + ")";
                CusLinkmanManager.deleteCusLinkmanBySql(sql);
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

            if (CustomerManager.getSName(cusshortname, id))
            {
                str += "客户简称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;

            }
            if (CustomerManager.getCName(cusCName, id))
            {
                str += "客户全称已存在\\n";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
                return;
            }
            ImageButton imgbtn = sender as ImageButton;
            AddBase(imgbtn.CommandName);
        }


        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../CusInfo/Customer.aspx");
        }


        //修改(已审核)
        //protected void imgbtnmodify_Click(object sender, ImageClickEventArgs e)
        //{

        //    string cusCode = this.cusCode.Value.ToString();
        //    string cusshortname = this.cusshortname.Value.ToString();
        //    string cusCName = this.cusCName.Value.ToString();
        //    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        //    string str = "";

        //    if (CustomerManager.getSName(cusshortname, id))
        //    {
        //        str += "客户简称已存在\\n";
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
        //        return;

        //    }
        //    if (CustomerManager.getCName(cusCName, id))
        //    {
        //        str += "客户全称已存在\\n";
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
        //        return;
        //    }

        //    string cusid = Request.QueryString["id"].ToString();
        //    EtNet_Models.Customer cus = CustomerManager.getCustomerById(Convert.ToInt32(cusid));

        //    //基本信息
        //    // EtNet_Models.Customer cus = new EtNet_Models.Customer();
        //    cus.Id = Convert.ToInt32(Request.QueryString["id"].ToString());
        //    cus.CusCode = this.cusCode.Value.ToString();
        //    //cus.Codeformat = this.hidcodeformat.Value;
        //    //cus.Ordernum = this.hidordernum.Value;
        //    cus.CusshortName = this.cusshortname.Value.ToString();
        //    // cus.Province = this.ddlProvince.SelectedValue;
        //    //cus.City = this.ddlCity.SelectedValue;
        //    cus.CusType = Convert.ToInt32(this.HidTypeID.Value);
        //    string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
        //    cus.Province = addre[0].ToString();
        //    cus.City = addre[1].ToString();
        //    cus.CusCName = this.cusCName.Value.ToString();
        //    cus.CompanyURL = this.companyURL.Value.ToString();
        //    cus.CusCAddress = this.cusCAddress.Value.ToString();
        //    //修改客户等级
        //    TimeSpan ts = DateTime.Now - Convert.ToDateTime(this.companyURL.Value);
        //    int Days = ts.Days;

        //    //0为新客户。1为老客户。
        //    if (Days > 365)
        //    {
        //        cus.CusPro = 1;
        //    }
        //    else
        //    {
        //        cus.CusPro = 0;
        //    }
        //    //cus.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value);
        //    //联系人                                                                                 
        //    //cus.LinkName = this.linkName.Value.ToString();
        //    //cus.Post = this.linkPost.Value.ToString();
        //    //cus.Telephone = this.linkTel.Value.ToString();
        //    //cus.Mobile = this.linkMobile.Value.ToString();
        //    //cus.Fax = this.linkFax.Value.ToString();
        //    //cus.Email = this.linkEmail.Value.ToString();
        //    //cus.Msn = this.linkMsn.Value.ToString();
        //    //cus.Skype = this.linkSkype.Value.ToString();


        //    //银行信息
        //    cus.Bank = this.bankName.Value.ToString();
        //    cus.CardId = this.bankCard.Value.ToString();
        //    cus.CardName = this.bankMan.Value.ToString();
        //    cus.Remark = this.bankremark.Value.ToString();
        //    cus.Madefrom = ((LoginInfo)Session["Login"]).Id;
        //    cus.MadeTime = DateTime.Now;
        //    int count = CustomerManager.updateCustomer(cus);
        //    if (count > 0)
        //    {
        //        addbank();
        //        addlink();
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('客户修改成功！');location.href='../CusInfo/Customer.aspx'", true);
        //    }

        //}



    }
}