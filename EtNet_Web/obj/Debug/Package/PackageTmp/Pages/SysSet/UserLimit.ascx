<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLimit.ascx.cs" Inherits="Pages.SysSet.UserLimit" %>
<asp:CheckBox ID="chkParentMenu" runat="server" onclick="CheckAll(this.id)" EnableViewState="False"
    Font-Bold="True" Font-Size="13pt"></asp:CheckBox>
<asp:CheckBoxList ID="chklstChildMenu" onclick="CheckOnly(this.id)" runat="server"
    RepeatColumns="5" CellPadding="0" CellSpacing="0" Font-Size="11pt">
</asp:CheckBoxList>
<br />
<hr style="border: 1px solid #c6d5e1;" />
<input id="hidParentMenu" type="hidden" runat="server" />
<input id="hidId" type="hidden" runat="server" />