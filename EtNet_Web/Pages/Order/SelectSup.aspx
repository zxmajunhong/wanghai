<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectSup.aspx.cs" Inherits="EtNet_Web.Pages.Order.SelectSup" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>选择付款单位</title>
    <script src="../CusInfo/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Product/artDialog.js" type="text/javascript"></script>
    <script src="../Product/iframeTools.js" type="text/javascript"></script>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 10px 10px 10px;
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
        /*
        #saveBack
        {
            margin-left: 420px;
        }*/
        #btn
        {
            margin-top: 10px;
            width: 100%;
            text-align: right;
        }
        a img
        {
            border: none;
        }
        a
        {
            text-decoration: none;
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
                debugger;
                var origin = artDialog.open.origin;
                if ($('tr.selected').length == 0) {
                    alert('请选择付款单位');
                    return;
                }
                debugger;
                //联系人id（当前读取的是付款单位主表中的联系人信息，所以给的联系人id值为0）
                var linkidvalue = document.getElementById('linkID').value;
                var linkid = origin.document.getElementById(linkidvalue);
                linkid.value = 0;

                //联系人名称
                var payLinkvalue = document.getElementById('payLink').value;
                var payLink = origin.document.getElementById(payLinkvalue);
                payLink.value = $.trim($('tr.selected').find('#linkName').html());

                var supvalue = origin.document.getElementById('hidsupvalue').value;
                //付款单位名称
                var sup = origin.document.getElementById(supvalue);

                sup.value = $.trim($('tr.selected').find('#comname').html());

                //存储付款单位id
                var idvalue = origin.document.getElementById("hidsupid").value;

                var id = origin.document.getElementById(idvalue);

                id.value = $.trim($('tr.selected').find('#comid').html());

                if (document.all) {
                    origin.document.getElementById(idvalue).innerText = $.trim($('tr.selected').find('#comid').html()); ;
                }
                else {
                    origin.document.getElementById(idvalue).textContent = $.trim($('tr.selected').find('#comid').html()); ;
                }

                art.dialog.close();
            });


            $('#cancel').click(function () {
                art.dialog.close();
            });
        });
    </script>
</head>
<body style="width: 600px">
    <form id="form1" runat="server">
    <input type="hidden" id="supname" value="" runat="server" />
    <input type="hidden" id="linkID" value="" runat="server" /><!--存储联系人id列的id -->
    <input type="hidden" id="payLink" value="" runat="server" /><!--存储联系人列的id -->
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td style="width: 80px;">
                    付款单位简称:
                </td>
                <td>
                    <input type="text" runat="server" id="txtShortName" class="clsunderline" />
                </td>
                <td style="width: 80px;">
                    付款单位类别:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddltype" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 60px;">
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
                <th width="40px" class="clstitleimg">
                    选择
                </th>
                <th width="80px" class="clstitleimg">
                    付款单位代码
                </th>
                <th width="80px" class="clstitleimg">
                    付款单位简称
                </th>
                <th width="200px" class="clstitleimg">
                    付款单位全称
                </th>
                <th width="80px" class="clstitleimg">
                    单位类别
                </th>
                <th style="display: none">
                    id
                </th>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="RpCustomerList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="Radio1" type="radio" />
                            </td>
                            <td>
                                <%#Eval("factCode") %>
                            </td>
                            <td>
                                <%# Eval("factShortName") %>
                            </td>
                            <td id="comname">
                                <%#Eval("factCName") %>
                            </td>
                            <td id="saleman">
                                <%# facttype(Eval("factType").ToString())%>
                            </td>
                            <td style="display: none" id="linkName">
                                <%# Eval("linkeName") %>
                            </td>
                            <td style="display: none" id="comid">
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
        <div id="btn">
            <a href="javascript:void(0);" id="saveBack">
                <img alt="确定" src="../../Images/button/btn_sure.jpg" /></a> <a href="javascript:void(0);"
                    id="cancel">
                    <img alt="取消" src="../../Images/button/btn_cancel.jpg" /></a></div>
    </div>
    </form>
</body>
</html>
