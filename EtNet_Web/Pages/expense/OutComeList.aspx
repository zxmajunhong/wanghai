<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutComeList.aspx.cs" Inherits="EtNet_Web.Pages.expense.OutComeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>付款列表</title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 5px 10px 5px;
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
            border: 0px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .style2
        {
            width: 100px;
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
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/customdate.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


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
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=036&dt=" + new Date().toString(), window.self, strmodal);
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
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" value="0" id="hidsift" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%">
                <tr>
                    <td class="toptitletxt">
                        付款列表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" />&nbsp;<span>页面设置</span></span>
                        <a href="OutComeAdd.aspx" title="新增" style="text-decoration: none"><span class="topimgtxt"
                            id="addtxt" title="新增">
                            <img alt="新增" title="新增" src="../../Images/public/pagedit.png" />&nbsp;<span>新增</span>
                        </span></a><span class="topimgtxt" id="sifttxt" title="筛选">
                            <img alt="筛选" title="筛选" src="../../Images/public/collapse.gif" />&nbsp;<span>筛选</span>
                        </span>
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
                <td align="right" style="width: 80px;">
                    支付状态:
                </td>
                <td>
                    <asp:DropDownList ID="ddlPayStatus" runat="server" Width="200px">
                        <asp:ListItem Text="——请选择——" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="未支付" Value="0"></asp:ListItem>
                        <asp:ListItem Text="已支付" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 80px;">
                    付款类别:
                </td>
                <td>
                    <asp:DropDownList ID="ddlpayitem" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 80px;">
                    收款单位:
                </td>
                <td>
                    <input type="text" id="txtSkUnit" runat="server" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px;">
                    付款银行:
                </td>
                <td>
                    <asp:DropDownList ID="ddlAcount" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 80px;">
                    所属部门:
                </td>
                <td>
                    <asp:DropDownList ID="ddlDepart" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 80px;">
                    制单员:
                </td>
                <td>
                    <input type="text" id="textMakeName" runat="server" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px;">
                    收款日期:
                </td>
                <td>
                    <asp:DropDownList ID="ddlRequestDate" CssClass="filterInput" runat="server">
                        <asp:ListItem Value="-1">——请选择——</asp:ListItem>
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
                <td align="right" style="width: 80px;">
                    备注:
                </td>
                <td>
                    <input type="text" id="txtremark" runat="server" class="clsunderline" />
                </td>
                 <td align="right" style="width: 80px;">
                    付款金额:
                </td>
                <td>
                    <input type="text" id="iptmoney" runat="server" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                    <asp:ImageButton runat="server" ID="ibtexport" 
                      ImageUrl="~/Images/Button/btn_export.jpg" onclick="ibtexport_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <tr>
                <th class="clstitleimg" style="width: 5%">
                    支付状态
                </th>
                <th class="clstitleimg" style="width: 11%">
                    付款日期
                </th>
                <th class="clstitleimg" style="width: 11%">
                    付款类别
                </th>
                <th class="clstitleimg" style="width: 13%">
                    收款单位
                </th>
                <th class="clstitleimg" style="width: 11%">
                    付款金额
                </th>
                <th class="clstitleimg" style="width: 11%">
                    付款银行
                </th>
                <th class="clstitleimg" style="width: 11%">
                    所属部门
                </th>
                <th class="clstitleimg" style="width: 11%">
                    制单员
                </th>
                <th class="clstitleimg" style="width: 11%">
                    备注
                </th>
                <th class="clstitleimg" style="width: 5%">
                    操作
                </th>
            </tr>
            <tbody>
                <asp:Repeater ID="outList" runat="server" OnItemCommand="outList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("outComeStatus").ToString() == "1"?"<font color='green'>已支付</font>":"<font color='red'>未支付</font>"%>
                            </td>
                            <td>
                                <%# Convert.ToDateTime(Eval("outComeDate")).ToString("yyyy-MM-dd")%>
                            </td>
                            <td>
                                <%# Eval("outComeItem")%>
                            </td>
                            <td>
                                <%# Eval("comeUnit")%>
                            </td>
                            <td>
                                <%# Eval("outComeMoney")%>
                            </td>
                            <td>
                                <%# Eval("outComeBankName")%>
                            </td>
                            <td>
                                <%# Eval("outComeDepart")%>
                            </td>
                            <td>
                                <%# Eval("makeName")%>
                            </td>
                            <td>
                                <%# Eval("remark") %>
                            </td>
                            <td>
                                <asp:ImageButton ID="BtnConfirm" runat="server" CommandName="confirm" CommandArgument='<%# Eval("id") %>'
                                    alt="确认支付" ToolTip="确认支付" ImageUrl="~/Images/icons/tick.png" Visible='<%# Eval("outComeStatus").ToString() !="1" %>' />
                                <asp:ImageButton ID="BtnCancelConfirm" runat="server" OnClientClick="return window.confirm('确定要取消确认吗?');"
                                    CommandName="CANCEL" CommandArgument='<%# Eval("id") %>' ImageUrl="../../Images/public/load.png"
                                    alt="撤销确认" ToolTip="撤销确认" Visible='<%# Eval("outComeStatus").ToString()=="1"%>'>
                                </asp:ImageButton>
                                <asp:ImageButton ID="ibtEdit" runat="server" title="编辑" CommandName="Edit" CommandArgument='<%# Eval("id") %>'
                                    Visible='<%#Eval("outComeStatus").ToString()!="1" %>' ImageUrl="~/Images/public/edit.gif" />
                                <asp:ImageButton ID="ibtDetail" runat="server" title="详细" CommandName="Detail" CommandArgument='<%# Eval("id") %>'
                                    ImageUrl="~/Images/public/searchform.png" />
                                <asp:ImageButton ID="ibtDelete" runat="server" title="删除" CommandName="Delete" CommandArgument='<%# Eval("id") %>'
                                    ImageUrl="~/Images/public/delete.gif" OnClientClick="return confirm('确定删除?')"
                                    Visible='<%#Eval("outComeStatus").ToString()!="1" %>' />
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
                     <asp:Label ID="zje" runat="server" Text=""></asp:Label>

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
                </tr>

            </tbody>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
            PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
            CustomInfoTextAlign="Left" LayoutType="Table" PageIndexBoxType="DropDownList"
            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
