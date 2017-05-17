<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EtNet_Web.Login" %>

<%@ Register Assembly="Vincent.AutoAuthCode" Namespace="Vincent.AutoAuthCode" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>登录页面</title>
    <style type="text/css">
        #Layer1
        {
            position: absolute;
            width: 293px;
            height: 142px;
            z-index: 1;
            left: 2px;
            top: 68px;
        }
        #Layer2
        {
            position: absolute;
            width: 416px;
            height: 15px;
            z-index: 5;
            left: 61%;
            top: 458px;
        }
        #Layer4
        {
            position: absolute;
            width: 366px;
            height: 115px;
            z-index: 1;
            left: 245px;
            top: 396px;
        }
        #Layer5
        {
            position: absolute;
            width: 548px;
            height: 27px;
            z-index: 2;
            left: 102px;
            top: 374px;
        }
        #Layer6
        {
            position: absolute;
            width: 137px;
            height: 135px;
            z-index: 3;
            left: 87px;
            top: 412px;
        }
        #Layer7
        {
            position: absolute;
            width: 370px;
            height: 436px;
            z-index: 4;
            left: 60%;
            top: 111px;
        }
        #Layer8
        {
            position: absolute;
            width: 135px;
            height: 37px;
            z-index: 5;
            left: 82px;
            top: 186px;
        }
        .td
        {
            height: 30px;
        }
        .style1
        {
            height: 32px;
            width: 62px;
        }
        
        .ButtonStyle
        {
            border: 1px;
            border-color: #7F9DB9;
            border-style: solid;
            height: 20px;
        }
        
        #msg
        {
            width: 412px;
        }
        .tdmsg
        {
            border-bottom: 1px dashed #aaccff;
            font-size: 14px;
        }
        .tdmsg img
        {
            vertical-align: middle;
        }
    </style>
    <script src="Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">


        $(function () {
            $("#ibtnLogin").click(function () {

                var rg = /[^\w]/g;
                var str = "";
                if (rg.test($("#txtLoginId").val()) || rg.test($("#txtPwd").val())) {
                    str = "用户名与密码有误,请注意不要输入空格!<br/>";
                }
                if (str) {
                    alert(str);
                    return false;
                }
                else {
                    return true;
                }

            });


            var list = <%# GetMsgData() %>

            function msg() {
               debugger;
                if(list.length == 0)
                {
                  return;
                }
                var len = list.length > 5 ? 5 : list.length;
                var str = ""
                $("#msg").empty();

                for (var i = 0; i < len; i++) {
                   
                    str += "<tr><td class='tdmsg'> <img src='Images/login/qh_32.jpg' />";
                    str += list[i] + "</td></tr>";
                    $(str).appendTo($("#msg"));
                    str = "";
                }
                list.push(list.shift());

            }

            msg()

           var setmsg = setInterval(msg, 1000);


            $("#msg").mouseover(function(){
               
               clearInterval(setmsg);
              
            })

            $("#msg").mouseout(function(){
              setmsg = setInterval(msg, 1000);
            })

            window.onload = function () {
                if (self != top) {
                    top.location = self.location;
                }
            }

        });
    </script>
</head>
<body background="Images/login/bg1.jpg" style="background-attachment: fixed; background-repeat: no-repeat">
    <form id="myform" runat="server">
    <div style="background-image: Images/login/bg1.jpg; width: 100%">
        <div id="Layer7" style="background-image: url(Images/login/login_box1.png); background-repeat: no-repeat;">
            <div id="Layer1">
                <table align="left" style="width: 100%;">
                    <tr>
                        <td class="style1" style="font-size: 13px; font-family: 黑体; font-weight: bold;">
                            &nbsp; 用户名
                        </td>
                        <td>
                            <asp:TextBox ID="txtLoginId" runat="server" Width="150px" CssClass="ButtonStyle"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" style="font-size: 13px; font-family: 黑体; font-weight: bold;">
                            &nbsp; 密 码
                        </td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" Width="150px" TextMode="Password" CssClass="ButtonStyle"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="codeBox" runat="server">
                        <td class="style1" style="font-size: 13px; font-family: 黑体; font-weight: bold;">
                            &nbsp; 验证码
                        </td>
                        <td>
                            <cc2:AuthCode ID="AuthCode1" runat="server" NextImgText="" CodeStringType="LowerLetter" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Layer8">
                <asp:ImageButton ID="ibtnLogin" runat="server" ImageUrl="Images/login/login_btn.png"
                    OnClick="ibtnLogin_Click"/></div>
        </div>
        <div id="Layer2" style="font-size: 13px; font-weight: normal; line-height: 20px;
            color: #313131;">
            <asp:Literal ID="LtrCopyRight" runat="server">
              
            </asp:Literal>
        </div>
        <div id="Layer5" style="background-image: url(Images/login/tit_news.png); z-index: 100;
            background-repeat: no-repeat;">
            <div style="margin-left: 110px; margin-top: 20px;">
                <table id="msg">
                </table>
            </div>
        </div>
        <div id="Layer6" style="background-image: url(Images/login/ico.png); background-repeat: no-repeat;">
        </div>
    </div>
    </form>
</body>
</html>
