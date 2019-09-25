<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordList.aspx.cs" Inherits="EtNet_Web.Pages.Financial.InvoiceRecord.RecordList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开票记录列表</title>
    <link href="../../../Styles/page.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            background: none #FFF;
            font-family: 宋体;
            min-width: 880px;
            width: expression_r(document.body.clientWidth > 880? "880px": "auto" );
            overflow-x: hidden;
        }
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 20px 10px 20px;
        }
        .titlebtncls
        {
            position: absolute;
            right: 40px;
            margin-top: 5px;
        }
        .titlebtncls a
        {
            font-size: 12px;
            font-weight: bold;
            margin-right: 0px;
            color: #718ABE;
            cursor: pointer;
            text-decoration: none;
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
            background-image: url('../../../Images/Public/list_tit.png');
            color: White;
            height: 25px;
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
        .clsbtntxt
        {
            width: 80px;
            height: 20px;
            line-height: 20px;
            cursor: pointer;
            float: right;
            background: url('../../Images/Public/btn.png');
            margin-right: 5px;
            text-align: center;
            border: 1px solid #4CB0D5;
        }
    </style>
    <script src="../../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/plugins/iframeTools.source.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../../Scripts/customdate.js" type="text/javascript"></script>
    <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            /*
            //全选或全部选
            $("#btnchkdel").click(function () {
            if ($(".clschkb :checkbox").length == $(".clschkb :checked").length) {
            $(".clschkb :checkbox").removeAttr("checked");
            }
            else {
            $(".clschkb :checkbox").attr("checked", "checked");
            }
            })
            */

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
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=032&dt=" + new Date().toString(), window.self, strmodal);
            });

            /*选择时间*/
            $("#selDate").click(function () {
                cdate({ sid: "dateBox", hid: "hidInvoiceDate" });
                $("#ddlInvoiceDate").val(5);
            })

            /*选时间段*/
            $("#ddlInvoiceDate").change(function () {
                if ($(this).val() == "5") {
                    $("#selDate").click();
                }
                else {
                    $("#dateBox").text("");
                    $("#hidInvoiceDate").val("");
                }
            })

            /*选择时间*/
            $("#selDate1").click(function () {
                cdate({ sid: "dateBox1", hid: "hidMakeDate" });
                $("#ddlMakeDate").val(5);
            })

            /*选时间段*/
            $("#ddlMakeDate").change(function () {
                if ($(this).val() == "5") {
                    $("#selDate1").click();
                }
                else {
                    $("#dateBox1").text("");
                    $("#hidMakeDate").val("");
                }
            })

            /*新增开票记录*/
            $("#addtxt").click(function () {
                window.location.href = "AddRecord.aspx";
            });

            /*
            $("#btnread").click(function () {
            if ($(".clschkb :checked").length == 0) {
            alert('未选中任何项');
            }
            else {
            if (confirm('确定对选中项进行确认')) {
            $("#imgread").click();
            }
            }
            })
            */
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" value="0" id="hidsift" />
    <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <table style="width: 100%;">
            <tr>
                <td class="toptitletxt">
                    开票记录
                </td>
                <td style="text-align: right; padding-right: 20px;">
                    <span class="topimgtxt" id="editpage" title="页面设置">
                        <img alt="页面编辑" title="页面设置" src="../../../Images/public/layoutedit.png" />&nbsp;<span>页面设置</span></span>
                    <span class="topimgtxt" id="addtxt" title="新增">
                        <img alt="新增" title="新增" src="../../../Images/public/pagedit.png" />&nbsp;<span>新增</span>
                    </span><span class="topimgtxt" id="sifttxt" title="筛选">
                        <img alt="筛选" title="筛选" src="../../../Images/public/collapse.gif" />&nbsp;<span>筛选</span>
                    </span>
                </td>
            </tr>
        </table>
    </div>
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td align="right" style="width: 80px;">
                    开票日期:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlInvoiceDate" Width="200px" runat="server">
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
                    <input id="hidInvoiceDate" type="hidden" runat="server" />
                </td>
                <td align="right" style="width: 80px;">
                    付款单位:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtUnit" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px;">
                    登记日期:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlMakeDate" Width="200px" runat="server">
                        <asp:ListItem Value="-1">——请选择——</asp:ListItem>
                        <asp:ListItem Value="0">——今天——</asp:ListItem>
                        <asp:ListItem Value="1">——今天之前——</asp:ListItem>
                        <asp:ListItem Value="2">——昨天——</asp:ListItem>
                        <asp:ListItem Value="3">——7天内——</asp:ListItem>
                        <asp:ListItem Value="4">——15天内——</asp:ListItem>
                        <asp:ListItem Value="5">——指定范围——</asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../../Images/public/calendar.png" id="selDate1" style="cursor: pointer;"
                        alt="选取时间范围" /><br />
                    <span id="dateBox1"></span>
                    <input id="hidMakeDate" type="hidden" runat="server" />
                </td>
                <td align="right" style="width: 80px;">
                    登记人:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlMakeMan" Width="200px" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0" width="100%">
            <tr>
                <th class="clstitleimg" style="width: 10%;">
                    开票日期
                </th>
                <th class="clstitleimg" style="width: 10%;">
                    登记日期
                </th>
                <th class="clstitleimg" style="width: 10%;">
                    登记人
                </th>
                <th class="clstitleimg" style="width: 25%;">
                    付款单位
                </th>
                <th class="clstitleimg" style="width: 10%;">
                    开票金额
                </th>
                <th class="clstitleimg" style="width: 25%;">
                    开票备注
                </th>
                <th class="clstitleimg" style="width: 10%;">
                    操作
                </th>
            </tr>
            <tbody>
                <asp:Repeater ID="payRepeater" runat="server" OnItemCommand="payRepeater_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("recordDate", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <%# Eval("makeDate", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <%# Eval("makeMan")%>
                            </td>
                            <td>
                                <%# Eval("cusName") %>
                            </td>
                            <td>
                                <%# Eval("amount", "{0:N2}")%>
                            </td>
                            <td>
                                <%# Eval("makeRemark")%>
                            </td>
                            <td>
                                <asp:ImageButton ID="ibtEdit" runat="server" title="编辑" CommandName="edit" CommandArgument='<%#Eval("Id") %>'
                                    ImageUrl="~/Images/public/edit.gif" />
                                <asp:ImageButton ID="ibtSearch" runat="server" title="查看" CommandName="search" CommandArgument='<%#Eval("Id") %>'
                                    ImageUrl="~/Images/public/searchform.png" />
                                <asp:ImageButton ID="ibtDel" runat="server" title="删除" CommandName="del" CommandArgument='<%#Eval("Id") %>'
                                    OnClientClick="return window.confirm('确认删除吗?');" ImageUrl="~/Images/public/delete.gif" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
            PageSize="5" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
            OnPageChanged="AspNetPager1_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
            CustomInfoHTML="" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PagingButtonLayoutType="Span">
        </webdiyer:AspNetPager>
    </div>
    <!-- 功能按钮隐藏区-->
    <div>
        <asp:ImageButton runat="server" ID="imgread" Width="0" Height="0" ImageUrl="~/Images/Public/btn.png"
            OnClick="imgread_Click" />
    </div>
    </form>
</body>
</html>
