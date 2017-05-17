using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using EtNet_BLL;

namespace EtNet_Web.Pages.Job.ReimbursedForm
{
    public partial class ModifyReimbursedForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ReadAuthority();
            }
        }

        /// <summary>
        /// 判断进入修改界面是通过报销管理还是消息提示或主页，如是消息提示或主页判断是否符合修改所需的条件
        /// </summary>
        private void ReadAuthority()
        {
            if (Request.QueryString["login"] != null)
            {
                string str = "  founderid=" + Request.QueryString["login"] + " AND id=" + Request.QueryString["id"];
                str += " AND  savestatus='草稿' AND  auditstatus  in('01')";
                DataTable tbl = EtNet_BLL.JobFlowManager.GetList(str);
                if (tbl.Rows.Count < 1)
                {
                    Response.Redirect("../Error.aspx?error=1");
                }
                else
                {
                    LoadRule();
                    LoadOriginalData();
                    LoadDetialData();
                    LoadOrderDetail();
                    LoadFile();
                }
            }
            else
            {
                LoadRule();
                LoadOriginalData();
                LoadDetialData();
                LoadOrderDetail();
                LoadFile();
            }

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

        /// <summary>
        ///加载报销单的数据
        /// </summary>
        private void LoadOriginalData()
        {

            int id = int.Parse(Request.QueryString["id"]); //获取工作流的id值
            string Sqlstr = " jobflowid =" + id.ToString();
            DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(Sqlstr);
            if (tbl.Rows.Count == 1)
            {
                this.iptnumbers.Value = tbl.Rows[0]["jobflowcname"].ToString(); //报销单号
                this.lblapplydate.Text = DateTime.Now.ToString("yyyy-MM-dd"); //报销日期
                this.lblcanme.Text = tbl.Rows[0]["applycantcname"].ToString(); //填单人员
                this.iptremark.Value = tbl.Rows[0]["remark"].ToString(); //备注
                //账户信息
                this.txtbanker.Value = tbl.Rows[0]["banker"].ToString();
                this.txtbankname.Value = tbl.Rows[0]["bankname"].ToString();
                this.txtbanknum.Value = tbl.Rows[0]["banknum"].ToString();
                //this.ddlbillstate.SelectedValue = tbl.Rows[0]["billstatecode"].ToString(); //报销类别（现在隐藏该功能，默认都是1，都是有票报销）
                int ruleid = int.Parse(tbl.Rows[0]["ruleid"].ToString());
                this.ddlrule.SelectedValue = ruleid.ToString(); //得到审核规则
                LoadAuditImg(ruleid);

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

        /// <summary>
        /// 加载订单明细数据
        /// </summary>
        private void LoadOrderDetail()
        {
            string jbid = Request.QueryString["id"];
            DataTable dt = EtNet_BLL.AusOrderInfoManager.GetList(jbid);
            rpOrderlist.DataSource = dt;
            rpOrderlist.DataBind();
        }


        /// <summary>
        /// 加载报销明细
        /// </summary>
        private void LoadDetialData()
        {

            string jbid = Request.QueryString["id"]; //获取工作流的id值
            DataTable tbl = EtNet_BLL.AusDetialInfoManager.GetLists(jbid);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            string strnumeral = "";


            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                if (i == 0)
                {
                    row = this.tblprocess.Rows[1];

                    cell = row.Cells[0];


                    cell.InnerHtml = DateTime.Parse(tbl.Rows[i]["happendate"].ToString()).ToString("yyyy-MM-dd");
                    cell.Attributes.Add("class", "clshdate");

                    cell = row.Cells[1];
                    cell.Attributes.Add("onclick", "document.getElementById('hidausitem').value=$(this).find('input').attr('id'),artDialog.open('AusItem.aspx')");
                    cell.InnerHtml = "<input type='text'  value='" + (string)tbl.Rows[i]["ausname"] + "' id='item1' style='text-align: center' />";
                    this.HidItemID.Value = tbl.Rows[i]["ausname"].ToString();

                    cell = row.Cells[2];
                    cell.Attributes.Add("onclick", "document.getElementById('hidblong').value=$(this).find('input').attr('id'),artDialog.open('BlongDepartment.aspx')");
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["belongsort"] + "' id='blong1' style='text-align: center'/>";
                    this.HidDepartmentID.Value = tbl.Rows[i]["belongsort"].ToString();

                    cell = row.Cells[3];
                    //string str = "";
                    cell.Attributes.Add("onclick", "document.getElementById('hidsaleman').value=$(this).find('input').attr('id');var value = document.getElementById('blong1').value;artDialog.open('Salesman.aspx?depart=' + value)");
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["Salesman"] + "' id='saleman1' style='text-align: center'/>";
                    this.HidSalesman.Value = tbl.Rows[i]["Salesman"].ToString();

                    cell = row.Cells[4];
                    strnumeral = tbl.Rows[i]["billnum"].ToString();
                    cell.InnerHtml = "<input type='text' class='clsdigit' value='" + ShowNumeral(strnumeral) + "' />";

                    cell = row.Cells[5];
                    strnumeral = tbl.Rows[i]["ausmoney"].ToString();
                    cell.InnerHtml = "<input type='text' class='clsmoney' value='" + ShowNumeral(strnumeral) + "' />";




                    cell = row.Cells[6];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' />";
                }
                else
                {


                    row = new HtmlTableRow();

                    cell = new HtmlTableCell();

                    cell.InnerHtml = DateTime.Parse(tbl.Rows[i]["happendate"].ToString()).ToString("yyyy-MM-dd");
                    cell.Attributes.Add("class", "clshdate");
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.Attributes.Add("onclick", "document.getElementById('hidausitem').value=$(this).find('input').attr('id'),artDialog.open('AusItem.aspx')");
                    strnumeral = tbl.Rows[i]["ausname"].ToString();
                    cell.InnerHtml = "<input type='text'  value='" + (string)tbl.Rows[i]["ausname"] + "' id='item" + Convert.ToInt32(Convert.ToInt32(i) + 1) + "' style='text-align: center'/>";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.Attributes.Add("onclick", "document.getElementById('hidblong').value=$(this).find('input').attr('id'),artDialog.open('BlongDepartment.aspx')");
                    strnumeral = tbl.Rows[i]["belongsort"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["belongsort"] + "' id='blong" + Convert.ToInt32(Convert.ToInt32(i) + 1) + "' style='text-align: center'/>";
                    row.Controls.Add(cell);


                    cell = new HtmlTableCell();
                    string departid = "blong" + Convert.ToInt32(Convert.ToInt32(i) + 1);
                    cell.Attributes.Add("onclick", "document.getElementById('hidsaleman').value=$(this).find('input').attr('id');var value = document.getElementById('" + departid + "').value;artDialog.open('Salesman.aspx?depart=' + value)");
                    strnumeral = tbl.Rows[i]["Salesman"].ToString();
                    cell.InnerHtml = "<input type='text' value='" + (string)tbl.Rows[i]["Salesman"] + "' id='saleman" + Convert.ToInt32(Convert.ToInt32(i) + 1) + "' style='text-align: center'/>";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    strnumeral = tbl.Rows[i]["billnum"].ToString();
                    cell.InnerHtml = "<input type='text' class='clsdigit' value='" + ShowNumeral(strnumeral) + "' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    strnumeral = tbl.Rows[i]["ausmoney"].ToString();
                    cell.InnerHtml = "<input type='text' class='clsmoney' value='" + ShowNumeral(strnumeral) + "' />";
                    row.Controls.Add(cell);





                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.Attributes.Add("align", "center");
                    cell.InnerHtml = "<div class='imgdel'>&nbsp;</div>";
                    row.Controls.Add(cell);
                    this.tblprocess.Controls.Add(row);
                }
                this.hiditemrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hidblongrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hidsalemanrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hiddepart.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();

                this.hidausitem.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hidblong.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hidsaleman.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();


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





        /// <summary>
        /// 返回文件显示的图标
        /// </summary>
        private string FileIcon(string path)
        {
            string result = "<img src='../../../Images/public/";
            string[] extend = new string[5] { "txt", "xls", "doc", "ppt", "pic" };
            string suffix = "";
            if (path.Trim() != "" && path.LastIndexOf('.') != -1)
            {
                int start = path.LastIndexOf('.');
                suffix = path.Substring(start + 1).ToLower();
                switch (suffix)
                {
                    case "txt":
                        result += "txtfile.png' />";
                        break;

                    case "xls":
                    case "xlsx":
                        result += "xlsfile.png' />";
                        break;

                    case "doc":
                    case "docx":
                        result += "docfile.png' />";
                        break;

                    case "ppt":
                    case "pptx":
                        result += "pptfile.png' />";
                        break;

                    case "png":
                    case "gif":
                    case "jpg":
                    case "bmp":
                        result += "picfile.png' />";
                        break;
                    default:
                        result += "dftfile.png' />";
                        break;
                }
            }
            else
            {
                result += "dftfile.png' />";
            }
            return result;
        }




        /// <summary>
        /// 加载原有附件的列表
        /// </summary>
        public void LoadFile()
        {

            string strfile = " jobflowid =" + int.Parse(Request.QueryString["id"]); ;
            DataTable tblfile = EtNet_BLL.JobFlowFileManager.GetList(strfile);
            HtmlTableRow filetr = null;
            HtmlTableCell filetd = null;

            for (int i = 0; i < tblfile.Rows.Count; i++)
            {
                filetr = new HtmlTableRow();

                filetd = new HtmlTableCell();
                filetd.InnerHtml = FileIcon(tblfile.Rows[i]["fileload"].ToString());
                filetd.Attributes.Add("style", "text-align:center");
                filetr.Controls.Add(filetd);

                filetd = new HtmlTableCell();
                filetd.InnerHtml = tblfile.Rows[i]["filename"].ToString();
                filetd.Attributes.Add("style", "text-align:center");
                filetr.Controls.Add(filetd);


                filetd = new HtmlTableCell();
                filetd.Attributes.Add("align", "center");
                filetd.InnerHtml = "<div title='删除' id='fd" + tblfile.Rows[i]["id"].ToString() + "' class='clsfiledel'>&nbsp;</div>";
                filetr.Controls.Add(filetd);
                this.originalfile.Controls.Add(filetr);
            }


            //现有附件的数量
            this.iptflienum.Value = tblfile.Rows.Count.ToString();

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
        /// 添加明细
        /// </summary>
        private bool CreateDetial(int maxid)
        {
            EtNet_BLL.AusDetialInfoManager.Del(maxid); //删除原有的报销明细信息
            bool result = true;

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
                    model.belongsort = txt[2] != "" ? txt[2] : "";  //部门
                    model.Salesman = txt[3] != "" ? txt[3] : "";    //报销人员
                    model.billnum = txt[4] != "" ? int.Parse(txt[4]) : 0;   //票据张数 
                    model.ausmoney = txt[5] != "" ? decimal.Parse(txt[5]) : 0;  //报销金额
                    model.remark = txt[6];  //详细说明
                    model.jobflowid = maxid;    //工作流id
                    if (!EtNet_BLL.AusDetialInfoManager.Add(model))
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 增加订单明细信息
        /// </summary>
        /// <param name="maxid"></param>
        private void CreateOrderDetail(int maxid,double lasttotalmoney, double totalmoney)
        {
            EtNet_BLL.AusOrderInfoManager.Del(maxid);

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
                        orderInfo.Gross = orderInfo.Gross + lasttotalmoney - totalmoney;
                        To_OrderInfoManager.updateOrderGross(orderInfo);
                    }
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
            //str[6] = "0";0为没有文件，1为有上传文件
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
        /// 单据是否可修改以及提交单据
        /// </summary>
        private bool IsCanModifyUp()
        {
            string str = "  founderid=" + ((EtNet_Models.LoginInfo)Session["login"]).Id + " AND id=" + Request.QueryString["id"];
            str += " AND  savestatus='草稿' AND  auditstatus  in('01')";
            DataTable tbl = EtNet_BLL.JobFlowManager.GetList(str);
            if (tbl.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        /// <summary>
        /// 提交数据
        /// </summary>
        private void Submit()
        {
            if (IsCanModifyUp())
            {
                string[] strfile = FileUp(Request.Files);
                if (strfile[0] != "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "jobflow", "<script>alert('提交申请失败原因:" + strfile[0] + "！');</script>", false);
                }
                else
                {
                    int jfid = int.Parse(Request.QueryString["id"]); //获取工作流的id值
                    EtNet_Models.JobFlow jobmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
                    jobmodel.createtime = DateTime.Now; //默认是当前时间
                    jobmodel.endtime = DateTime.Now;
                    jobmodel.savestatus = "已提交";
                    jobmodel.ruleid = int.Parse(this.ddlrule.SelectedValue);
                    //判断是否有附件
                    if (strfile[6] == "1")
                    {
                        CreateJobFlowFile(strfile, jfid);
                    }

                    EtNet_BLL.JobFlowManager.Update(jobmodel); //更新工作流

                    string Sqlstr = " jobflowid =" + jfid.ToString();
                    DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(Sqlstr);
                    EtNet_Models.AusRottenInfo rottenmodel = EtNet_BLL.AusRottenInfoManager.GetModel(int.Parse(tbl.Rows[0]["id"].ToString()));
                    double lasttatalmoney = Convert.ToDouble(rottenmodel.totalmoney);
                    rottenmodel.applydate = DateTime.Now;
                    rottenmodel.totalmoney = Decimal.Parse(this.hidmoney.Value);
                    rottenmodel.remark = Server.UrlDecode(this.iptremark.Value);
                    rottenmodel.txt = "";

                    //账户信息
                    rottenmodel.Banker = txtbanker.Value;
                    rottenmodel.BankName = txtbankname.Value;
                    rottenmodel.bankNum = txtbanknum.Value;

                    string[] result = getItemandPerson();
                    rottenmodel.itemtype = result[0];
                    rottenmodel.person = result[1];
                    string item = result[2];
                    rottenmodel.itemtype = item;
                    rottenmodel.person = result[3];
                    if (EtNet_BLL.AusRottenInfoManager.Update(rottenmodel))
                    {
                        CreateDetial(jfid);
                        CreateOrderDetail(jfid, lasttatalmoney, Convert.ToDouble(rottenmodel.totalmoney));
                        int ruleid = int.Parse(this.ddlrule.SelectedValue);
                        CreateApproval(ruleid, jfid);
                        SendInformation(jfid, ruleid);
                        Response.Redirect("ShowReimbursedForm.aspx");
                        this.ibtnSubmit.Visible = this.ibtnReset.Visible = this.ibtnSave.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("../Error.aspx?error=2");
            }
        }




        /// <summary>
        /// 保存数据
        /// </summary>
        private void Save()
        {
            if (IsCanModifyUp())
            {
                string[] strfile = FileUp(Request.Files);
                if (strfile[0] != "")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "jobflow", "<script>alert('草稿保存失败原因:" + strfile[0] + "！');</script>", false);
                }
                else
                {
                    int jfid = int.Parse(Request.QueryString["id"]); //获取工作流的id值
                    EtNet_Models.JobFlow jobmodel = EtNet_BLL.JobFlowManager.GetModel(jfid);
                    jobmodel.createtime = DateTime.Now; //默认是当前时间
                    jobmodel.endtime = DateTime.Now;
                    jobmodel.savestatus = "草稿";
                    jobmodel.ruleid = int.Parse(this.ddlrule.SelectedValue);
                    //判断是否有附件
                    if (strfile[6] == "1")
                    {
                        CreateJobFlowFile(strfile, jfid);
                    }

                    EtNet_BLL.JobFlowManager.Update(jobmodel);
                    EtNet_BLL.AusDetialInfoManager.Del(jfid);

                    string Sqlstr = " jobflowid =" + jfid.ToString();
                    DataTable tbl = EtNet_BLL.ViewBLL.ViewAusRottenInfoManager.getlist(Sqlstr);
                    EtNet_Models.AusRottenInfo rottenmodel = EtNet_BLL.AusRottenInfoManager.GetModel(int.Parse(tbl.Rows[0]["id"].ToString()));
                    double lasttotalmoney = Convert.ToDouble(rottenmodel.totalmoney);
                    rottenmodel.applydate = DateTime.Now;
                    rottenmodel.totalmoney = Decimal.Parse(this.hidmoney.Value);
                    rottenmodel.remark = Server.UrlDecode(this.iptremark.Value);
                    rottenmodel.txt = "";

                    //账户信息
                    rottenmodel.Banker = txtbanker.Value;
                    rottenmodel.BankName = txtbankname.Value;
                    rottenmodel.bankNum = txtbanknum.Value;

                    string[] result = getItemandPerson();
                    rottenmodel.itemtype = result[0];
                    rottenmodel.person = result[1];

                    if (EtNet_BLL.AusRottenInfoManager.Update(rottenmodel)) //如果更新成功
                    {
                        bool create = CreateDetial(jfid);
                        CreateOrderDetail(jfid, lasttotalmoney, Convert.ToDouble(rottenmodel.totalmoney));
                        this.hidjobflow.Value = jfid.ToString(); //得到工作流id
                        //LoadDetialData();
                        this.ibtnSubmit.Visible = this.ibtnReset.Visible = this.ibtnSave.Visible = false;
                        this.savesubmit.Visible = true;
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "a", "alert('修改成功');self.location.href='ShowReimbursedForm.aspx';", true);//
                    }

                }
            }
            else
            {
                Response.Redirect("../Error.aspx?error=2");
            }
        }

        /// <summary>
        /// 得到项目和人员汇总
        /// </summary>
        /// <returns></returns>
        private string[] getItemandPerson()
        {
            string[] str = new string[2]; //0、存储项目类别汇总；1、存储报销人员汇总
            List<string> l = new List<string>();
            List<string> p = new List<string>();
            if (this.hiddetail.Value.Trim() != "")
            {
                string[] list = this.hiddetail.Value.Split(',');
                string[] txt = null;
                for (int i = 0; i < list.Length; i++)
                {
                    txt = list[i].Split('|');
                    if (!l.Contains(txt[1]))
                    {
                        l.Add(txt[1]);
                    }
                    if (!p.Contains(txt[3]))
                    {
                        p.Add(txt[3]);
                    }
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
        /// 重置数据
        /// </summary>
        protected void ibtnReset_Click(object sender, ImageClickEventArgs e)
        {
            this.ddlrule.SelectedIndex = 0;
            //this.ddlaustype.SelectedIndex = 0;
            this.auditpic.InnerHtml = "";
            LoadOriginalData();
            LoadDetialData();
            LoadFile();
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            Save();
        }


        /// <summary>
        /// 提交数据
        /// </summary>
        protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            Submit();
        }

        //返回
        protected void imgbtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ShowReimbursedForm.aspx");
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

    }
}