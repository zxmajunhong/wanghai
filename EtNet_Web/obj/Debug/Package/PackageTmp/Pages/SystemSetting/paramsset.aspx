<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paramsset.aspx.cs" Inherits="EtNet_Web.Pages.SystemSetting.paramsset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设置</title>
    <link href="default.css" rel="stylesheet" type="text/css" />
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
        .clsdata tr td
        {
            height: 20px;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .clsfirmtxt
        {
            width: 200px;
            height: 60px;
            border: 1px solid #C6E2FF;
            overflow: auto;
        }
        .buttonStyle
        {
            background: url('../../Images/buticon.gif');
            height: 22px;
            width: 64px;
            border: 0;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">

        //税金改管理费<input name='' runat="server"  type='text' class="clsunderline" />

        $(function () {
            $('#tc').click(function () {
                art.dialog.open('addratio.aspx').lock().title('提成比例设置');
            })
        })

        
    </script>
</head>
<body style="padding: 10px;">
    <form id="MYFROM" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        参数设置
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="imgbtnadd" runat="server" ImageUrl="../../Images/Button/btn_save.jpg" OnClick="imgbtnadd_Click" />
        </div>
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <tr>
                <td style="width: 100px;">
                    银行利率(%):
                </td>
                <td style="width: 300px;">
                    <input name='' runat="server" type='text' id='rate' class="clsunderline" />
                </td>
                <td style="width: 80px;">
                    免息天数(天):
                </td>
                <td>
                    <input name='' runat="server" type='text' id='freeDay' class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    咨询费比率(%):
                </td>
                <td colspan="3">
                    <input name='' runat="server" type='text' id='zxfbl' class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    管理费比率(%):
                </td>
                <td colspan="3">
                    <input name='' runat="server" type='text' id='glfbl' class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    服务费比率(%):
                </td>
                <td colspan="3">
                    <input name='' runat="server" type='text' id='fwfbl' class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    经纪费税率(%):
                </td>
                <td colspan="3">
                    <input name='' runat="server" type='text' id='jjfsl' class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    服务费税率(%):
                </td>
                <td colspan="3">
                    <input name='' runat="server" type='text' id='fwfsl' class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    其他费税率(%):
                </td>
                <td colspan="3">
                    <input name='' runat="server" type='text' id='qtsl' class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <span id="tc" style="cursor: pointer; color: Blue; text-decoration: underline">提成制度</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
