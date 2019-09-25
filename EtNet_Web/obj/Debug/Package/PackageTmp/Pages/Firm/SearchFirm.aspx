<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchFirm.aspx.cs" Inherits="Pages.Firm.SearchFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询公司</title>
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsunderline
        {
            width: 180px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .clsdata
        {
            width: 100%;
            border: 1px solid #4CB0D5;
        }
        .clsbtn
        {
            background-image: url('../../Images/public/btn.png');
            width: 80px;
            border: 1px solid #BCBCBC;
            margin-left: 10px;
            margin-right: 10px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidselfirm" runat="server" />
    <input type="hidden" id="hidtxtfirm" runat="server" />
    <div class="clstop">
        <div style="background-image: url('../../Images/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        公司显示
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <!-- 隐藏查询栏 -->
        <table class="clsdata" cellpadding="1" cellspacing="0">
            <tr style="display: none;">
                <td style="width: 60px; text-align: right">
                    中文地址:
                </td>
                <td style="width: 210px;">
                    <input runat="server" type="text" id="iptaddress" class="clsunderline" />
                </td>
                <td style="width: 60px; text-align: right">
                    全称:
                </td>
                <td style="width: 200px;">
                    <input runat="server" type="text" id="iptcname" class="clsunderline" />
                </td>
                <td>
                </td>
            </tr>
            <tr style="display: none;">
                <td colspan="4" align="right" style="padding-right: 20px; padding-top: 5px;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="padding-left: 40px;">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <asp:ListBox ID="listleft" SelectionMode="Multiple" runat="server" Width="180" Height="240">
                                    </asp:ListBox>
                                </td>
                                <td style="width: 60px">
                                    <asp:Button runat="server" ID="addbtn" Text="添加—>" CssClass="clsbtn" OnClick="addbtn_Click" />
                                    <asp:Button runat="server" ID="delbtn" Text="删除<—" CssClass="clsbtn" OnClick="delbtn_Click" />
                                    <asp:Button runat="server" ID="addallbtn" Text="全部添加" CssClass="clsbtn" OnClick="addallbtn_Click" />
                                    <asp:Button runat="server" ID="selallbtn" Text="全部删除" CssClass="clsbtn" OnClick="selallbtn_Click" />
                                </td>
                                <td>
                                    <asp:ListBox ID="listright" SelectionMode="Multiple" runat="server" Width="180" Height="240">
                                    </asp:ListBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
