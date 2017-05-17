<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleUsers.aspx.cs" Inherits="EtNet_Web.Pages.SysSet.RoleUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
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
            
            margin-right: -6px;
            margin-bottom: 5px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
    </style>
    
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
                        <asp:ImageButton ID="btnBack" runat="server" 
                            ImageUrl="../../Images/Button/btn_back.jpg" onclick="btnBack_Click" />
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
                    
                    <th class="clstitleimg">
                        登录帐号
                    </th>
                    <th class="clstitleimg">
                        姓名
                    </th>
                    <th class="clstitleimg">
                        号码
                    </th>
                    <th class="clstitleimg">
                        Email
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RpUserList" runat="server">
                    <ItemTemplate>
                        <tr>
                           
                            <td>
                                <%# Eval("loginid") %>
                            </td>
                             <td>
                                <%# Eval("cname") %>
                            </td>
                            <td>
                                <%# Eval("tel") %>
                            </td>
                            <td>
                                <%# Eval("Email") %>
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
