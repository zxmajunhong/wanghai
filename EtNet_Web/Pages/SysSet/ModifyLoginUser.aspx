﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyLoginUser.aspx.cs"
    Inherits="Pages.SysSet.ModifyLoginUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改用户</title>
    <link href="../Financial/css/common.css" rel="stylesheet" type="text/css" />
    <link href="../CusInfo/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            height: 500px;
        }
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
        .clsdatalist
        {
            width: 200px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .clsfirmtxt
        {
            width: 200px;
            height: 60px;
            border: 1px solid #C6E2FF;
            overflow: auto;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
        }
        .buttonStyle
        {
            background: url('../../Images/public/buticon.gif');
            height: 22px;
            width: 64px;
            border: 0;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script type="text/javascript" src="artDialog.js"></script>
    <script src="../../Scripts/zDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/zDrag.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#ibtnmodify").click(function () {
                var rg = /[^\u4e00-\u9fa5]/g;
                var rglogin = /[^\w]/;
                var str = "";
                if ($.trim($("#tbxCname").val()) == "" || rg.test($.trim($("#tbxCname").val()))) {
                    str += "中文名不能为空,且只能是中文\n"
                }
                if ($.trim($("#tbxLoginID").val()) == "" || rglogin.test($.trim($("#tbxLoginID").val()))) {
                    str += "登录名不能为空,且只能为数字与字母\n"
                }
                //                if ($.trim($("#tbxPWD").val()) == "" || rglogin.test($.trim($("#tbxPWD").val()))) {
                //                    str += "密码不能为空且,只能为数字与字母\n"
                //                }
                if ($("#ddlDepart").val() == "-1") {
                    str += "请选部门\n";
                }
                if ($("#tbxPostid").val() == "") {
                    str += "所属岗位不能为空\n";
                }
                if ($("#ddlRole").val() == "-1") {
                    str += "请选角色\n"
                }
                if (str) {
                    alert(str);
                    return false;
                }


            })

            //显示公司对话框
            function diloginfo() {
                var diag = new Dialog();
                diag.Width = 630;
                diag.Height = 353;
                diag.Title = "所属公司选择";
                diag.URL = "../Firm/SearchFirm.aspx?firmlist=" + $("#hidfirm").val();
                diag.OKEvent = function () {
                    $("#hidfirm").val(diag.innerFrame.contentWindow.document.getElementById('hidselfirm').value);
                    $("#tbxFirm").val(diag.innerFrame.contentWindow.document.getElementById('hidtxtfirm').value);
                    showfirmtxt($("#tbxFirm").val());
                    diag.close();
                };
                diag.show();
            }

            //岗位选择窗口
            $(".edittype").click(function () {
                art.artDialog.open('../Common/PostSetType.aspx', { width: '600px', height: '450px' }).lock().title('岗位选择');

            });
            //岗位增加窗口
            $(".addtype").click(function () {
                art.artDialog.open('../Common/PostAddType.aspx', { width: '600px', height: '450px' }).lock().title('岗位新增');

            });

            //点击打开选择公司对话框
            $(".clsfirmtxt").click(function () {
                diloginfo();
            })

            //显示公司
            function showfirmtxt(txt) {
                $(".clsfirmtxt").html("");
                var str = "";
                var list = null;
                if (txt != "") {
                    if (txt.indexOf(',') != -1) {
                        list = txt.split(',');
                    }
                    else {
                        list = [txt];
                    }

                    for (var i = 0; i < list.length; i++) {
                        str += "所属公司" + (i + 1) + "：" + list[i] + "<br/>";
                    }
                    $(".clsfirmtxt").html(str);
                }
            }



            $(window).load(function () {
                showfirmtxt($("#tbxFirm").val());
            })
            //更改密码
            $("#pwd").click(function () {
                var strmodal = "dialogHeight=180px;dialogWidth=400px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../SysSet/UpdateUserPwd.aspx?id=" + $("#hiddenid").val() + "&dt=" + new Date().toString(), window.self, strmodal);
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
                        修改用户
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="background: #4CB0D5; height: 5px;">
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton ID="ibtnmodify" runat="server" ImageUrl="../../Images/Button/btn_save.jpg"
                OnClick="ibtnmodify_Click" />
            <asp:ImageButton ID="ibtnreset" runat="server" ImageUrl="../../Images/Button/btn_reset.jpg"
                OnClick="ibtnreset_Click" />
            <asp:ImageButton ID="ibtnback" runat="server" ImageUrl="../../Images/Button/btn_back.jpg"
                OnClick="ibtnback_Click" />
        </div>
        <table class="clsdata">
            <tr>
                <td style="width: 70px;">
                    登录帐号:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxLoginID"></asp:TextBox><span
                        style="color: Red;">&nbsp;*</span>
                </td>
                <td rowspan="5">
                </td>
                <td style="width: 70px">
                    电话号码:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxTel"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    登录密码:
                </td>
                <td>
                    <%--<asp:TextBox runat="server" TextMode="Password" CssClass="clsunderline" ID="tbxPWD"></asp:TextBox>--%>
                    <a href="#" id="pwd">修改密码</a>
                    <input type="hidden" id="hiddenid" runat="server" />
                </td>
                <td>
                    传真号码:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxFax"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    中文姓名:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxCname"></asp:TextBox><span
                        style="color: Red;">&nbsp;*</span>
                </td>
                <td>
                    电子邮箱:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxEmail"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    英文姓名:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxEname"></asp:TextBox>
                </td>
                <td rowspan="3">
                    所属公司
                </td>
                <td rowspan="3">
                    <div class="clsfirmtxt">
                    </div>
                    <asp:TextBox runat="server" CssClass="clsunderline" Width="0" Height="0" ID="tbxFirm"></asp:TextBox>
                    <input type="hidden" runat="server" id="hidfirm" />
                </td>
            </tr>
            <tr>
                <td>
                    所属部门:
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddlDepart">
                    </asp:DropDownList>
                    <span style="color: Red;">*</span>
                </td>
                <%--<td>权限角色</td>
                 <td><asp:TextBox runat="server"  CssClass="clsunderline" ID="tbxrole"></asp:TextBox></td>--%>
            </tr>
            <tr>
                <td>
                    所属岗位:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxPostid"></asp:TextBox>
                    <span style="color: Red;">* </span><a href="javascript:void(0);" class="edittype">
                        <img alt="选择" src="../../Images/public/expand.gif" title="选择类别" /></a> <a href="javascript:void(0);"
                            class="addtype">
                            <img alt="增加" src="../../Images/public/layoutedit.png" title="新增类别" /></a>
                    <input type="hidden" runat="server" id="hidPostid" />
                </td>
            </tr>
            <tr>
                <td>
                    订单提成:
                </td>
                <td style="width:300px">
                    <input type="text" id="ddtc" runat="server" class="clsunderline" />
                </td>
            </tr>
        </table>
        <br />
        当前用户拥有的审批流程
        <table class="clsdata" id="rule" runat="server" cellspacing="1" cellpadding="1">
            <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                <td class="clstitleimg" style="width: 200px;">
                    审批名称
                </td>
                <td class="clstitleimg" style="width: 200px;">
                    审批备注
                </td>
                <td class="clstitleimg" style="width: 200px;">
                    审批类型
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
