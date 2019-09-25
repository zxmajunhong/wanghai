<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadTargetHandler.aspx.cs" Inherits="EtNet_Web.Pages.Policy.LoadTargetHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
        <div id="user-info">
            <span style="padding-left:20px;">标的种类：<asp:Literal ID="ltrTargetType" runat="server"></asp:Literal></span>
        </div>

        <table id="tabledata" style="width: 100%;">
            <tr>
                <td colspan="8" style="background-image: url('../../Images/public/win_top.png'); background-repeat: repeat-x;
                    height: 31px" class="style1">
                    <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                        标的描述</span>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <table cellpadding="0" cellspacing="0" border="0" id="targetTable" class="sortable">
                        <thead>
                            <tr>
                                <th width="200px">
                                        标的描述
                                </th>
                                <th>
                                        值
                                </th>
                            </tr>
                        </thead>
                        <tbody id="container">
                            <asp:Repeater ID="rpTargetProperty" runat="server">
                                <ItemTemplate>
                                    <tr class="item" onmouseover="style.backgroundColor='#E9F5FF'" onmouseout="style.backgroundColor='#FFFFFF'">
                                        <td class="pname" align="right">
                                            <%# Eval("PropertyName")%>
                                        </td>
                                        <td class="pvalue">
                                            <%# GetHtmlControl(Convert.ToInt32(Eval("PropertyType")), Eval("EnumTypeId"))%>
                                        </td>
                                        <td class="ptypeID" style="display:none;">
                                            <%# Eval("TargetTypeId")%>
                                        </td>
                                        <td class="pid" style="display:none;">
                                            <%# Eval("PropertyId")%>
                                        </td>
                                        <td class="pdatatype" style="display:none;">
                                            <%# Eval("PropertyType")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    
</body>
</html>
