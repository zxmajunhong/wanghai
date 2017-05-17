<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="EtNet_Web.Pages.Index.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../CSS/colortip-1.0-jquery.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            padding: 0px;
            margin: 0px;
        }
        #top
        {
            background-image: url('../../Images/index/home.jpg');
            background-repeat: no-repeat;
            height: 110px;
            padding-top: 80px;
        }
        #topico
        {
            float: left;
        }
        .clsimg
        {
            display: inline-block;
            width: 55px;
            height: 25px;
            cursor: pointer;
        }
        #login
        {
            float: right;
            margin-top: 10px;
            margin-right: 40px;
            font-size: 12px;
            font-weight: bold;
            color: white;
        }
        #info div
        {
            color: red;
            font-weight: bold;
            font-size: 12px;
            width: 20px;
            margin-left: 8px;
            height: 14px;
            margin-top: 2px;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/colortip-1.0-jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            var getnum = function () {
                $.get("TopHandler.ashx", { sort: 1, dtime: new Date().toString() }, function (data) {
                    var json = window.eval("(" + data + ")");
                    $(".colorTip").remove();
                    $("#info div").html(json.total == 0 ? "" : json.total);
                    $("#info").attr("title", json.msg).colorTip({ color: "blue" });
                }, "text");
            }
            window.setInterval(getnum, 5000);


            //        //显示消息对话框
            //        function showdialog(txt, order) {
            //        $.messager.show({
            //        title: (order =="" ? '新消息提示': '消息提示' + order),
            //        msg: txt,
            //        timeout: 0,
            //        width: 300,
            //        height: 90,
            //        showType: 'slide'
            //        });
            //        }

            //        $.get("TopHandler.ashx", { sort: 3, dtime: new Date().toString() }, function (data) {
            //        var info = window.eval("(" + data + ")");
            //        for (var i = 0; i < info.count; i++) {
            //        showdialog(info.list[i].txt,  i + 1);
            //        }
            //        });


            //            
            //            
            //        var minfoid =  <%# MaxInfoId() %>;
            //           
            //        function newInfo()
            //        {         
            //        $.get("TopHandler.ashx", { sort:2, maxid:minfoid, dtime: new Date().toString() }, function (data) {         
            //        var info = window.eval("(" + data + ")");
            //              
            //        for (var i = 0; i < info.count; i++) {
            //        showdialog(info.list[i].txt,"");
            //        }
            //        minfoid = info.mid; 
            //        });
            //                
            //        }
            //           
            //            
            //        window.setInterval(newInfo, 2000);

            //            



            //        var infocycle = function () {
            //               
            //        $.get("TopHandler.ashx", { sort: 4, dtime: new Date().toString() }, function (data) {         
            //        var list = data.split('_');
            //        if(list[0] == "f")
            //        {                            
            //        window.setTimeout(infocycle,parseInt(list[1]));
            //        }
            //        else
            //        {
            //        var strmodal = "dialogHeight=200px;dialogWidth=620px;resizable=no;";
            //        strmodal += "status=no;";
            //        var vcycle = window.showModalDialog("../Information/InformationCycle.aspx?dt=" + new Date().toString(), window.self, strmodal);         
            //        window.setTimeout(infocycle,vcycle); 
            //        }
            //        });
            //        }
            //  
            //        window.setTimeout(infocycle, <%# InfoCycleSet() %>);




            //返回到主页
            $("#homepage").click(function () {
                window.open("Welcome.aspx?newmain=" + new Date().toString(), "mainFrame");
                return false;

            })



            //刷新
            $("#refresh").click(function () {
                window.parent.frames["mainFrame"].location.reload(true);
                return false;
            })



            //公告
            $("#messge").click(function () {
                window.parent.frames[3].location.replace("../Announcement/AnnouncementSearch.aspx");
                return false;

            })



            //日程
            $("#calendar").click(function () {
                window.parent.frames[3].location.replace("../../Calendar.aspx");
                return false;
            })

            $("#service").click(function () {
                var strmodal = "dialogHeight=140px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../SysSet/Service.aspx?dt=" + new Date().toString(), window.self, strmodal);
            })

            //更改密码
            $("#pwd").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../SysSet/ModifyLoginPwd.aspx?dt=" + new Date().toString(), window.self, strmodal);
            })

            //消息
            $("#info").click(function () {
                if (confirm("查看消息")) {
                    window.parent.frames[3].location.replace("../Information/ReceiveInformationShow.aspx");
                }
                return false;
            })
            //退出
            $("#exit").click(function () {
                if (confirm('确定退出')) {
                    $("#btnExit").click();
                    return true;
                }
            })

            //进入后台
            $("#houtai").click(function () {
                $("#btnhoutai").click();
                return true;
            })

            //            $("#help").click(function () {
            //                var str = "dialogWidth=270px;dialogHeight=400px;status=no";
            //                window.showModalDialog("../AddressList/AddressListSearch.aspx?dt=" + new Date().toString(), "", str);
            //                return false;
            //            })



        });

        
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <div id="top">
        <table id="topico">
            <tr>
                <td id="homepage" class="clsimg" style="background-image: url(../../Images/index/infobar_home1.png);"
                    title="主页">
                </td>
                <td id="refresh" class="clsimg" style="background-image: url(../../Images/index/infobar_refresh1.png);"
                    title="刷新">
                </td>
                <td id="messge" class="clsimg" style="background-image: url(../../Images/index/infobar_info1.png);"
                    title="公告">
                </td>
                <td id="info" class="clsimg" style="background-image: url(../../Images/index/infobar_msg1.png);"
                    title="消息">
                    <div>
                    </div>
                </td>
                <td id="pwd" class="clsimg" style="background-image: url(../../Images/index/infobar_psw1.png);
                    width: 80px" title="更改密码">
                </td>
                <td id="help" class="clsimg" style="background-image: url(../../Images/index/infobar_help1.png);"
                    title="帮助">
                </td>
                <td id="houtai" class="clsimg" style="background-image: url(../../Images/index/infobar_manage.png);
                    width: 82px;" title="后台" runat="server">
                </td>
                <td id="exit" class="clsimg" style="background-image: url(../../Images/index/infobar_quit1.png);"
                    title="退出">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div id="login" runat="server" style="font-family:微软雅黑;font-size:14px;">
        </div>
    </div>
    <!--功能区 -->
    <div>
        <asp:ImageButton ID="btnExit" runat="server" Width="0" Height="0" ImageUrl="~/Images/public/btn.png"
            OnClick="btnExit_Click" />
        <asp:ImageButton ID="btnhoutai" runat="server" Width="0" Height="0" ImageUrl="~/Images/public/btn.png"
            OnClick="btnhoutai_Click" />
    </div>
    </form>
</body>
</html>
