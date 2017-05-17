using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL.DataPage;
using System.Data;
using EtNet_BLL;
using EtNet_Models;


namespace EtNet_Web.Pages.CusInfo
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    Response.Redirect("../../Login.aspx");
                }
                else
                {
                    DdlSales_Load();
                    QueryBuilder();
                    PageSymbolNum();
                    dataBind();

                }

            }
            LoadZtreeData();
        }


        /// <summary>
        /// 绑定
        /// </summary>
        private void dataBind()
        {
            string sqlstr = "";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            //string ids = LoginDataLimitManager.GetLimit(login.Id);
            //if (string.IsNullOrEmpty(ids))
            //{
            //    sqlstr += " and madefrom = " + login.Id;

            //}
            //else
            //{
            //    sqlstr += " and madefrom in (" + ids + "," + login.Id + ")";
            //}


            //sqlstr += " AND (madefrom = " + login.Id + " OR ";
            //sqlstr += " ',' + viewidlist + ',' like " + "'%," + login.Id + ",%' )";

            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 013);
            if (sps == null)
            {
                Data data = new Data();
                DataSet ds = data.DataPage("ViewCustomer", "Id", "*", sqlstr, "Id", true, 10, 15, pages);
                cuslist.DataSource = ds;
                cuslist.DataBind();
            }
            else
            {
                Data data = new Data();
                DataSet ds = data.DataPage("ViewCustomer", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
                cuslist.DataSource = ds;
                cuslist.DataBind();
            }
        }

        public static string ifused(string args)
        {
            return LoginInfoManager.getLoginInfoById(Convert.ToInt32(args)).Cname;
        }

        /// <summary>
        /// 客户等级
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string cuspro(string args)
        {
            if (args == "0")
            {
                return args = "<span style='color:red'>新客户</span>";
            }
            else
            {
                return args = "<span style='color:blue'>老客户</span>";
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
        /// 修改客户资料
        /// </summary>
        /// <param name="id">客户的id值</param>
        private void UpdateCustomer(int id)
        {
            string strsql = " id=" + id;
            //string strfields = " savestatus,auditstatus ";
            //DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList(strfields, strsql);
            //if (tbl.Rows.Count != 1)
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('未能加载该客户资料')</script>", false);
            //}
            //else
            //{
            //    if (tbl.Rows[0]["savestatus"].ToString() == "已提交")
            //    {
            //        if (tbl.Rows[0]["auditstatus"].ToString() == "04")
            //        {
            //            Response.Redirect("UpdateCus.aspx?id=" + id);
            //        }
            //        else if (tbl.Rows[0]["auditstatus"].ToString() == "03")
            //        {
            //            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('修改失败,该客户已被审核员拒绝')</script>", false);
            //        }
            //        else
            //        {
            //            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('修改失败,该客户资料正在审核')</script>", false);
            //        }

            //    }
            //    else if (tbl.Rows[0]["savestatus"].ToString() == "")
            //    {
            //        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('客户资料有缺失导致加载失败')</script>", false);
            //    }
            //    else
            //    {
                    Response.Redirect("UpdateCus.aspx?id=" + id);
            //    }
            //}

        }

        /// <summary>
        ///客户详情
        /// </summary>
        /// <param name="id">客户的id值</param>
        private void DetialCustomer(int id)
        {
            //string strsql = " id=" + id;
            //string strfields = " jobflowcode ";
            //DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList(strfields, strsql);
            //if (tbl.Rows.Count != 1)
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('未能加载该客户资料')</script>", false);
            //}
            //else
            //{
            //    if (tbl.Rows[0]["jobflowcode"].ToString() == "")
            //    {
            //        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "update", "<script>alert('客户资料有缺失导致加载失败')</script>", false);
            //    }
            //    else
            //    {
                    Response.Redirect("CusDetial.aspx?id=" + id + "&sqsh=sq");
            //    }
            //}
        }


        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="id">客户的id值</param>
        private void DelCustomer(int id)
        {
            //string strsql = " id=" + id;
            //string strfields = " jobflowcode ";
            //DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList(strfields, strsql);
            //int count = To_PolicyManager.getTo_PolicyCountByCoutomerID(id.ToString());
            //if (count > 0)
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('该客户有保单数据，不能删除。')", true);
            //    return;
            //}
            //else
            //{
            //    int jfid = int.Parse(tbl.Rows[0]["jobflowcode"].ToString());
            //    EtNet_BLL.AuditJobFlowManager.Delete(" jobflowid=" + jfid);
            //    EtNet_BLL.JobFlowManager.Delete(jfid);
                CustomerManager.deleteCustomer(Convert.ToInt32(id));
            //}

        }



        /// <summary>
        /// 客户送审
        /// </summary>
        /// <param name="id">客户的id值</param>
        private void AuditCustomer(int id)
        {
            string strsql = " id=" + id;
            string strfields = " jobflowcode,savestatus,ruleid ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList(strfields, strsql);
            if (tbl.Rows.Count != 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审失败')</script>");
            }
            else
            {
                if (tbl.Rows[0]["savestatus"].ToString() == "草稿")
                {
                    int jfid = int.Parse(tbl.Rows[0]["jobflowcode"].ToString());
                    EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
                    model.createtime = DateTime.Now; //默认是当前时间
                    model.endtime = DateTime.Now;
                    model.savestatus = "已提交";
                    EtNet_BLL.JobFlowManager.Update(model);
                    CreateApproval(model.ruleid, model.id);
                    SendInformation(model.id, model.ruleid);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审成功')</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('无需送审')</script>");
                }
            }

        }



        /// <summary>
        /// 分享客户资料
        /// </summary>
        /// <param name="id">客户的id值</param>
        private void ShareCustomer(int id)
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];

            string strsql = " id=" + id;
            string strfields = " auditstatus,madefrom,authidlist ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList(strfields, strsql);
            if (tbl.Rows[0]["auditstatus"].ToString() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "share", "<script>alert('客户资料缺失导致无法设置权限')</script>");
            }
            else if (tbl.Rows[0]["auditstatus"].ToString() != "04")
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "share", "<script>alert('客户还未通过审批')</script>");
            }
            else
            {
                string compare = "," + login.Id.ToString() + ",";
                string strlist = tbl.Rows[0]["madefrom"].ToString();
                if (tbl.Rows[0]["authidlist"].ToString() != "")
                {
                    strlist += "," + tbl.Rows[0]["authidlist"].ToString();
                }
                strlist = "," + strlist + ",";
                if (strlist.IndexOf(compare) != -1)
                {
                    string tp = "dt" + DateTime.Now.ToString();
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), tp, "<script> share(" + id.ToString() + ")</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "share", "<script>alert('无此权限')</script>");
                }
            }
        }





        /// <summary>
        /// 回收客户审批资料
        /// </summary>
        /// <param name="jfid">客户的id值</param>
        private void RefreshCus(int id)
        {
            string login = ((EtNet_Models.LoginInfo)Session["login"]).Id.ToString();
            string strsql = " id=" + id;
            string strfields = " madefrom,jobflowcode,auditstatus ";
            DataTable tbl = EtNet_BLL.ViewBLL.ViewCustomerManager.getList(strfields, strsql);
            if (tbl.Rows.Count == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "share", "<script>alert('该客户已删除')</script>");
            }
            else
            {
                string str = "<script>alert('成功收回客户！')</script>";
                if (tbl.Rows[0]["jobflowcode"].ToString() == "")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "share", "<script>alert('客户资料缺失导致无法回收')</script>");
                }
                else if (tbl.Rows[0]["auditstatus"].ToString() == "02" || tbl.Rows[0]["auditstatus"].ToString() == "04")
                {
                    str = "<script>alert('回收失败,只有状态是未开始与被拒绝的客户才能回收')</script>";
                }
                else if (tbl.Rows[0]["madefrom"].ToString() != login)
                {
                    str = "<script>alert('回收失败,无此权限')</script>";
                }
                else
                {
                    int jfid = int.Parse(tbl.Rows[0]["jobflowcode"].ToString());
                    string strfresh = " jobflowid = " + jfid.ToString();
                    EtNet_BLL.AuditJobFlowManager.Delete(strfresh); //删除审核人员的数据

                    EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
                    model.savestatus = "草稿";
                    model.auditstatus = "01";
                    EtNet_BLL.JobFlowManager.Update(model);

                    EtNet_Models.Customer cus = EtNet_BLL.CustomerManager.getCustomerById(id);
                    cus.Txt = "";
                    EtNet_BLL.CustomerManager.updateCustomer(cus);
                }
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "refresh", str, false);
            }
        }





        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                DelCustomer(id);

            }

            if (e.CommandName == "Update")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                UpdateCustomer(id);

            }

            if (e.CommandName == "Detial")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                DetialCustomer(id);
            }
            if (e.CommandName == "Copy")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("CopyCus.aspx?id=" + id);
            }
            if (e.CommandName == "Audit")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                AuditCustomer(id);
            }

            if (e.CommandName == "Share")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                ShareCustomer(id);
            }

            if (e.CommandName == "Refresh")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                RefreshCus(id);
            }


            dataBind();
        }



        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddCus.aspx");
        }







        public string ShowColor(string str)
        {
            string result = "";
            switch (str)
            {
                case "未开始":
                case "被拒绝":
                    result = "<span style='color:Red'>" + str + "</span>";
                    break;

                case "已通过":
                    result = "<span style='color:Green'>" + str + "</span>";
                    break;
                default:
                    result = str;
                    break;
            }
            return result;
        }


        /// <summary>
        /// 保存数据列表
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = "";
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
            if (Session["PageNum"].ToString() != "001")
            {
                Session["PageNum"] = "001";
                Session["query"] = "";
            }
        }

        /// <summary>
        /// 加载业务员选择列表
        /// </summary>
        private void DdlSales_Load()
        {
            this.ddlsalesman.Items.Clear();
            this.ddlsalesman.Items.Add(new ListItem("——请选择——", "0"));
            IList<LoginInfo> list = LoginInfoManager.getLoginInfoAll();
            foreach (LoginInfo sale in list)
            {
                ListItem adItem = new ListItem();
                adItem.Text = sale.Cname;
                adItem.Value = sale.Id.ToString();
                this.ddlsalesman.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string sqlstr = "";
            //string cname = this.cname.Value.ToString().Trim();
            //string caddress = this.caddress.Value.ToString();
            //string clinkname = this.clinkname.Value.ToString();
            //string cshortname = this.cshortname.Value.ToString().Trim();

            ////string ddlsavestatus = this.ddlsavestatus.ToString();
          

            //string sqlstr = "and cusCName like '%" + cname + "%' and cusCAddress like '%" + caddress + "%' and linkName like '%" + clinkname + "%' and cusshortName like '%" + cshortname + "%'";
          
            //if (this.ddlreviewstatus.SelectedValue != "0")
            //{
            //    sqlstr += " AND  auditstutastxt='" + this.ddlreviewstatus.SelectedItem + "'";
            //}
            //if (this.ddlsavestatus.SelectedValue != "0")
            //{
            //    sqlstr += " AND  savestatus='" + this.ddlsavestatus.SelectedItem + "'";
            //}
            if (this.cname.Value.Trim() != string.Empty)
                sqlstr += " and cusCName like '%" + this.cname.Value.Trim() + "%' ";
            if (this.caddress.Value.Trim() != string.Empty)
                sqlstr += " and cusCAddress like '%" + this.caddress.Value.Trim() + "%' ";
            if (this.cshortname.Value.Trim() != string.Empty)
                sqlstr += " and cusshortName like '%" + this.cshortname.Value.Trim() + "%' ";
            if (this.ddlsalesman.SelectedIndex != 0)
                sqlstr += " and cusType = " + this.ddlsalesman.SelectedValue;
          
            Session["query"] = sqlstr;
        }



        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            dataBind();
        }


        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {
            //string sqlstr = "";
            //sqlstr += "";
            //LoginInfo login = (LoginInfo)Session["login"];
            //string ids = LoginDataLimitManager.GetLimit(login.Id);
            //if (string.IsNullOrEmpty(ids))
            //{
            //    sqlstr += " and madefrom = " + login.Id;

            //}
            //else
            //{
            //    sqlstr += " and madefrom in (" + ids + "," + login.Id + ")";
            //}
            //SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 001);
            //if (sps == null)
            //{
            //    Data data = new Data();
            //    DataSet ds = data.DataPage("ViewCustomer", "Id", "*", sqlstr, "Id", true, 5, 5, pages);
            //    cuslist.DataSource = ds;
            //    cuslist.DataBind();
            //}
            //else
            //{
            //    Data data = new Data();
            //    DataSet ds = data.DataPage("ViewCustomer", "Id", "*", sqlstr, "Id", true, sps.Pageitem, sps.Pagecount, pages);
            //    cuslist.DataSource = ds;
            //    cuslist.DataBind();
            //}

            this.cname.Value = "";
            this.caddress.Value = "";
           
            //this.ddlreviewstatus.SelectedValue = "0";
            //this.ddlsavestatus.SelectedValue = "0";
            this.cshortname.Value = "";
            this.ddlsalesman.SelectedIndex = 0;
            Session["query"] = "";
            dataBind();
        }

        /// <summary>
        /// 验证是否能够编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsCanEdit(object id)
        {
            //LoginInfo login = Session["login"] as LoginInfo;
            //if (login != null)
            //{
            //    if (login.Id == 1) //如果是管理员可以编辑
            //        return true;
            //    else
            //        return id.Equals(login.Id);
            //}
            //else
            //    return false;
            return true;
        }


        //判断是否自己的记录
        public bool IsSelf(object id)
        {
            LoginInfo login = Session["login"] as LoginInfo;
            if (login != null)
            {
                return id.Equals(login.Id);
            }
            else
            {
                return false;
            }
        }

        //树形控件
        public string result = "";
        public string LoadZtreeData()
        {
            result += "[{id:999, pId: 999, name:'全部等级" + "', icon:'../../Images/public/bfolder.gif', open: true },";
            result += "{id:0, pId: 999, name:'新客户" + "',icon:'../../Images/public/folder.gif'},";
            result += "{id:1, pId: 999, name:'老客户" + "',icon:'../../Images/public/folder.gif' }]";
            return result;

        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string sqlstr;
            int id = int.Parse(hidsort.Value.Trim());
            if (id == 999)
            {
                sqlstr = "";
            }
            else
            {
                sqlstr = "and cusPro=" + id + "";
            }
            Session["query"] = sqlstr;
            dataBind();
        }


    }
}