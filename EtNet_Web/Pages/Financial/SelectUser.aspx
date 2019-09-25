<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectUser.aspx.cs" Inherits="EtNet_Web.Pages.Financial.SelectUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Product/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Policy/jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../Policy/css/zTreeStyle/demo.css" rel="stylesheet" type="text/css" />
    <link href="../Policy/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        ul.ztree{margin-top:0px;}
    </style>
    <script type="text/javascript">

        var setting = {
            data: {
                simpleData: {
                    enable: true
                }
            },
            view: {
                selectedMulti: true
            },
            check: {
                enable: true
            },
            treeNodeKey: "id",
            treeNodeParentKey: "pId",
            nameCol: "name",
            showLine: true

        };

        zNodes = [<%= NodesData %>] ;


        $(document).ready(function () {
            $.fn.zTree.init($('#ztree'), setting, zNodes);
            SelectAll();
        });

        function Save() {
            var treeData = $.fn.zTree.getZTreeObj("ztree");
            var selectedList = treeData.getCheckedNodes(true);

            var userNames="";
            var userIDs="";
            for (var i = 0; i < selectedList.length; i++) {
                if(!selectedList[i].isParent){
                    userNames+=selectedList[i].name+"，";
                    userIDs+=selectedList[i].id+",";
                }
            }

            var origin = artDialog.open.origin;
            var name = origin.document.getElementById('userBox');
            var id = origin.document.getElementById('hidUserList');
            name.innerHTML = userNames;
            id.value = userIDs;;
            art.dialog.close();
        }

        function Cancel() {
            art.dialog.close();
        }

        function SelectAll() {
            var treeObj = $.fn.zTree.getZTreeObj("ztree");
            if (treeObj.getCheckedNodes(false).length > 0) {
                treeObj.checkAllNodes(true);
            } else {
                treeObj.checkAllNodes(false)
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-size:12px;padding-left:10px;">
            <a href="javascript:void('0');" style="" onclick="SelectAll()" title="全选/全不选">全选/全不选</a>
        </div>
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
    </form>
</body>
</html>
