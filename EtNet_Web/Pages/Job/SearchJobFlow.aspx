<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchJobFlow.aspx.cs" Inherits="EtNet_Web.Job.SearchJobFlow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作流查询界面</title>
    <link href="../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    

    <script src="../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>

 
</head>

<body>
    <form id="form1" runat="server">
   
   
  <div id="divmenu">
      <ul>
       <li><a href="AuditJobFlow.aspx">工作流审核</a></li>
       <li><a href="LeaveForm/AddLeaveForm.aspx">添加请假申请</a></li>
       <li><a href="LeaveForm/ShowLeaveForm.aspx">查看请假申请</a></li>
       <li><a href="SealForm/AddSealForm.aspx">添加公章申请</a></li>
       <li><a href="SealForm/ShowSealForm.aspx">查看公章申请</a></li>
       <li><a href="ReimbursedForm/ShowReimbursedForm.aspx">查看报销申请</a></li>
       <li><a href="ReimbursedForm/AddReimbursedForm.aspx">添加报销申请</a></li>
       <li><a href="OfficeSuppyForm/AddOfficeSuppyForm.aspx">添加办公用品申请</a></li>
       <li><a href="OfficeSuppyForm/ShowOfficeSuppyForm.aspx">查看办公用品申请</a></li>
      </ul> 
    </div>


    </form>
</body>
</html>
