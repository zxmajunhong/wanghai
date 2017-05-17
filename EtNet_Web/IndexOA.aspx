<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexOA.aspx.cs" Inherits="EtNet_Web.IndexOA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>保险经纪管理系统</title>
</head>
<frameset rows="111,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame name="topFrame" src="Pages/Index/Top.aspx"  scrolling="No" noResize id="topFrame"/>
  <frameset cols="182,10,*" frameborder="no" border="0" framespacing="0">
     <frame id="leftFrame" name="leftFrame" src="Pages/Index/left.aspx" noResize/>
    <frame src="Pages/Index/Split.html" name="flag" scrolling="No" noresize="noresize" id="flag" title="flag" />
    <frame id ="mainFrame" name="mainFrame" src="" runat="server" noResize />
    <%--<frame id ="mainFrame" name="mainFrame" src="Pages/Job/AuditJobFlow.aspx" noResize />--%>
  </frameset>
</frameset>
<body>
</body>
</html>
