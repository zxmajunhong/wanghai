<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditReimbursedForm.aspx.cs"
    Inherits="EtNet_Web.Pages.Job.ReimbursedForm.AuditReimbursedForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报销审批</title>
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
            border: 0px solid #CDC9C9;
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
            border: 0px solid #CDC9C9;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: #000000;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
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
        #tracomment
        {
            border: 1px solid #C6E2FF;
            width: 100%;
            height: 50px;
            font-size: 12px;
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
            color: White;
            text-align: center;
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
            padding: 5px;
        }
        .content caption
        {
            background-color: #fff;
            border: 0px;
        }
        .style1
        {
            width: 408px;
        }
        #orderList td
        {
            text-align: center;
            height: 30px;
            border-bottom: 1px solid #B9D3EE;
            border-right: 1px solid #B9D3EE;
        }
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {


            //隔行显示不同的背景色
            function showline() {
                $("#tblprocess tr:odd td").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的行
                $("#tblprocess tr:even td").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的行
                $("#tblprocess tr:odd td input:text").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的文本框
                $("#tblprocess tr:even td input:text").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的文本框
            }
            showline();

            //原有的票据张数与报销金额合计显示
            function loadtotal() {
                var total = 0;
                $(".clsdigit").each(function () {
                    if ($(this).text() != "") {
                        total += parseInt($(this).text());
                    }
                })
                $("#lblalldigit").text(total);
                total = 0;
                $(".clsmoney").each(function () {
                    if ($(this).text() != "") {
                        total += parseFloat($(this).text());
                    }
                })
                $("#lblallmoney").text(total.toFixed(2))
            }
            loadtotal();


            //审批通过
            $("#ibtnPass").click(function () {
                //                if ($.trim($("#tracomment").val()) == "") {
                //                    alert('请填写审批意见!');
                //                    return false;
                //                }
                if (confirm("确定审批通过!")) {
                    $("#tracomment").val(encodeURIComponent($("#tracomment").val()));
                }
                else {
                    return false;
                }
            })




            //审批拒绝
            $("#ibtnRefuse").click(function () {
                //                if ($.trim($("#tracomment").val()) == "") {
                //                    alert('请填写审批意见!');
                //                    return false;
                //                }
                if (confirm("确定拒绝该申请!")) {
                    $("#tracomment").val(encodeURIComponent($("#tracomment").val()));
                    return true;
                }
                else {
                    return false;
                }
            })


        })
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
                        报销审批
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="ibtnPass" runat="server" ImageUrl="~/Images/Button/btn_pass.jpg"
                OnClick="ibtnPass_Click" />
            <asp:ImageButton ID="ibtnRefuse" runat="server" ImageUrl="~/Images/Button/btn_refuse.jpg"
                OnClick="ibtnRefuse_Click" />
            <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="ibtnBack_Click" />
        </div>
        <div style="margin: 0px 10px 20px 10px; border: 1px solid #CDC9C9;">
            <table class="clsdata lineTable">
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 14px;">基础资料</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 80px; height: 25px; font-weight: bold; text-align: center">
                        报销单号
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblnumbers"></asp:Label>
                    </td>
                    <td style="width: 80px; height: 25px; font-weight: bold; text-align: center">
                        报销日期
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblapplydate"></asp:Label>
                    </td>
                    <td style="width: 80px; height: 25px; font-weight: bold; text-align: center">
                        填单人员
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
                    <td style="width: 80px; height: 25px; font-weight: bold; text-align: center">
                        备注
                    </td>
                    <td colspan="5">
                        <asp:Label runat="server" ID="lblremark" Width="91.5%"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 0px 10px 20px 10px; border: 1px solid #CDC9C9;">
            <table class="clsdata" id="mytable2" cellspacing="1" cellpadding="1">
                <tr>
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
        <div style="margin: 0px 10px 20px 10px; border: 1px solid #CDC9C9;">
            <table id="tblprocess" runat="server" cellspacing="1" cellpadding="1">
                <tr class="onetd" style="background-color: White;">
                    <td align="center" colspan="8" style="background-color: White; background-image: url('../../../Images/public/whitebg.png');">
                        <span style="font-weight: bold; font-size: 14px;">报销明细</span>
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
            </table>
            <table id="totalnum" cellspacing="1" cellpadding="1">
                <tr>
                    <td class="style1">
                        合计:
                    </td>
                    <td style="width: 100px; text-align: right">
                        <span id="lblalldigit" style="color: Blue; font-weight: bold;"></span>
                    </td>
                    <td style="width: 100px; text-align: right;">
                        <span id="lblallmoney" style="color: Blue; font-weight: bold;"></span>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
            <table style="width: 100%">
                <br />
                <tr>
                    <td style="font-weight: bold">
                        附件列表:
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
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
                    </td>
                </tr>
                <br />
                <tr>
                    <td colspan="5" style="font-weight: bold">
                        审批意见:
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <textarea id="tracomment" runat="server" style="height: 60px; resize: none;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
