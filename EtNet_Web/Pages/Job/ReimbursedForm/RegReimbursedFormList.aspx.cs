using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class RegReimbursedFormList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartData();
                QueryBuilder();
                PageSymbolNum();
                //LoadAuditStatus();
                LoadUserData();
                LoadReimbursementFormData();
                LoadTypeData();
                LoadItemData();
            }
        }

        /// <summary>
        /// 加载项目类别
        /// </summary>
        private void LoadItemData()
        {
            DataTable tbl = EtNet_BLL.AusItemInfoManager.GetList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["itemname"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);
            this.ddlitemType.DataSource = tbl;
            this.ddlitemType.DataTextField = "itemname";
            this.ddlitemType.DataValueField = "itemname";
            this.ddlitemType.DataBind();
        }

        /// <summary>
        /// 加载审批状态
        /// </summary>
        private void LoadAuditStatus()
        {
            DataTable tbl = EtNet_BLL.JobAuditStatusManager.GetList("");
            DataRow row = tbl.NewRow();
            row["num"] = "00";
            row["txt"] = "——请选中——";
            tbl.Rows.InsertAt(row, 0);

            row = tbl.NewRow();
            row["num"] = "-1";
            row["txt"] = "全部状态";
            tbl.Rows.InsertAt(row, 1);

            //this.ddlauditstatus.DataSource = tbl;
            //this.ddlauditstatus.DataTextField = "txt";
            //this.ddlauditstatus.DataValueField = "num";
            //this.ddlauditstatus.DataBind();

        }

        /// <summary>
        /// 加载登录用户数据
        /// </summary>
        private void LoadUserData()
        {
            IList<EtNet_Models.LoginInfo> list = EtNet_BLL.LoginInfoManager.getLoginInfoAll();
            this.ddlpeople.DataSource = list;
            this.ddlpeople.DataTextField = "cname";
            this.ddlpeople.DataValueField = "id";
            this.ddlpeople.DataBind();
            this.ddlpeople.Items.Insert(0, "——请选中——");
        }



        /// <summary>
        /// 检验页面设置记录是否存在,如不存在新建一条记录
        /// </summary>
        private DataTable Exists()
        {
            string strsql = " ownersid = " + ((EtNet_Models.LoginInfo)Session["login"]).Id;
            strsql += " AND pagenum='021'";
            DataTable tbl = EtNet_BLL.SearchPageSetManager.GetList(strsql);
            if (tbl.Rows.Count < 1)
            {
                EtNet_Models.SearchPageSet pageset = new EtNet_Models.SearchPageSet();
                pageset.Ownersid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                pageset.Pagenum = "021";
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
        /// 是否打开筛选栏
        /// </summary>
        private void SiftIsOpen()
        {
            DataTable tbl = Exists();
            if (tbl.Rows[0]["siftfence"].ToString() == "1")
            {
                this.hidsift.Value = "1";
            }
            else
            {
                this.hidsift.Value = "0";
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
            if (Session["PageNum"].ToString() != "021")
            {
                Session["PageNum"] = "021";
                Session["query"] = " AND  auditstatus in('01','02','04') ";
            }
        }


        /// <summary>
        /// 保存数据列表的筛选条件,如页面已切换，清除筛选条件
        /// </summary>
        private void QueryBuilder()
        {
            if (Session["query"] == null)
            {
                Session["query"] = " AND  auditstatus in('01','02','04') ";
            }
        }





        /// <summary>
        /// 修改数据列表筛选条件
        /// </summary>
        private void ModifyQueryBuilder()
        {
            string strsql = "";
            string applydate = " convert(varchar(10),applydate,120) ";
            if (this.tbxnumber.Text != "")
            {
                strsql += " AND  jobflowcname like '%" + this.tbxnumber.Text + "%' ";

            }
            if (this.ddlbelongsort.SelectedIndex != 0)
            {
                strsql += " AND  belongsort=" + this.ddlbelongsort.SelectedValue;
            }
            //if (this.ddlsavestatus.SelectedIndex != 0)
            //{
            //    strsql += " AND  savestatus='" + this.ddlsavestatus.SelectedValue + "'";
            //}
            if (this.ddlpeople.SelectedIndex != 0)
            {
                strsql += " AND  founderid=" + this.ddlpeople.SelectedValue;
            }
            if (this.ddlbelongtype.SelectedIndex != 0)
            {
                strsql += " AND  typename='" + this.ddlbelongtype.SelectedItem + "'";
            }
            if (this.iptmoney.Value != "")
            {
                strsql += " AND  totalmoney like '" + this.iptmoney.Value + "%'";
            }
            //if (this.ddlauditstatus.SelectedIndex != 0)
            //{
            //    if (this.ddlauditstatus.SelectedIndex == 1)
            //    {
            //        strsql += " AND  auditstatus in('01','02','03','04') ";
            //    }
            //    else
            //    {
            //        strsql += " AND  auditstatus='" + this.ddlauditstatus.SelectedValue + "'";
            //    }
            //}

            //strsql += " AND  auditstatus in('01','02','04') ";

            if (this.ddlbxType.SelectedValue != "")
            {
                if (this.ddlbxType.SelectedValue == "1")
                {
                    strsql += " AND  billstatetxt='无票报销'";
                }
                else if (this.ddlbxType.SelectedValue == "2")
                {
                    strsql += " AND  billstatetxt='有票报销'";
                }

            }
            if (this.ddlpayStatus.SelectedValue != "")
            {
                if (this.ddlpayStatus.SelectedValue == "1")
                {
                    strsql += " AND  payStatus='1'";
                }
                else if (this.ddlpayStatus.SelectedValue == "2")
                {
                    strsql += " AND  (payStatus='0' or payStatus is null)";
                }

            }
            if (this.ddlitemType.SelectedIndex != 0)
            {
                strsql += string.Format(" AND itemtype like '%{0}%' ", ddlitemType.SelectedValue.Trim());
            }
            if(this.orderId.Value!="")//0419,增加搜索条件可根据订单序号进行模糊搜索
            {
                string ordernum = "";
                string sql = " orderNum like '%" + this.orderId.Value + "%'";
                DataTable dt = EtNet_BLL.AusOrderInfoManager.GetListBysql(sql);
                if(dt!=null)
                {
                    for (int i = 0; i < dt.Rows.Count;i++ )
                    {
                        if (dt.Rows[i]["jobflowId"].ToString() != "")
                        {
                            ordernum += dt.Rows[i]["jobflowId"].ToString() + ",";
                        }
                    }
                    ordernum = ordernum.TrimEnd(',');

                }
                strsql += " AND  jobflowId in (" + ordernum + ")";
            }
            if (this.hidcdate.Value != "")
            {
                string[] list = this.hidcdate.Value.Split(',');
                if (list[0] != "" && list[1] != "")
                {
                    strsql += " AND  ( " + applydate + " >= '" + list[0] + "' AND  " + applydate + " <= '" + list[1] + "')";
                }
                else if (list[0] != "" && list[1] == "")
                {
                    strsql += " AND " + applydate + " >= '" + list[0] + "'";
                }
                else
                {
                    strsql += " AND " + applydate + " <= '" + list[1] + "'";
                }
            }
            else
            {
                switch (this.ddldate.SelectedValue)
                {
                    case "1":
                        strsql += " AND " + applydate + " = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "2":
                        strsql += " AND " + applydate + " < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                        break;

                    case "3":
                        strsql += " AND " + applydate + " = '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                        break;

                    case "4":
                        strsql += " AND ( " + applydate + " >= '" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
                        strsql += " AND " + applydate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;

                    case "5":
                        strsql += " AND ( " + applydate + " >= '" + DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd") + "'";
                        strsql += " AND " + applydate + " <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' )";
                        break;
                }
            }

            Session["query"] = strsql;
        }


        /// <summary>
        /// 删除服务器上的文件
        /// </summary>
        private void DelFile(int jobflowid)
        {
            string str = " jobflowid = " + jobflowid;
            DataTable tbl = EtNet_BLL.JobFlowFileManager.GetList(str);
            if (tbl.Rows.Count >= 1)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    string strfile = tbl.Rows[i]["fileload"].ToString();
                    File.Delete(Server.MapPath(strfile));
                }

            }

        }


        /// <summary>
        /// 依据不同的审批状态，显示不同颜色
        /// </summary>
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
        /// 显示时间
        /// </summary>
        public string ShowDate(string strdate)
        {
            return Convert.ToDateTime(strdate).ToString("yyyy-MM-dd");

        }


        /// <summary>
        /// 显示金额
        /// </summary>
        public string ShowMoney(string strmoney)
        {
            string result = "";
            result += Decimal.Round(Decimal.Parse(strmoney), 2).ToString();
            return result;
        }


        private void LoadDepartData()
        {
            DataTable tbl = EtNet_BLL.DepartmentInfoManager.GetList("");
            DataRow row = tbl.NewRow();
            row["departid"] = 0;
            row["departcname"] = "——请选中——";

            tbl.Rows.InsertAt(row, 0);
            this.ddlbelongsort.DataSource = tbl;
            this.ddlbelongsort.DataTextField = "departcname";
            this.ddlbelongsort.DataValueField = "departid";

            this.ddlbelongsort.DataBind();

        }


        private void LoadTypeData()
        {
            DataTable tbl = EtNet_BLL.DepartmentInfoManager.GetTypeList("");
            DataRow row = tbl.NewRow();
            row["id"] = 0;
            row["typename"] = "——请选中——";

            tbl.Rows.InsertAt(row, 0);
            this.ddlbelongtype.DataSource = tbl;
            this.ddlbelongtype.DataTextField = "typename";
            this.ddlbelongtype.DataValueField = "id";

            this.ddlbelongtype.DataBind();

        }


        /// <summary>
        /// 编辑报销单
        /// </summary>
        /// <param name="jfid">工作流的id值</param>
        private void EditReimbursement(string args)
        {
            //EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            //int login = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            //string str = "";
            //if (model == null)
            //{
            //    str = "<script>alert('编辑失败,该报销申请已删除')</script>";
            //}
            //else if (model.savestatus != "草稿")
            //{
            //    str = "<script>alert('编辑失败,只有草稿状态才能编辑')</script>";
            //}
            //else if (model.founderid != login)
            //{
            //    str = "<script>alert('编辑失败,无此权限')</script>";
            //}
            //else
            //{
            if (args.Split(',')[3].Trim() == "1") //0 jobflowid , 1 id , 2 regID, 3payStatus支付状态
            {
                ClientScript.RegisterClientScriptBlock(pages.GetType(), "a", "alert(\"已支付登记不能修改\");", true);
                return;
            }
            Response.Redirect("RegReimbursedForm.aspx?id=" + args.Split(',')[0] + "&ausID=" + args.Split(',')[1] + "&regID=" + args.Split(',')[2]);
            //}
            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "edit", str, false);
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
                Response.Redirect("SearchReimbursedForm.aspx?id=" + jfid);
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "search", str, false);
        }



        /// <summary>
        /// 回收报销单
        /// </summary>
        /// <param name="jfid">工作流的id值</param>
        private void RefreshReimbursement(int jfid)
        {

            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            int login = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            string str = "";
            if (model == null)
            {
                str = "<script>alert('回收失败,该报销申请单已删除')</script>";
            }
            else if (model.auditstatus == "02" || model.auditstatus == "04")
            {
                str = "<script>alert('回收失败,只有状态是未开始与被拒绝的单据才能回收')</script>";
            }
            else if (model.founderid != login)
            {
                str = "<script>alert('回收失败,无此权限')</script>";
            }
            else
            {
                string strfresh = " jobflowid = " + jfid;
                EtNet_BLL.AuditJobFlowManager.Delete(strfresh); //删除审批人员的数据

                string id = EtNet_BLL.AusRottenInfoManager.GetList(strfresh).Rows[0]["id"].ToString(); //更具工作流id值获取报销单的id值
                EtNet_Models.AusRottenInfo rotten = EtNet_BLL.AusRottenInfoManager.GetModel(int.Parse(id));
                rotten.txt = "";  //清空审批人员的审核意见
                EtNet_BLL.AusRottenInfoManager.Update(rotten);
                model.savestatus = "草稿";
                model.auditstatus = "01";
                if (EtNet_BLL.JobFlowManager.Update(model))
                {
                    str = "<script>alert('成功收回报销申请单！')</script>";
                }
            }
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "refresh", str, false);

        }




        /// <summary>
        /// 删除报销单
        /// </summary>
        /// <param name="jfid">工作流的id值</param>
        private void DelReimbursement(int jfid)
        {

            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            int login = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            string str = "";
            if (model == null)
            {
                str = "<script>alert('删除失败,报销申请单已删除')</script>";
            }
            else if (model.auditstatus != "01")
            {
                str = "<script>alert('删除失败,审核员已审核')</script>";

            }
            else if (model.founderid != login)
            {
                str = "<script>alert('删除失败,无此权限')</script>";
            }
            else
            {
                string strdel = " jobflowid = " + jfid;
                EtNet_BLL.AuditJobFlowManager.Delete(strdel);
                int id = int.Parse(EtNet_BLL.AusRottenInfoManager.GetList(strdel).Rows[0]["id"].ToString());
                EtNet_BLL.AusRottenInfoManager.Delete(id);
                EtNet_BLL.AusDetialInfoManager.Del(jfid); //删除明细数据
                DelFile(jfid); //删除上传的附件
                EtNet_BLL.JobFlowFileManager.Delete(jfid);
                //删除工作流
                EtNet_BLL.JobFlowManager.Delete(jfid);
                str = "<script>alert('删除成功')</script>";
            }

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "del", str, false);
        }


        /// <summary>
        /// 报销送审
        /// </summary>
        /// <param name="id">工作流的id值</param>
        private void SendAuditReimbursement(int jfid)
        {
            EtNet_Models.JobFlow model = EtNet_BLL.JobFlowManager.GetModel(jfid);
            int login = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            if (model != null)
            {
                if (model.savestatus == "已提交")
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('已经送审')</script>", false);
                }
                else if (model.founderid != login)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('无此权限')</script>", false);
                }
                else
                {
                    model.createtime = DateTime.Now; //默认是当前时间
                    model.endtime = DateTime.Now;
                    model.savestatus = "已提交";
                    EtNet_BLL.JobFlowManager.Update(model);
                    CreateApproval(model.ruleid, model.id);
                    SendInformation(model.id, model.ruleid);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审成功')</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审失败')</script>", false);
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
                informodel.sortid = 4;
                informodel.associationid = jobflowid;
                informodel.contents = "编号为" + model.cname + "的单据需要您审批!";
                informodel.createtime = DateTime.Now;
                informodel.sendtime = DateTime.Now;
                informodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                if (EtNet_BLL.InformationManager.Add(informodel))
                {
                    int maxid = EtNet_BLL.InformationManager.GetMaxId();
                    EtNet_Models.InformationNotice infnotic = null;
                    for (int j = 0; j < list.Length; j++)
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
        ///  创建审批序列
        /// </summary>
        ///<param name="ruleid">审批规则id值</param>
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






        protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "edit":
                    string args = e.CommandArgument.ToString();
                    EditReimbursement(args);
                    break;

                case "cancel":
                    string regID = e.CommandArgument.ToString().Trim();
                    EtNet_BLL.RegReimbursementManager bReg = new EtNet_BLL.RegReimbursementManager();
                    bReg.UpdatePayStatus(0, regID);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "cancel", "alert(\"撤销成功\");", true);
                    break;

                case "search":
                    string arg = e.CommandArgument.ToString();
                    Response.Redirect("RegReimbursedForm.aspx?id=" + arg.Split(',')[0] + "&ausID=" + arg.Split(',')[1] + "&regID=" + arg.Split(',')[2] + "&pay=" + arg.Split(',')[3]);
                    break;

            }
            LoadReimbursementFormData();

        }


        /// <summary>
        /// 查询显示报销单的数据
        /// </summary>
        private void LoadReimbursementFormData()
        {
            this.pages.Visible = true;
            DataTable tbl = Exists();
            string str = "";
            int login = ((EtNet_Models.LoginInfo)Session["login"]).Id;
            string strlist = EtNet_BLL.LoginDataLimitManager.GetLimit(login);
            if (strlist == null || strlist.Trim() == "")
            {
                str = " AND founderid in(" + login + ")";
            }
            else
            {
                str = " AND founderid in(" + login + "," + strlist + ")";
            }

            str += " AND  auditstatus='04' ";
            str += Session["query"].ToString();
            int pitem = int.Parse(tbl.Rows[0]["pageitem"].ToString());
            int pcount = int.Parse(tbl.Rows[0]["pagecount"].ToString());
            EtNet_BLL.DataPage.Data data = new EtNet_BLL.DataPage.Data();
            DataSet set = data.DataPage("View_RegReimbursement", "id", "*", str, "id", true, pitem, pcount, pages);
            this.rptdata.DataSource = set;
            this.rptdata.DataBind();

        }


        /// <summary>
        /// 查询报销单
        /// </summary>
        protected void ibtnsearchjob_Click(object sender, ImageClickEventArgs e)
        {
            ModifyQueryBuilder();
            LoadReimbursementFormData();
        }


        /// <summary>
        /// 重置查询条件
        /// </summary> 
        protected void ibtnjobreset_Click(object sender, ImageClickEventArgs e)
        {
            this.tbxnumber.Text = "";
            //this.ddlauditstatus.SelectedIndex = 0;
            this.ddlbelongsort.SelectedIndex = 0;
            this.ddlpeople.SelectedIndex = 0;
            //this.ddlsavestatus.SelectedIndex = 0;
            this.ddlbxType.SelectedIndex = 0;
            this.ddlpayStatus.SelectedIndex = 0;
            this.ddlbelongtype.SelectedIndex = 0;
            this.ddldate.SelectedIndex = 0;
            this.hidcdate.Value = "";
            this.iptmoney.Value = "";
            Session["query"] = " AND  auditstatus in('01','02','04') ";
            LoadReimbursementFormData();
        }

        //判断支付状态显示撤销或编辑按钮
        public static bool Edit(string pay)
        {
            if (pay == "1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //判断支付状态显示撤销或编辑按钮
        public static bool Back(string pay)
        {
            if (pay == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}