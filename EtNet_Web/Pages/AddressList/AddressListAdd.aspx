<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressListAdd.aspx.cs"
    Inherits="Pages.AddressList.AddressListAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增通讯录</title>
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
        .clsdata tr td
        {
            height: 24px;
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
        .clsmtxt
        {
            border: 1px solid #C6E2FF;
            width: 400px;
            height: 60px;
            resize: none;
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
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {


            //保存时进行验证
            $("#imgbtnsave").click(function () {
                var str = "";
                var rg = /[^\u4e00-\u9fa5]/;
                var strname = $("#iptcname").val();
                if ($.trim(strname) == "" || rg.test(strname)) {
                    str += "中文名不能为空,且只能为中文\n";
                    $("#iptcname").val("");
                }
                var tel = $("#iptphone").val();
                var mob = $("#iptcellphone").val();
                if ($.trim(tel) == "" && $.trim(mob) == "") {
                    str += "电话号码,手机号码默认必填一项";
                }

                if (str) {
                    alert(str);
                    return false;
                }
                else {
                    window.encodeURI($("#trearemark").val());
                    return true;
                }
            });





        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                  <td class="toptitletxt">新增通讯录</td>     
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <table class="clsdata">
            <tr style="display: none">
                <td>
                    关联员工
                </td>
                <td colspan="3">
                    <asp:DropDownList runat="server" ID="ddlstaff" CssClass="clsdatalist" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlstaff_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 60px;">
                    中文名称:
                </td>
                <td style="width: 400px;">
                    <input type="text" runat="server" id="iptcname" class="clsunderline" />
                    <span style="color: Red;">*</span>
                </td>
                <td style="width: 60px;">
                    英文名称:
                </td>
                <td>
                    <input type="text" runat="server" id="iptename" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    职务:
                </td>
                <td>
                    <input type="text" runat="server" id="iptposition" class="clsunderline" />
                </td>
                <td>
                    性别:
                </td>
                <td>
                    <asp:RadioButtonList ID="radsex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="男" Selected="True" Value="男"></asp:ListItem>
                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    电话号码:
                </td>
                <td>
                    <input type="text" runat="server" id="iptphone" class="clsunderline" />
                </td>
                <td>
                    手机号码:
                </td>
                <td>
                    <input type="text" runat="server" id="iptcellphone" class="clsunderline" />
                </td>
            </tr>

            <tr>
              <td>邮箱地址:</td> 
              <td>
                 <input type="text" runat="server" id="iptmailtxt" class="clsunderline" />
              </td>
             <td>手机短号:</td>
             <td>
                <input type="text" runat="server" id="iptscellphone" class="clsunderline" />
             </td>
            </tr>

            <tr>
                <td>
                    所属部门:
                </td>
                <td colspan="3">
                    <asp:DropDownList runat="server" ID="ddldepart" CssClass="clsdatalist">
                    </asp:DropDownList>
                </td>
            
            </tr>


            <tr>
                <td colspan="4">
                    备注:
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <textarea id="trearemark" class="clsmtxt" runat="server" style="font-size: small"></textarea>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
