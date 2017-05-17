<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectOrderCollect.aspx.cs"
    Inherits="EtNet_Web.Pages.Financial.InvoiceRecord.SelectOrderCollect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../css/jPages.css" rel="stylesheet" type="text/css" />
    <script src="../js/jPages.min.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            font-size: 12px;
        }
        a
        {
            text-decoration: none;
        }
        a img
        {
            border: none;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .clsdata
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
            background-color: #B9D3EE;
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
        .clsdata tr.hover td, .clsdata tr.hover input
        {
            background-color: #FFEFBB !important;
            cursor: pointer;
        }
        .clsdata tr.selected td, .clsdata tr.selected input
        {
            background-color: #FFECB5 !important;
        }
        tr.odd td, tr.odd input
        {
            background-color: #E3EBEF !important;
        }
        td, input
        {
            font-size: 12px;
        }
        .num
        {
            background: #fff;
            border: none;
            text-align: center;
        }
        .display
        {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            /*点击一行出现的效果*/
            $('.clsdata tbody tr').each(function () {
                $(this).hover(function () {
                    $(this).toggleClass('hover');
                });
                $(this).click(function () {
                    if ($(this).hasClass("selected")) {
                        $(this).removeClass("selected").find('input').removeAttr("checked");
                    }
                    else {
                        $(this).addClass('selected')
                                        .find('input').attr('checked', 'checked');
                    }
                });
            });

            //分页
            $("div.holder").jPages({
                containerID: "orderCollectList",
                previous: "上一页",
                next: "下一页",
                perPage: 10,
                delay: 20
            });

            $(".num").focus(function () { $(this).blur(); });
            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td,.clsdata tr:odd input").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            $('#saveBack').click(function () {
                var origin = artDialog.open.origin;
                if ($('tr.selected').length == 0) {
                    alert('请选择订单');
                    return;
                }

                var listHTML = "";
                $('tr.selected').each(function () {
                    listHTML += "<tr>";
                    listHTML += $(this).html();
                    listHTML += "</tr>";
                })
                window.parent.getList(listHTML);


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
    <div>
        <table id="mytable2" style="text-align: center;" cellspacing="1" class="clsdata">
            <thead>
                <tr>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 40px;">
                        选择
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 120px;">
                        订单序号
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 80px;">
                        应开票金额
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 80px;">
                        未开票金额
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 80px;">
                        已开票金额
                    </th>
                </tr>
            </thead>
            <tbody id="orderCollectList">
                <asp:Repeater ID="rpOrderCollectList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="del">
                                <input id="Checkbox1" type="checkbox" />
                            </td>
                            <td class="orderNum">
                                <%#Eval("orderNum") %>
                            </td>
                            <td class="amount">
                                <%#Eval("shouldAmount", "{0:F2}")%>
                            </td>
                            <td>
                                <input class="num" style="color: Red" readonly="readonly" datatype="Require" msg="开票金额不能为空"
                                    maxvalue='<%#Eval("canAmount") %>' value='<%#Eval("canAmount") %>' type="text" />
                            </td>
                            <td class="remove">
                                <%#Eval("hasAmount", "{0:F2}")%>
                            </td>
                            <td class="cId" style="display:none;">
                                <%#Eval("collectId") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="pages" class="holder">
        </div>
        <table style="width: 100%; margin-top: 10px;">
            <tr>
                <td align="right">
                    <a href="javascript:void(0);" id="saveBack">
                        <img alt="保存" src="../../../Images/Button/btn_sure.jpg" /></a><a href="javascript:void(0);"
                            id="cancel">
                            <img alt="取消" src="../../../Images/Button/btn_cancel.jpg" /></a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
