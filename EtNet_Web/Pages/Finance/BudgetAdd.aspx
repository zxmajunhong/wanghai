<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetAdd.aspx.cs" Inherits="EtNet_Web.Pages.Finance.Budget" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Policy/common.css" />
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../Policy/z.js" type="text/javascript"></script>
    <style type="text/css">
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 10px 0px;
            overflow: auto;
            min-width: 880px;
            width: expression_r(document.body.clientWidth > 880? "880px": "auto" );
        }
        .border
        {
            width: 100%;
        }
        .sortable th
        {
            height: 24px;
            text-align: center;
        }
        .titlebtncls
        {
            position: absolute;
            right: 3px;
            font-size: 12px;
            font-weight: bold;
            margin-right: 10px;
            color: #718ABE;
            cursor: pointer;
            text-decoration: none;
            top: 17px;
        }
        #top-left
        {
            width: 40%;
            float: left;
        }
        #top-right
        {
            width: 60%;
            float: right;
        }
        #bottom
        {
            border: 1px solid #999;
            clear: both;
            margin: 0px 5px;
            padding: 10px;
        }
        .tabledata input
        {
            width: 95%;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        .tabledata input.num
        {
            width: 70%;
            text-align: right;
        }
        img
        {
            border: none;
        }
        a
        {
            text-decoration: none;
        }
    </style>
    <script type="text/javascript">
        $(".num").each(function () {
            $(this).focus(function () {
                $(this).css('text-align', 'left');
            });
            $(this).blur(function () {
                $(this).css('text-align', 'right');
            });
        });
    </script>
        <script type="text/javascript">
            $(document).ready(function () {

                $(".num").each(function () {
                    $(this).focus(function () {
                        $(this).css('text-align', 'left');
                    });
                    $(this).blur(function () {
                        $(this).css('text-align', 'right');
                    });
                });
                CalcTotal();

            });

            function SetNum(e) {
                var value = $(e).val();
                if (value == null || value == '') {
                    return false;
                }
                if (!isNaN(value)) {
                    var userreg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                    if (userreg.test(value)) {
                        var numindex = parseInt(value.indexOf("."), 10);
                        if (numindex <= 0) {
                            $(e).val(value + ".00");
                        } else if (value.length - numindex == 2) {
                            $(e).val(value + "0");
                        }
                    } else {
                        var numindex = parseInt(value.indexOf("."), 10);
                        if (value.length - numindex == 1) {
                            $(e).val(value + "00");
                        } else {
                            var numindex = parseInt(value.indexOf("."), 10);
                            if (numindex == 0) {
                                $(e).val("");
                            }
                            var head = value.substring(0, numindex);
                            var bottom = value.substring(numindex, numindex + 3);
                            var fianlNum = head + bottom;
                            $(e).val(fianlNum);
                        }
                    }
                } else {
                    $(e).val("");
                }
                CalcTotal();
            }

            function CalcTotal() {
                var totalCoverage = 0.00;
                var totalPremium = 0.00;
                $('.a').each(function () {
                    if (!isNaN(parseFloat($(this).val()))) {
                        totalCoverage += parseFloat($(this).val());
                    }
                });
                $('.b').each(function () {
                    if (!isNaN(parseFloat($(this).val()))) {
                        totalPremium += parseFloat($(this).val());
                    }
                });
                if (isNaN(totalCoverage)) {
                    $('#totalCoverage').html("0.00");
                } else {
                    $('#totalCoverage').html(totalCoverage.toFixed(2));
                }
                if (isNaN(totalPremium)) {
                    $('#totalPremium').html("0.00");
                } else {
                    $('#totalPremium').html(totalPremium.toFixed(2));
                }
            }
         
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">盈亏测算</span> <span class="titlebtncls">
                <asp:ImageButton ID="BtnSave" OnClientClick="return ReadySubmit();" runat="server"
                    ImageUrl="~/Images/button/btn_save.jpg" OnClick="BtnSave_Click" /><a href="../Policy/PolicyList.aspx"
                        title="返回列表">
                        <img alt="返回" src="../../Images/button/btn_back.jpg" /></a> </span>
    </div>
        <div style="background: #4CB0D5; height: 5px;width:100.2%">
        </div>
    
    <div class="border" id="slider">
        <div id="top">
            <div id="top-left">
                <table class="tabledata" style="width: 100%;">
                    <tr>
                        <td colspan="8" style="background-image: url('../../Images/public/win_top.png'); background-repeat: repeat-x;
                            height: 31px" class="style1">
                            <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                                收入部分</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <table cellpadding="0" cellspacing="0" border="0" id="leftTable" class="sortable">
                                <thead>
                                    <tr>
                                        <th>
                                            项目内容
                                        </th>
                                        <th>
                                            预计收入金额
                                        </th>
                                        <th>
                                            备注
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="container">
                                    <tr>
                                        <td align="right" width="100px">
                                            保费：
                                        </td>
                                        <td width="80px">
                                            ￥<asp:TextBox CssClass="num income" ReadOnly="true" ID="TxtPremium" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtPremiunMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            经纪费：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this);calcMoney('TxtBrokerage','TxtZxfRatio','TxtZxf');calcMoney('TxtBrokerage','TxtGlfRatio','TxtGlf');calcMoney('TxtBrokerage','TxtJjfsjRatio','TxtJjfsj');"
                                                ID="TxtBrokerage" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtBrokerageMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            服务费：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this);calcMoney('TxtService','TxtFwfRatio','TxtFwf');calcMoney('TxtService','TxtFwfsjRatio','TxtFwfsj');"
                                                ID="TxtService" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtServiceMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项1：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this);calcMoney('TxtIncomeOther1','TxtOtherRatio','TxtOther');"
                                                ID="TxtIncomeOther1" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther1Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项2：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther2" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther2Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项3：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther3" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther3Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项4：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther4" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther4Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项5：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther5" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther5Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项6：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther6" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther6Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项7：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther7" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther7Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项8：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther8" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther8Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项9：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther9" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther9Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项10：
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num income" onblur="SetNum(this)" ID="TxtIncomeOther10" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtIncomeOther10Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="leftSum">
                                        <td style="color: Blue" colspan="3">
                                            收入合计：￥<asp:Label ID="lblIncomeSum" runat="server" Text="0.00"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="sum">
                                        <td style="color: Blue" colspan="3">
                                            盈利总额：￥<asp:Label ID="lblSum" runat="server" Text="0.00"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="top-right">
                <table class="tabledata" style="width: 100%;">
                    <tr>
                        <td colspan="8" style="background-image: url('../../Images/public/win_top.png'); background-repeat: repeat-x;
                            height: 31px" class="style1">
                            <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                                支出部分</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <table cellpadding="0" cellspacing="0" border="0" id="table2" class="sortable">
                                <thead>
                                    <tr>
                                        <th>
                                            项目内容
                                        </th>
                                        <th>
                                            比例系数1
                                        </th>
                                        <th>
                                            比例系数2
                                        </th>
                                        <th>
                                            预计支出费用
                                        </th>
                                        <th>
                                            备注
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="Tbody1">
                                    <tr>
                                        <td align="right" width="100px">
                                            代垫保费：
                                        </td>
                                        <td width="80px">
                                            
                                        </td>
                                        <td width="80px">
                                        </td>
                                        <td width="80px">
                                            ￥<asp:TextBox CssClass="num exp" ReadOnly="true" onblur="SetNum(this)" ID="TxtExpPremium" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtExpPremiumMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="100px">
                                            佣金：
                                        </td>
                                        <td width="80px">
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtYjRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td width="80px">
                                        </td>
                                        <td width="80px">
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtYj" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtYjMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            贴费：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtTfRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtTf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtTfMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            咨询费：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('TxtBrokerage','TxtZxfRatio','TxtZxf');"
                                                ID="TxtZxfRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this);calcRatio('TxtBrokerage','TxtZxfRatio','TxtZxf');"
                                                ID="TxtZxf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtZxfmark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            服务费：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('TxtService','TxtFwfRatio','TxtFwf');"
                                                ID="TxtFwfRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this);calcRatio('TxtService','TxtFwfRatio','TxtFwf');"
                                                ID="TxtFwf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtFwfMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            管理费：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('TxtBrokerage','TxtGlfRatio','TxtGlf');"
                                                ID="TxtGlfRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this);calcRatio('TxtBrokerage','TxtGlfRatio','TxtGlf');"
                                                ID="TxtGlf" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtGlfMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            垫款利息：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtDklxRatio1" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtDklxRatio2" runat="server"></asp:TextBox>天
                                        </td>
                                        <td>
                                            <%--￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtDklx" runat="server"></asp:TextBox>--%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtDklxMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            经纪费税金：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('TxtBrokerage','TxtJjfsjRatio','TxtJjfsj');"
                                                ID="TxtJjfsjRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtJjfsj" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtJjfsjMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            服务费税金：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('TxtService','TxtFwfsjRatio','TxtFwfsj');"
                                                ID="TxtFwfsjRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtFwfsj" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtFwfsjMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它税金：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('TxtIncomeOther1','TxtOtherRatio','TxtOther');"
                                                ID="TxtOtherRatio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtOther" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtOtherMark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其它项1：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtExpOther1Ratio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtExpOther1" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtExpOther1Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其他项2：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtExpOther2Ratio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtExpOther2" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtExpOther2Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其他项3：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtExpOther3Ratio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtExpOther3" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtExpOther3Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其他项4：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtExpOther4Ratio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtExpOther4" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtExpOther4Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            其他项5：
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="num" onblur="setRatio(this)" ID="TxtExpOther5Ratio" runat="server"></asp:TextBox>%
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ID="TxtExpOther5" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtExpOther5Mark" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="rightSum">
                                        <td style="color: Blue" colspan="5">
                                            支出合计：￥<asp:Label ID="lblExpSum" runat="server" Text="0.00"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--<div style="color: Blue" id="bottom">
            盈利总额:￥000
        </div>--%>
    </div>
    <script type="text/javascript">
        function SetNum(e) {
            var value = $(e).val();
            if (value == null || value == '') {
                return false;
            }
            if (!isNaN(value)) {
                var userreg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (userreg.test(value)) {
                    var numindex = parseInt(value.indexOf("."), 10);
                    if (numindex <= 0) {
                        $(e).val(value + ".00");
                    } else if (value.length - numindex == 2) {
                        $(e).val(value + "0");
                    }
                } else {
                    var numindex = parseInt(value.indexOf("."), 10);
                    if (value.length - numindex == 1) {
                        $(e).val(value + "00");
                    } else {
                        var numindex = parseInt(value.indexOf("."), 10);
                        if (numindex == 0) {
                            $(e).val("");
                        }
                        var head = value.substring(0, numindex);
                        var bottom = value.substring(numindex, numindex + 3);
                        var fianlNum = head + bottom;
                        $(e).val(fianlNum);
                    }
                }
            } else {
                $(e).val("");
            }
            CalcTotal();
        }

        function setRatio(e) {
            var value = $(e).val();
            if (value == null || value == '') {
                return false;
            }
            if (!isNaN(value)) {
                var userreg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (userreg.test(value)) {
                    //return true;
                } else {
                    var numindex = parseInt(value.indexOf("."), 10);
                    if (numindex > 0) {
                        $(e).val(value.substring(0, numindex))
                    }
                    else {
                        //return true;
                    }
                }
            } else {
                $(e).val("");
            }

            var income = 0;
            $(".income").each(function () {
                if ($(this).val() != "") {
                    income += parseFloat($(this).val());
                }
            });
            var exp = 0;
            $(".exp").each(function () {
                if ($(this).val() != "") {
                    exp += parseFloat($(this).val());
                }
            });
            $("#lblIncomeSum").html(income.toFixed(2));
            $("#lblExpSum").html(exp.toFixed(2));
            //$("#lblSum").html((parseFloat($("#lblIncomeSum").html()) - parseFloat($("#lblExpSum").html())).toFixed(2));
            var zz = (parseFloat($("#lblIncomeSum").html()) - parseFloat($("#lblExpSum").html())).toFixed(2);
            if (zz < 0) {
                $("#lblSum").html("<font color='red'>" + zz + "</font>");
            }
            else {
                $("#lblSum").html(zz);
            }
        }

        function calcMoney(c1, c2, c3) {
            var v1 = $("#" + c1).val();
            var v2 = $("#" + c2).val();
            if (v1 == "" || v2 == "") {
                $("#" + c3).val("");
            }
            else {
                $("#" + c3).val((v1 * (v2 / 100)).toFixed(2));
            }

            $(".exp").each(function () {
                $(this).blur(function () {
                    var income = 0;
                    $(".exp").each(function () {
                        if ($(this).val() != "") {
                            income += parseFloat($(this).val());
                        }
                    });
                });
            });

            //        $("#UCBudgetEdit1_lblExpSum").html(income.toFixed(2));
            //        $("#UCBudgetEdit1_lblSum").html((parseFloat($("#UCBudgetEdit1_lblExpSum").html() + parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()))).toFixed(2));
        }

        function calcRatio(c1, c2, c3) {
            var v1 = $("#" + c1).val();
            var v3 = $("#" + c3).val();
            if (v1 == "" || v3 == "") {
                return false;
            }
            else {
                $("#" + c2).val(((v3 / v1) * 100).toFixed(0)); ;
            }
        }

        $(document).ready(function () {

            $(".income,.exp").each(function () {
                $(this).blur(function () {
                    var income = 0;
                    $(".income").each(function () {
                        if ($(this).val() != "") {
                            income += parseFloat($(this).val());
                        }
                    });
                    var exp = 0;
                    $(".exp").each(function () {
                        if ($(this).val() != "") {
                            exp += parseFloat($(this).val());
                        }
                    });
                    $("#lblIncomeSum").html(income.toFixed(2));
                    $("#lblExpSum").html(exp.toFixed(2));
                    var zz = (parseFloat($("#lblIncomeSum").html()) - parseFloat($("#lblExpSum").html())).toFixed(2);
                    if (zz < 0) {
                        $("#lblSum").html("<font color='red'>" + zz + "</font>");
                    }
                    else {
                        $("#lblSum").html(zz);
                    }
                });
            });

            //        $(".exp").each(function () {
            //            $(this).blur(function () {
            //                var income = 0;
            //                $(".exp").each(function () {
            //                    if ($(this).val() != "") {
            //                        income += parseFloat($(this).val());
            //                    }
            //                });
            //                $("#UCBudgetEdit1_lblExpSum").html(income.toFixed(2));
            //                $("#UCBudgetEdit1_lblSum").html((parseFloat($("#UCBudgetEdit1_lblExpSum").html() + parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()))).toFixed(2));
            //            });
            //        });
        });
    </script>
    </form>
</body>
</html>
