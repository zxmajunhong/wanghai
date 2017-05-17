<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectPayType.aspx.cs"
    Inherits="EtNet_Web.Pages.Order.SelectPayType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
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
        .clsdata
        {
            border-collapse: collapse;
            width: 100%;
        }
        .clsdata tr
        {
            background-color: #FFFFFF;
        }
        .clsdata th
        {
            border: 1px solid #DED6DC;
        }
        .clsdata tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .clsdata tr.hover td
        {
            background-color: #FFEFBB;
            cursor: pointer;
        }
        .clsdata tr.selected td
        {
            background-color: #FFECB5;
        }
        tr.odd td
        {
            background-color: #E3EBEF;
        }
    </style>
    <script type="text/javascript">

        window.onunload = function () {
            var dia = window.dialogArguments;
            dia.location = dia.location.href;
            window.close();
        }
        $(document).ready(function () {
            $('.clsdata tbody tr').each(function () {
                $(this).hover(function () {
                    $(this).toggleClass('hover');
                });
                $(this).click(function () {
                    $(this).addClass('selected').siblings().removeClass('selected').end()
                    .find(':radio').attr('checked', 'checked');
                    $(this).siblings().find(':radio').removeAttr('checked');
                });
            });

            $(".clsdata tbody>tr:odd").addClass("odd");

            $('#choose').click(function () {
                var origin = artDialog.open.origin;
                var id = origin.document.getElementById('hidpaytype').value;




                if ($('tr.selected').length == 0) {
                    alert('请选择类别');
                    return;
                }
                var typename = origin.document.getElementById(id);

                typename.value = $.trim($('tr.selected').find('.typename').html());
                art.dialog.close();
            });
            $('#cancel').click(function () {
                art.dialog.close();
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
                top: 5px; left: 5px;">选择付款类别</span>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <!--版本号：20130312-->
    <div class="clsbottom">
        <!--版本号:20120311-->
        <table class="clsdata" cellspacing="0" cellpadding="0">
            <tr>
                <th class="clstitleimg">
                    选择
                </th>
                <th class="clstitleimg">
                    类别名称
                </th>
                <th style="display: none">
                    id
                </th>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="type">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="Radio1" type="radio" />
                            </td>
                            <td class="typename">
                                <%#Eval("itemname")%>
                            </td>
                            <td style="display: none" class="paytypeid">
                                <%# Eval("id")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="btn" style="text-align: right; padding-top: 4px">
            <asp:ImageButton runat="server" ID="choose" ImageUrl="../../Images/button/btn_sure.jpg" />
            <asp:ImageButton runat="server" ID="cancel" ImageUrl="../../Images/button/btn_cancel.jpg" />
        </div>
    </div>
    </form>
</body>
</html>
