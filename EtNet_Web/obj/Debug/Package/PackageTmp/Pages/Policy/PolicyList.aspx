<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyList.aspx.cs" Inherits="EtNet_Web.Pages.Policy.PolicyList" %>

<%--2013年1月7日15:30:59--%>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="flexigrid.css" rel="stylesheet" type="text/css" />
    <script src="../Product/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="flexigrid.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
        .bDiv
        {
            /*min-height: 440px;
            height: expression_r(document.body.clientHeight > 420? "auto": "440px" );*/
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
        .filterInput
        {
            width: 200px;
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
            text-align: right !important;
        }
        .company
        {
             width: 225px;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
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

            setFilterBox();

            $('#search').click(function () {
                if ($("#siftbox").is(":hidden")) {
                    $(this).find('img').attr('src', '../../Images/public/collapse.gif');
                    $("#siftbox").slideDown(400, function () { });
                    $("#hidFilterState").val("1");
                } else {
                    $(this).find('img').attr('src', '../../Images/public/expand.gif');
                    $("#siftbox").slideUp(400, function () { });
                    $("#hidFilterState").val("0");
                }
            });


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

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=015&dt=" + new Date().toString(), window.self, strmodal);
            })
        });

        function setFilterBox() {
            if ($("#hidFilterState").val() == "1") {
                $("#siftbox").find('img').attr('src', '../../Images/public/collapse.gif');
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hidcdate" />
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 5px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">保单管理列表</span> <span class="titlebtncls"><a
                href="javascript:void('0');" id="editpage" title="页面设置">
                <img alt="" src="../../Images/public/layoutedit.png" />页面设置</a><a href="AddPolicy.aspx?action=new"
                    title="新增">
                    <img alt="" src="../../Images/public/pagedit.png" />新增</a> <a href="javascript:void('0');"
                        id="search" title="筛选">
                        <img alt="" src="../../Images/public/expand.gif" />筛选</a> </span>
    </div>
    <div style="background: #4CB0D5; height: 5px; width: 100.2%">
    </div>
    <div class="border" id="slider">
        <div id="siftbox">
            <table class="filterBox">
                <tr>
                    <td width="80px" align="right">
                        保单编号：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtFilterPolicyNum" runat="server"></asp:TextBox>
                    </td>
                    <td width="80px" align="right">
                        保单日期：
                    </td>
                    <td>
                        <%-- <asp:DropDownList runat="server" ID="ddldate" CssClass="clsdatalist">
                            <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                            <asp:ListItem Text="——今天——" Value="1"></asp:ListItem>
                            <asp:ListItem Text="——今天之前——" Value="2"></asp:ListItem>
                            <asp:ListItem Text="——昨天——" Value="3"></asp:ListItem>
                            <asp:ListItem Text="——7天内——" Value="4"></asp:ListItem>
                            <asp:ListItem Text="——15天内——" Value="5"></asp:ListItem>
                            <asp:ListItem Text="——指定范围——" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                        <img src="../../../Images/public/calendar.png" id="selimgdt" style="cursor: pointer;"
                            alt="选取时间范围" />--%>
                        <asp:TextBox class="filterInput Wdate" ID="txtFilterSatrtTime" runat="server" onFocus="var d5222=$dp.$('txtFilterEndTime');WdatePicker({onpicked:function(){txtFilterEndTime.focus();},maxDate:'#F{$dp.$D(\'txtFilterEndTime\')}'})"></asp:TextBox>
                        到
                        <asp:TextBox class="filterInput Wdate" ID="txtFilterEndTime" runat="server" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'txtFilterSatrtTime\')}'})"></asp:TextBox>
                    </td>
                    <td width="80px" align="right">
                        业务员：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtFilterSalesman" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        投保客户：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtFilterCustomer" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">
                        保险公司：
                    </td>
                    <td>
                        <asp:TextBox class="company"  ID="txtFilterCompany" runat="server" ></asp:TextBox>
                    </td>
                    <td align="right">
                        保险险种：
                    </td>
                    <td>
                        <asp:TextBox class="filterInput" ID="txtFilterProType" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="80px" align="right">
                        审核状态：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFilterPolicyState" runat="server">
                            <asp:ListItem Value="all">全部</asp:ListItem>
                            <asp:ListItem Value="01">未开始</asp:ListItem>
                            <asp:ListItem Value="02">进行中</asp:ListItem>
                            <asp:ListItem Value="03">被拒绝</asp:ListItem>
                            <asp:ListItem Value="04">已通过</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="80px" align="right">
                        保存状态：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlsavestatus" runat="server" CssClass="clsdatalist" Width="225px">
                            <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                            <asp:ListItem Text="已提交" Value="1"></asp:ListItem>
                            <asp:ListItem Text="草稿" Value="2"></asp:ListItem>
                            <asp:ListItem Text="未开始" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="2" align="left" style="padding-left: 20px;">
                        <asp:ImageButton runat="server" ID="btnFilter" ImageUrl="~/Images/Button/btn_search.jpg"
                            OnClick="BtnFilter_Click" />
                        <asp:ImageButton runat="server" ID="btnResetFilter" ImageUrl="~/Images/Button/btn_reset.jpg"
                            OnClick="BtnResetFilter_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; text-align: right;">
            <%--<span id="scol" style="margin-right: 7px"></span>--%>
            <span id="scol" class="nBtn" style="margin-right: 7px"></span>
        </div>
        <asp:Repeater ID="RpPolicy" runat="server" OnItemCommand="RpPolicy_ItemCommand">
            <HeaderTemplate>
                <table id="flexigrid" style="padding-bottom: 10px" class="sortable">
                    <thead>
                        <tr>
                            <th width="85" class="nosort">
                                操作
                            </th>
                            <th width="40">
                                审核状态
                            </th>
                            <th width="40">
                                保存状态
                            </th>
                            <th width="100">
                                业务编号
                            </th>
                            <th width="60">
                                制单员
                            </th>
                            <th width="120">
                                业务员
                            </th>
                            <th width="80">
                                经纪费
                            </th>
                            <th width="80">
                                贴费
                            </th>
                            <th width="100">
                                保单编号
                            </th>
                            <th width="80">
                                保单日期
                            </th>
                            <th width="150">
                                投保客户
                            </th>
                            <th width="150">
                                保险公司
                            </th>
                            <th width="150">
                                保险险种
                            </th>
                            <th width="50">
                                保单状态
                            </th>
                            <th width="140">
                                保单期限
                            </th>
                            <th width="20">
                                续保
                            </th>
                            <th width="50" style="display: none">
                                被保险人
                            </th>
                            
                        </tr>
                    </thead>
                    <tbody id="container">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="op">
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="refresh" CommandArgument='<%# Eval("isVerify") %>'
                            ImageUrl="~/Images/public/formfresh.png" Visible='<%# IsSelf(Eval("policy_makerId")) %>'
                            ToolTip="回收" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="audit" CommandArgument='<%# Eval("isVerify")+","+Eval("id")+","+Eval("serialnum") %>'
                            ImageUrl="~/Images/public/itemgo.png" Visible='<%# IsSelf(Eval("policy_makerId")) %>'
                            ToolTip="送审" />
                        <asp:HyperLink ID="LnkEdit" NavigateUrl='<%# "AddPolicy.aspx?jobflowid=" + Eval("isVerify") + "&action=edit&id="+Eval("id") %>'
                            ToolTip="编辑" Visible='<%# IsSelf(Eval("policy_makerId")) %>' runat="server">
                                <img src="../../Images/public/edit.gif" alt="编辑" />
                        </asp:HyperLink>
                        <a href='<%# "Preview.aspx?id="+Eval("id") + "&sqsh=sq" %>' title="预览">
                            <img src="../../Images/public/searchform.png" alt="预览" /></a>
                        <asp:ImageButton ID="btnDelete" OnClientClick="return BeforeDel();" CommandName="DELETE"
                            CommandArgument='<%# Eval("id") %>' ToolTip="删除" ImageUrl="~/Images/public/delete.gif"
                            Visible='<%# IsSelf(Eval("policy_makerId")) %>' runat="server" />
                    </td>
                    <td>
                        <%# Eval("auditstutastxt").ToString() == "未开始" ? "<font color='red'>未开始</font>" : (Eval("auditstutastxt").ToString() == "已通过" ? "<font color='green'>已通过</font>" : (Eval("auditstutastxt").ToString() == "被拒绝" ? "<font color='red'>被拒绝</font>" : Eval("auditstutastxt").ToString()))%>
                    </td>
                    <td>
                        <%# Eval("savestatus")%>
                    </td>
                    <td>
                        <asp:HyperLink ID="LnkBtnEdit" NavigateUrl='<%# "AddPolicy.aspx?jobflowid=" + Eval("isVerify") + "&action=edit&id="+Eval("id") %>'
                            ToolTip="编辑" CssClass="lnkEdit" runat="server">
                            <%# Eval("serialnum")%>
                        </asp:HyperLink>
                             <%-- <%# Eval("serialnum")%>--%>
                    </td>
                    <td>
                        <%# Eval("policy_maker")%>
                    </td>
                    <td>
                        <%# Eval("persons")%>
                    </td>
                    <td>
                        <%# Eval("totalEconomic")%>
                    </td>
                    <td>
                        <%# Eval("totalRich")%>
                    </td>
                    <td>
                        <%# Eval("policy_num")%>
                    </td>
                    <td>
                        <%# GetDate(Convert.ToDateTime(Eval("policy_date")))%>
                    </td>
                    <td>
                        <%# Eval("cusshortName")%>
                    </td>
                    <td>
                        <%# Eval("comShortname")%>
                    </td>
                    <td>
                        <%# Eval("ProdTypeName")%>
                    </td>
                    <td>
                        <%# Eval("policy_state").ToString().Trim()=="0"?"无效":"有效"%>
                    </td>
                    <td>
                        <%# GetDate(Convert.ToDateTime( Eval("policy_startdate"))) + " 至 " + GetDate(Convert.ToDateTime(Eval("policy_enddate")))%>
                    </td>
                    <td>
                        <%# Eval("IsRenewal").ToString().Trim()=="0"?"否":"是"%>
                    </td>
                    <td style="display: none">
                        <%# Eval("assured")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
            PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
            CustomInfoTextAlign="Left" LayoutType="Table" PageIndexBoxType="DropDownList"
            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </div>
    <input id="hidFilterState" value="0" runat="server" type="hidden" />
    </form>
</body>
</html>
