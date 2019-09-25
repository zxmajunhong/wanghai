<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentList.aspx.cs" Inherits="EtNet_Web.Pages.Financial.PaymentList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Policy/flexigrid.js" type="text/javascript"></script>
    <link href="../Policy/flexigrid.css" rel="stylesheet" type="text/css" />
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/customdate.js" type="text/javascript"></script>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            background: none #FFF;
            font-family: 宋体;
            min-width: 880px;
            width: expression_r(document.body.clientWidth > 880? "880px": "auto" );
            overflow-x: hidden;
        }
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            border-top-width: 4px;
            padding: 10px 0px 0px 0px;
        }
        .border, #contable, #contable table
        {
            width: 100%;
        }
        .sortable th
        {
            height: 24px;
            text-align: center;
        }
        .sortable td
        {
            text-align: center;
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
        tr.odd td, .oddrow td
        {
            background-color: #E3EBEF;
        }
        #scol
        {
            background: url(../../Images/public/common_bg.gif) no-repeat;
            width: 104px;
            height: 25px;
            display: inline-block;
        }
        .nDiv
        {
            z-index: 9999999999999999999999999;
        }
        #form1 .border .desc div
        {
            background: url(../../Images/public/dn.png) 7px center no-repeat;
            cursor: pointer;
        }
        #form1 .border .asc div
        {
            background: url(../../Images/public/up.png) 7px center no-repeat;
            cursor: pointer;
        }
        #form1 .border .act
        {
            background: url(../../Images/public/actived_bg.gif) no-repeat;
        }
        #siftbox
        {
            display: none;
        }
        a img
        {
            border: none;
        }
        a
        {
            text-decoration: none;
        }
        .paginator
        {
            font: 12px Arial, Helvetica, sans-serif;
            padding: 5px;
            margin: 0px;
        }
        .paginator a
        {
            border: solid 1px #ccc;
            color: #0063dc;
            cursor: pointer;
            text-decoration: none;
        }
        .paginator a:visited
        {
            padding: 1px 6px;
            border: solid 1px #61befe;
            background: #61befe;
            color: #fff;
            text-decoration: none;
        }
        .paginator .cpb
        {
            border: 1px solid #61befe;
            font-weight: 700;
            color: #fff;
            background-color: #61befe;
        }
        .paginator a:hover
        {
            border: solid 1px #61befe;
            color: #fff;
            background: #61befe;
            text-decoration: none;
        }
        .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover
        {
            float: left;
            height: 21px;
            line-height: 21px;
            min-width: 10px;
            _width: 10px;
            margin-right: 5px;
            text-align: center;
            white-space: nowrap;
            font-size: 12px;
            font-family: Arial,SimSun;
            padding: 0 4px;
        }
        .titlebtncls img
        {
            height: 14px;
            width: 14px;
            margin-right: 0px;
            margin-bottom: -2px;
        }
        .filterBox
        {
            border-bottom: 2px solid #4CB0D5;
            width: 100%;
            height: auto;
            padding: 5px;
            margin-bottom: 10px;
        }
        .filterBox td
        {
            padding: 4px 0px 5px 0px;
        }
        .filterInput
        {
            width: 200px;
        }
        input.filterInput
        {
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        input.Wdate
        {
            width: 100px;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        select#ddlFilterPolicyState
        {
            width: 200px;
        }
        input.Wdate
        {
            cursor: pointer;
        }
        .lnkEdit
        {
            text-decoration: underline;
        }
        td.op, td.op div
        {
            text-align: left !important;
        }
        .buttonStyle
        {
            background: url('../../Images/Common/buticon.gif');
            height: 22px;
            width: 64px;
            border: 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".sortable tbody>tr:odd").addClass("odd");
            $('#flexigrid').flexigrid({ height: 'auto', width: 'auto', striped: false });
            $('#scol').click(function () {
                var p = document.getElementById('scol');
                $('.nDiv').show().offset({ top: p.offsetTop + p.offsetHeight, left: document.body.clientWidth - $('.nDiv').width() });
                $(this).addClass('act');
            });
            $('.nDiv').hover
            (
                function () {
                    var p = document.getElementById('scol');
                    $('.nDiv').offset({ top: p.offsetTop + p.offsetHeight, left: document.body.clientWidth - $('.nDiv').width() }).show();
                },
                function () {
                    $('.nDiv').hide();
                }
            );
            //            $('.nDiv').mouseleave(function () {
            //                $('#scol').removeClass('act');
            //            });
            //            $('.flexigrid').mouseenter(function () {
            //                $('#scol').removeClass('act');
            //            });

            setFilterBox();

            $('#search').click(function () {
                if ($("#siftbox").is(":hidden")) {
                    $(this).find('img.aa').attr('src', '../../Images/public/collapse.gif');
                    $("#siftbox").slideDown(400, function () { });
                    $("#hidFilterState").val("1");
                } else {
                    $(this).find('img.aa').attr('src', '../../Images/public/expand.gif');
                    $("#siftbox").slideUp(400, function () { });
                    $("#hidFilterState").val("0");
                }
            });

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=017&dt=" + new Date().toString(), window.self, strmodal);
            });

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
        });

        function setFilterBox() {
            if ($("#hidFilterState").val() == "1") {
                $("#siftbox").find('img.aa').attr('src', '../../Images/public/collapse.gif');
                $("#siftbox").show();
            }
        }

        function BeforeDel() {
            if (window.confirm("确定删除吗")) {
                return true;
            } else {
                return false;
            }
        }

        function printForm(id) {
            var url = 'PaymentPrint.aspx?payid=' + id;
            window.open(url, 'newwindow', 'height=470,width=850,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">付款申请列表</span> <span class="titlebtncls"><a
                href="javascript:void('0');" id="editpage" title="页面设置">
                <img alt="" src="../../Images/public/layoutedit.png" />页面设置</a><a href="PaymentAdd.aspx"
                    title="新增">
                    <img alt="" src="../../Images/public/pagedit.png" />新增</a> <a href="javascript:void('0');"
                        id="search" title="筛选">
                        <img alt="" class="aa" src="../../Images/public/expand.gif" />筛选</a>
        </span>
    </div>
    <div class="border" id="slider">
        <div id="siftbox">
            <table class="filterBox">
                <tr>
                    <td align="right">
                        申请单号：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtSerialNum" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">
                        申请日期：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRequestDate" CssClass="filterInput" runat="server">
                            <asp:ListItem Value="-1">——所有——</asp:ListItem>
                            <asp:ListItem Value="0">——今天——</asp:ListItem>
                            <asp:ListItem Value="1">——今天之前——</asp:ListItem>
                            <asp:ListItem Value="2">——昨天——</asp:ListItem>
                            <asp:ListItem Value="3">——7天内——</asp:ListItem>
                            <asp:ListItem Value="4">——15天内——</asp:ListItem>
                            <asp:ListItem Value="5">——指定范围——</asp:ListItem>
                        </asp:DropDownList>
                        <img src="../../Images/public/calendar.png" id="selDate" style="cursor: pointer;"
                            alt="选取时间范围" /><br />
                        <span id="dateBox"></span>
                        <input id="hidDateValue" type="hidden" runat="server" />
                    </td>
                    <td width="80px" align="right">
                        制单员：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtMaker" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="80px" align="right">
                        收款单位：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtPayerUnit" runat="server"></asp:TextBox>
                    </td>
                    <td width="80px" align="right">
                        支付金额：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtPayAmount" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                    </td>
                    <td colspan="2" align="left" style="padding-left: 90px;">
                        <asp:ImageButton runat="server" ID="btnFilter" ImageUrl="~/Images/Button/btn_search.jpg"
                            OnClick="btnFilter_Click" />
                        <asp:ImageButton runat="server" ID="btnResetFilter" ImageUrl="~/Images/Button/btn_reset.jpg"
                            OnClick="btnResetFilter_Click" />
                    </td>
                    <%-- <td width="80px" align="right">
                        审核状态：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAuditStaus" CssClass="filterInput" runat="server">
                            <asp:ListItem Value="-1">——所有——</asp:ListItem>
                            <asp:ListItem Value="01">——未开始——</asp:ListItem>
                            <asp:ListItem Value="02">——进行中——</asp:ListItem>
                            <asp:ListItem Value="03">——被拒绝——</asp:ListItem>
                            <asp:ListItem Value="04">——已通过——</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        保存状态：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSaveSatus" CssClass="filterInput" runat="server">
                            <asp:ListItem Value="-1">——所有——</asp:ListItem>
                            <asp:ListItem Value="已提交">——已提交——</asp:ListItem>
                            <asp:ListItem Value="草稿">——草稿——</asp:ListItem>
                        </asp:DropDownList>
                    </td>--%>
                </tr>
                <tr>
                </tr>
            </table>
        </div>
        <div style="width: 100%; text-align: right;">
            <%--<span id="scol" style="margin-right: 7px"></span>--%>
            <span id="scol" class="nBtn" style="margin-right: 7px"></span>
        </div>
        <asp:Repeater ID="RpPaymentList" runat="server" OnItemCommand="RpPaymentList_ItemCommand">
            <HeaderTemplate>
                <table id="flexigrid" style="padding-bottom: 10px" class="sortable">
                    <thead>
                        <tr>
                            <th width="100">
                                操作
                            </th>
                            <th width="40">
                                审核状态
                            </th>
                            <th width="40">
                                保存状态
                            </th>
                            <th width="100">
                                申请单号
                            </th>
                            <th width="100">
                                申请日期
                            </th>
                            <th width="200">
                                收款单位
                            </th>
                            <th width="100">
                                付款类别
                            </th>
                            <th width="80">
                                支付金额合计
                            </th>
                            <th width="100">
                                制单员
                            </th>
                            <th width="200">
                                备注
                            </th>
                        </tr>
                    </thead>
                    <tbody id="container">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="op">
                        <%--操作--%>
                        <asp:ImageButton ID="btnRecover" runat="server" CommandName="RECOVER" CommandArgument='<%# Eval("jobflowID") %>'
                            ImageUrl="~/Images/public/formfresh.png" ToolTip="回收" AlternateText="回收" />
                        <asp:ImageButton ID="btnApproval" runat="server" CommandName="APPROVAL" CommandArgument='<%# Eval("jobflowID")+","+Eval("id")+","+Eval("serialNum") %>'
                            ImageUrl="~/Images/public/itemgo.png" ToolTip="送审" AlternateText="送审" />
                        <asp:ImageButton ID="btnEdit" CommandName="EDIT" ToolTip="编辑" AlternateText="编辑"
                            CommandArgument='<%# Eval("id")+","+Eval("jobflowID") %>' ImageUrl="~/Images/public/edit.gif"
                            runat="server" />
                        <a href='<%# "PaymentPreview.aspx?payid="+Eval("id") + "&sqsh=sq" %>' title="预览">
                            <img src="../../Images/public/searchform.png" alt="预览" />
                        </a>
                        <%--<asp:ImageButton ID="btnPrint" runat="server" title="打印" CommandName="PRINT" CommandArgument='<%# Eval("id")+","+Eval("auditstatus") %>'
                            ImageUrl="~/Images/icons/printer.png" />--%>
                        <asp:ImageButton ID="btnDelete" OnClientClick="return BeforeDel();" CommandName="DELETE"
                            ToolTip="删除" AlternateText="删除" CommandArgument='<%# Eval("id")+","+Eval("jobflowID") %>'
                            ImageUrl="~/Images/public/delete.gif" runat="server" />
                    </td>
                    <td>
                        <%--审核状态--%>
                        <%# GetApprovalHtml(Eval("auditstutastxt"))%>
                    </td>
                    <td>
                        <%--保存状态--%>
                        <%# Eval("savestatus")%>
                    </td>
                    <td>
                        <%--申请单号--%>
                        <%# Eval("serialNum")%>
                    </td>
                    <td>
                        <%--申请日期--%>
                        <%# Eval("requestDate", "{0:d}")%>
                    </td>
                   
                    <td>
                        <%--付款单位--%>
                        <%# Eval("payerName") %>
                    </td>
                    <td>
                        <%--付款类别--%>
                        <%# Eval("paymentType") %>
                    </td>
                    <td>
                        <%--支付金额合计--%>
                        <%# Eval("totalAmount") %>
                    </td>
                    <td>
                        <%--制单员--%>
                        <%# Eval("makerName") %>
                    </td>
                    <td>
                        <%--备注--%>
                        <%# Eval("bankMark") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <div runat="server" id="pages">
        </div>
        <%--   <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
            PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
            CustomInfoTextAlign="Left" LayoutType="Table" PageIndexBoxType="DropDownList"
            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>--%>
    </div>
    <input id="hidFilterState" value="0" runat="server" type="hidden" />
    </form>
</body>
</html>
