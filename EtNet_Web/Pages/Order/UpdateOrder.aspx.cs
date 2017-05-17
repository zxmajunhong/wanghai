using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

namespace EtNet_Web.Pages.Order
{
    public partial class UpdateOrder : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitVifify();
                DdlBindInputer();
                object id = Request.QueryString["id"];
                int rid = 0;
                if (id != null && int.TryParse(id.ToString(), out rid))
                {
                    LoadData(rid);
                }
                else
                {
                    Response.End();
                }
                DdlToUserBindData();
                this.OrderType.Enabled = false;
                this.txtOrderCode.Attributes.Add("readonly", "readonly");
                this.lblMadeFrom.Attributes.Add("readonly", "readonly");
                this.lblMadeTime.Attributes.Add("readonly", "readonly");
                this.hidorderid.Value = rid.ToString();
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
        /// 加载当前订单信息
        /// </summary>
        /// <param name="id"></param>
        private void LoadData(int id)
        {
            To_OrderInfo orderModel = To_OrderInfoManager.getTo_OrderInfoById(id);

            //主表信息
            OrderType.SelectedValue = orderModel.OrderType; //业务类型
            txtOrderCode.Value = orderModel.OrderNum; //订单序号
            txtOutDate.Value = orderModel.OutTime.ToString("yyyy-MM-dd"); // 出团日期
            txtTeamnum.Value = orderModel.TeamNum; //团队总人数
            this.ddlnature.SelectedValue = orderModel.Natrue; //性质
            txtRemark.Value = orderModel.TourRemark; //描述
            ddlLine.SelectedValue = orderModel.Tour; //线路
            lblMadeFrom.Value = orderModel.MakerName; //制单员
            lblMadeTime.Value = orderModel.MakerTime.ToString("yyyy-MM-dd"); //制单日期

            //是否作废
            this.isCancel.Checked = orderModel.IsCancel == "Y" ? true : false;
            this.hidCancel.Value = orderModel.IsCancel == "Y" ? "1" : "0";

            //操作人员
            this.ddlInputer.SelectedValue = orderModel.InputerID.ToString();

            JobFlow jobModel = JobFlowManager.GetModel(orderModel.JobflowID);
            this.DdlIsVirify.SelectedValue = jobModel.ruleid.ToString();

            //加载收款单位明细信息
            LoadCollectDetail(id);
            LoadPayDetial(id);
            LoadRefunDetial(id);
            LoadReimDetial(id);

            LoadAuditImg(jobModel.ruleid);
        }

        /// <summary>
        /// 加载收款单位明细信息
        /// </summary>
        /// <param name="id"></param>
        private void LoadCollectDetail(int id)
        {
            DataTable tbl = To_OrderCollectDetialManager.getList(id);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            decimal moneyAmount = 0;
            decimal outmoney = 0;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string[] result = GetColStatusAndAmount(tbl.Rows[i]["id"].ToString(), tbl.Rows[i]["money"].ToString());
                if (i == 0)
                {
                    row = this.tablelink.Rows[1];

                    //单位id
                    cell = row.Cells[0];
                    cell.Attributes.CssStyle.Add("display", "none");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusId"].ToString() + "' id='cus1' class='clsblurtxt clsedit clscusid' />";
                    //cell.InnerHtml = "<span id='cus1' class='clsedit'>" + tbl.Rows[i]["cusId"].ToString() + "</span>";
                    //营业部id
                    cell = row.Cells[1];
                    cell.Attributes.CssStyle.Add("display", "none");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkid"].ToString() + "' id='colLinkID1' class='clsblurtxt clsedit clscollinkid' />";
                    //单位名称
                    cell = row.Cells[2];
                    if (result[0] == "有")
                    {
                        cell.Attributes.Add("onclick", "alert('已做过收款的信息，无法更改单位')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='cusname1' class='clsblurtxt clsedit cus' style='text-align: center' readonly='readonly' />";
                    }
                    else
                    {
                        cell.Attributes.Add("onclick", "document.getElementById('hidcusvalue').value=$(this).find('input').attr('id');document.getElementById('hidcusid').value=$(this).parent().find('.clscusid').attr('id');getcus('saleman1');");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='cusname1' class='clsblurtxt clsedit cus' style='text-align: center' />";
                    }

                    //业务员
                    cell = row.Cells[3];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["salesman"].ToString() + "' id='saleman1' class='clsblurtxt clsedit' style='text-align: center' readonly='readonly'/>";
                    //营业部名称
                    cell = row.Cells[4];
                    cell.Attributes.Add("onclick", "getcollink('cus1','colLink1','colLinkID1','colLinkName1')");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["departName"].ToString() + "' id='colLink1' class='clsblurtxt clsedit' style='text-align: center' />";

                    //联系人
                    cell = row.Cells[5];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkname"].ToString() + "' id='colLinkName1' class='clsblurtxt clsedit' style='text-align: center' />";

                    //成人数
                    cell = row.Cells[6];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["adultNum"].ToString() + "' class='clsblurtxt clsedit colaut' />";

                    //儿童数
                    cell = row.Cells[7];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["childNum"].ToString() + "' class='clsblurtxt clsedit colchild' />";

                    //陪同
                    cell = row.Cells[8];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["withNum"].ToString() + "' class='clsblurtxt clsedit colwith'/>";

                    if (result[0] == "有")
                    {
                        ////成人数
                        //cell = row.Cells[6];
                        //cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["adultNum"].ToString() + "' class='clsblurtxt clsedit colaut' readonly='readonly' />";

                        ////儿童数
                        //cell = row.Cells[7];
                        //cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["childNum"].ToString() + "' class='clsblurtxt clsedit colchild' readonly='readonly' />";

                        ////陪同
                        //cell = row.Cells[8];
                        //cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["withNum"].ToString() + "' class='clsblurtxt clsedit colwith' readonly='readonly' />";

                        //操作
                        cell = row.Cells[14];
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail coldetailid' />";
                        cell.InnerHtml += "<div title='删除' class='clscoldel' style='float: left; margin-left: 20%'>&nbsp;</div><div title='查看' class='clsimgcollink' style='margin-left: 1px' ></div>";

                    }
                    else
                    {

                        //操作 input 用于存储明细表id
                        cell = row.Cells[14];
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail coldetailid' />";
                        cell.InnerHtml += "<div title='删除' class='clsimgdel' style='float: left; margin-left: 20%'>&nbsp;</div><div title='查看' class='clsimgcollink' style='margin-left: 1px' ></div>";
                    }

                    //金额
                    cell = row.Cells[9];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit colmoney' />";

                    //收款状态
                    cell = row.Cells[10];
                    if (result[1] == "部分收款")
                        cell.InnerHtml = "<input type='text' style='color:Blue' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else if (result[1] == "完成收款")
                        cell.InnerHtml = "<input type='text' style='color:Green' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";

                    //实际收款金额
                    cell = row.Cells[11];
                    cell.InnerHtml = "<input type='text' value='" + result[2] + "' class='clsblurtxt clsedit colhasmoney' readonly='readonly'/>";

                    //剩余收款金额
                    cell = row.Cells[12];
                    double surplus = getSurplus(tbl.Rows[i]["money"].ToString(), result[2]); //得到剩余金额
                    cell.InnerHtml = "<input type='text' value='" + surplus.ToString("F2") + "' class='clsblurtxt clsedit colsymoney' />";

                    //备注
                    cell = row.Cells[13];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' class='clsblurtxt clsedit' />";


                }
                else
                {
                    row = new HtmlTableRow();

                    //隐藏列
                    cell = new HtmlTableCell();
                    cell.Attributes.CssStyle.Add("display", "none");
                    string hidcusid = "cus" + (i + 1).ToString();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusId"].ToString() + "' id='" + hidcusid + "' class='clsblurtxt clsedit clscusid' />";
                    row.Controls.Add(cell);

                    //营业部id
                    cell = new HtmlTableCell();
                    string collinkid = "colLinkID" + (i + 1).ToString();
                    cell.Attributes.CssStyle.Add("display", "none");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkid"].ToString() + "' id='" + collinkid + "' class='clsblurtxt clsedit clscollinkid' />";
                    row.Controls.Add(cell);

                    //单位名称
                    cell = new HtmlTableCell();
                    string cusid = "cusname" + (i + 1).ToString();
                    string salemanid = "saleman" + (i + 1).ToString();
                    string collink = "colLink" + (i + 1).ToString();
                    string collinkname = "colLinkName" + (i + 1).ToString();
                    if (result[0] == "有")
                    {
                        cell.Attributes.Add("onclick", "alert('已做过收款的信息，无法更改单位')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='" + cusid + "' class='clsblurtxt clsedit cus' style='text-align: center' readonly='readonly' />";
                    }
                    else
                    {
                        cell.Attributes.Add("onclick", "document.getElementById('hidcusvalue').value=$(this).find('input').attr('id');document.getElementById('hidcusid').value=$(this).parent().find('.clscusid').attr('id');getcus('" + salemanid + "')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='" + cusid + "' class='clsblurtxt clsedit cus' style='text-align: center' />";
                    }
                    row.Controls.Add(cell);

                    //业务员
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["salesman"].ToString() + "' id='" + salemanid + "' class='clsblurtxt clsedit' style='text-align: center' readonly='readonly'/>";
                    row.Controls.Add(cell);
                    //营业部名称
                    cell = new HtmlTableCell();
                    cell.Attributes.Add("onclick", "getcollink('" + hidcusid + "','" + collink + "','" + collinkid + "','" + collinkname + "')");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["departName"].ToString() + "' id='" + collink + "' class='clsblurtxt clsedit' style='text-align: center' />";
                    row.Controls.Add(cell);

                    //联系人
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkname"].ToString() + "' id='" + collinkname + "' class='clsblurtxt clsedit' style='text-align: center' />";
                    row.Controls.Add(cell);
                    //成人数
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["adultNum"].ToString() + "' class='clsblurtxt clsedit colaut' />";
                    row.Controls.Add(cell);

                    //儿童数
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["childNum"].ToString() + "' class='clsblurtxt clsedit colchild' />";
                    row.Controls.Add(cell);

                    //陪同
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["withNum"].ToString() + "' class='clsblurtxt clsedit colwith' />";
                    row.Controls.Add(cell);

                    //金额
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit colmoney' />";
                    row.Controls.Add(cell);

                    //收款状态
                    cell = new HtmlTableCell();
                    if (result[1] == "部分收款")
                        cell.InnerHtml = "<input type='text' style='color:Blue' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else if (result[1] == "完成收款")
                        cell.InnerHtml = "<input type='text' style='color:Green' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    row.Controls.Add(cell);

                    //实际收款金额
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + result[2] + "' class='clsblurtxt clsedit colhasmoney' readonly='readonly'/>";
                    row.Controls.Add(cell);

                    //剩余收款金额
                    cell = new HtmlTableCell();
                    double symoney = getSurplus(tbl.Rows[i]["money"].ToString(), result[2]); //得到剩余金额
                    cell.InnerHtml = "<input type='text' value='" + symoney.ToString("F2") + "' class='clsblurtxt clsedit colsymoney' />";
                    row.Controls.Add(cell);

                    //备注
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' class='clsblurtxt clsedit' />";
                    row.Controls.Add(cell);

                    //操作
                    cell = new HtmlTableCell();
                    cell.Attributes.Add("align", "center");
                    //input 用于存储明细表的id值
                    if (result[0] == "有")
                    {
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail coldetailid' />";
                        cell.InnerHtml += "<div title='删除' class='clscoldel' style='float: left; margin-left: 20%'>&nbsp;</div><div title='查看' class='clsimgcollink' style='margin-left: 1px' ></div>";
                    }
                    else
                    {
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail coldetailid' />";
                        cell.InnerHtml += "<div title='删除' class='clsimgdel' style='float: left; margin-left: 20%'>&nbsp;</div><div title='查看' class='clsimgcollink' style='margin-left: 1px' ></div>";
                    }
                    row.Controls.Add(cell);

                    this.tablelink.Controls.Add(row);
                }
                decimal.TryParse(tbl.Rows[i]["money"].ToString(), out outmoney);
                moneyAmount += outmoney;

                this.hidcusrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
                this.hidsalemanrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
            }
            this.lblCollAmount.Value = moneyAmount.ToString("F2");
        }

        /// <summary>
        /// 得到收款状态和收款金额
        /// </summary>
        /// <param name="colid">收款信息明细表id</param>
        /// <param name="money">应收金额</param>
        /// <returns></returns>
        private string[] GetColStatusAndAmount(string colid, string money)
        {
            string[] result = new string[3];
            To_ClaimDetailManager claimDetailManager = new To_ClaimDetailManager();
            double hasAmount = claimDetailManager.GetHasAmount(colid);
            DataTable dt = claimDetailManager.GetList(" orderCollectId=" + colid);
            if (dt.Rows.Count > 0) //如果数据大于零表示做过收款
                result[0] = "有";
            else
                result[0] = "无";
            double shouldAmount = 0;
            double.TryParse(money, out shouldAmount);
            if (shouldAmount == 0)
            {
                result[1] = "完成收款";
                result[2] = hasAmount.ToString("F2");
            }
            else
            {
                if (hasAmount == 0)
                {
                    result[1] = "未收款";
                    result[2] = hasAmount.ToString("F2");
                }
                else
                {
                    if (shouldAmount > hasAmount)
                    {
                        result[1] = "部分收款";
                        result[2] = hasAmount.ToString("F2");
                    }
                    else
                    {
                        result[1] = "完成收款";
                        result[2] = hasAmount.ToString("F2");
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 加载付款单位明细信息
        /// </summary>
        /// <param name="id"></param>
        private void LoadPayDetial(int id)
        {
            DataTable tbl = To_OrderPayDetialManager.getList(id);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            decimal moneyAmount = 0;
            decimal outmoney = 0;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string[] result = GetPayStatusAndMoney(tbl.Rows[i]["id"].ToString(), tbl.Rows[i]["money"].ToString());
                if (i == 0)
                {
                    row = this.tablebank.Rows[1];
                    //付款单位id
                    cell = row.Cells[0];
                    cell.Attributes.CssStyle.Add("display", "none");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["factid"].ToString() + "' id='supid1' class='clsblurtxt clsedit clssupid ' />";
                    //cell.InnerHtml = "<span id='supid1' class='clsedit' >" + tbl.Rows[i]["factid"].ToString() + "</span>";
                    //联系人id
                    cell = row.Cells[1];
                    cell.Attributes.CssStyle.Add("display", "none");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkID"].ToString() + "' id='linkID1' class='clsblurtxt clsedit clslinkid' />";
                    //单位名称
                    cell = row.Cells[2];
                    if (result[0] == "有")
                    {
                        cell.Attributes.Add("onclick", "alert('该条记录已经做过付款申请，无法修改单位名称')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["supName"].ToString() + "' id='sup1' class='clsblurtxt clsedit clseditdate sup' style='text-align: center' readonly='readonly' />";
                    }
                    else
                    {
                        cell.Attributes.Add("onclick", "document.getElementById('hidsupvalue').value=$(this).find('input').attr('id');debugger;document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpay('linkID1','payLink1');");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["supName"].ToString() + "' id='sup1' class='clsblurtxt clsedit clseditdate sup' style='text-align: center' />";
                    }


                    //付款类别
                    cell = row.Cells[3];
                    if (result[0] == "有")
                    {
                        cell.Attributes.Add("onclick", "alert('该条记录已经做过付款申请，无法修改付款类别')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payType"].ToString() + "' id='payType1' class='clsblurtxt clsedit payType' style='text-align: center' readonly='readonly' />";
                    }
                    else
                    {
                        cell.Attributes.Add("onclick", "document.getElementById('hidpaytype').value = $(this).find('input').attr('id');document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpaytype();");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payType"].ToString() + "' id='payType1' class='clsblurtxt clsedit payType' style='text-align: center' />";
                    }

                    //联系人
                    cell = row.Cells[4];
                    cell.Attributes.Add("onclick", "getpaylink('supid1','payLink1','linkID1')");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkName"].ToString() + "' id='payLink1' class='clsblurtxt clsedit' style='text-align: center' />";

                    //成人数
                    cell = row.Cells[5];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payNum"].ToString() + "' class='clsblurtxt clsedit payNum' />";

                    //儿童数
                    cell = row.Cells[6];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payChildNum"].ToString() + "' class='clsblurtxt clsedit payNum' />";

                    //金额
                    cell = row.Cells[7];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit clseditdate paymoney' />";

                    //付款申请单
                    cell = row.Cells[8];
                    cell.InnerHtml = "<input type='text' value='" + result[0] + "' class='clsblurtxt clsedit clsagelimit' readonly='readonly'/>";

                    //支付状态
                    cell = row.Cells[9];
                    if (result[1] == "部分支付")
                        cell.InnerHtml = "<input type='text' style='color:Blue' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else if (result[1] == "完成支付")
                        cell.InnerHtml = "<input type='text' style='color:Green' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";

                    //已支付金额
                    cell = row.Cells[10];
                    cell.InnerHtml = "<input type='text' value='" + result[2] + "' class='clsblurtxt clsedit payhasmoney' readonly='readonly' />";
                    //剩余金额
                    cell = row.Cells[11];
                    double symoney = getSurplus(tbl.Rows[i]["money"].ToString(), result[2]);
                    cell.InnerHtml = "<input type='text' value='" + symoney.ToString("F2") + "' class='clsblurtxt clsedit paysymoney' />";

                    //备注
                    cell = row.Cells[12];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' class='clsblurtxt clsedit' />";

                    //操作
                    cell = row.Cells[13]; //input 用于存储明细表id
                    if (result[0] == "有")
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail supdetailid' /><div title='删除' style='float:left;margin-left:20%' class='clsworkimgdel'>&nbsp;</div><div title='查看' class='clsimglink' style='margin-left:1px'></div>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail supdetailid' /><div title='删除' style='float:left;margin-left:20%' class='clsimgdel'>&nbsp;</div><div title='查看' class='clsimglink' style='margin-left:1px'></div>";
                }

                else
                {
                    row = new HtmlTableRow();


                    //隐藏列
                    cell = new HtmlTableCell();
                    cell.Attributes.CssStyle.Add("display", "none");
                    string hidsupid = "supid" + (i + 1).ToString();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["factid"].ToString() + "' id='" + hidsupid + "' class='clsblurtxt clsedit clssupid' />";
                    //cell.InnerHtml = "<span id='" + hidsupid + "' class='clsedit'>" + tbl.Rows[i]["factid"].ToString() + "</span>";
                    row.Controls.Add(cell);

                    //联系人id
                    cell = new HtmlTableCell();
                    cell.Attributes.CssStyle.Add("display", "none");
                    string linkid = "linkID" + (i + 1).ToString();
                    string paylink = "payLink" + (i + 1).ToString();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkID"].ToString() + "' id='" + linkid + "' class='clsblurtxt clsedit clslinkid' />";
                    row.Controls.Add(cell);


                    //单位名称
                    cell = new HtmlTableCell();
                    string supid = "sup" + (i + 1).ToString();
                    if (result[0] == "有")
                    {
                        cell.Attributes.Add("onclick", "alert('该条记录已经做过付款申请，无法修改单位名称')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["supName"].ToString() + "' id='" + supid + "' class='clsblurtxt clsedit clseditdate sup' style='text-align: center' readonly='readonly' />";
                    }
                    else
                    {
                        cell.Attributes.Add("onclick", "document.getElementById('hidsupvalue').value=$(this).find('input').attr('id');debugger;document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpay('" + linkid + "','" + paylink + "');");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["supName"].ToString() + "' id='" + supid + "' class='clsblurtxt clsedit clseditdate sup' style='text-align: center' />";
                    }
                    row.Controls.Add(cell);

                    //付款类别
                    cell = new HtmlTableCell();
                    string typeid = "payType" + (i + 1).ToString();
                    if (result[0] == "有")
                    {
                        cell.Attributes.Add("onclick", "alert('该条记录已经做过付款申请，无法修改付款类别')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payType"].ToString() + "' id='" + typeid + "' class='clsblurtxt clsedit payType' style='text-align: center' readonly='readonly' />";
                    }
                    else
                    {
                        cell.Attributes.Add("onclick", "document.getElementById('hidpaytype').value=$(this).find('input').attr('id');document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpaytype();");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payType"].ToString() + "' id='" + typeid + "' class='clsblurtxt clsedit payType' style='text-align: center' />";
                    }
                    row.Controls.Add(cell);

                    //联系人
                    cell = new HtmlTableCell();
                    cell.Attributes.Add("onclick", "getpaylink('" + hidsupid + "','" + paylink + "','" + linkid + "')");
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["linkName"].ToString() + "' id='" + paylink + "' class='clsblurtxt clsedit' style='text-align: center' />";
                    row.Controls.Add(cell);

                    //成人数
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payNum"].ToString() + "' class='clsblurtxt clsedit payNum' />";
                    row.Controls.Add(cell);

                    //儿童数
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["payChildNum"].ToString() + "' class='clsblurtxt clsedit payNum' />";
                    row.Controls.Add(cell);

                    //金额
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit clseditdate paymoney' />";
                    row.Controls.Add(cell);

                    //付款申请单
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + result[0] + "' class='clsblurtxt clsedit clsagelimit' readonly='readonly' />";
                    row.Controls.Add(cell);

                    //支付状态
                    cell = new HtmlTableCell();
                    if (result[1] == "部分支付")
                        cell.InnerHtml = "<input type='text' style='color:Blue' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly' />";
                    else if (result[1] == "完成支付")
                        cell.InnerHtml = "<input type='text' style='color:Green' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly' />";
                    else
                        cell.InnerHtml = "<input type='text' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly' />";
                    row.Controls.Add(cell);

                    //已支付金额
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + result[2] + "' class='clsblurtxt clsedit payhasmoney' readonly='readonly' />";
                    row.Controls.Add(cell);

                    //剩余金额
                    cell = new HtmlTableCell();
                    double symoney = getSurplus(tbl.Rows[i]["money"].ToString(), result[2]);
                    cell.InnerHtml = "<input type='text' value='" + symoney.ToString("F2") + "' class='clsblurtxt clsedit paysymoney' />";
                    row.Controls.Add(cell);

                    //备注
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' class='clsblurtxt clsedit' />";
                    row.Controls.Add(cell);

                    //操作
                    cell = new HtmlTableCell();
                    cell.Attributes.Add("align", "center");
                    if (result[0] == "有") //如果做过付款申请不能删除 input 用于存储明细表id
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail supdetailid' /><div title='删除' style='float:left;margin-left:20%' class='clsworkimgdel'>&nbsp;</div><div title='查看' class='clsimglink' style='margin-left:1px'></div>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail supdetailid' /><div title='删除' style='float:left;margin-left:20%' class='clsimgdel'>&nbsp;</div><div title='查看' class='clsimglink' style='margin-left:1px'></div>";
                    row.Controls.Add(cell);

                    this.tablebank.Controls.Add(row);
                }
                decimal.TryParse(tbl.Rows[i]["money"].ToString(), out outmoney);
                moneyAmount += outmoney;

                this.hidsuprows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
            }
            this.lblPayAmount.Value = moneyAmount.ToString("F2");
        }

        /// <summary>
        /// 得到付款单位的确认，支付状态，支付金额等信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="factid"></param>
        /// <param name="payType"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        private string[] GetPayStatusAndMoney(string orderPayId, string money)
        {
            string[] result = new string[3]; //0，可否修改；1，支付状态；2，支付金额
            To_PaymentDetailManager paymentDetailManager = new To_PaymentDetailManager();
            DataTable dt = paymentDetailManager.GetOrderPayDetail("orderPayId=" + orderPayId);
            double shouldpay = 0;
            double.TryParse(money, out shouldpay);
            double haspay = 0;
            double ispay = 0;
            if (shouldpay == 0)
            {
                result[0] = "无";
                result[1] = "完成付款";
                result[2] = haspay.ToString("F2");
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["regType"].ToString() == "1" || dt.Rows[i]["auditstatus"].ToString() == "04") //表示该付款申请已经支付或者已经审核通过
                        {
                            double.TryParse(dt.Rows[i]["payAmount"].ToString(), out ispay);
                            haspay += ispay;
                        }
                    }

                    result[0] = "有"; //表示这张付款信息做过付款申请，不能再在订单中修改应付金额

                    if (haspay == 0)
                        result[1] = "未付款";
                    else if (shouldpay > haspay)
                        result[1] = "部分付款";
                    else
                        result[1] = "完成付款";

                    result[2] = haspay.ToString("F2");
                }
                else
                {
                    result[0] = "无";
                    result[1] = "未付款";
                    result[2] = haspay.ToString("F2");
                }
            }

            return result;
        }

        /// <summary>
        /// 加载退款明细信息
        /// </summary>
        /// <param name="id"></param>
        private void LoadRefunDetial(int id)
        {
            DataTable tbl = To_OrderRefunDetialManager.getList(id);
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            decimal moneyAmount = 0;
            decimal outmoney = 0;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                string[] result = GetReturnStatusAndMoney(tbl.Rows[i]["id"].ToString(), tbl.Rows[i]["money"].ToString());
                if (i == 0)
                {
                    row = this.tableBack.Rows[1];

                    //退款单位id
                    cell = row.Cells[0];
                    cell.Attributes.CssStyle.Add("display", "none");
                    cell.InnerHtml = "<span id='backid1' class='clsedit'>" + tbl.Rows[i]["cusid"].ToString() + "</span>";

                    if (result[0] == "有")
                    {
                        cell = row.Cells[1]; //退款单位
                        cell.Attributes.Add("onclick", "alert('该条记录已经做过付款申请，无法修改单位名称')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='cusreturn1' class='clsblurtxt clsedit returnCus' style='text-align: center' />";

                        cell = row.Cells[2]; //应退金额
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit clseditdate backmoney' readonly='readonly' />";
                    }
                    else
                    {
                        //收款单位
                        cell = row.Cells[1];
                        cell.Attributes.Add("onclick", "document.getElementById('hidcusreturnvalue').value=$(this).find('input').attr('id');document.getElementById('hidbackid').value=$(this).parent().find('span').attr('id');getreturn()");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='cusreturn1' class='clsblurtxt clsedit returnCus' style='text-align: center' />";

                        //金额
                        cell = row.Cells[2];
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit clseditdate backmoney' />";
                    }

                    //退款状态
                    cell = row.Cells[3];
                    if (result[1] == "部分退款")
                        cell.InnerHtml = "<input type='text' style='color:Blue' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else if (result[1] == "完成退款")
                        cell.InnerHtml = "<input type='text' style='color:Green' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";

                    //实际退款金额
                    cell = row.Cells[4];
                    cell.InnerHtml = "<input type='text' value='" + result[2] + "' class='clsblurtxt clsedit' readonly='readonly' />";

                    //备注
                    cell = row.Cells[5];
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' class='clsblurtxt clsedit' />";

                    //操作 input用于存储明细表id值
                    cell = row.Cells[6];
                    if (result[0] == "有")
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail reudetailid' /><div class='clsreturndel'>&nbsp;</div>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail reudetailid' /><div class='clsimgdel'>&nbsp;</div>";

                }

                else
                {
                    row = new HtmlTableRow();

                    //隐藏列
                    cell = new HtmlTableCell();
                    cell.Attributes.CssStyle.Add("display", "none");
                    string hidbackid = "backid" + (i + 1).ToString();
                    cell.InnerHtml = "<span id='" + hidbackid + "' class='clsedit'>" + tbl.Rows[i]["cusid"].ToString() + "</span>";
                    row.Controls.Add(cell);

                    if (result[0] == "有")
                    {
                        //单位名称
                        cell = new HtmlTableCell();
                        string cusreturnId = "cusreturn" + (i + 1).ToString();
                        cell.Attributes.Add("onclick", "alert('该条记录已经做过付款申请，无法修改单位名称')");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='" + cusreturnId + "' class='clsblurtxt clsedit clseditdate sup' style='text-align: center' />";
                        row.Controls.Add(cell);

                        //金额
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit clseditdate backmoney' readonly='readonly' />";
                        row.Controls.Add(cell);
                    }
                    else
                    {
                        //单位名称
                        cell = new HtmlTableCell();
                        string cusreturnId = "cusreturn" + (i + 1).ToString();
                        cell.Attributes.Add("onclick", "document.getElementById('hidcusreturnvalue').value=$(this).find('input').attr('id');document.getElementById('hidbackid').value=$(this).parent().find('span').attr('id');getreturn()");
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["cusName"].ToString() + "' id='" + cusreturnId + "' class='clsblurtxt clsedit clseditdate sup' style='text-align: center' />";
                        row.Controls.Add(cell);

                        //金额
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["money"].ToString() + "' class='clsblurtxt clsedit clseditdate backmoney' />";
                        row.Controls.Add(cell);
                    }

                    //退款状态
                    cell = new HtmlTableCell();
                    if (result[1] == "部分退款")
                        cell.InnerHtml = "<input type='text' style='color:Blue' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else if (result[1] == "完成退款")
                        cell.InnerHtml = "<input type='text' style='color:Green' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + result[1] + "' class='clsblurtxt clsedit clsStatus' readonly='readonly'/>";
                    row.Controls.Add(cell);

                    //实际退款金额
                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + result[2] + "' class='clsblurtxt clsedit' readonly='readonly' />";
                    row.Controls.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["remark"].ToString() + "' class='clsblurtxt clsedit' />";
                    row.Controls.Add(cell);

                    //操作 input 用于存储明细表id
                    cell = new HtmlTableCell();
                    cell.Attributes.Add("align", "center");
                    if (result[0] == "有")
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail reudetailid' /><div class='clsreturndel'>&nbsp;</div>";
                    else
                        cell.InnerHtml = "<input type='text' value='" + tbl.Rows[i]["id"].ToString() + "' class='clsedit clsdetail reudetailid' /><div class='clsimgdel'>&nbsp;</div>";
                    row.Controls.Add(cell);

                    this.tableBack.Controls.Add(row);
                }

                decimal.TryParse(tbl.Rows[i]["money"].ToString(), out outmoney);
                moneyAmount += outmoney;

                this.hidcusreturnrows.Value = (Convert.ToInt32(tbl.Rows.Count) + 1).ToString();
            }
            this.lblBackAmount.Value = moneyAmount.ToString("F2");
        }

        /// <summary>
        /// 得到退款信息的退款状态和退款金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payerId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        private string[] GetReturnStatusAndMoney(string orderRetID, string money)
        {
            string[] result = new string[3]; //0，可否修改；1，支付状态；2，支付金额
            DataTable dt = To_PaymentReturnManager.GetOrderReturnDetail("orderRetID=" + orderRetID);
            double shouldReturn = 0;
            double.TryParse(money, out shouldReturn);
            double hasReturn = 0;
            double isReturn = 0;
            if (shouldReturn == 0)
            {
                result[0] = "无";
                result[1] = "完成退款";
                result[2] = hasReturn.ToString("F2");
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["regType"].ToString() == "1" || dt.Rows[i]["auditstatus"].ToString() == "04") //表示该付款申请已支付或者已经审核通过
                        {
                            double.TryParse(dt.Rows[i]["returnAmount"].ToString(), out isReturn);
                            hasReturn += isReturn;
                        }
                    }

                    result[0] = "有"; //表示这张退款信息做过付款申请，不能再在订单中修改应退金额

                    if (hasReturn == 0)
                        result[1] = "未退款";
                    else if (shouldReturn > hasReturn)
                        result[1] = "部分退款";
                    else
                        result[1] = "完成退款";

                    result[2] = hasReturn.ToString("F2");
                }
                else
                {
                    result[0] = "无";
                    result[1] = "未退款";
                    result[2] = hasReturn.ToString("F2");
                }
            }

            return result;
        }

        /// <summary>
        /// 加载报销明细信息
        /// </summary>
        /// <param name="id"></param>
        public void LoadReimDetial(int id)
        {
            DataTable dt = AusRottenInfoManager.GetViewList("  orderid= " + id);
            double reim = 0;
            double reimAmount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double.TryParse(dt.Rows[i]["totalmoney"].ToString(), out reim);
                reimAmount += reim;
            }
            this.lblReimAmount.Value = reimAmount.ToString("F2");
            this.rpReimbused.DataSource = dt;
            this.rpReimbused.DataBind();
        }




        //审核流程
        /// <summary>
        /// 加载选择规则DDL
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
        /// 更新的方法
        /// </summary>
        private int Update(string args, string auditstatus)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            To_OrderInfo orderModle = To_OrderInfoManager.getTo_OrderInfoById(id);
            JobFlow jobModel = JobFlowManager.GetModel(orderModle.JobflowID);
            jobModel.savestatus = args;
            jobModel.auditstatus = auditstatus;
            jobModel.ruleid = int.Parse(DdlIsVirify.SelectedValue);
            JobFlowManager.Update(jobModel);

            orderModle.OutTime = DateTime.Parse(txtOutDate.Value.ToString()); //出团时间
            orderModle.TeamNum = txtTeamnum.Value.ToString(); //团队总数
            orderModle.Natrue = this.ddlnature.SelectedValue; //性质
            orderModle.TourRemark = txtRemark.Value.ToString(); //描述
            orderModle.Tour = ddlLine.SelectedValue.ToString(); //线路

            orderModle.IsCancel = this.isCancel.Checked ? "Y" : "N"; //是否作废

            //操作人员
            orderModle.Inputer = this.ddlInputer.SelectedItem.Text;
            orderModle.InputerID = Convert.ToInt32(this.ddlInputer.SelectedValue);

            orderModle.CollectAmount = double.Parse(lblCollAmount.Value); //收款金额合计
            orderModle.PayAmount = double.Parse(lblPayAmount.Value); //付款金额合计
            orderModle.RefundAmount = double.Parse(lblBackAmount.Value); //退款金额合计
            orderModle.ReimAmount = double.Parse(lblReimAmount.Value); //报销金额合计
            orderModle.Gross = double.Parse(lblCollAmount.Value) - double.Parse(lblPayAmount.Value) + double.Parse(lblBackAmount.Value) - double.Parse(lblReimAmount.Value); //毛利
            orderModle.InputerTc = orderModle.Gross * LoginInfoManager.getLoginInfoById(orderModle.InputerID).orderRate; //操作员毛利
            orderModle.Gross = orderModle.Gross - orderModle.InputerTc;//预计毛利还得减掉操作员在该笔订单中所占的提成（毛利*提成系数）

            if (To_OrderInfoManager.updateTo_OrderInfo(orderModle) > 0) //更新主表数据
            {
                //To_OrderCollectDetialManager.deleteTo_OrderCollectDetialByOrderID(orderModle.Id);
                addlink(orderModle.Id);
                //To_OrderPayDetialManager.deleteTo_OrderPayDetialByOrderID(orderModle.Id);
                addbank(orderModle.Id);
                //To_OrderRefunDetialManager.deleteTo_OrderRefunDetialByOrderID(orderModle.Id);
                addback(orderModle.Id);
            }

            return orderModle.JobflowID;
        }

        /// <summary>
        /// 收款单位
        /// </summary>
        /// <param name="orderid"></param>
        private void addlink(int orderid)
        {
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
                        if (cell[0] != "")
                        {
                            EtNet_Models.To_OrderCollectDetial factLink = To_OrderCollectDetialManager.getTo_OrderCollectDetialById(int.Parse(cell[14]));
                            if (factLink == null) //如果没有就新增
                            {
                                factLink = new To_OrderCollectDetial();
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
                                if (cell[9] == "") //收款金额
                                    factLink.Money = 0;
                                else
                                    factLink.Money = Convert.ToDouble(cell[9]);
                                factLink.CollectStatus = factLink.Money == 0 ? "完成收款" : cell[10]; //收款状态
                                factLink.Remark = cell[13]; //备注
                                factLink.Orderid = orderid;
                                To_OrderCollectDetialManager.addTo_OrderCollectDetial(factLink);
                            }
                            else //如果有就编辑
                            {
                                string[] result = GetColStatusAndAmount(cell[14], cell[9]);
                                factLink.CustId = Convert.ToInt32(cell[0]); //收款单位id
                                factLink.LinkID = cell[1] == "0" ? 0 : Convert.ToInt32(cell[1]); //收款单位营业部id
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
                                if (cell[9] == "") //收款金额
                                    factLink.Money = 0;
                                else
                                    factLink.Money = Convert.ToDouble(cell[9]);
                                //factLink.CollectStatus = cell[7]; //收款状态
                                factLink.CollectStatus = factLink.Money == 0 ? "完成收款" : result[1]; //收款状态
                                if (result[2] == "") //实际收款金额
                                    factLink.CollectAmount = 0.00;
                                else
                                    factLink.CollectAmount = Convert.ToDouble(result[2]);
                                factLink.Remark = cell[13]; //备注
                                factLink.Orderid = orderid;
                                To_OrderCollectDetialManager.updateTo_OrderCollectDetial(factLink);
                            }

                        }
                    }
                }
            }
            string ids = this.hidcoldetailid.Value.TrimEnd(',');
            //删除数据
            if (ids != "")
            {
                string sql = " id in (" + ids + ")";
                To_OrderCollectDetialManager.deleteTo_OrderCollectDetailbySql(sql);
            }
        }

        /// <summary>
        /// 添加付款单位
        /// </summary>
        //To_orderPayDetial
        private void addbank(int orderid)
        {
            string banklist = this.hidbank.Value;
            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;
                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                if (row.Count() > 0)
                {

                    for (int i = 0; i < row.Length; i++)
                    {
                        cell = row[i].Split('|');

                        if (cell[0] != "")
                        {
                            EtNet_Models.To_OrderPayDetial factbank = To_OrderPayDetialManager.getTo_OrderPayDetialById(int.Parse(cell[13]));
                            if (factbank == null)
                            {
                                factbank = new To_OrderPayDetial();
                                factbank.Factid = Convert.ToInt32(cell[0]); //付款单位id
                                factbank.Orderid = orderid; //订单id
                                factbank.LinkID = cell[1] == "" ? 0 : int.Parse(cell[1]); //联系人信息id
                                factbank.SupName = cell[2]; //付款单位名称
                                factbank.PayType = cell[3]; //付款类别
                                factbank.LinkName = cell[4]; //联系人名称
                                factbank.PayNum = Convert.ToInt32(cell[5]); //成人数
                                factbank.PayChildNum = Convert.ToInt32(cell[6]); //儿童数
                                double money = 0;
                                double.TryParse(cell[7], out money);
                                factbank.Money = money; //付款金额
                                factbank.PayConfirm = cell[8]; //是否做过付款申请
                                factbank.PayAmount = 0;
                                factbank.PayStatus = factbank.Money == 0 ? "完成付款" : cell[9]; //付款支付状态
                                factbank.Remark = cell[12]; //备注

                                To_OrderPayDetialManager.addTo_OrderPayDetial(factbank);
                            }
                            else
                            {
                                string[] result = GetPayStatusAndMoney(cell[13], cell[7]);
                                factbank.Factid = Convert.ToInt32(cell[0]); //付款单位id
                                factbank.Orderid = orderid; //订单id
                                factbank.LinkID = cell[1] == "" ? 0 : int.Parse(cell[1]); //联系人信息id
                                factbank.SupName = cell[2]; //付款单位名称
                                factbank.PayType = cell[3]; //付款类别
                                factbank.LinkName = cell[4]; //联系人名称
                                factbank.PayNum = Convert.ToInt32(cell[5]); //成人数
                                factbank.PayChildNum = Convert.ToInt32(cell[6]); //儿童数
                                double money = 0;
                                double.TryParse(cell[7], out money);
                                factbank.Money = money; //付款金额
                                factbank.PayConfirm = cell[8]; //是否做过付款申请
                                money = 0; //实际付款金额
                                double.TryParse(result[2], out money);
                                factbank.PayAmount = money;
                                factbank.PayStatus = factbank.Money == 0 ? "完成付款" : result[1]; //付款支付状态
                                factbank.Remark = cell[12]; //备注

                                To_OrderPayDetialManager.updateTo_OrderPayDetial(factbank);
                            }
                        }
                    }
                }
            }

            string ids = this.hidpaydetailid.Value.TrimEnd(',');
            //删除数据
            if (ids != "")
            {
                string sql = " id in (" + ids + ")";
                To_OrderPayDetialManager.deleteTo_orderPayDetailbySql(sql);
            }
        }

        /// <summary>
        /// 添加退款信息
        /// </summary>

        //back
        private void addback(int orderid)
        {
            string banklist = this.hidback.Value;
            if (banklist != "")
            {
                string[] row = null;
                string[] cell = null;

                if (banklist.IndexOf(',') >= 0) { row = banklist.Split(','); }
                else { row = new string[1] { banklist }; }
                if (row.Count() > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        cell = row[i].Split('|');
                        if (cell[0] != "")
                        {
                            EtNet_Models.To_OrderRefunDetial factbank = To_OrderRefunDetialManager.getTo_OrderRefunDetialById(int.Parse(cell[6]));
                            if (factbank == null)
                            {
                                factbank = new EtNet_Models.To_OrderRefunDetial();
                                factbank.Cusid = Convert.ToInt32(cell[0]);//退款单位id
                                factbank.CusName = cell[1]; //退款单位名称
                                if (cell[2] == "") //退款金额
                                    factbank.Money = 0;
                                else
                                    factbank.Money = Convert.ToDouble(cell[2]);
                                factbank.RefundStatus = factbank.Money == 0 ? "完成退款" : cell[3]; //退款状态
                                factbank.Remark = cell[5]; //备注
                                factbank.Orderid = orderid; //订单id
                                //实际退款金额不需要存进明细表中
                                To_OrderRefunDetialManager.addTo_OrderRefunDetial(factbank);
                            }
                            else
                            {
                                string[] result = GetReturnStatusAndMoney(cell[6], cell[2]);
                                factbank.Cusid = Convert.ToInt32(cell[0]);//退款单位id
                                factbank.CusName = cell[1]; //退款单位名称
                                if (cell[2] == "") //退款金额
                                    factbank.Money = 0.00;
                                else
                                    factbank.Money = Convert.ToDouble(cell[2]);
                                factbank.RefundStatus = factbank.Money == 0 ? "完成退款" : result[1]; //退款状态
                                if (result[2] == "") //实际退款金额
                                    factbank.RefundAmount = 0.00;
                                else
                                    factbank.RefundAmount = Convert.ToDouble(result[2]);
                                factbank.Remark = cell[5]; //备注
                                factbank.Orderid = orderid; //订单id
                                To_OrderRefunDetialManager.updateTo_OrderRefunDetial(factbank);
                            }
                        }
                    }
                }
            }
            string ids = this.hidretdetailid.Value.TrimEnd(',');
            if (ids != "")
            {
                string sql = " id in (" + ids + ")";
                To_OrderRefunDetialManager.deleteTo_OrderRefunDetialbySql(sql);
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

        ///// <summary>
        ///// 送审
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void imgbtnaudisend_Click(object sender, ImageClickEventArgs e)
        //{
        //    int jfid = Update("已提交", "01");
        //    CreateApproval(int.Parse(this.DdlIsVirify.SelectedValue), jfid);
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('送审成功！');location.href='OrderList.aspx'", true);
        //}

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            Update("草稿", "01");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功！');location.href='OrderList.aspx'", true);
        }

        /// <summary>
        /// 新增报销单的时候，保存当前订单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgnewreim_Click(object sender, ImageClickEventArgs e)
        {
            Update("草稿", "01");
        }

        protected void imgbtnback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrderList.aspx");
        }
        /// <summary>
        /// ddl
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

        /// <summary>
        /// 得到审核状态
        /// </summary>
        /// <param name="auditTxt"></param>
        /// <returns></returns>
        public string getAuditTxt(string auditTxt)
        {
            if (auditTxt == "已通过")
                return "<font color='green'>已通过</font>";
            else if (auditTxt == "进行中")
                return "<font color='blue'>进行中</font>";
            else if (auditTxt == "被拒绝")
                return "<font color='red'>被拒绝</font>";
            else
                return "未开始";
        }

        /// <summary>
        /// 得到剩余金额
        /// </summary>
        /// <param name="money"></param>
        /// <param name="hasmoney"></param>
        /// <returns></returns>
        public double getSurplus(string money, string hasmoney)
        {
            double m1 = 0; //应金额
            double m2 = 0; //实际金额
            double.TryParse(money, out m1);
            double.TryParse(hasmoney, out m2);
            return (m1 - m2);
        }

    }
}