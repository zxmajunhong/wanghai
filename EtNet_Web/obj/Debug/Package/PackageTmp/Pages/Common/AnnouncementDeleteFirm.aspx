<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnouncementDeleteFirm.aspx.cs" Inherits="EtNet_Web.Pages.Common.AnnouncementDeleteFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>页面设置</title>
    <base target="_self" />
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <link href="../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clstop
        {
            margin: 5px 10px 0px 10px;
        }
        .clsbottom
        {
            margin: 0px 10px 0px 10px;
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata2
        {
            width: 100%;
            border: 1px solid #CDC9C9;
        }
        .clsunderline
        {
            width: 100px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        hr
        {
            color: #4CB0D5;
            background-color: #4CB0D5;
            border: 0;
            height: 1px;
        }
        .clsdata
        {
            border-collapse: collapse;
            width: 100%;
        }
        .clsdata tr
        {
            background-color: #FFFFFF;
        }
        .clsdata th
        {
            border: 1px solid #DED6DC;
        }
        .clsdata tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
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
        .clsdata tr.hover td
        {
            background-color: #FFEFBB;
            cursor: pointer;
        }
        .clsdata tr.selected td
        {
            background-color: #FFECB5;
        }
        tr.odd td
        {
            background-color: #E3EBEF;
        }
    </style>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        window.onunload = function () {
            var dia = window.dialogArguments;
            dia.location = dia.location.href;
            window.close();
        }

        $(document).ready(function () {
            $('.clsdata tbody tr').each(function () {
                $(this).hover(function () {
                    $(this).toggleClass('hover');
                });
                $(this).click(function () {
                    $(this).addClass('selected').siblings().removeClass('selected').end()
                    .find(':radio').attr('checked', 'checked');
                    $(this).siblings().find(':radio').removeAttr('checked');
                });
            });
            $(".clsdata tbody>tr:odd").addClass("odd");
        });

        $(document).ready(function () {
            $('.choose').each(function () {
                $(this).click(function () {
                    var origin = artDialog.open.origin;

                    var cusid = origin.document.getElementById('HidTypeID');
                    var cusname = origin.document.getElementById('TxtType');

                    cusid.value = $.trim($(this).parent().parent().find('.comtypeid').html());
                    cusname.value = $.trim($(this).parent().parent().find('.typename').html());
                    art.dialog.close();
                });
            });
        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <span style="color: White; font-size: 12px; font-weight: bold; position: relative;
                top: 5px; left: 5px;">新增类别</span>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <!--版本：20130312-->
    <div class="clsbottom">
        
        <table class="clsdata">
            <asp:Repeater ID="type" runat="server" OnItemCommand="type_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td class="typename" style="width: 250px">
                            <%#Eval("typename") %>
                        </td>
                        
                        <td style="width: 250px">
                            <asp:LinkButton ID="delete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id") %>'
                                OnClientClick="return window.confirm('确认删除吗?')">删除</asp:LinkButton>
                        </td>
                        <td style="display: none" class="custypeid">
                            <%# Eval("id")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <!--旧版代码 版本：20130306-->
    <%-- <div class="clsbottom">
        <div style="float: right; margin-bottom: 5px;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="../../Images/Button/btn_add.jpg"
                OnClick="imgbtnsave_Click" />
        </div>
        <table class="clsdata">
            <tr>
                <td>
                    类别名称:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxTypeName"></asp:TextBox><span
                        style="color: Red;">*</span>
                </td>
                <td>
                    类别注释:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxTypeRemark"></asp:TextBox>
                </td>
                <td>
                </td>
                <td style="display: none">
                    id
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <hr />
                </td>
            </tr>
            <asp:Repeater ID="type" runat="server" OnItemCommand="type_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td class="typename">
                            <%#Eval("TypeName") %>
                        </td>
                        <td>
                        </td>
                        <td>
                            <%#Eval("TypeRemark") %>
                        </td>
                        <td>
                            <a href="javascript:void(0);" class="choose">选择</a>
                            <asp:LinkButton ID="delete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id") %>'
                                OnClientClick="return window.confirm('确认删除吗?')">删除</asp:LinkButton>
                        </td>
                        <td style="display: none" class="comtypeid">
                            <%# Eval("id")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <span style="color: Red">在使用中的类别不能删除</span>
    </div>--%>
    </form>
</body>
</html>
