<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectInvoiceUnit.aspx.cs"
    Inherits="EtNet_Web.Pages.Invoice.SelectInvoiceUnit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 40px 10px 40px;
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
        .clssift
        {
            width: 100%;
        }
        .clsunderline
        {
            width: 150px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
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
        #saveBack
        {
            margin-left: 400px;
        }
        #btn
        {
            margin-top: 10px;
        }img
        {
            border: none;
        }
    </style>
    <script type="text/javascript">
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
            $('#saveBack').click(function () {
                var origin = artDialog.open.origin;
                if ($('tr.selected').length == 0) {
                    alert('请选择单位');
                    return;
                }
                var cusid = origin.document.getElementById('HidComId');
                var cusname = origin.document.getElementById('txtUnit');

                cusid.value = $.trim($('tr.selected').find('#comid').html());
                cusname.value = $.trim($('tr.selected').find('#cuscname').html());
                art.dialog.close();
            });
            $('#cancel').click(function () {
                art.dialog.close();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td style="width: 60px;">
                    单位简称:
                </td>
                <td>
                    <input type="text" runat="server" id="cname" class="clsunderline" />
                </td>
                <td style="width: 60px;">
                    单位全称:
                </td>
                <td>
                    <input type="text" runat="server" id="caddress" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td style="width: 60px;">
                    &nbsp;
                </td>
                <td>
                </td>
                <td colspan="8" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="0" cellpadding="0">
            <tr>
                <th class="clstitleimg" style="width:40px">
                    选择
                </th>
                <th class="clstitleimg" style="width:150px">
                    单位代码
                </th>
                <th class="clstitleimg" style="width:150px">
                    单位简称
                </th>
                <th class="clstitleimg">
                    单位全称
                </th>
                <th style="display: none">
                    id
                </th>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="Rpunit">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="Radio1" type="radio" />
                            </td>
                            <td>
                                <%#Eval("comCode") %>
                            </td>
                            <td id="cuscname">
                                <%#Eval("comCName") %>
                            </td>
                            <td id="cusshortname">
                                <%#Eval("comShortName") %>
                            </td>
                            <td style="display: none" id="comid">
                                <%# Eval("id")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div runat="server" id="pages">
        </div>
        <table class="clssift">
            <tr>
                <td>
                </td>
                <td style="text-align: right; ">
                    <a id="saveBack" href="javascript:void(0);">
                        <img alt="保存" src="../../Images/Button/btn_sure.jpg" /></a> <a id="cancel" href="javascript:void(0);">
                            <img alt="取消" src="../../Images/Button/btn_cancel.jpg" /></a>
                </td>
            </tr>
        </table>
    </div>
    <input id="HidComId" type="hidden" runat="server" />
    </form>
</body>
</html>
