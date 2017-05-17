<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClaimAdd.aspx.cs" Inherits="EtNet_Web.Pages.Financial.ToClaim.ClaimAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../../Policy/z.js" type="text/javascript" charset="gb2312"></script>
    <link href="../../../CSS/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a
        {
            text-decoration: none;
        }
        a img
        {
            border: none;
        }
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
            overflow: auto;
            min-width: 880px;
        }
        table#dataBox
        {
            width: 100%;
        }
        table#dataBox th
        {
            width: 20%;
            text-align: right;
            color: #444444;
        }
        table#dataBox td
        {
            padding: 5px;
            width: 30%;
        }
        table#dataBox input
        {
            border: 0px;
            border-bottom: 1px solid #C6E2FF;
        }
        table#dataBox input, table#dataBox select
        {
            width: 200px;
        }
        table#dataBox input#txtUnit
        {
            margin-left: 10px;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
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
        .num
        {
            width: 98%;
            border: 0px;
            border-bottom: 1px solid #C6E2FF;
            text-align: center;
        }
        .remark
        {
            width: 98%;
            border: 0px;
            border-bottom: 1px solid #C6E2FF;
            text-align: right;
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
        #sum
        {
            color: Blue;
        }
        #chkFinish
        {
            cursor: pointer;
        }
        .style1
        {
            font-size: 20px;
            background-color: #CCCCCC;
            font-weight: 700;
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
            margin-left: 10px;
        }
    </style>
    <script type="text/javascript">
        function selectPolicy() {
            var payer = $("#hidComID").val();
            var paytxt = $("#txtUnit").val();
            if (paytxt != "")
                art.artDialog.open('SelectPolicy.aspx?payer=' + payer, { width: '600px', height: '420px' }).lock().title('选择订单');
            else
                alert("请先确认付款单位");
        }

        //选择单位
        function selectCompany() {
            art.artDialog.open("../SelectPayerUnit.aspx?cusName=s", { width: "690px" }).lock().title("选择付款单位");
        }

        $(document).ready
        (
            function () {
                $("#selectPolicy").bind("click", selectPolicy);


                $("#chkBox,#chkFinish").click(function () {
                    if ($("#chkFinish").attr("checked")) {
                        $("#chkFinish").removeAttr("checked");
                        setEnable(false);
                        return;
                    }
                    var toatl = 0;
                    var amount = parseFloat($.trim($("#HidReceiptAmount").val()));

                    $("#mytable2 .num").each(function () {
                        toatl += parseFloat($.trim($(this).val()));
                    });
                    toatl = toatl.toFixed(2);
                    amount = amount.toFixed(2);
                    if (isNaN(toatl)) {
                        alert("输入金额不正确");
                        $("#chkFinish").removeAttr("checked");
                        return false;
                    }
                    if (toatl > amount) { 
                        alert("输入金额总数大于收款金额");
                        $("#chkFinish").removeAttr("checked");
                        return false;
                    }
                    else if (toatl < amount) { 
                        alert("输入金额总数小于收款金额，未完成收款");
                        $("#chkFinish").removeAttr("checked");
                        return false;
                    } 
                    else {
                        $("#chkFinish").attr("checked", "checked");
                        setEnable(true);
                    }
                });
            }
        );

        function getList(listHtml) {
            $("#mytable2 tbody tr:has(input)").remove();
            $("#sum").before(listHtml);
            $(".del").html("<a href='javascript:void(0);' onclick='delRow(this);'><img src='../../../images/public/filedelete.gif'/></a>");
            $(".num").removeAttr("readonly");
            $(".remove").remove();
            $(".num").each(function () {
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
                        $(this).val(amount);
                        return;
                    }
                    else if (value < 0) {
                        $(this).val("0");
                        return;
                    }
                    else {
                        $(this).val(parseFloat(value).toFixed(2));
                    }
                });
            });
            CalcSum();

            $(".num").blur(function () {
                CalcSum();
            });
        }

        function setEnable(falg) {
            if (falg) {
                $("#mytable2 .num").attr("readonly", "readonly");
                $(".del").find("a").attr("onclick", "alert('已确认完成收款，不能删除')");
                $("#selectPolicy").unbind();
                $("#selectPolicy").bind("click", function () { alert("请先取消确认，才能继续操作"); })
            }
            else {
                $("#selectPolicy").unbind();
                $("#selectPolicy").bind("click", selectPolicy);
                $(".del").find("a").attr("onclick", "delRow(this);");
            }
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

        function readData() {
            if (Validator.Validate(document.getElementById('form1'), 1)) {
                var toatl = 0;
                var amount = parseFloat($.trim($("#HidReceiptAmount").val()));
                var detail = "";
                $("#mytable2 tbody tr:has(input)").each(function () {
                    detail += $.trim($(this).find(".pid").text()) + "$"; //收款单位明细id
                    detail += $.trim($(this).find(".orderNum").text()) + "$"; //订单序号
                    detail += $.trim($(this).find(".amount").text()) + "$"; //应收金额
                    detail += $.trim($(this).find("input").eq(0).val()) + "$"; //本次认领金额
                    detail += $.trim($(this).find("input").eq(1).val()) + "@"; //备注
                    toatl += parseFloat($.trim($(this).find("input").eq(0).val())); //本次认领金额合计
                    debugger;
                });
                if (toatl.toFixed(2) > amount.toFixed(2)) {  
                    alert("输入金额总数大于收款金额");
                    return false;
                }
                $("#HidClaimDetail").val(detail);
                return true;
            }
            else {
                return false;
            }
        }


        function CalcSum() {
            var toatl = 0;

            try {
                $(".num").each(function () {
                    var value = $.trim($(this).val());
                    if (!isNaN(value)) {
                        toatl += parseFloat(value);
                    }
                });
                $("#sumBox").text(toatl.toFixed(2));
            } catch (e) {
                $("#sumBox").text("0.00");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background: url('../../../Images/public/title_hover.png') no-repeat;
        text-align: left; height: 25px;">
        <span style="color: #FFFFFF; padding-left: 5px; font-size: 12px; font-weight: bold;
            line-height: 25px">收款认领</span></div>
    <div class="border">
        <span style="display: block; width: 100%; text-align: right;">
            <asp:ImageButton ID="BtnSubmit" OnClientClick="return readData();" runat="server"
                ImageUrl="~/Images/button/btn_save.jpg" ToolTip="保存" OnClick="BtnSubmit_Click"
                Style="height: 21px" />
            <a href="ClaimList.aspx" title="取消认领">
                <img alt="取消认领" src="../../../Images/button/btn_cancel.jpg" /></a> </span>
        <div style="border: 1px solid #CDC9C9;">
            <table id="dataBox">
                <caption class="style1">
                    认领信息
                </caption>
                <tr>
                    <th>
                        收款单号：
                    </th>
                    <td>
                        <asp:Label ID="LblNumber" runat="server" Text="Label" CssClass="clsunderline" Width="200"></asp:Label>
                    </td>
                    <th>
                        收款金额：
                    </th>
                    <td>
                        <asp:Label ID="LtrAmount" runat="server" Text="Label" CssClass="clsunderline" Width="200"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        付款单位：
                    </th>
                    <td>
                        <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox>
                        <a href="javascript:void(0);" onclick="selectCompany();" title="选择">
                            <img alt="选择" src="../../../Images/public/expand.gif" />
                        </a>
                    </td>
                    <th>
                        认领人员：
                    </th>
                    <td>
                        <asp:Label ID="LblMaker" runat="server" Text="Label" CssClass="clsunderline" Width="200"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border: 1px solid #CDC9C9; margin-top: 20px; padding: 10px;">
            <div style="width: 100%; text-align: left;">
                <a href="javascript:void(0);" title="选择订单" id="selectPolicy">
                    <img alt="" src="../../../Images/public/fileadd.gif" />
                    选择订单 </a>
            </div>
            <table id="mytable2" style="text-align: center;" cellspacing="1" class="mytable">
                <caption class="style1">
                    分摊信息
                </caption>
                <thead>
                    <tr>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 40px;">
                            删除
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 24%;">
                            订单编号
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 24%;">
                            应收金额
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 24%;">
                            本次收款金额
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 24%;">
                            收款备注
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
                        <td>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="border: 1px solid #CDC9C9; margin-top: 20px; padding: 10px; text-align: right;
            vertical-align: middle;">
            <span id="chkBox" style="cursor: pointer;">
                <input id="chkFinish" type="checkbox" runat="server" style="vertical-align: middle;" />确认完成收款？</span>
        </div>
    </div>
    <input id="HidMaker" type="hidden" runat="server" />
    <input id="HidPayer" type="hidden" runat="server" />
    <input id="hidComID" type="hidden" runat="server" />
    <input id="HidClaimDetail" type="hidden" runat="server" />
    <input id="HidReceiptAmount" type="hidden" runat="server" />
    </form>
</body>
</html>
