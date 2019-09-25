using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Globalization;
using System.Text;
using EtNet_BLL;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class AddReimbursedForm : System.Web.UI.Page
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
                    LoadRule();
                    LoadLoginInfo();
                    string orderid = Request.QueryString["orderid"];
                    if (orderid != null)
                    {
                        LoadOrder(orderid);
                    }
                }
            }
        }

        /// <summary>
        /// 加载订单信息（如果是从订单跳转过来的）
        /// </summary>
        /// <param name="orderid"></param>
        private void LoadOrder(string orderid)
        {
            DataTable dt = To_OrderInfoManager.GetLists("id = " + orderid);
            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<tr><td class='del'><a href='javascript:void(0);' onclick='delRow(this);'><img src='../../../images/public/filedelete.gif' /></a></td>");
            strHtml.Append("<td class='orderNum'>" + dt.Rows[0]["orderNum"].ToString() + "</td>");
            strHtml.Append("<td class='orderType'>" + dt.Rows[0]["orderType"].ToString() + "</td>");
            strHtml.Append("<td class='outTime'>" + Convert.ToDateTime(dt.Rows[0]["outTime"]).ToString("yyyy-MM-dd") + "</td>");
            strHtml.Append("<td class='natrue'>" + dt.Rows[0]["natrue"].ToString() + "</td>");
            strHtml.Append("<td class='tour'>" + dt.Rows[0]["line"].ToString() + "</td>");
            strHtml.Append("<td class='orderId' style='display:none' >" + dt.Rows[0]["id"].ToString() + "</td></tr>");
            orderList.InnerHtml = strHtml.ToString();
        }

        /// <summary>
        /// 审核流规则
        /// </summary>
        private void LoadRule()
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            string fields = " id,(sort + '—' + cname  ) as rulename ";
            string strsql = " jobflowsort='01'AND hide='1' AND  ',' + departidlist + ',' like '%," + login.Departid.ToString() + ",%' ";
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


        //private void LoadDepartData()
        //{
        //   DataTable tbl =  EtNet_BLL.DepartmentInfoManager.GetList("");
        //   DataRow row = tbl.NewRow();
        //   row["departid"] =0;
        //   row["departcname"] = "——请选中——";

        //   tbl.Rows.InsertAt(row, 0);
        //   this.ddlbelongsort.DataSource = tbl;
        //   this.ddlbelongsort.DataTextField = "departcname";
        //   this.ddlbelongsort.DataValueField = "departid";

        //   this.ddlbelongsort.DataBind();

        //}




        /// <summary>
        /// 加载登录用户数据
        /// </summary>
        private void LoadLoginInfo()
        {
            EtNet_Models.LoginInfo login = (EtNet_Models.LoginInfo)Session["login"];
            EtNet_Models.DepartmentInfo model = EtNet_BLL.DepartmentInfoManager.getDepartmentInfoById(login.Departid);
            this.lblcanme.Text = login.Cname; //填单人员

            this.blong1.Value = model.Departcname; //默认明细里面的部门名字
            this.saleman1.Value = login.Cname; //默认明细里面的报销人员
            //this.HidDepartmentID.Value = model.Departid.ToString();

            //this.lbldepart.Text = model.Departcname;
            this.lblapplydate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable tbl = GetModuleCoding();
            if (tbl != null)
            {
                if (tbl.Rows[0]["usecode"].ToString() == "1")
                {
                    this.iptnumbers.Attributes.Add("readonly", "readonly");
                    // this.iptnumbers.Disabled = true;
                    this.showauto.InnerHtml = "(自动生成)";
                    this.iptnumbers.Value = getNum();
                }
            }
        }


        /// <summary>
        /// 上传附件，返回上传文件的路径的集合
        /// </summary>
        private string[] FileUp(HttpFileCollection item)
        {
            string[] str = new string[7] { "", "", "", "", "", "", "0" };
            string fileload = ""; //文件的路径
            //str[6] = "0";0为没有文件，1未有上传文件
            int num = 1;
            string saveUrl = "~/UploadFile/Job/";
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
        /// 设置是否自动编码
        /// </summary>
        private DataTable GetModuleCoding()
        {
            string strsql = " num = '00003'";
            DataTable tbl = EtNet_BLL.ModuleCodingInfoManager.GetList(strsql);

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
        /// <param name="number">输入的单据名称</param>
        /// <param name="cname">单据全称</param>
        /// <param name="attachment">单据名称不包含流水号</param>
        /// <param name="txt">单据的流水号</param>
        private bool StrNumbers(string number, out string cname, out string attachment, out string txt)
        {
            bool result = true;
            cname = ""; //单据全称
            attachment = ""; //单据名称，不包含流水号
            txt = ""; //单据的流水号

            DataTable tbl = GetModuleCoding(); //自动编码
            string txtformat = tbl.Rows[0]["txtformat"].ToString(); //单据名称的格式
            string usecode = tbl.Rows[0]["usecode"].ToString(); //单据的流水号
            int len = int.Parse(tbl.Rows[0]["orderlen"].ToString()); //流水号长度


            DataTable jftbl = null;
            string strsql = ""; //查询字符窜
            if (usecode == "0")
            {
                if (number.Trim() != "")
                {
                    strsql = " sort='01' AND cname ='" + number + "'";
                    jftbl = EtNet_BLL.JobFlowManager.GetList(strsql);
                    if (jftbl.Rows.Count != 0)
                    {
                        result = false;
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('添加失败,单号已存在!')</script>");
                    }
                    else
                    {
                        cname = number; //单据全称
                    }
                }
                else
                {
                    result = false;
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('添加失败,单号不能为空!')</script>");
                }
            }
            else
            {
                int num = 1; //默认流水号
                attachment = Numbers(txtformat); //单据名称
                strsql = " sort='01' AND attachment= '" + attachment + "' AND LEN(txt) =" + len.ToString(); //筛选报销申请
                jftbl = EtNet_BLL.JobFlowManager.GetList(1, strsql, " id desc ");
                if (jftbl.Rows.Count >= 1)
                {
                    if (jftbl.Rows[0]["txt"].ToString() != "")
                    {
                        num = int.Parse(jftbl.Rows[0]["txt"].ToString()) + 1; //当前单据的流水号
                        if (num.ToString().Length > len)
                        {
                            result = false;
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "test", "<script>alert('添加失败,流水号长度不够!')</script>");
                        }

                    }
                }
                txt = num.ToString().PadLeft(len, '0'); //单据流水号
                cname = attachment + txt; //单据全称
            }
            return result;
        }



        /// <summary>
        /// 返回单据名称,不包含流水号
        /// </summary>
        private string Numbers(string txtformat)
        {
            string result = ""; //返回的单据名称        
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
        /// 保存附件的路径
        /// </summary>
        /// <param name="filelist">附件的路径的列表</param>
        /// <param name="jobflowid">工作流的id值</param>
        private void CreateJobFlowFile(string[] filelist, int jobflowid)
        {
            EtNet_Models.JobFlowFile model = null;

            for (int i = 1; i < 6; i++)
            {
                if (filelist[i] != "")
                {
                    model = new EtNet_Models.JobFlowFile();
                    model.createtime = DateTime.Now.ToString();
                    model.fileload = filelist[i].Substring(0, filelist[i].IndexOf("|"));
                    model.filesize = int.Parse(filelist[i].Split('|')[1]);
                    model.filename = filelist[i].Split('|')[2];
                    model.jobflowid = jobflowid;
                    EtNet_BLL.JobFlowFileManager.Add(model);
                }
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
        /// 提交数据
        /// </summary>
        private void Submit()
        {
            string[] strfile = FileUp(Request.Files);
            string cname = ""; //单据全称
            string attachment = ""; //单据名称，不包含流水号
            string txt = ""; //单据的流水号
            if (strfile[0] != "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "jobflow", "<script>alert('提交申请失败原因:" + strfile[0] + "！');</script>", false);
                Reset();
            }
            else
            {
                if (StrNumbers(this.iptnumbers.Value, out cname, out attachment, out txt))
                {
                    //创建工作流
                    EtNet_Models.JobFlow jobmodel = new EtNet_Models.JobFlow();
                    jobmodel.attachment = attachment;
                    jobmodel.txt = txt;
                    jobmodel.cname = cname;
                    jobmodel.sort = "01"; //报销申请
                    jobmodel.auditsort = "";
                    jobmodel.auditstatus = "01";
                    jobmodel.createtime = DateTime.Now; //默认是当前时间
                    jobmodel.endtime = DateTime.Now;
                    jobmodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id号
                    jobmodel.savestatus = "已提交";
                    jobmodel.ruleid = int.Parse(this.ddlrule.SelectedValue);
                    int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(jobmodel); //作为工作流id

                    if (strfile[6] == "1")
                    {
                        CreateJobFlowFile(strfile, maxid);
                    }

                    EtNet_Models.AusRottenInfo model = new EtNet_Models.AusRottenInfo();
                    model.applycantid = ((EtNet_Models.LoginInfo)Session["login"]).Id;
                    model.applydate = DateTime.Now;
                    model.jobflowid = maxid; //工作流id
                    model.remark = Server.UrlDecode(this.iptremark.Value); //备注
                    model.totalmoney = decimal.Parse(this.hidmoney.Value); //总金额
                    model.txt = "";  //审批人员填写的字段
                    model.itemtype = "";//首先赋值该申请单的项目类别为空
                    model.billstate = 1;//int.Parse(this.ddlbillstate.SelectedValue); //判断其是有票还是无票的（现在隐藏这个功能，默认都是有票）

                    //收款帐号信息
                    model.Banker = txtbanker.Value;
                    model.BankName = txtbankname.Value;
                    model.bankNum = txtbanknum.Value;

                    string[] result = CreateDetail(maxid);
                    model.itemtype = result[0];
                    model.person = result[1];
                    if (EtNet_BLL.AusRottenInfoManager.Add(model))
                    {
                        AddOrderDetail(maxid, Convert.ToDouble(model.totalmoney));
                        int ruleid = int.Parse(this.ddlrule.SelectedValue); //获得所选择的审批流程
                        CreateApproval(ruleid, maxid);
                        SendInformation(maxid, ruleid);
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "a", "alert('送审成功');self.location.href='ShowReimbursedForm.aspx';", true); //self.location.href='ShowReimbursedForm.aspx';
                        this.ibtnSubmit.Visible = this.ibtnReset.Visible = this.ibtnSave.Visible = false;
                    }
                    else
                    {
                        EtNet_BLL.AusDetialInfoManager.Del(maxid);
                        EtNet_BLL.JobFlowManager.Delete(maxid);
                        EtNet_BLL.JobFlowFileManager.Delete(maxid);
                    }

                }
                else
                {
                    Reset();
                }
            }
        }


        /// <summary>
        /// 保存数据方法
        /// </summary>
        private void Save()
        {
            string[] strfile = FileUp(Request.Files);
            string cname = ""; //单据全称
            string attachment = ""; //单据名称，不包含流水号
            string txt = ""; //单据的流水号


            if (StrNumbers(this.iptnumbers.Value, out cname, out attachment, out txt))
            {

                //创建工作流
                EtNet_Models.JobFlow jobmodel = new EtNet_Models.JobFlow();
                jobmodel.attachment = attachment;
                jobmodel.txt = txt;
                jobmodel.cname = cname;
                jobmodel.sort = "01";     //报销申请的编号
                jobmodel.auditsort = "01";  //审核分类已不用
                jobmodel.auditstatus = "01"; //未开始
                jobmodel.createtime = DateTime.Now; //默认是当前时间
                jobmodel.endtime = DateTime.Now;
                jobmodel.founderid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //登录人员的id号
                jobmodel.savestatus = "草稿";
                jobmodel.ruleid = int.Parse(this.ddlrule.SelectedValue); //得到审批流程
                int maxid = EtNet_BLL.JobFlowManager.AddAndGetId(jobmodel);

                if (strfile[6] == "1")
                {
                    CreateJobFlowFile(strfile, maxid); //保存文件的路径到数据库中
                }
                //新增报销申请数据
                EtNet_Models.AusRottenInfo model = new EtNet_Models.AusRottenInfo();
                model.applycantid = ((EtNet_Models.LoginInfo)Session["login"]).Id; //填单人员的关联id
                model.applydate = DateTime.Now; //填单日期
                model.jobflowid = maxid; //工作流id
                model.remark = Server.UrlDecode(this.iptremark.Value); //备注
                model.totalmoney = decimal.Parse(this.hidmoney.Value); //总金额
                model.txt = "";  //审批人员填写的字段（审批意见）
                model.itemtype = "";//首先赋值该申请单的项目类别为空


                model.billstate = 1;//int.Parse(this.ddlbillstate.SelectedValue); //判断其是有票还是无票的（现在隐藏这个功能，默认都是有票）

                //收款帐号信息
                model.Banker = txtbanker.Value;
                model.BankName = txtbankname.Value;
                model.bankNum = txtbanknum.Value;

                string[] result = CreateDetail(maxid);
                model.itemtype = result[0];
                model.person = result[1];

                if (EtNet_BLL.AusRottenInfoManager.Add(model)) //如果添加成功
                {
                    AddOrderDetail(maxid, Convert.ToDouble(model.totalmoney)); 
                    this.hidjobflow.Value = maxid.ToString(); //得到工作流id
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "a", "alert('保存成功');self.location.href='ShowReimbursedForm.aspx';", true); //self.location.href='ShowReimbursedForm.aspx';
                    //LoadDetialData();
                    this.ibtnSubmit.Visible = this.ibtnReset.Visible = this.ibtnSave.Visible = false;
                    this.savesubmit.Visible = true;
                }
                else
                {
                    EtNet_BLL.AusDetialInfoManager.Del(maxid);
                    EtNet_BLL.JobFlowManager.Delete(maxid);
                    EtNet_BLL.JobFlowFileManager.Delete(maxid);

                }

            }
            else
            {
                Reset();
            }
        }

        /// <summary>
        /// 添加明细
        /// </summary>
        private string[] CreateDetail(int maxid)
        {
            string[] str = new string[2]; //0、存储项目类别汇总；1、存储报销人员汇总
            List<string> l = new List<string>();//存储项目类别汇总
            List<string> p = new List<string>();//存储报销人员汇总
            if (this.hiddetail.Value.Trim() != "")
            {

                string[] list = this.hiddetail.Value.Split(','); //以逗号分隔每一张的数据
                string[] txt = null;
                EtNet_Models.AusDetialInfo model = null;
                for (int i = 0; i < list.Length; i++)
                {
                    txt = list[i].Split('|');
                    model = new EtNet_Models.AusDetialInfo();
                    model.happendate = txt[0] != "" ? DateTime.Parse(txt[0]) : DateTime.Now;
                    model.ausname = txt[1] != "" ? txt[1] : ""; //项目类别
                    if (!l.Contains(model.ausname))
                    {
                        l.Add(model.ausname);
                    }
                    //model.austype = txt[2] != "" ? txt[2] : ""; //发票内容
                    model.belongsort = txt[2] != "" ? txt[2] : "";  //部门
                    model.Salesman = txt[3] != "" ? txt[3] : "";    //报销人员
                    if (!p.Contains(model.Salesman))
                    {
                        p.Add(model.Salesman);
                    }
                    model.billnum = txt[4] != "" ? int.Parse(txt[4]) : 0;   //票据张数 
                    model.ausmoney = txt[5] != "" ? decimal.Parse(txt[5]) : 0;  //报销金额
                    model.remark = txt[6];  //详细说明
                    model.jobflowid = maxid;    //工作流id
                    EtNet_BLL.AusDetialInfoManager.Add(model);
                }

            }
            foreach (string s in l)
            {
                str[0] += s + ";";
            }
            foreach (string s in p)
            {
                str[1] += s + ";";
            }
            return str;
        }

        /// <summary>
        /// 增加订单明细信息
        /// </summary>
        /// <param name="maxid"></param>
        private void AddOrderDetail(int maxid,double totalmoney)
        {
            if (this.hidorderdetail.Value.Trim() != "")
            {
                string[] list = this.hidorderdetail.Value.Trim().TrimEnd(',').Split(',');
                string[] txt = null;
                EtNet_Models.AusOrderInfo model = null;
                for (int i = 0; i < list.Length; i++)
                {
                    txt = list[i].Split('|');
                    model = new EtNet_Models.AusOrderInfo();
                    model.orderId = txt[0] != "" ? int.Parse(txt[0]) : 0; //订单id
                    model.jobflowId = maxid; //工作流id
                    model.orderNum = txt[1]; //订单序号
                    model.orderType = txt[2]; //订单类型
                    model.outTime = txt[3] != "" ? DateTime.Parse(txt[3]) : DateTime.Parse("1900-1-1"); //出团日期
                    model.natrue = txt[4]; //性质
                    model.tour = txt[5]; //路线
                    EtNet_BLL.AusOrderInfoManager.Add(model);

                    EtNet_Models.To_OrderInfo orderInfo = To_OrderInfoManager.getTo_OrderInfoById(model.orderId);
                    if (orderInfo != null)
                    {
                        orderInfo.Gross = orderInfo.Gross - totalmoney;
                        To_OrderInfoManager.updateOrderGross(orderInfo);
                    }
                }

            }
        }


        /// <summary>
        ///重置清空
        /// </summary>
        private void Reset()
        {
            this.ddlrule.SelectedIndex = 0;
            this.auditpic.InnerHtml = "";
            this.hidmoney.Value = "";
            this.hiddetail.Value = "";
            this.iptremark.Value = "";
            Response.Redirect("AddReimbursedForm.aspx");
        }


        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
        {
            Reset();
        }





        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            Submit();


        }

        /// <summary>
        /// 保存后送审
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void savesubmit_Click(object sender, ImageClickEventArgs e)
        {
            int jfid = int.Parse(this.hidjobflow.Value);
            SendAuditReimbursement(jfid);
        }

        //返回
        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            string id = Request.QueryString["page"];
            if (id == "1")
            {
                Response.Redirect("ShowReimbursedForm.aspx");
            }
            if (id == "2")
            {
                Response.Redirect("RegReimbursedFormList.aspx");
            }
        }

        ////新增报销类型
        //protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        //{
        //    EtNet_Models.AusTypeInfo model = new EtNet_Models.AusTypeInfo();
        //    //model.typename = this.iptaddtype.Value;
        //    EtNet_BLL.AusTypeInfoManager.Add(model);
        //    //LoadAusType();
        //}

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            Save();
        }

        /// <summary>
        /// 得到自动编码产生的报销编码
        /// </summary>
        /// <returns></returns>
        private string getNum()
        {
            string cname = "";
            string attachment = "";
            string txt = "";

            DataTable tbl = GetModuleCoding();
            string txtformat = tbl.Rows[0]["txtformat"].ToString();
            string usecode = tbl.Rows[0]["usecode"].ToString();
            int len = int.Parse(tbl.Rows[0]["orderlen"].ToString());

            DataTable jftbl = null;
            int num = 1; //默认流水号
            attachment = Numbers(txtformat); //单据名称
            string strsql = " sort='01' AND attachment= '" + attachment + "' AND LEN(txt) =" + len.ToString(); //筛选报销申请
            jftbl = EtNet_BLL.JobFlowManager.GetList(1, strsql, " id desc ");
            if (jftbl.Rows.Count >= 1)
            {
                if (jftbl.Rows[0]["txt"].ToString() != "")
                {
                    num = int.Parse(jftbl.Rows[0]["txt"].ToString()) + 1;
                    if (num.ToString().Length > len)
                    {
                        return "";
                    }
                }
            }
            txt = num.ToString().PadLeft(len, '0');
            cname = attachment + txt;
            return cname;
        }

        /// <summary>
        /// 加载报销明细
        /// </summary>
        private void LoadDetialData()
        {

            //string jbid = Request.QueryString["id"]; //获取工作流的id值
            if (this.hiddetail.Value.Trim() != "")
            {
                string[] list = this.hiddetail.Value.Split(',');
                string[] txt = null;
                HtmlTableRow row = null;
                HtmlTableCell cell = null;
                string strnumeral = "";


                for (int i = 0; i < list.Length; i++)
                {
                    txt = list[i].Split('|');
                    if (i == 0)
                    {
                        row = this.tblprocess.Rows[2];

                        cell = row.Cells[0];


                        cell.InnerHtml = DateTime.Parse(txt[0]).ToString("yyyy-MM-dd");
                        cell.Attributes.Add("class", "clshdate");

                        cell = row.Cells[1];
                        cell.Attributes.Add("onclick", "document.getElementById('hidausitem').value=$(this).find('input').attr('id'),artDialog.open('AusItem.aspx')");
                        cell.InnerHtml = "<input type='text'  value='" + txt[1] + "' id='item1' style='text-align: center' />";
                        this.HidItemID.Value = txt[1];

                        cell = row.Cells[2];
                        cell.Attributes.Add("onclick", "document.getElementById('hidblong').value=$(this).find('input').attr('id'),artDialog.open('BlongDepartment.aspx')");
                        cell.InnerHtml = "<input type='text' value='" + txt[2] + "' id='blong1' style='text-align: center'/>";
                        this.HidDepartmentID.Value = txt[2];

                        cell = row.Cells[3];
                        cell.Attributes.Add("onclick", "document.getElementById('hidsaleman').value=$(this).find('input').attr('id');var value = document.getElementById('blong1').value;artDialog.open('Salesman.aspx?depart=' + value)");

                        cell.InnerHtml = "<input type='text' value='" + txt[3] + "' id='saleman1' style='text-align: center'/>";
                        this.HidSalesman.Value = txt[3];

                        cell = row.Cells[4];
                        strnumeral = txt[4];
                        cell.InnerHtml = "<input type='text' class='clsdigit' value='" + ShowNumeral(strnumeral) + "' />";

                        cell = row.Cells[5];
                        strnumeral = txt[5];
                        cell.InnerHtml = "<input type='text' class='clsmoney' value='" + ShowNumeral(strnumeral) + "' />";


                        cell = row.Cells[6];
                        cell.InnerHtml = "<input type='text' value='" + txt[6] + "' />";
                    }
                    else
                    {


                        row = new HtmlTableRow();

                        cell = new HtmlTableCell();

                        cell.InnerHtml = DateTime.Parse(txt[0]).ToString("yyyy-MM-dd");
                        cell.Attributes.Add("class", "clshdate");
                        row.Controls.Add(cell);

                        cell = new HtmlTableCell();
                        cell.Attributes.Add("onclick", "document.getElementById('hidausitem').value=$(this).find('input').attr('id'),artDialog.open('AusItem.aspx')");
                        strnumeral = txt[1];
                        cell.InnerHtml = "<input type='text'  value='" + txt[1] + "' id='item" + Convert.ToInt32(Convert.ToInt32(i) + 1) + "' style='text-align: center'/>";
                        row.Controls.Add(cell);

                        cell = new HtmlTableCell();
                        cell.Attributes.Add("onclick", "document.getElementById('hidblong').value=$(this).find('input').attr('id'),artDialog.open('BlongDepartment.aspx')");
                        strnumeral = txt[2];
                        cell.InnerHtml = "<input type='text' value='" + txt[2] + "' id='blong" + Convert.ToInt32(Convert.ToInt32(i) + 1) + "' style='text-align: center'/>";
                        row.Controls.Add(cell);


                        cell = new HtmlTableCell();
                        string departid = "blong" + Convert.ToInt32(Convert.ToInt32(i) + 1);
                        cell.Attributes.Add("onclick", "document.getElementById('hidsaleman').value=$(this).find('input').attr('id');var value = document.getElementById('" + departid + "').value;artDialog.open('Salesman.aspx?depart=' + value)");
                        strnumeral = txt[3];
                        cell.InnerHtml = "<input type='text' value='" + txt[3] + "' id='saleman" + Convert.ToInt32(Convert.ToInt32(i) + 1) + "' style='text-align: center'/>";
                        row.Controls.Add(cell);

                        cell = new HtmlTableCell();
                        strnumeral = txt[4];
                        cell.InnerHtml = "<input type='text' class='clsdigit' value='" + ShowNumeral(strnumeral) + "' />";
                        row.Controls.Add(cell);

                        cell = new HtmlTableCell();
                        strnumeral = txt[5];
                        cell.InnerHtml = "<input type='text' class='clsmoney' value='" + ShowNumeral(strnumeral) + "' />";
                        row.Controls.Add(cell);

                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + txt[6] + "' />";
                        row.Controls.Add(cell);

                        cell = new HtmlTableCell();
                        cell.Attributes.Add("align", "center");
                        cell.InnerHtml = "<div class='imgdel'>&nbsp;</div>";
                        row.Controls.Add(cell);
                        this.tblprocess.Controls.Add(row);
                    }
                    this.hiditemrows.Value = (Convert.ToInt32(list.Length) + 1).ToString();
                    this.hidblongrows.Value = (Convert.ToInt32(list.Length) + 1).ToString();
                    this.hidsalemanrows.Value = (Convert.ToInt32(list.Length) + 1).ToString();

                    this.hidausitem.Value = (Convert.ToInt32(list.Length) + 1).ToString();
                    this.hidblong.Value = (Convert.ToInt32(list.Length) + 1).ToString();
                    this.hidsaleman.Value = (Convert.ToInt32(list.Length) + 1).ToString();

                }
            }

        }

        /// <summary>
        /// 显示票据张数或金额
        /// </summary>
        /// <returns></returns>
        private string ShowNumeral(string strnumeral)
        {
            string result = "";
            result = strnumeral.Replace("0", "");
            result = result.Replace(".", "");
            if (result != "")
            {
                result = Decimal.Round(Decimal.Parse(strnumeral), 2).ToString();
            }
            return result;
        }

        protected string ispay(string data)
        {
            return data;
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
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审成功');self.location.href='ShowReimbursedForm.aspx';</script>", false);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "audit", "<script>alert('送审失败')</script>", false);
            }
        }

        /// <summary>
        /// 加载审批流程图
        /// </summary>
        /// <param name="ruleid"></param>
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
    }
}