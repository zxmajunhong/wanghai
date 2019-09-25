<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="parameter.aspx.cs" Inherits="EtNet_Web.Pages.SystemSetting.parameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>参数列表</title>
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 5px 10px 5px;
        }
        .clsdata
        {
            width: 100%;
            background-color: #B9D3EE;
        }
        .clsdata tr td
        {
            background-color: White;
            height: 30px;
            text-align: center;
        }
        .clssift
        {
            width: 100%;
        }
        .clsunderline
        {
            width: 150px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .clstitleimg:hover
        {
            color: Black;
        }
        .topbtnimg
        {
            width: 0px;
            height: 0px;
        }
        .topimgtxt
        {
            font-size: 12px;
            font-weight: bold;
            color: #718ABE;
            cursor: pointer;
            display: inline-block;
            margin-top: 4px;
            margin-right: 6px;
        }
        .topimgtxt img
        {
            height: 14px;
            width: 14px;
            margin-right: -6px;
            margin-bottom: -2px;
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
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <link href="default.css" rel="stylesheet" type="text/css" />
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        function clickLink(id) {
            art.dialog.open('CusLinkInfo.aspx?id=' + id).lock().title('联系人');
        }
        function clickSet() {
            art.dialog.open('../Common/PageSearchSet.aspx?pagenum=001').lock().title('设置');
        }
        function clickBank(id) {
            art.dialog.open('CusBankInfo.aspx?id=' + id).lock().title('银行信息');
        }
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //新增
            $("#addtxt").click(function () {
                $("#imgbtnadd").click();
            })

            //按照条件判断是否显示筛选栏
            function fist() {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();


            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");
                }
                else {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }

            })

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=003&dt=" + new Date().toString(), window.self, strmodal);
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" value="0" id="hidsift" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        参数列表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage">
                            <img alt="页面编辑" src="../../Images/public/layoutedit.png" />
                            <span>页面设置</span></span> <span class="topimgtxt" id="addtxt">
                                <img alt="新增" src="../../Images/public/pagedit.png" />
                                <span>新增</span> </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <tr>
                <th class="clstitleimg" style="width: 80px;">
                    参数列表
                </th>
                <th class="clstitleimg" style="width: 60px;">
                    利率
                </th>
                <th class="clstitleimg" style="width: 100px;">
                    免息天数
                </th>
                <th class="clstitleimg" style="width: 100px;">
                    咨询费比率
                </th>
                <th class="clstitleimg" style="width: 80px;">
                    经纪费比率
                </th>
                <th class="clstitleimg" style="width: 100px;">
                    经纪费税金比率
                </th>
                <th class="clstitleimg" style="width: 100px;">
                    服务费税金比率
                </th>
                <th class="clstitleimg" style="width: 80px;">
                    其他税金比率
                </th>
                <th class="clstitleimg" style="width: 70px;">
                    提成比例
                </th>
                <th class="clstitleimg" style="width: 80px;">
                    操作
                </th>
            </tr>
            <tbody>
                <asp:Repeater ID="Pramas" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                a
                            </td>
                            <td>
                                b
                            </td>
                            <td>
                                b
                            </td>
                            <td>
                                d
                            </td>
                            <td>
                                e
                            </td>
                            <td>
                                f
                            </td>
                            <td>
                                g
                            </td>
                            <td>
                                h
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Update" ImageUrl="~/Images/public/edit.gif" />
                                <%--<asp:ImageButton ID="ImageButton2" runat="server" CommandName="Detial" ImageUrl="~/Images/searchform.png" />--%>
                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Delete" ImageUrl="~/Images/public/delete.gif"
                                    OnClientClick="return window.confirm('确认删除吗?')" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div runat="server" id="pages">
        </div>
    </div>
    <%-- <div>
        <asp:ImageButton ID="imgbtnadd" CssClass="topbtnimg" runat="server" ImageUrl="../../Images/addapply.gif"
            OnClick="imgbtnadd_Click" />
    </div>--%>
    </form>
</body>
</html>
