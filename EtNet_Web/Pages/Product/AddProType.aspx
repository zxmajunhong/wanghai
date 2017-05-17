<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProType.aspx.cs" Inherits="EtNet_Web.Pages.Product.AddProType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
        }
        #need
        {
            margin: 0px;
            width: auto;
            width: 330px;
            padding: 0px;
        }
        #need li
        {
            height: 26px;
            width: auto;
            font: 12px/26px Arial, Helvetica, sans-serif;
            background: white;
            border-bottom: 1px dashed #E0E0E0;
            display: block;
            cursor: text;
            padding: 7px 0px 7px 0px !important;
            padding: 5px 0px 5px 0px;
        }
        #need li:hover, #need li.hover
        {
            background: white;
        }
        #need li.txt input
        {
            line-height: 14px;
            background: white;
            height: 14px;
            width: 200px;
            border: 0px solid #E0E0E0;
            vertical-align: middle;
            padding: 6px;
            border-bottom: 1px solid #C6E2FF;
            outline: none;
        }
        #need select
        {
            outline: none;
            width: 200px;
        }
        #need label
        {
            padding-left: 30px;
        }
        #need li.txt #BtnManage
        {
            width: 40px;
            padding: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ol id="need">
            <li class="txt">
                <label class="">
                    上级险种：</label>
                <asp:TextBox ID="txtParent" Enabled="false" runat="server"></asp:TextBox><input id="hidParent"
                    type="hidden" runat="server" /></li>
            <li class="txt">
                <label class="">
                    险种名称：</label><asp:TextBox ID="txtName" runat="server"></asp:TextBox><dfn id="msg"></dfn></li>
            <li class="txt">
                <label class="">
                    险种大类：</label><asp:DropDownList ID="ddlType" runat="server">
                    </asp:DropDownList>
                <asp:ImageButton ID="BtnManage" ToolTip="管理" runat="server" Style="height: 16px;
                    width: 16px; cursor:pointer" ImageUrl="../../Images/public/wrench_orange.png" AlternateText="管理"
                    OnClick="BtnManage_Click" /></li>
            <li class="txt">
                <label class="">
                    标的类别：</label><asp:DropDownList ID="ddlTarget" runat="server">
                    </asp:DropDownList>
            </li>
            <li style="text-align: right; margin-right: 10px">
                <asp:ImageButton ID="btnSave" CssClass="btn" Text="保存" runat="server" OnClick="btnSave_Click"
                    OnClientClick="return CheckProData()" ImageUrl="../../Images/Button/btn_save.jpg" />
            </li>
        </ol>
        <input id="hidId" type="hidden" runat="server" />
    </div>
    <script type="text/javascript">
        function CheckProData() {
            if ($("#txtName").val() == "") {
                $("#msg").html("险种名称为必填项，请填写！").show();
                return false;
            }
            else if ($("#txtName").val().length > 60) {
                $("#msg").html("险种名称为必填项，请填写！").show();
                return false;
            }
            else {
                $("#msg").hide();
                return true;
            }
        }

        function goBack() {
            var origin = artDialog.open.origin;
            var aValue = document.getElementById('hidId').value;
            var result = origin.document.getElementById('hidResult');
            result.value = aValue;
            var btn = origin.document.getElementById('btnType');
            btn.click();
            art.dialog.close();
        }

    </script>
    </form>
</body>
</html>
