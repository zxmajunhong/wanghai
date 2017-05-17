<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProdRate.aspx.cs" Inherits="EtNet_Web.Pages.ProductRate.UpdateProdRate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改综合比率</title>
    <link href="../../artDialog4.1.6/skins/default.css" rel="Stylesheet" type="text/css" />
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
            border: 1px solid #CDC9C9;
        }
        .clsunderline
        {
            width: 300px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        
        .style1
        {
            width: 600px;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#ibtnAdd").click(function () {
                var str = "";
                var strtxt = $("#txtrate").val();
                var struser = $("#txtuser").val();
                var strprod = $("#txtprod").val();
                if ($.trim(strtxt) == "") {
                    str += " 比率不能为空";
                }
                if ($.trim(struser) == "") {
                    str += " 人员不能为空";
                }
                if ($.trim(strprod) == "") {
                    str += " 险种不能为空";
                }
                if (str) {
                    alert(str);
                    return false;
                }
            })

            //验证输入的格式
            $("#txtrate").live("keyup", function () {
                debugger
                //                var rg = /^(0[0-9].*)|(.*\.\d{3,})$/
                var rg = /^(100|[1-9][0-9]?)(\.\d{0,2})?$/;
                var strtxt = $("#txtrate").val();
                if (isNaN(strtxt) || !rg.test(strtxt)) {
                    alert('输入格式有误')
                    $("#txtrate").val("");
                }
            })

            //比率格式补全
            $("#txtrate").live("blur", function () {
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


            //返回时清空数据
            $("#ibtnback").click(function () {
                $("#txtmoney").val("");

            })

            //选择人员
            $('#txtuser').click(function () {
                artDialog.open('SelectSalesman.aspx', { width: '310px', height: '480px' }).lock().title('选择所属人员');
            });

            //选择险种
            $('#txtprod').click(function () {
                artDialog.open('SelectProdType.aspx', { width: '310px', height: '480px' }).lock().title('选择所属险种');
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/Public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        修改综合比率
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="background: #4CB0D5; height: 5px;">
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="ibtnAdd_Click" CommandName="add" />
            <asp:ImageButton ID="ibtnback" runat="server" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="ibtnback_Click" />
        </div>
        <table class="clsdata">
            <tr style="height: 26px;">
                <td style="width: 100px; text-align: right;">
                    人员：
                </td>
                <td>
                    <asp:TextBox ID="txtuser" runat="server" CssClass="clsunderline"></asp:TextBox>
                    <span style="color: Red;">*</span>
                </td>
                <td style="width: 100px; text-align: right;">
                    险种：
                </td>
                <td>
                    <asp:TextBox ID="txtprod" runat="server" CssClass="clsunderline"></asp:TextBox>
                    <span style="color: Red;">*</span>
                </td>
            </tr>
            <tr style="height: 26px;">
                <td style="width: 100px; text-align: right;">
                    比率：
                </td>
                <td>
                    <asp:TextBox ID="txtrate" runat="server" CssClass="clsunderline"></asp:TextBox>
                    <span style="color: Red;">*</span>
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="hiduserId" runat="server" />
    <input type="hidden" id="hidprodId" runat="server" />
    </form>
</body>
</html>
