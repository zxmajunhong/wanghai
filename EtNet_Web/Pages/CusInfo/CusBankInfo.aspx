<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusBankInfo.aspx.cs" Inherits="EtNet_Web.Pages.CusInfo.CusBankInfo" %>

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
            <table class="usertableborder" cellspacing="1" cellpadding="3" width="760px;" align="center"
                border="0">
                <thead>
                    <tr>
                        <%--<th width="5%">
                            <input id="allClick" type="checkbox" onchange="ReSelectCheckBox()" />
                        </th>--%>
                        <th width="20%;">
                            开户银行
                        </th>
                        <th width="20%">
                            收款人
                        </th>
                        <th width="30%">
                            银行账号
                        </th>
                        <th width="40%">
                            备注
                        </th>
                    </tr>
                </thead>
                <tbody align="center">
                    <tr>
                        <td>
                           <asp:Label ID="lblBank" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                          <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        <asp:Label ID="lblCardID" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                          <asp:Label ID="lblRemark" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
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
            <div id="tip" runat="server">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
