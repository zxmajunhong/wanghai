<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUserPwd.aspx.cs" Inherits="EtNet_Web.Pages.SysSet.UpdateUserPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <base target="_self" />
    <style type="text/css">
        .clstop
        {
            margin: 5px 5px 0px 5px;
        }
        .clsbottom
        {
            margin: 0px 5px 0px 5px;
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata
        {
            width: 100%;
            border: 1px solid #CDC9C9;
        }
        .clsdata tr td
        {
            height: 25px;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        window.onload = function () {
            window.document.getElementById("imgbtnsave").onclick = function () {
                var pwd = window.document.getElementById("iptpwd").value;
                if (pwd == "") {
                    alert('新置密码不能为空!')
                    return false;
                }
                else {
                    return true;
                }
            }
        }


        function winclose() {
            window.close();
        }
   
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        修改用户密码</td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="float: right; padding-bottom: 5px;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="../../Images/Button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
            <asp:ImageButton runat="server" ID="imgbtncanel" 
                ImageUrl="../../Images/Button/btn_cancel.jpg" />
        </div>
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <tr>
                <td style="width: 60px;">
                    用户名称:
                </td>
                <td>
                    <%--<input id="iptlogin" type="" runat="server" class="clsunderline" />--%>
                    <asp:Label ID="iptlogin" runat="server" Text="" class="clsunderline" Width="200px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    新置密码:
                </td>
                <td>
                    <input id="iptpwd" type="text" runat="server" class="clsunderline" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
