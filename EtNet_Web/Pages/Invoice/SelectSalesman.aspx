<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectSalesman.aspx.cs"
    Inherits="EtNet_Web.Pages.Invoice.SelectSalesman" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Product/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <script src="../Product/artDialog.js" type="text/javascript"></script>
    <script src="../Product/iframeTools.js" type="text/javascript"></script>
    <link href="css/zTreeStyle/demo.css" rel="stylesheet" type="text/css" />
    <link href="css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        var setting = {
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onClick: zTreeOnClick,
                beforeClick: beforeClick
            },
            view: {
                selectedMulti: false
            },
            check: {
                enable: true,
                chkStyle: "radio"
            },
            treeNodeKey: "id",
            treeNodeParentKey: "pId",
            nameCol: "name",
            showLine: true

        };

        zNodes = [<%= NodesData %>] ;


        $(document).ready(function () {
            $.fn.zTree.init($('#ztree'), setting, zNodes);
        });


        function zTreeOnClick(event, treeId, treeNode) {
            $('#HidId').val(treeNode.id);
            $('#HidName').val(treeNode.name);
            $('#HidDpId').val(treeNode.getParentNode().id);
            $('#HidDpName').val(treeNode.getParentNode().name);
        }

        function beforeClick(treeId, treeNode, clickFlag) {
            return (treeNode.getParentNode() != null);
        }

        function Save() {
            if ($('#HidId').val() == "") {
                alert("请选择业务员");
                return;
            }
            var origin = artDialog.open.origin;
            var name = origin.document.getElementById('TxtSalesman');
            var id = origin.document.getElementById('HidSalesman');
            var dpName=origin.document.getElementById('txtDepart');
            name.value = $('#HidName').val();
            id.value = $('#HidId').val();
            dpName.value=$("#HidDpName").val();
            art.dialog.close();
        }

        function Cancel() {
            art.dialog.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul id="ztree" class="ztree">
        </ul>
        <div style="margin-left: 150px">
            <a href="javascript:void('0');" onclick="Save()" title="保存返回">
                <img alt="确定" src="../../Images/Button/btn_sure.jpg" /></a> <a href="javascript:void('0');"
                    onclick="Cancel()" title="取消返回">
                    <img alt="取消" src="../../Images/Button/btn_cancel.jpg" /></a>
        </div>
    </div>
    <input id="HidId" type="hidden" />
    <input id="HidName" type="hidden" />
    <input id="HidDpId" type="hidden" />
    <input id="HidDpName" type="hidden" />
    </form>
</body>
</html>
