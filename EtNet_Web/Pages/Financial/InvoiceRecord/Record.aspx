<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Record.aspx.cs" Inherits="EtNet_Web.Pages.Financial.InvoiceRecord.Record" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开票登记</title>
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
            width: 97%;
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
                            font-weight: bold;">开票登记</span>
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
        <div style="margin: 0px 10px 20px 10px;">
            <table class="dataBox" id="stuTable" cellspacing="1" cellpadding="0">
                <tr>
                    <th class="clstitleimg" style="width: 18%;">
                        订单序号
                    </th>
                    <th class="clstitleimg" style="width: 18%;">
                        制单日期
                    </th>
                    <th class="clstitleimg" style="width: 18%;">
                        制单员
                    </th>
                    <th class="clstitleimg" style="width: 18%;">
                        金额合计
                    </th>
                    <th class="clstitleimg" style="width: 28%;">
                        收款单位名称
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
                                    <%# Eval("money", "{0:N2}")%>
                                </td>
                                <td>
                                    <%# Eval("cusName")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div id="pages" runat="server"></div>
        <div style="margin: 0px 10px 0px 10px;">
            <table class="dataBox" cellspacing="1">
                <tr style="height: 30px; line-height: 50px;">
                    <td class="fieldTitle">
                        开票情况：
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="invoicStatus" runat="server" Width="200px">
                            <asp:ListItem Text="——请选择——" Value=""></asp:ListItem>
                            <asp:ListItem Text="未开票" Value="0"></asp:ListItem>
                            <asp:ListItem Text="未完成开票" Value="1"></asp:ListItem>
                            <asp:ListItem Text="已完成开票" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
