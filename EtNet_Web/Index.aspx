<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EtNet_Web.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>杭州望海旅游管理系统</title>
</head>
<frameset rows="111,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame name="topFrame" src="Pages/Index/Top.aspx"  scrolling="No" noResize id="topFrame"/>
  <frameset cols="182,10,*" frameborder="no" border="0" framespacing="0">
     <frame id="leftFrame" name="leftFrame" src="Pages/Index/left.aspx" noResize/>
    <frame src="Pages/Index/Split.html" name="flag" scrolling="No" noresize="noresize" id="flag" title="flag" />
    <frame id ="mainFrame" name="mainFrame" src="Pages/Index/Welcome.aspx" runat="server" noResize />
    <%--<frame id ="mainFrame" name="mainFrame" src="Pages/Job/AuditJobFlow.aspx" noResize />--%>
  </frameset>
</frameset>
</html>
