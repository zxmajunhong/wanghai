using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using messageBLL = EtNet_BLL.InformationManager;
using System.Data;

namespace EtNet_Web.Pages.Order
{
    public partial class AddOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblMadeFrom.Value = LoginInfoManager.getLoginInfoById(((LoginInfo)Session["Login"]).Id).Cname;
                this.lblMadeTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                InitVifify();
                DdlToUserBindData();
                DdlBindInputer();
            }
        }
        /// <summary>
        /// 付款单位代码字段是否填写
        /// </summary>
        private void IsEditCuscode()
        {
            DataTable tbl = GetModuleCoding();
            if (tbl.Rows[0]["usecode"].ToString() == "1") //流水号
            {
                this.txtOrderCode.Disabled = true;
                this.txtshow.InnerHtml = "(自动生成)";
            }
            else
            {
                this.txtshow.InnerHtml = "*";
            }
        }

        /// <summary>
        /// 绑定线路
        /// </summary>
        private void DdlToUserBindData()
        {
            DataTable data = Tb_lineManager.getList("");
            ddlLine.DataTextField = "line";
            ddlLine.DataValueField = "id";
            ddlLine.DataSource = data;
            ddlLine.DataBind();
            ListItem item = new ListItem("选择旅游路线", "-1");
            this.ddlLine.Items.Insert(0, item);
        }

        /// <summary>
        /// 绑定操作人员
        /// </summary>
        private void DdlBindInputer()
        {
            this.ddlInputer.Items.Clear();
            IList<LoginInfo> logins = LoginInfoManager.getLoginInfoAll();
            this.ddlInputer.Items.Add(new ListItem("选择操作人员", "-1"));
            foreach (LoginInfo login in logins)
            {
                ListItem adItem = new ListItem(login.Cname, login.Id.ToString());
                this.ddlInputer.Items.Add(adItem);
            }
        }

        /// <summary>
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = "";
            if (this.DropDownList1.SelectedValue == "1")
            {
                strsql = " num = '00004'";
            }
            else if (this.DropDownList1.SelectedValue == "2")
            {
                strsql = " num = '00005'";
            }
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
        /// 检验是否能成功产生订单名称
        /// </summary>
        /// <param name="cuscode">输入的付款单位代码</param>
        /// <param name="cname">付款单位代码全称</param>
        /// <param name="attachment">>付款单位代码不包含流水号</param>
        /// <param name="txt">流水号</param>
        private bool StrNumbers(string strcuscode, out string cuscode, out string codeformat, out string ordernum)
        {
            bool result = true;
            cuscode = ""; //订单代码全称
            codeformat = ""; //名称，不包含流水号
            ordernum = ""; //流水号

            DataTable tbl = GetModuleCoding(); //自动编码
            string txtformat = tbl.Rows[0]["txtformat"].ToString(); //名称的格式
            string usecode = tbl.Rows[0]["usecode"].ToString(); //是否启用
            int len = int.Parse(tbl.Rows[0]["orderlen"].ToString()); //流水号长度

            DataTable ordertbl = null;
            string strsql = ""; //查询字符窜
            if (usecode == "0")
            {
                if (strcuscode.Trim() != "")
                {
                    //strsql = "  orderNum ='" + strcuscode + "'";
                    //ordertbl = To_OrderInfoManager.getList(strsql);
                    //if (ordertbl.Rows.Count != 0)
                    //{
                    //    result = false;
                    //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败, 付款单位代码已存在!')</script>");
                    //}
                    //else
                    //{
                    cuscode = strcuscode; //付款单位代码全称
                    //}
                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,付款单位代码不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                codeformat = Numbers(txtformat); //编码规格
                LoginInfo login = Session["login"] as LoginInfo;
                string departcode = DepartmentInfoManager.getDepartmentInfoById(login.Departid).AutoCode; //部门自动编码标识符
                string year = DateTime.Parse(this.txtOutDate.Value).Year.ToString(); //出团年份
                strsql = "  YEAR(outTime)= '" + year + "' AND LEN(codenum) =" + len.ToString() + " AND departautocode='" + departcode + "' AND orderType=" + this.DropDownList1.SelectedValue;
                ordertbl = To_OrderInfoManager.GetList(1, strsql, " id desc ");

                if (ordertbl.Rows.Count >= 1)
                {
                    if (ordertbl.Rows[0]["codenum"].ToString() != "")
                    {
                        num = int.Parse(ordertbl.Rows[0]["codenum"].ToString()) + 1; //流水号
                        if (num.ToString().Length > len)
                        {
                            result = false;
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('保存失败,流水号长度不够!')</script>");
                        }

                    }
                }
                ordernum = num.ToString().PadLeft(len, '0'); //流水号
                cuscode = codeformat + ordernum; //付款单位代码全称
            }
            return result;
        }





        /// <summary>
        /// 返回名称,不包含流水号
        /// 根据出团日期来编码订单序号
        /// </summary>
        private string Numbers(string txtformat)
        {
            string result = ""; //返回的名称    
            DateTime outtime = new DateTime();
            DateTime.TryParse(this.txtOutDate.Value, out outtime);
            int lineid = 0;
            int.TryParse(this.ddlLine.SelectedValue, out lineid);
            Tb_line line = Tb_lineManager.getTb_lineById(lineid);
            string linecode = ""; //线路自动编码标识符
            if (line != null)
            {
                linecode = line.AutoCode;
            }
            LoginInfo login = Session["login"] as LoginInfo;
            string departcode = DepartmentInfoManager.getDepartmentInfoById(login.Departid).AutoCode; //部门自动编码标识符
            if (txtformat.Contains("[YYYY]"))
            {
                txtformat = txtformat.Replace("[YYYY]", outtime.ToString("yyyy"));
            }
            if (txtformat.Contains("[YY]"))
            {
                txtformat = txtformat.Replace("[YY]", outtime.ToString("yy"));
            }
            if (txtformat.Contains("[MM]"))
            {
                txtformat = txtformat.Replace("[MM]", outtime.ToString("MM"));
            }
            if (txtformat.Contains("[DD]"))
            {
                txtformat = txtformat.Replace("[DD]", outtime.ToString("dd"));
            }
            if (txtformat.Contains("[XL]"))
            {
                txtformat = txtformat.Replace("[XL]", linecode);
            }
            if (txtformat.Contains("[BM]"))
            {
                txtformat = txtformat.Replace("[BM]", departcode);
            }
            result = txtformat;
            return result;
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            //string factCode = this.factCode.Value.ToString();

            //string factCName = this.cusCName.Value.ToString();

            //string str = "";

            //if (FactoryManager.getSName(factshortname, 0))
            //{
            //    str += "付款单位简称已存在\\n";
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            //    return;
            //}
            //if (FactoryManager.getCName(factCName, 0))
            //{
            //    str += "付款单位全称已存在\\n";
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
            //    return;
            //}
            ImageButton imgbtn = sender as ImageButton;
            AddBase(imgbtn.CommandName);
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
        /// 添加订单信息
        /// </summary>
        private void AddBase(string sort)
        {
            string cuscode = "";  //公司代码全称
            string codeformat = ""; //公司代码，不包含流水号
            string ordernum = "";  //流水号
            if (StrNumbers(this.txtOrderCode.Value, out cuscode, out codeformat, out ordernum))
            {
                int maxid = 0;
                EtNet_Models.JobFlow model = new JobFlow();
                model.attachment = codeformat;
                model.txt = ordernum;
                model.cname = cuscode;
                model.sort = "02"; //订单申请
                model.auditsort = "";

                model.createtime = DateTime.Now; //默认是当前时间
                model.endtime = DateTime.Now;
                model.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id     
                model.ruleid = int.Parse(this.DdlIsVirify.SelectedValue);
                if (sort == "save")
                {
                    model.savestatus = "草稿";
                    model.auditstatus = "01";
                    maxid = EtNet_BLL.JobFlowManager.AddAndGetId(model); //工作流的id值
                }
                else
                {
                    model.savestatus = "已提交";
                    model.auditstatus = "02";
                    maxid = EtNet_BLL.JobFlowManager.AddAndGetId(model); //工作流的id值
                    CreateApproval(int.Parse(this.DdlIsVirify.SelectedValue), maxid);
                    SendMessage(maxid.ToString());
                }


                //基本信息
                EtNet_Models.To_OrderInfo order = new EtNet_Models.To_OrderInfo();
                order.OrderNum = cuscode;
                order.Codeformat = codeformat;
                order.Codenum = ordernum;
                order.JobflowID = Convert.ToInt32(this.DdlIsVirify.SelectedValue);
                order.MakerName = ((LoginInfo)Session["login"]).Cname;
                order.MakerTime = DateTime.Now;
                order.MarkId = ((LoginInfo)Session["login"]).Id;
                order.Natrue = this.ddlnature.SelectedValue; //订单类型
                order.OrderType = this.DropDownList1.SelectedValue;
                order.OutTime = Convert.ToDateTime(this.txtOutDate.Value);
                order.CollectCusID = "";
                order.CollectAmount = Convert.ToDouble(lblCollAmount.Value); //收款金额合计
                order.PayAmount = Convert.ToDouble(lblPayAmount.Value); //付款金额合计
                order.PayCusID = "";
                order.RefundAmount = Convert.ToDouble(lblBackAmount.Value); //退款金额合计
                order.RefundID = "";
                order.ReimAmount = Convert.ToDouble(0);
                order.ReimID = "";
                order.Gross = Convert.ToDouble(lblCollAmount.Value) - Convert.ToDouble(lblPayAmount.Value) + Convert.ToDouble(lblBackAmount.Value); //预计毛利
                order.TeamNum = txtTeamnum.Value;
                order.Tour = this.ddlLine.SelectedValue;
                order.TourRemark = this.txtRemark.Value;
                order.Verify = Convert.ToInt32(this.DdlIsVirify.SelectedValue);
                order.JobflowID = maxid;

                //操作人员
                order.Inputer = ddlInputer.SelectedItem.Text;
                order.InputerID = Convert.ToInt32(ddlInputer.SelectedValue);
                order.InputerTc = order.Gross * LoginInfoManager.getLoginInfoById(order.InputerID).orderRate; //操作员提成金额
                order.Gross = order.Gross - order.InputerTc; //预计毛利还得减掉操作员在该笔订单中所占的提成（毛利*提成系数）

                //部门编码标识符
                DepartmentInfo depart = DepartmentInfoManager.getDepartmentInfoById(((LoginInfo)Session["login"]).Departid);
                if (depart != null)
                    order.DepartAutoCode = depart.AutoCode;
                else
                    order.DepartAutoCode = "";

                //订单是否作废
                order.IsCancel = "N";

                int count = To_OrderInfoManager.addTo_OrderInfo(order);
                if (count > 0)
                {
                    addlink(count);
                    addbank(count);
                    addback(count);
                    if (sort == "save")
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功！');location.href='OrderList.aspx'", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('送审成功！');location.href='OrderList.aspx'", true);

                    }
                }
            }
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
        /// 添加收款单位信息
        /// </summary>
        private void addlink(int orderID)
        {
            string strList = this.hidlink.Value;
            if (strList != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.To_OrderCollectDetial factLink = null;
                if (strList.IndexOf(',') >= 0) { row = strList.Split(','); }
                else { row = new string[1] { strList }; }
                if (row.Count() > 0)
                {

                    for (int i = 0; i < row.Length; i++)
                    {

                        cell = row[i].Split('|');
                        if (cell[0] != "")
                        {
                            factLink = new EtNet_Models.To_OrderCollectDetial();
                            factLink.CustId = Convert.ToInt32(cell[0]); //收款单位id
                            factLink.LinkID = cell[1] == "" ? 0 : Convert.ToInt32(cell[1]); //收款单位营业部id
                            factLink.CusName = cell[2]; //收款单位名称
                            factLink.Salesman = cell[3]; //业务员
                            factLink.Salemanid = LoginInfoManager.getLoginIDByname(cell[3]); //业务员id
                            factLink.DepartName = cell[4]; //营业部名称
                            factLink.LinkName = cell[5]; //联系人
                            if (cell[6] != "") //成人数
                                factLink.AdultNum = Convert.ToInt32(cell[6]);
                            else
                                factLink.AdultNum = 0;
                            if (cell[7] != "") //儿童数
                                factLink.ChildNum = Convert.ToInt32(cell[7]);
                            else
                                factLink.ChildNum = 0;
                            if (cell[8] != "") //陪同
                                factLink.WithNum = Convert.ToInt32(cell[8]);
                            else
                                factLink.WithNum = 0;
                            //factLink.Money = Convert.ToDouble(cell[5]);
                            if (cell[9] == "") //收款金额
                                factLink.Money = 0;
                            else
                                factLink.Money = Convert.ToDouble(cell[9]);
                            factLink.CollectStatus = factLink.Money == 0 ? "完成收款" : cell[10]; //收款状态
                            factLink.Remark = cell[11]; //备注
                            factLink.Orderid = orderID; //订单id
                            To_OrderCollectDetialManager.addTo_OrderCollectDetial(factLink);

                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加付款单位
        /// </summary>
        private void addbank(int orderID)
        {
            string banklist = this.hidbank.Value;
            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.To_OrderPayDetial factbank = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                if (row.Count() > 0)
                {

                    for (int i = 0; i < row.Length; i++)
                    {
                        cell = row[i].Split('|');
                        factbank = new EtNet_Models.To_OrderPayDetial();

                        if (cell[0] != "")
                        {
                            factbank.Factid = Convert.ToInt32(cell[0]); //付款单位id
                            factbank.Orderid = orderID; //订单id
                            factbank.LinkID = cell[1] == "" ? 0 : int.Parse(cell[1]); //联系人信息id
                            factbank.SupName = cell[2]; //付款单位名称
                            factbank.PayType = cell[3]; //付款类别
                            factbank.LinkName = cell[4]; //联系人名称
                            if (cell[5] != "")
                                factbank.PayNum = Convert.ToInt32(cell[5]);
                            factbank.PayChildNum = cell[6] != "" ? Convert.ToInt32(cell[6]) : 0;
                            double money = 0;
                            double.TryParse(cell[7], out money);
                            factbank.Money = money; //付款金额
                            factbank.PayConfirm = cell[8]; //是否做过付款申请
                            factbank.PayAmount = 0;
                            factbank.PayStatus = factbank.Money == 0 ? "完成付款" : cell[9]; //付款支付状态
                            factbank.Remark = cell[10]; //备注

                            To_OrderPayDetialManager.addTo_OrderPayDetial(factbank);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 添加退款单位
        /// </summary>
        private void addback(int orderID)
        {
            string banklist = this.hidback.Value;
            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                EtNet_Models.To_OrderRefunDetial factbank = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                if (row.Count() > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        cell = row[i].Split('|');
                        if (cell[0] != "")
                        {
                            factbank = new EtNet_Models.To_OrderRefunDetial();
                            factbank.Cusid = Convert.ToInt32(cell[0]); //退款单位id
                            factbank.CusName = cell[1]; //退款单位名称
                            if (cell[2] == "") //退款金额
                                factbank.Money = 0;
                            else
                                factbank.Money = Convert.ToDouble(cell[2]);
                            factbank.RefundStatus = factbank.Money == 0 ? "完成退款" : cell[3]; //退款状态
                            factbank.Remark = cell[4]; //备注
                            factbank.Orderid = orderID;
                            To_OrderRefunDetialManager.addTo_OrderRefunDetial(factbank);
                        }
                    }
                }

            }
        }






        ////送审
        //protected void imgbtnaudisend_Click(object sender, ImageClickEventArgs e)
        //{
        //    //string factCode = this.factCode.Value.ToString();
        //    //string factCName = this.cusCName.Value.ToString();

        //    //string str = "";
        //    //if (FactoryManager.getSName(factshortname, 0))
        //    //{
        //    //    str += "付款单位简称已存在\\n";
        //    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
        //    //    return;

        //    //}
        //    //if (FactoryManager.getCName(factCName, 0))
        //    //{
        //    //    str += "付款单位全称已存在\\n";
        //    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + str + "');", true);
        //    //    return;
        //    //}
        //ImageButton imgbtn = sender as ImageButton;
        //AddBase(imgbtn.CommandName);
        //}

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrderList.aspx");
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
        /// 选项变化操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlLine.SelectedValue != "-1")
            {
                string remark = Tb_lineManager.getTb_lineById(Convert.ToInt32(ddlLine.SelectedValue)).LineRemark;
                this.txtRemark.Value = remark;
            }
            else
            {
                this.txtRemark.Value = "";
            }

        }

    }
}