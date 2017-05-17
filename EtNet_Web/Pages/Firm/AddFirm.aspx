<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFirm.aspx.cs" Inherits="Pages.Firm.AddFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加公司资料</title>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
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
            border: 1px solid #CDC9C9;
        }
        .clsdata tr td
        {
            height: 24px;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsmtxt
        {
            border: 1px solid #C6E2FF;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .imgtitle
        {
            background-image: url('../../Images/public/list_tit.png');
            font-weight: bold;
            color: White;
        }
        .clsaccount
        {
            width: 100%;
            background-color: #B9D3EE;
        }
        .clsaccount tr td
        {
            background-color: White;
        }
        .clsaccount input
        {
            border: 0;
            width: 90%;
        }
        .imgadd
        {
            background-image: url('../../Images/public/iconadd.png');
            width: 16px;
            height: 16px;
            cursor: pointer;
        }
        .imgdel
        {
            background-image: url('../../Images/public/icondelete.png');
            width: 16px;
            height: 16px;
            cursor: pointer;
        }
        .clshdate
        {
            cursor: pointer;
            text-align: center;
        }
        .datebox
        {
            border: 0;
        }
        .combo-text
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .imgbtnstyle
        {
            background: url('../../Images/Common/buticon.gif');
            height: 22px;
            width: 64px;
            float: right;
            margin-right: 5px;
            text-align: center;
            line-height: 22px;
            cursor: pointer;
            border: 0;
            display: inline-block;
        }
    </style>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $("#imgbtnsave").click(function () {
                var str = "";
                str += testimg();
                str += testdate();
                if (!$.trim($("#iptfirmcode").val())) {
                    str += "公司代码不能为空\n";
                }
                if (!$.trim($("#iptshortname").val())) {
                    str += "公司简称不能为空\n";
                }
                if (!$.trim($("#iptcname").val())) {
                    str += "公司中文名称不能为空\n"
                }
                if (!$.trim($("#iptcaddress").val())) {
                    str += "公司地址名称不能为空\n"
                }
                if (!$.trim($("#ipttel").val())) {
                    str += "公司电话不能为空\n"
                }
                if (!testaccount()) {
                    str += '请勿在账户资料中包含括号中的字符(,|"\'<>)';
                }

                if (str) {
                    alert(str);
                    return false;
                }
                else {
                    $("#hidfirm").val(saveaccount());
                }

            })


            //新增一行
            $(".imgadd").click(function () {
                var rowtxt = "<tr><td><input type='text'/></td>";
                rowtxt += "<td><input type='text' /></td>";
                rowtxt += "<td><input type='text' class='clshdate' /></td>";
                rowtxt += "<td><input type='text' /></td>";
                rowtxt += "<td align='center'>";
                rowtxt += "<div title='删除' class='imgdel'></div></td></tr>";
                $(".clsaccount").append(rowtxt);

            })

            //删除行
            $(".imgdel").live("click", function () {
                $(this).parent("td").parent("tr").remove();
            })


            //检验图片的格式
            function testimg() {
                var rg = /(\.PNG|\.png|\.GIF|\.gif|\.jpg|\.JPG|\.bmp|\.BMP)$/;
                var strimg = "";
                var strtxt = $("#iptlogopath").val();
                if (strtxt != "") {
                    if (!rg.test(strtxt)) {
                        strimg = "公司logo格式不正确,支持上传png,gif,bmp,jpg后缀的图片!\n";
                    }
                }
                return strimg;
            }

            //检查预设时间时候有填写
            function testdate() {
                var str = "";
                $(".clsaccount .clshdate").each(function () {
                    var date = $.trim($(this).val());
                    if (date == "") {
                        str = "请确认预设时间是否全部填写!\n";
                    }
                });
                return str;
            }



            //检测账户资料的填写字段
            function testaccount() {
                var rg = /[,|"<'>]/;
                var past = true;
                $(".clsaccount tr:gt(0) td input:text").each(function () {
                    if (rg.test($(this).val())) {
                        past = false;
                        return false;
                    }
                })
                return past;
            }


            //保存账户资料
            function saveaccount() {
                var totaltxt = "";
                $(".clsaccount tr:gt(0)").each(function () {
                    var txt = "";
                    $(this).find("input:text").each(function (i, dom) {
                        switch (i) {
                            case 0:
                                txt += $.trim(dom.value) + ",";
                                break;
                            case 1:
                                txt += $.trim(dom.value) + ",";
                                break;
                            case 2:
                                txt += $.trim(dom.value) + ",";
                                break;
                            case 3:
                                txt += $.trim(dom.value);
                                break;
                        }
                    })
                    if (!(txt.length == 1)) {
                        if (totaltxt == "") {
                            totaltxt += txt;
                        }
                        else {
                            totaltxt += "|" + txt;
                        }
                    }
                })
                return totaltxt;
            }

            $(".clshdate").live("mouseover", function () {
                $(this).attr("title", "点击设置时间");
            });

            var objhadate = null;

            $("#ipthdate").datebox();

            $(".clshdate").live("click", function () {
                objhadate = $(this);
                if ($(this).text() != "") {
                    $("#ipthdate").datebox("setValue", $(this).text());
                }
                $("#showhdate").show();
                $("#showhdate").dialog({
                    width: 300,
                    height: 100,
                    resizable: false,
                    closable: false,
                    title: "选择预设时间",
                    modal: true
                });
            });

            //确定发生日期
            $("#btns").click(function () {
                debugger;
                $(objhadate).val($("#ipthdate").datebox("getValue"))
                $("#showhdate").dialog("close");
            })


            //取消
            $("#btnc").click(function () {
                $("#showhdate").dialog("close");
            })

        })   
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidfirm" runat="server" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        添加公司资料
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <table class="clsdata">
            <tr>
                <td style="width: 70px;">
                    公司代码:
                </td>
                <td style="width: 300px;">
                    <input type="text" runat="server" id="iptfirmcode" class="clsunderline" />
                    <span style="color: Red;">*</span>
                </td>
                <td rowspan="7" style="width: 250px">
                </td>
                <td style="width: 70px">
                    英文全称:
                </td>
                <td>
                    <input type="text" runat="server" id="iptename" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td style="width: 70px;">
                    公司简称:
                </td>
                <td style="width: 300px;">
                    <input type="text" runat="server" id="iptshortname" class="clsunderline" />
                    <span style="color: Red;">*</span>
                </td>
                <td>
                    邮政编码:
                </td>
                <td>
                    <input type="text" runat="server" id="iptpostal" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    公司全称:
                </td>
                <td>
                    <input type="text" runat="server" id="iptcname" class="clsunderline" />
                    <span style="color: Red;">*</span>
                </td>
                <td>
                    税务登记号:
                </td>
                <td>
                    <input type="text" runat="server" id="ipttaxnum" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    电话号码:
                </td>
                <td>
                    <input type="text" runat="server" id="ipttel" class="clsunderline" />
                    <span style="color: Red;">*</span>
                </td>
                <td>
                    机构代码号:
                </td>
                <td>
                    <input type="text" runat="server" id="iptorgcode" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    传真号码:
                </td>
                <td>
                    <input type="text" runat="server" id="iptfax" class="clsunderline" />
                </td>
                <td>
                    邮箱地址:
                </td>
                <td>
                    <input type="text" runat="server" id="iptmailbox" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    中文地址:
                </td>
                <td colspan="3">
                    <input type="text" runat="server" id="iptcaddress" style="width: 400px;" class="clsunderline" />
                    <span style="color: Red;">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    英文地址:
                </td>
                <td colspan="3">
                    <input type="text" runat="server" id="ipteaddress" style="width: 400px;" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    公司网址:
                </td>
                <td colspan="4">
                    <input type="text" runat="server" id="iptwedsite" style="width: 400px;" class="clsunderline" />
                </td>
            </tr>
            <tr>
                <td>
                    备注资料:
                </td>
                <td colspan="2">
                    <textarea id="traremark" class="clsmtxt" runat="server" style="width: 100%; font-size: 13px;
                        resize: none; height: 60px;"></textarea>
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    公司Logo图:
                </td>
                <td colspan="4">
                    <asp:FileUpload runat="server" ID="iptlogopath" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    银行资料:
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table class="clsaccount" cellspacing="1" cellpadding="0">
                        <tr>
                            <td class="imgtitle" style="width: 30%;">
                                开户行名称
                            </td>
                            <td class="imgtitle" style="width: 28%;">
                                开户行账号
                            </td>
                            <td class="imgtitle" style="width: 15%;">
                                预设时间
                            </td>
                            <td class="imgtitle" style="width: 12%;">
                                预设余额
                            </td>
                            <td class="imgtitle" style="width: 5%; text-align: center;">
                                操作
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" />
                            </td>
                            <td>
                                <input type="text" />
                            </td>
                            <td>
                                <input type="text" class="clshdate" />
                            </td>
                            <td>
                                <input type="text" />
                            </td>
                            <td align="center">
                                <div title="新增一行" class="imgadd">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                </td>
            </tr>
        </table>
    </div>
    <div id="showhdate" style="display: none;">
        <table>
            <tr>
                <td>
                    发生时间:
                </td>
                <td>
                    <input type='text' id="ipthdate" />
                </td>
            </tr>
        </table>
        <div style='text-align: right; padding-top: 5px;'>
            <span id='btnc' class='imgbtnstyle'>取消</span> <span id='btns' class='imgbtnstyle'>确定</span>
        </div>
    </div>
    </form>
</body>
</html>
