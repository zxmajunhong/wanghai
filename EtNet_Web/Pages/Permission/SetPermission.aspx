<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetPermission.aspx.cs"
    Inherits="EtNet_Web.Pages.Permission.SetPermission" %>

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
            padding: 0px 0px 30px 0px;
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
        #left
        {
            margin-left: 20px;
            float: left;
        }
        #right
        {
            margin-right: 20px;
            float: left;
            width: 400px;
            margin-left:20px;
        }
        a img
        {
            border: none;
        }
        #user-info{margin:0px 0px 10px 0px;height:30px;line-height:30px;width:100%;background:#F5F5F5;font-size:12px;color:#333333;border-bottom:1px solid #D4D4D4;}
    </style>
    <script type="text/javascript">

        var zNodesData = [<%= NodesData %>] ;
        var zNodesMenu = [<%= NodesMenu %>] ;

        var setting1 = {
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

        var setting2 = {
            data: {
                simpleData: {
                    enable: true
                }
            },
            check: {
                enable: true
            },
            callback: {
                onCheck: zTreeOnCheck
            },
            view: {
                selectedMulti: true
            },
            treeNodeKey: "id",
            treeNodeParentKey: "pId",
            nameCol: "name",
            showLine: true

        };

        function zTreeOnCheck(event, treeId, treeNode) {
            $("#DdlRoleList option[value='0']").attr("selected", "selected").siblings().removeAttr("selected");
            //$("#HidBtn").click();
        };

        $(document).ready(function () {
            $.fn.zTree.init($('#ztreeData'), setting1, zNodesData);
            $.fn.zTree.init($('#ztreeMenu'), setting2, zNodesMenu);
        });


        function ReadySubmit() {
            var treeData = $.fn.zTree.getZTreeObj("ztreeData");
            var treeMenu = $.fn.zTree.getZTreeObj("ztreeMenu");
            var nodesData = treeData.getCheckedNodes(true);
            var nodesMenu = treeMenu.getCheckedNodes(true);
            var noMenu = treeMenu.getCheckedNodes(false);

            var menus = "[";
            for (var i = 0; i < nodesMenu.length; i++) {
                menus += '"' + "{id:" + nodesMenu[i].id + ",name:" + "'" + nodesMenu[i].name + "'" + ",isParent:" + "'" + nodesMenu[i].isParent + "'" + "}" + '"';
                if (i < nodesMenu.length - 1) {
                    menus += ",";
                }
            }
            menus += "]";

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
                if (!nodesData[i].isParent) {
                    datas += '"' + "{id:" + nodesData[i].id + ",name:" + "'" + nodesData[i].name + "'" + ",isParent:" + "'" + nodesData[i].isParent + "'" + "}" + '"';
                    if (i < nodesData.length - 1) {
                        datas += ",";
                    }
                }
            }
            datas += "]";
            $('#HidData').val(datas);
            $('#HidMenu').val(menus);
            $('#HidNoMenu').val(nomenus);
            return true;
        }
        function CheckTree(obj,flag) {
            var treeObj = $.fn.zTree.getZTreeObj(obj);
            if (treeObj.getCheckedNodes(false).length > 0) {
                treeObj.checkAllNodes(true);
            } else {
                treeObj.checkAllNodes(false)
            }
            if(flag==1){
                $("#DdlRoleList option[value='0']").attr("selected", "selected").siblings().removeAttr("selected");
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
                    ImageUrl="../../Images/Button/btn_save.jpg" OnClick="BtnSave_Click" /><a href="../SysSet/LoginSet.aspx"
                        title="返回列表" id="back" style="text-decoration: none">
                        <img alt="返回" src="../../Images/Button/btn_back.jpg" /></a> </span>
    </div>
    <div class="border" id="slider">
        <div id="user-info">
            <span style="padding-left:20px;">当前正在为用户：<asp:Literal ID="ltrUserInfo" runat="server"></asp:Literal>&nbsp分配权限</span>
        </div>
        <div id="left">
            <h3>
                数据查看权限<a style="float: right; margin-right: 5px; color: #2ea0dc;" href="javascript:void('0');"
                    onclick="CheckTree('ztreeData',0)">全选/全不选</a></h3>
            <div class="box_r">
                <ul id="ztreeData" class="ztree">
                </ul>
            </div>
            <div class="box-bottom">
                <i class="lb"></i><i class="rb"></i>
            </div>
        </div>
        <div id="right">
            <h3 style="">
                功能操作权限<a style="float: right; margin-right: 5px; color: #2ea0dc;" href="javascript:void('0');"
                    onclick="CheckTree('ztreeMenu',1)">全选/全不选</a></h3>
            <div class="box_r">
            <span style="clear:both"></span>
            <span style="display: block; height: 20px;"><span style="float: left; height: 20px;
                line-height: 20px;">角色组选择:</span> <span style="float: right; width: 300px; height: 20px;
                    line-height: 20px;">
                    <asp:DropDownList Width="100%" ID="DdlRoleList" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="DdlRoleList_SelectedIndexChanged">
                    </asp:DropDownList>
                </span></span>
                <ul id="ztreeMenu" class="ztree">
                </ul>
            </div>
            <div class="box-bottom">
                <i class="lb"></i><i class="rb"></i>
            </div>
        </div>
    </div>
    <input id="HidData" runat="server" type="hidden" />
    <input id="HidMenu" runat="server" type="hidden" />
    <input id="HidNoMenu" runat="server" type="hidden" />
    </form>
</body>
</html>
