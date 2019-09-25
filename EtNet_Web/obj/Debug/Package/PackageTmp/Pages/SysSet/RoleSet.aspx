<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleSet.aspx.cs" Inherits="Pages.SysSet.RoleSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>角色管理</title>
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata
        {
            width: 100%;
            background-color: #B9D3EE;
        }
        .clsdata tr td
        {
            background-color: White;
            height: 30px;
            text-align: center;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .clstitleimg:hover
        {
            color: Black;
        }
        .topbtnimg
        {
            width: 0px;
            height: 0px;
        }
        .topimgtxt
        {
            font-size: 12px;
            font-weight: bold;
            color: #718ABE;
            cursor: pointer;
            display: inline-block;
            margin-top: 4px;
            margin-right: 6px;
        }
        .topimgtxt img
        {
            height: 14px;
            width: 14px;
            margin-right: -6px;
            margin-bottom: -2px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        a
        {
            text-decoration: none;
        }
        img
        {
            border: none;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


            //添加角色
            $("#addtxt").click(function () {
                window.location = "AddRole.aspx";
            })


        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        角色管理
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="addtxt" title="新增角色">
                            <img alt="新增" titie="新增角色" src="../../Images/public/pagedit.png" />
                            <span>新增角色</span> </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <thead>
                <tr>
                    <th class="clstitleimg" style="width: 200px;">
                        名称
                    </th>
                    <th class="clstitleimg">
                        备注
                    </th>
                    <th class="clstitleimg" style="width: 100px;">
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="roleInfo" runat="server" OnItemCommand="roleInfo_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("rolenname") %>
                            </td>
                            <td>
                                <%# Eval("Remark") %>
                            </td>
                            <td>
                                <a title="用户列表" href='<%# "RoleUsers.aspx?roleid="+Eval("roleid") %>'>
                                    <img alt="用户列表" width="16px" height="16px" src="../../Images/public/group.gif" />
                                </a>
                                <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("roleid") %>'
                                    ImageUrl="../../Images/public/edit.gif" alt="编辑" title="编辑"></asp:ImageButton>
                                <asp:ImageButton ID="ibtnDelete" runat="server" OnClientClick="return window.confirm('确认删除吗?')"
                                    CommandName="Delete" CommandArgument='<%# Eval("roleid") %>' ImageUrl="../../Images/public/delete.gif"
                                    alt="删除" title="删除"></asp:ImageButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <div id="pages" runat="server" visible="true">
    </div>
    </form>
</body>
</html>
