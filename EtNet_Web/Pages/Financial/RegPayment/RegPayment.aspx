<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegPayment.aspx.cs" Inherits="EtNet_Web.Pages.Financial.RegPayment.RegPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Policy/tab.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .content
        {
            margin-bottom: 5px;
            padding-bottom: 5px;
            padding-left: 5px;
            padding-right: 5px;
            padding-top: 5px;
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
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            min-width: 100px;
        }
        table.dataBox td
        {
            padding: 5px;
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
            text-align: center;
            padding: 6px 6px 6px 12px;
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
        
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
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
        #mytable2
        {
            border-collapse: collapse;
            width: 100%;
        }
        #mytable2 tr
        {
            background-color: #FFFFFF;
        }
        #mytable2 th
        {
            border: 1px solid #DED6DC;
        }
        #mytable2 tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        #mytable2 tr .sum-title
        {
            text-align: right;
        }
        .invoiceCol
        {
            display: none;
        }
        
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata
        {
            width: 100%;
        }
        .clstxt
        {
            display: inline-block;
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsmtxt
        {
            display: inline-block;
            border: 1px solid #C6E2FF;
            height: 60px;
            width: 100%;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        img
        {
            cursor: pointer;
            border: 0;
        }
        #tblprocess
        {
            width: 100%;
            background-color: #E3E3E3;
        }
        #tblprocess tr td
        {
            background-color: #F0F8FF;
            height: 20px;
        }
        #totalnum
        {
            width: 100%;
            background-color: #E3E3E3;
        }
        #totalnum tr td
        {
            background-color: #F8F8FF;
            height: 20px;
        }
        #originalfile
        {
            background-color: #E3E3E3;
        }
        #originalfile tr td
        {
            background-color: #F0F8FF;
            height: 20px;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            height: 20px;
            text-align: center;
            color: White;
            font-weight: bold;
        }
        .clstitleimg:hover
        {
            color: Black;
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
        .clshdate
        {
            text-align: center;
        }
        .clsdigit, .clsmoney
        {
            text-align: right;
        }
        
        
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
        }
        input.num, input.remark
        {
            width: 100%;
            border: none;
            height: 100%;
            line-height: 100%;
            background-color: #F1F1F1;
        }
        input.num:focus, input.remark:focus
        {
            background-color: #E6E6E6;
        }
        #invoiceTable
        {
            border-collapse: collapse;
            display: none;
        }
        #invoiceTable tbody td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            padding: 0px;
        }
        #czinvoicetable
        {
            border-collapse: collapse;
            margin-top: 0px;
            display: none;
        }
        #czinvoicetable tbody td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            padding: 0px;
        }
        .splitLine
        {
            margin-top: 20px;
        }
        #regTable td
        {
            padding: 5px;
        }
        table#regTable td.fieldTitle
        {
            background-color: transparent;
            border: none;
        }
        
        .style1
        {
            height: 20px;
        }
    </style>
</head>
<body onload="pageload();">
    <form id="form1" runat="server">
    <input type="hidden" id="hidnumrow" runat="server" value="2" />
    <input type="hidden" id="hidremarkrow" runat="server" value="2" />
    <input type="hidden" id="hidnum" runat="server" value="num1" />
    <input type="hidden" id="hidremark" runat="server" value="remark1" />
    <div class="topTitle">
        <span>付款登记</span>
    </div>
    <div class="wrapper">
        <div class="buttonBox">
            <asp:ImageButton ID="btnSave" OnClientClick="return readData();" runat="server" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="btnSave_Click" />
            <a href="RegPaymentList.aspx" onclick="imgbtnsave_Click" title="返回列表">
                <img alt="返回" src="../../../Images/button/btn_back.jpg" /></a>
        </div>
        <div id="con">
            <ul id="tags">
                <li id="tag0" class="selectTag"><a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">
                    付款信息</a> </li>
                <li id="tag1"><a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">财务登记</a>
                </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <div class="content">
                        <table class="dataBox lineTable">
                            <tr>
                                <td colspan="6" style="text-align: center; background: #F0F0F0;" class="style1">
                                    <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="fieldTitle">
                                    申请单号
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblSerialNumber" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="fieldTitle">
                                    申请日期
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblRequestDate" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="fieldTitle">
                                    制单员
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblMaker" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <%--<td class="fieldTitle">
                                    付款类别
                                </td>
                                <td>
                                    <asp:Label ID="lblPaymentType" runat="server" Text=""></asp:Label>
                                </td>--%>
                                <td class="fieldTitle">
                                    支付方式
                                </td>
                                <td>
                                    <asp:Label ID="lblpayType" runat="server" Text=""></asp:Label>
                                </td>
                                <%--<td class="fieldTitle">
                                    收款单位代码
                                </td>
                                <td>
                                    <asp:Label ID="lblPayerCode" runat="server" Text=""></asp:Label>
                                </td>--%>
                                <td class="fieldTitle">
                                    收款单位名称
                                </td>
                                <td>
                                    <asp:Label ID="lblPayerName" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="fieldTitle">
                                    付款类别
                                </td>
                                <td>
                                    <asp:Label ID="lblPayFor" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="fieldTitle">
                                    支付金额合计
                                </td>
                                <td>
                                    <asp:Label ID="lblSumAmount" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="dataBox lineTable">
                            <tr>
                                <td colspan="6" style="text-align: center; background: #F0F0F0;">
                                    <span style="font-weight: bold; font-size: 14px;">付款人银行资料</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="fieldTitle">
                                    开户银行
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblPayBank" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="fieldTitle">
                                    银行账号
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblPayAccount" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="fieldTitle">
                                    开户户名
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblPayAccountName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="dataBox lineTable">
                            <tr>
                                <td colspan="6" style="text-align: center; background: #F0F0F0;">
                                    <span style="font-weight: bold; font-size: 14px;">收款人银行资料</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="fieldTitle">
                                    开户银行
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblBank" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="fieldTitle">
                                    银行账号
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblBankAccount" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="fieldTitle">
                                    开户户名
                                </td>
                                <td width="24%">
                                    <asp:Label ID="lblBankAccountName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="content">
                        <table class="dataBox ">
                            <tr>
                                <td colspan="6" style="padding: 0px;">
                                    <table class="dataBox lineTable">
                                        <tr>
                                            <td colspan="6" style="text-align: center;">
                                                <span style="font-weight: bold; font-size: 14px;">支付明细</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="mytable2" style="text-align: center;" cellspacing="1" class="dataBox">
                                                    <thead>
                                                        <tr>
                                                            <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                                订单编号
                                                            </th>
                                                            <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                                应付金额
                                                            </th>
                                                            <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 33%">
                                                                本次支付金额
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="policyList">
                                                        <asp:Repeater ID="RpPaymentDetail" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <a href="javascript:void(0)" onclick="getOrder('<%# getOrderidpay(Eval("orderPayId").ToString()) %>')">
                                                                            <%# Eval("orderNum")%></a>
                                                                    </td>
                                                                    <td>
                                                                        <%# Eval("shouldPay", "{0:F2}")%>
                                                                    </td>
                                                                    <td>
                                                                        <%# Eval("payAmount","{0:F2}")%>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <tr id="sum" style="color: Blue;">
                                                            <td class="sum-title" colspan="2" align="right">
                                                                合计：
                                                            </td>
                                                            <td id="sumBox" runat="server">
                                                                0.00
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="tagContent" id="tagContent1">
                    <table id="regTable" class="dataBox">
                        <caption>
                            登记信息</caption>
                        <tbody>
                            <tr>
                                <td class="fieldTitle">
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsPay" runat="server" Text="财务支付" />
                                </td>
                                <%--<td class="fieldTitle">
                                    支付方式：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaymentMode" CssClass="inputLine" runat="server">
                                        <asp:ListItem Value="0">现金</asp:ListItem>
                                        <asp:ListItem Value="1">转账</asp:ListItem>
                                        <asp:ListItem Value="2">网银</asp:ListItem>
                                    </asp:DropDownList>
                                </td>--%>
                            </tr>
                            <tr>
                                <td class="fieldTitle">
                                    支付人：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPayer" CssClass="inputLine readonly"  runat="server"></asp:TextBox>
                                </td>
                                <td class="fieldTitle">
                                    支付日期：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaymentDate" CssClass="inputLine readonly Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div class="splitLine">
                                        <span>收票登记</span></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="fieldTitle">
                                    是否收到发票：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlHasInvoiceNum" CssClass="inputLine" runat="server">
                                        <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="fieldTitle">
                                    收到日期：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHasInvoceDate" CssClass="inputLine Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="fieldTitle">
                                    凭证：
                                </td>
                                <td colspan="3">
                                    <input type="text" class="inputLine" id="txtpz" runat="server" style="width: 95%" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script src="../../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".readonly").live("focus", function () {
                $(this).blur();
            });


        });
        function readData() {
            if (!$("#chkIsPay").is(":checked")) {
                alert("勾选财务支付按钮后才能保存");
                return false;
            }
        }

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

            $("#hidTabSatae").val(showContent);
        }

        //查看订单信息
        function getOrder(orderId) {
            debugger;
            if (orderId != "")
                window.open('../../Order/OrderDetial.aspx?id=' + orderId);
            else
                alert('参数错误，找不到该订单');
        }
    </script>
    <input type="hidden" id="hidInvoice" runat="server" />
    <input type="hidden" id="hidInvoiceType" runat="server" />
    </form>
</body>
</html>
