<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCollect.aspx.cs"
    Inherits="EtNet_Web.Pages.Financial.SelectCollect" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../Policy/tab.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            width: 600px;
            font-size: 12px;
        }
        #selectInfo
        {
            margin: 0px -1px 0px -1px;
            height: 30px;
            line-height: 30px;
            background: #F5F5F5;
            font-size: 12px;
            color: #333333;
            border: 1px solid #D4D4D4;
            border-top: 0px;
            padding-left: 10px;
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
        a
        {
            text-decoration: none;
        }
        a img
        {
            border: none;
        }
        .clsunderline
        {
            width: 150px;
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
        }
    </style>
    <script type="text/javascript">
        $(document).ready(
            function () {
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
            }
        );

        function Save() {
            var origin = artDialog.open.origin;
            if ($('tr.selected').length == 0) {
                alert('请选择收款单位');
                return;
            }
            var payerID = origin.document.getElementById('hidPayerID');
            var payerName = origin.document.getElementById('txtPayerName');
            payerID.value = $.trim($('tr.selected').find('.factID').html());
            payerName.value = $.trim($('tr.selected').find('.factSName').html());
            art.dialog.close();
        }

        function Cancel() {
            art.dialog.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" style="padding-bottom: 20px">
        <tr>
            <td style="width: 60px; text-align: right;">
                收款单位:
            </td>
            <td style="width: 200px; float: left;">
                <input type="text" id="txtskdw" runat="server" class="clsunderline" />
            </td>
            <td style="width: 60px; text-align: right;">
                单位简称:
            </td>
            <td style="width: 200px; float: left;">
                <input type="text" id="txtdwjc" runat="server" class="clsunderline" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                <asp:ImageButton runat="server" ID="btnFilter" ImageUrl="~/Images/Button/btn_search.jpg"
                    OnClick="btnFilter_Click" />
                <asp:ImageButton runat="server" ID="btnResetFilter" ImageUrl="~/Images/Button/btn_reset.jpg"
                    OnClick="btnResetFilter_Click" />
            </td>
        </tr>
    </table>
    <table id="facttomerTable" class="clsdata" cellspacing="0" cellpadding="0">
        <thead>
            <tr>
                <th width="40px" class="clstitleimg">
                    选择
                </th>
                <th width="80px" class="clstitleimg">
                    收款单位
                </th>
                <th width="100px" class="clstitleimg">
                    客户简称
                </th>
                <th width="200px" class="clstitleimg">
                    客户名称
                </th>
                <th style="display: none">
                    id
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="RpfacttomerList">
                <ItemTemplate>
                    <tr>
                        <td>
                            <input id="Radio1" type="radio" />
                        </td>
                        <td class="factCode">
                            <%#Eval("factCode")%>
                        </td>
                        <td class="factSName">
                            <%# Eval("factShortName")%>
                        </td>
                        <td class="factName">
                            <%#Eval("factCName")%>
                        </td>
                        <td style="display: none" class="factID">
                            <%# Eval("id")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页"
            PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
            CustomInfoTextAlign="Left" LayoutType="Table" NumericButtonCount="5">
        </webdiyer:AspNetPager>
    <div style="text-align: right; padding-top: 5px;">
        <a href="javascript:void(0);" onclick="Save();" id="save" title="保存">
            <img alt="保存" src="../../Images/Button/btn_save.jpg" />
        </a><a href="javascript:void(0);" onclick="Cancel();" id="cancel" title="取消">
            <img alt="取消" src="../../Images/Button/btn_cancel.jpg" />
        </a>
    </div>
    <input id="hidPayerType" type="hidden" value="" runat="server" />
    <input id="hidPayerName" type="hidden" value="" runat="server" />
    <input id="hidPayerID" type="hidden" value="" runat="server" />
    <input id="hidPayerCode" type="hidden" value="" runat="server" />
    </form>
</body>
</html>
