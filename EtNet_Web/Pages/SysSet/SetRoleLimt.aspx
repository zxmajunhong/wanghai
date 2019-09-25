<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetRoleLimt.aspx.cs" Inherits="Pages.SysSet.SetRoleLimt" %>
<%@ Register Src="RoleLimit.ascx" TagName="RoleLimit" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../CSS/common.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script language="javascript" type="text/javascript">
        function CheckAll(paramId) {
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length; i++) {
                var e = items[i];
                var eId = e.id; //获得当前控件元素的Id
                var m = eId.indexOf('_chk');
                var n = paramId.indexOf('_chk');
                //判断控件类型是否是checkbox,父子节点Id是否匹配,以控制只选中该父节点对应的子节点	
                if (eId.substring(0, m) == paramId.substring(0, n) && e.type == 'checkbox') {
                    e.checked = document.getElementById(paramId).checked;
                }
            }
        }
        function CheckOnly(paramId) {
            var items = document.getElementsByTagName("input");
            for (i = 0; i < items.length; i++) {
                var e = items[i];
                var eId = e.id;
                var m = eId.indexOf('_chk');
                var n = paramId.indexOf('_chk');
                //判断控件类型是否是checkbox,父子节点Id是否匹配,以控制只选中该子节点对应的父节点
                if (eId.substring(0, m) == paramId.substring(0, n) && e.type == 'checkbox') {
                    if (eId.indexOf('chkParentMenu') != -1) { document.getElementById(eId).checked = true; }
                }
            }
        }       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%;">
            <tr>
                <td style="text-align: center" colspan="3">
                    <strong><span style="font-size: large">角 色 权 限 分 配</span></strong>
                    <br />
                    <hr style="border: 1px solid #c6d5e1;"/>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:PlaceHolder ID="phRoleDistribute" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td>
                    当前角色：
                    <asp:Label ID="lblCurrentRole" runat="server" Font-Bold="True" Width="125px"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="ibtnSubmit" runat="server" 
                        ImageUrl="../../Images/Button/btn_save.jpg" onclick="ibtnSubmit_Click" />
                   <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="../../Images/Button/btn_back.jpg" 
                        onclick="ibtnBack_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
