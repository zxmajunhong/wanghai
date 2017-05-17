<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAuditRole.aspx.cs"
    Inherits="Pages.SysSet.AuditRole.SearchAuditRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询审批流程</title>
    <link href="../../../CSS/page.css" rel="stylesheet" type="text/css" />
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
        .clsdatalist
        {
            width: 200px;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
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
        .clsfilehide
        {
            display: none;
        }
        .datebox
        {
            border: 0;
        }
        .combo-text
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //删除
            $(".imgdel").click(function () {
                if (confirm("确定删除吗！")) {
                    return true;
                }
                else {
                    return false;
                }
            });


            $("#addtxt").click(function () {
                window.location = "AddAuditRole.aspx";

            })

            $("#iptrolename").blur(function () {
                var rg = /[^\u4e00-\u9fa5\w]/g;
                var str = "";
                if ($(this).val() && rg.test($(this).val())) {
                    str += "流程名称只能由中文字母与数字!";
                    $(this).val("");
                }
                if (str) {
                    alert(str);
                }

            });




            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";

                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=028&dt=" + new Date().toString(), window.self, strmodal);
            })






            //数据导出
            $("#datago").click(function () {
                window.document.getElementById("imgbtndata").click();

            })


            //按照条件判断是否显示筛选栏
            function fist() {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../../Images/public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", "  ../../../Images/public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();


            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../../Images/public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");

                }
                else {
                    $("#sifttxt img").attr("src", "../../../Images/public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }
            })
        })
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidsift" value="0" runat="server" />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        审批流程管理
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../../Images/public/layoutedit.png" />
                            <span>页面设置</span> </span><span class="topimgtxt" id="addtxt" title="新增">
                                <img alt="新增" title="新增" src="../../../Images/public/pagedit.png" />
                                <span>新增流程</span> </span><span class="topimgtxt" id="sifttxt" title="筛选">
                                    <img alt="筛选" title="筛选" />
                                    <span>筛选</span> </span>
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
                <td style="width: 80px;">
                    流程名称
                </td>
                <td style="width: 220px;">
                    <input type="text" id="iptrolename" class="clsunderline" runat="server" />
                </td>
                <td style="width: 80px;">
                    审核类型
                </td>
                <td style="width: 220px;">
                    <select id="selauditsort" runat="server" class="clsdatalist">
                        <option selected="selected" value="0">——请选中——</option>
                        <option value="单审">单审</option>
                        <option value="会签">会签</option>
                        <option value="选审">选审</option>
                    </select>
                </td>
                <td style="width: 100px;">
                    所属工作流类型
                </td>
                <td>
                    <select id="seljobflowsort" runat="server" class="clsdatalist">
                    </select>
                </td>
            </tr>
            <tr>
             <td style=" width:60px;">是否可见:</td>
           <td>
             <asp:DropDownList runat="server" ID="ddlhide" CssClass="clsdatalist">
              <asp:ListItem Value="-1">——请选中——</asp:ListItem>
              <asp:ListItem Value="2">不可见</asp:ListItem>
              <asp:ListItem Value="1">可见</asp:ListItem>
             </asp:DropDownList>
           </td>
                <td colspan="4" align="right">
                    <asp:ImageButton ID="ibtnsearch" runat="server" ImageUrl="../../../Images/Button/btn_search.jpg"
                        OnClick="ibtnsearch_Click" />
                    <asp:ImageButton ID="ibtnreset" runat="server" ImageUrl="../../../Images/Button/btn_reset.jpg"
                        OnClick="ibtnreset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <thead>
                <tr>
                    <th class="clstitleimg" style="width: 200px;">
                        名称
                    </th>
                    <th class="clstitleimg" style="width: 100px;">
                        审核类型
                    </th>
                    <th class="clstitleimg" style="width: 150px;">
                        所属工作流类型
                    </th>
                    <th class="clstitleimg">
                        描述
                    </th>
                    <th class="clstitleimg" style="width: 100px;">
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptauditrole" runat="server" OnItemCommand="rptauditrole_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("cname")%>
                            </td>
                            <td>
                                <%# Eval("sort") %>
                            </td>
                            <td>
                                <%# Eval("jobsorttxt")%>
                            </td>
                            <td>
                                <%# CommonlyUsed.Conversion.StrConversion(Eval("txt").ToString()) %>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgbtneedit" CommandName="edit" title="编辑" CommandArgument='<%# Eval("id") %>'
                                    runat="server" ImageUrl="~/Images/public/edit.gif" />
                                <asp:ImageButton ID="imghide" runat="server" title="隐藏或显示" CommandName="hide"
                                    CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/hiddenrow.png" />
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("id") %>'
                                    title="详情" CommandName="search" ImageUrl="~/Images/public/searchform.png" />
                                <asp:ImageButton ID="imgbtndel" CssClass="imgdel" CommandName="del" title="删除" CommandArgument='<%# Eval("id") %>'
                                    runat="server" ImageUrl="~/Images/public/delete.gif" AlternateText="删除" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="pages" runat="server">
        </div>
    </div>
    <!-- 功能按钮 -->
    <div>
        <asp:ImageButton runat="server" CssClass=" topbtnimg" ID="imgbtndata" ImageUrl="~/Images/public/tablesave.png"
            OnClick="imgbtndata_Click" />
    </div>
    </form>
</body>
</html>
