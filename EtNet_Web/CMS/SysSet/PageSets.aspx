<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageSets.aspx.cs" Inherits="EtNet_Web.CMS.SysSet.PageSets" %>

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
                <td colspan="2" class="" align="left">
                    <asp:ImageButton ID="itbnSave" runat="server" ImageUrl="../../Images/Button/btn_save.jpg"
                        OnClick="itbnSave_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color: Blue">数据列表页面显示配置</span>
                </td>
            </tr>
            <tr>
                <td width="18%" class="left_title_1">
                    显示页数：
                </td>
                <td>
                    <asp:DropDownList ID="ddlShowPage" runat="server">
                        <asp:ListItem Value="3">3页</asp:ListItem>
                        <asp:ListItem Value="5">5页</asp:ListItem>
                        <asp:ListItem Value="8">8页</asp:ListItem>
                        <asp:ListItem Value="10">10页</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="left_title_2">
                    每页数据：
                </td>
                <td style="color: Red">
                    <asp:DropDownList ID="ddlShowCount" runat="server">
                        <asp:ListItem Value="10">10条</asp:ListItem>
                        <asp:ListItem Value="15">15条</asp:ListItem>
                        <asp:ListItem Value="20">20条</asp:ListItem>
                        <asp:ListItem Value="25">25条</asp:ListItem>
                        <asp:ListItem Value="30">30条</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
