<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditPolicy.aspx.cs" Inherits="EtNet_Web.Pages.Policy.AuditPolicy" %>

<%@ Register Src="../Finance/BudgetPre.ascx" TagName="BudgetPre" TagPrefix="uc1" %>
<%@ Register Src="UCTargetPre.ascx" TagName="UCTargetPre" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>保单审批</title>
    <link href="../Product/common.css" rel="stylesheet" type="text/css" />
    <link href="tab.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 5px 0px;
            overflow: auto;
            min-width: 880px;
            width: expression_r(document.body.clientWidth > 880? "880px": "auto" );
        }
        .border, #contable, #contable table
        {
            width: 99%;
        }
        .sortable th
        {
            height: 24px;
            text-align: center;
        }
        #table td
        {
            text-align: center;
        }
        .titlebtncls
        {
            position: absolute;
            right: 40px;
            font-size: 12px;
            font-weight: bold;
            margin-right: 10px;
            color: #718ABE;
            cursor: pointer;
            margin-top: 0px;
            text-decoration: none;
        }
        #contable input, #contable select
        {
            width: 153px;
        }
        #contable input
        {
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        #contable input#TxtYears
        {
            width: 40px;
        }
        
        .clsauditpic
        {
            border: 1px solid #63B8FF;
        }
        #top-left
        {
            width: 40%;
            float: left;
        }
        #top-right
        {
            width: 60%;
            float: right;
        }
        .tabledata input
        {
            width: 95%;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        .tabledata input.num
        {
            width: 70%;
        }
        img
        {
            border: none;
        }
        a
        {
            text-decoration: none;
        }
        #user-info
        {
            margin: 0px 0px 10px 0px;
            height: 30px;
            line-height: 30px;
            width: 100%;
            background: #F5F5F5;
            font-size: 12px;
            color: #333333;
            border-bottom: 1px solid #D4D4D4;
        }
        #targetTable input
        {
            width: 400px;
        }
        #targetTable select
        {
            width: 402px;
        }
        #tagContent0
        {
            padding: 5px;
            margin:0 3px 0 3px;
            width: auto;
        }
        #tagContent0 table td
        {
            border: 1px solid #C1DAD7;
            padding-left: 5px;
        }
        #tagContent0 table td.no_border
        {
            padding-left: 0px;
        }
        #tagContent0 table
        {
            border: 1px solid #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: #000;
        }
        .item_title
        {
            font-family: 宋体;
            color: #000;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: right;
            padding: 6px 6px 6px 12px;
            background: #DBE6E3 no-repeat;
        }
        caption
        {
            padding: 5px 0px;
            width: 100%;
            font: 14px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            font-weight: bold;
            text-align: center;
        }
        .sum_box
        {
            font-weight: bold;
        }
        #tagContent input
        {
            background: none;
            border: none;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        #treatxt
        {
            border: 1px solid #C6E2FF;
            width: 400px;
            height: 60px;
            font-size: 13px;
            resize: none;
        }
        #originalfile
        {
            width: 400px;
            background-color: #B9D3EE;
            margin-top: 5px;
            margin-left: 5px;
        }
        #originalfile tr td
        {
            background-color: White;
            text-align: center;
            height: 20px;
        }
        .clstitleimg
        {
            background-image: url('../../Images/Public/list_tit.png');
            height: 24px;
            text-align: center;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
        }
        .clsborder
        {
            border: 1px solid red !important;
        }
        .content
        {
            padding: 5px;
        }
        .content caption
        {
            background-color: #fff;
            border: 0px;
        }
        table.dataBox
        {
            width: 100%;
        }
        
        table.dataBox td
        {
            padding: 3px;
        }
        table.dataBox td.fieldTitle
        {
            font-family: 宋体;
            font-weight: normal;
            color: #333;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: right;
            font-weight: bold;
        }
        .lineTable td
        {
            border: 1px solid #C1DAD7;
            padding-left: 5px;
        }
        .lineTable tr
        {
            height: 20px;
            line-height: 20px;
        }
        .lineTable
        {
            border: 1px solid #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: #000000;
        }
        
        
        .dataBox
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
        }
        .onetd
        {
            background-color: White;
        }
        .clsunderline
        {
            width: 200px;
            border-bottom: 1px solid #C6E2FF;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: 0;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            margin-bottom: 0px;
        }
        #originalfile
        {
            width: 400px;
            background-color: #B9D3EE;
            margin-top: 5px;
            margin-left: 5px;
        }
        #originalfile tr td
        {
            background-color: White;
            text-align: center;
            height: 20px;
        }
        .clstitleimg
        {
            background-image: url('../../Images/Public/list_tit.png');
            height: 24px;
            text-align: center;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
        }
        .clsborder
        {
            border: 1px solid red !important;
        }
        #optiniontxt
        {
            border: 1px solid #63B8FF;
            height: 60px;
            background-color: #F2F2F2;
            padding-top: 5px;
            line-height: 20px;
            overflow: auto;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            height: 10px;
            text-align: center;
            color: White;
            font-weight: bold;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            //审核通过
            $("#imgbtnpass").click(function () {
                //                if ($.trim($("#treatxt").val()) == "") {
                //                    alert('请填写审批意见!');
                //                    return false;
                //                }
                if (confirm("确定审批通过")) {
                    $("#treatxt").val(encodeURIComponent($("#treatxt").val()));
                    return true;
                }
                else {
                    return false;
                }

            })



            //审核拒绝
            $("#imgbtnrefuse").click(function () {
                //                if ($.trim($("#treatxt").val()) == "") {
                //                    alert('请填写审批意见!');
                //                    return false;
                //                }
                if (confirm("确定拒绝该申请！")) {
                    $("#treatxt").val(encodeURIComponent($("#treatxt").val()));
                    return true;
                }
                else {
                    return false;
                }
            })


        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">保单审批</span>
    </div>
    <div class="border" id="slider">
        <div style="text-align: right">
            <asp:ImageButton runat="server" ID="imgbtnpass" ImageUrl="~/Images/Button/btn_pass.jpg"
                OnClick="imgbtnpass_Click" />
            <asp:ImageButton runat="server" ID="imgbtnrefuse" ImageUrl="~/Images/Button/btn_refuse.jpg"
                OnClick="imgbtnrefuse_Click" />
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <div id="con">
            <ul id="tags">
                <li class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">
                    保单信息</a> </li>
                <li><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">标的信息</a>
                </li>
                <li><a id="budgetTag" onclick="selectTag('tagContent2',this)" href="javascript:void(0)"
                    runat="server">盈亏测算</a> </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <table id="contable" class="dataBox lineTable" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" colspan="6" style="background: #F0F0F0">
                                <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px" align="center" style="font-weight:bold">
                                内部编号
                            </td>
                            <td>
                                <asp:Label ID="LblSerialNum" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight:bold">
                                保单日期
                            </td>
                            <td>
                                <asp:Label ID="LblPolicyDate" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight:bold">
                                制单员
                            </td>
                            <td>
                                <asp:Label ID="LblPolicyMaker" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px" align="center" style="font-weight:bold">
                                保单编号
                            </td>
                            <td>
                                <asp:Label ID="LblPolicyNum" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight:bold">
                                保单状态
                            </td>
                            <td>
                                <asp:Label ID="LblPolicyState" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <%--<td width="80px" align="center" style="font-weight:bold">
                                业务员
                            </td>
                            <td>
                                <asp:Label ID="LblSalesman" runat="server" Text="暂无信息"></asp:Label>
                            </td>--%>
                            <td width="80px" align="center" style="font-weight: bold">
                                制单部门：
                            </td>
                            <td>
                                <asp:Label ID="LblMakerDepart" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px" align="center" style="font-weight:bold">
                                保险期限
                            </td>
                            <td colspan="5">
                                <asp:Label ID="LblTimeStart" runat="server" Text="暂无信息"></asp:Label>
                                到
                                <asp:Label ID="LblTimeEnd" runat="server" Text="暂无信息"></asp:Label>
                                （共&nbsp<asp:Literal ID="ltrYearsCount" runat="server"></asp:Literal>&nbsp年）
                            </td>
                        </tr>
                        <tr>
                            <td width="80px" align="center" style="font-weight:bold">
                                投保客户
                            </td>
                            <td>
                                <asp:Label ID="LblCustomer" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight:bold">
                                是否续保
                            </td>
                            <td>
                                <asp:Label ID="LblIsRenewal" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight:bold">
                                被保险人
                            </td>
                            <td>
                                <asp:Label ID="LblAssured" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px" align="center" style="font-weight:bold">
                                保险公司
                            </td>
                            <td>
                                <asp:Label ID="LblCompany" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight:bold">
                                保险险种
                            </td>
                            <td>
                                <asp:Label ID="LblType" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td  style="font-weight:bold" align="center">
                                经营单位
                            </td>
                            <td>
                                <asp:Label ID="lblUserCompany" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px" align="center" style="font-weight: bold">
                                总保额：
                            </td>
                            <td>
                                <asp:Label ID="zbe" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight: bold">
                                总保费：
                            </td>
                            <td>
                                <asp:Label ID="zbf" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td align="center" style="font-weight: bold">
                                船名：
                            </td>
                            <td>
                                <asp:Label ID="cm" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px" align="center" style="font-weight: bold">
                                经纪费比率：
                            </td>
                            <td>
                                <asp:Label ID="zjjfrate" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td width="80px" align="center" style="font-weight: bold">
                                总贴费：
                            </td>
                            <td>
                                <asp:Label ID="ztf" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                            <td align="center" style="font-weight: bold">
                                总经纪费：
                            </td>
                            <td>
                                <asp:Label ID="zjjf" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="padding-bottom: 10px; padding-right: 5px;">
                                <table id="tabledata" style="width: 100%;">
                                    <caption>
                                        具体保险项目
                                    </caption>
                                    <tr>
                                        <td colspan="8" class="no_border">
                                            <table cellpadding="0" cellspacing="0" border="0" id="table" class="sortable">
                                                <thead>
                                                    <tr>
                                                        <td width="12%" class="clstitleimg" style="padding: 0 0 0 0">
                                                            业务员
                                                        </td>
                                                        <td width="12%" class="clstitleimg">
                                                            部门
                                                        </td>
                                                        <td width="12%" class="clstitleimg">
                                                            业务员占比
                                                        </td>
                                                        <td width="12%" class="clstitleimg">
                                                            经纪费
                                                        </td>
                                                        <td width="12%" class="clstitleimg">
                                                            贴费
                                                        </td>
                                                        <td class="clstitleimg">
                                                            备注
                                                        </td>
                                                    </tr>
                                                </thead>
                                                <tbody id="container">
                                                    <asp:Repeater ID="RpProType" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td align="center">
                                                                    <%# Eval("salesman")%>
                                                                </td>
                                                                <td align="center">
                                                                    <%# Eval("departname")%>
                                                                </td>
                                                                <%--<td align="center">
                                                                    ￥<%# Eval("coverage", "{0:f2}")%></td>
                                                                <td align="center">
                                                                    ￥<%# Eval("premium", "{0:f2}")%></td>--%>
                                                                <td align="center">
                                                                    <%# Eval("numrate") %>
                                                                </td>
                                                                <td align="center">
                                                                    <%# Eval("fmone") %>
                                                                </td>
                                                                <td align="center">
                                                                    <%# Eval("rich") %>
                                                                </td>
                                                                <td align="center">
                                                                    <%# Eval("mark") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <tr class="sum_box">
                                                        <td align="left" colspan="2">
                                                            合计:
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td id="totalCoverage" runat="server" align="center">
                                                            0.00
                                                        </td>
                                                        <td id="totalPremium" runat="server" align="center">
                                                            0.00
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="font-weight:bold">
                                审核状态：
                            </td>
                            <td colspan="5">
                                <asp:Label ID="LblIsVirify" runat="server" Text="暂无信息"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tagContent" id="tagContent1">
                    <uc1:UCTargetPre ID="UCTarget1" runat="server" />
                </div>
                <div id="tagContent2" class="tagContent" runat="server">
                    <uc1:BudgetPre ID="BudgetPre1" runat="server" />
                </div>
                <div style="clear: both">
                </div>
            </div>
        </div>
        <div>
            <table id="originalfile" cellpadding="0" cellspacing="1" runat="server">
                <tr>
                    <td class="clstitleimg" style="width: 20px;">
                    </td>
                    <td class="clstitleimg">
                        名称
                    </td>
                    <td class="clstitleimg" style="width: 40px;">
                        下载
                    </td>
                </tr>
            </table>
        </div>
        <table style="width:100%;padding:0 10px 10px 8px">
            <tr>
                <td style="font-weight:bold">
                    审批意见:
                </td>
            </tr>
            <tr>
                <td >
                    <textarea id="treatxt" runat="server" style="width:100%"></textarea>
                </td>
            </tr>
        </table>
    </div>
    </div>
    <script type="text/javascript">
        function selectTag(showContent, selfObj) {
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
    </form>
</body>
</html>
