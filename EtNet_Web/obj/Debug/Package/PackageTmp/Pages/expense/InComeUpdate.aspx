<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InComeUpdate.aspx.cs" Inherits="EtNet_Web.Pages.expense.InComeUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑收款</title>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Policy/z.js" type="text/javascript" charset="gb2312"></script>
    <style type="text/css">
        a{text-decoration:none;}
        a img{border:none;}
        .border{font-size:12px;border:1px solid #4CB0D5;padding:10px;overflow:auto;min-width:880px;}
        table#dataBox{width:100%;}
        table#dataBox th{width:100px;text-align:right;color:#444444;}
        table#dataBox td{padding:5px;}
        table#dataBox input,#lblMarker,#lblMarkerDepartment,#lblConfirm,#lblConfirmData{border:0px;border-bottom:1px solid #C6E2FF;}
        table#dataBox input,table#dataBox select{width:200px;}
        table#dataBox input#txtUnit{width:160px;}
        table#dataBox input#txtMoney{width:200px;}
        table#dataBox input#ChkConfirm{width:auto;vertical-align:middle;cursor:pointer;}
        #txtMark{width:95%;height:100px;resize:none;font-size:14px;}
        .Wdate{cursor:pointer;}
        #lblMarker,#lblMarkerDepartment,#lblConfirm,#lblConfirmData{display:block;width:200px;}
        .titlebtncls{position: absolute;right: 40px;}
        #confirmBox label{font-weight:bold;vertical-align:middle;cursor:pointer;}
        #paymentInfo{display:none;}
    </style>
    <script type="text/javascript">
        //格式化金额
        function formatMoney(e) {
            var value = $.trim($(e).val());
            if (value == "") {
                $(e).val("");
                return;
            }
            if (isNaN(value)) {
                $(e).val("");
            }
            else {
                $(e).val(parseFloat($(e).val()).toFixed(2));
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background:url('../../Images/public/title_hover.png') no-repeat;text-align:left;height:25px;">
            <span style="color:#FFFFFF;padding-left:5px;font-size:12px;font-weight: bold;line-height: 25px">
            编辑收款登记
            </span>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="border">
        <span style="display:block;width:100%;text-align:right;">
            <asp:ImageButton ID="ibtSubmit" ImageUrl="~/Images/Button/btn_save.jpg" OnClientClick="return Validator.Validate(document.getElementById('form1'), 1);"
            ToolTip="保存数据" runat="server" onclick="ibtSubmit_Click" />&nbsp;
            <a href="InComeList.aspx" title="返回列表"><img alt="返回" src="../../Images/Button/btn_back.jpg" /></a>
        </span>
        <div style="border:1px solid #CDC9C9;">
            <table id="dataBox">
                <tr>
                    <th>
                        收款日期：
                    </th>
                    <td>
                        <asp:TextBox ID="txtSKDate" dataType="Require" msg="收款时间不能为空" CssClass="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        付款单位：
                    </th>
                    <td>
                        <asp:TextBox ID="txtSKUnit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        入账银行：
                    </th>
                    <td style="width:800px;">
                        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlBank_SelectedIndexChanged"></asp:DropDownList>
                            &nbsp;
                            账户：
                        <asp:Label ID="lblBankAccount" runat="server"></asp:Label>
                    </td>
                    <th>
                        收款金额：
                    </th>
                    <td>
                        <asp:TextBox ID="txtMoney" dataType="Require" msg="收款金额不能为空" runat="server" Text="" onBlur="formatMoney(this);" onfocus="javascript:this.select()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        所属部门：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlDepart" runat="server"></asp:DropDownList>
                    </td>
                    <th>
                        收款类别：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlsktype" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <th valign="top" style="padding-top:5px;">
                        备注：
                    </th>
                    <td colspan="5">
                        <textarea id="txtMark" rows="2" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <th>
                        制单员：
                    </th>
                    <td>
                        <asp:Label ID="lblMaker" runat="server" Text=""></asp:Label>
                    </td>
                    <th>
                        制单日期：
                    </th>
                    <td>
                        <asp:Label ID="lblMakeDate"  runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
