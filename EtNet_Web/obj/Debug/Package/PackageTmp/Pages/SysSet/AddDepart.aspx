<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDepart.aspx.cs" Inherits="Pages.SysSet.AddDepart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加部门资料</title>
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
            width: 200px;
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
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //提交保存时验证
            $("#imgbtnadd,#imgbtnSaveadd").click(function () {
                var rg = /[^\u4e00-\u9fa5\d]/;
                var rge = /[^\w\s]/
                var str = "";
                var txt = $("#iptcname").val();
                var txte = $("#iptename").val();
                if ($.trim(txt) == "" || rg.test($.trim(txt))) {
                    str += "中文名称不能为空，且只能包含中文或数字\n";
                }
                if ($.trim(txte) != "") {
                    if (rge.test(txte)) {
                        str += "英文名称只能是数字或字母与空格\n";
                    }
                }
                else {
                    $("#iptename").val("");
                }
                if (str) {
                    alert(str);
                    return false;
                }                   
            })


            //返回时清空页面数据
            $("#imgbtnback").click(function () {
                $("input:text").val("");

            })

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
                    <td class="toptitletxt">
                        添加部门
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;"></div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="imgbtnSaveadd" runat="server" ImageUrl="../../Images/Button/btn_saveadd.jpg" OnClick="imgbtnSaveadd_Click" />
            <asp:ImageButton ID="imgbtnadd" runat="server" ImageUrl="../../Images/Button/btn_save.jpg" OnClick="imgbtnadd_Click" />
            <asp:ImageButton ID="imgbtnback" runat="server" ImageUrl="../../Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <table class="clsdata">
            <tr>
                <td style="width: 100px;">
                    中文名称:
                </td>
                <td>
                    <input type="text" runat="server" class="clsunderline" id="iptcname" />
                    <span style="color:Red;">*</span>
                </td>
                <td>
                    英文名称:
                </td>
                <td>
                    <input type="text" runat="server" class="clsunderline" id="iptename" />
                </td>
            </tr>
            <tr>
                <td>
                    自动编码标识符:
                </td>
                <td>
                    <input type="text" runat="server" class="clsunderline" id="autocode" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
