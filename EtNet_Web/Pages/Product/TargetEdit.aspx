<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TargetEdit.aspx.cs" Inherits="EtNet_Web.Pages.Product.TargetEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="jquery-1.7.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="product.css" />
    <link href="common.css" rel="stylesheet" type="text/css" />
    <link href="product.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tabledata table#table th
        {
            height: 24px;
        }
        .sortable tbody tr
        {
            cursor: pointer;
        }
        .sortable tbody tr:hover
        {
            background-color: Orange;
        }
        tr.selected
        {
            background-color: Green;
        }
        #need, #need li
        {
            margin-left: 0px;
            padding-left: 0px;
        }
        #need li.chk input
        {
            width: 15px;
            margin-right: 20px;
        }
        #need li.chk label
        {
            padding-left: 0px;
        }
        #tbljobprocess
        {
            background-color: #E5E5E5;
            display: none;
        }
        #tbljobprocess tr td
        {
            background-color: White;
        }
        .imgBtn
        {
            cursor: pointer;
        }
        .add
        {
            margin-right: 2px;
        }
        .tbxprocess
        {
            border: 0px;
            width: 95%;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            var show = document.getElementById("HidShow").value;
            if (show == "true") {
                $('#tbljobprocess').show();
            }
            else {
                $('#tbljobprocess').hide();
            }

            $('#rdoDataType_0,#rdoDataType_2,#rdoDataType_3').click(function () {
                $('#tbljobprocess').hide();
            });
            $('#rdoDataType_1').click(function () {
                $('#tbljobprocess').show();
            });
            $('#btnBack').click(function () {
                window.location.href = 'TargetManager.aspx';
            });
        });
        function addRow() {
            var row = "<tr><td><input class='tbxprocess' type='text' /></td><td><img class='add imgBtn' onclick='addRow()' alt='添加一行' src='Image/add.png' /><img class='delete imgBtn' onclick='delRow(this)' alt='删除' src='Image/backto.png' /></td></tr>";
            $('#tbljobprocess').append(row);
        }

        function delRow(e) {
            if ($('#tbljobprocess tr').size() <= 1) {
                alert('最后一行不能删除');
            }
            else {
                $(e).parent("td").parent("tr").remove();
            }
        }

        function CheckBoxList_Click(sender) {
            var container = sender.parentNode;
            if (container.tagName.toUpperCase() == "TD") {
                container = container.parentNode.parentNode;
            }
            var chkList = container.getElementsByTagName("input");
            var senderState = sender.checked;
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = false;
            }
            sender.checked = senderState;
        }


        function ReadySave() {
            var radio = document.getElementById('rdoDataType_1');
            var item = document.getElementById('HidItem');
            var values = '';
            if (radio.checked) {
                $('#tbljobprocess input').each(function () {
                    values += $(this).val();
                    values += '$￥$';
                });
            }
            item.value = values;
            $('(#tbljobprocess input)[type="checkbox"]').each(function () {
                if ($(this).attr("checked")) {
                    $('#HidMainFlag').val($(this).attr('id'));
                }
            });
            if ($("#txtName").val() == "") {
                $('#msg').html("标的描述不能为空").show();
                return false;
            }
            else {
                return true;
            }
        }

        var name = document.getElementById('txtName');
        name.onblur = CheckProData;
        function CheckProData() {
            if ($("#txtName").val() == "") {
                $('#msg').html("标的描述不能为空").show();
            }
            else {
                $('#msg').hide();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">标的定义</span>
    </div>
    <div class="border" id="slider">
        <table id="tabledata" style="width: 100%;">
            <tr>
                <td colspan="8" style="background-image: url('../../Images/public/win_top.png');
                    background-repeat: repeat-x; height: 31px">
                    <div style="margin-top: 10px">
                        <span class="opadd" style="font-size: 13px; font-weight: bold; margin: 10px 0 10px 10px;">
                            标的描述</span> <span style="float: right; margin-right: 10px; margin-top: -5px">
                                <asp:ImageButton ID="btnSave" OnClientClick="return ReadySave();" ImageUrl="../../Images/Button/btn_save.jpg"
                                    runat="server" OnClick="btnSave_Click" />
                                <a id="btnBack" href="javascript:void(0);">
                                    <img alt="返回" src="../../Images/Button/btn_back.jpg" /></a> </span>
                    </div>
                </td>
            </tr>
        </table>
        <div>
            <ol id="need">
                <li>
                    <label class="">
                        标的描述：</label>
                    <asp:TextBox ID="txtName" Text="" runat="server"></asp:TextBox><label id="msg"></label></li>
                <li>
                    <label class="">
                        标的编号：</label><asp:TextBox ID="txtNum" Text="" Enabled="false" runat="server"></asp:TextBox></li>
                <li class="chk">
                    <label style="padding-left: 30px; padding-right: 10px" class="">
                        是否主标：</label><asp:CheckBoxList ID="chkMain" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" TextAlign="Left">
                            <asp:ListItem onclick="CheckBoxList_Click(this)" Value="T">主标</asp:ListItem>
                            <asp:ListItem onclick="CheckBoxList_Click(this)" Value="F">副标</asp:ListItem>
                        </asp:CheckBoxList>
                    <asp:CheckBox ID="isrequired" runat="server" Text="是否必填" TextAlign="Left" />
                </li>
                <li class="chk">
                    <label style="padding-left: 30px; padding-right: 10px" class="">
                        数据类型：<asp:RadioButtonList ID="rdoDataType" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" TextAlign="Left">
                            <asp:ListItem Selected="True" Value="0">文字描述</asp:ListItem>
                            <asp:ListItem Value="9">多选一</asp:ListItem>
                            <asp:ListItem Value="5">日期</asp:ListItem>
                            <asp:ListItem Value="3">是非判断</asp:ListItem>
                        </asp:RadioButtonList>
                    </label>
                </li>
            </ol>
            <table style="width: 100%" id="tbljobprocess" cellspacing="1" cellpadding="1">
                <tr>
                    <td style="width: 30%; height: 20px; background-color: #C6E2FF;">
                        可选项目
                    </td>
                    <td style="height: 20px; background-color: #C6E2FF;">
                        操作
                    </td>
                </tr>
                <asp:Literal ID="LtlEnum" runat="server"></asp:Literal>
                <%--<tr>
                    <td>
                        <input class="tbxprocess" type="text" />
                    </td>
                    <td>
                        <img class="add imgBtn" onclick="addRow()" alt="添加一行" src="Image/add.png" />
                        <img class="delete imgBtn" onclick="delRow(this)" alt="删除" src="Image/backto.png" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
    <input id="HidItem" value="" type="hidden" runat="server" />
    <input id="HidMainFlag" value="" type="hidden" runat="server" />
    <input id="HidShow" value="" type="hidden" runat="server" />
    </form>
</body>
</html>
