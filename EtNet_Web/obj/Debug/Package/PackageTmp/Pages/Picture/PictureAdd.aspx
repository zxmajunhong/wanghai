<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PictureAdd.aspx.cs" Inherits="EtNet_Web.Pages.Picture.PictureAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增图片</title>
  <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%; border:1px solid #CDC9C9;}
       .clsdatalist{ width:200px;}
       .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
       img{ cursor:pointer;}
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {


            //动态新增文件上传控件
            $("#imgadd").click(function () {
                var str = '<tr><td><input type="file" class="clsimg" name="addfile" /></td>';
                str += '<td><img class="imgdel" alt="删除" src="../../Images/public/delete.gif" /></td></tr>';
                $("#addfile").append(str);
            })


            //删除新增的上传控件
            $(".imgdel").live("click", function () {
                $(this).parent().parent().remove();
            });

            //保存时验证
            $("#imgbtnsave").click(function () {
                var str = "";
                if ($("#ddlfolder").val() == "0") {
                    str += "请选中所属图集\n";
                }
                if (!test()) {
                    str += "图片的格式只能是png,bmp,jpg,gif";
                }

                if (str) {
                    alert(str);
                    return false;
                }
                else {
                    return true;
                }
            })



            //检测
            function test() {
                var rg = /\.(png|gif|bmp|jpg)$/;
                var past = true;

                $(".clsimg").each(function () {
                    var path = "";
                    if ($(this).val() != "") {
                        path = $(this).val().toLowerCase();
                        if (!rg.test(path)) {
                            past = false;
                        }
                    }
                })

                return past;
            }

           


        })
    </script>
    
      

</head>
<body style="height:440px;">
   <form id="form1" runat="server">
     <div class="clstop">
        <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
          <table style="width:100%; height:100%;">
           <tr>
             <td class="toptitletxt">上传图片</td>
           </tr>
          </table>
        </div>
        <div style=" background:#4CB0D5; height:5px;"></div>          
     </div>
     <div class="clsbottom">
      <div style=" float:right; padding-bottom:5px;">
        <asp:ImageButton runat="server" ImageUrl="~/Images/Button/btn_save.jpg" 
              ID="imgbtnsave" onclick="imgbtnsave_Click" />
        <asp:ImageButton runat="server" ImageUrl="~/Images/Button/btn_back.jpg" 
              ID="imgbtnback" onclick="imgbtnback_Click" />
      </div>
      <table class="clsdata"> 
        <tr>
          <td style="width:60px;">所属目录:</td>
          <td>
            <asp:DropDownList ID="ddlfolder" runat="server" CssClass="clsdatalist"></asp:DropDownList>
          </td>
        </tr>  
            
        <tr>
          <td colspan="2">图片上传:</td>      
         </tr>
         <tr>
          <td colspan="2">
            <table id="addfile">
             <tr>
              <td><asp:FileUpload runat="server" CssClass="clsimg" ID="fpattachment" /></td>      
              <td><img id="imgadd" alt="新增图片" src="../../Images/public/fileadd.gif"  /></td>      
             </tr>
            </table>     
          </td>
         </tr>
       </table>
     </div>       
   </form>
</body>
</html>
