<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSet.aspx.cs" Inherits="Pages.SysSet.LoginSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户</title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
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
        .clsdata td.clstitleimg
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
            margin-right: 0px;
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
        .clssift
        {
            width: 100%;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行


            //添加用户
            $("#addtxt").click(function () {
                window.location = "AddLoginUser.aspx";
            })

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=027&dt=" + new Date().toString(), window.self, strmodal);
            })
            //按照条件判断是否显示筛选栏
            function fist() {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();


            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");
                }
                else {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }

            })
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" value="0" id="hidsift" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        用户管理
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" /><span>页面设置</span></span>
                        <span class="topimgtxt" id="addtxt" title="新增用户">
                            <img style="margin-right: -6px;" alt="新增" title="新增用户" src="../../Images/public/pagedit.png" />
                            <span>新增用户</span> </span><span class="topimgtxt" id="sifttxt" title="筛选">
                                <img alt="筛选" title="筛选" src="../../Images/public/collapse.gif" />&nbsp;<span>筛选</span>
                            </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td style="width: 80px; text-align: right;">
                    &nbsp;登录账号：
                </td>
                <td>
                    <input type="text" runat="server" id="Txtdlzh" class="clsunderline" />
                </td>
                <td style="width: 70px; text-align: right;">
                    姓名：
                </td>
                <td>
                    <input type="text" runat="server" id="Txtxm" class="clsunderline" />
                </td>
                <td style="width: 70px; text-align: right;">
                    所属部门：
                </td>
                <td>
                    <input type="text" runat="server" id="Txtssbm" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    &nbsp;所在岗位：
                </td>
                <td colspan="5">
                    <input type="text" runat="server" id="Txtszgw" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td colspan="10" style="text-align: right; padding-right: 20px;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click1" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <thead>
                <tr>
                    <td class="clstitleimg">
                        登录帐号
                    </td>
                    <td class="clstitleimg">
                        姓名
                    </td>
                    <td class="clstitleimg">
                        所属部门
                    </td>
                    <td class="clstitleimg">
                        号码
                    </td>
                    <td class="clstitleimg">
                        Email
                    </td>
                    <td class="clstitleimg">
                        所在岗位
                    </td>
                    <td class="clstitleimg">
                        权限分配
                    </td>
                    <td class="clstitleimg" style="width: 60px;">
                        操作
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rploginUser" runat="server" OnItemCommand="rploginUser_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("loginid") %>
                            </td>
                            <td>
                                <%# Eval("cname") %>
                            </td>
                            <td>
                                <%# ShowDepart(Eval("departid").ToString()) %>
                            </td>
                            <td>
                                <%# Eval("tel") %>
                            </td>
                            <td>
                                <%# Eval("Email") %>
                            </td>
                            <td>
                                <%# ShowPostname(Eval("postid").ToString())%>
                            </td>
                            <td>
                                <asp:LinkButton ID="limitTo" CommandName="Limit" CommandArgument='<%#Eval("id") %>'
                                    runat="server">权限分配</asp:LinkButton>
                            </td>
                            <td>
                                <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("id") %>'
                                    ImageUrl="../../Images/public/edit.gif" alt="编辑" title="编辑"></asp:ImageButton>
                                <asp:ImageButton ID="ibtnDelete" runat="server" OnClientClick="return window.confirm('确认删除吗?')"
                                    CommandName="Delete" CommandArgument='<%# Eval("id") %>' ImageUrl="../../Images/public/delete.gif"
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
