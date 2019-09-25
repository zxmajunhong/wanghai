<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="EtNet_Web.Pages.Customers.Customer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 30px 0px;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <link href="default.css" rel="stylesheet" type="text/css" />
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ReSelectCheckBox() {

            var form = document.forms[0];
            for (i = 0; i < form.elements.length; i++) {
                if (form.elements[i].type == "checkbox") {
                    if (form.elements[i].checked)
                        form.elements[i].checked = false;
                    else
                        form.elements[i].checked = true;
                }
            }
        }

        function clickLink(id) {
            art.dialog.open('CusLink.aspx?id=' + id).lock().title('联系人');
        }
        function clickBank(id) {
            art.dialog.open('CustBank.aspx?id=' + id).lock().title('银行信息');
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="background-image: url('../../Images/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
                font-weight: bold;">所有客户</span>
        </div>
        <div class="border" id="slider">
            <table class="usertableborder" cellspacing="1" cellpadding="3" width="96%" align="center"
                border="0">
                <thead>
                    <tr>
                        <%--<th width="5%">
                            <input id="allClick" type="checkbox" onchange="ReSelectCheckBox()" />
                        </th>--%>
                        <th width="10%">
                            客户代码
                        </th>
                        <th width="10%">
                            客户名称
                        </th>
                        <th width="20%">
                            公司网址
                        </th>
                        <th width="10%">
                            联系人
                        </th>
                        <th width="10%">
                            银行信息
                        </th>
                        <th width="10%">
                            客户属性
                        </th>
                        <th width="10%">
                            是否启用
                        </th>
                        <th width="10%">
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="cuslist" runat="server" OnItemCommand="cuslist_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <%--<td align="center">
                                    <input id="Checkbox1" type="checkbox" />
                                </td>--%>
                                <td>
                                    <%#Eval("cusCode") %>
                                </td>
                                <td>
                                    <%#Eval("cusCName") %>
                                </td>
                                <td>
                                    <a target="_blank" href="http://<%#Eval("companyURL") %>">
                                        <%#Eval("companyURL") %>
                                    </a>
                                </td>
                                <td>
                                    <a id="linkMan" onclick='clickLink(<%#Eval("id")%>)' href="#">联系人</a>
                                </td>
                                <td>
                                    <a id="linkBank" onclick='clickBank(<%#Eval("id")%>)' href="#">银行信息</a>
                                </td>
                                <td>
                                    <%# pages_customers_customer_aspx.cuspro(Eval("cusPro").ToString()) %>
                                </td>
                                <td>
                                    <%# pages_customers_customer_aspx.ifused(Eval("used").ToString()) %>
                                </td>
                                <td align="center">
                                    <asp:LinkButton ID="lkUpdate" runat="server" CommandName="update" CommandArgument='<%#Eval("id") %>'>修改</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("id") %>'
                                        OnClientClick="return window.confirm('确认删除吗?')">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div id="pages" runat="server" style="padding-left: 30px">
            </div>
        </div>
    </form>
</body>
</html>
