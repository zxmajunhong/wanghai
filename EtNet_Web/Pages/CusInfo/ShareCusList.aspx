<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareCusList.aspx.cs" Inherits="EtNet_Web.Pages.CusInfo.ShareCusList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>客户批量分配</title>
   <style type="text/css">
     .clsbottom{ font-size: 12px; border: 1px solid #4CB0D5;  padding: 5px 5px 10px 5px;}
     .toptitletxt{color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px; font-weight: bold;}
     .clsdata{ width: 100%;  border: 1px solid #CDC9C9;}   
     .clsbtn{ background-image:url('../../Images/Public/btn.png'); 
              text-align:center;
              cursor:pointer;
              width:80px;
              line-height:20px;
              border:1px solid #BCBCBC;
              margin-left:10px;
              margin-right:10px;
              margin-bottom:5px;}
      .custop
      {
        background:#F5F5F5;
        height:24px;
        line-height:24px;
        color:red;
        border:0px;
        border-bottom:1px solid #D4D4D4;
        text-align:left;
        
       }      
    </style>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">

        function closecus() {
            alert('保存成功!');
            art.dialog.close();
        }


        $(function () {
            $(".clsbtn").click(function () {
                var sort = $(this).attr("id");
                switch (sort) {
                    case "addbtn":
                        if ($("#listleft option:selected").length == 0) {
                            alert('未选中添加项')
                            return;
                        }
                        $("#listleft option:selected").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listright").append(str);
                            $(this).remove();
                        })

                        break;

                    case "delbtn":
                        if ($("#listright option:selected").length == 0) {
                            alert('未选中删除项')
                            return;
                        }
                        $("#listright option:selected").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listleft").append(str);
                            $(this).remove();
                        })

                        break;

                    case "addallbtn":
                        if ($("#listleft option").length == 0) {
                            return;
                        }
                        $("#listleft option").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listright").append(str);
                            $(this).remove();
                        })

                        break;

                    case "selallbtn":
                        if ($("#listright option").length == 0) {
                            return;
                        }
                        $("#listright option").each(function () {
                            var str = "<option value='" + $(this).val() + "'>" + $(this).text() + "</option>";
                            $("#listleft").append(str);
                            $(this).remove();
                        })
                        break;
                }

                if ($("#listright option").length == 0) {
                    $("#hidlist").val("");
                    $("#hidtxtlist").val("");
                }
                else {
                    var list = "";
                    var listxt = "";
                    $("#listright option").each(function () {
                        if (list == "") {
                            list = $(this).val();
                            listxt = $(this).text();
                        }
                        else {
                            list += "," + $(this).val();
                            listxt += "," + $(this).text();
                        }
                    })

                    $("#hidlist").val(list);
                    $("#hidtxtlist").val(listxt);

                }
            })

        })
    </script>
</head>
<body>
  <form id="form1" runat="server">
   <div class="clstop">
     <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left; background-repeat: no-repeat; height: 25px;">    
        <table style="width: 100%; height: 100%;">
           <tr>
             <td class="toptitletxt">客户分配</td>  
           </tr>
       </table>
      </div>
      <div style="background: #4CB0D5; height: 5px;"></div>
    </div>
    <div class="clsbottom">
       <div style="text-align:right;">
         <asp:ImageButton ID="imgbtnsave" runat="server" 
               ImageUrl="~/Images/Button/btn_save.jpg" onclick="imgbtnsave_Click" />
       </div>
       <table class="clsdata" cellpadding="0" cellspacing="0">
         <tr> 
          <td colspan="3" class="custop">客户分配设置</td>
         </tr>
         <tr style=" height:20px;">
           <td>未分配客户</td>
           <td style=" width:60px"></td>
           <td>已分配客户</td>
         </tr>
         <tr>
          <td>
            <asp:ListBox ID="listleft" SelectionMode="Multiple" runat="server" Width="250" Height="200"></asp:ListBox>
          </td>    
          <td style=" width:60px">
             <div id="addbtn" class="clsbtn"> 添加—></div>
             <div id="delbtn" class="clsbtn"> 删除<—</div>
             <div id="addallbtn" class="clsbtn"> 全部添加</div>
             <div id="selallbtn" class="clsbtn"> 全部删除</div> 
             <input id="hidlist" type="hidden" runat="server" />
             <input id="hidtxtlist" type="hidden" runat="server" />
           </td>
           <td>
             <asp:ListBox ID="listright" SelectionMode="Multiple" runat="server" Width="250" Height="200"></asp:ListBox>
           </td>     
         </tr>
       </table>
    </div>
  </form>
</body>
</html>
