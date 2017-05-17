<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAccount.aspx.cs" Inherits="EtNet_Web.Pages.Financial.ShowAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>帐号信息</title>
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
<body style="width:700px">
    <form id="form1" runat="server">
    <div>
        <table class="dataBox">
            <tr>
                <td colspan="2" style="font-weight:bold">
                    帐号信息
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    支付方式
                </td>
                <td style="text-align:left">
                    <input type="text" id="payType" runat="server" class="clsInput" />
                </td>
            </tr>
            <tr>
                <td>
                    收款方信息
                </td>
                <td style="text-align:left">
                    <input type="text" id="collectInfo" runat="server" class="clsInput" />
                </td>
            </tr>
            <tr>
                <td>
                    付款方信息
                </td>
                <td style="text-align:left">
                    <input type="text" id="payInfo" runat="server" class="clsInput" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
