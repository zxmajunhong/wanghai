<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CutPayed.aspx.cs" Inherits="EtNet_Web.Pages.Financial.CutPay.CutPayed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提成发放</title>
    <link href="../../../Scripts/artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 10px 0px;
        }
        .clsunderline
        {
            width: 80%;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clstitleimg:hover
        {
            color: White;
        }
        img
        {
            cursor: pointer;
            height: 21px;
        }
        .dataBox
        {
            border-collapse: collapse;
            width: 100%;
        }
        .dataBox tr td
        {
            height: 30px;
            text-align: center;
            border: 1px solid #CDC9C9;
        }
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            height: 26px;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
            border: 1px solid #CDC9C9;
        }
        input
        {
            font-family: 宋体;
        }
    </style>
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../../Scripts/artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">提成发放</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right; margin-right: 10px">
            <asp:ImageButton runat="server" CommandName="save" ID="imgbtnsave" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
            <asp:ImageButton runat="server" CommandName="audisend" Width="0" Height="0" ID="imgbtnaudisend"
                ImageUrl="~/Images/Button/btn_audisend.jpg" />
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <div style="margin: 0px 10px 20px 10px;" id="ywy" runat="server">
            <table class="dataBox" id="stuTable" cellspacing="1" cellpadding="0">
                <tr>
                    <th class="clstitleimg" style="width: 13%;">
                        订单序号
                    </th>
                    <th class="clstitleimg" style="width: 13%;">
                        制单日期
                    </th>
                    <th class="clstitleimg" style="width: 13%;">
                        制单员
                    </th>
                    <th class="clstitleimg" style="width: 22%;">
                        收款单位名称
                    </th>
                    <th class="clstitleimg" style="width: 13%;">
                        业务员
                    </th>
                    <th class="clstitleimg" style="width: 13%;">
                        人数
                    </th>
                    <th class="clstitleimg" style="width: 13%;">
                        利润
                    </th>
                </tr>
                <tbody>
                    <asp:Repeater ID="payRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("orderNum")%>
                                </td>
                                <td>
                                    <%# Eval("makerTime", "{0:d}")%>
                                </td>
                                <td>
                                    <%# Eval("makerName")%>
                                </td>
                                <td>
                                    <%# Eval("cusName")%>
                                </td>
                                <td>
                                    <%# Eval("salesman")%>
                                </td>
                                <td>
                                    <%# Eval("adultNum").ToString() != ""&&Eval("childNum").ToString() !=""? Convert.ToInt32(Eval("adultNum")) + Convert.ToInt32(Eval("childNum")):0 %>
                                </td>
                                <td>
                                    <%#Eval("lirun") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr>
                    <td>合计：</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td id="sumNum" runat="server"></td>
                    <td id="sumlirun" runat="server"></td>
                </tr>
            </table>
        </div>
        <div style="margin: 0px 10px 20px 10px;" id="czy" runat="server">
            <table class="dataBox" id="Table1" cellspacing="1" cellpadding="0">
                <tr>
                    <th class="clstitleimg" style="width: 16%;">
                        订单序号
                    </th>
                    <th class="clstitleimg" style="width: 16%;">
                        制单日期
                    </th>
                    <th class="clstitleimg" style="width: 16%;">
                        出团日期
                    </th>
                    <th class="clstitleimg" style="width: 20%;">
                        团队总数
                    </th>
                    <th class="clstitleimg" style="width: 16%;">
                        操作员
                    </th>
                    <th class="clstitleimg" style="width: 16%;">
                        提成金额
                    </th>
                </tr>
                <tbody>
                    <asp:Repeater ID="czyRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("orderNum")%>
                                </td>
                                <td>
                                    <%# Eval("makerTime", "{0:d}")%>
                                </td>
                                <td>
                                    <%# Eval("outTime", "{0:d}")%>
                                </td>
                                <td>
                                    <%# Eval("teamNum")%>
                                </td>
                                <td>
                                    <%# Eval("inputer")%>
                                </td>
                                <td>
                                    <%# Eval("inputerTc")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tr>
                    <td>合计：
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td id="suminputerTc" runat="server">
                    </td>
                </tr>
            </table>
        </div>
        <div id="pages" runat="server">
        </div>
        <div style="margin: 0px 10px 0px 10px;">
            <table class="dataBox" cellspacing="1">
                <tr style="height: 30px; line-height: 50px;">
                    <td class="fieldTitle">
                        提成发放情况：
                    </td>
                    <td style="text-align: left;">
                        <input type="radio" name="tc" checked="true" id="tc_yes" runat="server" /><span style="color:Green;">是</span>
                        <input type="radio" name="tc" runat="server" /><span style="color:Red">否</span>
                   <%--     <input type="text" id="txtstatus" runat="server" class="clsunderline" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
