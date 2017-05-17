<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleCodingSet.aspx.cs"
    Inherits="Pages.SysSet.ModuleCode.ModuleCodingSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模块自动编码</title>
    <base target="_self" />
    <style type="text/css">
        body
        {
            padding: 2px;
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
            background-color: #B9D3EE;
        }
        .clsdata tr td
        {
            background-color: White;
            height: 24px;
            text-align: center;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
            height: 24px;
            font-weight: bold;
            text-align: center;
            color: White;
        }
        .clstitleimg:hover
        {
            color: Black;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .clsbtn
        {
            background-image: url('../../../Images/Common/btn.png');
            text-align: center;
            display: inline-block;
            margin-right: 2px;
            width: 60px;
            height: 20px;
            line-height: 20px;
            cursor: pointer;
            border: 1px solid #CDC9C9;
        }
        .clstxtformat, .clsorderlen
        {
            width: 95%;
            border: 0;
        }
        .clstxtsel
        {
            background-color: #CCCCCC !important;
        }
    </style>
    <script type="text/javascript" src="../../../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行
            $(".clsdata tr:odd td input:text").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的文本框

            //聚焦文本框，改变样式
            $(".clsdata tbody  td input:text").click(function () {
                $(".clstxtsel").removeClass("clstxtsel");
                $(this).addClass("clstxtsel");
                $(this).parent("td").addClass("clstxtsel");
            })

            //在表达式中添加指定的项
            $(".clsbtn").click(function () {
                debugger;
                var strtxt = "";
                switch ($(this).attr("id")) {
                    case "btnyearfour":
                        strtxt = "[YYYY]";
                        break;

                    case "btnyeartwo":
                        strtxt = "[YY]";
                        break;

                    case "btnmonthtwo":
                        strtxt = "[MM]";
                        break;
                    case "btndaytwo":
                        strtxt = "[DD]";
                        break;
                    case "btnline":
                        strtxt = "[XL]";
                        break;
                    case "btndepartment":
                        strtxt = "[BM]";
                        break;

                }
                var $ipt = $(".clstxtsel input:text");
                if ($ipt.length == 1 && $ipt.hasClass("clstxtformat")) {
                    $ipt.val($ipt.val() + strtxt);
                }
            })

            //提交时验证
            $(".clsimgsave").click(function () {
                var $ipt = $(this).parent("td").prevAll("td").children(".clsorderlen");
                var str = $.trim($ipt.val());
                if (!testdigit(str)) {
                    alert('自动编码的长度只能是数字,且不能为零');
                    $ipt.val("1");
                    return false;
                }
                else {

                    $ipt.val(str); //数字去除前后空格

                    $ipt = $(this).parent("td").prevAll("td").children(".clstxtformat");
                    str = $.trim($ipt.val());
                    $ipt.val(str);
//                    if (testcontent(str)) {
//                        alert('表达式不能包含非[,]与字母与数字');
//                        $ipt.val("");
//                        return false;
//                    }
//                    else {
//                        $ipt.val(str); //去除前后空格
//                        return true;
//                    }
                }
            })


            //验证自动编码的格式,返回false表示格式不正确
            function testdigit(txt) {
                var rg = /^[1-9][0-9]*$/;
                if (rg.test(txt)) {
                    return true;
                }
                else {
                    return false;
                }
            }

            //验证表达式是不是包含非单词字符,返回true表示包含非单词字符
            function testcontent(txt) {
                var rg = /[^\w[\]]/; //非单词字符
                if (rg.test(txt)) {
                    return true;
                }
                else {
                    return false;
                }
            }




        })
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        自动编码设置
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <tr>
                <td class="clstitleimg" style="width: 40px;">
                    编码
                </td>
                <td class="clstitleimg" style="width: 100px;">
                    模块名称
                </td>
                <td class="clstitleimg">
                    表达式
                </td>
                <td class="clstitleimg" style="width: 100px;">
                    自动编码的长度
                </td>
                <td class="clstitleimg" style="width: 40px;">
                    操作
                </td>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="rptdata" OnItemCommand="rptdata_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:CheckBox runat="server" Checked='<%# TestChecked( Eval("usecode").ToString())%>' />
                            </td>
                            <td>
                                <%# Eval("cname") %>
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="clstxtformat" Text='<%# Eval("txtformat") %>'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox runat="server" CssClass="clsorderlen" Text='<%# Eval("orderlen") %>'></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton runat="server" CommandArgument='<%# Eval("id") %>' AlternateText="保存"
                                    CssClass="clsimgsave" ImageUrl="~/Images/public/save.png" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="5" style="height: 40px; text-align: right;">
                        <span id="btnyearfour" class="clsbtn">+年(4位)</span> <span id="btnyeartwo" class="clsbtn">
                            +年(2位)</span> <span id="btnmonthtwo" class="clsbtn">+月(2位)</span> <span id="btndaytwo"
                                class="clsbtn">+日(2位)</span> <span id="btnline" class="clsbtn">+线路</span> <span id="btndepartment"
                                class="clsbtn">+部门</span>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
