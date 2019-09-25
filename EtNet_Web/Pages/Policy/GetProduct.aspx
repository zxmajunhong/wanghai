<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetProduct.aspx.cs" Inherits="EtNet_Web.Pages.Policy.GetProduct" %>

<asp:repeater id="RpProType" runat="server">
    <ItemTemplate>
        <tr>
            <td>
                <a onclick="delRow(this);" title="移除行" href="javascript:void(0);">
                    <img src="../../Images/public/filedelete.gif" alt="移除行" />
                </a>
            </td>
            <td class="idcol" style="display:none"><%# Eval("ProdID") %></td>
            <td><%# Eval("ProdNo")%>
            </td>
            <td><%# Eval("ProdName")%>
            </td>
            <td>￥<input id="Text1" onblur="SetNum(this)" class="a num" dataType="Custom" regexp="^[0-9]+(.[0-9]{1,2})?$" msg="保额不能为空且必须是数字" type="text" />
            </td>
            <td>￥<input id="Text2" onblur="SetNum(this)" class="b num" dataType="Custom" regexp="^[0-9]+(.[0-9]{1,2})?$" msg="保费不能为空且必须是数字" type="text" />
            </td>
            <td><input id="Text3" class="mark" type="text" />
            </td>
        </tr>
    </ItemTemplate>
</asp:repeater>
<tr id="sum-box">
    <td id="sum-title" colspan="3">
        合计:
    </td>
    <td id="totalCoverage">
        0.00
    </td>
    <td id="totalPremium">
        0.00
    </td>
    <td></td>
</tr>
