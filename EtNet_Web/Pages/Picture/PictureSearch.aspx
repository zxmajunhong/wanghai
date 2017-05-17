<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PictureSearch.aspx.cs" Inherits="EtNet_Web.Pages.Picture.PictureSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片查找</title>
    <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; border:1px solid #B9D3EE; padding:2px;  height:180px; overflow:auto;}
       .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .clsdatalist{ width:200px;}
       .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}    
       .pictotal{float:left;border:1px solid #CAE1FF; width:120px;margin:15px;}
       .pictotal:hover{border:1px solid #AA11C1;}
       .pictop{ text-align:center; width:100%; height:80px; line-height:80px;  background:#FAFAFA;}       
       .pictop img{ max-width:70px; max-height:70px; margin-top:5px;}
       .piccenter{ text-align:center; min-height:25px; max-width:120px; overflow:hidden;}
    
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $(".pictotal").click(function () {
                $("#iptcname").val($(this).find(".piccenter").text());
                $("#hidimgpath").val("../" + $(this).find("img").attr("src"));
                $("#hidimgid").val($(this).find("img").attr("id"));    
            })



        })  
    </script>

</head>
<body>
  <form id="form1" runat="server" > 
    <input type="hidden" id="hidimgpath" runat="server" />
    <input type="hidden" id="hidimgid" runat="server" />
    <div class="clstop">
        <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
           <table style=" width:100%; height:100%;">
             <tr>
               <td class="toptitletxt">查看图片</td>  
             </tr>
           </table>
        </div>
        <div style=" background:#4CB0D5; height:5px;"></div>          
    </div>
    <div class="clsbottom">
     <table class="clssift">
      <tr>
       <td style="width:60px;">选中图片:</td>
       <td>
         <input type="text" id="iptcname" class="clsunderline" />
       </td>
      </tr>
      <tr>              
        <td style="width:60px;" >所属图集:</td>
        <td>
          <asp:DropDownList ID="ddlfolder" runat="server" CssClass="clsdatalist"  AutoPostBack="true"
                onselectedindexchanged="ddlfolder_SelectedIndexChanged"></asp:DropDownList>
        </td>  
       </tr>
      </table>     
      <div id="picturedata" class="clsdata" runat="server"></div>
  
      </div>
   </form>
</body>
</html>
