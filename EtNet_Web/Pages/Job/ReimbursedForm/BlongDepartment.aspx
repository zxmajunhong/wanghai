﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlongDepartment.aspx.cs"
    Inherits="EtNet_Web.Pages.Job.ReimbursedForm.BlongDepartment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>页面设置</title>
    <base target="_self" />
    <script src="../../Common/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Common/artDialog.js" type="text/javascript"></script>
    <script src="../../Common/iframeTools.js" type="text/javascript"></script>
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
            background-image: url('../../../Images/public/list_tit.png');
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
                debugger
                var origin = artDialog.open.origin;
                var id = origin.document.getElementById('hidblong').value;
                //                var blong = 'blong' + id;

                if ($('tr.selected').length == 0) {
                    alert('请选择类别');
                    return;
                }
                var cusid = origin.document.getElementById('HidDepartmentID');
                var cusname = origin.document.getElementById(id);

                //                if (cusname == null) {
                //                    var blongid = 'blong' + (id - 1);
                //                    var cusid = origin.document.getElementById('HidDepartmentID');
                //                    var cusname = origin.document.getElementById(blongid);
                //                    art.dialog.close();
                //                } else {
                //                    origin.document.getElementById('hidblong').value = id + 1;
                //                }
                cusid.value = "";
                cusid.value = $.trim($('tr.selected').find('.austypeid').html()); //得到所选择部门的id
                cusname.value = "";
                cusname.value = $.trim($('tr.selected').find('.typename').html()); //得到所选择部门的名字

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
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <span style="color: White; font-size: 12px; font-weight: bold; position: relative;
                top: 5px; left: 5px;">选择部门</span>
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
                    部门
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
                                <%#Eval("departcname")%>
                            </td>
                            <td style="display: none" class="austypeid">
                                <%# Eval("departid")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="btn" style="text-align: right; padding-top: 4px">
            <asp:ImageButton runat="server" ID="choose" ImageUrl="../../../Images/button/btn_sure.jpg" />
            <asp:ImageButton runat="server" ID="cancel" ImageUrl="../../../Images/button/btn_cancel.jpg" />
        </div>
    </div>
    </form>
</body>
</html>
