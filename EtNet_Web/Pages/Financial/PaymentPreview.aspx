<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPreview.aspx.cs"
    Inherits="EtNet_Web.Pages.Financial.PaymentPreview" %>

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
            padding: 5px;
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
        table.dataBox #auditpic td
        {
            padding: 0px;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
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
            background-image: url('../../Images/public/list_tit.png');
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
        .clsborder
        {
            border: 1px solid red !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidlist" runat="server" />
    <div class="topTitle">
        <span>查看付款申请</span>
    </div>
    <div class="wrapper">
        <div class="buttonBox">
            <a href="PaymentList.aspx" onclick="javascript:void(0);" title="返回列表" id="sqyl" runat="server">
                <img alt="返回" src="../../Images/button/btn_back.jpg" /></a> <asp:ImageButton runat="server" ID="imgbtnback" 
                ImageUrl="~/Images/Button/btn_back.jpg" onclick="imgbtnback_Click" /> 
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
                        收款单位名称
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
                                                <td colspan="2" style="text-align: right">
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
                                                    本次退款金额
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
    </div>
    <div>
        <table class="dataBox">
            <tr>
                <td colspan="6" style="padding: 0px;">
                    <table class="dataBox" cellpadding="0">
                        <tr>
                            <td class="fieldTitle" style="width: 120px">
                                审核流程图：
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div id="auditpic" class="clsauditpic" runat="server">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">

        $(function () {
            //显示流程图
            $("#auditpic div").each(function () {
                var vpath = $(this).css("background-image");
                if (vpath.lastIndexOf('.') != -1) {
                    var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                    $(this).css({ "background-image": str });
                }
            })

            $(window).load(function () {

                if ($("#hidlist").val() == "-1") {
                    $("#start").addClass("clsborder");
                }
                else if ($("#hidlist").val() == "0") {
                    $("#end").addClass("clsborder");
                }
                else {
                    var str = $("#hidlist").val();
                    var list = null;
                    if (str.indexOf(',') != -1) {
                        list = str.split(',');
                    }
                    else {
                        list = [str];
                    }
                    for (var i = 0; i < list.length; i++) {
                        if ($(".cls" + $.trim(list[i])).length != 0) {
                            $(".cls" + $.trim(list[i])).addClass("clsborder");
                        }
                    }
                }
            })
        });

        function paymentDetail(e) {
            var pid = $.trim($(e).parent("td").parent("tr").find(".pid").text());

            artDialog.open("PaymentDetail.aspx?pid=" + pid, { width: "620px", height: "430px" }).lock().title("付款信息");
        }
        function printDetial(e) {
            debugger;
            var pid = $.trim($(e).parent("td").parent("tr").find(".pid").text());
            var type = $('#lblRegType').text();
            var url;
            if ($('#lblPayFor').text() != "") {
                if ($('#lblPayFor').text() == "贴费") {
                    url = 'TieFeiPrint.aspx?payid=' + pid + '&type=' + type;

                }
                else {
                    url = 'BaoFeiPrint.aspx?payid=' + pid;
                }

                window.open(url, 'newwindow', 'height=700,width=850,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
            }
            else {
                alert('付款名称为空，无法打印');
            }
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
