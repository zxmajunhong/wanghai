<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChearTable.aspx.cs" Inherits="EtNet_Web.CMS.Manager.ChearTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/common.css" type="text/css" />
    <style type="text/css">
        .clsbtntxt
        {
            width: 80px;
            height: 20px;
            line-height: 20px;
            cursor: pointer;
            float: right;
            background: url('../../Images/public/btn.png');
            margin-right: 5px;
            text-align: center;
            font-weight: bold;
            color: black;
            border: 1px solid #4CB0D5;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //全选或全部选
            $("#btnchkdel").click(function () {
                if ($(".clschkb :checkbox").length == $(".clschkb :checked").length) {
                    $(".clschkb :checkbox").removeAttr("checked");
                }
                else {
                    $(".clschkb :checkbox").attr("checked", "checked");
                }
            })


            $("#btnalldel").click(function () {
                if ($(".clschkb :checked").length == 0) {
                    alert('未选中清空项');
                }
                else {
                    if (confirm('确定清空选中项?\n清空后数据将不能恢复!')) {
                        $("#ibtnDeleteAll").click();
                    }
                }
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="man_zone">
        <table width="99%" border="0" align="center" cellpadding="3" cellspacing="1" class="table_style">
            <tr>
                <td style="height: 20px;">
                </td>
            </tr>
            <tr>
                <td width="100%" class="left_title_1">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbLinkInfo" runat="server" Text="通 讯 录" />
                            </td>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbAnnouncement" runat="server" Text="公告管理" />
                            </td>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbReimbursed" runat="server" Text="报销管理" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbCalendar" runat="server" Text="日程管理" />
                            </td>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbInfomation" runat="server" Text="消息管理" />
                            </td>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbPicture" runat="server" Text="图片管理" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbCompany" Text="付款单位" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbCustomer" Text="收款单位" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbPolicy" Text="订单管理" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbInvocie" Text="发票管理" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox CssClass="clschkb" ID="cbFinancial" Text="收款管理" runat="server" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="" align="right">
                    <div id="btnalldel" class="clsbtntxt">
                        清空选中项</div>
                    <div id="btnchkdel" class="clsbtntxt" title="全部选中时点击将取消所有选中项">
                        全选/全不选</div>
                    <asp:ImageButton ID="ibtnDeleteAll" Style="display: none;" runat="server" CommandName="DeleteAll"
                        Font-Size="12px" ImageUrl="../../Images/public/delete.gif" alt="清空" OnClick="ibtnDeleteAll_Click"
                        Width="16px"></asp:ImageButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
