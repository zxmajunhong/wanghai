<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveInformationShow.aspx.cs"
    Inherits="EtNet_Web.Pages.Information.ReceiveInformationShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>接收的消息</title>
    <link href="../../Css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata
        {
            width: 100%;
            background-color: #B9D3EE;
        }
        .clsdata tr td
        {
            background-color: White;
            height: 30px;
            text-align: center;
        }
        .clssift
        {
            width: 100%;
        }
        .clsdatalist
        {
            width: 200px;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .clstitleimg:hover
        {
            color: Black;
        }
        .topbtnimg
        {
            width: 0px;
            height: 0px;
        }
        .topimgtxt
        {
            font-size: 12px;
            font-weight: bold;
            color: #718ABE;
            cursor: pointer;
            display: inline-block;
            margin-top: 4px;
            margin-right: 6px;
        }
        .topimgtxt img
        {
            height: 14px;
            width: 14px;
            margin-right: -6px;
            margin-bottom: -2px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .buttonStyle
        {
            background: url('../../Images/Common/buticon.gif');
            height: 22px;
            width: 64px;
            border: 0;
        }
        .clsfilehide
        {
            display: none;
        }
        .datebox
        {
            border: 0;
        }
        .combo-text
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsbtntxt
        {
            width: 80px;
            height: 20px;
            line-height: 20px;
            cursor: pointer;
            float: right;
            background: url('../../Images/public/btn.png');
            margin-right: 5px;
            text-align: center;
            border: 1px solid #4CB0D5;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/customdate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //页面显示设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=006&dt=" + new Date().toString(), window.self, strmodal);
            })


            //新增
            $("#addtxt").click(function () {
                window.location = "AddInformation.aspx";

            })


            //按照条件判断是否显示筛选栏
            function fist() {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();


            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");

                }
                else {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }
            })


            //指定时间
            $("#selimgdt").click(function () {
                cdate({ sid: "customdate", hid: "hidcdate" });
                $("#ddldate").val(6);
            })

            //选时间段
            $("#ddldate").change(function () {
                if ($(this).val() == "6") {
                    $("#selimgdt").click();
                }
                else {
                    $("#customdate").text("");
                    $("#hidcdate").val("");
                }
            })

            //删除选中数据项
            $("#btnalldel").click(function () {
                if ($(".clschkb :checked").length == 0) {
                    alert('未选中删除项');
                }
                else {
                    if (confirm('确定删除选中项')) {
                        $("#imgdel").click();
                    }
                }
            })

            //取消提醒
            $("#btnread").click(function () {
                if ($(".clschkb :checked").length == 0) {
                    alert('未选中任何项');
                }
                else {
                    if (confirm('确定对选中项取消提醒')) {
                        $("#imgread").click();
                    }
                }
            })


            //全选或全部选
            $("#btnchkdel").click(function () {
                if ($(".clschkb :checkbox").length == $(".clschkb :checked").length) {
                    $(".clschkb :checkbox").removeAttr("checked");
                }
                else {
                    $(".clschkb :checkbox").attr("checked", "checked");
                }
            })


            //取消提醒
            // $(".clslink").live("click", function () {
            //    var sid = $(this).attr("id").substr(8);
            //    $.get('Information.ashx', { noticeid: sid, msg: "remind" }, function (data) { 
            //   })      
            // })

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidsift" runat="server" value="0" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt" style="">
                        接收消息管理
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage">
                            <img alt="页面编辑" src="../../Images/public/layoutedit.png" />
                            <span>页面编辑</span> </span><span class="topimgtxt" id="sifttxt">
                                <img alt="筛选" />
                                <span>筛选</span> </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td style="width: 60px">
                    发送人:
                </td>
                <td style="width: 240px;">
                    <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddlsend">
                    </asp:DropDownList>
                </td>
                <td style="width: 60px;">
                    分类:
                </td>
                <td style="width: 240px;">
                    <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddlsort">
                    </asp:DropDownList>
                </td>
                <td style="width: 60px;">
                    接收时间:
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddldate">
                        <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                        <asp:ListItem Text="——今天——" Value="1"></asp:ListItem>
                        <asp:ListItem Text="——今天之前——" Value="2"></asp:ListItem>
                        <asp:ListItem Text="——昨天——" Value="3"></asp:ListItem>
                        <asp:ListItem Text="——7天内——" Value="4"></asp:ListItem>
                        <asp:ListItem Text="——15天内——" Value="5"></asp:ListItem>
                        <asp:ListItem Text="——指定范围——" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../Images/Public/calendar.png" id="selimgdt" style="cursor: pointer;"
                        alt="选取时间范围" />
                    <br />
                    <span id="customdate"></span>
                    <input type="hidden" runat="server" id="hidcdate" />
                </td>
            </tr>
            <tr>
                <td colspan="6" align="right">
                    <asp:ImageButton ID="ibtnsearch" runat="server" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="ibtnsearch_Click" />
                    <asp:ImageButton ID="ibtnreset" runat="server" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="ibtnreset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <thead>
                <tr>
                    <td class="clstitleimg" style="width: 40px;"></td>                 
                    <td class="clstitleimg" style="width: 100px;">
                        发送方
                    </td>
                    <td class="clstitleimg" style="width: 150px;">
                        接收时间
                    </td>
                    <td class="clstitleimg" style="width: 100px;">
                        分类
                    </td>
                    <td class="clstitleimg">
                        内容
                    </td>
                    <td class="clstitleimg" style="width:80px;">
                        阅读状态
                    </td>
                    <td class="clstitleimg" style="width:80px;">
                        消息附件
                    </td>
                    <td class="clstitleimg" style="width:80px;">
                        操作
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptinformation" runat="server" OnItemCommand="rptinformation_ItemCommand">
                    <ItemTemplate>
                        <tr style='<%# Eval("remind").ToString() == "是"?"font-weight:bold;": ""%>'>
                            <td>
                                <asp:CheckBox CssClass="clschkb" runat="server" />
                            </td>
                            <td>
                                <%# Eval("cname") %>
                            </td>
                            <td>
                                <%# Eval("sendtime") %>
                            </td>
                            <td>
                                <%# Eval("txt").ToString()%>
                            </td>
                            <td style="text-align: left;">
                                <%# CommonlyUsed.Conversion.StrConversion(Eval("contents").ToString()) + LinkItem(int.Parse(Eval("sortid").ToString()), int.Parse(Eval("associationid").ToString()), int.Parse(Eval("id").ToString()))%>
                            </td>
                            <td style='<%# Eval("remind").ToString() == "是"?"color:Red;": ""%>'>
                                <%#  ReadStatus(Eval("remind").ToString()) %>
                            </td>
                            <td>
                                <asp:ImageButton runat="server" title="查看附件" CommandName="filelook" CommandArgument='<%# Eval("informationid") %>'
                                    ImageUrl="~/Images/public/lookfile.gif" />
                                <img class='<%# clsfile( Eval("informationid").ToString()) %>' alt="附件" src="../../Images/public/enclosure.png" />
                            </td>
                            <td>
                                <asp:ImageButton runat="server" title="取消提醒,阅读状态更改为已读" CommandName="remind" CommandArgument='<%# Eval("id") %>'
                                    ImageUrl="~/Images/public/fprojects.png" />
                                <asp:ImageButton runat="server" title="回复" CommandName="reply" CommandArgument='<%# Eval("id") %>'
                                    ImageUrl="~/Images/public/reply.png" />
                                <asp:ImageButton runat="server" title="删除" OnClientClick=" return confirm('确定删除');"
                                    CommandName="del" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/delete.gif" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="8" style="text-align: right;">
                        <div id="btnread"   class="clsbtntxt">取消提醒</div>
                        <div id="btnalldel" class="clsbtntxt">
                            删除选中项</div>
                        <div id="btnchkdel" class="clsbtntxt" title="全部选中时点击将取消所有选中项">
                            全选/全不选</div>
                    </td>
                </tr>
            </tfoot>
        </table>
        <div id="pages" runat="server">
        </div>
    </div>
    <!-- 功能按钮隐藏区-->
    <div>
        <asp:ImageButton runat="server" ID="imgdel" Width="0" Height="0" ImageUrl="~/Images/public/btn.png"
            OnClick="imgdel_Click" />
        <asp:ImageButton runat="server" ID="imgread" Width="0" Height="0" ImageUrl="~/Images/Public/btn.png"  onclick="imgread_Click" />

    </div>
    </form>
</body>
</html>
