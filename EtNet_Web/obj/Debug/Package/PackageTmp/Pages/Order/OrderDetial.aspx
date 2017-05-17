<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetial.aspx.cs" Inherits="EtNet_Web.Pages.Order.OrderDetial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单详细</title>
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 40px 10px 40px;
        }
        .clsdata
        {
            width: 100%;
            border: 1px solid #CDC9C9;
        }
        .clstxt
        {
            width: 200px;
            display: inline-block;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        #tablelink, #tablebank, #tableback, #tablerem
        {
            background-color: #E3E3E3;
            width: 100%;
            border: 0;
        }
        #tablelink tr td
        {
            text-align: center;
            background-color: #F0F8FF;
        }
        #tablebank tr td
        {
            text-align: center;
            background-color: #F0F8FF;
        }
        #tableback tr td
        {
            text-align: center;
            background-color: #F0F8FF;
        }
        #tablerem tr td
        {
            text-align: center;
            background-color: #F0F8FF;
        }
        .clsedit
        {
            text-align: center;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
        }
        .clstitleimg:hover
        {
            color: White;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
            margin-top: 5px;
        }
        .clsborder
        {
            border: 1px solid red !important;
        }
        .content
        {
            width: 100% padding: 5px;
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
            padding: 6px 6px 6px 16px;
            font-weight: bold;
            height: 20px;
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
            background-image: url('../../Images/public/list_tit.png');
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
        #iptcomment
        {
            border: 1px solid #C6E2FF;
            width: 400px;
            height: 60px;
            font-size: 13px;
            resize: none;
        }
        .clsborder
        {
            border: 1px solid red !important;
        }
    </style>
    <link href="../../Scripts/artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $("#auditpic div").each(function () {
                var vpath = $(this).css("background-image");
                if (vpath.lastIndexOf('.') != -1) {
                    var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                    $(this).css({ "background-image": str });
                }
            })

            //审核通过
            $("#ibtnPass").click(function () {
                //                if ($.trim($("#iptcomment").val()) == "") {
                //                    alert('请填写审批意见!');
                //                    return false;
                //                }
                if (confirm("确定审批通过!")) {
                    $("#iptcomment").val(encodeURIComponent($("#iptcomment").val()));
                }
                else {
                    return false;
                }
            })



            //审核拒绝
            $("#ibtnRefuse").click(function () {
                //                if ($.trim($("#iptcomment").val()) == "") {
                //                    alert('请填写审批意见!');
                //                    return false;
                //                }
                if (confirm("确定拒绝该申请!")) {
                    $("#iptcomment").val(encodeURIComponent($("#iptcomment").val()));
                    return true;
                }
                else {
                    return false;
                }
            })


            $(window).load(function () {

                if ($("#hidlist").val() == "-1") {
                    $("#start").addClass("clsborder");
                }
                else if ($("#hidlist").val() == "0") {
                    $("#end").addClass("clsborder");
                }
                else {
                    var str = $("#hidlist").val();
                    var list = null;
                    if (str.indexOf(',') != -1) {
                        list = str.split(',');
                    }
                    else {
                        list = [str];
                    }
                    for (var i = 0; i < list.length; i++) {
                        if ($(".cls" + $.trim(list[i])).length != 0) {
                            $(".cls" + $.trim(list[i])).addClass("clsborder");
                        }
                    }
                }
            })

        })

        //查看联系人(factid 单位id，linkid联系人id)
        function getLink(factid, linkid) {
            debugger;
            if (factid == "" && linkid == "")
            { }
            else
                art.artDialog.open('SearchLink.aspx?linkid=' + linkid + '&&payid=' + factid, { width: '620px' }).lock().title('查看联系人');
        }

        //查看营业部信息（linkid营业部id）
        function getdepart(linkid) {
            if (linkid == "")
            { }
            else
                art.artDialog.open('SearchDepart.aspx?departid=' + linkid, { width: '620px' }).lock().title('查看营业部');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">订单详细信息</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="../../Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <!--版本号:20130319-->
        <div class="content">
            <table class="dataBox lineTable">
                <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        订单类型
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblOrderType"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        订单序号
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblOrderCode"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        出团日期
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblOutDate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        订单类型
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblnature"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        团队总数
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        旅游线路
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblLine"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        线路描述
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" ID="lblLineremark"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        制单人员
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblMakeID"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        制单时间
                    </td>
                    <td style="width: 23%;">
                        <asp:Label runat="server" ID="lblMarkTime"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        操作人员
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblinputer"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        预计毛利
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblyjml"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        实际毛利
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblsjml"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        订单作废
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblIsCancel"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table class="clsdata" style="margin-top: 5px;">
            <tr>
                <td style="text-align: center; background: #F0F0F0;">
                    <span style="font-weight: bold; font-size: 14px;">收款单位信息</span>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="tablelink" runat="server" cellspacing="1" cellpadding="1">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td class="clstitleimg" style="width: 13%">
                                单位名称
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                业务员
                            </td>
                            <td class="clstitleimg" style="width: 12%">
                                营业部
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                联系人
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                成人数
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                儿童数
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                陪同
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                金额
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                收款状态
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                已收金额
                            </td>
                            <td class="clstitleimg" style="width: 7%">
                                剩余金额
                            </td>
                            <td class="clstitleimg" style="width: 12%">
                                备注
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="collecAmount" runat="server" cellspacing="1" cellpadding="1" width="100%"
                        border="0">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td style="width: 60%; color: Blue; text-align: left;">
                                合计：
                            </td>
                            <td style="width: 7%; text-align: center; color: blue; font-weight: bold;">
                                <span id="lblCollAmount" runat="server">0.00</span>
                            </td>
                            <td style="width: 7%">
                            </td>
                            <td style="width: 7%; text-align: center; color: Blue; font-weight: bold;">
                                <span id="lblColHasAmount" runat="server">0.00</span>
                            </td>
                            <td style="width: 19%">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="clsdata" style="margin-top: 5px;">
            <tr>
                <td style="text-align: center; background: #F0F0F0;">
                    <span style="font-weight: bold; font-size: 14px;">付款单位信息</span>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="tablebank" runat="server" cellspacing="1" cellpadding="1">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td class="clstitleimg" style="width: 15%;">
                                单位名称
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                付款类别
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                联系人
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                成人数
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                儿童数
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                金额
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                付款申请单
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                支付状态
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                已支付金额
                            </td>
                            <td class="clstitleimg" style="width: 8%;">
                                剩余金额
                            </td>
                            <td class="clstitleimg" style="width: 13%;">
                                备注
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="payAmount" runat="server" cellspacing="1" cellpadding="1" width="100%"
                        border="0">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td style="width: 47%; color: Blue; text-align: left;">
                                合计：
                            </td>
                            <td style="width: 8%; text-align: center; color: blue; font-weight: bold;">
                                <span id="lblPayAmount" runat="server">0.00</span>
                            </td>
                            <td style="width: 16%">
                            </td>
                            <td style="width: 8%; text-align: center; color: blue; font-weight: bold;">
                                <span id="lblPayHasAmount" runat="server">0.00</span>
                            </td>
                            <td style="width: 21%">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="clsdata" style="margin-top: 5px;">
            <tr>
                <td style="text-align: center; background: #F0F0F0;">
                    <span style="font-weight: bold; font-size: 14px;">退款信息</span>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="tableback" runat="server" cellspacing="1" cellpadding="1">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td class="clstitleimg" style="width: 20%;">
                                退款单位
                            </td>
                            <td class="clstitleimg" style="width: 20%;">
                                金额
                            </td>
                            <td class="clstitleimg" style="width: 20%;">
                                退款状态
                            </td>
                            <td class="clstitleimg" style="width: 20%;">
                                实际退款金额
                            </td>
                            <td class="clstitleimg" style="width: 20%;">
                                备注
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="backAmount" runat="server" cellspacing="1" cellpadding="1" width="100%"
                        border="0">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td style="width: 20%; color: Blue; text-align: left;">
                                合计：
                            </td>
                            <td style="width: 20%; text-align: center; color: blue; font-weight: bold;">
                                <span id="lblBackAmount" runat="server">0.00</span>
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 20%; text-align: center; color: blue; font-weight: bold;">
                                <span id="lblBackHasAmount" runat="server">0.00</span>
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="clsdata" style="margin-top: 5px;">
            <tr>
                <td style="text-align: center; background: #F0F0F0;">
                    <span style="font-weight: bold; font-size: 14px;">报销信息</span>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="tablerem" runat="server" cellspacing="1" cellpadding="1">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td class="clstitleimg" style="width: 20%;">
                                报销单号
                            </td>
                            <td class="clstitleimg" style="width: 20%;">
                                报销内容
                            </td>
                            <td class="clstitleimg" style="width: 20%;">
                                报销金额
                            </td>
                            <td class="clstitleimg" style="width: 20%;">
                                备注
                            </td>
                            <td class="clstitleimg" style="width: 10%;">
                                审批状态
                            </td>
                            <td class="clstitleimg" style="width: 10%;">
                                确认报销
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <table id="tableremview" runat="server" cellspacing="1" cellpadding="1" width="100%"
                        border="0">
                        <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                            <td style="width: 40%; color: Blue; text-align: left;">
                                合计：
                            </td>
                            <td style="width: 20%; text-align: center; color: blue; font-weight: bold;">
                                <span id="lblReimAmount" runat="server">0.00</span>
                            </td>
                            <td style="width: 40%">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    <div class="clsauditxt">
                        审批流程图:</div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="auditpic" class="clsauditpic" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    <div class="clsauditxt">
                        审批意见:</div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="optiniontxt" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="hidlist" runat="server" />
    </form>
</body>
</html>
