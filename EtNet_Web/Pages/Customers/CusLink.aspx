<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusLink.aspx.cs" Inherits="EtNet_Web.Pages.Customers.CusLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="border" id="slider">
            <table class="usertableborder" cellspacing="1" cellpadding="3" width="730px;" align="center"
                border="0">
                <thead>
                    <tr>
                        <%--<th width="5%">
                            <input id="allClick" type="checkbox" onchange="ReSelectCheckBox()" />
                        </th>--%>
                        <th width="60px;">
                            名称</th>
                        <th width="60px">
                            职务
                        </th>
                        <th width="90px">
                            电话
                        </th>
                        <th width="90px">
                            传真
                        </th>
                        <th width="90px">
                            移动电话
                        </th>
                        <th width="120px">
                            电子邮件
                        </th>
                        <th width="120px">
                            MSN
                        </th>
                        <th width="80px">
                            Skype
                        </th>
                    </tr>
                </thead>
                <tbody align="center">
                    <asp:Repeater ID="cuslinklist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <%--<td align="center">
                                    <input id="Checkbox1" type="checkbox" />
                                </td>--%>
                                <td>
                                   <%#Eval("linkName")%>
                                </td>
                                <td>
                                    <%#Eval("post")%>
                                </td>
                                <td>
                                    <%#Eval("telephone")%>
                                </td>
                                <td>
                                    <%#Eval("fax")%>
                                </td>
                                <td>
                                   <%#Eval("mobile")%>
                                </td>
                                <td>
                                   <%#Eval("email")%>
                                </td>
                                <td>
                                   <%#Eval("msn")%>
                                </td>
                                <td align="center">
                                   <%#Eval("skype")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <div id="tip" runat="server"></div>
        </div>
    </div>
    </form>
</body>
</html>
