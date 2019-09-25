<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CutPayList.aspx.cs" Inherits="EtNet_Web.Pages.Financial.CutPay.CutPayList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提成发放列表</title>
    <link href="../css/tab.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/page.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/plugins/iframeTools.source.js" type="text/javascript"></script>
    <link href="../../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <link href="../css/jPages.css" rel="stylesheet" type="text/css" />
    <script src="../js/jPages.js" type="text/javascript"></script>
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
        .clsdata tr.hover td, .clsdata tr.hover input
        {
            background-color: #FFEFBB !important;
            cursor: pointer;
        }
        .clsdata tr.selected td, .clsdata tr.selected input
        {
            background-color: #FFECB5 !important;
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
    <script type="text/javascript">
        $(function () {
            debugger;
            //分页
            $("div.holder").jPages({
                containerID: "orderList",
                first: "首页",
                last: "尾页",
                previous: "上一页",
                next: "下一页",
                perPage: 20,
                delay: 20
                //                perPage: $("#j_pagesize").val() == "" ? 10 : $("#j_pagesize").val(),
                //                delay: $("#j_pagecount").val() == "" ? 20 : $("#j_pagecount").val()
            });

            $("#pages1").jPages({
                containerID: "inputerList",
                first: "首页",
                last: "尾页",
                previous: "上一页",
                next: "下一页",
                perPage: 20,
                delay: 20
            });

            $('.clsdata tbody tr').each(function () {
                $(this).hover(function () {
                    $(this).toggleClass('hover');
                });
                $(this).click(function () {
                    debugger;
                    if ($(this).hasClass("selected")) {
                        $(this).removeClass("selected").find(".clschkb").find("input").removeAttr("checked");
                    }
                    else {
                        $(this).addClass('selected').find(".clschkb").find("input").attr('checked', 'checked');
                    }
                });
            });

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


            //全选或全部选
            $("#btnchkdel").click(function () {
                debugger;
                //                $('#table0 tbody tr').each(function () {
                //                    if ($(this).hasClass("jp-hidden"))
                //                    { }
                //                    else {
                //                        if ($(this).hasClass("selected")) {
                //                            $(this).removeClass("selected").find(".clschkb0").find("input").removeAttr("checked");
                //                        }
                //                        else {
                //                            $(this).addClass('selected').find(".clschkb0").find("input").attr('checked', 'checked');
                //                        }
                //                    }
                //                });

                if ($('#table0 tbody tr:visible td span input').length == $('#table0 tbody tr:visible td span input:checked').length) {
                    debugger;
                    $('#table0 tbody tr:visible').removeClass("selected");
                    $('#table0 tbody tr:visible td span input').removeAttr("checked");
                }
                else {
                    $('#table0 tbody tr:visible').addClass("selected");
                    $('#table0 tbody tr:visible td span input').attr("checked", "checked");
                }
            })

            //全选或全部选
            $("#btnchkdel1").click(function () {

                if ($('#table1 tbody tr:visible td span input').length == $('#table1 tbody tr:visible td span input:checked').length) {
                    debugger;
                    $('#table1 tbody tr:visible').removeClass("selected");
                    $('#table1 tbody tr:visible td span input').removeAttr("checked");
                }
                else {
                    $('#table1 tbody tr:visible').addClass("selected");
                    $('#table1 tbody tr:visible td span input').attr("checked", "checked");
                }
            })

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=033&dt=" + new Date().toString(), window.self, strmodal);
            })

            //操作
            $("#btnread").click(function () {
                if ($(".clschkb0 :checked").length == 0) {
                    alert('未选中任何项');
                }
                else if ($(".clschkb0 :checked").length > 60) {
                    alert('请选择少入60条的数据');
                }
                else {
                    if (confirm('确定对选中的 ' + $(".clschkb0 :checked").length + ' 项进行确认')) {
                        $("#hidtcsort").val(0);
                        $("#imgread").click();
                    }
                }
            })

            //操作
            $("#btnread1").click(function () {
                if ($(".clschkb1 :checked").length == 0) {
                    alert('未选中任何项');
                }
                else if ($(".clschkb1 :checked").length > 60) {
                    alert('请选择少入60条的数据');
                }
                else {
                    if (confirm('确定对选中的' + $(".clschkb1 :checked").length + '项进行确认')) {
                        $("#hidtcsort").val(1);
                        $("#imgread").click();
                    }
                }
            })
        })

        //查看订单信息
        function getOrder(orderId) {
            if (orderId != "")
                window.open('../../Order/OrderDetial.aspx?id=' + orderId);
            else
                alert('参数错误，找不到该订单');
        }

        function getCus(cusid) {
            if (cusid != "") {
                window.open('../../CusInfo/CusDetial.aspx?id=' + cusid);
            }
            else
                alert('参数错误，找不到该单位');
        }

        function selectTag(showContent, selfObj) {
            debugger;
            // 操作标签
            var tag = document.getElementById("tags").getElementsByTagName("li");
            var taglength = tag.length;
            for (i = 0; i < taglength; i++) {
                tag[i].className = "";
            }
            selfObj.parentNode.className = "selectTag";
            // 操作内容
            for (i = 0; j = document.getElementById("tagContent" + i); i++) {
                j.style.display = "none";
            }
            document.getElementById(showContent).style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
                font-weight: bold; line-height: 25px">提成发放列表</span> <span class="titlebtncls" style="display: none;">
                    <a href="javascript:void('0');" id="editpage" title="页面设置">
                        <img alt="" src="../../../Images/public/layoutedit.png" style="border: 0" />页面设置</a>
                </span>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div id="con" style="margin-top: 10px;">
        <ul id="tags">
            <li id="tag0" class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)"
                id="a1">业务员</a> </li>
            <li id="tag1"><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)"
                id="a2">操作员</a> </li>
        </ul>
        <div class="clsbottom" id="tagContent">
            <div class="tagContent selectTag" id="tagContent0">
                <table style="width: 100%; margin-top: 20px">
                    <tr>
                        <td style="width: 100px">
                            请选择业务员
                        </td>
                        <td style="width: 210px;">
                            <asp:DropDownList Width="200px" ID="salesmans" runat="server" OnSelectedIndexChanged="salesmans_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px; text-align: right;">
                            发放状态
                        </td>
                        <td colspan="6">
                            <asp:RadioButtonList ID="ywu_status" runat="server" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="ywu_status_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="是" Value="是" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                <asp:ListItem Text="全部" Value="全部"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle;" colspan="6">
                            <table class="clsdata" id="table0" cellspacing="1" cellpadding="0" width="100%">
                                <tr>
                                    <th class="clstitleimg" style="width: 5%;">
                                    </th>
                                    <th class="clstitleimg" style="width: 11%;">
                                        订单序号
                                    </th>
                                    <th class="clstitleimg" style="width: 11%;">
                                        制单日期
                                    </th>
                                    <th class="clstitleimg" style="width: 11%;">
                                        制单员
                                    </th>
                                    <th class="clstitleimg" style="width: 18%;">
                                        收款单位名称
                                    </th>
                                    <th class="clstitleimg" style="width: 11%;">
                                        业务员
                                    </th>
                                    <th class="clstitleimg" style="width: 11%;">
                                        人数
                                    </th>
                                    <th class="clstitleimg" style="width: 11%;">
                                        利润
                                    </th>
                                    <th class="clstitleimg" style="width: 11%;">
                                        发放状态
                                    </th>
                                </tr>
                                <tbody id="orderList">
                                    <asp:Repeater ID="payRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cbx" CssClass="clschkb clschkb0" runat="server" />
                                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("collectId") %>' Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <a href="javascript:void(0)" onclick="getOrder('<%# Eval("orderid").ToString() %>')">
                                                        <%# Eval("orderNum") %></a>
                                                </td>
                                                <td>
                                                    <%# Eval("makerTime", "{0:d}")%>
                                                </td>
                                                <td>
                                                    <%# Eval("makerName")%>
                                                </td>
                                                <td>
                                                    <a href="javascript:void(0)" onclick="getCus('<%# Eval("cusId").ToString() %>')">
                                                        <%# Eval("cusName")%></a>
                                                </td>
                                                <td>
                                                    <%# Eval("salesman")%>
                                                </td>
                                                <td>
                                                    <%# Eval("adultNum").ToString() != ""&&Eval("childNum").ToString() !=""? Convert.ToInt32(Eval("adultNum")) + Convert.ToInt32(Eval("childNum")):0 %>
                                                </td>
                                                <td>
                                                    <%#Eval("lirun") %>
                                                </td>
                                                <td>
                                                    <%# Eval("cutPayStatus")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="9" style="text-align: right;">
                                            <div id="btnread" class="clsbtntxt">
                                                提成发放</div>
                                            <div id="btnchkdel" class="clsbtntxt" title="全部选中时点击将取消所有选中项">
                                                全选/全不选</div>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                            <div id="pages" class="holder">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tagContent" id="tagContent1">
                <table style="width: 100%; margin-top: 20px;">
                    <tr>
                        <td style="width: 100px">
                            请选择操作员
                        </td>
                        <td style="width: 210px;">
                            <asp:DropDownList Width="200px" ID="inputers" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="inputers_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px; text-align: right;">
                            发放状态
                        </td>
                        <td colspan="5">
                            <asp:RadioButtonList ID="czy_status" runat="server" OnSelectedIndexChanged="czy_status_SelectedIndexChanged"
                                AutoPostBack="true" RepeatDirection="Horizontal">
                                <asp:ListItem Text="是" Value="是" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                <asp:ListItem Text="全部" Value="全部"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle;" colspan="6">
                            <table class="clsdata" id="table1" cellspacing="1" cellpadding="0" width="100%">
                                <tr>
                                    <th class="clstitleimg" style="width: 5%;">
                                    </th>
                                    <th class="clstitleimg" style="width: 13%;">
                                        订单序号
                                    </th>
                                    <th class="clstitleimg" style="width: 13%;">
                                        制单日期
                                    </th>
                                    <th class="clstitleimg" style="width: 13%;">
                                        出团日期
                                    </th>
                                    <th class="clstitleimg" style="width: 17%;">
                                        团队总数
                                    </th>
                                    <th class="clstitleimg" style="width: 13%;">
                                        操作员
                                    </th>
                                    <th class="clstitleimg" style="width: 13%;">
                                        提成金额
                                    </th>
                                    <th class="clstitleimg" style="width: 13%;">
                                        发放状态
                                    </th>
                                </tr>
                                <tbody id="inputerList">
                                    <asp:Repeater ID="inputerTc" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="cbx1" CssClass="clschkb clschkb1" runat="server" />
                                                    <asp:Label ID="lbl1" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <a href="javascript:void(0)" onclick="getOrder('<%# Eval("id").ToString() %>')">
                                                        <%# Eval("orderNum") %></a>
                                                </td>
                                                <td>
                                                    <%# Eval("makerTime", "{0:d}")%>
                                                </td>
                                                <td>
                                                    <%# Eval("outTime", "{0:d}")%>
                                                </td>
                                                <td>
                                                    <%# Eval("teamNum")%>
                                                </td>
                                                <td>
                                                    <%# Eval("inputer")%>
                                                </td>
                                                <td>
                                                    <%# Eval("inputerTc") %>
                                                </td>
                                                <td>
                                                    <%# Eval("inputerTc_status")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="10" style="text-align: right;">
                                            <div id="btnread1" class="clsbtntxt">
                                                提成发放</div>
                                            <div id="btnchkdel1" class="clsbtntxt" title="全部选中时点击将取消所有选中项">
                                                全选/全不选</div>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                            <div id="pages1" class="holder">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!-- 功能按钮隐藏区-->
    <div>
        <input type="hidden" id="j_pagesize" value="" runat="server" />
        <input type="hidden" id="j_pagecount" value="" runat="server" />
        <input type="hidden" id="hidtcsort" value="" runat="server" />
        <asp:ImageButton runat="server" ID="imgread" Width="0" Height="0" ImageUrl="~/Images/Public/btn.png"
            OnClick="imgread_Click" />
    </div>
    </form>
</body>
</html>
