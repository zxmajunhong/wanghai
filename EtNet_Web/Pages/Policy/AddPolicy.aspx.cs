using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using messageBLL = EtNet_BLL.InformationManager;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace EtNet_Web.Pages.Policy
{
    public partial class AddPolicy : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoginInfo login = new LoginInfo();
                if (Session["login"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    login = Session["login"] as LoginInfo;
                }

                InitVifify();
                if (true)
                {
                    TxtCompany.Text = TxtType.Text = "";
                }

                TxtPolicyDate.Attributes.Add("ReadOnly", "true");
                TxtTimeStart.Attributes.Add("ReadOnly", "true");
                TxtCustomer.Attributes.Add("ReadOnly", "true");
                TxtCompany.Attributes.Add("ReadOnly", "true");
                TxtType.Attributes.Add("ReadOnly", "true");
                //TxtVerifyDate.Attributes.Add("ReadOnly", "true");
                TxtSalesman.Attributes.Add("ReadOnly", "true");
                TxtPolicyDate.Text = DateTime.Now.ToShortDateString();
                //TxtTimeStart.Text = DateTime.Now.ToShortDateString();

                object action = Request.QueryString["action"];
                object id = Request.QueryString["id"];

                if (action != null && action.ToString() == "edit")
                {
                    int rid = 0;
                    if (id != null && int.TryParse(id.ToString(), out rid))
                    {
                        InitData(rid, login.Id);
                        LblTitle.Text = "保单编辑";
                    }
                    else
                    {
                        Response.End();
                    }
                }
                if (action != null && action.ToString() == "new")
                {
                    TxtPolicyMaker.Text = login.Cname;
                    budgetTag.Visible = false;
                    tagContent2.InnerHtml = "";
                    DepartmentInfo department = DepartmentInfoManager.getDepartmentInfoById(login.Departid);
                    if (department != null)
                    {
                        txtMarkerDepart.Text = department.Departcname;
                    }

                    string cuscode = "";  //公司代码全称
                    string codeformat = ""; //公司代码，不包含流水号
                    string ordernum = "";  //流水号

                    StrNumbers(this.TxtSerialNum.Text.Trim(), out cuscode, out codeformat, out ordernum);
                    this.TxtSerialNum.Text = cuscode;
                }

                IsEditCuscode();

                BindDdlUnit();
            }
        }
        private int _policyID = 0;

        /// <summary>
        /// 添加保单的方法
        /// </summary>
        /// <param name="policy"></param>
        private void Add(To_Policy policy)
        {
            int policyId = To_PolicyManager.addTo_Policy(policy);
            //具体保险项目
            if (policyId > 0 && HidPros.Value != "")
            {
                //string[] items = HidPros.Value.TrimEnd('|').Split('|');
                //To_PolicyDetail pdModel = new To_PolicyDetail();
                //foreach (string item in items)
                //{
                //    string[] proInfo = item.Split('$');
                //    pdModel.Coverage = double.Parse(proInfo[1]);//保额
                //    pdModel.Premium = double.Parse(proInfo[2]);//保费
                //    pdModel.PolicyId = policyId;//保单ID
                //    pdModel.ProductId = int.Parse(proInfo[0].Trim());//保险项目
                //    pdModel.Mark = proInfo[3];//备注

                //    To_PolicyDetailManager.addTo_PolicyDetail(pdModel);
                //}
                string[] list = HidPros.Value.Split(',');//以逗号分隔每一行的数据
                string[] txt = null; //存储每一行每一个单元的数据
                List<string> p = new List<string>(); //存储业务员汇总
                To_PolicyDetail model = null;
                for (int i = 0; i < list.Length; i++)
                {
                    model = new To_PolicyDetail();
                    txt = list[i].Split('|');

                    model.PolicyId = policyId; //保单id
                    model.Salesman = txt[0]; //业务员
                    if (!p.Contains(txt[0]))
                    {
                        p.Add(txt[0]);
                    }
                    model.DepartName = txt[1]; //部门
                    model.NumRate = decimal.Parse(txt[2]); //比率
                    model.Fmone = decimal.Parse(txt[3]); //经济费
                    model.Rich = decimal.Parse(txt[4]); //贴费
                    model.Mark = txt[5]; //备注
                    To_PolicyDetailManager.addTo_PolicyDetail(model);

                }
                StringBuilder persons = new StringBuilder();
                foreach (string s in p)
                {
                    persons.Append(s + ";"); 
                }

                To_PolicyManager.updateTo_PolicySalesman(persons.ToString(), policyId);

                //标的信息
                if (HidTarget.Value != "")
                {
                    string hidValues = HidTarget.Value.TrimEnd('@').Replace("\r\n", "");

                    string[] values = hidValues.Split('@');

                    To_PolicyTarget To_PolicyTarget = new To_PolicyTarget();
                    To_PolicyTarget.PolicyID = policyId;

                    foreach (string value in values)
                    {
                        string[] propertyArr = value.Split('$');
                        To_PolicyTarget.Datatype = propertyArr[4].Trim() == "" ? 0 : int.Parse(propertyArr[4].Trim());
                        To_PolicyTarget.PropertyName = propertyArr[0].Trim();
                        To_PolicyTarget.PropertyTypeID = propertyArr[2].Trim() == "" ? 0 : int.Parse(propertyArr[2].Trim());
                        To_PolicyTarget.PropertyValue = propertyArr[1].Trim();
                        To_PolicyTarget.PropertyID = propertyArr[3].Trim() == "" ? 0 : int.Parse(propertyArr[3].Trim());

                        To_PolicyTargetManager.addTo_PolicyTarget(To_PolicyTarget);
                    }
                }

                //上传附件并返回文件名集合
                string[] str = FileUp(Request.Files);
                if (str[0] == "" && str[6] == "1")
                {
                    SaveFilePath(str, policyId);
                }
            }
            _policyID = policyId;
        }


        /// <summary>
        /// 验证是否存在该保单
        /// </summary>
        /// <param name="policyID">保单ID</param>
        /// <returns></returns>
        private bool ExitsPolicy(int policyID)
        {
            To_Policy policyModel = To_PolicyManager.getTo_PolicyById(policyID);

            return policyModel != null;
        }


        /// <summary>
        /// 加载审核流程图
        /// </summary>
        private void LoadAuditImg(int ruleid)
        {
            ApprovalRule model = ApprovalRuleManager.GetModel(ruleid);
            if (model != null)
            {
                string strpath = Server.MapPath(model.rolepic);
                if (File.Exists(strpath))
                {
                    this.auditpic.InnerHtml = File.ReadAllText(Server.MapPath(model.rolepic));
                }
                else
                {
                    this.auditpic.InnerText = "找不到指定的审批流程图";
                }
            }
        }



        /// <summary>
        /// 初始化信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginID"></param>
        private void InitData(int id, int loginID)
        {
            DataTable data = To_PolicyManager.GetList(id);

            if (data.Rows.Count > 0)
            {
                if (data.Rows[0]["savestatus"].ToString().Trim() == "已提交")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "load", "<script>alert('已提交的保单不能修改');window.location='PolicyList.aspx'</script>");
                }

                TxtAssured.Text = data.Rows[0]["assured"].ToString();//被保险人
                //TxtBrokerage.Text = data.Rows[0][""].ToString();//经纪费合计
                TxtCompany.Text = data.Rows[0]["comshortname"].ToString();//保险公司
                TxtCustomer.Text = data.Rows[0]["cusShortName"].ToString();//投保客户
                TxtPolicyDate.Text = Convert.ToDateTime(data.Rows[0]["policy_date"]).ToString("yyyy-MM-dd");//保单日期
                TxtPolicyMaker.Text = data.Rows[0]["policy_maker"].ToString();//制单人
                TxtPolicyNum.Text = data.Rows[0]["policy_num"].ToString();//保单编号
                //TxtPremium.Text = data.Rows[0][""].ToString();//保费合计

                //TxtSalesman.Text = data.Rows[0]["cname"].ToString();//所属业务员

                TxtSerialNum.Text = data.Rows[0]["serialnum"].ToString();//内部流水号
                //TxtYears.Text = (Convert.ToDateTime(data.Rows[0]["policy_enddate"]).Year - Convert.ToDateTime(data.Rows[0]["policy_startdate"]).Year).ToString();//保单期限结束日期
                TxtTimeStart.Text = Convert.ToDateTime(data.Rows[0]["policy_startdate"]).ToString("yyyy-MM-dd");//保单期限开始日期
                txtEndTime.Text = Convert.ToDateTime(data.Rows[0]["policy_enddate"]).ToString("yyyy-MM-dd");
                TxtType.Text = data.Rows[0]["ProdTypeName"].ToString();//险种
                //TxtVerifyDate.Text = Convert.ToDateTime(data.Rows[0]["verifydate"]).ToString("yyyy-MM-dd");//审核日期
                //TxtVerifyUser.Text = data.Rows[0]["verifyUser"].ToString();//审核人

                DdlIsRenewal.SelectedIndex = data.Rows[0]["IsRenewal"] == null ? 1 : (data.Rows[0]["IsRenewal"].ToString() == "0" ? 1 : 0);//是否续保
                //DdlIsVirify.SelectedIndex = data.Rows[0]["isVerify"] == null ? 1 : (data.Rows[0]["isVerify"].ToString() == "0" ? 1 : 0);//审核状态
                DdlPolicyState.SelectedIndex = data.Rows[0]["policy_state"] == null ? 0 : (data.Rows[0]["policy_state"].ToString() == "0" ? 1 : 0);//保单状态

                zjjfrate.Text = data.Rows[0]["totalEcoRate"].ToString(); //总经济费比率
                zbf.Text = data.Rows[0]["totalPremium"].ToString(); //总保费
                zjjf.Text = data.Rows[0]["totalEconomic"].ToString();//总经济费
                zbe.Text = data.Rows[0]["totalBrokerage"].ToString();//总保额
                ztf.Text = data.Rows[0]["totalRich"].ToString();//总贴费
                cm.Text = data.Rows[0]["shipName"].ToString();//船名

                HidComId.Value = data.Rows[0]["company"].ToString();
                HidCusId.Value = data.Rows[0]["customer"].ToString();
                HidTypeId.Value = data.Rows[0]["ProdTypeNo"].ToString();
                HidSalesman.Value = data.Rows[0]["salesman"].ToString();
                this.DdlIsVirify.SelectedValue = data.Rows[0]["ruleid"].ToString(); //审核规则
                LoadAuditImg(int.Parse(data.Rows[0]["ruleid"].ToString()));

                DdlIsDaidian.SelectedValue = data.Rows[0]["isDaidian"].ToString();

                LoginInfo userInfo = LoginInfoManager.getLoginInfoById(Convert.ToInt32(data.Rows[0]["policy_makerId"]));
                if (userInfo != null)
                {
                    DepartmentInfo department = DepartmentInfoManager.getDepartmentInfoById(userInfo.Departid);
                    if (department != null)
                    {
                        txtMarkerDepart.Text = department.Departcname;
                    }
                }

                InitProductType(id);

                TxtSerialNum.Attributes.Add("ReadOnly", "true");
                TxtPolicyMaker.Attributes.Add("ReadOnly", "true");

                //初始化盈亏测算数据
                UCBudgetEdit1.InitBudgetData(id);
                UCTarget1.BindTarget(id);

                LoadFileList(id);
            }
            else
            {
                Response.End();
            }
        }

        /// <summary>
        /// 绑定保单对应的保险项目
        /// </summary>
        /// <param name="pid">保单ID</param>
        private void InitProductType(int pid)
        {
            #region 无用代码
            //ProductManager proBLL = new ProductManager();
            //DataTable data = To_PolicyDetailManager.GetListByPolicy(pid);


            //RpProType.DataSource = data;
            //RpProType.DataBind();

            //StringBuilder pros = new StringBuilder();
            //for (int i = 0; i < data.Rows.Count; i++)
            //{
            //    pros.Append(data.Rows[i]["ProdID"]);
            //    pros.Append("$");
            //    pros.Append(data.Rows[i]["coverage"]);
            //    pros.Append("$");
            //    pros.Append(data.Rows[i]["premium"]);
            //    pros.Append("|");
            //}

            //HidPros.Value = pros.ToString();
            #endregion

            DataTable tbl = To_PolicyDetailManager.GetListByPolicyid(pid);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string strnumeral = "";
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (i == 0)
                {
                    row = this.table.Rows[1];

                    //业务员列
                    cell = row.Cells[0];
                    cell.Attributes.Add("onclick", "document.getElementById('hidsaleman').value=$(this).find('input').attr('id')");
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["salesman"] + "' id='saleman1' class='Salesman' style='text-align: center' />";

                    //部门列
                    cell = row.Cells[1];
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["departname"] + "' id='depart1' class='depart' style='text-align: center' readonly='readonly' />";

                    //比率列
                    cell = row.Cells[2];
                    strnumeral = tbl.Rows[i]["numrate"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + strnumeral + "' class='clsrate' style='width: 95%' onblur='SetRate(this);GetNumjjf(this,jjf1)' />%";

                    //经济费列
                    cell = row.Cells[3];
                    strnumeral = tbl.Rows[i]["fmone"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + strnumeral + "' id='jjf1' class='clsjjf' reanonly='readonly' />";

                    //贴费列
                    cell = row.Cells[4];
                    strnumeral = tbl.Rows[i]["rich"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + strnumeral + "' class='clstiefei' />";

                    //备注列
                    cell = row.Cells[5];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["mark"].ToString() + "' />";
                }

                else
                {
                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();
                    string departid = "depart" + (i + 1).ToString();
                    string salesmanid = "salesman" + (i + 1).ToString();
                    cell.Attributes.Add("onclick", "document.getElementById('hidsaleman').value=$(this).find('input').attr('id'),artDialog.open('SelectSalesman.aspx?depart=" + departid + "')");
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["salesman"] + "' id='" + salesmanid + "' class='salesman' style='text-align: center' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["departname"] + "' id='" + departid + "' class='depart' style='text-align: center' readonly='readonly' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    string jjfid = "jjf" + (i + 1).ToString();
                    strnumeral = tbl.Rows[i]["numrate"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + strnumeral + "' class='clsrate' style='width: 95%' onblur='SetRate(this);GetNumjjf(this," + jjfid + ")' />%";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    strnumeral = tbl.Rows[i]["fmone"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + strnumeral + "' id='" + jjfid + "' class='clsjjf' readonly='readonly' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    strnumeral = tbl.Rows[i]["rich"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + strnumeral + "' class='clstiefei' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["mark"].ToString() + "' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.Attributes.Add("align", "center");
                    cell.InnerHtml = "<div class='imgdel'>&nbsp;</div>";
                    row.Controls.Add(cell);

                    this.table.Controls.Add(row);
                }

                this.hidsalemanrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hiddepartrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hidjjfrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
            }

        }




        /// <summary>
        /// 添加工作流管理
        /// </summary>
        /// <param name="args">保存或已提交</param>
        private int SavePolicyJob(string args, string auditsatus)
        {
            int result = 0;
            JobFlow jobflow = null;
            if (Request.Params["jobflowid"] == null || Request.Params["jobflowid"] == "")
            {
                string cuscode = "";  //公司代码全称
                string codeformat = ""; //公司代码，不包含流水号
                string ordernum = "";  //流水号

                StrNumbers(TxtSerialNum.Text.Trim(), out cuscode, out codeformat, out ordernum);

                jobflow = new JobFlow();
                jobflow.savestatus = args.ToString();
                jobflow.createtime = DateTime.Now;
                jobflow.endtime = DateTime.Now;
                jobflow.cname = cuscode; //工作流名称
                jobflow.attachment = ""; //附件上传（1表示有附件）
                jobflow.sort = "02";
                jobflow.auditsort = ""; //审核类型
                jobflow.auditstatus = auditsatus;
                jobflow.founderid = ((LoginInfo)Session["login"]).Id;
                jobflow.txt = "";
                jobflow.ruleid = int.Parse(this.DdlIsVirify.SelectedValue); //审核流程图关联id
                result = JobFlowManager.AddAndGetId(jobflow);
            }
            else
            {
                result = int.Parse(Request.Params["jobflowid"]);
                jobflow = JobFlowManager.GetModel(int.Parse(Request.Params["jobflowid"]));
                if (jobflow != null)
                {
                    jobflow.savestatus = args.ToString();
                    jobflow.auditstatus = auditsatus;
                    jobflow.ruleid = int.Parse(this.DdlIsVirify.SelectedValue);
                    JobFlowManager.Update(jobflow);
                }
            }
            return result;


        }


        /// <summary>
        /// 保存保单（编辑或添加）
        /// </summary>
        /// <returns>返回业务编号</returns>
        private string SavePolicy(int jobflowid)
        {

            To_Policy policyModel = new To_Policy();


            string cuscode = "";  //公司代码全称
            string codeformat = ""; //公司代码，不包含流水号
            string ordernum = "";  //流水号

            if (StrNumbers(TxtSerialNum.Text.Trim(), out cuscode, out codeformat, out ordernum))
            {
                policyModel.Assured = TxtAssured.Text;//被保险人
                policyModel.Company = int.Parse(HidComId.Value);//保险公司
                policyModel.Customer = int.Parse(HidCusId.Value);//投保客户
                policyModel.IsVerify = jobflowid; //工作流管理id
                policyModel.Policy_date = Convert.ToDateTime(TxtPolicyDate.Text);//表单日期
                policyModel.Policy_enddate = Convert.ToDateTime(txtEndTime.Text).ToString("yyyy-MM-dd"); //Convert.ToDateTime(TxtTimeStart.Text).AddYears(int.Parse(TxtYears.Text.Trim())).ToString("yyyy-MM-dd");//投保到期日期
                policyModel.Policy_startdate = Convert.ToDateTime(TxtTimeStart.Text).ToString("yyyy-MM-dd");//投保开始日期
                policyModel.Policy_maker = TxtPolicyMaker.Text;//制单人
                policyModel.Policy_num = TxtPolicyNum.Text;//表单编号
                policyModel.Policy_state = Convert.ToInt32(DdlPolicyState.SelectedValue);//保单状态（0：无效；1：有效）
                policyModel.Protype = HidTypeId.Value;//险种
                //policyModel.Salesman = int.Parse(HidSalesman.Value);// int.Parse(TxtSalesman.Text);//所属业务员
                policyModel.Salesman = 0;//去掉主表中的业务员信息，将其设置为默认0；
                //policyModel.Serialnum = TxtSerialNum.Text;//内部流水号
                policyModel.Verifydate = DateTime.Now;// Convert.ToDateTime(TxtVerifyDate.Text);//审核日期
                policyModel.VerifyUser = "";// TxtVerifyUser.Text;//审核人
                policyModel.IsRenewal = Convert.ToInt32(DdlIsRenewal.SelectedValue); //是否续保
                policyModel.UserCompany = ddlUnit.SelectedItem.Text; //经营单位

                policyModel.TotalEcoRate = Convert.ToDouble(zjjfrate.Text); //总经济费比率
                policyModel.TotalEconomic = Convert.ToDouble(this.zjjf.Text); //总经济费
                policyModel.TotalRich = Convert.ToDouble(ztf.Text); //总贴费
                policyModel.ShipName = cm.Text; //船名
                policyModel.TotalPremium = Convert.ToDouble(zbf.Text); //总保费
                policyModel.TotalBrokerage = Convert.ToDouble(zbe.Text); //总保额

                policyModel.Txt = ""; //审核意见
                policyModel.IsDaidian = int.Parse(DdlIsDaidian.SelectedValue.Trim());//是否代垫保费，0：否，1：是
                policyModel.OrderNum = ordernum;
                policyModel.CodeFormart = codeformat;
                policyModel.Serialnum = cuscode;

                object action = Request.QueryString["action"];

                //表示编辑保单
                if (action != null && action.ToString() == "edit")
                {
                    List<string> p = new List<string>(); //存储业务员的汇总
                    object id = Request.QueryString["id"];
                    int rid = 0;
                    if (id != null && int.TryParse(id.ToString(), out rid))
                    {
                        policyModel.Id = rid;
                        if (To_PolicyManager.updateTo_Policy(policyModel) > 0)
                        {
                            To_PolicyDetailManager.DeleteByPolicy(policyModel.Id);
                            if (HidPros.Value != "")
                            {
                                string[] items = HidPros.Value.Split(',');
                                string[] txt = null;
                                To_PolicyDetail pdModel = null;
                                foreach (string item in items)
                                {
                                    pdModel = new To_PolicyDetail();
                                    txt = item.Split('|');
                                    pdModel.PolicyId = policyModel.Id; //保单id
                                    pdModel.Salesman = txt[0]; //业务员
                                    if (!p.Contains(txt[0]))
                                    {
                                        p.Add(txt[0]);
                                    }
                                    pdModel.DepartName = txt[1]; //部门
                                    pdModel.NumRate = decimal.Parse(txt[2]); //比率
                                    pdModel.Fmone = decimal.Parse(txt[3]); //经济费
                                    pdModel.Rich = decimal.Parse(txt[4]); //贴费
                                    pdModel.Mark = txt[5]; //备注

                                    To_PolicyDetailManager.addTo_PolicyDetail(pdModel);

                                }
                                StringBuilder persons = new StringBuilder();
                                foreach (string s in p)
                                {
                                    persons.Append(s + ";");
                                }
                                To_PolicyManager.updateTo_PolicySalesman(persons.ToString(), rid);

                            }

                            To_PolicyTargetManager.DeleteByPolicy(rid);
                            if (HidTarget.Value != "")
                            {
                                string hidValues = HidTarget.Value.TrimEnd('@').Replace("\r\n", "");

                                string[] values = hidValues.Split('@');

                                To_PolicyTarget To_PolicyTarget = new To_PolicyTarget();
                                To_PolicyTarget.PolicyID = rid;

                                foreach (string value in values)
                                {
                                    string[] propertyArr = value.Split('$');
                                    To_PolicyTarget.Datatype = propertyArr[4].Trim() == "" ? 0 : int.Parse(propertyArr[4].Trim());
                                    To_PolicyTarget.PropertyName = propertyArr[0].Trim();
                                    To_PolicyTarget.PropertyTypeID = propertyArr[2].Trim() == "" ? 0 : int.Parse(propertyArr[2].Trim());
                                    To_PolicyTarget.PropertyValue = propertyArr[1].Trim();
                                    To_PolicyTarget.PropertyID = propertyArr[3].Trim() == "" ? 0 : int.Parse(propertyArr[3].Trim());

                                    To_PolicyTargetManager.addTo_PolicyTarget(To_PolicyTarget);
                                }
                            }

                            if (HidFiles.Value != "")
                            {
                                string oldFiles = HidFiles.Value.Trim().TrimEnd(',');
                                if (oldFiles != "")
                                {
                                    To_PolicyFileManager policyFileBLL = new To_PolicyFileManager();
                                    policyFileBLL.DeleteList(oldFiles);
                                }
                            }
                            //上传附件并返回文件名集合
                            string[] str = FileUp(Request.Files);
                            if (str[0] == "" && str[6] == "1")
                            {
                                SaveFilePath(str, rid);
                            }
                        }

                        UCBudgetEdit1.SaveData(rid);
                    }
                }
                    //新增保单
                else if (action != null && action.ToString() == "new")
                {
                    policyModel.Policy_makerId = (Session["login"] as LoginInfo).Id;
                    Add(policyModel);
                }

            }

            return cuscode;
        }

        /// <summary>
        /// 选择规则DDL
        /// </summary>
        public void InitVifify()
        {
            this.DdlIsVirify.Items.Clear();

            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string strsql = " jobflowsort='02' AND  ',' + departidlist + ',' like '%," + login.Departid.ToString() + ",%' ";

            DataTable typelist = EtNet_BLL.ViewBLL.ViewApprovalRuleManager.getList(strsql);
            for (int i = 0; i < typelist.Rows.Count; i++)
            {
                ListItem list = new ListItem(typelist.Rows[i]["sort"].ToString() + "→" + typelist.Rows[i]["CName"].ToString(), typelist.Rows[i]["Id"].ToString());
                this.DdlIsVirify.Items.Add(list);
            }
            ListItem ltem = new ListItem("选择流程", "-1");//添加第一行默认值
            this.DdlIsVirify.Items.Insert(0, ltem);//添加第一行默认值

        }

        /// <summary>
        /// 绑定所在单位数据
        /// </summary>
        private void BindDdlUnit()
        {
            LoginInfo loginInfo = Session["login"] as LoginInfo;
            if (loginInfo == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            LoginInfo userInfo = LoginInfoManager.getLoginInfoById(loginInfo.Id);

            if (userInfo != null)
            {
                if (userInfo.Firmidlist.Trim() != string.Empty)
                {
                    string strWhere = string.Format("id in ({0})", userInfo.Firmidlist);
                    DataTable dtFirmList = FirmInfoManager.GetList(strWhere);

                    ddlUnit.DataTextField = "cname";
                    ddlUnit.DataValueField = "id";
                    ddlUnit.DataSource = dtFirmList;
                    ddlUnit.DataBind();

                    if (ddlUnit.Items.Count > 0)
                        ddlUnit.SelectedIndex = 0;
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
            string stafflist = rule.idgourp; //审核人员组
            string auditsort = rule.sort; //审核类别
            string[] staff = null; //存储审核人员
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
                        model.numbers = i + 1; //当前第几个审核人员
                        model.jobflowid = id;
                        model.reviewerid = int.Parse(staff[i]); //当前审核人员对应的人员id
                        model.opiniontxt = ""; //审核意见
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
                        model.opiniontxt = "";
                        model.reviewerid = int.Parse(staff[i]);
                        EtNet_BLL.AuditJobFlowManager.Add(model);
                    }
                    break;
            }
        }


        /// <summary>
        /// 点击保存时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, ImageClickEventArgs e)
        {

            //string msg = string.Empty;
            //object ID = Request.QueryString["id"];

            //if (To_PolicyManager.ExitsRecordByField("serialnum", TxtSerialNum.Text.Trim(), ID))
            //{
            //    msg = "内部编号已存在";
            //}
            //else if (To_PolicyManager.ExitsRecordByField("policy_num", TxtPolicyNum.Text.Trim(), ID))
            //{
            //    msg = "保单编号已存在";
            //}
            //if (msg != string.Empty)
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", string.Format("alert('{0}')", msg), true);
            //    return;
            //}

            int jfid = SavePolicyJob("草稿", "01");
            SavePolicy(jfid);


            //Response.Redirect("PolicyList.aspx");
            JumpToBudget("保存成功");
        }


        /// <summary>
        /// 点击送审时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void itbnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            //string msg = string.Empty;
            //object ID = Request.QueryString["id"];
            //if (To_PolicyManager.ExitsRecordByField("serialnum", TxtSerialNum.Text.Trim(), ID))
            //{
            //    msg = "内部编号已存在";
            //}
            //else if (To_PolicyManager.ExitsRecordByField("policy_num", TxtPolicyNum.Text.Trim(), ID))
            //{
            //    msg = "保单编号已存在";
            //}
            //if (msg != string.Empty)
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", string.Format("alert('{0}')", msg), true);
            //    return;
            //}


            int jfid = SavePolicyJob("已提交", "01");
            string serialNum = SavePolicy(jfid);
            CreateApproval(int.Parse(this.DdlIsVirify.SelectedValue), jfid);

            SendMessage(serialNum);
            //Response.Redirect("PolicyList.aspx");
            JumpToBudget("送审成功");
        }


        /// <summary>
        /// 保存成功后跳转到中间页面，判断是否添加盈亏测算数据
        /// </summary>
        private void JumpToBudget(string msg)
        {
            if (Request.QueryString["action"].ToString() == "new")
                Response.Redirect(string.Format("Jump.aspx?policy={0}", _policyID));
            else
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('" + msg + "');self.location.href='PolicyList.aspx';", true);
        }

        /// <summary>
        /// 发消息给审核用户
        /// </summary>
        private void SendMessage(string serialNum)
        {
            ApprovalRule rule = ApprovalRuleManager.GetModel(int.Parse(DdlIsVirify.SelectedValue));

            if (rule.idgourp.Trim() != string.Empty)
            {
                EtNet_Models.Information messageEntity = new EtNet_Models.Information();


                messageEntity.associationid = 0;//此处不需要，默认给一个值  消息分类关联的id值,邮件的id值,文档的id值
                messageEntity.contents = string.Format("编号为{0}的保单需要您审批!", serialNum); //消息提示信息
                messageEntity.createtime = DateTime.Now; //创建时间
                messageEntity.founderid = (Session["login"] as LoginInfo).Id; //创建人id
                messageEntity.sendtime = DateTime.Now; //发送时间
                messageEntity.sortid = 10;//消息分类：保单审核

                if (messageBLL.Add(messageEntity))
                {
                    IEnumerable<string> userList = rule.idgourp.Split(',').Where(x => x != string.Empty);

                    int messageID = messageBLL.GetMaxId();

                    EtNet_Models.InformationNotice messageNoticeEntity = new InformationNotice();
                    messageNoticeEntity.informationid = messageID;

                    int len = rule.sort == "单审" ? 1 : userList.Count();

                    if (rule.sort == "单审")
                    {
                        messageNoticeEntity.recipientid = int.Parse(userList.ElementAt(0));
                        messageNoticeEntity.remind = "是";//默认未阅读;

                        InformationNoticeManager.Add(messageNoticeEntity);
                    }

                    else
                    {

                        foreach (string user in userList)
                        {

                            messageNoticeEntity.recipientid = int.Parse(user);
                            messageNoticeEntity.remind = "是";//默认未阅读;

                            InformationNoticeManager.Add(messageNoticeEntity);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 上传附件，返回上传文件的路径的集合
        /// </summary>
        private string[] FileUp(HttpFileCollection item)
        {

            //str[0]：错误消息，没有错误为""
            //str[1-5]：文件（路径|大小|原始文件名）
            //str[6]：0为没有文件，1为有上传文件
            string[] str = new string[7] { "", "", "", "", "", "", "0" };
            string fileload = ""; //文件的路径
            //str[6] = "0";0为没有文件，1为有上传文件
            int num = 1;
            string path = "~/UploadFile/Policy/";
            // 判断目标目录是否存在如果不存在则新建之  
            if (!Directory.Exists(Server.MapPath(path)))
                Directory.CreateDirectory(Server.MapPath(path));
            string saveUrl = path;
            HttpPostedFile postfile = null;
            for (int i = 0; i < item.Count; i++)
            {
                postfile = item[i];
                if (postfile.FileName == "")
                {

                }
                else if (String.IsNullOrEmpty(Path.GetExtension(postfile.FileName).ToLower()))
                {
                    str[0] = postfile.FileName + "文件拓展名出错，导致上传失败";
                    str[6] = "0";
                    if (num == 1)
                    {
                        return str;
                    }
                    else
                    {
                        for (int j = 1; j < num; j++)
                        {
                            fileload = str[j].Substring(0, str[j].LastIndexOf("|"));
                            File.Delete(HttpContext.Current.Server.MapPath(fileload));
                        }
                        return str;
                    }
                }
                else
                {
                    if (postfile.ContentLength <= (1024 * 1024))
                    {
                        string fileExt = Path.GetExtension(postfile.FileName).ToLower();
                        //上传文件的名称包括拓展名
                        string orfilename = postfile.FileName.Substring(postfile.FileName.LastIndexOf("\\") + 1);
                        string newFile = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + orfilename;
                        postfile.SaveAs(HttpContext.Current.Server.MapPath(saveUrl + newFile));
                        str[num] = saveUrl + newFile + "|" + postfile.ContentLength + "|" + orfilename;
                        str[6] = "1";
                        num++;

                    }
                    else
                    {
                        str[0] = postfile.FileName + "文件太大，导致上传失败";
                        str[6] = "0";
                        if (num == 1)
                        {
                            return str;
                        }
                        else
                        {
                            for (int j = 1; j < num; j++)
                            {
                                fileload = str[j].Substring(0, str[j].LastIndexOf("|"));
                                File.Delete(HttpContext.Current.Server.MapPath(fileload));

                            }
                            return str;
                        }
                    }

                }

            }

            return str;

        }

        /// <summary>
        /// 将附件信息保存到数据库
        /// </summary>
        /// <param name="fileList"></param>
        /// <param name="policID"></param>
        private void SaveFilePath(string[] fileList, int policID)
        {
            To_PolicyFileManager policyFileBLL = new To_PolicyFileManager();
            To_PolicyFile policyFileEntity = new To_PolicyFile();

            policyFileEntity.policyID = policID;

            for (int i = 1; i < 6; i++)
            {
                if (fileList[i] != "")
                {
                    string[] fileInfo = fileList[i].Split('|');

                    policyFileEntity.Filesize = int.Parse(fileInfo[1]);
                    policyFileEntity.filepath = fileInfo[0];
                    policyFileEntity.filename = fileInfo[2];
                    policyFileEntity.createTime = DateTime.Now;

                    policyFileBLL.Add(policyFileEntity);
                }
            }
        }

        /// <summary>
        /// 绑定附件列表
        /// </summary>
        private void LoadFileList(int policyID)
        {
            To_PolicyFileManager policyFileBLL = new To_PolicyFileManager();
            RpFileList.DataSource = policyFileBLL.GetList(string.Format(" policyID={0}", policyID));
            RpFileList.DataBind();
        }

        /// <summary>
        /// 转换文件大小单位
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        protected string ChangeSize(int size)
        {
            decimal newSize = size / 1024;

            if ((newSize / 1024) >= 1)
                return (newSize / 1024).ToString("F2") + "M";
            return newSize.ToString("F2") + "KB";
        }



        /// <summary>
        /// 业务编号是否自动生成
        /// </summary>
        private void IsEditCuscode()
        {
            DataTable tbl = GetModuleCoding();
            if (tbl.Rows[0]["usecode"].ToString() == "1") //流水号
            {
                object action = Request.QueryString["action"];

                this.txtshow.InnerHtml = "(自动生成)";
            }
            else
            {
                this.txtshow.InnerHtml = "*";
                TxtSerialNum.ReadOnly = false;
            }
        }

        /// <summary>
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = " num = '00005'";
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

                    cuscode = strcuscode; //客户代码全称

                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,业务编号不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                codeformat = Numbers(txtformat); //名称
                strsql = "  codeFormart= '" + codeformat + "' AND LEN(orderNum) =" + len.ToString();
                custbl = To_PolicyManager.GetList(1, strsql, " id desc ");

                if (custbl.Rows.Count >= 1)
                {
                    if (custbl.Rows[0]["orderNum"].ToString() != "")
                    {
                        num = int.Parse(custbl.Rows[0]["orderNum"].ToString()) + 1; //流水号
                        if (num.ToString().Length > len)
                        {
                            result = false;
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,业务编号长度不够!')</script>");
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
    }
}