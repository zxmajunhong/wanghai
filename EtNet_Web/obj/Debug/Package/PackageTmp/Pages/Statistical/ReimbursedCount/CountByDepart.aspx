<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountByDepart.aspx.cs"
    Inherits="EtNet_Web.Pages.Statistical.ReimbursedCount.CountByDepart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报销统计</title>
    <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 40px 10px 40px;
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
                    $("#sifttxt img").attr("src", "../../../Images/public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", " ../../../Images/public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();

            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../../Images/public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");
                }
                else {
                    $("#sifttxt img").attr("src", "../../../Images/public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }

            })



            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=029&dt=" + new Date().toString(), window.self, strmodal);
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



        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hidsift" value="0" />
    <input type="hidden" runat="server" id="hidsort" value="" />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        报销统计
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage">
                            <img alt="页面编辑" src="../../../Images/Public/layoutedit.png" />
                            <span>页面设置</span> </span><span class="topimgtxt" id="sifttxt">
                                <img alt="筛选" src="../../../Images/public/expand.gif" />
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
                <td style="width: 60px;" align="right">
                    金额:
                </td>
                <td>
                    <input type="text" runat="server" id="txtje" class="clsunderline" />
                </td>
                <td style="width: 60px;" align="right">
                    项目类别:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlitem" CssClass="clsdatalist">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    发票内容:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddltype" CssClass="clsdatalist">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    支付状态:
                </td>
                <td>
                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="clsdatalist">
                        <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                        <asp:ListItem Text="——已支付——" Value="1"></asp:ListItem>
                        <asp:ListItem Text="——未支付——" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    报销人:
                </td>
                <td>
                    <asp:DropDownList ID="ddlperson" runat="server" CssClass="clsdatalist">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    部门:
                </td>
                <td>
                    <asp:DropDownList ID="ddldepart" runat="server" CssClass="clsdatalist">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    发生日期:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddldate" CssClass="clsdatalist">
                        <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                        <asp:ListItem Text="——今天——" Value="1"></asp:ListItem>
                        <asp:ListItem Text="——今天之前——" Value="2"></asp:ListItem>
                        <asp:ListItem Text="——昨天——" Value="3"></asp:ListItem>
                        <asp:ListItem Text="——7天内——" Value="4"></asp:ListItem>
                        <asp:ListItem Text="——15天内——" Value="5"></asp:ListItem>
                        <asp:ListItem Text="——指定范围——" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../../Images/public/calendar.png" id="selimgdt" style="cursor: pointer;"
                        alt="选取时间范围" />
                    <br />
                    <span id="customdate"></span>
                    <input type="hidden" runat="server" id="hidcdate" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <div id="depart" style="height: 25px; padding-bottom: 10px; width: 100%">
            <table>
                <tr>
                    <td style="width: 95%">
                        <span id="biaoti" style="height: 25px; padding-left: 400px; font-size: 25px;" runat="server">
                            报销费用-部门明细</span>
                    </td>
                    <td style="text-align: right;">
                        <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/Images/Button/btn_export.jpg"
                            OnClick="imgexport_Click" />
                    </td>
                    <td style="text-align: right;">
                        <asp:ImageButton runat="server" ID="back" ImageUrl="~/Images/Button/btn_back.jpg"
                            OnClick="back_Click" float="right" />
                    </td>
                </tr>
            </table>
        </div>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <tr>
                <td class="clstitleimg" style="width: 50px">
                    序号
                </td>
                <td class="clstitleimg" style="width: 100px">
                    发生日期
                </td>
                <td class="clstitleimg" style="width: 100px">
                    部门
                </td>
                <td class="clstitleimg" style="width: 100px">
                    报销人
                </td>
                <td class="clstitleimg" style="width: 100px">
                    项目类别
                </td>
                <td class="clstitleimg" style="width: 100px">
                    发票内容
                </td>
                <td class="clstitleimg" style="width: 100px">
                    金额
                </td>
                <td class="clstitleimg" style="width: 100px">
                    支付状态
                </td>
                <td class="clstitleimg">
                    备注
                </td>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="rptdata">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Container.ItemIndex + 1 %>
                            </td>
                            <td>
                                <%# showTime(Eval("happendate").ToString()) %>
                            </td>
                            <td>
                                <%# Eval("belongsort") %>
                            </td>
                            <td>
                                <%# Eval("salesman") %>
                            </td>
                            <td>
                                <%# Eval("ausname") %>
                            </td>
                            <td>
                                <%# Eval("austype") %>
                            </td>
                            <td>
                                <%# two(Eval("ausmoney").ToString()) %>
                            </td>
                            <td>
                                <%# Eval("payStatus").ToString() == "1" ? "<font color='green'>已支付</font>" : "<font color='red'>未支付</font>"%>
                            </td>
                            <td>
                                <%# Eval("remark") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                        合计：
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        <asp:Label ID="zje" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                </tr>
            </tbody>
        </table>
        <div runat="server" id="pages">
        </div>
    </div>
    </form>
</body>
</html>
