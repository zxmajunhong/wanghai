﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegreimbursedFormDetail.aspx.cs"
    Inherits="EtNet_Web.Pages.Job.ReimbursedForm.RegreimbursedFormDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报销支付预览</title>
    <link href="../../Financial/css/common.css" rel="stylesheet" type="text/css" />
    <link href="../../Policy/tab.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
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
        }
        #tblprocess tr td input
        {
            border: 0;
            background-color: #F0F8FF;
            width: 98%;
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
            background-image: url('../../../Images/public/list_tit.png');
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
            height: 30px;
        }
        .clsdigit, .clsmoney
        {
            text-align: right;
        }
        
        .content
        {
            margin-bottom: 10px;
            margin-top: 5px;
            padding-bottom: 5px;
        }
        td.fieldTitle
        {
            width: 100px;
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
            padding: 6px 6px 6px 12px;
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
        
        
        .dataBox
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
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
        }
        .displae
        {
            display: none;
        }
        #orderList td
        {
            text-align: center;
            height: 30px;
            border-bottom: 1px solid #B9D3EE;
            border-right: 1px solid #B9D3EE;
        }
    </style>
    <script src="../../Common/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
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

            //隔行显示不同的背景色
            function showline() {
                $("#tblprocess tr:odd td").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的行
                $("#tblprocess tr:even td").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的行
                $("#tblprocess tr:odd td input:text").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的文本框
                $("#tblprocess tr:even td input:text").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的文本框
            }
            showline();

        })

        function selectTag(showContent, selfObj) {
            // 操作标签
            var tag = document.getElementById("tags").getElementsByTagName("li");
            var taglength = tag.length;
            for (i = 0; i < taglength; i++) {
                tag[i].className = "";
            }
            selfObj.parentNode.className = "selectTag";
            // 操作内容
            for (i = 0; j = document.getElementById("tagContent" + i); i++) {
                j.style.display = "none";
            }
            document.getElementById(showContent).style.display = "block";

            $("#hidTabSatae").val(showContent);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        报销支付
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="ibtnBack_Click" />
        </div>
        <div id="con" style="margin-bottom: 0px;">
            <ul id="tags">
                <li id="tag0" class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">
                    报销信息</a> </li>
                <li id="tag1"><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">财务登记</a>
                </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0" style="padding: 10px 10px 10px 10px">
                    <div class="content" style="width: 97%">
                        <table class="dataBox lineTable">
                            <tr>
                                <td align="center" colspan="6" style="background: #F0F0F0">
                                    <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; height: 20px; font-weight: bold" align="center">
                                    报销单号:
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblnumbers"></asp:Label>
                                </td>
                                <td style="font-weight: bold; width: 80px" align="center">
                                    申请日期:
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblapplydate"></asp:Label>
                                </td>
                                <td style="height: 20px; font-weight: bold; width: 80px" align="center">
                                    填单人员:
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblcanme"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; height: 25px; font-weight: bold; text-align: center">
                                    收款账户
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblbanker"></asp:Label>
                                </td>
                                <td style="width: 80px; height: 25px; font-weight: bold; text-align: center">
                                    收款银行
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblbankname"></asp:Label>
                                </td>
                                <td style="width: 80px; height: 25px; font-weight: bold; text-align: center">
                                    收款帐号
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblbanknum"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold" align="center">
                                    备注:
                                </td>
                                <td colspan="5">
                                    <asp:Label runat="server" ID="lblremark" Width="92%"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="content" style="width: 97%; text-align: center; border: 1px solid #CDC9C9;">
                        <table class="clsdata" id="mytable2" cellspacing="1" cellpadding="1">
                            <tr style="height: 32px">
                                <td align="center" colspan="5" style="background: #F0F0F0">
                                    <span style="font-weight: bold; font-size: 16px;">订单信息</span>
                                </td>
                            </tr>
                            <tr>
                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                                    订单序号
                                </th>
                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                                    订单类型
                                </th>
                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                                    出团日期
                                </th>
                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                                    性质
                                </th>
                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                                    旅游线路
                                </th>
                            </tr>
                            <tbody id="orderList">
                                <asp:Repeater ID="rpOrderlist" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Eval("orderNum") %>
                                            </td>
                                            <td>
                                                <%# Eval("orderType") %>
                                            </td>
                                            <td>
                                                <%# Eval("outTime","{0:yyyy-MM-dd}") %>
                                            </td>
                                            <td>
                                                <%# Eval("natrue") %>
                                            </td>
                                            <td>
                                                <%# Eval("tour") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="content" style="width: 97%;">
                        <table id="tblprocess" cellspacing="1" cellpadding="1" style="text-align: center;">
                            <tr style="height: 32px">
                                <td align="center" colspan="7" style="background: #F0F0F0">
                                    <span style="font-weight: bold; font-size: 16px;">报销明细</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="clstitleimg" style="width: 100px;">
                                    发生日期
                                </td>
                                <td class="clstitleimg" style="width: 100px;">
                                    项目类别
                                </td>
                                <td class="clstitleimg" style="width: 100px;">
                                    部门
                                </td>
                                <td class="clstitleimg" style="width: 100px;">
                                    报销人员
                                </td>
                                <td class="clstitleimg" style="width: 100px;">
                                    票据张数
                                </td>
                                <td class="clstitleimg" style="width: 100px;">
                                    报销金额
                                </td>
                                <td class="clstitleimg">
                                    详细说明
                                </td>
                            </tr>
                            <tbody>
                                <asp:Repeater runat="server" ID="detailList">
                                    <ItemTemplate>
                                        <tr style="height: 30px">
                                            <td>
                                                <%# Eval("happendate","{0:d}")%>
                                            </td>
                                            <td>
                                                <%# Eval("ausname")%>
                                            </td>
                                            <td>
                                                <%# Eval("belongsort")%>
                                            </td>
                                            <td>
                                                <%# Eval("Salesman")%>
                                            </td>
                                            <td>
                                                <%# Eval("billnum")%>
                                            </td>
                                            <td>
                                                <%# ShowNumeral(Eval("ausmoney").ToString())%>
                                            </td>
                                            <td>
                                                <%# Eval("remark")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <table id="totalnum" cellspacing="1" cellpadding="1">
                            <tr>
                                <td style="width: 408px; color: Blue; text-align: left">
                                    合计:
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <asp:Label ID="lblnum" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <asp:Label ID="lblmoney" Font-Bold="true" ForeColor="Blue" runat="server"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table style="width: 100%">
                        <tr>
                            <td align="center" style="font-weight: bold">
                                附件列表:
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <table id="originalfile" runat="server" cellspacing="1" cellpadding="1">
                                    <tr>
                                        <td class="clstitleimg" style="width: 20px;">
                                        </td>
                                        <td class="clstitleimg" style="width: 400px;">
                                            名称
                                        </td>
                                        <td class="clstitleimg" style="width: 40px;" align="center">
                                            下载
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table style="width: 60%">
                                    <tr>
                                        <td colspan="4" style="font-weight: bold">
                                            审核流程图:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <div id="auditpic" class="clsauditpic" runat="server" style="width: 98%">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" style="font-weight: bold">
                                            <div class="clsauditxt">
                                                审批意见:</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <div id="optiniontxt" runat="server" style="width: 98%">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tagContent" id="tagContent1">
                    <div class="content">
                        <table id="regTable" class="clsdata">
                            <caption>
                                登记信息</caption>
                            <tbody>
                                <tr>
                                    <td class="fieldTitle">
                                        支付状态：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpaystatus" runat="server"></asp:Label>
                                    </td>
                                    <%--<td class="fieldTitle">
                                        支付方式：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpaymodel" runat="server"></asp:Label>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td class="fieldTitle">
                                        支付人：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpayer" runat="server"></asp:Label>
                                    </td>
                                    <td class="fieldTitle">
                                        支付日期：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpaydate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldTitle">
                                        支付银行：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpaybank" runat="server"></asp:Label>
                                    </td>
                                    <td class="fieldTitle">
                                        支付帐号：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpayaccount" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fieldTitle">
                                        报销凭证
                                    </td>
                                    <td>
                                        <asp:Label ID="lblpayremark" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" id="hidlist" runat="server" />
    </form>
</body>
</html>
