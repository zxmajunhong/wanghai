<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectSalesman.aspx.cs"
    Inherits="EtNet_Web.Pages.Policy.SelectSalesman" %>

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
                beforeClick: beforeClick,
                beforeCheck: beforeCheck,
                onCheck: onCheck
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
        debugger;
            $('#HidId').val(treeNode.id);
            $('#HidName').val(treeNode.name);
            var node = treeNode.getParentNode();
            $('#HidDepartName').val(node.name);
            var treeObj = $.fn.zTree.getZTreeObj("ztree");
            treeObj.checkNode(treeNode, true, true);
        }

        function beforeClick(treeId, treeNode, clickFlag) {
            return (treeNode.getParentNode() != null);
        }

        function beforeCheck(treeId, treeNode) {
            var treeObj = $.fn.zTree.getZTreeObj("ztree");
            treeObj.selectNode(treeNode);
        }
        function onCheck(e, treeId, treeNode) {
        debugger;
            $('#HidId').val(treeNode.id);
            $('#HidName').val(treeNode.name);
            var node = treeNode.getParentNode();
            $('#HidDepartName').val(node.name);
        }


        function Save() {
        debugger;
            if ($('#HidId').val() == "") {
                alert("请选择业务员");
                return;
            }
            var origin = artDialog.open.origin;

            var departid = document.getElementById('hiddepartid').value;
            var salemanid = origin.document.getElementById('hidsaleman').value;

            var user = origin.document.getElementById(salemanid);
            var depart = origin.document.getElementById(departid);
            user.value = $('#HidName').val();
            depart.value = $('#HidDepartName').val();
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
    <input id="HidDepartName" type="hidden" />
    <input id="hiddepartid" type="hidden" runat="server" /> <%--传递过来的部门单元格id值--%>
    </form>
</body>
</html>
