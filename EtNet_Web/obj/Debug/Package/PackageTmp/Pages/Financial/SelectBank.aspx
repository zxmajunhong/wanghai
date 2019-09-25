<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectBank.aspx.cs" Inherits="EtNet_Web.Pages.Financial.SelectBank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>

    <style type="text/css">
        body{width:600px;font-size:12px;}
        .clsdata{border-collapse: collapse;width: 100%;}
        .clsdata tr{background-color: #FFFFFF;}
        .clsdata th{border: 1px solid #DED6DC;}
        .clsdata tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .clsdata tr.hover td{background-color: #FFEFBB;cursor: pointer;}
        .clsdata tr.selected td{background-color: #FFECB5;}
        tr.odd td{background-color: #E3EBEF;}
        a{text-decoration: none;}
        a img{border:none;}
        .paginator{font: 12px Arial, Helvetica, sans-serif;padding: 5px;margin: 0px;}
        .paginator a{border: solid 1px #ccc;color: #0063dc;cursor: pointer;text-decoration: none;}
        .paginator a:visited{padding: 1px 6px;border: solid 1px #61befe;background: #61befe;color: #fff;text-decoration: none;}
        .paginator .cpb{border: 1px solid #61befe;font-weight: 700;color: #fff;background-color: #61befe;}
        .paginator a:hover{border: solid 1px #61befe;color: #fff;background: #61befe;text-decoration: none;}
        .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover{float: left;height: 21px;line-height: 21px;min-width: 10px;_width: 10px;margin-right: 5px;text-align: center;white-space: nowrap;font-size: 12px;font-family: Arial,SimSun;padding: 0 4px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <table id="customerTable" class="clsdata" cellspacing="0" cellpadding="0">
            <thead>
                <tr>
                    <th width="40px" class="clstitleimg">
                        选择
                    </th>
                    <th width="80px" class="clstitleimg">
                        银行名称
                    </th>
                    <th width="100px" class="clstitleimg">
                        银行账号
                    </th>
                    <th  width="200px"class="clstitleimg">
                        开户名称
                    </th>
                    <th  width="200px"class="clstitleimg">
                        备注
                    </th>
                    <th style="display: none">
                        id
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="RpBankList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="Radio1" type="radio" />
                            </td>
                            <td class="bankName">
                                <%#Eval("bankName") %>
                            </td>
                            <td class="bankAccount">
                                <%# Eval("bankAccount") %>
                            </td>
                            <td class="bankUser">
                                <%#Eval("bankUser") %>
                            </td>
                            <td class="bankMark">
                                <%#Eval("bankMark") %>
                            </td>
                            <td style="display: none" class="bankID">
                                <%# Eval("bankID")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <div style="text-align:right;padding-top:5px;">
        <a href="javascript:void(0);" onclick="Save();" id="save" title="保存">
            <img alt="保存" src="../../Images/Button/btn_sure.jpg" />
        </a>
        <a href="javascript:void(0);" onclick="Cancel();" id="cancel" title="取消">
            <img alt="取消" src="../../Images/Button/btn_cancel.jpg" />
        </a>
    </div>
    <script type="text/javascript">
        $(document).ready(
            function () {
                $('#customerTable tbody tr').each(function () {
                    $(this).hover(function () {
                        $(this).toggleClass('hover');
                    });
                    $(this).click(function () {
                        $(this).addClass('selected').siblings().removeClass('selected').end()
                            .find(':radio').attr('checked', 'checked');
                        $(this).siblings().find(':radio').removeAttr('checked');
                        $('#companyTable tbody tr').each(function () {
                            $(this).removeClass('selected').find(':radio').removeAttr('checked');
                        });
                    });
                });

                $(".clsdata tbody>tr:odd").addClass("odd");
            }
        );

        function Save() {
            if ($('#hidPayerID').val() == "") {
                alert("请选择付款单位");
                return;
            }
            var origin = artDialog.open.origin;
            if ($('tr.selected').length == 0) {
                alert('请选择银行');
                return;
            }
            var bankName = origin.document.getElementById('txtBankName');
            var bankAccount = origin.document.getElementById('txtBankAccount');
            var bankUser = origin.document.getElementById('txtBankAccountName');
            var bankMark = origin.document.getElementById('txtBankMark');
            var bankID = origin.document.getElementById('hidBankID');
            
            bankName.value = $.trim($('tr.selected').find('.bankName').text());
            bankAccount.value = $.trim($('tr.selected').find('.bankAccount').text());
            bankUser.value = $.trim($('tr.selected').find('.bankUser').text());
            bankID.value = $.trim($('tr.selected').find('.bankID').text());
            bankMark.value = $.trim($('tr.selected').find('.bankMark').text());

            art.dialog.close();
        }

        function Cancel() {
            art.dialog.close();
        }
    </script>
    </form>
</body>
</html>
