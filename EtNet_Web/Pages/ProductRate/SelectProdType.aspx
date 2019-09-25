<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectProdType.aspx.cs"
    Inherits="EtNet_Web.Pages.ProductRate.SelectProdType" %>

<%@ Register TagPrefix="yyc" Assembly="YYControls" Namespace="YYControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Customers/main.css" rel="stylesheet" type="text/css" />
    <link href="../Product/default.css" rel="stylesheet" type="text/css" />
    <link href="../Product/common.css" rel="stylesheet" type="text/css" />
    <link href="product.css" rel="Stylesheet" type="text/css" />
    <link href="cuscosky.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Product/artDialog.js" type="text/javascript"></script>
    <script src="../Product/iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Save() {
        debugger;
            if ($('#hidprodname').val() == "" || $('#hidprodId').val() == "") {
                alert('请确认选中险种');
                return
            }
            var origin = artDialog.open.origin;
            var prodname = origin.document.getElementById('txtprod');
            var prodId = origin.document.getElementById('hidprodId');
            prodname.value = $('#hidprodname').val();
            prodId.value = $('#hidprodId').val();

            art.dialog.close();
        }

        function Cancel() {
            art.dialog.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="leftDiv">
        <yyc:SmartTreeView ID="stvProType" runat="server" OnSelectedNodeChanged="stvProType_SelectedNodeChanged"
            ExpandDepth="1" Font-Size="Small" PopulateNodesFromClient="False" Target="_blank"
            BorderColor="White" BorderStyle="None" Width="90%">
            <SelectedNodeStyle BorderStyle="None" BorderWidth="0px" BackColor="#66CCFF" Font-Bold="True" />
        </yyc:SmartTreeView>
    </div>
    <div style="clear: both">
    </div>
    <div style="float: right; margin-right: 50px;">
        <a href="javascript:void(0);" onclick="Save()" id="save">
            <img alt="保存" src="../../Images/Button/btn_sure.jpg" /></a> <a href="javascript:void(0);"
                onclick="Cancel()" id="camcel">
                <img alt="取消" src="../../Images/Button/btn_cancel.jpg" /></a></div>
    <input type="hidden" id="hidprodname" runat="server" />
    <input type="hidden" id="hidprodId" runat="server" />
    </form>
</body>
</html>
