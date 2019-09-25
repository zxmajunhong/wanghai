<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusShortName.aspx.cs" Inherits="EtNet_Web.Pages.Common.CusShortName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>页面设置</title>
    <base target="_self" />
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../CusInfo/artDialog.js" type="text/javascript"></script>
    <script src="../CusInfo/iframeTools.js" type="text/javascript"></script>
    <style type="text/css">
        .clstop
        {
            margin: 5px 10px 0px 10px;
        }
        .clsbottom
        {
            margin: 0px 10px 0px 10px;
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
            width: 100px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        hr
        {
            color: #4CB0D5;
            background-color: #4CB0D5;
            border: 0;
            height: 1px;
        }
    </style>
    <script type="text/javascript">

        window.onunload = function () {
            var dia = window.dialogArguments;
            dia.location = dia.location.href;
            window.close();
        }

        $(document).ready(function () {
            $('.choose').each(function () {
                $(this).click(function () {
                    var origin = artDialog.open.origin;
                    var cusname = origin.document.getElementById('cusshortname');

                    cusid.value = $.trim($(this).find('.custypeid').html());

                    art.dialog.close();
                });
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <span style="color: White; font-size: 12px; font-weight: bold; position: relative;
                top: 5px; left: 5px;">显示设置</span>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="float: right; margin-bottom: 5px;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="../../Images/Button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
        </div>
        <table class="clsdata">
            <tr>
                <td>
                    客户简称
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxName"></asp:TextBox><span
                        style="color: Red;">*</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
