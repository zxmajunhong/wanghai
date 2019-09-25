<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthCount.aspx.cs" Inherits="EtNet_Web.Pages.Statistical.ReimbursedCount.MonthCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门月度累计</title>
    <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 10px 10px 10px;
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
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
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
            padding-left: 2px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .buttonStyle
        {
            background: url('../../../Images/Common/buticon.gif');
            height: 22px;
            width: 64px;
            border: 0;
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
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../../Scripts/customdate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //新增
            $("#addtxt").click(function () {
                window.location = "AnnouncementAdd.aspx";
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



            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                document.getElementById
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=025&dt=" + new Date().toString(), window.self, strmodal);
            })


            //指定时间
            $("#selimgdt").click(function () {
                cdate({ sid: "customdate", hid: "hidcdate" });
                $("#ddldate").val(4);
            })

            //选时间段
            $("#ddldate").change(function () {
                if ($(this).val() == "4") {
                    $("#selimgdt").click();
                }
                else {
                    $("#customdate").text("");
                    $("#hidcdate").val("");
                }
            })



        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hidsift" value="0" />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        部门月度累计
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div style="text-align: right; width: 99%">
            <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/Images/Button/btn_export.jpg"
                OnClick="imgexport_Click" />
        </div>
    <div class="clsbottom">
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <tr>
                <td class="clstitleimg" style="width: 100px">
                    <asp:DropDownList runat="server" ID="selectyear" OnSelectedIndexChanged="selectyear_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>

                <td class="clstitleimg" style="width: 50px">
                    一月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    二月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    三月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    四月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    五月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    六月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    七月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    八月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    九月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    十月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    十一月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    十二月
                </td>
                <td class="clstitleimg" style="width: 50px">
                    部门_月
                </td>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="rptdata">
                    <ItemTemplate>
                        <tr>
                            <%--<td>
                                <a href="../../Job/ReimbursedForm/AddReimbursedForm.aspx"><%# Container.ItemIndex + 1 %></a>
                            </td>--%>
                            <td>
                                <%# Eval("departtxt") %>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("1")%>">
                                    <%# getje(Eval("1").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("2")%>">
                                    <%# getje(Eval("2").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("3")%>">
                                    <%# getje(Eval("3").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("4")%>">
                                    <%# getje(Eval("4").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("5")%>">
                                    <%# getje(Eval("5").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("6")%>">
                                    <%# getje(Eval("6").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("7")%>">
                                    <%# getje(Eval("7").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("8")%>">
                                    <%# getje(Eval("8").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("9")%>">
                                    <%# getje(Eval("9").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("10")%>">
                                    <%# getje(Eval("10").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("11")%>">
                                    <%# getje(Eval("11").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("12")%>">
                                    <%# getje(Eval("12").ToString()) %></a>
                            </td>
                            <td>
                                <a href="CountByDepart.aspx?args=<%# Eval("13")%>">
                                    <%# getje(Eval("13").ToString()) %></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
            </tbody>
        </table>
        <div runat="server" id="pages">
        </div>
    </div>
    </form>
</body>
</html>
