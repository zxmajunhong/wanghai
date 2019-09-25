<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustBank.aspx.cs" Inherits="EtNet_Web.Pages.Customers.CustBank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                            开户银行
                        </th>
                        <th width="60px">
                            收款人
                        </th>
                        <th width="90px">
                            银行账号
                        </th>
                        <th width="90px">
                            备注
                        </th>
                    </tr>
                </thead>
                <tbody align="center">
                    <asp:Repeater ID="banklist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <%--<td align="center">
                                    <input id="Checkbox1" type="checkbox" />
                                </td>--%>
                                <td>
                                    <%#Eval("bank")%>
                                </td>
                                <td>
                                    <%#Eval("cardName")%>
                                </td>
                                <td>
                                    <%#Eval("cardId")%>
                                </td>
                                <td>
                                    <%#Eval("remark")%>
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
