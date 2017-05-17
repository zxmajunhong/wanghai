<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageSearchSet.aspx.cs"
    Inherits="EtNet_Web.Pages.Common.PageSearchSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>页面设置</title>
    <base target="_self" />
    <style type="text/css">
        .clstop
        {
            margin: 5px 10px 0px 10px;
        }
        .clsbottom
        {
            margin: 0px 10px 0px 10px;
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata
        {
            width: 100%;
            border: 1px solid #CDC9C9;
        }
        .clsunderline
        {
            width: 100px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
    </style>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        window.onunload = function () {
            var dia = window.dialogArguments;
            dia.location = dia.location.href;
            window.close();
        }



    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <span style="color: White; font-size: 12px; font-weight: bold; position: relative;
                top: 5px; left: 5px;">显示设置</span>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="float: right; margin-bottom: 5px;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="../../Images/Button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
        </div>
        <table class="clsdata">
            <tr>
                <td>
                    显示页数:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxcount"></asp:TextBox><span
                        style="color: Red;">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    每页数据:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxitem"></asp:TextBox><span
                        style="color: Red;">*</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
