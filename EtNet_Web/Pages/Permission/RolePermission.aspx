<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolePermission.aspx.cs"
    Inherits="EtNet_Web.Pages.Permission.RolePremission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Product/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <link href="css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 30px 0px;
            overflow: auto;
            min-width: 880px;
            width: expression_r(document.body.clientWidth > 880? "880px": "auto" );
        }
        .titlebtncls
        {
            position: absolute;
            right: 40px;
            font-size: 12px;
            font-weight: bold;
            margin-right: 10px;
            color: #718ABE;
            cursor: pointer;
            text-decoration: none;
        }
        h3
        {
            background: url("images/bg.png") no-repeat rgb(255, 255, 255);
            font-weight: normal;
            padding: 0px 0px 0px 15px;
            height: 27px;
            line-height: 27px;
            color: rgb(57, 57, 57);
            font-size: 12px;
            width: 385px;
            margin: 0px;
        }
        .box_r
        {
            background: #fff;
            padding: 5px 10px 0 12px;
            border-left: 1px solid #ccc;
            border-right: 1px solid #ccc;
            float: left;
            width: 376px;
            margin: 0px;
        }
        .box-bottom
        {
            position: relative;
            background: #fff;
            width: 398px;
            height: 6px;
            margin: 0 0 10px 0;
            border-left: 1px solid rgb(204, 204, 204);
            border-right: 1px solid rgb(204, 204, 204);
            border-bottom: 1px solid rgb(204, 204, 204);
            clear: both;
        }
        a img
        {
            border: none;
        }
    </style>
    <script type="text/javascript">

        var zNodesData = [<%= NodesData %>] ;

        var setting = {
            data: {
                simpleData: {
                    enable: true
                }
            },
            check: {
                enable: true
            },
            view: {
                selectedMulti: true
            },
            treeNodeKey: "id",
            treeNodeParentKey: "pId",
            nameCol: "name",
            showLine: true

        };

        $(document).ready(function () {
            $.fn.zTree.init($('#ztree'), setting, zNodesData);
        });

        function ReadySubmit() {
            var treeData = $.fn.zTree.getZTreeObj("ztree");
            var nodesData = treeData.getCheckedNodes(true);
            var noMenu = treeData.getCheckedNodes(false);

            var nomenus = "[";
            for (var i = 0; i < noMenu.length; i++) {
                nomenus += '"' + "{id:" + noMenu[i].id + ",name:" + "'" + noMenu[i].name + "'" + ",isParent:" + "'" + noMenu[i].isParent + "'" + "}" + '"';
                if (i < noMenu.length - 1) {
                    nomenus += ",";
                }
            }
            nomenus += "]";

            var datas = "[";
            for (var i = 0; i < nodesData.length; i++) {
                datas += '"' + "{id:" + nodesData[i].id + ",name:" + "'" + nodesData[i].name + "'" + ",isParent:" + "'" + nodesData[i].isParent + "'" + "}" + '"';
                if (i < nodesData.length - 1) {
                    datas += ",";
                }
            }
            datas += "]";
            $('#HidMenu').val(datas);
            $('#HidNoMenu').val(nomenus);
            return true;
        }

        //全选/全不选
        function CheckTree(obj) {
            var treeObj = $.fn.zTree.getZTreeObj(obj);
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
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px;">权限设置</span> <span class="titlebtncls">
                <asp:ImageButton ID="BtnSave" OnClientClick="return ReadySubmit();" runat="server"
                    ImageUrl="~/Images/Button/btn_save.jpg" OnClick="BtnSave_Click" />
                <a href="../SysSet/RoleSet.aspx" title="返回列表" id="back">
                    <img alt="返回" src="../../Images/Button/btn_back.jpg" /></a> </span>
    </div>
    <div class="border" id="slider">
    <a style="margin-right:5px;color:#2ea0dc;margin-left:5px;" href="javascript:void('0');" onclick="CheckTree('ztree')">全选/全不选</a>
        <ul id="ztree" class="ztree">
        </ul>
    </div>
    <input id="HidMenu" runat="server" type="hidden" />
    <input id="HidNoMenu" runat="server" type="hidden" />
    </form>
</body>
</html>
