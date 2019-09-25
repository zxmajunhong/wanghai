<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactLinkInfo.aspx.cs" Inherits="EtNet_Web.Pages.Supplier.FactLinkInfo" %>

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
                        <th width="60px;">
                            名称
                        </th>
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
                      <tr>
                        <td>
                            <asp:Label ID="lblLinkname" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPost" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMsn" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSkype" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <asp:Repeater ID="cuslinklist" runat="server">
                        <ItemTemplate>
                            <tr>
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
                                <td>
                                    <%#Eval("skype")%>
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

