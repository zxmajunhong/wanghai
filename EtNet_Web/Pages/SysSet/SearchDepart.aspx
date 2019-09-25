<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchDepart.aspx.cs" Inherits="Pages.SysSet.SearchDepart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门查询</title>
    <style type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsunderline{ width:180px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsdatalist{ width:180px;}
       .clsdata{width:100%; height:200px; border:1px solid #4CB0D5;}
       .clsbtn{ background-image:url('../../Images/Public/btn.png'); 
                width:80px;
                border:1px solid #BCBCBC;
                margin-left:10px;
                margin-right:10px;
                margin-bottom:5px;}
   
    </style>    
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidseldepart" runat="server" />
    <input type="hidden" id="hidtxtdepart" runat="server" />
    <div class="clstop">
       <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <span style=" color:White; font-size:12px; font-weight:bold; position:relative; top:5px; left:5px;">部门显示</span>
       </div>
       <div style=" background:#4CB0D5; height:5px;"></div>          
    </div>
    <div class="clsbottom">   
       <table class="clsdata" cellpadding="1" cellspacing="0"> 
        <tr>
         <td colspan="5" style="padding-left:40px;">
            <div>
               <table>
                 <tr>
                   <td><asp:ListBox ID="listleft" SelectionMode="Multiple" runat="server" Width="180" Height="240"></asp:ListBox></td>    
                   <td style=" width:60px">
                     <asp:Button runat="server" ID="addbtn"    Text="添加—>"   CssClass="clsbtn" 
                           onclick="addbtn_Click" />
                     <asp:Button runat="server" ID="delbtn"    Text="删除<—"   CssClass="clsbtn" 
                           onclick="delbtn_Click" />
                     <asp:Button runat="server" ID="addallbtn" Text="全部添加" CssClass="clsbtn" 
                           onclick="addallbtn_Click" />
                     <asp:Button runat="server" ID="selallbtn" Text="全部删除" CssClass="clsbtn" 
                           onclick="selallbtn_Click" />
                   </td>
                   <td><asp:ListBox ID="listright" SelectionMode="Multiple" runat="server" Width="180" Height="240"></asp:ListBox></td>     
                 </tr>
               </table>
            </div>
         </td>       
        </tr>
       </table>   
    </div>
  </form>
</body>
</html>
