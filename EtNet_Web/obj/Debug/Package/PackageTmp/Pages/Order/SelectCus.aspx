<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCus.aspx.cs" Inherits="EtNet_Web.Pages.Order.SelectCus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>选择收款单位</title>
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
                    alert('请选择收款单位');
                    return;
                }

                var value = document.getElementById('salemane').value;
                var cusvalue = origin.document.getElementById('hidcusvalue').value;

                //收款单位名称
                var cusid = origin.document.getElementById(cusvalue);
                //业务员
                var saleman = origin.document.getElementById(value);

                var idvalue = origin.document.getElementById("hidcusid").value;

                var id = origin.document.getElementById(idvalue);

                cusid.value = $.trim($('tr.selected').find('#comname').html());

                saleman.value = $.trim($('tr.selected').find('#saleman').html());

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
    <input type="hidden" id="salemane" value="" runat="server" />
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td style="width: 80px;">
                    收款单位简称:
                </td>
                <td>
                    <input type="text" runat="server" id="txtShortName" class="clsunderline" />
                </td>
                <td style="width: 80px;">
                    收款单位全称:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtFullName" class="clsunderline" />
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
                    收款单位代码
                </th>
                <th width="80px" class="clstitleimg">
                    收款单位简称
                </th>
                <th width="200px" class="clstitleimg">
                    收款单位全称
                </th>
                <th width="80px" class="clstitleimg">
                    业务员
                </th>
                <th width="80px" class="clstitleimg">
                    客户等级
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
                                <%#Eval("cusCode") %>
                            </td>
                            <td>
                                <%# Eval("cusShortName") %>
                            </td>
                            <td id="comname">
                                <%#Eval("cusCName") %>
                            </td>
                            <td id="saleman">
                                <%# touser(Eval("cusType").ToString())%>
                            </td>
                            <td>
                                <%# cuspro(Eval("cusPro").ToString()) %>
                            </td>
                            <td style="display: none" id="linkName">
                                <%# Eval("linkName") %>
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
