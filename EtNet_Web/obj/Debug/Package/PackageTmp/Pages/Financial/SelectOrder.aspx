<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectOrder.aspx.cs" Inherits="EtNet_Web.Pages.Financial.SelectOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="css/jPages.css" rel="stylesheet" type="text/css" />
    <script src="js/jPages.min.js" type="text/javascript"></script>
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
            background-image: url('../../Images/public/list_tit.png');
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
            text-align: center;
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
        .amount
        {
            background: #fff;
            border: none;
            text-align: center;
        }
        a, input
        {
            outline: none;
            font-family: 宋体;
        }
        .clsunderline
        {
            width: 200px;
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
        $(document).ready(function () {
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
                containerID: "policyList",
                previous: "上一页",
                next: "下一页",
                perPage: 10,
                delay: 20,
                animation: "false"
            });

            $(".amount").focus(function () { $(this).blur(); });

            $(".num").focus(function () { $(this).blur(); });

            //$("#mytable2 tbody>tr:odd").addClass("odd");
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
                //list.innerText = listHTML;
                window.parent.getList(listHTML);

                //window.parent.addDelCol();

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
        <table border="0" style="padding-bottom:20px;width:100%">
            <tr>
                <td style="width:25px;text-align:right;">
                    订单编号：
                </td>
                <td style="width:25%" align="left" >
                    <input type="text" id="txtordernum" runat="server" class="clsunderline" />
                </td>
                <td style="width:25%">
                    <asp:ImageButton runat="server" ID="btnFilter" ImageUrl="~/Images/Button/btn_search.jpg"
                    OnClick="btnFilter_Click" />
                <asp:ImageButton runat="server" ID="btnResetFilter" ImageUrl="~/Images/Button/btn_reset.jpg"
                    OnClick="btnResetFilter_Click" />
                </td>
                <td style="width:25%">
                    <asp:CheckBox ID="cbxshowfile" runat="server" Text="显示存档" 
                        oncheckedchanged="cbxshowfile_CheckedChanged" AutoPostBack="true" />
                </td>
            </tr>
        </table>
        <table id="mytable2" style="text-align: center;" cellspacing="1" class="clsdata">
            <thead>
                <tr>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 9%;">
                        选择
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 23%;">
                        订单编号
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 23%;">
                        应付金额
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 23%;">
                        剩余支付金额
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 23%;">
                        已付金额
                    </th>
                </tr>
            </thead>
            <tbody id="policyList">
                <asp:Repeater ID="RpPolicyList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="del">
                                <input name="check" type="checkbox" />
                            </td>
                            <td class="pnum">
                                <%# Eval("orderNum") %>
                            </td>
                            <td class="shouldAmount">
                                <%# Eval("money") == DBNull.Value ? "0.00" : Eval("money").ToString()%>
                            </td>
                            <td>
                                <input class="amount" style="color: Red" readonly="readonly" datatype="Require" msg="金额不能为空"
                                    maxvalue='<%# GetCanAmount(Eval("money"), Eval("paydetailID")) %>'
                                    value='<%# GetCanAmount(Eval("money"), Eval("paydetailID")) %>'
                                    type="text" />
                            </td>
                            <td class="nouse" style="color: Green;">
                                <%# GetHasAmount(Eval("paydetailID"))%>
                            </td>
                            <td class="pid" style="display: none; width: 0px;">
                                <%# Eval("paydetailID")%>
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
                        <img alt="保存" src="../../Images/Button/btn_sure.jpg" /></a><a href="javascript:void(0);"
                            id="cancel">
                            <img alt="取消" src="../../Images/Button/btn_cancel.jpg" /></a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
