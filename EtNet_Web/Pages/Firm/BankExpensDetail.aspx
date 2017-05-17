<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankExpensDetail.aspx.cs"
    Inherits="EtNet_Web.Pages.Firm.BankExpensDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户收支情况</title>
    <link href="../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
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
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
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
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/customdate.js" type="text/javascript"></script>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=180px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=210&dt=" + new Date().toString(), window.self, strmodal);
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

            //返回
            $("#back").click(function () {
                debugger;
                $("#btnback").click();
            });

            //指定时间
            $("#selDate").click(function () {
                cdate({ sid: "dateBox", hid: "hidDateValue" });
                $("#ddlRequestDate").val(5);
            })

            //选时间段
            $("#ddlRequestDate").change(function () {
                if ($(this).val() == "5") {
                    $("#selDate").click();
                }
                else {
                    $("#dateBox").text("");
                    $("#hidDateValue").val("");
                }
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input runat="server" type="hidden" value="0" id="hidsift" />
    <asp:ImageButton ID="btnback" runat="server" ImageUrl="~/Images/public/pic25.gif"
                                OnClick="btnback_Click" Style="display: none;" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        账户收支情况
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="back" title="返回">
                            <img alt="返回" title="返回" src="../../Images/public/pic25.gif" />
                            <span>返回</span> </span><span class="topimgtxt" id="editpage" title="页面设置">
                                <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" />
                                <span>页面编辑</span> </span><span class="topimgtxt" id="sifttxt" title="筛选">
                                    <img src="" alt="筛选" title="筛选" />
                                    <span>筛选</span> </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td align="right" style="width: 80px;">
                    日期:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlRequestDate" Width="200px" runat="server">
                        <asp:ListItem Value="-1">——请选择——</asp:ListItem>
                        <asp:ListItem Value="0">——今天——</asp:ListItem>
                        <asp:ListItem Value="1">——今天之前——</asp:ListItem>
                        <asp:ListItem Value="2">——昨天——</asp:ListItem>
                        <asp:ListItem Value="3">——7天内——</asp:ListItem>
                        <asp:ListItem Value="4">——15天内——</asp:ListItem>
                        <asp:ListItem Value="5">——指定范围——</asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../Images/public/calendar.png" id="selDate" style="cursor: pointer;"
                        alt="选取时间范围" /><br />
                    <span id="dateBox"></span>
                    <input id="hidDateValue" type="hidden" runat="server" />
                </td>
                <td align="right" style="width: 80px;">
                    对方单位:
                </td>
                <td>
                    &nbsp;<input type="text" id="txtUnit" runat="server" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="imgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="imgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table style="width: 100%">
        <tr>
                <td style="text-align:right;">
                <asp:ImageButton runat="server" ID="ibtexport" 
                        ImageUrl="~/Images/Button/btn_export.jpg" onclick="ibtexport_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <tr>
                <th class="clstitleimg" style="width:13%">
                    日期
                </th>
                <th class="clstitleimg" style="width:13%">
                    收入
                </th>
                <th class="clstitleimg" style="width:13%">
                    支出
                </th>
                <th class="clstitleimg" style="width:13%">
                    余额
                </th>
                <th class="clstitleimg" style="width:15%">
                    对方单位
                </th>
                <th class="clstitleimg" style="width:15%">
                    银行账户
                </th>
                <th class="clstitleimg" style="width:13%">
                    类别
                </th>
                <th class="clstitleimg" style="width: 5%">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptexpens" runat="server" OnItemCommand="rptexpens_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Convert.ToDateTime(Eval("comedate")).ToString("yyyy-MM-dd") %>
                        </td>
                        <td>
                            <%#Eval("InMoney") %>
                        </td>
                        <td>
                            <%#Eval("OutMoney") %>
                        </td>
                        <td>
                            <%#Eval("balance")%>
                        </td>
                        <td>
                            <%#Eval("Unit") %>
                        </td>
                        <td>
                            <%#Eval("comebankname") %>
                        </td>
                        <td>
                            <%# showItem(Eval("item")) %>
                        </td>
                        <td>
                            <asp:ImageButton runat="server" CommandName="check" CommandArgument='<%#Eval("Id")+"_"+Eval("item") %>'
                                ImageUrl="~/Images/Public/searchform.png" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
            PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
            CustomInfoTextAlign="Left" LayoutType="Table" PageIndexBoxType="DropDownList"
            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
