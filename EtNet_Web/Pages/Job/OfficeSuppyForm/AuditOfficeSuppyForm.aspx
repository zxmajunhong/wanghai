<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditOfficeSuppyForm.aspx.cs"
    Inherits="PJOAUI.View.Job.OfficeSuppyForm.AuditOfficeSuppyForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审核办公用品申请单</title>
    <link href="../../../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/Jquery/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/Jquery/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            //审核通过
            $("#ibtnPass").click(function () {
                if (confirm("确定审核通过！")) {
                    if ($("#treacomment").val() == "") {
                        if (confirm('审批意见未填!如不需要填写点击"确定"')) {
                            $("#treacomment").val(encodeURIComponent($("#treacomment").val()));
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        $("#treacomment").val(encodeURIComponent($("#treacomment").val()));
                    }
                }
                else {
                    return false;
                }

            })





            //审核拒绝
            $("#ibtnRefuse").click(function () {
                if (confirm("确定拒绝该申请！")) {
                    $("#treacomment").val(encodeURIComponent($("#treacomment").val()));
                    return true;
                }
                else {
                    return false;
                }
            })



            //加载已有的办公用品的明细的数据
            $(window).load(function () {
                if ($("#iptdetial").val()) {
                    var list = $("#iptdetial").val().split(',');
                    var str = "";
                    for (var i = 0; i < list.length; i++) {
                        str += "<tr><td>" + list[i].split('_')[2] + "</td><td>" + list[i].split('_')[0] + " </td></tr>";

                    }

                    $("#supplydetail").append(str);
                }

            })


        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="iptdetial" />
    <div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <th colspan="8" align="center">
                    <h3>
                        办公用品申请单审核</h3>
                </th>
            </tr>
            <tr>
                <td colspan="8" style="background-image: url('../../../Images/Job/win_top.png');
                    height: 10px; background-repeat: repeat-x;">
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    办公用品申请单号
                </td>
                <td style="width: 15%">
                    <asp:Label ID="lblnumbers" runat="server"></asp:Label>
                </td>
                <td style="width: 10%">
                    部门
                </td>
                <td style="width: 10%">
                    <asp:Label ID="lbldepart" runat="server"></asp:Label>
                </td>
                <td style="width: 10%">
                    申请人
                </td>
                <td style="width: 15%">
                    <asp:Label ID="lblname" runat="server"></asp:Label>
                </td>
                <td style="width: 10%">
                    申请日期
                </td>
                <td style="width: 15%">
                    <asp:Label ID="lblapplydate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <table id="supplydetail" style="width: 40%;">
                        <tr>
                            <td colspan="2" style="font-weight: bold;">
                                办公用品申请明细
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70%;">
                                名称
                            </td>
                            <td style="width: 30%;">
                                数量
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    办公用品申请原因及用途说明
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Label runat="server" ID="lblremark" Width="100%" Height="100px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    附件情况
                </td>
                <td colspan="7">
                    <table runat="server" id="originalfile">
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    审核批示
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Label ID="lblcomment" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8" class="style1">
                    <textarea id="treacomment" runat="server" style="height: 100px; width: 100%"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="8" align="right">
                    <asp:ImageButton ID="ibtnPass" runat="server" ImageUrl="~/Images/home/btn_pass.jpg"
                        OnClick="ibtnPass_Click" />
                    &nbsp;
                    <asp:ImageButton ID="ibtnRefuse" runat="server" ImageUrl="~/Images/home/btn_refuse.jpg"
                        OnClick="ibtnRefuse_Click" />
                    &nbsp;
                    <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/Images/home/btn_back.jpg"
                        OnClick="ibtnBack_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
