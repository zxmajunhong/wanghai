<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="EtNet_Web.CMS.SysSet.Support" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/common.css" type="text/css" />
    <style type="text/css">
        .input
        {
            width: 400px;
        }
        select
        {
            width: 404px;
        }
    </style>
    <script type="text/javascript">
        function WidthCheck(str, maxLen) {

            var w = 0;
            var tempCount = 0;
            for (var i = 0; i < str.value.length; i++) {
                var c = str.value.charCodeAt(i);
                if ((c >= 0x0001 && c <= 0x007e) || (0xff60 <= c && c <= 0xff9f)) {
                    w++;

                } else {
                    w += 2;

                }

                if (w > maxLen) {
                    str.value = str.value.substr(0, i);
                    break;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="man_zone">
        <table width="99%" border="0" align="center" cellpadding="3" cellspacing="1" class="table_style">
            <tr>
                <td colspan="2"  class="" align="left">
                    <asp:ImageButton ID="itbnSave" runat="server" ImageUrl="../../Images/Button/btn_save.jpg" 
                        onclick="itbnSave_Click" />
                </td>
            </tr>
            <tr style="display: none;">
                <td width="18%" class="left_title_1">
                    登录验证：
                </td>
                <td>
                    <asp:DropDownList ID="DdlShowVerifyCode" runat="server">
                        <asp:ListItem Value="display">显示</asp:ListItem>
                        <asp:ListItem Value="hidden">隐藏</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="18%" class="left_title_1">
                    公司名称：
                </td>
                <td>
                    <asp:TextBox ID="TxtCopyright" CssClass="input" onChange="WidthCheck(this,22);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="18%" class="left_title_2">
                    联系电话：
                </td>
                <td>
                    <asp:TextBox ID="TxtTel" CssClass="input" runat="server" onChange="WidthCheck(this,22);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="18%" class="left_title_1">
                    联系传真：
                </td>
                <td>
                    <asp:TextBox ID="TxtFax" CssClass="input" onChange="WidthCheck(this,22);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="18%" class="left_title_2">
                    电子邮箱：
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" CssClass="input" onChange="WidthCheck(this,22);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="18%" class="left_title_1">
                    技术支持：
                </td>
                <td>
                    <asp:TextBox ID="TxtSupport" CssClass="input" onChange="WidthCheck(this,22);" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td width="18%" class="left_title_2">
                    公司网址：
                </td>
                <td>
                    <asp:TextBox ID="TxtURL" CssClass="input" onChange="WidthCheck(this,22);" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="left_title_1">
                </td>
                <td style="color: Red">
                    注：只能输入22个字符，数字、字母占1个字符，汉字占2个字符
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
