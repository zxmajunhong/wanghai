<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="EtNet_Web.Pages.SysSet.Service" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>技术支持</title>
    <style type="text/css">
        ul li
        {
            margin: 0;
            padding: 0;
            font-family: 黑体;
            list-style: none;
            padding-left: 1px;
            padding-top: 1px;
            margin: 0px;
        }
    </style>
</head>
<body style="background: White">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <img src="../../Images/public/logo.jpg" />
                </td>
                <td>
                    <div id="Layer" style="font-size: 13px; font-weight: normal; color: #313131; float: left">
                        <ul>
                            <asp:Literal ID="LtrCopyRight" runat="server">
                <%--<li>公司名称：杭州鹏锦科技有限公司<br /></li>
                <li>联系电话：0571-86585200<br /></li>
                <li>电子邮箱：info@pengjintech.com<br /></li>
                <li>技术支持：QQ：1234567890<br /></li>
                <li>联系传真：0571-86585200</li>--%>
                            </asp:Literal>
                        </ul>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
