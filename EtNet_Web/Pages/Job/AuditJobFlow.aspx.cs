using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace EtNet_Web.Pages.Job
{
    public partial class AuditJobFlow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    QueryBuilder();
                    PageSymbolNum();
                    LoadLoginData();
                    LoadRptjobflowData();
                    ShowTxt();
                    this.Page.DataBind();
                }
            }
        }



        public string ShowColor(string str)
        {
            string result = "";
            switch (str)
            {

                case "未审批":
                    result = "<span style='color:Red'>" + str + "</span>";
                    break;

                case "已审批":
                    result = "<span style='color:Green'>" + str + "</span>";
                    break;
                default:
                    result = str;
                    break;
            }
            return result;
        }

        public string ShowAuditoperatColor(string str)
        {
            string result = "";
            switch (str)
            {
                case "未操作":
                    result = "<span style='color:Red'>" + str + "</span>";
                    break;

                case "通过":
                    result = "<span style='color:Green'>" + str + "</span>";
                    break;
                default:
                    result = str;
                    break;
            }
            return result;
        }

        public string LoadZtreeData()
        {
            string result = "";
            string[] list = null;
            string strcount = "";
            list = StrCount("").Split('_');
            strcount = "(" + list[0] + ")";
            result += "[{id:1, pId: 0, name:'全部单据" + strcount + "', icon:'../../Images/public/bfolder.gif', open: true },";

            list = StrCount("01").Split('_');
            strcount = "(" + list[0] + ")";
            result += "{id:2, pId: 1, name: '报销管理" + strcount + "',icon:'../../Images/public/folder.gif'},";

            list = StrCount("02").Split('_');
            strcount = "(" + list[0] + ")";
            result += " {id:3, pId: 1, name: '订单管理" + strcount + "',icon:'../../Images/public/folder.gif' },";

            list = StrCount("03").Split('_');
            strcount = "(" + list[0] + ")";
            result += "{id:4, pId: 1, name: '客户管理" + strcount + "',icon:'../../Images/public/folder.gif'},";

            list = StrCount("04").Split('_');
            strcount = "(" + list[0] + ")";
            result += " {id:5, pId: 1, name: '公告管理" + strcount + "',icon:'../../Images/public/folder.gif'},";


            list = StrCount("05").Split('_');
            strcount = "(" + list[0] + ")";
            result += "{id:6, pId: 1, name: '付款管理" + strcount + "',icon:'../../Images/public/folder.gif'}];";
            return result;

        }


        public string StrCount(string sort)
        {
            string result = "";
            int count = 0;
            int past = 0;
            string strsql = " reviewerid =" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND (nowreviewer ='T' OR nowreviewer='p') AND auditoperat = '未操作' ";
            switch (sort)
            {
                case "01":
                    strsql += " AND sort='01' "; //报销
                    break;

                case "02":
                    strsql += " AND sort='02' "; //保单
                    break;

                case "03":
                    strsql += " AND sort='03' "; //客户
                    break;

                case "04":
                    strsql += " AND sort='04' "; //公告
                    break;

                case "05":
                    strsql += " AND sort='05' "; //付费
                    break;
            }
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAuditJobFlowManager.getList(strsql);
            count = tbl.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (tbl.Rows[i]["nowreviewer"].ToString() == "T")
                {
                    past++;
                }
            }
            result = past.ToString() + "_" + count.ToString();
            return result;

        }



        /// <summary>
        /// 加载人员数据
        /// </summary>
        private void LoadLoginData()
        {
            IList<EtNet_Models.LoginInfo> list = EtNet_BLL.LoginInfoManager.getLoginInfoAll();

            this.ddlpeople.DataSource = list;
            this.ddlpeople.DataValueField = "id";
            this.ddlpeople.DataTextField = "cname";
            this.ddlpeople.DataBind();
            ListItem item = new ListItem("——请选中——", "-1");
            this.ddlpeople.Items.Insert(0, item);
        }





        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='003'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "003";
                pageset.Pagecount = 5;
                pageset.Pageitem = 10;
                EtNet_BLL.SearchPageSetManager.addSearchPageSet(pageset);
                return Exists();
            }
            else
            {
                return tbl;
            }
        }



        /// <summary>
        /// 页面数字标识
        /// </summary>
        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = ""; //如无PageNum，先生成一个
            }
            if (Session["PageNum"].ToString() != "003")
            {
                Session["PageNum"] = "003";
                Session["query"] = " AND operatstatus='未审批' ";
            }

        }


        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = " AND operatstatus='未审批' ";
            }
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            Session["query"] = "";
            string strsql = "";
            if (this.iptnumber.Value.Trim() != "")
            {
                strsql += " AND  cname like '%" + this.iptnumber.Value + "%' ";

            }
            if (this.ddlpeople.SelectedIndex != 0)
            {
                strsql += " AND  logincode=" + this.ddlpeople.SelectedValue;
            }
            if (this.selauditstatus.SelectedIndex != 0)
            {
                if (this.selauditstatus.Value != "全部")
                {
                    strsql += " AND  operatstatus = '" + this.selauditstatus.Value + "' ";
                }
            }
            //else
            //{
            //    strsql += " AND operatstatus='未审批' ";
            //}
            if (this.hidsort.Value != "" && this.hidsort.Value != "1")
            {
                if (this.hidsort.Value=="3")
                {
                    strsql += " AND operatstatus='未审批' ";
                }
                strsql += " AND sort='0" + (int.Parse(this.hidsort.Value) - 1).ToString() + "' ";
            }

            Session["query"] = strsql;
        }




        /// <summary>
        /// 显示制单日期
        /// </summary>
        public string ShowDate(string jfid)
        {
            string result = "";
            int id = int.Parse(jfid.Trim());
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(id);
            DataTable tbl = null;
            if (model.sort == "01")
            {
                tbl = EtNet_BLL.AusRottenInfoManager.GetList("jobflowid=" + jfid);
                if (tbl.Rows.Count > 0)
                {
                    result = DateTime.Parse(tbl.Rows[0]["applydate"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    result = "";
                }
            }
            else if (model.sort == "02")
            {
                tbl = EtNet_BLL.To_OrderInfoManager.GetLists("jobflowid=" + jfid);
                if (tbl.Rows.Count > 0)
                {
                    result = DateTime.Parse(tbl.Rows[0]["makertime"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    result = "";
                }
            }
            else if (model.sort == "03")
            {
                tbl = EtNet_BLL.CustomerManager.GetList("jobflowid=" + jfid);

                if (tbl.Rows.Count > 0)
                {
                    result = tbl.Rows.Count == 0 ? "" : DateTime.Parse(tbl.Rows[0]["madeTime"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    result = "";
                }

            }
            else if (model.sort == "04")
            {
                tbl = EtNet_BLL.AnnouncementInfoManager.GetList("jobflowid=" + jfid);
                if (tbl.Rows.Count > 0)
                {
                    result = DateTime.Parse(tbl.Rows[0]["printtime"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    result = "";
                }
            }
            else if (model.sort == "05")
            {
                EtNet_BLL.To_PaymentManager pmodel = new EtNet_BLL.To_PaymentManager();
                tbl = pmodel.GetList("jobFlowID=" + jfid);
                if (tbl.Rows.Count > 0)
                {
                    result = DateTime.Parse(tbl.Rows[0]["requestDate"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }


        public void ShowTxt()
        {
            string strtxt = Session["query"].ToString();
            Regex rg1 = new Regex("sort='01");
            Regex rg2 = new Regex("sort='02");
            Regex rg4 = new Regex("sort='04");
            Regex rg5 = new Regex("sort='05");

            if (rg1.IsMatch(strtxt))
            {

                this.lbltxt.Text = "";
                this.lbltxtone.Text = "金额";
                this.lbltxttwo.Text = "";
            }
            else if (rg2.IsMatch(strtxt))
            {
                this.lbltxt.Text = "";
                this.lbltxtone.Text = "";
                this.lbltxttwo.Text = "";

            }
            else if (rg4.IsMatch(strtxt))
            {
                this.lbltxt.Text = "公告标题";
                this.lbltxtone.Text = "";
                this.lbltxttwo.Text = "";
            }
            else if (rg5.IsMatch(strtxt))
            {
                this.lbltxt.Text = "付款名称";
                this.lbltxtone.Text = "付款单位";
                this.lbltxttwo.Text = "金额";
            }
            else
            {
                this.lbltxt.Text = "";
                this.lbltxtone.Text = "";
                this.lbltxttwo.Text = "";

            }
        }




        public string ShowData(string jfid)
        {
            string result = "";
            int id = int.Parse(jfid.Trim());
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(id);
            DataTable tbl = null;

            string strtxt = Session["query"].ToString();
            //Regex rg1 = new Regex("sort='01");
            Regex rg2 = new Regex("sort='02");
            Regex rg4 = new Regex("sort='04");
            Regex rg5 = new Regex("sort='05");
            //if (rg1.IsMatch(strtxt) && model.sort == "01")
            //{
            //    tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist("jobflowid=" + jfid);
            //    result = tbl.Rows[0]["typename"].ToString();
            //}

            //if (rg2.IsMatch(strtxt) && model.sort == "02")
            //{
            //    tbl = EtNet_BLL.To_OrderInfoManager.GetLists("jobflowID=" + jfid);
            //    // tbl = EtNet_BLL.To_PolicyManager.GetLists("verify=" + jfid);
            //    result = tbl.Rows[0]["ordernum"].ToString();
            //}
            if (rg4.IsMatch(strtxt) && model.sort == "04")
            {
                tbl = EtNet_BLL.AnnouncementInfoManager.GetList("jobflowid=" + jfid);
                result = tbl.Rows[0]["title"].ToString();
            }
            if (rg5.IsMatch(strtxt) && model.sort == "05")
            {
                EtNet_BLL.To_PaymentManager bPayment = new EtNet_BLL.To_PaymentManager();

                tbl = bPayment.GetList("jobFlowID=" + jfid);

                if (tbl.Rows.Count > 0)
                    result = GetPayForName(tbl.Rows[0]["payFor"]);
            }

            return result;
        }

        /// <summary>
        /// 获取付款名称
        /// </summary>
        /// <param name="payForField"></param>
        /// <returns></returns>
        protected string GetPayForName(object payForField)
        {
            string payForName = "未知";
            if (payForField == DBNull.Value || payForField == null) { return payForName; }

            string payFor = payForField.ToString();

            switch (payFor)
            {
                case "exp_premium":
                    payForName = "代垫保费";
                    break;
                case "exp_commission":
                    payForName = "佣金";
                    break;
                case "exp_tiefei":
                    payForName = "贴费";
                    break;
                case "exp_consultingFees":
                    payForName = "咨询费";
                    break;
                case "exp_serviceCharge":
                    payForName = "服务费";
                    break;
                case "exp_managementFees":
                    payForName = "管理费";
                    break;
                case "exp_other1":
                    payForName = "其他1";
                    break;
                case "exp_other2":
                    payForName = "其他2";
                    break;
                case "exp_other3":
                    payForName = "其他3";
                    break;
                case "exp_other4":
                    payForName = "其他4";
                    break;
                case "exp_other5":
                    payForName = "其他5";
                    break;
                default:
                    break;
            }

            return payForName;
        }

        public string ShowDataOne(string jfid)
        {
            string result = "";
            int id = int.Parse(jfid.Trim());
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(id);
            DataTable tbl = null;

            string strtxt = Session["query"].ToString();
            Regex rg1 = new Regex("sort='01");
            Regex rg2 = new Regex("sort='02");
            Regex rg5 = new Regex("sort='05");
            if (rg1.IsMatch(strtxt) && model.sort == "01")
            {
                tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist("jobflowid=" + jfid);
                if (tbl.Rows.Count > 0)
                {
                    result = Decimal.Round(Decimal.Parse(tbl.Rows[0]["totalmoney"].ToString()), 2).ToString();
                }
            }

            //if (rg2.IsMatch(strtxt) && model.sort == "02")
            //{
            //    tbl = EtNet_BLL.To_OrderInfoManager.GetLists(" jobflowID=" + jfid.ToString());
            //    //tbl = EtNet_BLL.To_PolicyManager.GetLists("jobFlowID=" + jfid);
            //    result = tbl.Rows[0]["OrderNum"].ToString();
            //}

            if (rg5.IsMatch(strtxt) && model.sort == "05")
            {
                EtNet_BLL.To_PaymentManager bPayment = new EtNet_BLL.To_PaymentManager();

                tbl = bPayment.GetList("jobFlowID=" + jfid);

                if (tbl.Rows.Count > 0 && tbl.Rows[0]["payerName"] != DBNull.Value)
                    result = tbl.Rows[0]["payerName"].ToString();
            }

            return result;
        }


        public string ShowDataTwo(string jfid)
        {
            string result = "";
            int id = int.Parse(jfid.Trim());
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(id);
            DataTable tbl = null;

            string strtxt = Session["query"].ToString();
            Regex rg2 = new Regex("sort='02");
            Regex rg5 = new Regex("sort='05");
            //if (rg2.IsMatch(strtxt) && model.sort == "02")
            //{
            //    tbl = EtNet_BLL.To_OrderInfoManager.GetLists(" jobflowID=" + jfid.ToString());
            //    //tbl = EtNet_BLL.To_PolicyManager.GetLists("isVerify=" + jfid);
            //    result = tbl.Rows[0]["orderNum"].ToString();
            //}
            if (rg5.IsMatch(strtxt) && model.sort == "05")
            {
                EtNet_BLL.To_PaymentManager bPayment = new EtNet_BLL.To_PaymentManager();

                tbl = bPayment.GetList("jobFlowID=" + jfid);

                if (tbl.Rows.Count > 0 && tbl.Rows[0]["totalAmount"] != DBNull.Value)
                    result = tbl.Rows[0]["totalAmount"].ToString();
            }

            return result;
        }


        /// <summary>
        /// 加载审核的工作流的数据
        /// </summary>
        private void LoadRptjobflowData()
        {
            pages.Visible = true;
            DataTable tbl = Exists();
            string str = " AND auditoperat = '未操作' AND reviewerid =" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND (nowreviewer ='T' OR nowreviewer='p') ";
            str += Session["query"].ToString();

            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());

            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet set = data.DataPage("ViewAuditJobFlow", "id", "*", str, "id", true, pitem, pcount, pages);
            this.rptauditjobflow.DataSource = set;
            this.rptauditjobflow.DataBind();
        }


        /// <summary>
        /// 工作流的审核状态
        /// </summary>
        private string JobFlowAuditStatus(int jobflowid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jobflowid);
            return model.auditstatus;
        }



        /// <summary>
        /// 审核人的状态
        /// </summary>
        private string ReviewerStatus(string jobflowid, int reviewerid)
        {
            string str = "jobflowid =" + jobflowid.ToString() + " AND  reviewerid=" + reviewerid.ToString();
            DataTable tbl = EtNet_BLL.AuditJobFlowManager.GetList(str);
            if (tbl.Rows.Count > 0)
            {
                return tbl.Rows[0]["nowreviewer"].ToString();
            }
            else
            {
                return "";
            }
        }

        protected void rptauditjobflow_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
             
            switch (e.CommandName)
            {
                case "audit":
                    string[] str = e.CommandArgument.ToString().Split('-');
                    string rs = ReviewerStatus(str[0], ((EtNet_Models.LoginInfo)Session["login"]).Id);
                    if (rs == "")
                    {
                        //工作流已删除或审核人员已更改
                        LoadRptjobflowData();
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "faudit", "<script>alert('不能进入审批界面，原因可能是该申请已修改或删除！')</script>", false);
                        return;
                    }
                    else if (rs == "F")
                    {
                        LoadRptjobflowData();
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "faudit", "<script>alert('不能进入审批界面,原因可能是审批受限制！')</script>", false);
                    }
                    else if (rs == "T")
                    {
                        string strstatus = JobFlowAuditStatus(int.Parse(str[0]));
                        if (strstatus == "03" || strstatus == "04")
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "auditR", "<script>alert('该工作流已由他人审批，无需再审！')</script>", false);
                        }
                        else
                        {
                            if (str[1] == "01")
                            {
                                if (HttpContext.Current.Request.QueryString["page"] != null)
                                {
                                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                                    Response.Redirect("ReimbursedForm/AuditReimbursedForm.aspx?pageindex=" + page + "&jobflowid=" + str[0]);

                                }
                                else
                                    Response.Redirect("ReimbursedForm/AuditReimbursedForm.aspx?jobflowid=" + str[0]);

                            }

                            else if (str[1] == "02")
                            {
                                if (HttpContext.Current.Request.QueryString["page"] != null)
                                {
                                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                                    Response.Redirect("../Order/AuditOrder.aspx?pageindex=" + page + "&jobflowid=" + str[0]);

                                }
                                else
                                Response.Redirect("../Order/AuditOrder.aspx?jobflowid=" + str[0]);
                            }
                            else if (str[1] == "03")
                            {
                                if (HttpContext.Current.Request.QueryString["page"] != null)
                                {
                                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                                    Response.Redirect("../CusInfo/AuditCus.aspx?pageindex=" + page + "&jobflowid=" + str[0]);

                                }
                                else
                                Response.Redirect("../CusInfo/AuditCus.aspx?jobflowid=" + str[0]);
                            }
                            else if (str[1] == "04")
                            {
                                if (HttpContext.Current.Request.QueryString["page"] != null)
                                {
                                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                                    Response.Redirect("../Announcement/AnnouncementAuditFirm.aspx?pageindex=" + page + "&jobflowid=" + str[0]);

                                }
                                else
                                Response.Redirect("../Announcement/AnnouncementAuditFirm.aspx?jobflowid=" + str[0]);
                            }
                            else if (str[1] == "05")
                            {
                                if (HttpContext.Current.Request.QueryString["page"] != null)
                                {
                                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                                    Response.Redirect("../Financial/AuditPayment.aspx?pageindex=" + page + "&jobflowid=" + str[0]);

                                }
                                else
                                Response.Redirect("../Financial/AuditPayment.aspx?jobflowid=" + str[0]);
                            }
                            else
                            {

                            }
                        }
                    }
                    else if (rs == "P")
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "auditP", "<script>alert('不能重复审批！')</script>", false);
                    }
                    else
                    {

                    }
                    break;
                case "search":
                    string[] str2 = e.CommandArgument.ToString().Split('-');
                    int jfid2 = int.Parse(str2[0]);
                    if (str2[1] == "01") //报销审核的查看
                    {
                        SearchReimbursement(jfid2);
                    }
                    else if (str2[1] == "02") //定审核的查看
                    {
                        SearchOrder(jfid2);
                    }
                    else if (str2[1] == "03") //客户审批查看
                    {
                        SearchCus(jfid2);
                    }
                    else if (str2[1] == "04") //公告审核查看
                    {
                        SearchAnnoun(jfid2);
                    }
                    else if (str2[1] == "05") //付款申请单查看
                    {
                        SearchPayment(jfid2);
                    }
                    break;
                case "refresh":
                    string[] str3 = e.CommandArgument.ToString().Split('-');
                    int jfid3 = int.Parse(str3[0]); //工作流id
                    EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid3); //得到工作流实例
                    string strfresh = " jobflowid = " + jfid3;
                    EtNet_BLL.AuditJobFlowManager.Delete(strfresh);//删除审核数据，将审核状态改为初始状态
                    model.savestatus = "草稿";
                    model.auditstatus = "01"; //审核状态改为未开始状态
                    model.txt = "";//审核意见置空
                    if (model.sort == "01") //报销审核
                    {
                        string id = EtNet_BLL.AusRottenInfoManager.GetList(strfresh).Rows[0]["id"].ToString();//根据工作流id得到报销单的id值
                        EtNet_Models.AusRottenInfo rotten = EtNet_BLL.AusRottenInfoManager.GetModel(int.Parse(id));
                        if (rotten != null)
                        {
                            rotten.txt = "";//清空审批人员的审批意见
                            EtNet_BLL.AusRottenInfoManager.Update(rotten);
                        }
                    }
                    else if (model.sort == "02") //订单审核
                    {
                    }
                    else if (model.sort == "03") //客户审核
                    {
                        string sqlcus = " jobflowid = " + jfid3;
                        DataTable tblcus = EtNet_BLL.CustomerManager.GetList(1, sqlcus, "id");
                        EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(int.Parse(tblcus.Rows[0]["id"].ToString()));
                        if (cus != null)
                        {
                            cus.Txt = "";
                            EtNet_BLL.CustomerManager.updateCustomer(cus);
                        }
                    }
                    else if (model.sort == "04") //公告审批
                    {
                        string sqlano = " jobflowid = " + jfid3;
                        DataTable tblano = EtNet_BLL.AnnouncementInfoManager.GetList(1, sqlano, "id");
                        EtNet_Models.AnnouncementInfo ano = EtNet_BLL.AnnouncementInfoManager.GetModel(int.Parse(tblano.Rows[0]["id"].ToString()));
                        if (ano != null)
                        {
                            ano.txt = "";
                            EtNet_BLL.AnnouncementInfoManager.Update(ano);
                        }
                    }
                    else if (model.sort == "05") //付款审核
                    {
                    }

                    if (EtNet_BLL.JobFlowManager.Update(model))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "success", "<script>alert('撤销成功')</script>", false);
                    }
                    break;
            }
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        protected void ibtnAuditSerch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadRptjobflowData();
            ShowTxt();
        }


        /// <summary>
        /// 重置查询条件
        /// </summary>
        protected void ibtnAuditReset_Click(object sender, ImageClickEventArgs e)
        {
            this.hidsort.Value = "";
            this.iptnumber.Value = "";
            this.selauditstatus.SelectedIndex = 0;
            this.ddlpeople.SelectedIndex = 0;
            Session["query"] = "";
            ModifyQueryBuilder();
            LoadRptjobflowData();
        }

        /// <summary>
        /// 查看订单的审批情况
        /// </summary>
        /// <param name="jfid"></param>
        private void SearchOrder(int jfid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (model == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "search", "<script>alert('查看失败,该订单申请已经删除')</sciprt>", false);
            }
            else
            {

                DataTable tbl = EtNet_BLL.To_OrderInfoManager.GetLists(" jobflowID=" + jfid.ToString());
                if (HttpContext.Current.Request.QueryString["page"] != null)
                {
                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                    Response.Redirect("../Order/AdutiDetial.aspx?pageindex=" + page + "&id=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh");//参数sqsh判断当前所跳转到预览界面的是申请还是审核

                }
                else
                Response.Redirect("../Order/AdutiDetial.aspx?id=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh"); //sqsh来判断到预览界面是从申请进去的，还是审核进去的
            }
        }

        /// <summary>
        /// 查看报销单的审批情况
        /// </summary>
        /// <param name="jfid">工作流的id值</param>
        private void SearchReimbursement(int jfid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            int login = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            string str = "";
            if (model == null)
            {
                str = "<script>alert('查看失败,该报销申请单已删除')</script>";
            }
            else
            {
                if (HttpContext.Current.Request.QueryString["page"] != null)
                {
                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                    Response.Redirect("ReimbursedForm/SearchReimbursedForm.aspx?pageindex=" + page + "&id=" + jfid + "&sqsh=sh");//参数sqsh判断当前所跳转到预览界面的是申请还是审核

                }
                else
                Response.Redirect("ReimbursedForm/SearchReimbursedForm.aspx?id=" + jfid + "&sqsh=sh");//参数sqsh判断当前所跳转到预览界面的是申请还是审核
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "search", str, false);
        }

        /// <summary>
        /// 查看付款申请单的审批情况
        /// </summary>
        /// <param name="jfid"></param>
        private void SearchPayment(int jfid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (model == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "search", "<script>alert('查看失败,该保单申请已经删除')</sciprt>", false);
            }
            else
            {
                EtNet_BLL.To_PaymentManager manager = new EtNet_BLL.To_PaymentManager();
                DataTable tbl = manager.GetList(" jobFlowID=" + jfid.ToString());
                if (HttpContext.Current.Request.QueryString["page"] != null)
                {
                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                    Response.Redirect("../Financial/PaymentPreview.aspx?pageindex=" + page + "&payid=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh");//参数sqsh判断当前所跳转到预览界面的是申请还是审核

                }
                else
                Response.Redirect("../Financial/PaymentPreview.aspx?payid=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh"); //sqsh来判断预览界面是从申请进去的，还是审核进去的
            }
        }

        /// <summary>
        /// 查看客户申请单
        /// </summary>
        /// <param name="jfid"></param>
        private void SearchCus(int jfid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (model == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "search", "<script>alert('查看失败,该客户申请已经删除')</sciprt>", false);
            }
            else
            {
                DataTable tbl = EtNet_BLL.CustomerManager.GetList(" jobflowid=" + jfid.ToString());

                if (HttpContext.Current.Request.QueryString["page"] != null)
                {
                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                    Response.Redirect("../CusInfo/CusDetial.aspx?pageindex=" + page + "&id=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh");//参数sqsh判断当前所跳转到预览界面的是申请还是审核

                }
                else
                Response.Redirect("../CusInfo/CusDetial.aspx?id=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh"); //sqsh来判断预览界面是从申请进去的，还是审核进去的
            }
        }

        /// <summary>
        /// 查看公告申请单
        /// </summary>
        /// <param name="jfid"></param>
        private void SearchAnnoun(int jfid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (model == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "search", "<script>alert('查看失败,该公告已经删除')</sciprt>", false);
            }
            else
            {
                DataTable tbl = EtNet_BLL.AnnouncementInfoManager.GetList(" jobflowid=" + jfid.ToString());

                if (HttpContext.Current.Request.QueryString["page"] != null)
                {
                    int page = int.Parse(HttpContext.Current.Request.QueryString["page"]);
                    Response.Redirect("../Announcement/AnnouncementDetialFirm.aspx?pageindex=" + page + "&id=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh");//参数sqsh判断当前所跳转到预览界面的是申请还是审核

                }
                else
                Response.Redirect("../Announcement/AnnouncementDetialFirm.aspx?id=" + tbl.Rows[0]["id"].ToString() + "&sqsh=sh");//sqsh来判断预览界面是从申请进去的，还是审核进去的
            }
        }

        private void Print(string id)
        {
            ClientScript.RegisterStartupScript(pages.GetType(), "print", string.Format("printForm(\"{0}\");", id), true);
        }

        /// <summary>
        /// 判断是否能够撤销
        /// </summary>
        /// <param name="jfid"></param>
        public bool isRefresh(string jfid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(int.Parse(jfid));
            if (((EtNet_Models.LoginInfo)Session["login"]).Loginid == "admin")
            {
                return true;//0419,增加查看权限，原发起人发起的审批，admin有撤销功能
            }
            else
            {
                if (model.auditstatus == "04")
                {
                    if (model.sort == "05" || model.sort == "02" || model.sort == "01") //只有客户审核和订单审核,或者报销审核的才能查看
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
            }
        }
    }
}