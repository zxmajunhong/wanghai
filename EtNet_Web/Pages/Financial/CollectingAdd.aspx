<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CollectingAdd.aspx.cs" Inherits="EtNet_Web.Pages.Financial.CollectingAdd" %>
<%--2013年1月7日15:30:34--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../Policy/z.js" type="text/javascript" charset="gb2312"></script>
    <link href="../../artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
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
        table#dataBox input#txtMoney{width:172px;}
        table#dataBox input#ChkConfirm{width:auto;vertical-align:middle;cursor:pointer;}
        #txtMark{width:95%;height:100px;resize:none;}
        .Wdate{cursor:pointer;}
        #lblMarker,#lblMarkerDepartment,#lblConfirm,#lblConfirmData{display:block;width:200px;}
        .titlebtncls{position: absolute;right: 40px;}
        #confirmBox label{font-weight:bold;vertical-align:middle;cursor:pointer;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background:url('../../Images/public/title_hover.png') no-repeat;text-align:left;height:25px;">
        <span style="color:#FFFFFF;padding-left:5px;font-size:12px;font-weight: bold;line-height: 25px">
            新增收款登记
        </span>
    </div>
    <div class="border">
        <span style="display:block;width:100%;text-align:right;">
            <asp:ImageButton ID="BtnSubmit" OnClientClick="return Validator.Validate(document.getElementById('form1'), 1);" runat="server"
                 ImageUrl="../../images/button/btn_save.jpg" ToolTip="保存数据" onclick="BtnSubmit_Click" />
            <a href="CollectingList.aspx" title="返回列表"><img alt="返回" src="../../Images/button/btn_back.jpg" /></a>
        </span>
        <div style="border:1px solid #CDC9C9;">
            <table id="dataBox">
                <tr>
                    <th>
                        收款单号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtNumber" dataType="Require" msg="收款单号不能为空"  runat="server"></asp:TextBox>
                        <asp:Label ID="lblAutoCode" runat="server" style="color:Red;" Text=""></asp:Label>
                    </td>
                    <th>
                        收款时间：
                    </th>
                    <td>
                        <asp:TextBox ID="txtDate" dataType="Require" msg="收款时间不能为空"  CssClass="Wdate" onFocus="WdatePicker({isShowClear:false,readOnly:true})" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        收款金额：
                    </th>
                    <td>
                        <asp:TextBox ID="txtMoney" dataType="Require" msg="收款金额不能为空"  onBlur="formatMoney(this);" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        经营单位：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlUnit" dataType="Require" msg="sadas" runat="server" 
                            AutoPostBack="True" onselectedindexchanged="ddlUnit_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <th>
                        付款单位：
                    </th>
                    <td>
                        <asp:TextBox ID="txtUnit" runat="server" ReadOnly="true" BackColor="#E2E2E2"></asp:TextBox>
                        <%--<a href="javascript:void(0);" onclick="manualInput();" style="display:inline-block;width:16px;height:16px;" title="手动输入">
                            <img alt="手动输入" src="../../Images/public/edit.gif" />
                        </a>--%>
                        <a href="javascript:void(0);" onclick="manualInput();" style="display:none;width:16px;height:16px;" title="手动输入">
                            <img alt="手动输入" src="../../Images/public/edit.gif" />
                        </a>
                        <a href="javascript:void(0);" onclick="selectCompany();" title="选择" style="display:none">
                            <img alt="选择" src="../../Images/public/expand.gif" />
                        </a>
                    </td>
                    <%--<th>
                        入帐方式：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlWay" runat="server">
                            <asp:ListItem Value="0">现金</asp:ListItem>
                            <asp:ListItem Value="1">转账</asp:ListItem>
                            <asp:ListItem Value="2">网银</asp:ListItem>
                        </asp:DropDownList>
                    </td>--%>
                </tr>
                <tr id="paymentInfo" runat="server">
                    <th>
                        入账银行：
                    </th>
                    <td>
                        <%--<asp:TextBox ID="txtBank" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="DdlBank" msg="入账银行不能为空" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DdlBank_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <th>
                        银行帐号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtBankAccount" msg="银行账号不能为空" runat="server"></asp:TextBox>
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
                        <asp:Label ID="lblMarker" runat="server" Text=""></asp:Label>
                    </td>
                    <th>
                        制单部门：
                    </th>
                    <td>
                        <asp:Label ID="lblMarkerDepartment" runat="server" Text=""></asp:Label>
                    </td>
                    <th>
                        制单日期：
                    </th>
                    <td>
                        <asp:TextBox ID="txtMarkDate" dataType="Require" msg="制单日期不能为空" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>发送消息：
                        <a href="javascript:void(0);" onclick="selectUser();"><img src="../../Images/public/folder_user.gif" alt="" /></a>
                    </th>
                    <td colspan="3" id="userBox" runat="server"></td>
                    <td colspan="2" id="confirmBox" runat="server" style="padding-left:30px;">
                        <asp:CheckBox ID="ChkConfirm" Text="确认登记？" runat="server"
                            />
                        确认之后，单据不能再修改
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <input id="hidComID" type="hidden" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ddlWay").change(function () {
                toggleWay(this);
            });

            loadBankInfoState();

            $("#ChkConfirm").change(function () {
                debugger;
                if ($("#ChkConfirm").attr("checked")) {
                    var User = $("#hidListUser").val();
                     $("#hidUserList").val(User);
                     var UserList = $("#hidUserName").val();
//                    $("#hidUserList").val() = $("#hidListUser").val();
                    $("#userBox").text(UserList);
                }
                else {
                    $("#hidUserList").val("");
                    $("#userBox").text("");
                }
            });
        });

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

        //打开选择收款单位窗口
        function selectCompany() {
            artDialog.open("SelectPayerUnit.aspx", { width: "680px",height:"300px" }).lock().title("选择付款单位");
        }

        //手动输入付款单位
        function manualInput() {
            $("#txtUnit").removeAttr("readonly").css("background-color", "#FFFFFF");
            $("#hidComID").val("");
        }

        //根据收款方式设置信息是否显示
        function toggleWay(e) {
            if ($(e).find("option:selected").val() == "0") {
                $("#paymentInfo").hide();
                $("#hidBankInfoState").val("0");
                $("#DdlBank").removeAttr("dataType");
                $("#txtBankAccount").removeAttr("dataType");
                //$("#txtBankAccount").val("");
                //$("#txtBank").val("");
            } else {
                $("#paymentInfo").show();
                $("#hidBankInfoState").val("1");
                $("#DdlBank").attr("dataType", "Require");
                $("#txtBankAccount").attr("dataType", "Require");
            }
        }

        function loadBankInfoState() {
            if ($("#hidBankInfoState").val() == "1") {
                $("#paymentInfo").show();
                $("#DdlBank").attr("dataType", "Require");
                $("#txtBankAccount").attr("dataType", "Require");
            }
        }


        function selectUser() {
            if ($("#ChkConfirm").attr("checked")) {
                art.artDialog.open('SelectUser.aspx', { width: '310px' }).lock().title('选择消息接受者');
            }
            else { 
                alert("确认登记之后才能发送消息")
            }
        }
    </script>
    <input id="hidBankInfoState" value="0" runat="server" type="hidden" />
    <input id="hidUserList" runat="server" type="hidden" />
    <input id="hidListUser" runat="server" type="hidden" />
    <input id="hidUserName" runat="server" type="hidden" />
    </form>
</body>
</html>
