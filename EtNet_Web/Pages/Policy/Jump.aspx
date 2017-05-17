<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jump.aspx.cs" Inherits="EtNet_Web.Pages.Policy.Jump" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-size:12px;">
    <form id="form1" runat="server">
    <div>
        保单添加成功，请选择下一步操作<br /><br />
        <asp:Button ID="btnBack" runat="server" Text="返回列表" onclick="btnBack_Click" />&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="btnBudget" runat="server" Text="添加盈亏测算数据" 
            onclick="btnBudget_Click" />
    </div>
    </form>
</body>
</html>
