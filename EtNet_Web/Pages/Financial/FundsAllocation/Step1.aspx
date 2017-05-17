<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Step1.aspx.cs" Inherits="EtNet_Web.Pages.Financial.FundAllocation.Step1" %>
<%--2013年1月7日15:30:17--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../../Policy/z.js" type="text/javascript" charset="gb2312"></script>
    <link href="../../../CSS/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a{text-decoration: none;}
        a img{border: none;}
        .border{font-size: 12px;border: 1px solid #4CB0D5;padding: 10px;overflow: auto;min-width: 880px;}
        table#dataBox{width: 100%;}
        table#dataBox th{width: 150px;text-align: right;color: #444444;}
        table#dataBox td{padding: 5px;}
        table#dataBox input{border: 0px;border-bottom: 1px solid #C6E2FF;}
        table#dataBox input, table#dataBox select{width: 200px;}
    </style>
    <script type="text/javascript">
        $(document).ready
        (
            function () {
                $("#selectSalesman").click
                (
                    function () {
                        art.artDialog.open('SelectSalesman.aspx', { width: '310px' }).lock().title('选择业务员');
                    }
                );

                $("#selectPayer").click
                (
                    function () {
                        art.artDialog.open('SelectPayer.aspx', { width: '620px', height: "430px" }).lock().title('选择付款单位');
                    }
                );
            }
        );
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background: url('../../../Images/public/title_hover.png') no-repeat;
        text-align: left; height: 25px;">
        <span style="color: #FFFFFF; padding-left: 5px; font-size: 12px; font-weight: bold;
            line-height: 25px">认领 </span>
    </div>
    <div class="border">
        <span style="display: block; width: 100%; text-align: right;"><span style="float: left;">
            共2步，正在执行第1步 </span>
            <asp:ImageButton ID="BtnSubmit" OnClientClick="return Validator.Validate(document.getElementById('form1'), 1);"
                runat="server" ImageUrl="~/Images/button/btn_save.jpg" ToolTip="确认信息,下一步" OnClick="BtnSubmit_Click" />
            <a href="../FundsAllocation.aspx" title="取消认领">
                <img alt="取消认领" src="../../../Images/button/btn_cancel.jpg" /></a> </span>
        <div style="border: 1px solid #CDC9C9;">
            <table id="dataBox">
                <tr>
                    <th>
                        业务员：
                    </th>
                    <td> 
                        <asp:TextBox ID="TxtSalesman" dataType="Require" msg="没有选择业务员" runat="server"></asp:TextBox>
                        <a href="javascript:void(0);" id="selectSalesman" title="选择业务员">
                            <img alt="选择" src="../../../Images/public/folder_user.gif" />
                        </a>
                    </td>
                    <th> 
                        付款单位：
                    </th>
                    <td>
                        <asp:TextBox ID="TxtPayer" dataType="Require" msg="没有选择付款单位" runat="server"></asp:TextBox>
                        <a href="javascript:void(0);" id="selectPayer" title="选择付款单位">
                            <img alt="选择" src="../../../Images/public/expand.gif" />
                        </a>
                    </td>
                </tr>
                <tr>
                    <th>
                        收款类别：
                    </th>
                    <td>
                        <asp:DropDownList ID="DdlReceiptType" dataType="Require" msg="没有选择收款类别" runat="server">
                            <asp:ListItem Value="income_premium">保费</asp:ListItem>
                            <asp:ListItem Value="income_brokerageFees">经纪费</asp:ListItem>
                            <asp:ListItem Value="income_serviceCharge">服务费</asp:ListItem>
                            <asp:ListItem Value="income_other1">其他项1</asp:ListItem>
                            <asp:ListItem Value="income_other2">其他项2</asp:ListItem>
                            <asp:ListItem Value="income_other3">其他项3</asp:ListItem>
                            <asp:ListItem Value="income_other4">其他项4</asp:ListItem>
                            <asp:ListItem Value="income_other5">其他项5</asp:ListItem>
                            <asp:ListItem Value="income_other6">其他项6</asp:ListItem>
                            <asp:ListItem Value="income_other7">其他项7</asp:ListItem>
                            <asp:ListItem Value="income_other8">其他项8</asp:ListItem>
                            <asp:ListItem Value="income_other9">其他项9</asp:ListItem>
                            <asp:ListItem Value="income_other10">其他项10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <input id="HidSalesman" type="hidden" runat="server" />
    <input id="HidPayerID" type="hidden" runat="server" />
    <input id="HidPayerType" type="hidden" runat="server" />
    </form>
</body>
</html>
