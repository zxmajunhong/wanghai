<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detial.aspx.cs" Inherits="Pages.Message.Detial" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
     <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:5px 50px 10px 50px;}
      .clsdata{ width:100%; border:1px solid #CDC9C9;}
   </style>
</head>
<body>
  <form id="form1" runat="server">
    <div class="clstop">
        <div style=" background-image:url('../../Images/Staff/title_hover.png');  text-align:left; background-repeat:no-repeat; height:25px;">
           <span style="color:White; vertical-align:bottom; padding-left:5px; font-size:12px; font-weight:bold;">公告查看</span>
        </div>
        <div style=" background:#4CB0D5; height:5px;"></div>
    </div>
    <div class="clsbottom">
      <div style=" text-align:right;">
        <asp:ImageButton runat="server" ImageUrl="~/Images/home/btn_back.jpg" />
      </div>
      <table class="clsdata">
        <tr>     
          <td style=" text-align:center; font-size:24px;font-weight:bold;">
            <asp:Label ID="lblTitle" runat="server" style="color:Red;" Text="Label">关于上班考勤制度的更改通知</asp:Label>
          </td>   
        </tr>
        <tr> 
         <td style=" text-align:center; font-size:14px; font-weight:bold;">
            —部门公告
         </td>
        </tr>
        <tr>
         <td style="text-align:center;font-size:14px;">
          <div style=" border:1px solid #11aaee; text-align:left; width:700px; height:200px;">
            <div style=" margin:5px;">公告详情</div>
            <div style=" margin:5px; ">
              <asp:Label ID="lblContent" runat="server" Text="Label">
                1.上班时间的迟于10点<br />
                2.下班时间不得早于5点
              </asp:Label>
            </div>
          </div>
         </td>
        </tr>
        <tr>
         <td style="text-align:center;">
           公告发布人:<asp:Label ID="lblCreateMan" runat="server" Text="Label">张力</asp:Label> 
           有效期:
             <asp:Label ID="lblBegin" runat="server" Text="Label">2011-01-02</asp:Label>至
             <asp:Label ID="lblEnd" runat="server" Text="Label">2011-01-08</asp:Label>
         </td>
        </tr>
        
           
          
          
        
       </table>
    </div>
  </form>
</body>
</html>
