<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrossList.aspx.cs" Inherits="EtNet_Web.Pages.Statistical.Grossprofit.GrossList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>毛利表</title>
    <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
    <link href="../../../Scripts/simpletooltip/style-simpletooltip-min.css" rel="stylesheet"
        type="text/css" />
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
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/simpletooltip/jquery-simpletooltip-min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../../Scripts/customdate.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $.simpletooltip();
        });
    </script>
    <script type="text/javascript">
        $(function () {

            $(window).load(function () {
                debugger;
                $("#sDiv").width($("#a1").width());
            })

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


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
                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=036&dt=" + new Date().toString(), window.self, strmodal);
            })

            //导出
            $("#daochu").click(function () {
                $("#daochu1").click();
            })

            //指定时间
            $("#selDate").click(function () {
                cdate({ sid: "dateBox", hid: "hidDateValue" });
                $("#ddlRequestDate").val(5);
            })

            //选时间段
            $("#ddlRequestDate").change(function () {
                if ($(this).val() == "5") {
                    $("#selDate").click();
                }
                else {
                    $("#dateBox").text("");
                    $("#hidDateValue").val("");
                }
            })
        })


        // 查看订单信息
        function getOrder(orderId) {
            if (orderId != "")
                window.open('../../Order/OrderDetial.aspx?id=' + orderId);
            else
                alert('参数错误，找不到该订单');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hidsift" value="0" />
    <input type="hidden" runat="server" id="hidsort" value="" />
    <asp:Button ID="daochu1" runat="server" Text="daochu" style=" display:none;"
        onclick="daochu1_Click"  />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        毛利统计表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage">
                            <img alt="页面编辑" src="../../../Images/Public/layoutedit.png" />
                            <span>页面设置</span> </span><span class="topimgtxt" id="sifttxt">
                                <img alt="筛选" src="../../../Images/public/expand.gif" />
                                <span>筛选</span> </span><span class="topimgtxt" id="daochu">
                                <img alt="导出" src="../../../Images/public/tablesave.png" />
                                <span>导出</span> </span>
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
                <td style="width: 80px; text-align: right;">
                    订单编号:
                </td>
                <td>
                    <input type="text" runat="server" id="txtOrderNum" class="clsunderline" />
                </td>
                <td style="width: 80px; text-align: right;">
                    线路:
                </td>
                <td>
                    <asp:DropDownList ID="ddlline" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="width: 80px; text-align: right;">
                    地区:
                </td>
                <td>
                    <input type="text" runat="server" id="txtDepart" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px; text-align: right;">
                    散团:
                </td>
                <td>
                    <asp:DropDownList Width="200" ID="ddlnature" runat="server">
                        <asp:ListItem Text="——请选择——"></asp:ListItem>
                        <asp:ListItem Text="团队" Value="团队"></asp:ListItem>
                        <asp:ListItem Text="散客" Value="散客"></asp:ListItem>
                        <asp:ListItem Text="代订业务" Value="代订业务"></asp:ListItem>
                        <asp:ListItem Text="其他" Value="其他"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 80px; text-align: right;">
                    出团日期:
                </td>
                <td>
                    <asp:DropDownList ID="ddlRequestDate" Width="200px" runat="server">
                        <asp:ListItem Value="-1">——请选择——</asp:ListItem>
                        <asp:ListItem Value="0">——今天——</asp:ListItem>
                        <asp:ListItem Value="1">——今天之前——</asp:ListItem>
                        <asp:ListItem Value="2">——昨天——</asp:ListItem>
                        <asp:ListItem Value="3">——7天内——</asp:ListItem>
                        <asp:ListItem Value="4">——15天内——</asp:ListItem>
                        <asp:ListItem Value="5">——指定范围——</asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../../Images/public/calendar.png" id="selDate" style="cursor: pointer;"
                        alt="选取时间范围" /><br />
                    <span id="dateBox"></span>
                    <input id="hidDateValue" type="hidden" runat="server" />
                </td>
                <td style="width: 80px; text-align: right;">
                    操作人员:
                </td>
                <td>
                    <asp:DropDownList Width="200" ID="ddlinputer" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 80px; text-align: right;">
                    收款状态:
                </td>
                <td>
                    <asp:DropDownList ID="ddlcollectstatus" Width="200px" runat="server">
                        <asp:ListItem Value="请选择">——请选择——</asp:ListItem>
                        <asp:ListItem Value="未收款">——未收款——</asp:ListItem>
                        <asp:ListItem Value="部分收款">——部分收款——</asp:ListItem>
                        <asp:ListItem Value="完成收款">——完成收款——</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="4" style="text-align: right">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr>
                <td style="width: 100%; height: 25px; font-size: 25px; text-align: center">
                <asp:CheckBox ID="cbxFileShow" runat="server" Text="显示存档" Font-Size="16px" 
                        AutoPostBack="True" oncheckedchanged="cbxFileShow_CheckedChanged" Style="float:left;" />
                    毛利统计表
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0" id="flexigrid" runat="server">
            <tr>
                <td colspan="11" id="a1" style="width: 100%;">
                    <div id="sDiv" style="overflow-x: auto; overflow-y: auto; width: 1000px; margin-right: 0px;">
                        <table cellpadding="0" cellspacing="1" border="0" style="width: 2000px;" id="table">
                            <tr>
                                <th class="clstitleimg" width="110">
                                    订单编号
                                </th>
                                <th class="clstitleimg" width="100">
                                    线路
                                </th>
                                <th class="clstitleimg" width="100">
                                    出团日期
                                </th>
                                <th class="clstitleimg" width="60">
                                    地区
                                </th>
                                <th class="clstitleimg" width="80">
                                    清欠
                                </th>
                                <th class="clstitleimg" width="60">
                                    联字号
                                </th>
                                <th class="clstitleimg" width="80">
                                    散团
                                </th>
                                <th class="clstitleimg" width="200">
                                    团队总数
                                </th>
                                <th class="clstitleimg" width="100">
                                    操作员
                                </th>
                                <th class="clstitleimg" width="90">
                                    应收团款
                                </th>
                                <th class="clstitleimg" width="90">
                                    已收团款
                                </th>
                                <th class="clstitleimg" width="90">
                                    未收团款
                                </th>
                                <th class="clstitleimg" width="90">
                                    收款状态
                                </th>
                                <th class="clstitleimg" width="90">
                                    应付金额
                                </th>
                                <th class="clstitleimg" width="90">
                                    已付金额
                                </th>
                                <th class="clstitleimg" width="90">
                                    未付金额
                                </th>
                                <th class="clstitleimg" width="90">
                                    应退金额
                                </th>
                                <th class="clstitleimg" width="90">
                                    已退金额
                                </th>
                                <th class="clstitleimg" width="90">
                                    未退金额
                                </th>
                                <th class="clstitleimg" width="90">
                                    报销金额
                                </th>
                                <th class="clstitleimg" width="90">
                                    毛利
                                </th>
                            </tr>
                            <tbody>
                                <asp:Repeater ID="rpgrossdata" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" onclick="getOrder('<%# Eval("id") %>')">
                                                    <%# Eval("orderNum")%></a>
                                            </td>
                                            <td>
                                                <%# Eval("line")%>
                                            </td>
                                            <td>
                                                <%# Convert.ToDateTime(Eval("outTime")).ToString("yyyy-MM-dd")%>
                                            </td>
                                            <td>
                                                <%# Eval("departautocode")%>
                                            </td>
                                            <td>
                                                <%# Eval("auditstutastxt")%>
                                            </td>
                                            <td>
                                                <%# Eval("codenum")%>
                                            </td>
                                            <td>
                                                <%# Eval("natrue")%>
                                            </td>
                                            <td>
                                                <%# Eval("teamNum")%>
                                            </td>
                                            <td>
                                                <%# Eval("inputer")%>
                                            </td>
                                            <td class="simpletooltip left-bottom pastelblue" title="<%# getCollectDetail(Eval("id")) %>"
                                                style="color: Blue">
                                                <%# Eval("collectShould")%>
                                            </td>
                                            <td>
                                                <%# Eval("collectAmount")%>
                                            </td>
                                            <td>
                                                <%# Eval("collectSy")%>
                                            </td>
                                            <td>
                                                <%# Eval("collectStatus")%>
                                            </td>
                                            <td class="simpletooltip left-bottom pastelblue" title="<%# getPayDetail(Eval("id")) %>"
                                                style="color: Blue">
                                                <%# Eval("payShould")%>
                                            </td>
                                            <td>
                                                <%# Eval("payAmount")%>
                                            </td>
                                            <td>
                                                <%# Eval("paySy")%>
                                            </td>
                                            <td class="simpletooltip left-bottom pastelblue" title="<%# getRefDetail(Eval("id")) %>"
                                                style="color: Blue">
                                                <%# Eval("refuShould")%>
                                            </td>
                                            <td>
                                                <%# Eval("refundAmount")%>
                                            </td>
                                            <td>
                                                <%# Eval("refuSy")%>
                                            </td>
                                            <td class="simpletooltip left-bottom pastelblue" title="<%# getReimDetail(Eval("id")) %>">
                                                <%# Eval("reimShould")%>
                                            </td>
                                            <td>
                                                <%# Eval("gross_bx")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="11" style="font-size:20px;text-align:center">
                    毛利表金额合计
                </td>
            </tr>
            <tr>
                <td>
                    应收团款
                </td>
                <td>
                    已收团款
                </td>
                <td>
                    未收团款
                </td>
                <td>
                    应付金额
                </td>
                <td>
                    已付金额
                </td>
                <td>
                    未付金额
                </td>
                <td>
                    应退金额
                </td>
                <td>
                    已退金额
                </td>
                <td>
                    未退金额
                </td>
                <td>
                    报销金额
                </td>
                <td>
                    毛利
                </td>
            </tr>
            <tr>
                <td id="scshould" runat="server">
                    
                </td>
                <td id="scamount" runat="server">

                </td>
                <td id="scsy" runat="server">

                </td>
                <td id="spshould" runat="server">

                </td>
                <td id="spamount" runat="server">

                </td>
                <td id="spsy" runat="server">

                </td>
                <td id="srshould" runat="server">

                </td>
                <td id="sramount" runat="server">

                </td>
                <td id="srsy" runat="server">

                </td>
                <td id="sbx" runat="server">

                </td>
                <td id="sml" runat="server">

                </td>
            </tr>
        </table>
    </div>
    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
        runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
        PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
        CustomInfoTextAlign="Left" LayoutType="Table" PageIndexBoxType="DropDownList"
        ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
    </webdiyer:AspNetPager>
    </form>
</body>
</html>
