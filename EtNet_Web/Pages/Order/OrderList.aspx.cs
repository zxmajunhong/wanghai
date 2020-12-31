using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using EtNet_BLL.DataPage;
using messageBLL = EtNet_BLL.InformationManager;
using System.Data;
using System.Text;

namespace EtNet_Web.Pages.Order
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryBuilder();
                PageSymbolNum();
                OrderListBind();
                BindApprovalProcess();
                BindOperator();
                BindAuditStatus();
            }
        }


        /// <summary>
        /// 绑定线路
        /// </summary>
        public void BindApprovalProcess()
        {
            ddlLine.Items.Clear();

            IList<Tb_line> typelist = Tb_lineManager.getTb_lineAll();
            for (int i = 0; i < typelist.Count; i++)
            {
                ListItem list = new ListItem(typelist[i].Line.ToString(), typelist[i].Id.ToString());
                ddlLine.Items.Add(list);
            }
            ListItem ltem = new ListItem("选择线路", "-1");//添加第一行默认值
            ddlLine.Items.Insert(0, ltem);//添加第一行默认值

        }

        /// <summary>
        /// 绑定操作员
        /// </summary>
        public void BindOperator()
        {
            ddloperator.Items.Clear();
            ddloperator.Items.Add(new ListItem("——请选择——", "0"));
            IList<LoginInfo> list = LoginInfoManager.getLoginInfoAll();
            foreach (LoginInfo l in list)
            {
                ListItem adItem = new ListItem();
                adItem.Text = l.Cname;
                adItem.Value = l.Id.ToString();
                ddloperator.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 绑定结算状态
        /// </summary>
        public void BindAuditStatus()
        {
            ddlaudtistatus.Items.Clear();
            ddlaudtistatus.Items.Add(new ListItem("——请选择——", "0"));
            DataTable dt = JobAuditStatusManager.GetList("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem adItem = new ListItem();
                adItem.Text = dt.Rows[i]["txt"].ToString();
                adItem.Value = dt.Rows[i]["num"].ToString();
                ddlaudtistatus.Items.Add(adItem);
            }
        }

        private void PageSymbolNum()
        {
            if (Session["PageNum"] == null)
            {
                Session["PageNum"] = "";
            }
            if (Session["PageNum"].ToString() != "013")
            {
                Session["PageNum"] = "013";
                Session["query"] = "";
            }
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
        ///  订单列表
        /// </summary>
        private void OrderListBind()
        {
            string sqlstr = this.checkfile.Checked ? " " : " and fileStatus=0 ";
            sqlstr += Session["query"].ToString();
            LoginInfo login = (LoginInfo)Session["login"];
            string ids = LoginDataLimitManager.GetLimit(login.Id);
            if (string.IsNullOrEmpty(ids))
                sqlstr += " and (markid = " + login.Id + " or inputerId= " + login.Id + ") ";
            else
                sqlstr += " and (inputerId in (" + ids + ") or markid= " + login.Id + ") ";//0419修改，将查看数据权限更改为可查看操作员数据
            //sqlstr += " or inputerID = " + login.Id; //操作员也能看到其对应的订单信息

            SearchPageSet sps = SearchPageSetManager.getSearchPageSetByLoginId(login.Id, 013);
            Data data = new Data();
            AspNetPager1.RecordCount = data.GetCount("ViewOrder", sqlstr);
            if (sps == null)
            {
                AspNetPager1.NumericButtonCount = 10;
                AspNetPager1.PageSize = 10;
            }
            else
            {
                AspNetPager1.NumericButtonCount = sps.Pagecount;
                AspNetPager1.PageSize = sps.Pageitem;

            }
            DataTable dt = data.GetList("ViewOrder", "makerTime", "desc", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, sqlstr);
            cuslist.DataSource = dt;
            cuslist.DataBind();
            LoadZtreeData();
        }

        /// <summary>
        /// 分页改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            OrderListBind();
        }

        //树形控件
        public string result = "";
        public string LoadZtreeData()
        {
            result += "[{id:999, pId: 999, name:'全部订单" + "', icon:'../../Images/public/bfolder.gif', open: true },";
            result += "{id:1, pId: 999, name:'常规订单" + "',icon:'../../Images/public/folder.gif'},";
            result += "{id:2, pId: 999, name:'非常规订单" + "',icon:'../../Images/public/folder.gif' }]";
            return result;

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

        /// <summary>
        /// 验证能否操作
        /// </summary>
        /// <param name="makerid"></param>
        /// <param name="inputerid"></param>
        /// <returns></returns>
        public bool IsCanOperation(object makerid, object inputerid)
        {
            LoginInfo login = Session["login"] as LoginInfo;
            if (login != null)
            {
                //如果是管理员可以操作
                if ("1".Equals(login.Id))
                    return true;
                //如果是制单员可以操作
                else if (makerid.Equals(login.Id))
                    return true;
                //如果是操作员可以操作
                else if (inputerid.Equals(login.Id))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 验证是否能够编辑
        /// </summary>
        /// <param name="makerid"></param>
        /// <param name="inputerid"></param>
        /// <returns></returns>
        public bool IsCanEdit(object makerid, object inputerid)
        {
            LoginInfo login = Session["login"] as LoginInfo;
            LoginOperationLimit limit = LoginOperationLimitManager.getLoginOperationLimitByType("1");
            if (limit != null)
            {
                string[] limits = limit.LimitIds.Split(',');
                if (login != null)
                {
                    //管理员可以编辑
                    if (limits.Contains(login.Id.ToString()))
                        return true;
                    else if (makerid.Equals(login.Id))
                        return true;
                    else if (inputerid.Equals(login.Id))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            OrderListBind();
        }

        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            StringBuilder sqlstr = new StringBuilder();

            int id = 999;
            if (hidsort.Value.Trim() != "")
            {
                int.TryParse(hidsort.Value.Trim(), out id);
                if (id != 999)
                {
                    sqlstr.AppendFormat(" and orderType = " + id);
                }
            }

            if (this.ddlLine.SelectedValue != "-1")
            {
                sqlstr.AppendFormat(" and tour = " + this.ddlLine.SelectedValue);
            }

            if (this.txtNature.Value != "")
            {
                sqlstr.AppendFormat(" and natrue like '%" + this.txtNature.Value + "%'");
            }

            if (this.txtOrderNum.Value != "")
            {
                sqlstr.AppendFormat(" and orderNum like '%" + this.txtOrderNum.Value + "%'");
            }
            if (this.txtTourRemark.Value != "")
            {
                sqlstr.Append(" and tourRemark like '%" + this.txtTourRemark.Value + "%'");
            }
            if (this.ddloperator.SelectedIndex != 0)
            {
                sqlstr.Append(" and inputerID=" + this.ddloperator.SelectedValue);
            }
            if (this.ddlsavestatus.SelectedIndex != 0)
            {
                sqlstr.Append(" and savestatus = '" + this.ddlsavestatus.SelectedValue + "'");
            }
            if (this.ddlaudtistatus.SelectedIndex != 0)
            {
                sqlstr.Append(" and auditstatus = '" + this.ddlaudtistatus.SelectedValue + "'");
            }
            if (ddlRequestDate.SelectedValue.Trim() != "-1")
            {
                if (hidDateValue.Value.Trim() != string.Empty)
                {
                    string[] list = hidDateValue.Value.Trim().Split(',');

                    if (list[0].Trim() != "" && list[1].Trim() != "")
                    {
                        sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime <= '{1}' ) ", list[0].Trim(), list[1].Trim());
                    }
                    else if (list[0].Trim() != "" && list[1].Trim() == "")
                    {
                        sqlstr.AppendFormat(" AND outTime >= '{0}' ", list[0].Trim());
                    }
                    else
                    {
                        sqlstr.AppendFormat(" AND outTime <= '{0}' ", list[1].Trim());
                    }
                }
                else
                {
                    switch (ddlRequestDate.SelectedValue.Trim())
                    {
                        case "0"://今天
                            sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "1"://今天之前
                            sqlstr.AppendFormat(" AND outTime < '{0}' ", DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "2"://昨天
                            sqlstr.AppendFormat(" AND outTime = '{0}' ", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                            break;
                        case "3"://7天内
                            sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "4"://15天内
                            sqlstr.AppendFormat(" AND ( outTime >= '{0}' AND outTime<= '{1}' ) ", DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                            break;
                        case "5"://指定范围
                            break;
                        default:
                            break;
                    }
                }
            }
            Session["query"] = sqlstr;
        }

        /// <summary>
        /// 重置方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mgbtnreset_Click(object sender, ImageClickEventArgs e)
        {

            ddlRequestDate.SelectedIndex = -1;
            txtNature.Value = "";
            txtOrderNum.Value = "";
            ddlLine.SelectedIndex = -1;
            hidsort.Value = "";
            hidDateValue.Value = "";
            Session["query"] = "";
            txtTourRemark.Value = "";
            ddloperator.SelectedIndex = 0;
            ddlsavestatus.SelectedIndex = 0;
            ddlaudtistatus.SelectedIndex = 0;
            OrderListBind();

        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddOrder.aspx");
        }
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cuslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            To_OrderInfo orderinfo = To_OrderInfoManager.getTo_OrderInfoById(Convert.ToInt32(e.CommandArgument));
            switch (e.CommandName)
            {
                case "Delete":
                    Del(Convert.ToInt32(e.CommandArgument));
                    //To_OrderReimDetialManager.deleteTo_OrderReimDetialByOrderID(Convert.ToInt32(e.CommandArgument));
                    break;
                case "Edit":
                    if (orderinfo != null)
                    {
                        int jobflowid = orderinfo.JobflowID;
                        JobFlow model = JobFlowManager.GetModel(jobflowid);
                        if (model.savestatus == "草稿" && model.auditstatus == "01")
                        {
                            Edit(Convert.ToInt32(e.CommandArgument));
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "edit", "alert('该订单已送审，无法修改，欲修改请先回收');", true);
                        }
                    }
                    break;
                case "Detial":
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirect", "<script>window.open('../../Pages/Order/OrderDetial.aspx?id=" + Convert.ToInt32(e.CommandArgument) + "', '_blank')</script>");
                    break;
                case "Audit":
                    if (orderinfo != null)
                    {
                        int jobflowid = orderinfo.JobflowID;
                        JobFlow model = JobFlowManager.GetModel(jobflowid);
                        if (model == null || model.auditstatus != "01" || model.savestatus == "已提交")
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('订单已删除或订单已经送审或审核员已审核')</script>");
                        }
                        else
                        {
                            To_OrderInfo orderModle = To_OrderInfoManager.getTo_OrderInfoById(Convert.ToInt32(e.CommandArgument));
                            JobFlow jobModel = JobFlowManager.GetModel(orderModle.JobflowID);
                            string ordernum = AuditUpdate("已提交", "01", Convert.ToInt32(e.CommandArgument));
                            CreateApproval(jobModel.ruleid, orderModle.JobflowID);
                            SendMessage(ordernum.ToString(), jobModel.ruleid);
                        }
                    }

                    break;

                case "Refresh":
                    orderinfo = To_OrderInfoManager.getTo_OrderInfoById(Convert.ToInt32(e.CommandArgument));
                    Refresh(orderinfo.JobflowID);
                    break;
                case "File":
                    To_OrderInfoManager.updateFileStatus(1, Convert.ToInt32(e.CommandArgument));
                    break;
                case "delFile":
                    To_OrderInfoManager.updateFileStatus(0, Convert.ToInt32(e.CommandArgument));
                    break;
            }
            OrderListBind();
        }
        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="jfid"></param>
        private void Refresh(int jfid)
        {
            LoginInfo login = Session["login"] as LoginInfo;
            EtNet_Models.JobFlow refreshmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
            if (login.Id.ToString() == "1") //如果是管理员，那么审核通过后也能够回收
            {
                if (refreshmodel != null)
                {
                    string strfresh = " jobflowid = " + jfid;
                    EtNet_BLL.AuditJobFlowManager.Delete(strfresh);
                    refreshmodel.savestatus = "草稿";
                    refreshmodel.auditstatus = "01";
                    refreshmodel.txt = "";

                    if (EtNet_BLL.JobFlowManager.Update(refreshmodel))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "reone", "<script>alert('成功收回')</script>", false);
                    }
                }
            }
            else
            {
                if (refreshmodel != null && (refreshmodel.auditstatus == "01" || refreshmodel.auditstatus == "03"))
                {
                    string strfresh = " jobflowid = " + jfid;
                    EtNet_BLL.AuditJobFlowManager.Delete(strfresh); //删除审核人员的数据，申请单回到草稿状态
                    refreshmodel.savestatus = "草稿";
                    refreshmodel.auditstatus = "01";
                    refreshmodel.txt = "";

                    if (EtNet_BLL.JobFlowManager.Update(refreshmodel))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "reone", "<script>alert('成功收回')</script>", false);
                    }

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "retwo", "<script>alert('回收失败，原因可能审核人员在审核或审核已通过！')</script>", false);
                }
            }
        }


        /// <summary>
        /// 发消息给审核用户
        /// </summary>
        private void SendMessage(string serialNum, int ruleid)
        {
            ApprovalRule rule = ApprovalRuleManager.GetModel(ruleid);

            if (rule.idgourp.Trim() != string.Empty)
            {
                EtNet_Models.Information messageEntity = new EtNet_Models.Information();


                messageEntity.associationid = 0;//此处不需要，默认给一个值  消息分类关联的id值,邮件的id值,文档的id值
                messageEntity.contents = string.Format("编号为{0}的定单需要您审批!", serialNum); //消息提示信息
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
        /// 更新的方法
        /// </summary>
        private string AuditUpdate(string args, string auditstatus, int id)
        {

            To_OrderInfo orderModle = To_OrderInfoManager.getTo_OrderInfoById(id);
            JobFlow jobModel = JobFlowManager.GetModel(orderModle.JobflowID);
            jobModel.savestatus = args;
            jobModel.auditstatus = auditstatus;
            JobFlowManager.Update(jobModel);
            return orderModle.OrderNum;
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
                        model.audittime = DateTime.Now;
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
                        model.audittime = DateTime.Now;
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
        /// 编辑订单
        /// </summary>
        /// <param name="id">订单id</param>
        private void Edit(int id)
        {
            To_OrderInfo orderinfo = To_OrderInfoManager.getTo_OrderInfoById(id);
            if (orderinfo != null)
            {
                int jobflowid = orderinfo.JobflowID;
                JobFlow model = JobFlowManager.GetModel(jobflowid);
                if (model == null || model.auditstatus != "01")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('订单已删除或审核员已审核')</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "redirect", "<script>window.open('../../Pages/Order/UpdateOrder.aspx?id=" + Convert.ToInt32(id) + "', '_blank')</script>");
                    //Response.Redirect("UpdateOrder.aspx?id=" + Convert.ToInt32(id));
                }
            }
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id">订单的id值</param>
        private void Del(int id)
        {
            To_OrderInfo orderinfo = To_OrderInfoManager.getTo_OrderInfoById(id);
            if (orderinfo != null)
            {
                int jobflowid = orderinfo.JobflowID;
                JobFlow model = JobFlowManager.GetModel(jobflowid);

                if (model == null || model.auditstatus != "01")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('订单已删除或审核员已审核')</script>");
                }
                else if (!To_OrderInfoManager.CanDelete(id))
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", "<script>alert('该订单关联过收款或付款或退款或报销，无法删除')</script>");
                }
                else
                {
                    string strdel = " jobflowid=" + jobflowid;
                    AuditJobFlowManager.Delete(strdel);
                    JobFlowManager.Delete(jobflowid);
                    To_OrderInfoManager.deleteTo_OrderInfo(Convert.ToInt32(id));
                    To_OrderCollectDetialManager.deleteTo_OrderCollectDetialByOrderID(Convert.ToInt32(id));
                    To_OrderPayDetialManager.deleteTo_OrderPayDetialByOrderID(Convert.ToInt32(id));
                    To_OrderRefunDetialManager.deleteTo_OrderRefunDetialByOrderID(Convert.ToInt32(id));
                }
            }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        /// <param name="statusid"></param>
        /// <returns></returns>
        public static string AuditsStatus(string statusid)
        {
            string status = JobAuditStatusManager.GetModelByNUM(statusid).txt;

            if (status == "进行中")
            {
                status = "<span style='color:blue'>" + status + "</span>";
            }
            if (status == "被拒绝")
            {
                status = "<span style='color:red'>" + status + "</span>";
            }
            if (status == "已通过")
            {
                status = "<span style='color:green'>" + status + "</span>";
            }
            return status;
        }


        public static string OrderStatus(string status)
        {
            if (status == "草稿")
            {
            }
            else
            {
                status = "<span style='color:blue'>已提交</span>";
            }
            return status;
        }



        public string TourLine(int lineid)
        {
            if (lineid > 0)
            {
                return Tb_lineManager.getTb_lineById(lineid).Line.ToString();
            }
            else
            {
                return "线路出现错误";
            }

        }

        /// <summary>
        /// 订单收款状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string colStatus(string orderId)
        {
            int id = 0;
            int.TryParse(orderId, out id);
            DataTable orderdt = To_OrderCollectDetialManager.getList(id);
            List<string> status = new List<string>();
            for (int i = 0; i < orderdt.Rows.Count; i++)
            {
                status.Add(getStatus(orderdt.Rows[i]["id"].ToString(), orderdt.Rows[i]["money"].ToString()));
            }

            if (status.All<string>(x => x == "0")) //判断是否都为0
            {
                return "<font color='red'>未收款</font>";
            }
            else if (status.All<string>(x => x == "2")) //判断是否都为2
            {
                return "<font color='green'>完成收款</font>";
            }
            else
                return "<font color='blue'>部分收款</font>";
        }

        /// <summary>
        /// 得到收款状态
        /// </summary>
        /// <param name="ordercolid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public string getStatus(string ordercolid, string money)
        {
            To_ClaimDetailManager manager = new To_ClaimDetailManager();
            double hasAmount = manager.GetHasAmount(ordercolid);
            double shouldAmount = 0;
            double.TryParse(money, out shouldAmount);
            if (hasAmount == 0)
            {
                return "0";
            }
            else
            {
                if (shouldAmount > hasAmount)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
        }

        /// <summary>
        /// 得到付款状态
        /// </summary>
        /// <param name="orderpayid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public string getPayStatus(string orderpayid, string money)
        {
            double hasAmount = new To_PaymentDetailManager().GetRealityHasAmount(orderpayid);
            double shouldAmount = 0;
            double.TryParse(money, out shouldAmount);
            if (hasAmount == 0)
                return "0";
            else
            {
                if (shouldAmount > hasAmount)
                    return "1";
                else
                    return "2";
            }
        }

        /// <summary>
        /// 验证是否能够存档
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="fileStatus"></param>
        /// <param name="iscancel"></param>
        /// <returns></returns>
        public bool isCanFile(object orderid, object fileStatus, object iscancel)
        {
            if (iscancel.ToString() == "Y")
                return true;
            else
            {
                int id = 0;
                int.TryParse(orderid.ToString(), out id);
                DataTable ordercollect = To_OrderCollectDetialManager.getList(id);
                DataTable orderpay = To_OrderPayDetialManager.getList(id);
                List<string> collectstatus = new List<string>();
                List<string> paystatus = new List<string>();
                for (int i = 0; i < ordercollect.Rows.Count; i++)
                {
                    collectstatus.Add(ordercollect.Rows[i]["collectStatus"].ToString());
                }
                for (int i = 0; i < orderpay.Rows.Count; i++)
                {
                    paystatus.Add(orderpay.Rows[i]["payStatus"].ToString());
                }
                if ((collectstatus.All<string>(x => x == "完成收款") && paystatus.All<string>(x => x == "完成付款")) && fileStatus.ToString() == "0")
                {
                    return true;
                }
                else
                    return false;
            }
        }

        protected void checkfile_CheckedChanged(object sender, EventArgs e)
        {
            OrderListBind();
        }
    }
}