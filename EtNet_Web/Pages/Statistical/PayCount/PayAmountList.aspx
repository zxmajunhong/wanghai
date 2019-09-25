<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayAmountList.aspx.cs"
    Inherits="EtNet_Web.Pages.Statistical.PayCount.PayAmountList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>应付款汇总</title>
    <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
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
        .filterInput{width:200px;border-width:0px 0px 1px;border-style: none none solid;border-color: #C6E2FF;}
        input.Wdate{cursor:pointer;width:100px;border-width:0px 0px 1px;border-style: none none solid;border-color: #C6E2FF;}
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../../Scripts/customdate.js" type="text/javascript"></script>
    <script src="../../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=032&dt=" + new Date().toString(), window.self, strmodal);
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
                        应付款汇总
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
                <td style="width: 60px; text-align: right;">
                    支付单位:
                </td>
                <td>
                    <input type="text" runat="server" id="txtunit" class="clsunderline" />
                </td>
                <td style="width: 60px; text-align: right;">
                    未付金额:
                </td>
                <td>
                    <asp:DropDownList ID="ddlsyamount" runat="server" Width="200px">
                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                        <asp:ListItem Text="大于零" Value=">"></asp:ListItem>
                        <asp:ListItem Text="等于零" Value="="></asp:ListItem>
                        <asp:ListItem Text="小于零" Value="<"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <%--<td width="80px" align="right">收款时间：</td>
                    <td>
                        <asp:TextBox class="filterInput Wdate" ID="txtFilterSatrtTime" runat="server"
                            onFocus="var d5222=$dp.$('txtFilterEndTime');WdatePicker({onpicked:function(){txtFilterEndTime.focus();},maxDate:'#F{$dp.$D(\'txtFilterEndTime\')}'})"></asp:TextBox>
                        到
                        <asp:TextBox class="filterInput Wdate" ID="txtFilterEndTime" runat="server"
                            onFocus="WdatePicker({minDate:'#F{$dp.$D(\'txtFilterSatrtTime\')}'})"></asp:TextBox>
                    </td>--%>
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
        <table style="width: 100%">
            <tr>
                <td style="width: 100%; height: 25px; font-size: 25px; text-align: center">
                <asp:CheckBox ID="cbxFileShow" runat="server" Text="显示存档" Font-Size="16px" 
                        AutoPostBack="True" oncheckedchanged="cbxFileShow_CheckedChanged" Style="float:left;" />
                    应付款汇总表
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <tr>
                <th class="clstitleimg" style="width: 19%">
                    支付单位
                </th>
                <th class="clstitleimg" style="width: 9%">
                    订单数
                </th>
                <th class="clstitleimg" style="width: 9%">
                    成人数
                </th>
                <th class="clstitleimg" style="width: 9%">
                    儿童数
                </th>
                <th class="clstitleimg" style="width: 9%">
                    应付金额
                </th>
                <th class="clstitleimg" style="width: 9%">
                    已付金额
                </th>
                <th class="clstitleimg" style="width: 9%">
                    未付金额
                </th>
                <th class="clstitleimg" style="width: 9%">
                    应退金额
                </th>
                <th class="clstitleimg" style="width: 9%">
                    已退金额
                </th>
                <th class="clstitleimg" style="width: 9%">
                    未退金额
                </th>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="rptdata">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href="PayDetailList.aspx?unit=<%# Eval("factid")%>" >
                                    <%# Eval("supName")%></a>
                            </td>
                            <td>
                                <%# Eval("countNum")%>
                            </td>
                            <td>
                                <%# Eval("payNum")%>
                            </td>
                            <td>
                                <%# Eval("payChildNum")%>
                            </td>
                            <td>
                                <%# Eval("money")%>
                            </td>
                            <td>
                                <%# Eval("payAmount")%>
                            </td>
                            <td>
                                <%# Eval("syAmount")%>
                            </td>
                            <td>
                                <%# Eval("reMoney")%>
                            </td>
                            <td>
                                <%# Eval("reAmount")%>
                            </td>
                            <td>
                                <%# Eval("reSyAmount")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tr>
                <td>
                    合计：
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td id="shouldamount" runat="server" style="color:Green;">
                </td>
                <td id="hasamount" runat="server" style="color:Green;">
                </td>
                <td id="syamount" runat="server" style="color:Green;">
                </td>
                <td id="refundshouldamount" runat="server" style="color:Green;">
                </td>
                <td id="rehasamount" runat="server" style="color:Green;">
                </td>
                <td id="resyamount" runat="server" style="color:Green;">
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
