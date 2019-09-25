<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartUsers.aspx.cs" Inherits="Pages.SysSet.DepartUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门下包含用户</title>
    <style type="text/css">
      .clsbottom{font-size: 12px;border: 1px solid #4CB0D5;padding: 10px;}
      .clsdata {width: 100%; background-color: #B9D3EE; }
      .clsdata tr td {background-color: White; height: 24px; text-align: center;}
      .clstitleimg{ background-image: url('../../Images/public/list_tit.png'); color: White;height: 24px;font-weight:bold; text-align:center;}
      .clstitleimg:hover { color: Black; }
      .toptitletxt { color: White; padding-left: 5px; font-size: 12px; font-weight: bold; width: 100px;}  
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


            //添加角色
            $("#addtxt").click(function () {
                window.location = "AddRole.aspx";
            })


        });

    </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
    
    </div>  <div class="clstop">
      <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;height: 25px;">
        <table style="width: 100%; height: 100%;">
          <tr>
           <td class="toptitletxt">角色下的用户  </td>  
          </tr>
        </table>
      </div> 
      <div style="background: #4CB0D5; height: 5px;">
    </div>
    </div>
    <div class="clsbottom">
        <div style=" text-align:right;">
          <asp:ImageButton runat="server" ID="imgbtnback" 
                ImageUrl="~/Images/Button/btn_back.jpg" onclick="imgbtnback_Click" />
        </div>
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <thead>
              <tr>
                <td class="clstitleimg">登录帐号</td>
                <td class="clstitleimg">姓名    </td>
                <td class="clstitleimg">号码    </td>
                <td class="clstitleimg">Email   </td>
              </tr>
            </thead>
            <tbody>
               <asp:Repeater ID="rptlist" runat="server">
                   <ItemTemplate>
                      <tr>       
                        <td> <%# Eval("loginid") %> </td>
                        <td> <%# Eval("cname") %>   </td>
                        <td> <%# Eval("tel") %>     </td>
                        <td> <%# Eval("Email") %>   </td>
                     </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
  </form>
</body>
</html>
