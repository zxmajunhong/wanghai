<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReimbursedForm.aspx.cs"
    Inherits="EtNet_Web.Pages.Job.ReimbursedForm.AddReimbursedForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增报销申请</title>
    <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
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
        .clsunderline
        {
            width: 180px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsaddtxt
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #1E90FF;
            float: left;
            margin-right: 5px;
        }
        .clsdatalist
        {
            width: 200px;
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
            border: 1px solid #C6E2FF;
            height: 60px;
            resize: none;
            width: 100%;
            font-size: 12px;
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
        }
        #tblprocess
        {
            width: 100%;
            background-color: #E3E3E3;
        }
        #tblprocess tr td
        {
            background-color: #F0F8FF;
        }
        #tblprocess tr td input
        {
            border: 0;
            background-color: #F0F8FF;
            width: 98%;
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
        .imgadd
        {
            background-image: url('../../../Images/public/iconadd.png');
            width: 16px;
            height: 16px;
            cursor: pointer;
        }
        .imgdel
        {
            background-image: url('../../../Images/public/icondelete.png');
            width: 16px;
            height: 16px;
            cursor: pointer;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            height: 20px;
            color: White;
            text-align: center;
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
        .datebox
        {
            border: 0;
        }
        .combo-text
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .imgbtnstyle
        {
            background: url('../../../Images/Common/buticon.gif');
            height: 22px;
            width: 64px;
            float: right;
            margin-right: 5px;
            text-align: center;
            line-height: 22px;
            cursor: pointer;
            border: 0;
            display: inline-block;
        }
        .clshdate
        {
            cursor: pointer;
            text-align: center;
            height: 30px;
        }
        .clsdigit, .clsmoney
        {
            text-align: right;
            font-size: 11px;
        }
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            font-weight: bold;
            height: 26px;
        }
        #addfile
        {
            margin-right: 0px;
        }
        .biaoti
        {
            background: #F0F0F0;
            text-align: center;
            font-weight: bold;
            font-size: 14px;
        }
        .style10
        {
            width: 401px;
        }
        
        .stylecenter
        {
            text-align: center;
        }
        #orderList td
        {
            text-align: center;
            height: 30px;
        }
        #mytable2 img
        {
            border: 0;
        }
    </style>
    <script src="../../Common/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Common/artDialog.js" type="text/javascript"></script>
    <script src="../../Common/iframeTools.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //动态新增文件上传控件
            var num = 1;
            $("#imgadd").click(function () {
                var str = '<tr><td></td><td><input type="file" name="addfile" /></td>'
                str += '<td><img class="imgaddfile" alt="删除" src="../../../Images/public/delete.gif" /></td></tr>'
                if (num == 5) {
                    alert("最多上传5个附件!");
                }
                else {
                    $("#addfile").append(str);
                    num++;
                }
            })



            //删除新增的上传控件
            $(".imgaddfile").live("click", function () {
                $(this).parent().parent().remove();
                num--;

            });


            //显示审核规则
            $("#ddlrule").change(function () {
                $.get("../JobFlowHandler.ashx", { sort: 1, flag: $("#ddlrule").val() }, function (data) {
                    $("#auditpic").html(data);
                });
            })


            //隔行显示不同的背景色
            function showline() {
                $("#tblprocess tr:odd td").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的行
                $("#tblprocess tr:even td").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的行
                $("#tblprocess tr:odd td input:text").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的文本框
                $("#tblprocess tr:even td input:text").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的文本框
            }
            showline();

            //加一行
            $(".imgadd").click(function () {

                var blongid = new Number(document.getElementById("hidblongrows").value);
                var salemanid = new Number(document.getElementById("hidsalemanrows").value);
                var itemid = new Number(document.getElementById("hiditemrows").value);
                var departid = new Number(document.getElementById("hiddepart").value);

                var blong = "blong" + blongid;
                var saleman = "saleman" + salemanid;
                var item = "item" + itemid;
                var depart = "depart" + departid;


                var str = '<tr><td class="clshdate"  class="AusType" > ' + document.getElementById("date").innerHTML + '</td>';

                str += '<td onclick=' + "document.getElementById('hidausitem').value" + "=" + "$(this).find('input').attr('id')," + "artDialog.open('AusItem.aspx')" + '><input type="text" id=' + item + ' class="AusItem" style="text-align: center"></td>';
                str += '<td onclick=' + "document.getElementById('hidblong').value" + "=" + "$(this).find('input').attr('id')," + "artDialog.open('BlongDepartment.aspx')" + '><input type="text"/ id=' + blong + ' style="text-align: center" value=' + document.getElementById("blong1").value + '></td>';
                str += '<td class="clssalse" id=' + depart + '><input type="text"/ id=' + saleman + ' class="Salesman" style="text-align: center" value=' + document.getElementById("saleman1").value + '></td>';

                str += '<td><input type="text" class="clsdigit"/></td>';
                str += '<td><input type="text" class="clsmoney"/></td>';
                str += '<td><input type="text"/></td>';
                str += '<td align="center">';
                str += '<div class="imgdel">&nbsp;</div></td></tr>';
                $("#tblprocess").append(str);
                if (!("#" + depart).onclick) {
                    $("#" + depart).bind('click', function () {
                        document.getElementById('hidsaleman').value = $(this).find('input').attr('id');
                        var value = $("#" + blong).val();
                        artDialog.open('Salesman.aspx?depart=' + value, { width: '310px', height: '480px' }).lock().title('选择所属报销人员');
                    });
                }
                showline();
                document.getElementById("hidblongrows").value = blongid + 1;
                document.getElementById("hidsalemanrows").value = salemanid + 1;
                document.getElementById("hiditemrows").value = itemid + 1;
                document.getElementById("hiddepart").value = departid + 1;
            })

            //减一行
            $(".imgdel").live("click", function () {
                $(this).parent("td").parent("tr").remove();
                showline();
            })

            //保存草稿或提交
            $("#ibtnSubmit,#ibtnSave").click(function () {
                var str = "";
                if (checkdetial()) {
                    savedetail();
                    saveOrderDetail();
                    calculationamount();
                    var rgt = /[\W]/;
                    if (rgt.test($("#iptnumbers").val())) {
                        str += "请注意输入的单据名称只能包含字母与数字!\n";
                    }
                    if ($("#ddlrule").val() == "0" || $("#auditpic").html() == "") {
                        str += "审批流程未选或有误\n";
                    }
                    if ($(".AusItem").val() == "") {
                        str += "项目类别第一行不能为空！\n";
                    }
                    if ($(".BlongDepartment").val() == "") {
                        str += "部门第一行不能为空！\n";
                    }
                    if ($(".Salesman").val() == "") {
                        str += "报销人员第一行不能为空！\n";
                    }
                    if (str) {
                        alert(str);
                        return false;
                    }
                    else {
                        return true;
                    }
                }
                else {
                    return false;
                }
            })


            //检验报销明细
            function checkdetial() {
                var result = true;
                $("#tblprocess .clshdate").each(function () {
                    var date = $.trim($(this).text());
                    if (date == "") {
                        alert('请确认发生日期是否全部填写');
                        result = false;
                    }
                    if (!result) {
                        return false;
                    }
                });
                $("#tblprocess input").each(function () {
                    var strnum = $(this).val();
                    // var rg = new RegExp("^(0|[1-9][0-9]*|(0\.[0-9]+)|([1-9][0-9]*\.[0-9]+))$");

                    var rg = new RegExp("^(0|[1-9][0-9]*)\.[0-9][0-9]$");
                    rg.global = true;

                    var rgdigit = new RegExp("^(0|[1-9][0-9]*)$");
                    rgdigit.global = true;

                    var rgtxt = /['|,<">]/
                    if ($(this).hasClass("AusItem")) {
                        if (strnum == "") {
                            alert('请确认项目类别是否全部填写');
                            result = false;
                        }
                    }
                    if ($(this).hasClass("BlongDepartment")) {
                        if (strnum == "") {
                            alert('请确认部门是否全部填写');
                            result = false;
                        }
                    }
                    if ($(this).hasClass("Salesman")) {
                        if (strnum == "") {
                            alert('请确认业务员是否全部填写');
                            result = false;
                        }
                    }
                    if ($(this).hasClass("clsdigit")) {
                        if (strnum == "") {
                            alert('请确认票据张数是否填写');
                            result = false;
                        }
                    }
                    if ($(this).hasClass("clsmoney")) {
                        if (strnum == "") {
                            alert('请确认报销金额是否填写');
                            result = false;
                        }
                    }
                    if (rgtxt.test(strnum)) {
                        alert('请勿在报销明细中的任何可编辑项中输入括号中的字符[|\'"<>]');
                        result = false;
                    }
                    if ($(this).hasClass("clsmoney")) {
                        if (strnum && !rg.test(strnum)) {
                            alert("金额格式不正确,金额只保留两位小数,且小数点之前必须有一位!")
                            result = false;
                        }
                    }
                    if ($(this).hasClass("clsdigit")) {
                        if (strnum && !rgdigit.test(strnum)) {
                            alert("票据张数格式不正确!")
                            result = false;
                        }
                    }
                    if (!result) {
                        return false;
                    }
                });
                return result;
            }


            //保存报销明细
            function savedetail() {
                var list = "";
                $("#tblprocess tr:gt(1)").each(function () {
                    var txt = "";
                    txt = $.trim($(this).find("td.clshdate").text());
                    txt += "|" + $.trim($(this).find("input:text:eq(0)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(1)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(2)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(3)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(4)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(5)").val());
                    if (txt.length != 7) {
                        if (list == "") {
                            list = txt;
                        }
                        else {
                            list += "," + txt;
                        }
                    }
                })

                $("#hiddetail").val(list);
            }

            //保存订单明细
            function saveOrderDetail() {
                var list = "";
                $("#orderList tr").each(function () {
                    list += $.trim($(this).find(".orderId").text()) + "|";
                    list += $.trim($(this).find(".orderNum").text()) + "|";
                    list += $.trim($(this).find(".orderType").text()) + "|";
                    list += $.trim($(this).find(".outTime").text()) + "|";
                    list += $.trim($(this).find(".natrue").text()) + "|";
                    list += $.trim($(this).find(".tour").text()) + ",";
                });
                $("#hidorderdetail").val(list);
            }



            //计算总金额
            function calculationamount() {
                var amount = 0;
                $(".clsmoney").each(function () {
                    if ($.trim($(this).val()) != "") {
                        amount += parseFloat($(this).val());
                    }
                })
                $("#hidmoney").val(amount);

            }



            //合计票据张数
            $(".clsdigit").live("keyup", function () {
                var rgdigit = new RegExp("^(0|[1-9][0-9]*)$");
                var total = 0;
                $(this).val($.trim($(this).val()));
                var strdigit = $(this).val();
                var isempty = true;
                if (strdigit == "") {
                    $(".clsdigit").each(function () {
                        if ($(this).val() != "") {
                            isempty = false;
                        }
                    })
                    if (isempty) {
                        $("#lblalldigit").text("");
                        return;
                    }
                }
                if (rgdigit.test(strdigit) || strdigit == "") {
                    $(".clsdigit").each(function () {
                        if ($(this).val() != "") {
                            total += parseInt($(this).val());
                        }
                    })
                    $("#lblalldigit").text(total + "(张)");
                }
                else {
                    alert('输入有误,不能输入数字以外的字符')
                    $(this).val(strdigit.replace(/[^0-9]/g, ""));
                }
            })




            //合计金额
            $(".clsmoney").live("keyup", function () {
                var total = 0
                var rg = /^(0[0-9].*)|(.*\.\d{3,})$/
                $(this).val($.trim($(this).val()));
                var strmoeny = $(this).val();
                var isempty = true;
                if (strmoeny == "") {
                    $(".clsmoney").each(function () {
                        if ($(this).val() != "") {
                            isempty = false;
                        }
                    })
                    if (isempty) {
                        $("#lblallmoney").text("");
                        return;
                    }
                }

                if (isNaN(strmoeny) || rg.test(strmoeny)) {
                    alert('输入格式有误')
                    $(this).val("");
                }
                $(".clsmoney").each(function () {
                    if ($(this).val() != "") {
                        total += parseFloat($(this).val());
                    }
                })

                if (total != 0) {
                    $("#lblallmoney").text("￥" + total.toFixed(2))
                }
                else {
                    $("#lblallmoney").text("")
                }

            })




            //金额格式补全
            $(".clsmoney").live("blur", function () {
                var strmoney = $(this).val()
                if (strmoney == "") {
                    return;
                }
                rg = new RegExp("^(0|[1-9][0-9]*)$");
                if (rg.test(strmoney)) {
                    $(this).val(strmoney + ".00");
                    return;
                }
                rg = new RegExp("^(0|[1-9][0-9]*)\.$");
                if (rg.test(strmoney)) {
                    $(this).val(strmoney + "00");
                    return;
                }
                rg = new RegExp("^(0|[1-9][0-9]*)\.[0-9]$");
                if (rg.test(strmoney)) {
                    $(this).val(strmoney + "0");
                    return;
                }
            })




            $(".clshdate").live("mouseover", function () {
                $(this).attr("title", "点击设置时间")
            })


            var objhdate = null;

            $("#ipthdate").datebox();

            $(".clshdate").live("click", function () {
                objhdate = $(this);
                if ($(this).text() != "") {
                    $("#ipthdate").datebox("setValue", $(this).text());
                }
                $("#showhdate").show()
                $("#showhdate").dialog({
                    width: 300,
                    height: 100,
                    resizable: false,
                    closable: false,
                    title: "选择发生时间",
                    modal: true

                });

            })


            //确定发生日期
            $("#btns").click(function () {
                $(objhdate).text($("#ipthdate").datebox("getValue"))
                $("#showhdate").dialog("close");
            })


            //取消
            $("#btnc").click(function () {
                $("#showhdate").dialog("close");
            })

            //项目类别
            $('.AusItem').click(function () {
                artDialog.open('AusItem.aspx', { width: '310px', height: '480px' }).lock().title('选择所属项目类别');
            });

            //业务员
            $('.Salesman').click(function () {
                var value = document.getElementById('blong1').value;
                artDialog.open('Salesman.aspx?depart=' + value, { width: '310px', height: '480px' }).lock().title('选择所属报销人员');
            });
            //发票内容
            $('.AusType').click(function () {

                artDialog.open('AusType.aspx', { width: '310px', height: '480px' }).lock().title('选择所属发票内容');
            });
            //费用归属
            $('.BlongDepartment').click(function () {
                artDialog.open('BlongDepartment.aspx', { width: '310px' }).lock().title('选择所属部门');
            });

            //选择订单
            $("#selectOrder").click(function () {
                artDialog.open('SelectOrder.aspx', { width: '900px' }).lock().title('选择订单');
            });
        })

        //得到订单信息
        function getList(listHtml) {
            $("#orderList").html(listHtml);
            $(".del").html("<a href='javascript:void(0);' onclick='delRow(this);'><img src='../../../images/public/filedelete.gif' /></a>");
        }

        //删除行
        function delRow(e) {
            $(e).parent("td").parent("tr").remove();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input id="ty1" type="hidden" runat="server" />
    <input type="hidden" runat="server" id="hiddetail" />
    <input type="hidden" runat="server" id="hidorderdetail" />
    <input type="hidden" runat="server" id="hidmoney" />
    <input type="hidden" runat="server" id="hidblongrows" value="2" />
    <input type="hidden" runat="server" id="hidsalemanrows" value="2" />
    <input type="hidden" runat="server" id="hiditemrows" value="2" />
    <input type="hidden" runat="server" id="hiddepart" value="2" />
    <input type="hidden" runat="server" id="hidblong" value="blong1" />
    <input type="hidden" runat="server" id="hidsaleman" value="saleman1" />
    <input type="hidden" runat="server" id="hidausitem" value="item1" />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        新增报销申请
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right; width: 99%">
            <asp:ImageButton ID="savesubmit" runat="server" ImageUrl="~/Images/Button/btn_audisend.jpg"
                OnClick="savesubmit_Click" Visible="false" />
            <asp:ImageButton ID="ibtnSubmit" runat="server" ImageUrl="~/Images/Button/btn_audisend.jpg"
                OnClick="ibtnSubmit_Click" />
            <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="ibtnSave_Click" />
            <asp:ImageButton ID="ibtnReset" runat="server" ImageUrl="~/Images/Button/btn_reset.jpg"
                OnClick="ibtnReset_Click" />
            <asp:ImageButton ID="imgbtnback" runat="server" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
            <table class="clsdata">
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle" style="width: 90px">
                        报销单号:
                    </td>
                    <td>
                        <input type="text" id="iptnumbers" runat="server" class="clsunderline" />
                        <span id="showauto" runat="server" style="color: Red;"></span>
                    </td>
                    <td class="fieldTitle" style="width: 90px">
                        报销日期:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="lblapplydate" CssClass="clstxt"></asp:TextBox>
                        &nbsp;
                    </td>
                    <td class="fieldTitle" style="width: 90px">
                        填单人员:
                    </td>
                    <td>
                        <asp:Label runat="server" CssClass="clstxt" ID="lblcanme"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle" style="width: 90px">
                        收款账户:
                    </td>
                    <td>
                        <input type="text" id="txtbanker" runat="server" class="clsunderline" />
                    </td>
                    <td class="fieldTitle" style="width: 90px">
                        收款银行:
                    </td>
                    <td>
                        <input type="text" id="txtbankname" runat="server" class="clsunderline" />
                    </td>
                    <td class="fieldTitle" style="width: 90px">
                        收款帐号:
                    </td>
                    <td>
                        <input type="text" id="txtbanknum" runat="server" class="clsunderline" />
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle" style="width: 90px">
                        备注:
                    </td>
                    <td colspan="6" style="padding-right: 5px;">
                        <input type="text" id="iptremark" runat="server" style="width: 1000px" class="clsunderline" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
            <table class="clsdata" id="mytable2">
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">订单信息</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div style="width: 100%; text-align: left;">
                            <a href="javascript:void(0);" title="" id="selectOrder">
                                <img alt="" src="../../../Images/public/fileadd.gif" style="border: 0" />
                                <span id="selText">选择订单</span></a>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 5%;">
                        操作
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                        订单序号
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                        订单类型
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                        出团日期
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                        性质
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                        旅游线路
                    </th>
                </tr>
                <tbody id="orderList" runat="server">
                </tbody>
            </table>
        </div>
        <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
            <table id="tblprocess" cellspacing="1" cellpadding="0" runat="server">
                <tr>
                    <td align="center" colspan="9" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">报销明细</span>
                    </td>
                </tr>
                <tr>
                    <td class="clstitleimg" style="width: 100px;">
                        发生日期
                    </td>
                    <td class="clstitleimg" style="width: 100px;">
                        项目类别
                    </td>
                    <td class="clstitleimg" style="width: 100px;">
                        部门
                    </td>
                    <td class="clstitleimg" style="width: 100px;">
                        报销人员
                    </td>
                    <td class="clstitleimg" style="width: 100px;">
                        票据张数
                    </td>
                    <td class="clstitleimg" style="width: 100px;">
                        报销金额
                    </td>
                    <td class="clstitleimg">
                        详细说明
                    </td>
                    <td class="clstitleimg" style="width: 60px;">
                        操作
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td style="height: 30px" class="clshdate" id="date">
                    </td>
                    <td onclick="document.getElementById('hidausitem').value=$(this).find('input').attr('id')">
                        <input type="text" class="AusItem" id="item1" readonly="readonly" style="text-align: center" />
                    </td>
                    <td onclick="document.getElementById('hidblong').value=$(this).find('input').attr('id')">
                        <input type="text" class="BlongDepartment" id="blong1" readonly="readonly" style="text-align: center"
                            runat="server" />
                    </td>
                    <td onclick="document.getElementById('hidsaleman').value=$(this).find('input').attr('id')">
                        <input type="text" class="Salesman" id="saleman1" readonly="readonly" style="text-align: center"
                            runat="server" />
                    </td>
                    <td>
                        <input type="text" class="clsdigit" />
                    </td>
                    <td>
                        <input type="text" class="clsmoney" runat="server" />
                    </td>
                    <td>
                        <input type="text" />
                    </td>
                    <td align="center">
                        <div title='新增' class="imgadd">
                            &nbsp;</div>
                    </td>
                </tr>
            </table>
            <table id="totalnum" cellspacing="1" cellpadding="1" width="100%">
                <tr style="height: 25px">
                    <td style="color: Blue" class="style10">
                        合计:
                    </td>
                    <td style="width: 98px; text-align: right; color: blue; font-weight: bold;">
                        <span id="lblalldigit"></span>
                    </td>
                    <td style="width: 98px; text-align: right; color: blue; font-weight: bold;">
                        <span id="lblallmoney"></span>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
            <div>
                <table id="addfile">
                    <tr>
                        <td style="width: 80px; font-weight: bold" align="center">
                            附件上传:
                        </td>
                        <td>
                            <asp:FileUpload runat="server" ID="fpattachment" Width="273px" />
                        </td>
                        <td>
                            <img id="imgadd" alt="新增" src="../../../Images/public/fileadd.gif" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="width: 100%">
                    <tr>
                        <td class="fieldTitle">
                            审核流程：
                        </td>
                        <td colspan="5">
                            <asp:DropDownList ID="ddlrule" CssClass="clsdatalist" runat="server">
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
            </div>
        </div>
        <div id="showhdate" style="display: none;">
            <table>
                <tr>
                    <td>
                        发生时间:
                    </td>
                    <td>
                        <input type='text' id="ipthdate" />
                    </td>
                </tr>
            </table>
            <div style='text-align: right; padding-top: 5px;'>
                <span id='btnc' class='imgbtnstyle'>取消</span> <span id='btns' class='imgbtnstyle'>确定</span>
            </div>
        </div>
    </div>
    <input id="HidSalesman" type="hidden" runat="server" />
    <input id="HidTypeID" type="hidden" runat="server" />
    <input id="HidDepartmentID" type="hidden" runat="server" />
    <input id="HidItemID" type="hidden" runat="server" />
    <input id="hidjobflow" type="hidden" runat="server" />
    </form>
</body>
</html>
