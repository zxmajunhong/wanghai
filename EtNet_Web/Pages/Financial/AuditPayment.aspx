<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditPayment.aspx.cs" Inherits="EtNet_Web.Pages.Financial.AuditPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .content
        {
            margin-bottom: 5px;
            padding: 5px 5px 5px 5px;
        }
        .content caption
        {
            background-color: #fff;
            border: 0px;
        }
        table.dataBox
        {
            width: 100%;
        }
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            min-width: 100px;
            font-weight: bold;
        }
        table.dataBox td
        {
            padding: 5px;
        }
        .lineTable td
        {
            border: 1px solid #C1DAD7;
            padding-left: 5px;
        }
        .lineTable tr
        {
            height: 20px;
            line-height: 20px;
        }
        .lineTable
        {
            border: 1px solid #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: #000000;
        }
        
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .dataBox
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
        }
        .mytable
        {
            border-collapse: collapse;
            width: 100%;
        }
        .mytable tr
        {
            background-color: #FFFFFF;
        }
        .mytable th
        {
            border: 1px solid #DED6DC;
        }
        .mytable tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        .invoiceCol
        {
            display: none;
        }
        
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata
        {
            width: 100%;
        }
        .clstxt
        {
            display: inline-block;
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsmtxt
        {
            display: inline-block;
            border: 1px solid #C6E2FF;
            height: 60px;
            width: 100%;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        img
        {
            cursor: pointer;
            border: 0;
        }
        #tblprocess
        {
            width: 100%;
            background-color: #E3E3E3;
        }
        #tblprocess tr td
        {
            background-color: #F0F8FF;
            height: 20px;
        }
        #totalnum
        {
            width: 100%;
            background-color: #E3E3E3;
        }
        #totalnum tr td
        {
            background-color: #F8F8FF;
            height: 20px;
        }
        #originalfile
        {
            background-color: #E3E3E3;
        }
        #originalfile tr td
        {
            background-color: #F0F8FF;
            height: 20px;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            height: 20px;
            text-align: center;
            color: White;
            font-weight: bold;
        }
        .clstitleimg:hover
        {
            color: Black;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
        }
        .clsborder
        {
            border: 1px solid red !important;
        }
        #optiniontxt
        {
            border: 1px solid #63B8FF;
            height: 60px;
            background-color: #F2F2F2;
            padding-top: 5px;
            line-height: 20px;
            overflow: auto;
        }
        .clshdate
        {
            text-align: center;
        }
        .clsdigit, .clsmoney
        {
            text-align: right;
        }
        input.num, input.remark
        {
            width: 100%;
            border: none;
            height: 100%;
            line-height: 100%;
            background-color: #F1F1F1;
        }
        input.num:focus, input.remark:focus
        {
            background-color: #E6E6E6;
        }
        #invoiceTable
        {
            border-collapse: collapse;
            margin-top: 10px;
            display: none;
        }
        #invoiceTable tbody td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            padding: 0px;
        }
        .splitLine
        {
            margin-top: 20px;
        }
        #regTable td
        {
            padding: 5px;
        }
        #invoiceTypeRow
        {
            display: none;
        }
        #txtApprovalOpinion
        {
            border: 1px solid #C6E2FF;
            width: 400px;
            height: 60px;
            font-size: 13px;
            resize: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topTitle">
        <span>付款审批</span>
    </div>
    <div class="wrapper">
        <div class="buttonBox">
            <asp:ImageButton ID="btnApprove" ToolTip="通过" runat="server" ImageUrl="~/Images/Button/btn_pass.jpg"
                OnClick="btnApprove_Click" />
            <asp:ImageButton ID="btnRefuse" ToolTip="拒绝" runat="server" ImageUrl="~/Images/Button/btn_refuse.jpg"
                OnClick="btnRefuse_Click" />
                      <asp:ImageButton ID="imgbtnback"   runat="server" 
                ImageUrl="~/Images/Button/btn_back.jpg" onclick="imgbtnback_Click"  />    
        
        </div>
        <div class="content">
            <table class="dataBox lineTable">
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        申请单号
                    </td>
                    <td width="24%">
                        <asp:Label ID="lblSerialNumber" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        申请日期
                    </td>
                    <td width="24%">
                        <asp:Label ID="lblRequestDate" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        制单员
                    </td>
                    <td width="24%">
                        <asp:Label ID="lblMaker" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        付款单位名称
                    </td>
                    <td>
                        <asp:Label ID="lblPayerName" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        付款类别
                    </td>
                    <td>
                        <asp:Label ID="lblPaymentType" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        支付金额合计
                    </td>
                    <td>
                        <asp:Label ID="lblSumAmount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="content" style="margin-top: 5px">
            <table class="dataBox">
                <tr>
                    <td colspan="6" style="padding: 0px;">
                        <table class="dataBox">
                            <caption style="margin-top: 0px; margin-bottom: 5px;">
                                支付明细</caption>
                            <tr>
                                <td>
                                    <table id="mytable2" style="text-align: center;" cellspacing="1" class="dataBox mytable">
                                        <thead>
                                            <tr>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                    订单编号
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                    应付金额
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                    本次支付金额
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="policyList">
                                            <asp:Repeater ID="RpPaymentDetail" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" onclick="getOrder('<%# getOrderidpay(Eval("orderPayId").ToString()) %>')">
                                                                <%# Eval("orderNum")%></a>
                                                        </td>
                                                        <td>
                                                            <%# Eval("shouldPay", "{0:F2}")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("payAmount","{0:F2}")%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <tr id="sum" style="color: Blue;">
                                                <td style="text-align: right" colspan="2">
                                                    合计：
                                                </td>
                                                <td id="sumBox" runat="server">
                                                    0.00
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table id="mytable1" style="text-align: center;" cellspacing="1" class="dataBox mytable">
                                        <thead>
                                            <tr>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                    订单编号
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                    应退金额
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                    本次退款金额&nbsp;
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="RpReturnList" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" onclick="getOrder('<%# getOrderidRet(Eval("orderRetID").ToString()) %>')">
                                                                <%# Eval("orderNum")%></a>
                                                        </td>
                                                        <td>
                                                            <%# Eval("shouldReturn", "{0:F2}")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("returnAmount", "{0:F2}")%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <tr id="returnsum" style="color: Blue;">
                                                <td colspan="2" style="text-align: right">
                                                    合计：
                                                </td>
                                                <td id="returnsumBox" runat="server">
                                                    0.00
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%">
            <tr>
                <td style="font-weight: bold">
                    审批意见:
                </td>
            </tr>
            <tr>
                <td>
                    <textarea id="txtApprovalOpinion" runat="server" style="width: 100%"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            if ($.trim($("#hidPaymentType").val()) == "1") {
                $(".invoiceCol").show();
                $("td.sum-title").attr("colspan", "6");
            }
            else {
                $(".invoiceCol").hide();
                $("td.sum-title").attr("colspan", "3");
            }
        });

        function paymentDetail(e) {
            var pid = $.trim($(e).parent("td").parent("tr").find(".pid").text());

            artDialog.open("PaymentDetail.aspx?pid=" + pid, { width: "620px", height: "430px" }).lock().title("付款信息");
        }

        //查看订单信息
        function getOrder(orderId) {
            if (orderId != "")
                window.open('../Order/OrderDetial.aspx?id=' + orderId);
            else
                alert('参数错误，找不到该订单');
        }
    </script>
    </form>
</body>
</html>
