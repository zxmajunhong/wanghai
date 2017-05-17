<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentPrint.aspx.cs" Inherits="EtNet_Web.Pages.Financial.PaymentPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="common.css" rel="stylesheet" type="text/css" />
    <link href="print.css" rel="stylesheet" media="print" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        *
        {
            font-size: 12px !important;
        }
        td
        {
            font-size: 12px !important;
        }
        .content
        {
            margin-bottom: 0px;
            padding-bottom: 5px;
            padding-left: 5px;
            padding-right: 5px;
        }
        .content caption
        {
            background-color: #fff;
            border: 0px;
            font-size: 20px;
        }
        table.dataBox
        {
            width: 100%;
        }
        td.fieldTitle
        {
            width: 120px;
            text-align: right;
            color: #444;
            min-width: 120px;
            text-align: right;
            padding-left: 0px !important;
        }
        
        table.dataBox td.fieldTitle
        {
            font-family: 宋体;
            font-weight: bold;
            color: #333;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            padding: 6px 6px 6px 0px;
        }
        .toptd
        {
            padding: 6px 6px 6px 0px;
            font-style:normal;
            font-size:15px !important;
            font-weight:bold;
            font-family:@宋体;
         }
        .lineTable td
        {
            border: 1px solid #C1DAD7;
            padding-left: 5px;
        }
        .lineTable tr
        {
            height: 20px;
            line-height: 15px;
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
        #mytable2
        {
            border-collapse: collapse;
            width: 100%;
        }
        #mytable2 tr
        {
            background-color: #FFFFFF;
        }
        #mytable2 th
        {
            border: 1px solid #DED6DC;
        }
        #mytable2 tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        tr.payDetail td.sum-title
        {
            text-align: left;
        }
        tr.payDetail td.sumBox
        {
            text-align: center;
        }
        
        div.buttonBox
        {
            position: absolute;
            top: 10px;
            right: 20px;
        }
        div.topTitle
        {
            background: none;
            width: 100%;
            text-align: center;
        }
        div.topTitle span
        {
            color: #000;
            font-size: 13px;
            width: 100%;
            height: 25px;
        }
        div#printBox
        {
            width: 210mm;
            padding: 0px 5px 0px 5px;
        }
        
        tr.payDetail td
        {
            text-align: center;
        }
    </style>
    <style media="print" type="text/css">
        div.buttonBox
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="printBox">
        <div class="topTitle">
            <span></span>
        </div>
        <div class="wrapper" style="margin: 55px 0 0 75px; width: 93.5%;">
            <div class="buttonBox" style="margin: 55px 0 0 0">
                <a href="javascript:void(0);" onclick="window.print();" title="打印">
                    <img alt="打印" src="../../Images/button/btn_print.jpg" /></a> <a href="javascript:void(0);"
                        onclick="self.close();" title="关闭">
                        <img alt="关闭" src="../../Images/button/btn_close.jpg" /></a>
            </div>
            <div class="content">
                <table class="dataBox lineTable">
                    <tr align="center" style="font-size:larger;">
                        <td colspan="6" class="toptd"  style="border-top-color: White; border-left-color: white; border-right-color: white;">
                            付费申请单
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            申请单号：
                        </td>
                        <td width="24%">
                            <asp:Label ID="lblSerialNumber" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            申请日期：
                        </td>
                        <td width="24%">
                            <asp:Label ID="lblRequestDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            制单员：
                        </td>
                        <td width="24%">
                            <asp:Label ID="lblMaker" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            付款名称：
                        </td>
                        <td>
                            <asp:Label ID="lblPayFor" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            支付金额：
                        </td>
                        <td>
                            <asp:Label ID="lblSumAmount" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            预计付款日期：
                        </td>
                        <td>
                            <asp:Label ID="lblExpectedDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            收款方银行：
                        </td>
                        <td width="24%">
                            <asp:Label ID="lblBank" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            银行账号：
                        </td>
                        <td width="24%">
                            <asp:Label ID="lblBankAccount" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            开户户名：
                        </td>
                        <td width="24%">
                            <asp:Label ID="lblBankAccountName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            收款单位代码：
                        </td>
                        <td>
                            <asp:Label ID="lblPayerCode" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            收款单位名称：
                        </td>
                        <td>
                            <asp:Label ID="lblPayerName" runat="server" Text=""></asp:Label>
                        </td>
                        <%--<td class="fieldTitle">
                            付款类别：
                        </td>
                        <td>
                            <asp:Label ID="lblPaymentType" runat="server" Text=""></asp:Label>
                        </td>--%>
                        <td class="fieldTitle">入账方式：</td>
                        <td>
                            <asp:Label ID="lblRegType" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            备注：
                        </td>
                        <td colspan="5" style="height: 50px;">
                            <asp:Literal ID="ltrBankMark" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr class="payDetail">
                        <td class="fieldTitle" colspan="2">
                            保单编号
                        </td>
                        <td class="fieldTitle" colspan="2">
                            应付金额
                        </td>
                        <td class="fieldTitle" colspan="2">
                            本次支付金额
                        </td>
                    </tr>
                    <asp:Repeater ID="RpPaymentDetail" runat="server">
                        <ItemTemplate>
                            <tr class="payDetail">
                                <td colspan="2">
                                    <%# Eval("policyNum")%>
                                </td>
                                <td colspan="2">
                                    <%# Eval("policyAmount")%>
                                </td>
                                <td colspan="2">
                                    <%# Eval("payAmount")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="sum" class="payDetail" style="color: Blue;">
                        <td class="sum-title" colspan="4" align="left">
                            合计人民币（大写）：<asp:Label ID="lblRMB" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="sumBox" colspan="2">
                            <asp:Label ID="lblSum" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            审批人签名：
                        </td>
                        <td colspan="3">
                            <asp:Literal ID="ltrOptinion" runat="server"></asp:Literal>
                        </td>
                        <td>
                            申请人签名：
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidPaymentType" runat="server" />
    </form>
</body>
</html>
