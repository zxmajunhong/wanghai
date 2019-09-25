<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditLine.aspx.cs" Inherits="EtNet_Web.Pages.Line.EditLine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加类型</title>
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
            border: 1px solid #CDC9C9;
        }
        .clsunderline
        {
            width: 300px;
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
        
        .style1
        {
            width: 600px;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#ibtnAdd").click(function () {
                var str = "";
                var strtxt = $("#txtlinename").val();
                if ($.trim(strtxt) == "") {
                    str += " 类别名称不能为空";
                }
                if (str) {
                    alert(str);
                    return false;
                }
            })


            //返回时清空数据
            $("#ibtnback").click(function () {
                $("#txtTypeName").val("");

            })



        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/Public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        编辑旅游线路
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="background: #4CB0D5; height: 5px;">
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="ibtnAdd_Click" CommandName="add" />
            <asp:ImageButton ID="ibtnback" runat="server" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="ibtnback_Click" />
        </div>
        <table class="clsdata">
            <tr style="height: 26px;">
                <td  style="width:80px;text-align:right;">
                    线路名称:
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtlinename" runat="server" CssClass="clsunderline" Style="width: 600px"></asp:TextBox><span style="color: Red;">*</span>
                </td>
            </tr>
            <tr style="height: 26px;">
                <td style="text-align:right">
                    线路描述:
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtlineremark" runat="server" CssClass="clsunderline" style="width:600px"></asp:TextBox>
                    <span style="color: Red;">*</span>
                </td>
            </tr>
            <tr style="height: 26px;">
                <td style="text-align:right">
                    自动编码标识符:
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtautocode" runat="server" CssClass="clsunderline" style="width:600px"></asp:TextBox>
                    <span style="color: Red;">*</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
