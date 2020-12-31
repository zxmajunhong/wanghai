<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrderList.aspx.cs" Inherits="EtNet_Web.Pages.Order.MyOrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的订单</title>
    <link href="../../Styles/page.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
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
            background-image: url('../../Images/Public/list_tit.png');
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
        #iptcus 
        {
            outline: none;}
        .ui-autocomplete 
        {
            list-style-type: none;
            max-height: 150px;
            overflow-y: scroll;
            padding-left: 2px;
            background-color: #fff;
            border: 1px solid #dfdfdf;
            width: 200px !important;
        }
        
        .ui-autocomplete .ui-menu-item 
        {
            margin: 2px 0;
            cursor: pointer;
        }
    </style>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog4.1.6/plugins/iframeTools.source.js" type="text/javascript"></script>
    <link href="../../Scripts/artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/customdate.js" type="text/javascript"></script>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <%--输入下拉模糊查询--%>
    <script src="../../Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                if (window.showModalDialog) {
                  window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=034&dt=" + new Date().toString(), window.self, strmodal);
                } else {
                  window.open("../Common/PageSearchSet.aspx?pagenum=034&dt=" + new Date().toString(),"页面编辑", "width=500,height=160");
                }
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
            });

            // 定义收款单位模糊查询功能
            var cusSource = <%= getCusDataSourec() %>;
            $("#iptcus").autocomplete({
                minLength: 0,
                maxHeight: 150,
                source: cusSource,
                focus: function(event, ui) {
                    $("#iptcus").val(ui.item.value);
                    return false;
                },
                select: function(event, ui) {
                    $("#iptcus").val(ui.item.value);
                    $("#hidcusid").val(ui.item.id);
                    return false;
                }
            });

            $("#iptcus").blur(function(){
                if($(this).val() == ''){
                    $("#hidcusid").val('0');
                }
            });
        })

        //查看订单信息
        function getOrder(orderId) {
            if (orderId != "")
                window.open('../Order/OrderDetial.aspx?id=' + orderId);
            else
                alert('参数错误，找不到该订单');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">我的订单</span> <span class="titlebtncls"><a href="javascript:void('0');"
                id="editpage" title="页面设置">
                <img alt="" src="../../Images/public/layoutedit.png" style="border: 0" />页面设置</a>
            </span>
    </div>
    <div class="clsbottom">
        <table style="width: 100%; margin-top: 20px">
            <tr>
                <td style="width: 100px">
                    请选择业务员：
                </td>
                <td>
                    <asp:DropDownList Width="200px" ID="ddlsalesman" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="width: 100px">
                    请选择收款状态：
                </td>
                <td>
                    <asp:DropDownList Width="200px" ID="ddlcolstatus" runat="server" >
                        <asp:ListItem Text="——请选择——" Value=""></asp:ListItem>
                        <asp:ListItem Text="未收款" Value="未收款"></asp:ListItem>
                        <asp:ListItem Text="部分收款" Value="部分收款"></asp:ListItem>
                        <asp:ListItem Text="完成收款" Value="完成收款"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 100px">
                    请选择收款单位：
                </td>
                <td>
                    <input type="text" name="iptcus" value="" id="iptcus" runat="server" />
                    <input type="hidden" id="hidcusid" value="0" runat="server"/>
                    <%--<asp:DropDownList Width="200px" ID="ddlcus" runat="server">
                    </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    请选择出团日期：
                </td>
                <td>
                    <asp:DropDownList ID="ddlRequestDate" CssClass="filterInput" Width="200px" runat="server">
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
                <td style="width: 100px">
                    请选择性质
                </td>
                <td>
                  <asp:DropDownList Width="200px" ID="ddlNatrue" runat="server">
                    <asp:ListItem Text="——请选择——" Value=""></asp:ListItem>
                    <asp:ListItem Text="团队" Value="团队"></asp:ListItem>
                    <asp:ListItem Text="散客" Value="散客"></asp:ListItem>
                    <asp:ListItem Text="代订业务" Value="代订业务"></asp:ListItem>
                    <asp:ListItem Text="其他" Value="其他"></asp:ListItem>
                  </asp:DropDownList>
                </td>
                <td colspan="2" align="right">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                    <asp:ImageButton runat="server" ID="imgbtnexport" 
                      ImageUrl="~/Images/Button/btn_export.jpg" onclick="imgbtnexport_Click" />
                </td>
            </tr>
            <tr>
                <td style="vertical-align: middle;" colspan="6">
                <table id="orderlist" runat="server" style="width: 100%">
                  <tr>
                    <td style="vertical-align: middle;">
                    <table class="clsdata" cellspacing="1" cellpadding="0" width="100%">
                        <tr>
                            <th class="clstitleimg" style="width: 7%;">
                                订单序号
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                出团日期
                            </th>
                            <th class="clstitleimg" style="width: 4%;">
                                性质
                            </th>
                            <th class="clstitleimg" style="width: 4%;">
                                成人数
                            </th>
                            <th class="clstitleimg" style="width: 4%;">
                                儿童数
                            </th>
                            <%--<th class="clstitleimg" style="width: 4%;">
                                陪同
                            </th>
                            <th class="clstitleimg" style="width: 4%;">
                                人数
                            </th>--%>
                            <% if (ViewState["lirun"].ToString() == "1")
                               { %>
                            <th class="clstitleimg" style="width: 4%;">
                                利润
                            </th>
                            <% } %>
                            <th class="clstitleimg" style="width: 6%;">
                                旅游线路
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                线路描述
                            </th>
                            <th class="clstitleimg" style="width: 5%;">
                                应收金额
                            </th>
                            <th class="clstitleimg" style="width: 5%;">
                                已收金额
                            </th>
                            <th class="clstitleimg" style="width: 5%;">
                                未收金额
                            </th>
                            <%--<th class="clstitleimg" style="width: 5%;">
                                状态
                            </th>
                            <th class="clstitleimg" style="width: 5%;">
                                结算状态
                            </th>--%>
                            <th class="clstitleimg" style="width: 5%;">
                                收款状态
                            </th>
                            <th class="clstitleimg" style="width: 23%;">
                                收款单位名称
                            </th>
                            <th class="clstitleimg" style="width: 9%;">
                                联系人
                            </th>
                            <th class="clstitleimg" style="width: 5%;">
                                业务员
                            </th>
                        </tr>
                        <tbody>
                            <asp:Repeater ID="orderRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%--<a href="javascript:void(0)" onclick="getOrder('<%# Eval("orderid").ToString() %>')">--%>
                                                <%# Eval("orderNum") %>
                                              <%--</a>--%>
                                        </td>
                                        <td>
                                            <%# DateTime.Parse(Eval("outTime").ToString()).ToString("yyyy-MM-dd")%>
                                        </td>
                                        <td>
                                            <%# Eval("natrue")%>
                                        </td>
                                        <td>
                                            <%# Eval("adultNum")%>
                                        </td>
                                        <td>
                                            <%# Eval("childNum")%>
                                        </td>
                                        <%--<td>
                                            <%# Eval("withNum")%>
                                        </td>
                                        <td>
                                            <%#Eval("pNum") %>
                                        </td>--%>
                                        <% if (ViewState["lirun"].ToString() == "1")
                                           { %>
                                        <td>
                                            <%#Eval("lirun") %>
                                        </td>
                                        <% }%>
                                        <td>
                                            <%# TourLine(Convert.ToInt32( Eval("tour")))%>
                                        </td>
                                        <td>y
                                            <%#Eval("tourRemark")%>
                                        </td>
                                        <td>
                                            <%#Eval("money")%>
                                        </td>
                                        <td>
                                            <%#Eval("collectAmount")%>
                                        </td>
                                        <td>
                                            <%# GetSymoney(Eval("money"),Eval("collectAmount"))%>
                                        </td>
                                        <%--<td>
                                            <%# OrderStatus(Eval("savestatus").ToString()) %>
                                        </td>
                                        <td>
                                            <%#AuditsStatus(Eval("auditstatus").ToString())%>
                                        </td>--%>
                                        <td>
                                            <%# CollectStatus(Eval("collectStatus").ToString()) %>
                                        </td>
                                        <td>
                                            <%# Eval("cusName") %>
                                        </td>
                                        <td>
                                            <%# Eval("linkname") %>
                                        </td>
                                        <td>
                                            <%# Eval("salesman") %>
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
                            <td id="adult_sum" runat="server"></td>
                            <td id="child_sum" runat="server"></td>
                            <%--<td id="with_sum" runat="server"></td>
                            <td id="pnum_sum" runat="server"></td>--%>
                            <% if (ViewState["lirun"].ToString() == "1")
                               { %>
                            <td id="lirun_sum" runat="server"></td>
                            <% } %>
                            <td></td>
                            <td></td>
                            <td id="money_sum" runat="server"></td>
                            <td></td>
                            <%--<td></td>
                            <td></td>--%>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                    </td>
                  </tr>
                </table>
                    
                </td>
            </tr>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
            PageSize="5" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never"
            OnPageChanged="AspNetPager1_PageChanged" CustomInfoTextAlign="Left" LayoutType="Table"
            CustomInfoHTML="" PageIndexBoxType="DropDownList" ShowPageIndexBox="Always" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" PagingButtonLayoutType="Span">
        </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
