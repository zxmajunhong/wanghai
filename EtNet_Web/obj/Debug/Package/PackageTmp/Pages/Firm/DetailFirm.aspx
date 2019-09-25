<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailFirm.aspx.cs" Inherits="Pages.Firm.DetailFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司资料</title>
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
            border: 1px solid #CDC9C9;
        }
        .clsdata tr td
        {
            height: 24px;
        }
        .clstxt
        {
            width: 200px;
            display: inline-block;
            border-bottom: 1px solid #C6E2FF;
            height: 20px;
            line-height: 25px;
        }
        .clsmtxt
        {
            border: 1px solid #C6E2FF;
            width: 100%;
            height: 60px;
            overflow: auto;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .imgtitle
        {
            background-image: url('../../Images/public/list_tit.png');
            font-weight: bold;
            color: White;
        }
        .clsaccount
        {
            width: 100%;
            background-color: #B9D3EE;
        }
        .clsaccount tr th
        {
            height:24px;
            }
        .clsaccount tr td
        {
            background-color: White;
        }
        .clslogo
        {
            max-width: 200px;
            max-height: 200px;
            border: 1px solid #C6E2FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        公司资料
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
        <div class="clsbottom">
            <div style="text-align: right;">
                <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="~/Images/Button/btn_back.jpg"
                    OnClick="imgbtnback_Click" />
            </div>
            <table class="clsdata">
                <tr>
                    <td style="width: 70px;">
                        公司代码:
                    </td>
                    <td style="width: 240px;">
                        <asp:Label runat="server" ID="lblfirmcode" class="clstxt"></asp:Label>
                    </td>
                    <td rowspan="7" style="width: 200px;">
                    </td>
                    <td style="width: 70px;">
                        英文全称:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblename" class="clstxt"></asp:Label>
                    </td>
                    <td rowspan="7" style="width: 200px;" align="left" valign="top">
                        <img runat="server" id="imglogopath" class="clslogo" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 70px;">
                        公司简称:
                    </td>
                    <td style="width: 240px;">
                        <asp:Label runat="server" ID="lblshortname" class="clstxt"></asp:Label>
                    </td>
                    <td>
                        邮政编码:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblpostal" class="clstxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        公司全称:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblcname" class="clstxt"></asp:Label>
                    </td>
                    <td>
                        税务登记号:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbltaxnum" class="clstxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        电话号码:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbltel" class="clstxt"></asp:Label>
                    </td>
                    <td>
                        机构代码号:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblorgcode" class="clstxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        传真号码:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblfax" class="clstxt"></asp:Label>
                    </td>
                    <td>
                        邮箱地址:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblmailbox" class="clstxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        中文地址:
                    </td>
                    <td colspan="4">
                        <asp:Label runat="server" ID="lblcaddress" class="clstxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        英文地址:
                    </td>
                    <td colspan="4">
                        <asp:Label runat="server" ID="lbleaddress" class="clstxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        公司地址:
                    </td>
                    <td colspan="5">
                        <asp:Label runat="server" ID="lblwedsite" class="clstxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        备注资料:
                    </td>
                    <td colspan="2">
                        <div id="remark" runat="server" class="clsmtxt">
                        </div>
                    </td>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        银行资料:
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="clsaccount"  id="accountlist" cellspacing="1" cellpadding="0">
                            <tr>
                                <td class="imgtitle" style="width: 30%">
                                    开户行名称
                                </td>
                                <td class="imgtitle" style="width: 30%">
                                    开户行账号
                                </td>
                                <td class="imgtitle" style="width: 16%">
                                    预设时间
                                </td>
                                <td class="imgtitle" style="width: 12%">
                                    预设余额
                                </td>
                                <td class="imgtitle" style="width: 12%">
                                    实际余额
                                </td>
                            </tr>
                            <tbody>
                                <asp:Repeater ID="rptAccount" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("bankname") %>
                                            </td>
                                            <td>
                                                <%#Eval("account") %>
                                            </td>
                                            <td>
                                                <%#Convert.ToDateTime(Eval("ystime")).ToString("yyyy-MM-dd") %>
                                            </td>
                                            <td>
                                                <%#Eval("amount") %>
                                            </td>
                                            <td>
                                               <a href='BankExpensDetail.aspx?bankid=<%#Eval("id") %>&firmid=<%#Eval("firmid") %>' title="查看明细" ><%#Math.Round(Convert.ToDecimal(getamount(Eval("id"))),2) %></a> 
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </td>
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
