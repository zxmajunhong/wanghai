<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementRecord.aspx.cs" Inherits="EtNet_Web.Pages.Announcement.AnnouncementRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看记录</title>
     <link href="../../Css/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; background-color:#B9D3EE}
       .clsdata tr td{ background-color:White; height:30px; text-align:center;}
       .clsunderline{ width:200px;  display:block; border:0; border-bottom:1px solid #C6E2FF;}
       .clstitleimg{ background-image:url('../../Images/public/list_tit.png'); color:White; height:24px; font-weight:bold; text-align:center;}
       .topimgtxt{font-size:12px;
                   font-weight:bold; 
                   color:#718ABE;
                   cursor:pointer;
                   display:inline-block;
                   margin-top:4px; 
                   margin-right:6px;
                  }   
       .topimgtxt img{ height:14px; width:14px; margin-right:-6px; margin-bottom:-2px;}
       .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


        })
   
    
    </script>
</head>
<body>
  <form id="form1" runat="server">
     <div class="clstop">
     <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
        <table style=" width:100%; height:100%;">
          <tr>
           <td class="toptitletxt">公告记录</td>
          </tr>
        </table>
      </div>
      <div style=" background:#4CB0D5; height:5px;"></div>
   </div>
   <div class="clsbottom">
      <table class="clsdata"  cellspacing="1" cellpadding="0">
        <thead>
          <tr>
            <td class="clstitleimg">操作人员</td>
            <td class="clstitleimg">IP地址 </td>   
            <td class="clstitleimg">操作时间</td>
            <td class="clstitleimg">操作类型</td>
               
          </tr>
         </thead>
         <tbody>
           <asp:Repeater ID="rptrecord" runat="server">       
             <ItemTemplate>
              <tr>
               <td><%# Eval("foundertxt") %>  </td>             
               <td><%# Eval("ipaddress")%>  </td>
               <td><%# Convert.ToDateTime(Eval("createtime").ToString()).ToString("yyyy-MM-dd HH:mm:ss") %> </td>
               <td><%# Eval("operatetxt") %></td>   
              </tr>
             </ItemTemplate>
            </asp:Repeater>
          </tbody>
       </table>  
      <div id="pages" runat="server"></div>
  </div>
  </form>
</body>
</html>
