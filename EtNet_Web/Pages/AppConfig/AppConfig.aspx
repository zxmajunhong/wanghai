<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppConfig.aspx.cs" Inherits="EtNet_Web.Pages.AppConfig.AppConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 4px 30px 40px;
            overflow: auto;
            min-width: 880px;
            width: expression_r(document.body.clientWidth > 880? "880px": "auto" );
        }
        .titlebtncls
        {
            position: absolute;
            right: 40px;
            font-size: 12px;
            font-weight: bold;
            margin-right: 10px;
            color: #718ABE;
            cursor: pointer;
            text-decoration: none;
        }
        a
        {
            text-decoration: none;
        }
        img
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            height: 21px;
        }
        .border input
        {
            width: 400px;
        }
        select
        {
            width: 404px;
        }
    </style>
    <script type="text/javascript">
        function WidthCheck(str) {

            var w = 0;
            var tempCount = 0;
            for (var i = 0; i < str.value.length; i++) {
                var c = str.value.charCodeAt(i);
                if ((c >= 0x0001 && c <= 0x007e) || (0xff60 <= c && c <= 0xff9f)) {
                    w++;

                } else {
                    w += 2;

                }

                if (w > 40) {
                    str.value = str.value.substr(0, i);
                    break;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px;">系统设置</span> <span class="titlebtncls">
                <asp:ImageButton ID="BtnSubmit" OnClientClick="return ReadySubmit();" runat="server"
                    ImageUrl="~/Pages/Policy/Images/btn_save.jpg" OnClick="BtnSubmit_Click" />
            </span>
    </div>
    <div class="border">
        <table cellspacing="10">
            <tr>
                <td>
                    验证码：
                </td>
                <td>
                    <asp:DropDownList ID="DdlShowVerifyCode" runat="server">
                        <asp:ListItem Value="display">显示</asp:ListItem>
                        <asp:ListItem Value="hidden">隐藏</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    版权所有：
                </td>
                <td>
                    <asp:TextBox ID="TxtCopyright" onChange="WidthCheck(this);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    联系电话：
                </td>
                <td>
                    <asp:TextBox ID="TxtTel" runat="server" onChange="WidthCheck(this);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    联系传真：
                </td>
                <td>
                    <asp:TextBox ID="TxtFax" onChange="WidthCheck(this);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    电子邮箱：
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" onChange="WidthCheck(this);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    技术支持：
                </td>
                <td>
                    <asp:TextBox ID="TxtSupport" onChange="WidthCheck(this);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="color: Red">
                    注：只能输入40个字符，数字、字母占1个字符，汉字占2个字符
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
