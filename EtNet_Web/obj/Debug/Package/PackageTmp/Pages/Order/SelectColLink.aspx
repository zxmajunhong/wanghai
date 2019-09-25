<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectColLink.aspx.cs" Inherits="EtNet_Web.Pages.Order.SelectColLink" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择联系人</title>
    <script src="../CusInfo/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Product/artDialog.js" type="text/javascript"></script>
    <script src="../Product/iframeTools.js" type="text/javascript"></script>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
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
                    alert('请选择营业部信息');
                    return;
                }

                //营业部名称
                var linkvalue = document.getElementById('hidlink').value;
                var link = origin.document.getElementById(linkvalue);
                link.value = $.trim($('tr.selected').find('#link').html());

                //营业部id
                var idvalue = document.getElementById("hidlinkid").value;
                var id = origin.document.getElementById(idvalue);
                id.value = $.trim($('tr.selected').find('#linkid').html());

                //营业部联系人名称
                var linknamevalue = document.getElementById('hidlinkname').value;
                var linkname = origin.document.getElementById(linknamevalue);
                linkname.value = $.trim($('tr.selected').find('#linkname').html());

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
    <input type="hidden" id="hidlinkname" value="" runat="server" />
    <input type="hidden" id="hidlinkid" value="" runat="server" />
    <input type="hidden" id="hidlink" value="" runat="server" />
    <div class="clsbottom">
        <table class="clsdata" cellspacing="0" cellpadding="0">
            <tr>
                <th width="40px" class="clstitleimg">
                    选择
                </th>
                <th width="100px" class="clstitleimg">
                    营业部名称
                </th>
                <th width="100px" class="clstitleimg">
                    联系人名称
                </th>
                <th width="100px" class="clstitleimg">
                    联系人电话
                </th>
                <th width="100px" class="clstitleimg">
                    联系人手机
                </th>
                <th width="100px" class="clstitleimg">
                    联系人邮箱
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
                            <td id="link">
                                <%#Eval("departName")%>
                            </td>
                            <td id="linkname">
                                <%# Eval("linkName")%>
                            </td>
                            <td>
                                <%# Eval("telephone") %>
                            </td>
                            <td>
                                <%# Eval("mobile")%>
                            </td>
                            <td>
                                <%# Eval("email")%>
                            </td>
                            <td style="display: none" id="linkid">
                                <%# Eval("id")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div runat="server" id="pages">
        </div>
        <div id="btn">
            <a href="javascript:void(0);" id="saveBack">
                <img alt="确定" src="../../Images/button/btn_sure.jpg" /></a> <a href="javascript:void(0);"
                    id="cancel">
                    <img alt="取消" src="../../Images/button/btn_cancel.jpg" /></a></div>
    </div>
    </form>
</body>
</html>
