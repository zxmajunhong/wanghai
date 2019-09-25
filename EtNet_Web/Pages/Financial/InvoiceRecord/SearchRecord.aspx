<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchRecord.aspx.cs" Inherits="EtNet_Web.Pages.Financial.InvoiceRecord.SearchRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../../Policy/z.js" type="text/javascript" charset="gb2312"></script>
    <link href="../../../CSS/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a
        {
            text-decoration: none;
        }
        a img
        {
            border: none;
        }
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
            overflow: auto;
            min-width: 880px;
        }
        table#dataBox
        {
            width: 100%;
        }
        table#dataBox th
        {
            width: 20%;
            text-align: right;
            color: #444444;
        }
        table#dataBox td
        {
            padding: 5px;
            width: 30%;
        }
        table#dataBox input
        {
            border: 0px;
            border-bottom: 1px solid #C6E2FF;
        }
        table#dataBox input, table#dataBox select
        {
            width: 200px;
        }
        table#dataBox input#txtUnit
        {
            margin-left: 0px;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .mytable
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
        }
        caption
        {
            padding: 5px;
            font-size: 14px;
            font-weight: bold;
        }
        .num
        {
            width: 98%;
            border: none;
            border-bottom: 1px solid #C6E2FF;
            text-align: center;
            background: #fff;
        }
        .remark
        {
            width: 98%;
            border: 0px;
            border-bottom: 1px solid #C6E2FF;
            text-align: right;
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
        #sum td.sum-title
        {
            text-align: right;
        }
        #hasSum td.sum-title
        {
            text-align: right;
        }
        #sum
        {
            color: Blue;
        }
        #chkFinish
        {
            cursor: pointer;
        }
        .style1
        {
            font-size: 20px;
            background-color: #CCCCCC;
        }
        .clsunderline
        {
            width: 200px;
            border-bottom: 1px solid #C6E2FF;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: 0;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            margin-bottom: 0px;
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background: url('../../../Images/public/title_hover.png') no-repeat;
        text-align: left; height: 25px;">
        <span style="color: #FFFFFF; padding-left: 5px; font-size: 12px; font-weight: bold;
            line-height: 25px">查看开票记录</span></div>
    <div class="border">
        <span style="display: block; width: 100%; text-align: right;"><a href="RecordList.aspx"
            title="返回">
            <img alt="返回" src="../../../Images/button/btn_back.jpg" /></a> </span></span>
        <div style="border: 1px solid #CDC9C9;">
            <table id="dataBox">
                <caption class="style1">
                    开票信息
                </caption>
                <tr>
                    <th>
                        开票日期：
                    </th>
                    <td>
                        <asp:Label ID="lblInvoiceDate" runat="server" CssClass="clsunderline" Width="200px"></asp:Label>
                    </td>
                    <th>
                        开票金额：
                    </th>
                    <td>
                        <asp:Label ID="lblAmount" runat="server" CssClass="clsunderline" Width="200px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        付款单位：
                    </th>
                    <td>
                        <asp:Label ID="lblUnit" runat="server" CssClass="clsunderline" Width="250px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        开票备注：
                    </th>
                    <td colspan="3">
                        <asp:Label ID="lblRemark" runat="server" CssClass="clsunderline" Width="90%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        登记日期：
                    </th>
                    <td>
                        <asp:Label ID="lblRecordDate" runat="server" CssClass="clsunderline" Width="200px"></asp:Label>
                    </td>
                    <th>
                        登记人：
                    </th>
                    <td>
                        <asp:Label ID="lblRecordMan" runat="server" CssClass="clsunderline" Width="200px"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border: 1px solid #CDC9C9; margin-top: 20px; padding: 10px;">
            <table id="mytable1" style="text-align: center;" cellspacing="1" class="mytable">
                <caption class="style1">
                    上次选择订单
                </caption>
                <thead>
                    <tr>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            订单编号
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            应开金额
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            本次开票金额
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpRecordList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="orderNum">
                                    <%# Eval("orderNum")%>
                                </td>
                                <td class="amount">
                                    <%# Eval("shouldMoney", "{0:F2}")%>
                                </td>
                                <td>
                                    <%#Eval("invoiceMoney","{0:F2}") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="hasSum" style="color: Blue;">
                        <td class="sum-title" colspan="2" align="right">
                            合计：
                        </td>
                        <td id="hasSumBox" runat="server">
                            0.00
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
