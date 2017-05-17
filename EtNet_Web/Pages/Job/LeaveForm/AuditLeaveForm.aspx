<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditLeaveForm.aspx.cs" Inherits="PJOAUI.View.Job.LeaveForm.AuditLeaveForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审核请假单</title>  
    <link href="../../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />

    <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {

            //审核通过
            $("#btnpass").click(function () {
                if (confirm("确定审核通过！")) {
                    if ($("#treacomment").val() == "") {
                        if (confirm('审批意见未填!如不需要填写点击"确定"')) {
                            $("#treacomment").val(encodeURIComponent($("#treacomment").val()));
                          
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        $("#treacomment").val(encodeURIComponent($("#treacomment").val()));
                        return true;

                     }
                }
                else {
                    return false;
                }

            })



            //审核拒绝
            $("#btnRefuse").click(function () {
                if (confirm("确定拒绝该申请！")) {
                    $("#treacomment").val(encodeURIComponent($("#treacomment").val()));
                    return true;
                }
                else {
                    return false;
                }
            })



        })


    </script>



    <style type="text/css">
        .style1
        {
            height: 109px;
        }
        .style2
        {
            height: 20px;
        }
    </style>

</head>
<body>
  
  <form id="form1" runat="server">
    <input type="hidden" id="hidattachment" runat="server" />
    <div style=" width:100%; height: 660px;">
      <table style="width:100%;">
         <tr>
          <th colspan="8" align="center"><h3>请假申请单审核</h3></th>
         </tr>
         <tr>
          <td colspan="8" style=" background-image: url('../../../Images/Job/win_top.png'); height:10px; background-repeat:repeat-x;"></td>
         </tr>
         <tr>
           <td style="width:10%">请假单号</td>
           <td style="width:15%"><asp:Label ID="lblnumbers" runat="server"></asp:Label></td>    
           <td style="width:10%">部门</td>
           <td style="width:15%"><asp:Label ID="lbldepart" runat="server"></asp:Label></td>
           <td style="width:10%">申请人</td>
           <td style="width:15%"><asp:Label ID="lblname" runat="server"></asp:Label></td>
           <td style="width:10%">申请日期</td>
           <td style="width:15%"><asp:Label ID="lblapplydate" runat="server"></asp:Label></td>
         </tr>
         <tr>
           <td>请假类型</td>
           <td><asp:Label ID="lblleavesort" runat="server"></asp:Label></td>
           <td>请假时间</td>
           <td colspan="5"><asp:Label ID="leavetime" runat="server"></asp:Label></td>
         </tr>
        <tr>
          <td colspan="8">请假原因及其他事项</td>
        </tr>
        <tr>
         <td colspan="8" class="style3">
           <asp:Label id="lblremark"  Height="100px"  Width="100%" runat="server"></asp:Label>   
         </td>
        </tr>
        <tr>
           <td>附件</td>
           <td colspan="7">
            <table id="originalfile" runat="server">
            </table>
           </td>   
       </tr>
       <tr>
        <td colspan="8" class="style2">审核批示</td>
       </tr>
       <tr>
         <td colspan="8"><asp:Label runat="server" ID="lblcomment"></asp:Label></td>
       </tr>
       <tr>
         <td colspan="8" class="style1">
            <textarea id="treacomment" runat="server" style="height:100px; width:100%"></textarea>
          </td>
       </tr>
       <tr>
         <td colspan="8" align="right">
           <asp:Button Text="通过" runat="server" BorderStyle="Solid" BorderWidth="1px"
                 ID="btnpass" onclick="btnpass_Click" /> &nbsp
           <asp:Button Text="拒绝" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                 ID="btnRefuse" onclick="btnRefuse_Click" /> &nbsp
           <asp:Button Text="返回" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                 ID="btnback" onclick="btnback_Click" />
                
         </td>
       </tr>

      </table>
    </div>

   

    </form>

</body>
</html>
