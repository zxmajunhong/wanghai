<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowFirm.aspx.cs" Inherits="Pages.Firm.ShowFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司列表</title>
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
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {


            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //新增
            $("#addtxt").click(function () {
                window.location = "AddFirm.aspx";
            })

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=180px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=201&dt=" + new Date().toString(), window.self, strmodal);
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
        })
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input runat="server" type="hidden" value="0" id="hidsift" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        公司资料
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" />
                            <span>页面编辑</span> </span><span class="topimgtxt" id="addtxt" title="新增">
                                <img alt="新增" title="新增" src="../../Images/public/pagedit.png" />
                                <span>新增</span> </span><span class="topimgtxt" id="sifttxt" title="筛选">
                                    <img src="" alt="筛选" title="筛选" />
                                    <span>筛选</span> </span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="background: #4CB0D5; height: 5px;">
    </div>
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td style="width: 80px;">
                    公司全称:
                </td>
                <td style="width: 400px;">
                    <input type="text" runat="server" id="iptcname" class="clsunderline" />
                </td>
                <td style="width: 80px;">
                    公司地址:
                </td>
                <td>
                    <input type="text" runat="server" id="iptcadr" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="imgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="imgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <tr>
                <th class="clstitleimg">
                    公司代码
                </th>
                <th class="clstitleimg">
                    公司全称
                </th>
                <th class="clstitleimg">
                    中文地址
                </th>
                <th class="clstitleimg">
                    电话号码
                </th>
                <th class="clstitleimg">
                    传真号码
                </th>
                <th class="clstitleimg">
                    公司网址
                </th>
                <th class="clstitleimg">
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rptfirm" OnItemCommand="rptfirm_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("firmcode") %>
                        </td>
                        <td>
                            <%# Eval("cname") %>
                        </td>
                        <td>
                            <%# Eval("caddress") %>
                        </td>
                        <td>
                            <%# Eval("telephone") %>
                        </td>
                        <td>
                            <%# Eval("fax") %>
                        </td>
                        <td>
                            <a href='<%# "http://" + Eval("website").ToString() %> ' target="_blank">
                                <%# Eval("website") %>
                            </a>
                        </td>
                        <td>
                            <asp:ImageButton runat="server" title="查看用户" CommandName="searchuser" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/Public/group.gif"/>
                            <asp:ImageButton runat="server" title="编辑" CommandName="edit" AlternateText="编辑"
                                CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/edit.gif" />
                            <asp:ImageButton runat="server" CommandName="search" title="详细" AlternateText="详细"
                                CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/searchform.png" />
                            <asp:ImageButton runat="server" CommandName="del" AlternateText="删除" title="删除" OnClientClick=" return confirm('确定删除!');"
                                CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/delete.gif" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div runat="server" id="pages">
    </div>
    </form>
</body>
</html>
