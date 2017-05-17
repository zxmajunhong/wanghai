<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PictureModify.aspx.cs" Inherits="EtNet_Web.Pages.Picture.PictureModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改图片</title>
    <link href="../../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px; height:500px;}
      .clsdata{ width:100%; border:1px solid #CDC9C9;}
      .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
      .clsdatalist{ width:200px;}
      .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
      .buttonStyle{ background:url('../../Images/Common/buticon.gif'); height:22px; width:64px; border:0; }
    </style>

    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/zDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/zDrag.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {


            //显示选共享人对话框
            function sdilog() {
                var diag = new Dialog();
                diag.Width = 620;
                diag.Height = 353;
                diag.Title = "共享人员选择";
                diag.URL = "../Personnel/SearchPersonnel.aspx?plist=" + $("#hidplist").val();
                diag.OKEvent = function () {
                    $("#hidplist").val(diag.innerFrame.contentWindow.document.getElementById('hidselpeople').value);
                    $("#iptplist").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtpeople').value);
                    diag.close();
                };
                diag.show();
            }


            //打开共享人员对话框
            $("#imgplist").click(sdilog);
            $("#iptplist").click(sdilog);

        });

        
    </script>
   
</head>
<body>
  <form id="form1" runat="server">
    <div class="clstop">
     <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
       <table style=" width:100%; height:100%;">
        <tr>
         <td class="toptitletxt">编辑图片</td>
        </tr>
       </table>    
      </div>
      <div style=" background:#4CB0D5; height:5px;"></div>          
    </div>
    <div class="clsbottom">
      <div style="text-align:right; margin-bottom:5px;">
         <asp:ImageButton runat="server" ID="imgbtnsure" 
              ImageUrl="~/Images/Button/btn_save.jpg" onclick="imgbtnsure_Click" />
         <asp:ImageButton runat="server" ID="imgbtnback" 
              ImageUrl="~/Images/Button/btn_back.jpg" onclick="imgbtnback_Click" />
      </div>
      <table class="clsdata">
       <tr>
         <td style=" width:80px;">图片名称:</td>
         <td><input type="text" id="iptcname" runat="server" class="clsunderline" /></td>
       </tr>
       <tr>
        <td>所属目录:</td>
        <td><asp:DropDownList runat="server" ID="ddlfolder" CssClass="clsdatalist"></asp:DropDownList></td>
       </tr>
       <tr>
        <td>是否共享:</td>
        <td>
          <asp:RadioButtonList runat="server" ID="radshare"  RepeatDirection="Horizontal">
           <asp:ListItem Value="1" Text="是"></asp:ListItem>
           <asp:ListItem Value="0" Text="否"></asp:ListItem>    
          </asp:RadioButtonList>
        </td>
       </tr>
       <tr>
        <td>分享人员:</td>
        <td>
          <input type="text" id="iptplist" class="clsunderline" runat="server" />
          <img src="../../Images/public/adedit.gif"  id="imgplist" style="cursor:pointer;" alt="修改分享人员"/>
          <span style="color:Red;">*</span>
          <input type="hidden" runat="server" id="hidplist" />
        </td>
       </tr>
     </table>
   </div>
  </form>
</body>
</html>
