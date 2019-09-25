<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceInfo.aspx.cs" Inherits="EtNet_Web.Pages.Invoice.InvoiceInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发票详单</title>
    <link href="../Financial/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a
        {
            color: #c75f3e;
        }
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 40px 10px 40px;
        }
        .mytable
        {
            border: 1px dashed #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            margin-top: 10px;
        }
        
        caption
        {
            padding: 0 0 5px 0;
            width: 100%;
            font: 14px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            font-weight: bold;
            text-align: center;
            background-color: transparent;
            border: none;
        }
        
        th
        {
            letter-spacing: 2px;
            font-family: 宋体;
            font-weight: normal;
            color: #333;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            border-left: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: center;
            height: 20px;
            font-weight: bold;
        }
        
        th.nobg
        {
            border-top: 0;
            border-left: 0;
            border-right: 1px dashed #C1DAD7;
            background: none;
        }
        
        
        
        alt
        {
            background: #F5FAFA;
            color: #797268;
        }
        
        th.spec
        {
            border-left: 1px solid #C1DAD7;
            border-top: 0;
            background: #fff no-repeat;
            font: bold 10px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
        }
        
        th.specalt
        {
            border-left: 1px solid #C1DAD7;
            border-top: 0;
            background: #f5fafa no-repeat;
            font: bold 10px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            color: #797268;
        }
        .td
        {
            border: 1px dashed #4f6b72;
            padding-left: 5px;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
            margin-top: 5px;
        }
        .clsborder
        {
            border: 1px solid red !important;
        }
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
            width: 80px;
            text-align: right;
            color: #444;
        }
        table.dataBox td
        {
            padding: 5px;
        }
        table.dataBox td.fieldTitle
        {
            font-family: 宋体;
            font-weight: normal;
            color: #333;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: right;
            font-weight: bold;
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
        #mytable2 tr .sum-title
        {
            text-align: right;
        }
        .invoiceCol
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">费用发票预览</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="../../Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click1" />
        </div>
        <div class="content">
            <table class="dataBox lineTable">
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <th style="width: 100px; background-color: White">
                        发票号码
                    </th>
                    <td scope="col" style="width: 23%;">
                        <asp:Label ID="lblInvoiceID" runat="server"></asp:Label>
                    </td>
                    <th scope="col" style="width: 100px">
                        发票日期
                    </th>
                    <td scope="col" class="td" style="width: 23%;">
                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                    </td>
                    <th scope="col" style="width: 100px">
                        业务员
                    </th>
                    <td scope="col" class="td" style="width: 23%;">
                        <asp:Label ID="lblSalesman" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="col" >
                        费用类别
                    </th>
                    <td scope="col" class="td">
                        <asp:Label ID="lblInvoiceType" runat="server"></asp:Label>
                    </td>
                    <th scope="col"  class="td">
                        费用金额
                    </th>
                    <td scope="col">
                        <asp:Label ID="lblCost" runat="server"></asp:Label>
                        &nbsp;
                    </td>
                    <th scope="col"  class="td">
                        所属部门
                    </th>
                    <td scope="col">
                        <asp:Label ID="lblInvoiceDepart" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="col">
                        开票单位
                    </th>
                    <td scope="col" colspan="5" class="td">
                        <asp:Label ID="lblInvoiceUnit" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="col" >
                        备注
                    </th>
                    <td scope="col" colspan="5" >
                        <asp:Label ID="lblInvoiceRemark" runat="server" Height="20px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">费用明细</span>
                    </td>
                </tr>
                <tr>
                    <th scope="col" style="text-align: center;" colspan="2" class="clstitleimg">
                        保单编号
                    </th>
                    <th scope="col" style="text-align: center;" colspan="2" class="clstitleimg">
                        客户名称
                    </th> 
                    <th scope="col" style="text-align: center;" colspan="2" class="clstitleimg">
                        费用金额
                    </th>
                </tr>
                <asp:Repeater ID="rpPolicyDetial" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="row" style="text-align: center;" colspan="2">
                                <%#Eval("policyID") %>
                            </td>
                            <td class="row" style="text-align: center;" colspan="2">
                                <%#Eval("cusName") %>
                            </td>
                            <td class="row" style="text-align: center;" colspan="2">
                                <%#Eval("cost")+".00" %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">制单明细</span>
                    </td>
                </tr>
                <tr>
                    <th scope="col" style="width: 100px">
                        制单员
                    </th>
                    <td scope="col" >
                        <asp:Label ID="lblCMan" runat="server"></asp:Label>
                        &nbsp;
                    </td>
                    <th scope="col" style="width: 100px">
                        制单部门
                    </th>
                    <td scope="col" >
                        <asp:Label ID="lblCDepart" runat="server"></asp:Label>
                    </td>
                    <th class="row" style="width: 100px">
                        制单日期
                    </th>
                    <td class="row" >
                        <asp:Label ID="lblCDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th class="row" >
                        发票状态
                    </th>
                    <td class="row"  colspan="5">
                        <asp:Label ID="lblState" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
