<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProTypeClass.aspx.cs" Inherits="EtNet_Web.Pages.Product.ProTypeClass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var $num = $('#txtTypeNum');
            var $name = $('#txtTypeName');
            $('#AddType').click(function () {
                $('#editForm').show();
                $('#HidCmdName').val('ADD');
            });
            $('#EditType').click(function () {
                $name.val($('#ddlProTypeClass option:selected').text());
                $num.val($('#HidNum').val());
                $('#editForm').show();
                $('#HidCmdName').val('MODIFY');
            });
            $('#cancel').click(function () {
                $('#editForm').hide();
                $name.val("");
                $num.val("");
            });
        });

        function confirmDelete() {
            if (window.confirm("确定删除吗")) {
                return true;
            } else {
                return false;
            }
        }

        function CheckProData() {
            if ($.trim($("#txtTypeNum").val()) == "") {
                alert("编号不能为空");
                return false;
            }
            else if ($.trim($("#txtTypeName").val()) == "") {
            alert("名称不能为空");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <style type="text/css">
        body
        {
            font: 12px/26px Arial, Helvetica, sans-serif;
            width: 300px;
        }
        a img
        {
            border: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 30px; margin-right: 50px; line-height: 30px; vertical-align: middle;">
        <div style="float: left; margin-right: 5px;">
            <label>
                标的种类：</label><asp:DropDownList ID="ddlProTypeClass" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlProTypeClass_SelectedIndexChanged">
                </asp:DropDownList>
        </div>
        <div style="clear: both">
        </div>
        <div style="margin-top: 4px; float: left">
            <input id="HidNum" type="hidden" runat="server" />
            <a href="javascript:void(0);" id="AddType">
                <img alt="添加" src="../../Images/Button/btn_addtype.jpg" /></a> <a href="javascript:void(0);" id="EditType">
                    <img alt="修改" src="../../Images/Button/btn_modtype.jpg" /></a>
            <asp:ImageButton ID="BtnDelType" ImageUrl="../../Images/Button/btn_deltype.jpg"
                OnClientClick="return confirmDelete()" runat="server" OnClick="BtnDelType_Click" />
                <a href="AddProType.aspx?hasTemp=0" title="返回"><img alt="返回" src="../../Images/Button/btn_back.jpg" /></a>
        </div>
    </div>
    <div style="clear: both">
    </div>
    <div id="editForm" style="display: none; float: left;">
        <table>
            <tr>
                <td>
                    编号：
                </td>
                <td>
                    <asp:TextBox ID="txtTypeNum" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    名称：
                </td>
                <td>
                    <asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:ImageButton ID="BtnSaveType" ImageUrl="Image/btn_save.jpg" runat="server" OnClientClick="return CheckProData()"
                        OnClick="BtnSaveType_Click" />
                    <a href="javascript:void(0);" id="cancel">
                        <img alt="取消" src="../Policy/Images/btn_cancel.jpg" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="2" id="msg" style="display: none" runat="server">
                </td>
            </tr>
        </table>
    </div>
    <input id="HidCmdName" type="hidden" runat="server" />
    </form>
</body>
</html>
