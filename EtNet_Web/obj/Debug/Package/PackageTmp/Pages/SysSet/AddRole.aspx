<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="Pages.SysSet.AddRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加角色</title>
    <style  type="text/css">
       .clsbottom{ font-size:12px; border:1px solid #4CB0D5; padding:10px;}
       .clsdata{ width:100%;border:1px solid #CDC9C9;}
       .clsunderline{ width:200px; border:0; border-bottom:1px solid #C6E2FF;}
       .toptitletxt{color:White; padding-left:5px; font-size:12px; font-weight:bold; width:100px;}
       #txtRoleRemark{ height:60px; width:100%;resize:none;} 
    </style>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#ibtnAdd").click(function () {
                var str = "";
                var strtxt = $("#txtRoleName").val();
                if ($.trim(strtxt) == "") {
                    str += "名称不能为空";
                }
                if (str) {
                    alert(str);
                    return false;
                }
            })


            //返回时清空数据
            $("#ibtnback").click(function () {
                $("#txtRoleName").val("");
                $("#txtRoleRemark").val("");

            })

            

        })
    </script>
</head>
<body>
  <form id="form1" runat="server">
     <div class="clstop">
        <div style=" background-image:url('../../Images/public/title_hover.png'); background-repeat:no-repeat; height:25px;">
           <table style=" width:100%; height:100%;">
             <tr>
               <td class="toptitletxt">添加角色</td>
             </tr>
           </table>
        </div>
     </div>
     <div style=" background:#4CB0D5; height:5px;"></div>
     <div class="clsbottom">
      <div style=" text-align:right;">
        <asp:ImageButton ID="ibtnAdd" runat="server"  
              ImageUrl="../../Images/Button/btn_save.jpg" onclick="ibtnAdd_Click" />
        <asp:ImageButton ID="ibtnback" runat="server" 
              ImageUrl="../../Images/Button/btn_back.jpg" onclick="ibtnback_Click"  />       
      </div>
      <table class="clsdata">
        <tr>
          <td style=" width:100px;">角色名称</td>
          <td>          
            <asp:TextBox ID="txtRoleName" runat="server" CssClass="clsunderline"></asp:TextBox>
            <span style=" color:Red;">*</span>
          </td>
        </tr>
        <tr>
         <td colspan="2">角色备注</td>
        </tr>
        <tr>
          <td colspan="2" style=" padding-right:10px;">
            <asp:TextBox ID="txtRoleRemark" runat="server" TextMode="MultiLine"></asp:TextBox>
          </td>
        </tr>
      </table>
     </div>
  </form>
</body>
</html>
