<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecord.aspx.cs" Inherits="EtNet_Web.Pages.Financial.InvoiceRecord.EditRecord" %>

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
            margin-left: 0px;
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
        caption
        {
            padding: 5px;
            font-size: 14px;
            font-weight: bold;
        }
        .num
        {
            width: 98%;
            border: none;
            border-bottom: 1px solid #C6E2FF;
            text-align: center;
            background: #fff;
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
        #hasSum td.sum-title
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
            margin-left: 0px;
        }
    </style>
    <script type="text/javascript">

        /*选择订单*/
        function selectOrder() {
            var cusid = $("#hidComID").val();
            var custxt = $("#txtUnit").val();
            if (custxt != "")
                art.artDialog.open('SelectOrderCollect.aspx?cusId=' + cusid, { width: '600px', height: '420px' }).lock().title('选择订单');
            else
                alert("请先确认付款单位");
        }

        /*验证已经开票信息中开票金额的填写*/
        function checkNum(e) {
            var value = $.trim($(e).val());
            if (value == "") {
                $(e).val("");
                return;
            }
            if (isNaN(value)) {
                $(e).val("");
                return;
            }
            //var amount = $(this).parent().parent().find(".amount").text();
            var amount = $(e).attr("maxvalue");
            if (isNaN(amount)) {
                return;
            }
            if (parseFloat(value) > parseFloat(amount)) {
                $(e).val(amount);
                return;
            }
            else if (value < 0) {
                $(e).val("0");
                return;
            }
            else {
                $(e).val(parseFloat(value).toFixed(2));
            }
        }

        /*保存时读取当前开票明细数据*/
        function readData() {
            debugger;
            var total = 0;
            var detail = "";
            $(".mytable tbody tr:has(input)").each(function () {
                debugger;
                detail += $.trim($(this).find(".cId").text()) + "$";
                detail += $.trim($(this).find(".orderNum").text()) + "$";
                detail += $.trim($(this).find(".amount").text()) + "$";
                detail += $.trim($(this).find("input").eq(0).val()) + "@";
            });

            $("#hidInvoiceDetail").val(detail);
            return true;
        }

        /*在选择订单窗口选择订单后获取所选择的订单数据(以html的方式传递数据)*/
        function getList(listHtml) {
            $("#mytable2 tbody tr:has(input)").remove();
            $("#sum").before(listHtml);
            $(".del").html("<a href='javascript:void(0);' onclick='delRow(this);'><img src='../../../images/public/filedelete.gif'/></a>");
            $(".num").removeAttr("readonly");
            $(".remove").remove();
            $(".num").each(function () {
                $(this).blur(function () {
                    debugger;
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

        /*计算金额合计*/
        function CalcSum() {
            var total1 = 0;
            try {
                $("#mytable2 .num").each(function () {
                    var value = $.trim($(this).val());
                    if (!isNaN(value)) {
                        total1 += parseFloat(value);
                    }
                });
                $("#sumBox").text(total1.toFixed(2));
            } catch (e) {
                $("#sumBox").text("0.00");
            }

            var total2 = 0;
            try {
                $("#mytable1 .num").each(function () {
                    var value = $.trim($(this).val());
                    if (!isNaN(value)) {
                        total2 += parseFloat(value);
                    }
                });
                $("#hasSumBox").text(total2.toFixed(2));
            } catch (e) {
                $("#hasSumBox").text("0.00");
            }

            var total = parseFloat(total1) + parseFloat(total2);
            $("#lblAmount").text(total.toFixed(2));
            $("#hidAmount").val(total);
        }

        /*删除一行数据*/
        function delRow(e) {
            $(e).parent("td").parent("tr").remove();
            CalcSum();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidComID" value="" runat="server" />
    <input type="hidden" id="hidInvoiceDetail" value="" runat="server" />
    <input type="hidden" id="hidAmount" value="0.00" runat="server" />
    <div style="background: url('../../../Images/public/title_hover.png') no-repeat;
        text-align: left; height: 25px;">
        <span style="color: #FFFFFF; padding-left: 5px; font-size: 12px; font-weight: bold;
            line-height: 25px">修改开票记录</span></div>
    <div class="border">
        <span style="display: block; width: 100%; text-align: right;">
            <asp:ImageButton ID="BtnSubmit" OnClientClick="return readData();" runat="server"
                ImageUrl="~/Images/button/btn_save.jpg" ToolTip="保存" OnClick="BtnSubmit_Click"
                Style="height: 21px" />
            <a href="RecordList.aspx" title="取消">
                <img alt="取消" src="../../../Images/button/btn_cancel.jpg" /></a> </span>
        <div style="border: 1px solid #CDC9C9;">
            <table id="dataBox">
                <caption class="style1">
                    开票信息
                </caption>
                <tr>
                    <th>
                        开票日期：
                    </th>
                    <td>
                        <asp:TextBox ID="txtInvoiceDate" dataType="Require" msg="开票日期不能为空" CssClass=" Wdate"
                            Width="200px" onFocus="WdatePicker({isShowClear:false,readOnly:true})" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        开票金额：
                    </th>
                    <td>
                        <asp:Label ID="lblAmount" runat="server" Text="0.00" CssClass="clsunderline" Width="200"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        付款单位：
                    </th>
                    <td>
                        <asp:TextBox ID="txtUnit" runat="server" ReadOnly="false" BackColor="#E2E2E2" Width="250px"></asp:TextBox>
                        <%--<a href="javascript:void(0);" onclick="selectCompany();" title="选择">
                            <img alt="选择" src="../../../Images/public/expand.gif" />
                        </a>--%>
                    </td>
                </tr>
                <tr>
                    <th>
                        开票备注：
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="txtRemakr" runat="server" CssClass="clsunderline" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        登记日期：
                    </th>
                    <td>
                        <asp:Label ID="lblRecordDate" runat="server" Text="label" CssClass="clsunderline"
                            Width="200"></asp:Label>
                    </td>
                    <th>
                        登记人：
                    </th>
                    <td>
                        <asp:Label ID="lblRecordMan" runat="server" Text="label" CssClass="clsunderline"
                            Width="200"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border: 1px solid #CDC9C9; margin-top: 20px; padding: 10px;">
            <table id="mytable1" style="text-align: center;" cellspacing="1" class="mytable">
                <caption class="style1">
                    上次选择订单
                </caption>
                <thead>
                    <tr>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 40px;">
                            删除
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            订单编号
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            应开金额
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            本次开票金额
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpRecordList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="del">
                                    <a href="javascript:void(0);" onclick="delRow(this)" title="删除">
                                        <img src='../../../images/public/filedelete.gif' />
                                    </a>
                                </td>
                                <td class="orderNum">
                                    <%# Eval("orderNum")%>
                                </td>
                                <td class="amount">
                                    <%# Eval("shouldMoney")%>
                                </td>
                                <td>
                                    <input type="text" class="num" onblur="checkNum(this);CalcSum()" maxvalue='<%#Eval("canAmount") %>' value='<%#Eval("invoiceMoney","{0:F2}") %>' />
                                </td>
                                <td class="cId" style="display:none;">
                                    <%#Eval("orderCollectId")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="hasSum" style="color:Blue;">
                        <td class="sum-title" colspan="3" align="right">
                            合计：
                        </td>
                        <td id="hasSumBox" runat="server">
                            0.00
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="border: 1px solid #CDC9C9; margin-top: 20px; padding: 10px;">
            <div style="width: 100%; text-align: left;">
                <a href="javascript:void(0);" title="选择订单" id="selectOrder" onclick="selectOrder()">
                    <img alt="" src="../../../Images/public/fileadd.gif" />
                    选择订单 </a>
            </div>
            <table id="mytable2" style="text-align: center;" cellspacing="1" class="mytable">
                <caption class="style1">
                    开票明细
                </caption>
                <thead>
                    <tr>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 40px;">
                            删除
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            订单编号
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            应开金额
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 30%;">
                            本次开票金额
                        </th>
                    </tr>
                </thead>
                <tbody id="sumList">
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
        </div>
    </div>
    </form>
</body>
</html>
