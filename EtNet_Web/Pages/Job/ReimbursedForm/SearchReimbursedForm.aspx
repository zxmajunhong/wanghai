<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchReimbursedForm.aspx.cs"
    Inherits="EtNet_Web.Pages.Job.ReimbursedForm.SearchReimbursedForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看报销申请</title>
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
            border-style: none;
            border-color: inherit;
            border-width: 0;
            cursor: pointer;
            height: 21px;
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
            border: 0px solid #4f6b72;
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
        .onetd
        {
            background-color: White;
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
        .clsmoney
        {
            text-align: right;
        }
        .clsdigit
        {
            text-align: right;
        }
        .clshdate
        {
            text-align: center;
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

        })
        function printForm(id) {
            var url = 'PrintReimbursedForm.aspx?id=' + id;
            window.open(url, 'newwindow', 'height=440,width=850,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidlist" runat="server" />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        查看报销申请
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="ibtnprint" runat="server" ImageUrl="~/Images/Button/btn_print.jpg"
                OnClick="ibtnprint_Click" Visible="false" />
            <asp:ImageButton ID="ibtnBack1" runat="server" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="ibtnBack_Click1" />
            <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="ibtnBack_Click" />
        </div>
        <div style="margin: 0px 10px 20px 10px;border: 1px solid #CDC9C9;">
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
                        收款单位
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
        <div style="margin: 0px 10px 20px 10px;border: 1px solid #CDC9C9;">
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
            <br />
            <table>
                <tr>
                    <td colspan="6" style="font-weight: bold; font-size: 12px">
                        附件列表:
                    </td>
                </tr>
            </table>
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
            <table>
                <br />
                <tr>
                    <td style="font-weight: bold">
                        审核流程图:
                    </td>
                </tr>
            </table>
            <tr>
                <td colspan="6">
                    <div id="auditpic" class="clsauditpic" runat="server">
                    </div>
                </td>
            </tr>
            <table>
                <tr>
                    <td colspan="6" style="font-weight: bold">
                        <div class="clsauditxt">
                            审批意见:</div>
                    </td>
                </tr>
            </table>
            <tr>
                <td colspan="6">
                    <div id="optiniontxt" runat="server">
                    </div>
                </td>
            </tr>
        </div>
    </div>
    </form>
    <div id="pages" runat="server">
    </div>
</body>
</html>
