<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNotice.aspx.cs" Inherits="Pages.Message.AddNotice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/common.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style5
        {
            font-size: 12px;
            height: 20px;
        }
        .style3
        {
            font-size: 12px;
            height: 21px;
        }
        .style4
        {
            height: 21px;
        }
        .style8
        {
            font-size: 12px;
        }
        .style9
        {
            height: 20px;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jNotify.jquery.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            //点击提交时验证数据
            $("#ibtnAdd").click(function () {
                var str = "";
                if (!$("#txtTitle").val().replace(/\s/g, "")) {
                    str += "标题不能为空且不能全为空白字符!" + "<br/>"
                }
                if ($("#ddlSor").val() == "-1") {
                    str += "公告分类未选!<br/>";
                }
                if (!$("#txtBegin").val()) {
                    str += "开始时间未设置!<br/>";
                }
                if (!$("#txtEnd").val()) {
                    str += "结束时间为设置!<br/>";
                }

                if ($("#txtBegin").val() > $("#txtEnd").val()) {
                    str += "开始时间结束时间有误!<br/>";
                }

                if (str) {
                    jNotify(str, {
                        HorizontalPosition: "center",
                        VerticalPosition: "center"
                    });
                    return false;
                }
                else {

                    return true;
                }

            });









        })
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        &nbsp;<asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/Images/btn_save.jpg"
            OnClick="ibtnAdd_Click" />&nbsp;
        <asp:ImageButton ID="ibtnNew" runat="server" ImageUrl="~/Images/btn_reset.jpg" OnClick="ibtnNew_Click" />&nbsp;
        <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/Images/btn_back.jpg" OnClick="ibtnBack_Click" />
        <br />
        <table border="0" width="100%" cellpadding="3" cellspacing="1">
            <tr>
                <td class="style5">
                    标题
                </td>
                <td class="style11" style="color: #FF0000">
                    <asp:TextBox ID="txtTitle" runat="server" size="40" MaxLength="40" Font-Size="12px"></asp:TextBox>
                    !
                </td>
            </tr>
            <tr>
                <td class="style5">
                    属性
                </td>
                <td class="style5">
                    <asp:RadioButton ID="rbtn1" runat="server" Text="公告草稿" GroupName="0" Checked="true" />
                    <asp:RadioButton ID="rbtn2" runat="server" Text="正式发布" GroupName="0" />
                </td>
            </tr>
            <tr>
                <td colspan="1" class="style3">
                    公告分类
                </td>
                <td class="style4">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div style="position: inherit; display: block">
                                <asp:DropDownList ID="ddlSor" runat="server">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSort" runat="server" Visible="False" Width="100px"></asp:TextBox>
                                <asp:Button ID="btnAddType" runat="server" Text="新增" OnClick="btnAddType_Click" />
                                <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="取消" Visible="False" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    发布范围
                </td>
                <td class="style5">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:RadioButton ID="rbAll" runat="server" Text="所有用户" Checked="True" GroupName="1"
                                OnCheckedChanged="rbClick" AutoPostBack="True" />
                            <asp:RadioButton ID="rbToUser" runat="server" Text="指定用户" GroupName="1" OnCheckedChanged="rbClick"
                                AutoPostBack="True" />
                            &nbsp;<asp:ImageButton ID="ibntToUser" runat="server" ImageUrl="../../Images/user_node.gif"
                                Visible="False" OnClick="ibntToUser_Click" />
                            &nbsp;<asp:TreeView ID="tvuser" runat="server" AutoGenerateDataBindings="False" OnSelectedNodeChanged="tvuser_SelectedNodeChanged"
                                ShowLines="True" Visible="False">
                            </asp:TreeView>
                            <br />
                            <asp:ListBox ID="lbToUser" runat="server" Height="68px" Width="117px" Visible="False">
                            </asp:ListBox>
                            <asp:Button ID="btnDelSelect" runat="server" OnClick="btnDelSelect_Click" Text="删除"
                                Visible="False" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td rowspan="2" class="style5">
                    有效期
                </td>
                <td class="style5">
                    生效时间:<asp:TextBox ID="txtBegin" runat="server" type="text" ContentEditable="false"
                        onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    终止日期:<asp:TextBox ID="txtEnd" runat="server" type="text" ContentEditable="false"
                        onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    附件
                </td>
                <td class="style9">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" Style="height: 21px" />
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    公告正文
                </td>
            </tr>
        </table>
        <div class="fck">
            <textarea name="content" style="display: none" id="content" runat="server"></textarea>
            <iframe id="Editor" name="Editor" src="../../HtmlEditor/index.html?ID=content" frameborder="0"
                marginheight="0" marginwidth="0" scrolling="no" style="height: 400px; width: 100%">
            </iframe>
        </div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function setcontent(s) {
        document.getElementById('content').value = s;
    }

    function getcontent() {
        var current = document.getElementById("Editor").contentWindow;
        var sub = current.document.getElementById("HtmlEditor").contentWindow;
        document.getElementById('content').value = sub.document.getElementsByTagName("BODY")[0].innerHTML;
        return false;
    }
</script>
