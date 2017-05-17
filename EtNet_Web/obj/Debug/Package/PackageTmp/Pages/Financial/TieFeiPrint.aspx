<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TieFeiPrint.aspx.cs" Inherits="EtNet_Web.Pages.Financial.TieFeiPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="common.css" rel="stylesheet" type="text/css" />
    <%--<link href="print.css" rel="stylesheet" media="print" type="text/css" />--%>
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
            font-size: 15px !important;
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
            text-align: center;
        }
        .toptd
        {
            padding: 6px 6px 6px 0px;
            font-style: normal;
            font-size: 15px !important;
            font-weight: bold;
            font-family: @宋体;
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
        h1
        {
            font-size: 25px !important;
        }
        h2
        {
            font-size: 15px !important;
        }
        #txtdepart
        {
            width: 50px;
        }
    </style>
    <style media="print" type="text/css">
        div.buttonBox
        {
            display: none;
        }
    </style>
    <%--<script type="text/javascript">
        function preview() {
            var bdhtml = window.document.body.innerHTML;
            var sprnstr = "<!--startprint-->";
            var prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div id="printBox">
        <div class="topTitle">
            <span></span>
        </div>
        <div class="wrapper" style="margin: 55px 0 0 75px; width: 90%;">
            <div class="buttonBox" style="margin: 55px 0 0 0">
                <a href="javascript:void(0);" onclick="window.print();" title="打印">
                    <img alt="打印" src="../../Images/button/btn_print.jpg" /></a> <a href="javascript:void(0);"
                        onclick="self.close();" title="关闭">
                        <img alt="关闭" src="../../Images/button/btn_close.jpg" /></a>
            </div>
            <!--startprint-->
            <div class="content">
                <div>
                    <h1 style="text-align: center;">
                        浙江海安发展保险经纪有限责任公司</h1>
                    <h2 style="text-align: center">
                        业务审批表</h2>
                </div>
                <table class="dataBox lineTable">
                    <tr>
                        <td style="border: 0 0 0 0; border-bottom-style: none; border-color: White;" colspan="2">
                            报批单位：<input type="text" id="txtdepart" style="border: 0px; border-bottom: 1px solid #C6E2FF;"
                                runat="server" />客服中心
                                <%--<asp:Label ID="txtdepart1" BorderStyle="None" runat="server"></asp:Label>--%>
                        </td>
                        <td style="border: 0 0 0 0; border-color: White; border-bottom-style: none;">
                        </td>
                        <td style="border: 0 0 0 0; border-bottom-style: none; border-color: White" align="right">
                            <input type="text" id="txttime" style="border: 0px; width: auto; text-align: right"
                                value="时间" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            客户名称
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblkhmc" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            险种
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblxz" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            总保费
                        </td>
                        <td>
                            <input type="text" id="txtzbf" runat="server" style="width: auto; border: 0px;" />
                        </td>
                        <td class="fieldTitle">
                            毛经济费
                        </td>
                        <td>
                            <input type="text" id="txtjjf" runat="server" style="width: auto; border: 0px;" />
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            保险公司
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblbxgs" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 50px">
                        <td class="fieldTitle">
                            支付原因
                        </td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            咨询费比率/金额
                        </td>
                        <td colspan="3">
                            <input type="text" id="txtzxf" runat="server" style="width: auto; border: 0px;" />
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            支付方式
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblzffs" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            报批人
                        </td>
                        <td>
                            <asp:Label ID="lblbpr" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="fieldTitle">
                            区域意见
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            业务总监
                        </td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="fieldTitle">
                            总经理
                        </td>
                        <td colspan="3">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
