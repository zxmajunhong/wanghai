<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdRateList.aspx.cs" Inherits="EtNet_Web.Pages.ProductRate.ProdRateList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>险种、人员综合比率</title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 5px 10px 5px;
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
            width: 150px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
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
        .filterInput
        {
            width: 200px;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        .style1
        {
            width: 100%;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">






        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //新增
            $("#addtxt").click(function () {
                window.location = "AddProdRate.aspx";
            })



            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=012&dt=" + new Date().toString(), window.self, strmodal);
            })


        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" value="0" id="hidsift" />
    <input type="hidden" runat="server" id="hidsort" value="" />
    <input type="hidden" runat="server" id="hiditem" value="" />
    <asp:Button ID="btnQuery" Text="" runat="server" Style="display: none;" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        综合比率
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" /><span>页面设置</span></span>
                        <span class="topimgtxt" id="addtxt" title="新增">
                            <img alt="新增" title="新增" src="../../Images/public/pagedit.png" />&nbsp;<span>新增</span>
                        </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div id="depart" style="height: 25px; padding-bottom: 5px; width: 100%">
        <table>
            <tr>
                <td class="style1">
                    <span id="biaoti" style="height: 25px; padding-left:500px; font-size: 25px;text-align:center" runat="server">
                        险种、人员综合比率</span>
                </td>
            </tr>
        </table>
    </div>
    <div class="clsbottom">
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top;">
                    <table class="clsdata" cellspacing="1" cellpadding="0">
                        <tr>
                            <th class="clstitleimg" style="width: 5%;">
                                序号
                            </th>
                            <th class="clstitleimg" style="width: 30%;">
                                险种名称
                            </th>
                            <th class="clstitleimg" style="width: 30%;">
                                人员名称
                            </th>
                            <th class="clstitleimg" style="width: 30%;">
                                综合比率
                            </th>
                            <th class="clstitleimg">
                                操作
                            </th>
                        </tr>
                        <tbody>
                            <asp:Repeater runat="server" ID="ratelist" OnItemCommand="ratelist_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex +1%>
                                        </td>
                                        <td>
                                            <%# Eval("prodname") %>
                                        </td>
                                        <td>
                                            <%# Eval("username") %>
                                        </td>
                                        <td>
                                            <%# rateshow(Eval("rate").ToString()) %>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="edit" title="编辑" AlternateText="编辑" runat="server" CommandName="Update"
                                                CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/edit.gif" />
                                            <%--     <asp:ImageButton ID="ImageButton5" title="复制" AlternateText="复制" Visible='<%# IsSelf(Eval("madefrom")) %>'
                                                runat="server" CommandName="Copy" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/page_copy.png" />--%>
                                            <asp:ImageButton ID="delete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id") %>'
                                                ImageUrl="~/Images/public/delete.gif" title="删除" AlternateText="删除" OnClientClick="return window.confirm('确认删除吗?');" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            
                        </tbody>
                    </table>
                    <div runat="server" id="pages">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:ImageButton ID="imgbtnadd" CssClass="topbtnimg" runat="server" ImageUrl="../../Images/public/layoutedit.png" />
    </div>
    </form>
</body>
</html>
