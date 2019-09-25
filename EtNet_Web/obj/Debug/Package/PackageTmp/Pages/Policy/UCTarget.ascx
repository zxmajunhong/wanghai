<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTarget.ascx.cs" Inherits="EtNet_Web.Pages.Policy.UCTarget" %>
<div id="user-info">
    <span style="padding-left: 20px;">标的种类：<asp:Literal ID="ltrTargetType" runat="server"></asp:Literal></span>
</div>
<table id="tabledata" style="width: 100%;">
    
    <tr>
        <td colspan="8">
            <table cellpadding="0" cellspacing="0" border="0" id="targetTable" class="sortable">
                <thead>
                    <tr>
                        <th width="200px">
                            标的描述
                        </th>
                        <th>
                            标的内容 
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
                                    <%# GetValue(Eval("propertyValue"), Convert.ToInt32(Eval("datatype")), Convert.ToInt32(Eval("propertyID")), Convert.ToInt32(Eval("propertyTypeID")))%>
                                </td>
                                <td class="ptypeID" style="display: none;">
                                    <%# Eval("propertyTypeID")%>
                                </td>
                                <td class="pid" style="display: none;">
                                    <%# Eval("propertyID")%>
                                </td>
                                <td class="pdatatype" style="display: none;">
                                    <%# Eval("datatype")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </td>
    </tr>
</table>
