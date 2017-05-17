<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentAdd.aspx.cs" EnableEventValidation="false"
    Inherits="EtNet_Web.Pages.Financial.Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <script src="../Policy/z.js" type="text/javascript" charset="gb2312"></script>
    <style type="text/css">
        table.dataBox
        {
            width: 100%;
        }
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            font-weight: bold;
        }
        table.dataBox td
        {
            padding: 5px;
        }
        .content
        {
            margin-bottom: 5px;
            padding-bottom: 5px;
        }
        #bankLoading
        {
            display: none;
            vertical-align: middle;
        }
        .mytable
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
        }
        .mytable
        {
            border-collapse: collapse;
            width: 100%;
        }
        .mytable tr
        {
            background-color: #FFFFFF;
        }
        .mytable th
        {
            border: 1px solid #DED6DC;
        }
        .mytable tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        #sum td.sum-title
        {
            text-align: right;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .amount
        {
            width: 98%;
            border: 0px;
            border-bottom: 1px solid #C6E2FF;
            text-align: center;
        }
        table.dataBox #auditpic td
        {
            padding: 0px;
        }
        .hideBtn
        {
            display: none;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
        }
        .invoiceCol
        {
            display: none;
        }
        input
        {
            font-family: 宋体;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="topTitle">
        <span>新增付款申请</span>
    </div>
    <div class="wrapper">
        <div class="buttonBox">
            <a href="javascript:void(0);" id="draft" title="保存草稿">
                <img alt="保存草稿" src="../../images/button/btn_save.jpg" />
            </a><a href="javascript:void(0);" id="approval" title="送审">
                <img alt="送审" src="../../Images/Button/btn_audisend.jpg" />
            </a><a href="PaymentList.aspx" onclick="javascript:void(0);" title="返回列表">
                <img alt="返回" src="../../Images/button/btn_back.jpg" /></a>
            <asp:ImageButton ID="btnSubmit" runat="server" CssClass="hideBtn" Width="0px" Height="0px"
                ImageUrl="" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnApproval" runat="server" Text="" CssClass="hideBtn" Width="0px"
                Height="0px" OnClick="btnApproval_Click" />
        </div>
        <div class="content">
            <table class="dataBox">
                <caption>
                    基本信息</caption>
                <tr>
                    <td class="fieldTitle">
                        申请单号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtSerialNumber" CssClass="inputLine" runat="server"></asp:TextBox>
                        <asp:Label ID="lblAutoCode" runat="server" Style="color: Red;" Text=""></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        申请日期：
                    </td>
                    <td>
                        <asp:TextBox ID="txtRequestDate" dataType="Require" msg="申请日期不能为空" CssClass="inputLine Wdate"
                            onFocus="WdatePicker({isShowClear:false,readOnly:true})" runat="server"></asp:TextBox>
                    </td>
                    <td class="fieldTitle">
                        制单员：
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaker" CssClass="inputLine readonly" dataType="Require" msg="制单员不能为空"
                            runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        收款单位名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPayerName" dataType="Require" msg="付款收款名称不能为空" CssClass="inputLine readonly"
                            runat="server"></asp:TextBox>
                        <a href="javascript:void('0');" id="selectPayer" title="选择收款单位">
                            <img alt="选择" src="../../Images/public/expand.gif" /></a>
                    </td>
                    <td class="fieldTitle">
                        付款类别：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPayType" dataType="Require" msg="收款类别不能为空" CssClass="inputLine readonly"
                            runat="server"></asp:TextBox>
                    </td>
                    <td class="fieldTitle">
                        支付金额合计：
                    </td>
                    <td>
                        <asp:TextBox ID="txtSumAmount" dataType="Require" msg="支付金额合计不能为空" CssClass="inputLine readonly"
                            Text="0.00" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="content">
            <table class="dataBox">
                <tr>
                    <td colspan="6" style="padding: 0px;">
                        <table class="dataBox">
                            <caption style="margin-top: 0px; margin-bottom: 5px;">
                                支付明细
                            </caption>
                            <tr>
                                <td>
                                    <div style="width: 100%; text-align: left;">
                                        <a href="javascript:void(0);" title="" id="selectPolicy">
                                            <img alt="" src="../../Images/public/fileadd.gif" />
                                            <span id="selText">选择订单</span></a>
                                    </div>
                                    <table id="mytable2" style="text-align: center; margin-bottom:20px" cellspacing="1" class="mytable">
                                        <thead>
                                            <tr>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 10%;">
                                                    操作
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%">
                                                    订单编号
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%">
                                                    应付金额
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%">
                                                    本次支付金额
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="policyList">
                                            <tr id="sum" style="color: Blue;">
                                                <td class="sum-title" colspan="3" align="right">
                                                    合计：
                                                </td>
                                                <td id="sumBox">
                                                    0.00
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div style="width:100%; text-align:left;">
                                        <a href="javascript:void(0);" title="" id="selectReturn">
                                            <img alt="" src="../../Images/public/fileadd.gif" /> <span id="selreturntext">选择退款信息</span>
                                        </a>
                                    </div>
                                    <table id="mytable1" style="text-align: center; margin-bottom:20px" cellspacing="1" class="mytable">
                                        <thead>
                                            <tr>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 10%;">
                                                    操作
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%">
                                                    订单编号
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%">
                                                    应退金额
                                                </th>
                                                <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%">
                                                    本次退款金额
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="returnList">
                                            <tr id="returnsum" style="color:Blue;">
                                                <td colspan="3" style="text-align:right">
                                                    合计：
                                                </td>
                                                <td id="returnsumBox">
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
        <div>
            <table class="dataBox">
                <tr>
                    <td colspan="6" style="padding: 0px;">
                        <table class="dataBox">
                            <tr>
                                <td class="fieldTitle">
                                    审核流程：
                                </td>
                                <td colspan="5">
                                    <asp:DropDownList ID="ddlApproval" CssClass="inputLine" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div id="auditpic" class="clsauditpic" runat="server">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".readonly").bind("focus", function () {
                $(this).blur();
            });

            //选择收款单位
            $("#selectPayer").click(function () {
                artDialog.open("SelectCollect.aspx", { width: "640px", height: "460px" }).lock().title("选择收款单位");
            });

            //选择付款类别
            $("#txtPayType").click(function () {
                artDialog.open("SelectPayType.aspx", { width: "310px", height: "350px" }).lock().title("选择付款类别");
            });

            //送审
            $("#approval").click(function () {
                if (beforeSubmit()) {
                    $("#btnApproval").click();
                }
            });

            //保存草稿
            $("#draft").click(function () {
                if (beforeSubmit()) {
                    var dialog = art.dialog({
                        content: '<p>确定要保存为草稿吗？</p>',
                        fixed: true,
                        lock: true,
                        id: 'Fm7',
                        icon: 'question',
                        ok: false,
                        cancel: true,
                        button: [
                                {
                                    name: '保存草稿', callback: function () {
                                        $("#btnSubmit").click();
                                    }
                                },
                                {
                                    name: '直接送审', callback: function () {
                                        $("#btnApproval").click();
                                    }
                                }
                            ]
                    });
                }
            });

            //选择保单
            $("#selectPolicy").click(function () {
                var payer = $.trim($("#hidPayerID").val()); //付款单位id
                var type = $.trim($("#txtPayType").val()); //付款类别
                if (payer == "") { alert("请选择收款单位"); return false; }
                if (type == "") { alert("请选择付款类别"); return false; }
                var url = "SelectOrder.aspx";
                art.artDialog.open(url + "?payer=" + payer + "&&type=" + type, { width: '600px', height: '450px' }).lock().title("选择订单");
            });

            //选择退款信息
            $("#selectReturn").click(function () {
                var payer = $.trim($("#hidPayerID").val()); //付款单位id
                if (payer == "") { alert("请选择收款单位"); return false; }
                art.artDialog.open("SelectOrderReturn.aspx?payer=" + payer, { width: '600px' }).lock().title("选择退款信息");
            });

            //显示审核规则
            $("#ddlApproval").change(function () {
                $.get("../Job/JobFlowHandler.ashx", { sort: 1, flag: $("#ddlApproval").val() }, function (data) {
                    $("#auditpic").html(data);
                    $("#auditpic div").each(function () {
                        var vpath = $(this).css("background-image");
                        if (vpath.lastIndexOf('.') != -1) {
                            var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                            $(this).css({ "background-image": str });
                        }
                    })

                });
            });

            $("#ddlPaymentType").change(function () {
                if ($.trim($(this).val()) == "1") {
                    $(".invoiceCol").show();
                    $("td.sum-title").attr("colspan", "6");
                    $("#selText").text("选择费用发票");
                }
                else {
                    $(".invoiceCol").hide();
                    $("td.sum-title").attr("colspan", "3");
                    $("#selText").text("选择保单");
                }
                $("#mytable2 tbody tr:has(input)").remove();
            });
        });


        //加载保单数据
        function getList(listHTML) {
            $("#mytable2 tbody tr:has(input)").remove();
            $("#sum").before(listHTML);
            $(".del").html("<a href='javascript:void(0);' title='移除项' onclick='delRow(this);'><img src='../../images/public/filedelete.gif'/></a>")
            $(".amount").removeAttr("readonly");
            $(".nouse").remove();
            $(".amount").each(function () {
                $(this).blur(function () {
                    var value = $.trim($(this).val());
                    if (value == "") {
                        $(this).val("");
                        return;
                    }
                    if (isNaN(value)) {
                        $(this).val("");
                        return;
                    }
                    //var amount = $(this).parent().parent().find(".amount").text();
                    var amount = $(this).attr("maxvalue");
                    if (isNaN(amount)) {
                        return;
                    }
                    if (parseFloat(value) > parseFloat(amount)) {
                        alert("输入金额过大，最多输入" + amount);
                        $(this).val(amount);
                        return;
                    }
                    else if (value < 0) {
                        alert("输入金额过小，最小输入0.00");
                        $(this).val("0.00");
                        return;
                    }
                    else {
                        $(this).val(parseFloat(value).toFixed(2));
                    }
                });
            });
            CalcSum();

            $(".amount").blur(function () {
                CalcSum();
            });
        }

        function getReturnList(listHTML) {
            $("#mytable1 tbody tr:has(input)").remove();
            $("#returnsum").before(listHTML);
            $(".del").html("<a href='javascript:void(0);' title='移除项' onclick='delRow(this);'><img src='../../images/public/filedelete.gif'/></a>")
            $(".amount").removeAttr("readonly");
            $(".nouse").remove();
            $(".amount").each(function () {
                $(this).blur(function () {
                    var value = $.trim($(this).val());
                    if (value == "") {
                        $(this).val("");
                        return;
                    }
                    if (isNaN(value)) {
                        $(this).val("");
                        return;
                    }
                    //var amount = $(this).parent().parent().find(".amount").text();
                    var amount = $(this).attr("maxvalue");
                    if (isNaN(amount)) {
                        return;
                    }
                    if (parseFloat(value) > parseFloat(amount)) {
                        alert("输入金额过大，最多输入" + amount);
                        $(this).val(amount);
                        return;
                    }
                    else if (value < 0) {
                        alert("输入金额过小，最小输入0.00");
                        $(this).val("0.00");
                        return;
                    }
                    else {
                        $(this).val(parseFloat(value).toFixed(2));
                    }
                });
            });
            CalcSum();
            $(".amount").blur(function () {
                CalcSum();
            });
        }

        function delRow(e) {
            //if ($("#mytable2 tbody tr").length <= 1) {
            //alert("至少保留一条数据");
            //}
            //else {
            $(e).parent("td").parent("tr").remove();
            CalcSum();
            //}
        }

        function CalcSum() {
            var total = 0;
            var returnTotal = 0;
            try {
                $("#mytable2 .amount").each(function () {
                    var value = $.trim($(this).val());
                    if (!isNaN(value) && value != "") {
                        total += parseFloat(value);
                    }
                });
                $("#mytable1 .amount").each(function () {
                    var value1 = $.trim($(this).val());
                    if (!isNaN(value1) && value1 != "") {
                        returnTotal += parseFloat(value1);
                    }
                });
                $("#sumBox").text(total.toFixed(2));
                $("#returnsumBox").text(returnTotal.toFixed(2));
                $("#txtSumAmount").val((total - returnTotal).toFixed(2));
            } catch (e) {
                $("#sumBox").text("0.00");
                $("#returnsumBox").text("0.00");
                $("#txtSumAmount").text("0.00");
            }
        }

        function beforeSubmit() {
            if (Validator.Validate(document.getElementById('form1'), 1)) {
                if ($.trim($("#ddlApproval").val()) == "" || $.trim($("#ddlApproval").val()) == "-1") {
                    alert("请选择审核流程");
                    return false;
                }
                else {
                    var detail = "";
                    var payReturn = "";
                    $("#mytable2 tbody tr:has(input)").each(function () {
                        detail += $.trim($(this).find(".pid").text()) + "$"; //订单付款信息明细表id
                        detail += $.trim($(this).find(".pnum").text()) + "$"; //订单编号
                        detail += $.trim($(this).find(".shouldAmount").text()) + "$"; //应付金额
                        detail += $.trim($(this).find("input").val()) + "@"; //本次支付金额
                    });
                    $("#hidPayDetail").val(detail);
                    $("#mytable1 tbody tr:has(input)").each(function () {
                        payReturn += $.trim($(this).find(".pid").text()) + "$"; //订单id
                        payReturn += $.trim($(this).find(".pnum").text()) + "$"; //订单编号
                        payReturn += $.trim($(this).find(".shouldAmount").text()) + "$"; //应退金额
                        payReturn += $.trim($(this).find("input").val()) + "@"; //本次退款金额
                    });
                    $("#hidPayReturn").val(payReturn);

                    return true;
                }
            }
            else {
                return false;
            }
        }
    </script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <input id="hidPayerID" type="hidden" runat="server" />
    <input id="hidPayerType" type="hidden" runat="server" />
    <%--存储付款类别id、--%>
    <input id="hidSalesmanID" type="hidden" runat="server" />
    <input id="hidPayDetail" type="hidden" runat="server" />
    <input id="hidPayReturn" type="hidden" runat="server" />
    </form>
</body>
</html>
