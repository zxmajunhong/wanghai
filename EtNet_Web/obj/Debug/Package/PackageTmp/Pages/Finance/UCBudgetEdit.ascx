<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBudgetEdit.ascx.cs"
    Inherits="EtNet_Web.Pages.Finance.UCBudgetEdit" %>
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
                                ￥<asp:TextBox CssClass="num income" onblur="SetNum(this);calcMoney('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtZxfRatio','UCBudgetEdit1_TxtZxf');calcMoney('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtGlfRatio','UCBudgetEdit1_TxtGlf');calcMoney('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtJjfsjRatio','UCBudgetEdit1_TxtJjfsj');"
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
                                ￥<asp:TextBox CssClass="num income" onblur="SetNum(this);calcMoney('UCBudgetEdit1_TxtService','UCBudgetEdit1_TxtFwfRatio','UCBudgetEdit1_TxtFwf');calcMoney('UCBudgetEdit1_TxtService','UCBudgetEdit1_TxtFwfsjRatio','UCBudgetEdit1_TxtFwfsj');"
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
                                ￥<asp:TextBox CssClass="num income" onblur="SetNum(this);calcMoney('UCBudgetEdit1_TxtIncomeOther1','UCBudgetEdit1_TxtOtherRatio','UCBudgetEdit1_TxtOther');"
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
                            <th width="100px">
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
                                ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this)" ReadOnly="true" ID="TxtExpPremium" runat="server"></asp:TextBox>
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
                                <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtZxfRatio','UCBudgetEdit1_TxtZxf');"
                                    ID="TxtZxfRatio" runat="server"></asp:TextBox>%
                            </td>
                            <td>
                            </td>
                            <td>
                                ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this);calcRatio('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtZxfRatio','UCBudgetEdit1_TxtZxf');"
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
                                <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('UCBudgetEdit1_TxtService','UCBudgetEdit1_TxtFwfRatio','UCBudgetEdit1_TxtFwf');"
                                    ID="TxtFwfRatio" runat="server"></asp:TextBox>%
                            </td>
                            <td>
                            </td>
                            <td>
                                ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this);calcRatio('UCBudgetEdit1_TxtService','UCBudgetEdit1_TxtFwfRatio','UCBudgetEdit1_TxtFwf');"
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
                                <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtGlfRatio','UCBudgetEdit1_TxtGlf');"
                                    ID="TxtGlfRatio" runat="server"></asp:TextBox>%
                            </td>
                            <td>
                            </td>
                            <td>
                                ￥<asp:TextBox CssClass="num exp" onblur="SetNum(this);calcRatio('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtGlfRatio','UCBudgetEdit1_TxtGlf');"
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
                                <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('UCBudgetEdit1_TxtBrokerage','UCBudgetEdit1_TxtJjfsjRatio','UCBudgetEdit1_TxtJjfsj');"
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
                                <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('UCBudgetEdit1_TxtService','UCBudgetEdit1_TxtFwfsjRatio','UCBudgetEdit1_TxtFwfsj');"
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
                                <asp:TextBox CssClass="num" onblur="setRatio(this);calcMoney('UCBudgetEdit1_TxtIncomeOther1','UCBudgetEdit1_TxtOtherRatio','UCBudgetEdit1_TxtOther');"
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
        $("#UCBudgetEdit1_lblIncomeSum").html(income.toFixed(2));
        $("#UCBudgetEdit1_lblExpSum").html(exp.toFixed(2));
        //$("#UCBudgetEdit1_lblSum").html((parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()) - parseFloat($("#UCBudgetEdit1_lblExpSum").html())).toFixed(2));
        var zz = (parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()) - parseFloat($("#UCBudgetEdit1_lblExpSum").html())).toFixed(2);
        if (zz < 0) {
            $("#UCBudgetEdit1_lblSum").html("<font color='red'>" + zz + "</font>");
        }
        else {
            $("#UCBudgetEdit1_lblSum").html(zz);
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
                $("#UCBudgetEdit1_lblIncomeSum").html(income.toFixed(2));
                $("#UCBudgetEdit1_lblExpSum").html(exp.toFixed(2));
                //$("#UCBudgetEdit1_lblSum").html((parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()) - parseFloat($("#UCBudgetEdit1_lblExpSum").html())).toFixed(2));
                var zz = (parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()) - parseFloat($("#UCBudgetEdit1_lblExpSum").html())).toFixed(2);
                if (zz < 0) {
                    $("#UCBudgetEdit1_lblSum").html("<font color='red'>" + zz + "</font>");
                }
                else {
                    $("#UCBudgetEdit1_lblSum").html(zz);
                }
            }); var income = 0;
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
            $("#UCBudgetEdit1_lblIncomeSum").html(income.toFixed(2));
            $("#UCBudgetEdit1_lblExpSum").html(exp.toFixed(2));
            //$("#UCBudgetEdit1_lblSum").html((parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()) - parseFloat($("#UCBudgetEdit1_lblExpSum").html())).toFixed(2));
            var zz = (parseFloat($("#UCBudgetEdit1_lblIncomeSum").html()) - parseFloat($("#UCBudgetEdit1_lblExpSum").html())).toFixed(2);
            if (zz < 0) {
                $("#UCBudgetEdit1_lblSum").html("<font color='red'>" + zz + "</font>");
            }
            else {
                $("#UCBudgetEdit1_lblSum").html(zz);
            }
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
