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
using System.IO;

namespace EtNet_Web.Pages.CusInfo
{
    public partial class CopyCus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRule();
                loadcus();
                loadlink();
                loadbank();
                IsEditCuscode();

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
                this.cusCode.Disabled = true;
                this.txtshow.InnerHtml = "(自动生成)";
            }

        }


        /// <summary>
        /// 审核流规则
        /// </summary>
        private void LoadRule()
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            string fields = " id,(sort + '—' + cname  ) as rulename ";
            string strsql = " jobflowsort='03' AND  ',' + departidlist + ',' like '%," + login.Departid.ToString() + ",%' ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewApprovalRuleManager.getList(fields, strsql);
            DataRow row = tbl.NewRow();
            row["id"] = "0";
            row["rulename"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlrule.DataSource = tbl;
            this.ddlrule.DataValueField = "id";
            this.ddlrule.DataTextField = "rulename";
            this.ddlrule.DataBind();
        }



        /// <summary>
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = " num = '00001'";
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
        /// 检验是否能成功产生单据名称
        /// </summary>
        /// <param name="cuscode">输入的客户代码</param>
        /// <param name="cname">客户代码全称</param>
        /// <param name="attachment">>客户代码不包含流水号</param>
        /// <param name="txt">流水号</param>
        private bool StrNumbers(string strcuscode, out string cuscode, out string codeformat, out string ordernum)
        {
            bool result = true;
            cuscode = ""; //客户代码全称
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
                    strsql = "  cusCode ='" + strcuscode + "'";
                    custbl = CustomerManager.GetList(strsql);
                    if (custbl.Rows.Count != 0)
                    {
                        result = false;
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('复制失败,客户代码已存在!')</script>");
                    }
                    else
                    {
                        cuscode = strcuscode; //客户代码全称
                    }
                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('复制失败,客户代码不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                codeformat = Numbers(txtformat); //名称
                strsql = "  codeformat= '" + codeformat + "' AND LEN(ordernum) =" + len.ToString();
                custbl = CustomerManager.GetList(1, strsql, " id desc ");

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
                cuscode = codeformat + ordernum; //客户代码全称
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



        //加载基本信息
        private void loadcus()
        {
            string cusid = Request.QueryString["id"].ToString();
            EtNet_Models.Customer cus = CustomerManager.getCustomerById(Convert.ToInt32(cusid));
            this.cusshortname.Value = cus.CusshortName.ToString();
            this.cusCName.Value = cus.CusCName.ToString();

            this.cusCAddress.Value = cus.CusCAddress.ToString();
            this.companyURL.Value = cus.CompanyURL.ToString();
            this.rbPro.SelectedValue = cus.CusPro.ToString();
            this.address.Text = cus.Province.ToString() + " " + cus.City.ToString();
            //this.txtcustype.Text = CusTypeManager.getCusTypeById(cus.CusType).TypeName.ToString();
            this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(((LoginInfo)Session["login"]).Id).Cname;
            this.lblMadeTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
            //this.rbUsed.SelectedValue = cus.Used.ToString();
            int id = cus.CusType;
            if (id > 0)
            {
                this.TxtType.Text = CusTypeManager.getCusTypeById(cus.CusType).TypeName;
            }
            else
            {
                this.TxtType.Text = "";
            }


            this.HidTypeID.Value = cus.CusType.ToString();
            //主要联系人
            this.linkName.Value = cus.LinkName.ToString();
            this.linkPost.Value = cus.Post.ToString();
            this.linkTel.Value = cus.Telephone.ToString();
            this.linkMobile.Value = cus.Mobile.ToString();
            this.linkFax.Value = cus.Fax.ToString();
            this.linkEmail.Value = cus.Email.ToString();
            this.linkMsn.Value = cus.Msn.ToString();
            this.linkSkype.Value = cus.Skype.ToString();

            //主要银行信息
            this.bankName.Value = cus.Bank.ToString();
            this.bankCard.Value = cus.CardId.ToString();
            this.bankMan.Value = cus.CardName.ToString();
            this.bankremark.Value = cus.Remark.ToString();

            RuleSet(cusid);
        }


        //加载联系人信息
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
        /// 设置规则的显示
        /// </summary>
        /// <param name="id">客户的id值</param>
        private void RuleSet(string id)
        {
            string strsql = " id=" + id;
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList("", strsql);
           
            int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString()); // 审核规则的id值

            this.ddlrule.SelectedValue = ruleid.ToString();
            LoadAuditImg(ruleid);


        }


        //加载审核流程图
        public void LoadAuditImg(int ruleid)
        {
            EtNet_Models.ApprovalRule model = EtNet_BLL.ApprovalRuleManager.GetModel(ruleid);
            if (model != null)
            {
                string strpath = Server.MapPath(model.rolepic);
                if (File.Exists(strpath))
                {
                    this.auditpic.InnerHtml = File.ReadAllText(strpath);
                }
            }
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




        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            string cusCode = this.cusCode.Value.ToString();
            string cusshortname = this.cusshortname.Value.ToString();
            string cusCName = this.cusCName.Value.ToString();

            string str = "";
            //if (CustomerManager.getCode(cusCode, 0))
            //{
            //    str += "客户代码已存在\\n";
            //}
            if (CustomerManager.getSName(cusshortname, 0))
            {
                str += "客户简称已存在\\n";
            }
            if (CustomerManager.getCName(cusCName, 0))
            {
                str += "客户全称已存在\\n";
            }

            int count = CustomerManager.getCountBy3(cusCode, cusshortname, cusCName, 0);
            if (count <= 0)
            {
                ImageButton imgbtn = sender as ImageButton;
                AddBase(imgbtn.CommandName);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            }

        }

        //送审
        protected void imgbtnaudisend_Click(object sender, ImageClickEventArgs e)
        {
            string cusCode = this.cusCode.Value.ToString();
            string cusshortname = this.cusshortname.Value.ToString();
            string cusCName = this.cusCName.Value.ToString();

            string str = "";
            //if (CustomerManager.getCode(cusCode, 0))
            //{
            //    str += "客户代码已存在\\n";
            //}
            if (CustomerManager.getSName(cusshortname, 0))
            {
                str += "客户简称已存在\\n";
            }
            if (CustomerManager.getCName(cusCName, 0))
            {
                str += "客户全称已存在\\n";
            }

            int count = CustomerManager.getCountBy3(cusCode, cusshortname, cusCName, 0);
            if (count <= 0)
            {
                ImageButton imgbtn = sender as ImageButton;
                AddBase(imgbtn.CommandName);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            }

        }



        private void AddBase(string sort)
        {
            string cuscode ="";  //公司代码全称
            string codeformat =""; //公司代码，不包含流水号
            string ordernum = "";  //流水号
            if (StrNumbers(this.cusCode.Value, out cuscode, out codeformat, out ordernum))
            {
                EtNet_Models.JobFlow model = new JobFlow();
                model.attachment = codeformat;
                model.txt = ordernum;
                model.cname = cuscode;
                model.sort = "03"; //客户管理申请
                model.auditsort = "";
                model.auditstatus = "01";
                model.createtime = DateTime.Now; //默认是当前时间
                model.endtime = DateTime.Now;
                model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id     
                model.ruleid = int.Parse(this.ddlrule.SelectedValue);
                if (sort == "save")
                {
                    model.savestatus = "草稿";
                }
                else
                {
                    model.savestatus = "已提交";
                }
                int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(model); //工作流的id值

                if (sort != "save")
                {
                    CreateApproval(model.ruleid, maxid);
                    SendInformation(maxid, model.ruleid);
                }


                //基本信息
                EtNet_Models.Customer cus = new EtNet_Models.Customer();
               // cus.Id = Convert.ToInt32(Request.QueryString["id"].ToString());
                cus.CusCode = cuscode;
                cus.Codeformat = codeformat;
                cus.Ordernum = ordernum;
                cus.CusshortName = this.cusshortname.Value.ToString();
                cus.Jobflowid = maxid;
                cus.Txt = "";
                cus.Viewidlist = "";
                cus.Viewidtxt = "";
                cus.Authidlist = "";
                cus.Authidtxt = ""; 

                //cus.Province = this.ddlProvince.SelectedValue;
                //cus.City = this.ddlCity.SelectedValue;
                cus.CusType = Convert.ToInt32(this.HidTypeID.Value);
                string[] addre = this.address.Text.ToString().Split(' ');// string[] sailing = args.Split('/');
                cus.Province = addre[0].ToString();
                cus.City = addre[1].ToString();
                cus.CusCName = this.cusCName.Value.ToString();
                cus.CompanyURL = this.companyURL.Value.ToString();
                cus.CusCAddress = this.cusCAddress.Value.ToString();
                cus.CusPro = Convert.ToInt32(this.rbPro.SelectedItem.Value);
                //cus.Used = Convert.ToInt32(this.rbUsed.SelectedItem.Value);
                //联系人                                                                                 
                cus.LinkName = this.linkName.Value.ToString();
                cus.Post = this.linkPost.Value.ToString();
                cus.Telephone = this.linkTel.Value.ToString();
                cus.Mobile = this.linkMobile.Value.ToString();
                cus.Fax = this.linkFax.Value.ToString();
                cus.Email = this.linkEmail.Value.ToString();
                cus.Msn = this.linkMsn.Value.ToString();
                cus.Skype = this.linkSkype.Value.ToString();
                cus.Madefrom = ((LoginInfo)Session["Login"]).Id;
                cus.MadeTime = DateTime.Now;
                //银行信息
                cus.Bank = this.bankName.Value.ToString();
                cus.CardId = this.bankCard.Value.ToString();
                cus.CardName = this.bankMan.Value.ToString();
                cus.Remark = this.bankremark.Value.ToString();
                cus.Madefrom = ((LoginInfo)Session["login"]).Id;
                cus.MadeTime = DateTime.Now;
                int count = CustomerManager.addCustomer(cus);
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



        private void addlink()
        {
            string id = Request.QueryString["id"].ToString();
            CusLinkmanManager.deleteCusLinkmanByCusId(Convert.ToInt32(id));

            string strList = this.hidlink.Value;
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.CusLinkman cusLink = null;
                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); }
                else { row = new string[1] { strList }; }
                for (int i = 0; i < row.Length; i++)
                {
                    cusLink = new EtNet_Models.CusLinkman();
                    cell = row[i].Split('|');
                    cusLink.LinkName = cell[0];
                    cusLink.Post = cell[1];
                    cusLink.Telephone = cell[2];
                    cusLink.Fax = cell[3];
                    cusLink.Mobile = cell[4];
                    cusLink.Email = cell[5];
                    cusLink.Msn = cell[6];
                    cusLink.Skype = cell[7];
                    cusLink.CustomerId = Convert.ToInt32(id);
                    CusLinkmanManager.addCusLinkman(cusLink);

                }
            }
        }

        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../CusInfo/Customer.aspx");
        }

      



    }
}