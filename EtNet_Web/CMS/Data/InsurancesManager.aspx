<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsurancesManager.aspx.cs"
    Inherits="EtNet_Web.CMS.Data.InsurancesManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/common.css" type="text/css" />
    <link href="../../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        th
        {
            background-color: #DBE6E3;
        }
        .border
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 30px 0px;
        }
        .border, #contable, #contable table
        {
            width: 100%;
        }
        .sortable th
        {
            height: 24px;
            text-align: center;
        }
        .sortable td
        {
            text-align: center;
        }
        .titlebtncls
        {
            position: absolute;
            right: 40px;
            margin-top: 5px;
        }
        .titlebtncls a
        {
            font-size: 12px;
            font-weight: bold;
            margin-right: 10px;
            color: #718ABE;
            cursor: pointer;
            text-decoration: none;
        }
        tr.odd td, .oddrow td
        {
            background-color: #E3EBEF;
        }
        #scol
        {
            background: url(Images/common_bg.gif) no-repeat;
            width: 104px;
            height: 25px;
            display: inline-block;
        }
        .nDiv
        {
            z-index: 99999;
        }
        #form1 .border .desc div
        {
            background: url(Images/dn.png) 7px center no-repeat;
            cursor: pointer;
        }
        #form1 .border .asc div
        {
            background: url(Images/up.png) 7px center no-repeat;
            cursor: pointer;
        }
        #form1 .border .act
        {
            background: url(Images/actived_bg.gif) no-repeat;
        }
        #siftbox
        {
            display: none;
        }
        a img
        {
            border: none;
        }
        
        .paginator
        {
            font: 12px Arial, Helvetica, sans-serif;
            padding: 5px;
            margin: 0px;
        }
        .paginator a
        {
            border: solid 1px #ccc;
            color: #0063dc;
            cursor: pointer;
            text-decoration: none;
        }
        .paginator a:visited
        {
            padding: 1px 6px;
            border: solid 1px #61befe;
            background: #61befe;
            color: #fff;
            text-decoration: none;
        }
        .paginator .cpb
        {
            border: 1px solid #61befe;
            font-weight: 700;
            color: #fff;
            background-color: #61befe;
        }
        .paginator a:hover
        {
            border: solid 1px #61befe;
            color: #fff;
            background: #61befe;
            text-decoration: none;
        }
        .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover
        {
            float: left;
            height: 21px;
            line-height: 21px;
            min-width: 10px;
            _width: 10px;
            margin-right: 5px;
            text-align: center;
            white-space: nowrap;
            font-size: 12px;
            font-family: Arial,SimSun;
            padding: 0 4px;
        }
        #allClick
        {
            cursor: pointer;
        }
        .clsbtntxt
        {
            width: 80px;
            height: 20px;
            line-height: 20px;
            cursor: pointer;
            float: right;
            background: url('../../Images/public/btn.png');
            margin-right: 5px;
            text-align: center;
            border: 1px solid #4CB0D5;
        }
        
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function WidthCheck(str, maxLen) {

            var w = 0;
            var tempCount = 0;
            for (var i = 0; i < str.value.length; i++) {
                var c = str.value.charCodeAt(i);
                if ((c >= 0x0001 && c <= 0x007e) || (0xff60 <= c && c <= 0xff9f)) {
                    w++;

                } else {
                    w += 2;

                }

                if (w > maxLen) {
                    str.value = str.value.substr(0, i);
                    break;
                }
            }
        }


        function ReSelectCheckBox() {
            var form = document.forms[0];

            for (i = 0; i < form.elements.length; i++) {
                if (form.elements[i].type == "checkbox") {
                    if (form.elements[i].checked)
                        form.elements[i].checked = false;
                    else
                        form.elements[i].checked = true;
                }
            }
        }




        $(function () {

            //全选或全部选
            $("#btnchkdel").click(function () {
                if ($(".clschkb :checkbox").length == $(".clschkb :checked").length) {
                    $(".clschkb :checkbox").removeAttr("checked");
                }
                else {
                    $(".clschkb :checkbox").attr("checked", "checked");
                }
            })


            $("#btnalldel").click(function () {
                if ($(".clschkb :checked").length == 0) {
                    alert('未选中删除项');
                }
                else {
                    if (confirm('确定删除选中项')) {
                        $("#ibtnDeleteAll").click();
                    }
                }
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="man_zone">
        <table width="99%" border="0" align="center" cellpadding="3" cellspacing="1" class="table_style">
            <tr>
                <td colspan="2" style="height: 25px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="left_title_1" colspan="2">
                    <table cellpadding="0" cellspacing="1" border="0" id="table" style="width: 100%;">
                        <thead>
                            <tr>
                                <th class="clstitleimg">
                                </th>
                                <th class="clstitleimg">
                                    发票号码
                                </th>
                                <th class="clstitleimg">
                                    发票日期
                                </th>
                                <th class="clstitleimg">
                                    发票类别
                                </th>
                                <th class="clstitleimg">
                                    发票金额
                                </th>
                                <th class="clstitleimg" style="width: 200px;">
                                    开票单位
                                </th>
                                <th class="clstitleimg" style="width: 100px;">
                                    制单员
                                </th>
                                <th class="clstitleimg">
                                    是否确认
                                </th>
                                <th class="clstitleimg">
                                    删除
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpInvoice" runat="server" OnItemCommand="rpInvoice_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:CheckBox CssClass="clschkb" ID="cbx" runat="server" /><asp:Label ID="lbl" runat="server"
                                                Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                        </td>
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
                                            <%# Eval("IsSure").ToString()=="0"?"未确认":"已确认"%>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ibtnDelete" runat="server" OnClientClick="return window.confirm('确认删除吗?')"
                                                CommandName="Delete" CommandArgument='<%# Eval("id") %>' Font-Size="12px" ImageUrl="../../Images/public/delete.gif"
                                                alt="删除"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tr>
                            <th>
                            </th>
                            <th colspan="8" style="height: 27px;">
                                <div id="btnalldel" class="clsbtntxt">
                                    删除选中项</div>
                                <div id="btnchkdel" class="clsbtntxt" title="全部选中时点击将取消所有选中项">
                                    全选/全不选</div>
                                <asp:ImageButton ID="ibtnDeleteAll" Style="display: none;" runat="server" CommandName="DeleteAll"
                                    Font-Size="12px" ImageUrl="../../Images/public/delete.gif" alt="删除" Width="16px"
                                    OnClick="ibtnDeleteAll_Click"></asp:ImageButton>
                            </th>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="left_title_2" colspan="2">
                    <div id="pages" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
