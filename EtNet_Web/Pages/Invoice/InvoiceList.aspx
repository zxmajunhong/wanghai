<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceList.aspx.cs" Inherits="EtNet_Web.Pages.Invoice.IncoiceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>费用发票列表</title>
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
            width: 120px;
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
        #operate
        {
            text-align: right;
            padding-right: 10px;
        }
        .filterInput, input.Wdate
        {
            width: 120px;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
    </style>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog.js" type="text/javascript"></script>
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=016&dt=" + new Date().toString(), window.self, strmodal);
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
                        费用发票列表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" />&nbsp;<span>页面设置</span></span>
                        <span class="topimgtxt" id="addtxt" title="新增">
                            <img alt="新增" title="新增" src="../../Images/public/pagedit.png" />&nbsp;<span>新增</span>
                        </span><span class="topimgtxt" id="sifttxt" title="筛选">
                            <img alt="筛选" title="筛选" src="../../Images/public/collapse.gif" />&nbsp;<span>筛选</span>
                        </span>
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
                <td style="width: 60px; padding-left: 30px;">
                    发票号码
                </td>
                <td>
                    <input type="text" runat="server" id="txtInvoiceID" class="clsunderline" />
                </td>
                <td>
                    费用类别
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" class="clsunderline">
                        <asp:ListItem Value="-1">请选择类别</asp:ListItem>
                        <asp:ListItem Value="佣金">佣金</asp:ListItem>
                        <asp:ListItem Value="贴费">贴费</asp:ListItem>
                        <asp:ListItem Value="咨询费">咨询费</asp:ListItem>
                        <asp:ListItem Value="服务费">服务费</asp:ListItem>
                        <asp:ListItem Value="管理费">管理费</asp:ListItem>
                        <asp:ListItem Value="其他1">其他1</asp:ListItem>
                        <asp:ListItem Value="其他2">其他2</asp:ListItem>
                        <asp:ListItem Value="其他3">其他3</asp:ListItem>
                        <asp:ListItem Value="其他4">其他4</asp:ListItem>
                        <asp:ListItem Value="其他5">其他5</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 60px;">
                    &nbsp;开票单位
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtUnit" class="clsunderline" />
                </td>
                <td style="width: 60px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 60px; padding-left: 30px;">
                    费用金额
                </td>
                <td>
                    <input type="text" runat="server" id="txtPrice" class="clsunderline" />
                </td>
                <td>
                    发票时间
                </td>
                <td>
                    <input type="text" runat="server" id="txtBeginDate" class="filterInput Wdate" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                    至
                    <input type="text" runat="server" id="txtEndDate" class="filterInput Wdate" onfocus="WdatePicker({isShowClear:false,readOnly:true})" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 60px;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="10" style="text-align: right; padding-right: 20px;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click1" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <tr>
                <th class="clstitleimg" style="width: 150px;">
                    发票号码
                </th>
                <th class="clstitleimg" style="width: 100px;">
                    发票日期
                </th>
                <th class="clstitleimg" style="width: 100px;">
                    发票类别
                </th>
                <th class="clstitleimg" style="width: 120px;">
                    发票金额
                </th>
                <th class="clstitleimg" style="width: 200px;">
                    开票单位
                </th>
                <th class="clstitleimg" style="width: 80px;">
                    制单员
                </th>
                <th class="clstitleimg" style="width: 80px;">
                    是否确认
                </th>
                <th class="clstitleimg" style="width: 80px;">
                    操作
                </th>
            </tr>
            <tbody>
                <asp:Repeater ID="rpInvoice" runat="server" OnItemCommand="rpInvoice_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("invoiceID")%>
                            </td>
                            <td>
                                <%# changeTime(Eval("invoiceDate").ToString())%>
                            </td>
                            <td>
                                <%#Eval("invoiceType")%>
                            </td>
                            <td>
                                <%# Eval("sum") %>
                            </td>
                            <td>
                                <%# Eval("invoiceUnit")%>
                            </td>
                            <td>
                                <%# CName(Convert.ToInt32( Eval("invoiceCMan")))%>
                            </td>
                            <td>
                                <%# Eval("IsSure").ToString() == "0" ? "<font color='red'>未确认</font>" : "已确认"%>
                            </td>
                            <td id="operate">
                                <asp:ImageButton ID="BtnCancelConfirm" runat="server" OnClientClick="return window.confirm('确定要撤销确认吗?');"
                                    CommandName="CANCEL" CommandArgument='<%# Eval("ID") %>' ImageUrl="../../Images/public/load.png"
                                    alt="撤销确认" ToolTip="撤销确认" Visible='<%# Eval("IsSure").ToString()=="1" && IsSelf(Eval("InvoiceCMan")) %>'>
                                </asp:ImageButton>
                                <asp:ImageButton ID="ImageButton1" title="编辑" AlternateText="编辑" runat="server" CommandName="Update"
                                    Visible='<%# IsSelf(Eval("InvoiceCMan")) %>' CommandArgument='<%# Eval("ID")+","+Eval("IsSure") %>'
                                    ImageUrl="~/Images/public/edit.gif" />
                                <asp:ImageButton ID="ImageButton2" runat="server" title="详细" AlternateText="详细" CommandName="Detial"
                                    CommandArgument='<%# Eval("id")+","+Eval("IsSure") %>' ImageUrl="~/Images/public/searchform.png" />
                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id")+","+Eval("IsSure") %>'
                                    ImageUrl="~/Images/public/delete.gif" title="删除" Visible='<%# IsSelf(Eval("InvoiceCMan")) %>'
                                    AlternateText="删除" OnClientClick="return window.confirm('确认删除吗?');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div runat="server" id="pages">
        </div>
    </div>
    <div>
        <asp:ImageButton ID="imgbtnadd" CssClass="topbtnimg" runat="server" ImageUrl="../../Images/public/pagedit.png"
            OnClick="imgbtnadd_Click" />
    </div>
    </form>
</body>
</html>
