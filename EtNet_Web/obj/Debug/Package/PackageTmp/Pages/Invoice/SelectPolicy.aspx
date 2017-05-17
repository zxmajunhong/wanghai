<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectPolicy.aspx.cs" Inherits="EtNet_Web.Pages.Invoice.SelectPolicy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
            width: 120px;
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
        #btn
        {
            margin-top: 10px;
        }
        img
        {
            border: none;
        }
        
        .filterInput, input.Wdate
        {
            width: 100px;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        input.Wdate
        {
            cursor: pointer;
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

            $(".clsdata tbody>tr:odd").addClass("odd");

            $('#saveBack').click(function () {
                var origin = artDialog.open.origin;
                if ($('tr.selected').length == 0) {

                    alert('请选择保单');
                    return;
                }

                var list = origin.document.getElementById('policyList');
                
                var listHTML = "";
                $('tr.selected').each(function () {
                    listHTML += "<tr>"; 
                    listHTML += $(this).html();
                    listHTML += "</tr>";
                })
                //list.innerText = listHTML;
                window.parent.getList(listHTML);

                window.parent.addDelCol();

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
                <td>
                    保单编号:<input type="text" runat="server" id="serialnum" class="clsunderline" />&nbsp;
                    时间范围:<input type="text" runat="server" id="txtBeginDate" class="filterInput Wdate"
                        onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    至
                    <input type="text" runat="server" id="txtEndDate" class="filterInput Wdate" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr align="right">
                <td>
                    <asp:ImageButton ID="ibtnSearch" ImageUrl="../../Images/Button/btn_search.jpg" runat="server"
                        OnClick="ibtnSearch_Click" />
                      &nbsp;<asp:ImageButton ID="ibtnReset" ImageUrl="../../Images/Button/btn_Reset.jpg"
                        runat="server" OnClick="ibtnReset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="0" cellpadding="0" id="table">
            <tr>
                <th class="clstitleimg" style="width: 50px">
                    选择
                </th>
                <th class="clstitleimg" style="width: 180px">
                    保单编号
                </th>
                <th class="clstitleimg">
                    客户名称
                </th>
                <th class="clstitleimg">
                    费用金额
                </th>
                <th style="display: none">
                    id
                </th>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="Rppolicy">
                    <ItemTemplate>
                        <tr>
                            <td class="delete">
                                <span>
                                    <input id="checkbox" type="checkbox" />
                                </span>
                            </td>
                            <td align="center">
                                <span class="clsblurtxt clsedit">
                                    <%#Eval("serialnum")%></span>
                            </td>
                            <td id="cuscname" align="center">
                                <span class="clsblurtxt clsedit">
                                    <%# customer( Convert.ToInt32(Eval("customer"))) %></span>
                            </td>
                            <td id="cusshortname" align="center">
                                <span class="clsblurtxt clsedit">
                                    <%# changerNull( Eval(price()).ToString()) %>
                                    <input class="linePrice" type="text" runat="server" value="<%#  changerNull( Eval(price()).ToString()) %>"
                                        style="display: none" />
                            </td>
                            <td style="display: none" id="comid" align="center">
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
            <tr align="right">
                <td>
                    <a href="javascript:void(0);" id="saveBack">
                        <img alt="保存" src="../../Images/Button/btn_sure.jpg" /></a><a href="javascript:void(0);"
                            id="cancel">
                            <img alt="取消" src="../../Images/Button/btn_cancel.jpg" /></a>
                </td>
            </tr>
        </table>
    </div>
    <input id="HidComId" type="hidden" runat="server" />
    <input id="HidText" type="hidden" runat="server" />
    <input id="HidPolicyID" type="hidden" runat="server" />
    </form>
</body>
</html>
