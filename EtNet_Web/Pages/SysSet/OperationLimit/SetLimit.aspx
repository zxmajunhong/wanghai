<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetLimit.aspx.cs" Inherits="EtNet_Web.Pages.SysSet.OperationLimit.SetLimit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            margin-bottom: 5px;
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
        .btnimg
        {
            width: 0px;
            height: 0px;
        }
        .clsuserbtn
        {
            background-image: url('../../../Images/Public/btn.png');
            width: 80px;
            border: 1px solid #BCBCBC;
            height: 20px;
            line-height: 20px;
            cursor: pointer;
            text-align: center;
            margin-left: 10px;
            margin-right: 10px;
            margin-bottom: 5px;
        }
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/zDialogTwo.js" type="text/javascript"></script>
    <script src="../../../Scripts/zDrag.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //显示选人对话框
            function diloginfo() {
                var diag = new Dialog();
                diag.Width = 630;
                diag.Height = 356;
                diag.Title = "选人员";
                diag.URL = "../../Personnel/SearchPersonnel.aspx?plist=" + $("#hiduserlist").val();
                diag.OKEvent = function () {
                    $("#hiduserlist").val(diag.innerFrame.contentWindow.document.getElementById('hidselpeople').value);
                    $("#iptuserlist").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtpeople').value);
                    diag.close();
                };
                diag.show();
            }

            //打开消息对话框
            $("#imgedit").click(diloginfo);
            $("#iptuserlist").focus(diloginfo);

            //重置用户
            $(".clsuserbtn").click(function () {
                if ($("#hiduserlist").val() == "") {
                    alert('未选中用户!');
                    return false;
                }
                if (confirm('确定设置用户订单编辑权限')) {
                    $("#imgbtnuser").click();
                }
                else {
                    return falsel;
                }

            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="clstop">
            <div style="background-image: url('../../../Images/Public/title_hover.png'); background-repeat: no-repeat;
                height: 25px;">
                <span style="color: White; font-size: 12px; font-weight: bold; position: relative;
                    top: 5px; left: 5px;">操作权限设置</span>
            </div>
            <div style="background: #4CB0D5; height: 5px;">
            </div>
        </div>
        <div class="clsbottom">
            <table class="clsdata">
                <tr>
                    <td style="width: 100px">
                        订单编辑权限：
                    </td>
                    <td>
                        <input type="text" runat="server" id="iptuserlist" class="clsunderline" />
                        <img id="imgedit" src="../../../Images/public/adedit.gif" alt="选择用户" />
                        <span class="clsuserbtn" style="display: inline-block; border: 1px solid #4CB0D5;">设置权限</span>
                        <input type="hidden" runat="server" id="hiduserlist" />
                        <asp:ImageButton runat="server" ID="imgbtnuser" CssClass="btnimg" ImageUrl="~/Images/Public/btn.png"
                            OnClick="imgbtnuser_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
