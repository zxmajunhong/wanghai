<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchLink.aspx.cs" Inherits="EtNet_Web.Pages.Order.SearchLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>联系人信息</title>
    <style type="text/css">
        .clsInput
        {
            border:0;
            text-align:left;
            width:100%;
            font-size:15px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="dataBox">
            <tr>
                <td colspan="6" style="font-weight:bold">
                    联系人信息
                </td>
            </tr>
            <tr>
                <td style="width:80px">
                    联系人名:
                </td>
                <td>
                    <input type="text" id="linkName" runat="server" class="clsInput" />
                </td>
                <td style="width:80px">
                    所属职务:
                </td>
                <td>
                    <input type="text" id="linkPost" runat="server" class="clsInput" />
                </td>
                <td style="width:80px">
                    手机号码:
                </td>
                <td>
                    <input type="text" id="linkMobile" runat="server" class="clsInput" />
                </td>
            </tr>
            <tr>
                <td>
                    联系电话:
                </td>
                <td>
                    <input type="text" id="linkTel" runat="server" class="clsInput" />
                </td>
                <td>
                    联系传真:
                </td>
                <td>
                    <input type="text" id="linkFax" runat="server" class="clsInput" />
                </td>
                <td>
                    邮箱地址:
                </td>
                <td>
                    <input type="text" id="linkEmail" runat="server" class="clsInput" />
                </td>
            </tr>
            <tr>
                <td>
                    Q Q:
                </td>
                <td>
                    <input type="text" id="linkMsn" runat="server" class="clsInput" />
                </td>
                <td>
                    Skype:
                </td>
                <td>
                    <input type="text" id="linkSkype" runat="server" class="clsInput" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
