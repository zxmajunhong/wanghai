<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPolicy.aspx.cs" Inherits="EtNet_Web.Pages.Invoice.GetPolicy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
    <tr>
        <td align="center" style="border-bottom: 1px dashed; border-top: 1px dashed; letter-spacing: 2px;
            text-transform: uppercase; text-align: left; padding: 6px 6px 6px 12px;">
            <a href="javascript:void(0);" class="">
                <img alt="删除此条" title="删除此条" src="../../Images/public/filedelete.gif" /></a>
        </td>
        <td class="row" style="border-right: 1px dashed;">
            123456789
        </td>
        <td class="row" style="border-right: 1px dashed;">
            李四
        </td>
        <td class="row" style="border-right: 1px dashed;">
            3000￥
        </td>
        <td class="row" style="border-right: 1px dashed;">
            备注
        </td>
    </tr>
    </ItemTemplate>
      </asp:Repeater>
    </form>
</body>
</html>
