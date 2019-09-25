﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCom.aspx.cs" Inherits="EtNet_Web.Pages.InsureCompany.UpdateCom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改客户</title>
    <link href="../Financial/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px 0px 30px 0px;
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
            margin-left:10px;
        }
        .clsdatalist
        {
            width: 200px;
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
        .subtxt
        {
            text-align: center;
            height: 20px;
        }
        #tablelink, #tablebank
        {
            background-color: #E3E3E3;
            width: 100%;
            border: 0;
        }
        #tablelink tr td
        {
            background-color: #F0F8FF;
        }
        #tablebank tr td
        {
            background-color: #F0F8FF;
        }
        .clsimgadd, .clsworkimgadd
        {
            background-image: url('../../Images/public/iconadd.png');
            background-repeat: no-repeat;
            height: 16px;
            width: 16px;
            cursor: pointer;
        }
        .clsimgdel
        {
            background-image: url('../../Images/public/icondelete.png');
            background-repeat: no-repeat;
            height: 16px;
            width: 16px;
            cursor: pointer;
        }
        .clsfocomtxt
        {
            border: 0;
            width: 98%;
            background-color: White;
        }
        .clsblurtxt
        {
            border: 0;
            width: 98%;
            background-color: #F0F8FF;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
        }
        .clstitleimg:hover
        {
            color: White;
        }
        .buttonStyle
        {
            background: url('../../Images/public/buticon.gif');
            height: 22px;
            width: 64px;
            border: 0;
        }
        .clsnav
        {
            cursor: pointer;
            border: 0;
        }
        .style1
        {
            background-image: url('../../Images/public/list_tit.png');
            color: #FFF;
            height: 20px;
        }
        .style2
        {
            background-image: url('../../Images/public/list_tit.png');
            color: #FFF;
            width: 60px;
            height: 20px;
        }
         table.dataBox{width:100%;}
        td.fieldTitle{width:100px;text-align:right;color:#444;font-weight:bold;height:26px;}
        .content{margin:5px 10px 20px 10px;padding-bottom:5px;width:98%;}
        #bankLoading{display:none;vertical-align:middle;}
        .mytable{border: 1px none #4f6b72;width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: black;}
        .mytable{border-collapse: collapse;width: 100%;}
        .mytable tr{background-color: #FFFFFF;}
        .mytable th{border: 1px solid #DED6DC;}
        .mytable tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        #sum td.sum-title{text-align:right;}
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .amount{width:98%;border:0px;border-bottom:1px solid #C6E2FF;text-align:center;}
        table.dataBox #auditpic td{padding:0px;}
        .hideBtn{display:none;}
        .clsauditpic{border: 1px solid #63B8FF;}
        .invoiceCol{display:none;}
        input{font-family:宋体;}
        .style5
        {
            width: 257px;
        }
        </style>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../CSS/JS/NbspSlider/jquery.nbspSlider.1.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jNotify.jquery.js" type="text/javascript"></script>
    <link href="default.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/nbspslider.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#imgbtnsave").click(function () {
                var str = "";
                if ($("#comCode").val() == "") {
                    str += "保险公司代码不能为空\n";
                }
                if ($("#comCAddress").val() == "") {
                    str += "保险公司地址不能为空\n";
                }
                if ($("#comCName").val() == "") {
                    str += "保险公司全称不能为空\n";
                }
                if ($("#comshort").val() == "") {
                    str += "保险公司简称不能为空\n";
                }
                if ($("#comType").val() == "0") {
                    str += "请选择公司类别\n";
                }

                if ($("#address").val() == "") {
                    str += "请选择省份城市\n";
                }

                if ($("#linkName").val() == "") {
                    str += "联系人姓名必填\n";
                }
                if ($("#linkTel").val() == "") {
                    str += "联系电话必填\n";
                }

                if (str) {
                    alert(str);
                    return false;
                }
            })

         


            //保存时验证数据
            $("#imgbtnsave").click(function () {
                var txtlink = ""; //次要，联系人
                var txtbank = ""; //其他银行
                $("#tablelink tr:gt(0)").each(function () {
                    var $edit = $(this).children("td").children(".clsedit");
                    var ctxt1 = $.trim($edit.eq(0).val()); //联系人
                    var ctxt2 = $.trim($edit.eq(1).val()); //职务
                    var ctxt3 = $.trim($edit.eq(2).val());
                    var ctxt4 = $.trim($edit.eq(3).val());
                    var ctxt5 = $.trim($edit.eq(4).val());
                    var ctxt6 = $.trim($edit.eq(5).val());
                    var ctxt7 = $.trim($edit.eq(6).val());
                    var ctxt8 = $.trim($edit.eq(7).val());

                    if ((ctxt1 + ctxt2 + ctxt3 + ctxt4 + ctxt5 + ctxt6 + ctxt7 + ctxt8) != "") {
                        if (txtlink == "") {
                            txtlink = ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7 + "|" + ctxt8;
                        }
                        else {
                            txtlink += "," + ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7 + "|" + ctxt8;
                        }
                    }
                });
                $("#hidlink").val(txtlink);

                $("#tablebank tr:gt(0)").each(function () {
                    var $edit = $(this).children("td").children(".clsedit");
                    var ctxt1 = $.trim($edit.eq(0).val()); //银行
                    var ctxt2 = $.trim($edit.eq(1).val()); //卡号
                    var ctxt3 = $.trim($edit.eq(2).val()); //收款人
                    var ctxt4 = $.trim($edit.eq(3).val()); //备注

                    if ((ctxt1 + ctxt2 + ctxt3 + ctxt4) != "") {
                        if (txtbank == "") {
                            txtbank = ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4;
                        }
                        else {
                            txtbank += "," + ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4;
                        }
                    }
                });
                $("#hidbank").val(txtbank);


            })

            //类别选择窗口
            $(".edittype").click(function () {
                art.artDialog.open('../Common/ComTypeSet.aspx', { width: '700px', height: '450px' }).lock().title('类别选择');

            });
            //类别增加窗口
            $(".addtype").click(function () {
                art.artDialog.open('../Common/ComAddType.aspx', { width: '700px', height: '450px' }).lock().title('类别新增');
            }); 

            //滑动效果
            $("#slider").nbspSlider({
                numBtnSty: "roundness",
                widths: "1000px",
                heights: "500px"
            });



            //编辑栏聚焦的样式
            $(".clsedit").live("focom", function () {
                $(this).removeClass("clsblurtxt").addClass("clsfocomtxt")
            })

            //编辑栏失去焦点是的样式
            $(".clsedit").live("blur", function () {
                $(this).removeClass("clsfocomtxt").addClass("clsblurtxt")

                var strtxt = $(this).val();
                var strshow = "输入字符不能包含括号中的字符[|,'<>\"]\n请重新输入";
                if (!test(strtxt)) {
                    alert(strshow);
                    $(this).val("");
                }
            })

            //检测输入值是否包含非法字符
            function test(strtest) {
                var dlist = ["|", ",", "'", "<", ">", "\""];
                var past = true;
                if (strtest.indexOf(dlist[0]) >= 0) {
                    past = false;
                }
                else if (strtest.indexOf(dlist[1]) >= 0) {
                    past = false;
                }
                else if (strtest.indexOf(dlist[2]) >= 0) {
                    past = false;
                }
                else if (strtest.indexOf(dlist[3]) >= 0) {
                    past = false;
                }
                else if (strtest.indexOf(dlist[4]) >= 0) {
                    past = false;
                }
                else if (strtest.indexOf(dlist[5]) >= 0) {
                    past = false;
                }
                else
                { }
                return past;
            }
            //增加行

            $(".clsimgadd").click(function () {
                var str = '<tr><td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><div title="删除" class="clsimgdel">&nbsp;</div></td></tr>';
                $("#tablelink").append(str);

            })

            $(".clsworkimgadd").click(function () {
                var str = '<tr><td><input type="text" class="clsblurtxt clsedit clseditdate" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clseditdate" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clsagelimit" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" /></td>';
                str += '<td><div title="删除" class="clsimgdel">&nbsp;</div></td></tr>';
                $("#tablebank").append(str)
            })




            $(".clsimgdel").live("click", function () {
                $(this).parent("td").parent("tr").remove();
            })


            $("#showstime").datebox();
            $("#showetime").datebox();
            objeditdate = null; //当前的工作经历时间段的激活框
            //显示工作经历时间段选取框
            $(".clseditdate").live("click", function () {
                objeditdate = this;
                $("#windate").show();
                $('#windate').window({
                    width: 540,
                    height: 90,
                    resizable: false,
                    maximizable: false,
                    minimizable: false,
                    collapsible: false,
                    modal: true
                });
            })


            
            function checktxt() {
                var checkvalue = true;
                var rgtest = /[<>]/;
                $("input:text, #traremark,#trawagecard").each(function () {
                    var ctxt = $(this).val()
                    if (rgtest.test(ctxt)) {
                        checkvalue = false;
                        return false;
                    }
                })
                return checkvalue;
            }

         

            //返回时清空数据
            $("#imgbtnback").click(function () {
                $("input:text").val("");
                $("#traremark").val("");
                $("#trawagecard").val("");
            })


        })
    </script>
</head>
<body onload='init();'>
    <form id="myform" runat="server">
    <input type="hidden" runat="server" id="hidlink" />
    <input type="hidden" runat="server" id="hidbank" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">修改保险公司</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="wrapper">
        <div style="text-align: right;padding-right: 10px;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="~/Images/button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="~/Images/button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div> 
         <!--版本：20130309-->  
          <div style="margin:0px 10px 20px 10px; padding-bottom:5px;border: 1px solid #CDC9C9; width:98%">
            <table class="dataBox">
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">基本信息</span>
                    </td>
                </tr>
                 
                <tr>
                    <td class="fieldTitle">
                        公司代码:
                    </td>
                    <td align="left" style="width: 26%;">
                        <input type="text" runat="server" id="comCode" class="clsunderline" /><span id="txtshow"
                            runat="server" style="color: Red;"></span>
                    </td>
                    <td class="fieldTitle">
                        公司类别:
                    </td>
                    <td align="left" style="width: 25%;">
                       <asp:TextBox ID="TxtType" dataType="Require" ReadOnly runat="server"
                                    class="clsunderline" ></asp:TextBox>
                        <a href="javascript:void(0);" class="edittype">
                            <img alt="选择" src="../../Images/public/expand.gif" title="选择类别"/></a>
                             <a href="javascript:void(0);"class="addtype">
                                <img alt="增加" src="../../Images/public/layoutedit.png" title="新增类别"/></a><span style="color: Red"> *</span></td>
                    <td class="fieldTitle">
                        是否启用:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbUsed" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">立即启用</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">暂不启用</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        公司简称:
                    </td>
                    <td align="left">
                        <span style="color: Red">
                            <input type="text" runat="server" id="comshort" class="clsunderline" />*</span>
                    </td>
                    <td class="fieldTitle">
                        公司全称:
                    </td>
                    <td align="left" colspan="3">
                        <span style="color: Red;">
                            <input type="text" runat="server" id="comCName" class="clsunderline" />*</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        省份城市:
                    </td>
                    <td align="left">
                        <script src="select.js" type="text/javascript" charset="gb2312"></script>
                        <asp:TextBox ID="address" runat="server" class="clsunderline" name="address" Style="width: 100px;"></asp:TextBox>
                        <select name="sheng" onchange="select()">
                        </select>
                        <select name="shi" onchange="select()">
                        </select><span style="color: Red">*</span>
                    </td>
                    <td class="fieldTitle">
                        公司地址:
                    </td>
                    <td align="left">
                        <input type="text" runat="server" id="comCAddress" class="clsunderline" /><span style="color: Red">*</span>
                    </td>
                    <td class="fieldTitle">
                        公司网址:
                    </td>
                    <td align="left">
                        <input type="text" runat="server" id="companyURL" class="clsunderline" />
                    </td>
                </tr>
                 <tr>
                    <td class="fieldTitle">
                        &nbsp;
                    </td>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">联系方式</span>
                    </td>
                </tr>
                
                <tr>
                    <td class="fieldTitle">
                        联系人名:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkName" class="clsunderline" /><span style="color: Red">*</span>
                    </td>
                    <td class="fieldTitle">
                        所属职务:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkPost" class="clsunderline" />
                    </td>
                    <td class="fieldTitle">
                        手机号码:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkMobile" class="clsunderline" />
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        联系电话:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkTel" class="clsunderline" /><span style="color: Red">*</span>
                    </td>
                    <td class="fieldTitle">
                        联系传真:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkFax" class="clsunderline" />
                    </td>
                    <td class="fieldTitle">
                        邮箱地址:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkEmail" class="clsunderline" />
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        Q Q:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkMsn" class="clsunderline" />
                    </td>
                    <td class="fieldTitle">
                        Skype:
                    </td>
                    <td align="left">
                        <input runat="server" id="linkSkype" class="clsunderline" />
                    </td>
                </tr>
                 <tr>
                    <td class="fieldTitle">
                        &nbsp;
                    </td>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">银行信息</span>
                    </td>
                </tr>
                
                <tr>
                    <td class="fieldTitle">
                        开户银行:
                    </td>
                    <td align="left" class="style5">
                        <input runat="server" id="bankName" class="clsunderline" />
                    </td>
                    <td class="fieldTitle">
                        银行帐号:
                    </td>
                    <td align="left">
                        <input runat="server" id="bankCard" class="clsunderline" />
                    </td>
                    <td class="fieldTitle" style="width: 91px">
                        开户户名:
                    </td>
                    <td align="left">
                        <input runat="server" id="bankMan" class="clsunderline" />
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        备注:
                    </td>
                    <td colspan="6" align="left">
                        <textarea id="bankremark" runat="server" name="S1" style="height: 60px; width: 97%;
                            resize: none; font-size: small; font-family: @宋体" onclick="return bankremark_onclick()"
                            class="clsunderline"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        制单员:
                    </td>
                    <td align="left" style="width: 20%">
                            
                        <input runat="server" id="lblMadeFrom" class="clsunderline" />
                    </td>
                    <td class="fieldTitle">
                        制单时间:
                    </td>
                    <td align="left" style="width: 20%">
                        
                        <input runat="server" id="lblMadeTime" class="clsunderline" />
                    </td>
                </tr>
                 <tr>
                    <td class="fieldTitle">
                        &nbsp;
                    </td>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <!--版本：20130309-->   
       <%--<div class="content" >
        <table class="dataBox">
        <tr>
                            <td align="center" colspan="4" style="background: #F0F0F0">
                                <span style="font-weight: bold; font-size: 16px;">基本信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px;">
                                &nbsp;
                            </td>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr >
                            <td class="fieldTitle">
                                公司代码:</td>
                            <td style="width: 300px;"align="left">
                                <input type="text" runat="server" id="comCode" class="clsunderline" /><span id="txtshow"
                                    runat="server" style="color: Red;"></span>
                            </td>
                            <td class="fieldTitle" >
                                是否启用:
                            </td>
                            <td style="width: 350px;">
                                <asp:RadioButtonList ID="rbUsed" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">立即启用</asp:ListItem>
                                    <asp:ListItem Value="0">暂不启用</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle">
                                公司简称:
                            </td>
                            <td align="left">
                                <span style="color: Red">
                                    <input type="text" runat="server" id="comshort" class="clsunderline" />*</span>
                            </td>
                            <td class="fieldTitle">
                                公司类别:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtType" dataType="Require" Style="width: 100px;" ReadOnly runat="server"
                                    class="clsunderline"></asp:TextBox>
                             
                               <a href="javascript:void(0);" class="edittype">
                            <img alt="选择" src="../../Images/public/expand.gif" /></a>
                             <a href="javascript:void(0);" class="addtype">
                                <img alt="增加" src="../../Images/public/layoutedit.png" /></a> 
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle">
                                公司全称:
                            </td>
                            <td align="left">
                                <span style="color: Red">
                                    <input type="text" runat="server" id="comCName" class="clsunderline" />*</span>
                            </td>
                            <td class="fieldTitle">
                                省份城市:
                            </td>
                            <td align="left">
                                <script src="select.js" type="text/javascript" charset="gb2312"></script>
                                <asp:TextBox ID="address" runat="server" class="clsunderline" name="address" Style="width: 100px;"></asp:TextBox>
                                <select name="sheng" onchange="select()">
                                </select>
                                <select name="shi" onchange="select()">
                                </select><span style="color: Red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle">
                                公司地址:
                            </td>
                            <td align="left">
                                <input type="text" runat="server" id="comCAddress" class="clsunderline" style="width: 310px" /><span
                                    style="color: Red" >*</span>
                            </td>
                            <td class="fieldTitle">
                                公司网址:
                            </td>
                            <td align="left">
                                <input type="text" runat="server" id="companyURL" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td class="fieldTitle">
                                制单员:
                            </td>
                            <td align="left" >
                                <asp:Label ID="lblMadeFrom" runat="server" Width="100" class="clsunderline"></asp:Label>&nbsp;&nbsp;
                                制单时间:<asp:Label ID="lblMadeTime" runat="server" class="clsunderline" Width="100"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
        </table>
        </div>
        <div class="content">
        <table class="dataBox">
        <tr>
                            <td align="center" colspan="4" style="background: #F0F0F0">
                                <span style="font-weight: bold; font-size: 16px;">联系方式</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle" >
                                联系人名:
                            </td>
                            <td align="left" style="width: 300px;">
                                <input runat="server" id="linkName" class="clsunderline" /><span style="color: Red">*</span>
                            </td>
                            <td class="fieldTitle">
                                所属职务:
                            </td>
                            <td align="left" style="width: 300px;">
                                <input runat="server" id="linkPost" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle" >
                                联系电话:
                            </td>
                            <td align="left" class="style6">
                                <input runat="server" id="linkTel" class="clsunderline" /><span style="color: Red">*</span>
                            </td>
                            <td class="fieldTitle" >
                                手机号码:
                            </td>
                            <td align="left">
                                <input runat="server" id="linkMobile" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle" >
                                联系传真:
                            </td>
                            <td align="left" class="style6">
                                <input runat="server" id="linkFax" class="clsunderline" /></td>
                            <td class="fieldTitle" >
                                Q Q &nbsp;&nbsp;:
                            </td>
                            <td align="left">
                                <input runat="server" id="linkMsn" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle">
                                邮箱地址:
                            </td>
                            <td align="left" class="style6">
                                <input runat="server" id="linkEmail" class="clsunderline" /></td>
                            <td class="fieldTitle" >
                                Skype &nbsp;:
                            </td>
                            <td align="left">
                                <input runat="server" id="linkSkype" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
        </table>
        </div>
        <div class="content">
        <table class="dataBox">
        <tr>
                            <td align="center" colspan="4" style="background: #F0F0F0">
                                <span style="font-weight: bold; font-size: 16px;">银行信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle">
                                开户银行:
                            </td>
                            <td align="left" style="width: 300px;">
                                <input runat="server" id="bankName" class="clsunderline" />
                            </td>
                            <td class="fieldTitle">
                                银行帐号:
                            </td>
                            <td align="left" style="width: 300px;">
                                <input runat="server" id="bankCard" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle">
                                开户户名:
                            </td>
                            <td align="left" >
                                <input runat="server" id="bankMan" class="clsunderline" />
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td   class="fieldTitle">
                                备注:
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding-right: 10px;" class="style4">
                                <textarea id="bankremark" runat="server" name="S1" style="height: 100px; width: 90%;
                                    resize: none; font-size: small; font-family: @宋体" onclick="return bankremark_onclick()"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding-right: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                    
        </table>
        </div>--%>
        <div class="content">
        <table class="dataBox">
        
       
         <tr>
                            <td align="center">
                                <span style="font-weight: bold; font-size: 16px;">其他联系人</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px; padding-left: 10px; vertical-align: top;">
                                <table id="tablelink" cellspacing="1" cellpadding="1" style="width:100%;" runat="server">
                                    <tr style="font-size: 12px; font-weight: bold;">
                                        <td class="style1">
                                            联系人姓名
                                        </td>
                                        <td class="style1">
                                            职务
                                        </td>
                                        <td class="style1">
                                            联系电话
                                        </td>
                                        <td class="style1">
                                            联系传真
                                        </td>
                                        <td class="style1">
                                            手机
                                        </td>
                                        <td class="style1">
                                            电子邮件
                                        </td>
                                        <td class="style1">
                                            QQ
                                        </td>
                                        <td class="style1">
                                            Skype
                                        </td>
                                        <td class="style2">
                                            操作
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <div title="新增一行" class="clsimgadd">
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                
                               
                              </table>
                            </td>
                        </tr>

           <tr>
           <td style="text-align: left">
            <span style="color: Red;padding-left:10px">姓名，电话，邮箱必填</span>
           </td>
           </tr>
          </table>
        </div>
        <div class="content">
        <table class="dataBox">
        <tr>
                            <td align="center">
                                <span style="font-weight: bold; font-size: 16px;">其他银行信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 10px; padding-left: 10px;vertical-align: top;">
                                <table id="tablebank" cellspacing="1" cellpadding="1" style="width:100%;" runat="server">
                                    <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                        <td class="clstitleimg" style="width: 150px;">
                                            开户银行
                                        </td>
                                        <td class="clstitleimg" style="width: 150px;">
                                            银行帐号
                                        </td>
                                        <td class="clstitleimg" style="width: 80px;">
                                            户名
                                        </td>
                                        <td class="clstitleimg" style="width: 150px;">
                                            备注
                                        </td>
                                        <td class="clstitleimg" style="width: 80px;">
                                            操作
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit " />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit " />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit " />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <div title="新增一行" class="clsworkimgadd">
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
        </table>
        </div>
    <%--<div class="clsbottom">
        <div style="text-align: right; padding-right: 70px;">
            <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="~/Images/button/btn_save.jpg"
                OnClick="imgbtnsave_Click" />
            <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="~/Images/button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
        </div>
        <div id="slider">
            <ul>
                <li style="text-align: left;">
                    <table class="clsdata" style="text-align: left; padding-left: 30px; padding-right: 30px;">
                        <tr>
                            <td align="center" colspan="4" style="background: #F0F0F0">
                                <span style="font-weight: bold; font-size: 16px;">基本信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px;">
                                &nbsp;
                            </td>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px;">
                                公司代码:
                            </td>
                            <td style="width: 300px;">
                                <input type="text" runat="server" id="comCode" class="clsunderline" readonly="readonly"
                                    style="background-color: #C0C0C0" visible="True" /><span style="color: Red">*</span>
                            </td>
                            <td style="width: 80px;">
                                是否启用:
                            </td>
                            <td style="width: 350px;">
                                <asp:RadioButtonList ID="rbUsed" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Selected="True">立即启用</asp:ListItem>
                                    <asp:ListItem Value="0">暂不启用</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                公司简称:
                            </td>
                            <td>
                                <span style="color: Red">
                                    <input type="text" runat="server" id="comshort" class="clsunderline" />*</span>
                            </td>
                            <td>
                                公司类别:
                            </td>
                            <td>
                                <asp:TextBox ID="TxtType" dataType="Require" Style="width: 100px;" ReadOnly runat="server"
                                    class="clsunderline"></asp:TextBox>
                                &nbsp;<a id="edittype" href="#">类别设置</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                公司全称:
                            </td>
                            <td>
                                <span style="color: Red">
                                    <input type="text" runat="server" id="comCName" class="clsunderline" />*</span>
                            </td>
                            <td>
                                省份城市:
                            </td>
                            <td>
                                <script src="select.js" type="text/javascript" charset="gb2312"></script>
                                <asp:TextBox ID="address" runat="server" class="clsunderline" name="address" Style="width: 100px;"></asp:TextBox>
                                <select name="sheng" onchange="select()">
                                </select>
                                <select name="shi" onchange="select()">
                                </select><span style="color: Red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                公司地址:
                            </td>
                            <td>
                                <input type="text" runat="server" id="comCAddress" class="clsunderline" style="width: 330px" /><span
                                    style="color: Red">*</span>
                            </td>
                            <td>
                                公司网址:
                            </td>
                            <td>
                                <input type="text" runat="server" id="companyURL" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                制单员:
                            </td>
                            <td>
                                <asp:Label ID="lblMadeFrom" runat="server" Width="100" class="clsunderline"></asp:Label>&nbsp;&nbsp;
                                制单时间:<asp:Label ID="lblMadeTime" runat="server" class="clsunderline" Width="100"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="background: #F0F0F0">
                                <span style="font-weight: bold; font-size: 16px;">联系方式</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                联系人名:
                            </td>
                            <td>
                                <input runat="server" id="linkName" class="clsunderline" /><span style="color: Red">*</span>
                            </td>
                            <td>
                                所属职务:
                            </td>
                            <td>
                                <input runat="server" id="linkPost" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                联系电话:
                            </td>
                            <td>
                                <input runat="server" id="linkTel" class="clsunderline" /><span style="color: Red">*</span>
                            </td>
                            <td>
                                手机号码:
                            </td>
                            <td>
                                <input runat="server" id="linkMobile" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                联系传真:
                            </td>
                            <td>
                                <input runat="server" id="linkFax" class="clsunderline" />
                            </td>
                            <td>
                                Q Q &nbsp;&nbsp;:
                            </td>
                            <td>
                                <input runat="server" id="linkMsn" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                邮箱地址:
                            </td>
                            <td>
                                <input runat="server" id="linkEmail" class="clsunderline" />
                            </td>
                            <td>
                                Skype &nbsp;:
                            </td>
                            <td>
                                <input runat="server" id="linkSkype" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="background: #F0F0F0">
                                <span style="font-weight: bold; font-size: 16px;">银行信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                开户银行:
                            </td>
                            <td>
                                <input runat="server" id="bankName" class="clsunderline" />
                            </td>
                            <td>
                                银行帐号:
                            </td>
                            <td>
                                <input runat="server" id="bankCard" class="clsunderline" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                开户户名:
                            </td>
                            <td>
                                <input runat="server" id="bankMan" class="clsunderline" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding-right: 10px;">
                                备注:
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding-right: 10px;">
                                <textarea id="bankremark" runat="server" cols="20" name="S1" rows="1" style="height: 100px;
                                    width: 76%; resize: none; font-size: small; font-family: @宋体"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding-right: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <table class="clsdata">
                        <tr>
                            <td align="center">
                                <span style="font-weight: bold; font-size: 16px;">次要联系人</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 60px; padding-left: 60px; vertical-align: top;">
                                <table id="tablelink" runat="server" cellspacing="1" cellpadding="1">
                                    <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                        <td class="clstitleimg">
                                            联系人姓名
                                        </td>
                                        <td class="clstitleimg">
                                            职务
                                        </td>
                                        <td class="clstitleimg">
                                            电话
                                        </td>
                                        <td class="clstitleimg">
                                            传真
                                        </td>
                                        <td class="clstitleimg">
                                            手机
                                        </td>
                                        <td class="clstitleimg">
                                            电子邮件
                                        </td>
                                        <td class="clstitleimg">
                                            QQ
                                        </td>
                                        <td class="clstitleimg">
                                            Skype
                                        </td>
                                        <td class="clstitleimg" style="width: 60px;">
                                            操作
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <div title="新增一行" class="clsimgadd">
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                </table>
                                <div style="text-align: left">
                                    <span style="color: Red">姓名，电话，邮箱必填</span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </li>
                <li>
                    <table class="clsdata">
                        <tr>
                            <td align="center">
                                <span style="font-weight: bold; font-size: 16px;">其他银行信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 30px; padding-left: 30px;">
                                <table id="tablebank" runat="server" cellspacing="1" cellpadding="1">
                                    <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                        <td class="clstitleimg" style="width: 150px;">
                                            开户银行
                                        </td>
                                        <td class="clstitleimg" style="width: 150px;">
                                            银行帐号
                                        </td>
                                        <td class="clstitleimg" style="width: 80px;">
                                            户名
                                        </td>
                                        <td class="clstitleimg" style="width: 150px;">
                                            备注
                                        </td>
                                        <td class="clstitleimg" style="width: 80px;">
                                            操作
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit clseditdate" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit clseditdate" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit clsagelimit" />
                                        </td>
                                        <td>
                                            <input type="text" class="clsblurtxt clsedit" />
                                        </td>
                                        <td>
                                            <div title="新增一行" class="clsworkimgadd">
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </li>
            </ul>
        </div>
    </div>--%>
    </div>
    <input id="HidTypeID" type="hidden" runat="server" />
    </form>
</body>
</html>
