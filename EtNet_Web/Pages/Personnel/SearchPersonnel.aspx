<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPersonnel.aspx.cs" Inherits="EtNet_Web.Pages.Personnel.SearchPersonnel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员查询</title>
    <style type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsunderline{ width:180px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsdatalist{ width:180px;}
       .clsdata{width:100%; border:1px solid #4CB0D5;}
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
    <input type="hidden" id="hidselpeople" runat="server" />
    <input type="hidden" id="hidtxtpeople" runat="server" />
    <div class="clstop">
       <div style=" background-image:url('../../Images/Public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <span style=" color:White; font-size:12px; font-weight:bold; position:relative; top:5px; left:5px;">人员显示</span>
       </div>
       <div style=" background:#4CB0D5; height:5px;"></div>          
    </div>
    <div class="clsbottom">   
       <table class="clsdata" cellpadding="1" cellspacing="0">
        <tr style=" display:none;">
          <td style="width:60px; text-align:right">姓名:</td>
          <td style=" width:210px;"><input runat="server" type="text" id="iptcname" class="clsunderline" /></td>
          <td style="width:60px; text-align:right">部门:</td>
          <td style="width:200px;">
            <asp:DropDownList runat="server" ID="ddldepartment" CssClass="clsdatalist"></asp:DropDownList>      
          </td>  
          <td></td>
        </tr>
        <tr style=" display:none;">
         <td colspan="4" align="right" style=" padding-right:20px; padding-top:5px;">
             <asp:ImageButton runat="server" ID="imgbtnsearch" 
                 ImageUrl="~/Images/Button/btn_search.jpg" onclick="imgbtnsearch_Click" />
         </td>
         <td></td>
        </tr>
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
