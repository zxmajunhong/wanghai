<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPolicy.aspx.cs" Inherits="EtNet_Web.Pages.Policy.AddPolicy" %>

<%@ Register Src="../Finance/UCBudgetEdit.ascx" TagName="UCBudgetEdit" TagPrefix="uc1" %>
<%@ Register Src="UCTarget.ascx" TagName="UCTarget" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Product/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <link href="../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="common.css" rel="stylesheet" type="text/css" />
    <script src="../Product/iframeTools.js" type="text/javascript"></script>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="z.js" type="text/javascript" charset="gb2312"></script>
    <script src="query.js" type="text/javascript"></script>
    <link href="tab.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        bordy
        {
            background-image: none;
            background-color: #FFFFFF;
            font-size: 12px;
        }
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 30px 0px;
            overflow: auto;
            min-width: 880px;
            width: expression_r(document.body.clientWidth > 880? "880px": "auto" );
        }
        .border, #contable, #contable #table
        {
            width: 100%;
        }
        .imgadd
        {
            background-image: url('../../Images/public/iconadd.png');
            width: 16px;
            height: 16px;
            cursor: pointer;
        }
        .imgdel
        {
            background-image: url('../../Images/public/icondelete.png');
            width: 16px;
            height: 16px;
            cursor: pointer;
        }
        .clsrate, .clsjjf, .clstiefei
        {
            text-align: right;
            font-size: 11px;
        }
        .sortable th
        {
            height: 24px;
            text-align: center;
        }
        #table
        {
            width: 100%;
            background-color: #E3E3E3;
        }
        #table tr td
        {
            background-color: #F0F8FF;
        }
        #table tr td input
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
        .titlebtncls
        {
            position: absolute;
            right: 13px;
        }
        .num
        {
            text-align: right;
        }
        #contable select
        {
            width: 153px;
        }
        .input-line
        {
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
            width: 200px;
        }
        .a, .b, .mark
        {
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
            width: 80%;
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
        #sum-box
        {
            font-weight: bold;
            color: Blue;
        }
        #sum-box td#sum-title
        {
            text-align: right;
        }
        #table #totalCoverage, #table #totalPremium
        {
            text-align: right;
            font-size: 14px;
            font-family: 宋体;
        }
        .Wdate
        {
            cursor: pointer;
        }
        .tabeltd
        {
            width: 90px;
            text-align: right;
        }
        .style1
        {
            width: 855px;
        }
        .style2
        {
            width: 468px;
        }
    </style>
    <script type="text/javascript">
        function GetItem(id) {
            $.ajax({
                type: "get",
                url: "GetProduct.aspx",
                dataType: "html",
                data: { 'id': id },
                success: function (data) {
                    $('#tagContent0 .sortable tbody').html(data);
                    $(".num").each(function () {
                        $(this).focus(function () {
                            $(this).css('text-align', 'left');
                        });
                        $(this).blur(function () {
                            $(this).css('text-align', 'right');
                        });
                    });
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
            getTarget();
        }

        $(document).ready(function () {
            var num = 1;
            //图片设置手的样式
            $("img").css({ cursor: "pointer" });
            $("img:[alt='删除附件'],img:[alt='新增附件'],img:[alt='删除原有附件']").live("mouseenter", function () {
                $(this).css({ cursor: "pointer" });
            })


            //动态新增文件上传控件

            $("#imgadd").click(function () {
                var str = '<tr><td><input type="file" name="addfile" /></td>'
                str += '<td><img class="imgaddfile" alt="删除附件" src="../../Images/public/delete.gif" /></td></tr>'
                if ($("#addfile tr").length >= 5) {
                    alert('最多上传五个文件');
                }
                else {
                    $("#addfile").append(str);
                }
            })



            //删除新增的上传控件
            $(".imgaddfile").live("click", function () {
                $(this).parent().parent().remove();
            });

            $(".delFile").click(function () {
                var value = $("#HidFiles").val();
                value += $(this).parent().find(".oldFile").val() + ",";
                $("#HidFiles").val(value);
                $(this).parent().parent().remove();
            });

            //隔行显示不同的背景色
            function showline() {
                $("#table tr:odd td").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的行
                $("#table tr:even td").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的行
                $("#table tr:odd td input:text").css({ "backgroundColor": "#F7F7F7" }) //指定需要改变颜色的文本框
                $("#table tr:even td input:text").css({ "backgroundColor": "#F0F8FF" }) //指定需要改变颜色的文本框
            }
            showline();

            //加一行
            $(".imgadd").click(function () {
                debugger;
                var salemanid = new Number(document.getElementById("hidsalemanrows").value);
                var departid = new Number(document.getElementById("hiddepartrows").value);
                var jjfid = new Number(document.getElementById("hidjjfrows").value);

                var saleman = "saleman" + salemanid;
                var depart = "depart" + departid;
                var jjf = "jjf" + jjfid;

                var str = '<tr><td onclick=' + "document.getElementById('hidsaleman').value" + "=" + "$(this).find('input').attr('id')," + "artDialog.open('SelectSalesman.aspx?depart=" + depart + "')" + '><input type="text" id=' + saleman + ' class="Salesman" style="text-align: center" /></td>';
                str += '<td><input type="text" id=' + depart + ' class="depart" style="text-align: center" /></td>';
                str += '<td><input type="text" class="clsrate" style="width: 95%;" onblur="SetRate(this);GetNumjjf(this,' + jjf + ')"/>%</td>';
                str += '<td><input type="text" id=' + jjf + ' class="clsjjf" readonly="readonly" /></td>';
                str += '<td><input type="text" class="clstiefei" /></td>';
                str += '<td><input type="text"/></td>';
                str += '<td align="center">';
                str += '<div class="imgdel">&nbsp;</div></td></tr>';

                $("#table").append(str);

                showline();
                document.getElementById("hidsalemanrows").value = salemanid + 1;
                document.getElementById("hiddepartrows").value = departid + 1;
                document.getElementById("hidjjfrows").value = jjfid + 1;
            });

            $(".clsjjf").live("blur", function () {
                SetNum(this);
            });

            //得到贴费和
            $(".clstiefei").live("blur", function () {
                SetNum(this);
                var total = 0;
                $('.clstiefei').each(function () {
                    if ($(this).val() != "") {
                        total += parseFloat($(this).val());
                    }
                })

                if (total != 0) {
                    $("#lblallmoney").text(total.toFixed(2));
                }
                else {
                    $("#lblallmoney").text("");
                }
            });

            //判断比率不会超过100
            $(".clsrate").live("keyup", function () {
                debugger;
                var total = 0;
                var rg = /^(100|[0-9][0-9]?)(\.\d{0,2})?$/;
                var value = $(this).val();
                if (isNaN(value) || !rg.test(value)) {
                    alert('输入格式有误');
                    $(this).val("");
                }
                else {
                    $('.clsrate').each(function () {
                        if ($(this).val() != "") {
                            total += parseFloat($(this).val());
                        }
                    })
                    if (total > 100) {
                        alert('所输入的比率和超过100%，请从新输入');
                        $(this).val("");
                    }
                }
            });

            //减一行
            $(".imgdel").live("click", function () {
                $(this).parent("td").parent("tr").remove();
                showline();
            });

            //保存
            $("#save").click(function () {
                if (ReadySubmit()) {

                    var id = getParamValue('id');
                    var snum = $("#TxtSerialNum").val();
                    var pnum = $("#TxtPolicyNum").val();

                    var params = null;
                    if (id == null) {
                        params = { s: snum, p: pnum };
                    }
                    else {
                        params = { s: snum, p: pnum, id: id };
                    }

                    $.get("ExitsRecord.ashx", params, function (data, textStatus) {
                        if ($.trim(data) != "ok") {
                            alert(data);
                            return;
                        }
                        else {
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
                                        $("#BtnSave").click();
                                    }
                                },
                                {
                                    name: '直接送审', callback: function () {
                                        $("#submit").click();
                                    }
                                }
                            ]
                            });
                        }
                    })
                }
            });

            //送审
            $("#ss").click(function () {
                if (ReadySubmit()) {

                    var id = getParamValue('id');
                    var snum = $("#TxtSerialNum").val();
                    var pnum = $("#TxtPolicyNum").val();

                    var params = null;
                    if (id == null) {
                        params = { s: snum, p: pnum };
                    }
                    else {
                        params = { s: snum, p: pnum, id: id };
                    }

                    $.get("ExitsRecord.ashx", params, function (data, textStatus) {
                        if ($.trim(data) != "ok") {
                            alert(data);
                            return;
                        }
                        else {
                            $("#submit").click();
                        }
                    })
                }
            });

            $('.ComAndPro').each(function () {
                $(this).click(function () {
                    art.artDialog.open('ComAndPro.aspx', { width: '650px', height: '477px' }).lock().title('选择保险公司和险种');
                });
            });
            $('#SelectCustomer').click(function () {
                art.artDialog.open('SelectCustomer.aspx', { width: '650px', height: '430px' }).lock().title('选择投保客户');
            });
            $('.Salesman').click(function () {
                art.artDialog.open('SelectSalesman.aspx?depart=depart1', { width: '310px' }).lock().title('选择所属业务员');
            });
            CalcTotal();

            $(window).load(function () {
                $("#auditpic div").each(function () {
                    var vpath = $(this).css("background-image");
                    if (vpath.lastIndexOf('.') != -1) {
                        var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                        $(this).css({ "background-image": str });
                    }
                })
            })


            $.get("../Job/JobFlowHandler.ashx", { sort: 1, flag: $("#DdlIsVirify").val() }, function (data) {
                $("#auditpic").html(data);
                $("#auditpic div").each(function () {
                    var vpath = $(this).css("background-image");
                    if (vpath.lastIndexOf('.') != -1) {
                        var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                        $(this).css({ "background-image": str });
                    }
                })

            });
            //显示审核规则
            $("#DdlIsVirify").change(function () {
                $.get("../Job/JobFlowHandler.ashx", { sort: 1, flag: $("#DdlIsVirify").val() }, function (data) {
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


            $("#TxtYears").blur(function () {
                $("#txtEndTime").val(getEndTime());
            });

        });


        function delRow(e) {
            if ($("#table tr").length <= 3) {
                alert("至少保留一条数据");
            }
            else {
                $(e).parent("td").parent("tr").remove();
            }
        }


        function SetRate(e) {
            var value = $(e).val();
            if (value == null || value == '') {
                return false;
            }
            if (!isNaN(value)) {
                var userreg = /^(100|[0-9][0-9]?)(\.\d{0,2})?$/;
                if (userreg.test(value)) {
                    var numindex = parseInt(value.indexOf("."), 10);
                    if (numindex <= 0) {
                        $(e).val(value + ".00");
                    } else if (value.length - numindex == 2) {
                        $(e).val(value + "0");
                    }
                    else if (value.length - numindex == 1) {
                        $(e).val(value + "00");
                    }
                }
                else {
                    $(e).val("");
                }
                //                else {
                //                    var numindex = parseInt(value.indexOf("."), 10);
                //                    if (value.length - numindex == 1) {
                //                        $(e).val(value + "00");
                //                    } else {
                //                        var numindex = parseInt(value.indexOf("."), 10);
                //                        if (numindex == 0) {
                //                            $(e).val("");
                //                        }
                //                        var head = value.substring(0, numindex);
                //                        var bottom = value.substring(numindex, numindex + 3);
                //                        var fianlNum = head + bottom;
                //                        $(e).val(fianlNum);
                //                    }
                //                }
            } else {
                $(e).val("");
            }
        }


        function SetNum(e) {
            var value = $(e).val();
            if (value == null || value == '') {
                //                CalcTotal();
                return false;
            }
            if (!isNaN(value)) {
                var userreg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                if (userreg.test(value)) {
                    var numindex = parseInt(value.indexOf("."), 10);
                    if (numindex <= 0) {
                        $(e).val(value + ".00");
                    } else if (value.length - numindex == 2) {
                        $(e).val(value + "0");
                    }
                } else {
                    var numindex = parseInt(value.indexOf("."), 10);
                    if (value.length - numindex == 1) {
                        $(e).val(value + "00");
                    } else {
                        var numindex = parseInt(value.indexOf("."), 10);
                        if (numindex == 0) {
                            $(e).val("");
                        }
                        var head = value.substring(0, numindex);
                        var bottom = value.substring(numindex, numindex + 3);
                        var fianlNum = head + bottom;
                        $(e).val(fianlNum);
                    }
                }
            } else {
                $(e).val("");
            }
            //            CalcTotal();
        }

        //得到经济费
        function Getjjf() {
            var sumValue;
            a = document.getElementById("zjjfrate").value;
            b = document.getElementById("zbf").value;
            if (isNaN(a))
            { a = 0 }
            if (isNaN(b))
            { b = 0 }
            sumValue = parseFloat(a) / 100 * parseFloat(b);
            if ($('#zjjfrate').val() == "" || $('#zbf').val() == "")
            { }
            else {
                //输出保留四舍五入保留两位小数
                sumValue = Math.round(sumValue * 100) / 100;
                //                document.getElementById("zjjf").value = sumValue;
                $('#zjjf').val(sumValue);
            }
        }

        //得到明细中的经济费（参数e表示所点击的那一个的比率。o表示要输出到的单元格对象）
        function GetNumjjf(e, o) {
            debugger;
            var sumValue;
            var rate = $(e).val();
            var fmone = $('#zjjf').val();
            if (isNaN(rate))
            { rate = 0 }
            if (isNaN(fmone))
            { fmone = 0 }
            sumValue = parseFloat(rate) / 100 * parseFloat(fmone);
            if (rate == "" || fmone == "")
            { }
            else {
                sumValue = Math.round(sumValue * 100) / 100;
                $(o).val(sumValue);
            }

            //得到经济费和
            var total = 0;
            $(".clsjjf").each(function () {
                if ($(this).val() != "") {
                    total += parseFloat($(this).val());
                }
            })

            if (total != 0) {
                $("#lblalldigit").text(total.toFixed(2));
            }
            else {
                $("#lblalldigit").text("");
            }
        }

        function CalcTotal() {
            var totalCoverage = 0.00;
            var totalPremium = 0.00;
            $('.a').each(function () {
                if (!isNaN(parseFloat($(this).val()))) {
                    totalCoverage += parseFloat($(this).val());
                }
            });
            $('.b').each(function () {
                if (!isNaN(parseFloat($(this).val()))) {
                    totalPremium += parseFloat($(this).val());
                }
            });
            if (isNaN(totalCoverage)) {
                $('#totalCoverage').html("0.00");
            } else {
                $('#totalCoverage').html(totalCoverage.toFixed(2));
            }
            if (isNaN(totalPremium)) {
                $('#totalPremium').html("0.00");
            } else {
                $('#totalPremium').html(totalPremium.toFixed(2));
            }
        }

        //读取明细和标的信息
        function ReadySubmit() {
            var pros = "";
            var targets = "";
            if (Validator.Validate(document.getElementById('form1'), 1)) {
                if ($("#DdlIsVirify option[value=-1]").attr("selected")) {
                    alert("请选择审核流程");
                    return false;
                }
                //验证明细中比率是否输入了100，贴费输入的和是否等于总表中的贴费数据
                if (!checkdetial()) {
                    return false;
                }
                //                $('.idcol').each(function () {
                //                    pros += $(this).html();
                //                    pros += "$";
                //                    pros += $(this).siblings().find('.a').val();
                //                    pros += "$";
                //                    pros += $(this).siblings().find('.b').val();
                //                    pros += "$";
                //                    pros += $(this).siblings().find('.mark').val();
                //                    pros += "|";
                //                });
                $("#table tr:gt(0)").each(function () {
                    var txt = "";
                    txt = $.trim($(this).find("input:text:eq(0)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(1)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(2)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(3)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(4)").val());
                    txt += "|" + $.trim($(this).find("input:text:eq(5)").val());
                    if (txt.length != 5) {
                        if (pros == "") {
                            pros = txt;
                        }
                        else {
                            pros += "," + txt;
                        }
                    }
                })
                $('#HidPros').val(pros);

                $("tr.item").each(function () {
                    targets += $(this).find("td.pname").html() + "$";

                    if ($.trim($(this).find("td.pdatatype").html()) == "9" || $.trim($(this).find("td.pdatatype").html()) == "3") {
                        targets += $(this).find("select").find("option:selected").text() + "$";
                    } else {
                        targets += $(this).find("td.pvalue").find("input").val() + "$";
                    }

                    targets += $(this).find("td.ptypeID").html() + "$";
                    targets += $(this).find("td.pid").html() + "$";
                    targets += $(this).find("td.pdatatype").html() + "@";
                });
                $("#HidTarget").val(targets);
                return true;
            } else {
                return false;
            }
        }

        function checkdetial() {
            var totalrate = 0;
            var totaltiefei = 0;
            var tiefei = $("#ztf").val();
            var result = true;
            $('.Salesman').each(function () {
                if ($(this).val() == "") {
                    alert('请确认业务员都已经选择');
                    result = false;
                }
            });
            $('.clsrate').each(function () {
                if ($(this).val() != "") {
                    totalrate += parseFloat($(this).val());
                }
            });
            $('.clstiefei').each(function () {
                if ($(this).val() != "") {
                    totaltiefei += parseFloat($(this).val());
                }
            });

            if (totalrate != 100) {
                alert('业务员占比不等于100%，不能保存');
                result = false;
            }
            if (totaltiefei != tiefei) {
                alert('业务员贴费金额不等于'+ tiefei + ',不能保存');
                result = false;
            }
            return result;
        }

        //加载标的信息页面
        function getTarget() {
            $.ajax({
                type: "get",
                url: "LoadTargetHandler.aspx",
                dataType: "html",
                data: { 'type': $("#HidTypeId").val() },
                success: function (data) {
                    $("#tagContent1").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }

        function getEndTime(dp) {
            var count = $("#TxtYears").val();
            var endDate = "";
            if ($.trim(count) == "" || isNaN(count)) {
                //endDate = "";
                $("#TxtYears").val("");
                return $("#txtEndTime").val();
            }
            else if ($.trim($("#TxtTimeStart").val()) == "") {
                endDate = "";
            }
            else {
                endDate += (parseInt($dp.cal.getP('y', 'yyyy')) + parseInt(count)).toString();
                endDate += "-";
                endDate += $dp.cal.getP('M', 'MM');
                endDate += "-";
                endDate += $dp.cal.getP('d', 'dd');
            }
            return endDate;
        }
    </script>
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
</head>
<body>
    <input type="hidden" runat="server" id="hidsalemanrows" value="2" />
    <input type="hidden" runat="server" id="hidsaleman" value="saleman1" />
    <input type="hidden" runat="server" id="hiddepartrows" value="2" />
    <input type="hidden" runat="server" id="hiddepart" value="depart1" />
    <input type="hidden" runat="server" id="hidjjfrows" value="2" />
    <input type="hidden" runat="server" id="hidjjf" value="jjf1" />
    <form id="form1" runat="server" onkeypress="if(event.keyCode==13||event.which==13){return false;}">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">
            <asp:Label ID="LblTitle" runat="server" Text="保单新增"></asp:Label></span> <span class="titlebtncls">
                <a href="javascript:void(0);" id="save" title="保存" style="padding-right: 7px">
                    <img alt="保存" src="../../images/button/btn_save.jpg" /></a><a href="javascript:void(0);"
                        id="ss" title="送审" style="padding-right: -6px"><img alt="送审" src="../../Images/Button/btn_audisend.jpg" /></a><asp:ImageButton
                            ID="BtnSave" Style="display: none;" runat="server" OnClick="BtnSave_Click" ImageUrl="../../images/button/btn_save.jpg" />
                <%--<asp:ImageButton ID="itbnSubmit" OnClientClick="return ReadySubmit();" runat="server"
                    ImageUrl="~/Images/Button/btn_audisend.jpg" OnClick="itbnSubmit_Click" />--%>
                <asp:ImageButton ID="submit" runat="server" Style="display: none;" ImageUrl="~/Images/Button/btn_audisend.jpg"
                    OnClick="itbnSubmit_Click" />
                <a href="PolicyList.aspx" title="返回列表">
                    <img alt="返回" src="../../Images/button/btn_back.jpg" /></a> </span>
    </div>
    <div style="background: #4CB0D5; height: 5px; width: 100.2%">
    </div>
    <div class="border" id="slider">
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
                    <table id="contable" cellspacing="10" width="100%">
                        <tr>
                            <td class="tabeltd">
                                业务编号：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ReadOnly="true" ID="TxtSerialNum" runat="server">
                                </asp:TextBox>
                                <span style="color: Red;" id="txtshow" runat="server"></span>
                            </td>
                            <td class="tabeltd">
                                保单日期：
                            </td>
                            <td>
                                <asp:TextBox dataType="Require" msg="保单日期不能为空" CssClass="Wdate input-line" onFocus="WdatePicker({isShowClear:false,readOnly:true})"
                                    ID="TxtPolicyDate" runat="server">
                                </asp:TextBox>
                            </td>
                            <td class="tabeltd">
                                制单员：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="TxtPolicyMaker" Enabled="false" dataType="Require"
                                    msg="制单人不能为空" runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tabeltd">
                                保单编号：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="TxtPolicyNum" runat="server">
                                </asp:TextBox>
                            </td>
                            <td class="tabeltd">
                                保单状态：
                            </td>
                            <td>
                                <asp:DropDownList CssClass="input-line" ID="DdlPolicyState" dataType="Require" msg=""
                                    runat="server" Width="200px">
                                    <asp:ListItem Selected="True" Value="1">有效</asp:ListItem>
                                    <asp:ListItem Value="0">无效</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="tabeltd">
                                制单部门：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="txtMarkerDepart" Enabled="false" runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tabeltd">
                                保险期限：
                            </td>
                            <td colspan="3">
                                <%--<asp:TextBox CssClass="input-line" ID="TxtYears" runat="server">
                                </asp:TextBox>
                                年--%><%--,onpicked:function(dp) {$dp.$('txtEndTime').value=getEndTime(dp);}--%>
                                <asp:TextBox ID="TxtTimeStart" dataType="Require" msg="保险期限起始日期不能为空" CssClass="Wdate input-line"
                                    onFocus="WdatePicker({isShowClear:false,readOnly:true,maxDate:'#F{$dp.$D(\'txtEndTime\')}'})"
                                    runat="server">
                                </asp:TextBox>
                                到
                                <asp:TextBox CssClass="input-line Wdate" onClick="WdatePicker({minDate:'#F{$dp.$D(\'TxtTimeStart\')}'})"
                                    ID="txtEndTime" runat="server">
                                </asp:TextBox>
                                <%--到
                    <asp:TextBox ID="TxtTimeEnd" dataType="Require" msg="保险期限终止日期不能为空" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'TxtTimeStart\')}'})"
                        runat="server"></asp:TextBox>--%>
                            </td>
                            <td class="tabeltd" style="display: none">
                                业务员：
                            </td>
                            <td style="display: none">
                                <asp:TextBox CssClass="input-line" ID="TxtSalesman" runat="server">
                                </asp:TextBox>
                                <a href="javascript:void(0);" id="Salesman">
                                    <img alt="选择" src="../../Images/public/folder_user.gif" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td class="tabeltd">
                                投保客户：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="TxtCustomer" dataType="Require" msg="投保客户不能为空"
                                    runat="server">
                                </asp:TextBox>
                                <a href="javascript:void(0);" id="SelectCustomer">
                                    <img alt="选择" src="../../Images/public/folder_user.gif" /></a>
                            </td>
                            <td class="tabeltd">
                                是否续保：
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlIsRenewal" dataType="Require" msg="" runat="server" Width="200px">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="tabeltd">
                                被保险人：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="TxtAssured" dataType="Require" msg="被保险人不能为空"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tabeltd">
                                保险公司：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="TxtCompany" dataType="Require" msg="保险公司不能为空"
                                    runat="server">
                                </asp:TextBox>
                                <a href="javascript:void(0);" class="ComAndPro">
                                    <img alt="选择" src="../../Images/public/expand.gif" /></a>
                            </td>
                            <td class="tabeltd">
                                保险险种：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="TxtType" dataType="Require" msg="保险险种不能为空"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                            <td class="tabeltd">
                                经营单位：
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tabeltd">
                                总保额：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="zbe" dataType="Require" msg="总保额不能为空" runat="server"
                                    onblur="SetNum(this)"></asp:TextBox>
                            </td>
                            <td class="tabeltd">
                                总保费：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="zbf" dataType="Require" msg="总保费不能为空" runat="server"
                                    onblur="SetNum(this);Getjjf()"></asp:TextBox>
                            </td>
                            <td class="tabeltd">
                                船名：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="cm" dataType="Require" msg="船名不能为空" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tabeltd">
                                总经纪费比率：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="zjjfrate" dataType="Require" msg="总经纪费比率不能为空"
                                    runat="server" onblur="SetRate(this);Getjjf()">
                                </asp:TextBox>%
                            </td>
                            <td class="tabeltd">
                                总经纪费：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="zjjf" dataType="Require" msg="总经纪费不能为空" runat="server"
                                    TabIndex="1"></asp:TextBox>
                            </td>
                            <td class="tabeltd">
                                总贴费：
                            </td>
                            <td>
                                <asp:TextBox CssClass="input-line" ID="ztf" dataType="Require" msg="总保费不能为空" runat="server"
                                    onblur="SetNum(this)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <table id="tabledata" style="width: 100%;">
                                    <tr>
                                        <td colspan="8" style="background-image: url('../../Images/public/win_top.png');
                                            background-repeat: repeat-x; height: 31px" class="style1">
                                            <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                                                具体保险项目</span> <span style="float: right; margin-right: 20px"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <table cellpadding="0" cellspacing="0" border="0" id="table" class="sortable" runat="server">
                                                <tr>
                                                    <th width="12%">
                                                        业务员
                                                    </th>
                                                    <th width="12%">
                                                        部门
                                                    </th>
                                                    <th width="12%">
                                                        业务员占比
                                                    </th>
                                                    <th width="12%">
                                                        经纪费
                                                    </th>
                                                    <th width="12%">
                                                        贴费
                                                    </th>
                                                    <th width="35%">
                                                        备注
                                                    </th>
                                                    <th width="40px" align="center">
                                                        操作
                                                    </th>
                                                </tr>
                                                <tr style="height: 30px">
                                                    <td onclick="document.getElementById('hidsaleman').value=$(this).find('input').attr('id')">
                                                        <input type="text" class="Salesman" id="saleman1" readonly="readonly" style="text-align: center"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <input type="text" class="depart" id="depart1" readonly="readonly" style="text-align: center"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <input type="text" class="clsrate" style="width: 90%;" onblur="SetRate(this);GetNumjjf(this,jjf1)" />%
                                                    </td>
                                                    <td>
                                                        <input type="text" id="jjf1" class="clsjjf" readonly="readonly" />
                                                    </td>
                                                    <td>
                                                        <input type="text" class="clstiefei" />
                                                    </td>
                                                    <td>
                                                        <input type="text" />
                                                    </td>
                                                    <td align="center">
                                                        <div title='新增' class="imgadd">
                                                            &nbsp;</div>
                                                    </td>
                                                </tr>
                                                <%--<thead>
                                                    <tr>
                                                        <th width="40px">
                                                            删除
                                                        </th>
                                                        <th width="10%">
                                                            险种编号
                                                        </th>
                                                        <th width="30%">
                                                            险种名称
                                                        </th>
                                                        <th width="10%">
                                                            保额
                                                        </th>
                                                        <th width="10%">
                                                            保费
                                                        </th>
                                                        <th width="30%">
                                                            备注
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="container">
                                                    <asp:Repeater ID="RpProType" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <a onclick="delRow(this);" title="移除行" href="javascript:void(0);">
                                                                        <img src="../../Images/public/filedelete.gif" alt="移除行" />
                                                                    </a>
                                                                </td>
                                                                <td class="idcol" style="display: none">
                                                                    <%# Eval("ProdID") %>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("ProdNo")%>
                                                                </td>
                                                                <td>
                                                                    <%# Eval("ProdName")%>
                                                                </td>
                                                                <td>
                                                                    ￥<input onblur="SetNum(this)" id="Text1" class="a num" value='<%# Eval("coverage","{0:f2}") %>'
                                                                        datatype="Custom" regexp="^[0-9]+(.[0-9]{1,2})?$" msg="保额不能为空且必须是数字" type="text" />
                                                                </td>
                                                                <td>
                                                                    ￥<input id="Text2" onblur="SetNum(this)" class="b num" value='<%# Eval("premium","{0:f2}") %>'
                                                                        datatype="Custom" regexp="^[0-9]+(.[0-9]{1,2})?$" msg="保费不能为空且必须是数字" type="text" />
                                                                </td>
                                                                <td>
                                                                    <input type="text" class="mark" value='<%# Eval("mark") %>' />
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <tr id="sum-box">
                                                        <td id="sum-title" align="right" colspan="3">
                                                            合计:
                                                        </td>
                                                        <td id="totalCoverage">
                                                            0.00
                                                        </td>
                                                        <td id="totalPremium">
                                                            0.00
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </tbody>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table id="totalnum" cellspacing="1" cellpadding="1" width="100%">
                                                <tr style="height: 25px">
                                                    <td style="color: Blue; width: 36%" colspan="3">
                                                        合计:
                                                    </td>
                                                    <td style="width: 12%; text-align: right; color: blue; font-weight: bold;">
                                                        <span id="lblalldigit"></span>
                                                    </td>
                                                    <td style="width: 12%; text-align: right; color: blue; font-weight: bold;">
                                                        <span id="lblallmoney"></span>
                                                    </td>
                                                    <td style="width: 40%">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                附件上传：
                            </td>
                            <td colspan="6">
                                <div>
                                    <table id="addfile">
                                        <asp:Repeater ID="RpFileList" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# Eval("filename") %>(<%# ChangeSize(Convert.ToInt32(Eval("filesize")))%>) <a href='<%# "PolicyFiles.aspx?id="+Eval("id") %>'>
                                                            <img alt="下载" src="../../Images/Public/download.png" /></a>
                                                    </td>
                                                    <td>
                                                        <input class="oldFile" value='<%# Eval("id") %>' type="hidden" /><img class="delFile"
                                                            alt="删除原有附件" src="../../Images/public/delete.gif" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td>
                                                <asp:FileUpload runat="server" ID="fpattachment" />
                                            </td>
                                            <td>
                                                <img id="imgadd" alt="新增附件" src="../../Images/public/fileadd.gif" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                审核流程：
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlIsVirify" dataType="Require" msg="" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                是否代垫：
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="DdlIsDaidian" dataType="Require" msg="" runat="server">
                                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <div id="auditpic" class="clsauditpic" runat="server">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tagContent" id="tagContent1">
                    <uc1:UCTarget ID="UCTarget1" runat="server" />
                </div>
                <div id="tagContent2" class="tagContent" runat="server">
                    <uc1:UCBudgetEdit ID="UCBudgetEdit1" runat="server" />
                </div>
                <div style="clear: both">
                </div>
            </div>
        </div>
    </div>
    <input id="HidTypeId" type="hidden" runat="server" />
    <input id="HidComId" type="hidden" runat="server" />
    <input id="HidCusId" type="hidden" runat="server" />
    <input id="HidPros" type="hidden" runat="server" />
    <input id="HidSalesman" type="hidden" runat="server" />
    <input id="HidTarget" type="hidden" runat="server" />
    <input id="HidFiles" type="hidden" runat="server" />
    </form>
</body>
</html>
