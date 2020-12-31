<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateOrder.aspx.cs" Inherits="EtNet_Web.Pages.Order.UpdateOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改订单</title>
    <link href="../../Scripts/artDialog4.1.6/skins/default.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/nbspslider.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/jNotify.jquery.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/common.css" rel="stylesheet" type="text/css" />
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
            border-bottom: 1px solid #C6E2FF;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: 0;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            margin-bottom: 0px;
            margin-left: 10px;
        }
        .clsunderline2
        {
            width: 97%;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
            height: 50px;
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
        #tablelink, #tablebank, #tableBack, #tablePreim
        {
            background-color: #E3E3E3;
            width: 100%;
            border: 0;
        }
        #tablelink tr td
        {
            background-color: #F0F8FF;
            height: 22px;
        }
        #tablebank tr td
        {
            background-color: #F0F8FF;
            height: 22px;
        }
        #tableBack tr td
        {
            background-color: #F0F8FF;
            height: 22px;
        }
        #tablePreim tr td
        {
            background-color: #F0F8FF;
        }
        .clsimgadd, .clsworkimgadd, .clsreturnadd
        {
            background-image: url('../../Images/public/iconadd.png');
            background-repeat: no-repeat;
            height: 16px;
            width: 16px;
            cursor: pointer;
        }
        .clsimgdel, .clsworkimgdel, .clsreturndel, .clscoldel
        {
            background-image: url('../../Images/public/icondelete.png');
            background-repeat: no-repeat;
            height: 16px;
            width: 16px;
            cursor: pointer;
        }
        .clsimglink
        {
            background-image: url('../../Images/public/record.gif');
            background-repeat: no-repeat;
            height: 16px;
            width: 16px;
            cursor: pointer;
            float: left;
        }
        .clsimgcollink
        {
            background-image: url('../../Images/public/record.gif');
            background-repeat: no-repeat;
            height: 16px;
            width: 16px;
            cursor: pointer;
            float: left;
        }
        .clsfocustxt
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
            height: 100%;
            vertical-align: middle;
        }
        .clsedit
        {
            text-align: center;
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
        
        img
        {
            cursor: pointer;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
        }
        img
        {
            cursor: pointer;
        }
        table.dataBox
        {
            width: 100%;
        }
        td.fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            font-weight: bold;
            height: 26px;
        }
        .content
        {
            margin: 10px 10px 20px 10px;
            padding-bottom: 5px;
        }
        #bankLoading
        {
            display: none;
            vertical-align: middle;
        }
        .mytable
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
        }
        .mytable
        {
            border-collapse: collapse;
            width: 100%;
        }
        .mytable tr
        {
            background-color: #FFFFFF;
        }
        .mytable th
        {
            border: 1px solid #DED6DC;
        }
        .mytable tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        #sum td.sum-title
        {
            text-align: right;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .amount
        {
            width: 98%;
            border: 0px;
            border-bottom: 1px solid #C6E2FF;
            text-align: center;
        }
        table.dataBox #auditpic td
        {
            padding: 0px;
        }
        .hideBtn
        {
            display: none;
        }
        .clsauditpic
        {
            border: 1px solid #63B8FF;
        }
        .invoiceCol
        {
            display: none;
        }
        input
        {
            font-family: 宋体;
        }
        .lblamount
        {
            text-align: center;
            color: Blue;
            font-weight: bold;
            border: 0;
            width: 100%;
        }
        .clsdetail
        {
            display: none;
        }
    </style>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Styles/JS/NbspSlider/jquery.nbspSlider.1.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $("#auditpic div").each(function () {
                var vpath = $(this).css("background-image");
                if (vpath.lastIndexOf('.') != -1) {
                    var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                    $(this).css({ "background-image": str });
                }
            })


            $("#imgbtnsave,#imgbtnaudisend,#imgnewreim").click(function () {
                var str = "";
                var rg = /\W/
                //                if (rg.test($("#txtOrderCode").val())) {
                //                    str += "订单代码只能是字母与数字\n";
                //                }
                //                if (!$.trim($("#txtnature").val())) {
                //                    str += "旅游性质不能为空\n"
                //                }
                if ($("#ddlLine").val() == "-1") {
                    str += "请选择旅游线路\n"
                }
                if (!$.trim($("#txtOutDate").val())) {
                    str += "出团日期不能为空\n"
                }
                if ($("#ddlInputer").val() == "-1") {
                    str += "请选择操作人员\n"
                }
                if ($("#DdlIsVirify").val() == "-1" || $("#auditpic").html() == "") {
                    str += "审核规则不能为空"
                }
                if (str) {
                    alert(str);
                    return false;
                }
            })

            //保存时验证数据
            $("#imgbtnsave,#imgbtnaudisend,#imgnewreim").click(function () {
                var txtlink = ""; //收款单位
                var txtbank = ""; //付款单位
                var txtback = ""; //退款单位
                var paystatus = true; //是否选择付款类别
                $("#tablelink tr:gt(0)").each(function () {
                    debugger;
                    var $edit = $(this).children("td").children(".clsedit");
                    var ctxt1 = $.trim($edit.eq(0).val()); //收款单位id
                    var ctxt2 = $.trim($edit.eq(1).val()); //收款单位营业部id
                    var ctxt3 = $.trim($edit.eq(2).val()); //收款单位名称
                    var ctxt4 = $.trim($edit.eq(3).val()); //业务员
                    var ctxt5 = $.trim($edit.eq(4).val()); //营业部
                    var ctxt6 = $.trim($edit.eq(5).val()); //联系人
                    var ctxt7 = $.trim($edit.eq(6).val()); //成人数
                    var ctxt8 = $.trim($edit.eq(7).val()); //儿童数
                    var ctxt9 = $.trim($edit.eq(8).val()); //陪同
                    var ctxt10 = $.trim($edit.eq(9).val()); //应收金额
                    var ctxt11 = $.trim($edit.eq(10).val()); //收款状态
                    var ctxt12 = $.trim($edit.eq(11).val()); //实际收款金额
                    var ctxt13 = $.trim($edit.eq(12).val()); //剩余金额
                    var ctxt14 = $.trim($edit.eq(13).val()); //备注
                    var ctxt15 = $.trim($edit.eq(14).val()); //明细表id

                    if ((ctxt1 + ctxt2 + ctxt3 + ctxt4 + ctxt5 + ctxt6 + ctxt7 + ctxt8 + ctxt9) != "") {
                        if (txtlink == "") {
                            txtlink = ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7 + "|" + ctxt8 + "|" + ctxt9 + "|" + ctxt10 + "|" + ctxt11 + "|" + ctxt12 + "|" + ctxt13 + "|" + ctxt14 + "|" + ctxt15;
                        }
                        else {
                            txtlink += "," + ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7 + "|" + ctxt8 + "|" + ctxt9 + "|" + ctxt10 + "|" + ctxt11 + "|" + ctxt12 + "|" + ctxt13 + "|" + ctxt14 + "|" + ctxt15;
                        }
                    }
                });

                $("#hidlink").val(txtlink);
                //                alert($("#hidlink").val());

                $("#tablebank tr:gt(0)").each(function () {
                    var $edit = $(this).children("td").children(".clsedit");
                    var ctxt1 = $.trim($edit.eq(0).val()); //付款单位id
                    var ctxt2 = $.trim($edit.eq(1).val()); //联系人id
                    var ctxt3 = $.trim($edit.eq(2).val()); //付款单位名称
                    var ctxt4 = $.trim($edit.eq(3).val()); //付款类别
                    var ctxt5 = $.trim($edit.eq(4).val()); //联系人
                    var ctxt6 = $.trim($edit.eq(5).val()); //成人数
                    var ctxt7 = $.trim($edit.eq(6).val()); //儿童数
                    var ctxt8 = $.trim($edit.eq(7).val()); //应付金额
                    var ctxt9 = $.trim($edit.eq(8).val()); //付款确认状态已支付金额
                    var ctxt10 = $.trim($edit.eq(9).val()); //付款支付状态
                    var ctxt11 = $.trim($edit.eq(10).val()); //已支付金额
                    var ctxt12 = $.trim($edit.eq(11).val()); //剩余金额
                    var ctxt13 = $.trim($edit.eq(12).val()); //备注
                    var ctxt14 = $.trim($edit.eq(13).val()); //明细表id

                    if ((ctxt1 + ctxt2 + ctxt3 + ctxt4) != "") {
                        if (txtbank == "") {
                            txtbank = ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7 + "|" + ctxt8 + "|" + ctxt9 + "|" + ctxt10 + "|" + ctxt11 + "|" + ctxt12 + "|" + ctxt13 + "|" + ctxt14;
                        }
                        else {
                            txtbank += "," + ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7 + "|" + ctxt8 + "|" + ctxt9 + "|" + ctxt10 + "|" + ctxt11 + "|" + ctxt12 + "|" + ctxt13 + "|" + ctxt14;
                        }
                    }
                    if (ctxt4 == "") {
                        paystatus = false;
                    }
                });
                $("#hidbank").val(txtbank);
                //                alert($("#hidbank").val());

                $("#tableBack tr:gt(0)").each(function () {
                    var $edit = $(this).children("td").children(".clsedit");
                    var ctxt1 = $.trim($edit.eq(0).text()); //付款单位id
                    var ctxt2 = $.trim($edit.eq(1).val()); //付款单位
                    var ctxt3 = $.trim($edit.eq(2).val()); //金额
                    var ctxt4 = $.trim($edit.eq(3).val()); //退款状态
                    var ctxt5 = $.trim($edit.eq(4).val()); //实际退款金额
                    var ctxt6 = $.trim($edit.eq(5).val()); //备注
                    var ctxt7 = $.trim($edit.eq(6).val()); //明细表id

                    if ((ctxt1 + ctxt2 + ctxt3 + ctxt4 + ctxt5) != "") {
                        if (txtback == "") {
                            txtback = ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7;
                        }
                        else {
                            txtback += "," + ctxt1 + "|" + ctxt2 + "|" + ctxt3 + "|" + ctxt4 + "|" + ctxt5 + "|" + ctxt6 + "|" + ctxt7;
                        }
                    }
                });
                $("#hidback").val(txtback);
                //                alert($("#hidback").val());

                if (!paystatus) {
                    alert("请选择付款类别");
                    return false;
                }
            })



            //            $('.cus').click(function () {
            //                getcus('saleman1');
            //            }); //hidsuprows

            //            $('.sup').click(function () {
            //                art.artDialog.open('SelectSup.aspx?sup=sup1', { width: '670px' }).lock().title('选择付款单位');
            //            });

            //            $('.returnCus').click(function () {
            //                art.artDialog.open('SelectCusReturn.aspx?cusreturn=cusreturn1', { width: '670px' }).lock().title('选择付款单位');
            //            });

            //            //选择付款类别
            //            $('.payType').click(function () {
            //                getpaytype();
            //            });

            //滑动效果
            $("#slider").nbspSlider({
                numBtnSty: "roundness",
                widths: "1000px",
                heights: "750px"
            });

            //点击后就全选内容
            $(".clsedit").live("click", function () {
                $(this).select();
            })

            //编辑栏聚焦的样式
            $(".clsedit").live("focus", function () {
                $(this).removeClass("clsblurtxt").addClass("clsfocustxt")
            })

            //编辑栏失去焦点是的样式
            $(".clsedit").live("blur", function () {
                $(this).removeClass("clsfocustxt").addClass("clsblurtxt")

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
                var sale = new Number(document.getElementById("hidsalemanrows").value);
                var cus = new Number(document.getElementById("hidcusrows").value);
                var saleman = "saleman" + sale;
                var cusname = "cusname" + cus
                var cusid = "cus" + cus;
                var linkid = "colLinkID" + cus;
                var link = "colLink" + cus;
                var linkname = "colLinkName" + cus;
                // + "artDialog.open('SelectCus.aspx?saleman=" + saleman + "')" +      
                var str = '<tr><td style="display:none;" ><input type="text" id=' + cusid + ' class="clsblurtxt clsedit clscusid" /></td>';
                str += '<td style="display:none;" ><input type="text" id=' + linkid + ' class="clsblurtxt clsedit clscollinkid" value="0" style="text-align: center" /></td>';
                str += '<td onclick=' + "document.getElementById('hidcusvalue').value" + "=" + "$(this).find('input').attr('id');document.getElementById('hidcusid').value=$(this).parent().find('.clscusid').attr('id');getcus('" + saleman + "')" + '><input type="text" id=' + cusname + ' class="clsblurtxt cus clsedit" style="text-align: center" /></td>';
                str += '<td><input type="text" id=' + saleman + ' class="clsblurtxt clsedit" style="text-align: center" /></td>';
                str += '<td onclick=' + "getcollink('" + cusid + "','" + link + "','" + linkid + "','" + linkname + "');" + '><input type="text" id=' + link + ' class="clsblurtxt clsedit" style="text-align: center" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit" id=' + linkname + ' style="text-align: center" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit colaut" value="0"  /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit colchild" value="0"  /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit colwith" value="0"  /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit colmoney" value="0.00"  /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clsStatus "  value="未收款" readonly="readonly"/></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit colhasmoney" value="0.00" readonly="readonly"/></td>'; //实际收款金额
                str += '<td><input type="text" class="clsblurtxt clsedit colsymoney" /></td>'; //剩余金额
                str += '<td><input type="text" class="clsblurtxt clsedit " value="" /></td>'; //备注
                str += '<td><input type="text" class="clsedit clsdetail coldetailid" value="0" /><div title="删除" class="clsimgdel" style="float:left;margin-left:20%">&nbsp;</div><div title="查看" class="clsimgcollink" style="margin-left:1px"></div></td></tr>' //input 用于存储该明细的明细表id

                document.getElementById("hidsalemanrows").value = sale + 1;
                document.getElementById("hidcusrows").value = cus + 1;

                $("#tablelink").append(str)


            })

            $(".clsworkimgadd").click(function () {
                var sup = new Number(document.getElementById('hidsuprows').value);

                var supname = "sup" + sup;
                var supid = "supid" + sup;
                var typeid = "payType" + sup;
                var linkID = "linkID" + sup;
                var payLink = "payLink" + sup;
                var str = '<tr><td style="display:none;" ><input type="text" id=' + supid + ' class="clsblurtxt clsedit clssupid" /></td>';
                str += '<td style="display:none;" ><input type="text" id=' + linkID + ' class="clsblurtxt clsedit clslinkid" value="0" /></td>';
                str += '<td onclick=' + "document.getElementById('hidsupvalue').value=$(this).find('input').attr('id');document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpay('" + linkID + "','" + payLink + "');" + '><input type="text" id=' + supname + ' class="clsblurtxt clsedit sup" style="text-align: center" /></td>';
                str += '<td onclick=' + "document.getElementById('hidpaytype').value=$(this).find('input').attr('id');document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpaytype();" + '><input type="text" id=' + typeid + ' class="clsblurtxt clsedit payType" style="text-align: center"/></td>';
                str += '<td onclick=' + "getpaylink('" + supid + "','" + payLink + "','" + linkID + "');" + '><input type="text" id=' + payLink + ' class="clsblurtxt clsedit" style="text-align: center" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit payNum" value="0" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit payNum" value="0" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clseditdate paymoney" value="0.00" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clsagelimit" value="无" readonly="readonly"/></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clsStatus" value="未支付" readonly="readonly"/></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit payhasmoney" readonly="readonly" value="0.00" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit paysymoney" /></td>'; //剩余金额
                str += '<td><input type="text" class="clsblurtxt clsedit " value="" /></td>'; //备注
                str += '<td><input type="text" class="clsedit clsdetail supdetailid" value="0" /><div title="删除" class="clsimgdel" style="float:left;margin-left:20%" >&nbsp;</div><div title="查看" class="clsimglink" style="margin-left:1px" ></div></td></tr>'

                document.getElementById("hidsuprows").value = sup + 1;

                $("#tablebank").append(str)
            })

            $(".clsreturnadd").click(function () {
                var returnvalue = new Number(document.getElementById('hidcusreturnrows').value);
                var backid = "backid" + returnvalue;
                var returnname = "cusreturn" + returnvalue;

                //<td onclick="document.getElementById('hidsupvalue').value=$(this).find('input').attr('id')">
                var str = '<tr><td style="display:none;" ><span id=' + backid + ' class="clsedit"></span></td>';
                str += '<td onclick=' + "document.getElementById('hidcusreturnvalue').value" + "=" + "$(this).find('input').attr('id');document.getElementById('hidbackid').value=$(this).parent().find('span').attr('id');getreturn()" + '><input type="text" id=' + returnname + ' class="clsblurtxt clsedit returnCus" style="text-align: center" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clseditdate backmoney" value="0.00"  /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit clsStatus" value="未退款" readonly="readonly"/></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit " readonly="readonly" /></td>';
                str += '<td><input type="text" class="clsblurtxt clsedit " value="" /></td>'; //备注
                str += '<td><input type="text" class="clsedit clsdetail reudetailid" value="0" /><div title="删除" class="clsimgdel">&nbsp;</div></td></tr>'

                document.getElementById("hidcusreturnrows").value = returnvalue + 1;

                $("#tableBack").append(str)
            })

            //单位的信息删除
            $(".clsimgdel").live("click", function () {
                debugger; //删除该行，并且记录当前行的明细id值用于后台删除数据库数据
                var colid = $(this).parent("td").find(".coldetailid").val();
                var payid = $(this).parent("td").find(".supdetailid").val();
                var retid = $(this).parent("td").find(".reudetailid").val();
                if (!(colid === undefined))
                    $("#hidcoldetailid").val($("#hidcoldetailid").val() + colid + ",");
                if (!(payid === undefined))
                    $("#hidpaydetailid").val($("#hidpaydetailid").val() + payid + ",");
                if (!(retid === undefined))
                    $("#hidretdetailid").val($("#hidretdetailid").val() + retid + ",");
                $(this).parent("td").parent("tr").remove();

                //计算金额合计
                //收款单位金额合计
                var coltotal = 0;
                var paytotal = 0;
                var rettotal = 0;
                $(".colmoney").each(function () {
                    if ($(this).val() != "") {
                        coltotal += parseFloat($(this).val());
                    }
                })

                if (coltotal != 0) {
                    $("#lblCollAmount").val(coltotal.toFixed(2))
                }
                else {
                    $("#lblCollAmount").val("0.00")
                }
                //付款单位金额合计
                $(".paymoney").each(function () {
                    if ($(this).val() != "") {
                        paytotal += parseFloat($(this).val());
                    }
                })

                if (paytotal != 0) {
                    $("#lblPayAmount").val(paytotal.toFixed(2))
                }
                else {
                    $("#lblPayAmount").val("0.00")
                }
                //退款单位金额合计
                $(".backmoney").each(function () {
                    if ($(this).val() != "") {
                        rettotal += parseFloat($(this).val());
                    }
                })

                if (rettotal != 0) {
                    $("#lblBackAmount").val(rettotal.toFixed(2))
                }
                else {
                    $("#lblBackAmount").val("0.00")
                }
            })

            //做过收款的收款信息删除
            $(".clscoldel").live("click", function () {
                alert("已收过款的收款单位无法删除");
            });

            //做过付款的付款信息删除
            $(".clsworkimgdel").live("click", function () {
                alert("已做过付款申请的信息无法删除");
            });

            //做过退款的退款信息删除
            $(".clsreturndel").live("click", function () {
                alert("已退过款的退款单位无法删除");
            })

            //查看联系人信息
            $(".clsimglink").live("click", function () {
                debugger;
                var linkid = $(this).parent().parent().find(".clslinkid").val();
                var payid = $(this).parent().parent().find(".clssupid").val();
                if (linkid == "" && payid == "")
                { }
                else
                    art.artDialog.open('SearchLink.aspx?linkid=' + linkid + '&&payid=' + payid, { width: '620px' }).lock().title('查看联系人');
            });

            //查看收款单位营业部
            $(".clsimgcollink").live("click", function () {
                debugger;
                var linkid = $(this).parent().parent().find(".clscollinkid").val();
                if (linkid == "")
                { }
                else
                    art.artDialog.open('SearchDepart.aspx?departid=' + linkid, { width: '620px' }).lock().title('查看营业部');
            });

            //返回时清空数据
            $("#imgbtnback").click(function () {
                $("input:text").val("");
                $("#traremark").val("");
                $("#trawagecard").val("");

            })


            //显示审核规则
            $("#DdlIsVirify").change(function () {
                debugger;
                $.get("../Job/JobFlowHandler.ashx", { sort: 1, flag: $("#DdlIsVirify").val() }, function (data) {
                    $("#auditpic").html(data);
                    $("#auditpic div").each(function () {
                        var vpath = $(this).css("background-image");
                        if (vpath.lastIndexOf('.') != -1) {
                            var str = 'url("../../Images/AuditRole' + vpath.substr(vpath.lastIndexOf('/'));
                            $(this).css({ "background-image": str });
                        }
                    })

                });


            })

            //保存
            $("#imgsave").click(function () {
                $("#imgbtnsave").click();
            })


            //返回
            $("#imgback").click(function () {
                $("#imgbtnback").click();
            })


            //送审
            $("#imgaudisend").click(function () {
                $("#imgbtnaudisend").click();
            })

            //新增报销单
            $("#newReim").click(function () {
                var cancel = $("#hidCancel").val();
                if (cancel == "1") {
                    alert("该订单已作废，无法做报销申请");
                }
                else {
                    $("#imgnewreim").click();
                    window.open("../Job/ReimbursedForm/AddReimbursedForm.aspx?orderid=" + $("#hidorderid").val());
                }
            })
            //刷新报销信息
            $("#refresh").click(function () {
                location = location;
            })

            function SetNum(e) {
                var value = $(e).val();
                if (value == null || value == '') {
                    //                CalcTotal();
                    return false;
                }
                if (!isNaN(value)) {
                    var userreg = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
                    if (userreg.test(value)) {
                        var numindex = parseInt(value.indexOf("."), 10);
                        if (numindex <= 0) {
                            $(e).val(value + ".00");
                        } else if (value.length - numindex == 2) {
                            $(e).val(value + "0");
                        }
                    } else {
                        var numindex = parseInt(value.indexOf("."), 10);
                        if (value.length - numindex == 1) {
                            $(e).val(value + "00");
                        } else {
                            var numindex = parseInt(value.indexOf("."), 10);
                            if (numindex == 0) {
                                $(e).val("");
                            }
                            var head = value.substring(0, numindex);
                            var bottom = value.substring(numindex, numindex + 3);
                            var fianlNum = head + bottom;
                            $(e).val(fianlNum);
                        }
                    }
                } else {
                    $(e).val("");
                }
            }

            //收款单位的金额格式补齐
            $(".colmoney").live("blur", function () {
                SetNum(this);
            });

            //得到收款单位合计
            $(".colmoney").live("keyup", function () {
                var total = 0
                var rg = /^(0[0-9].*)|(.*\.\d{3,})$/
                $(this).val($.trim($(this).val()));
                var strmoeny = $(this).val();

                var isempty = true;
                if (strmoeny == "") {
                    $(".colmoney").each(function () {
                        if ($(this).val() != "") {
                            isempty = false;
                        }
                    })
                    if (isempty) {
                        $("#lblCollAmount").val("");
                        return;
                    }
                }

                if (isNaN(strmoeny) || rg.test(strmoeny)) {
                    alert('输入格式有误')
                    $(this).val("");
                }
                $(".colmoney").each(function () {
                    if ($(this).val() != "") {
                        total += parseFloat($(this).val());
                    }
                })

                if (total != 0) {
                    $("#lblCollAmount").val(total.toFixed(2))
                }
                else {
                    $("#lblCollAmount").val("")
                }

            })

            //付款单位的金额格式补齐
            $(".paymoney").live("blur", function () {
                SetNum(this);
            });

            //得到付款单位合计
            $(".paymoney").live("keyup", function () {
                var total = 0
                var rg = /^(0[0-9].*)|(.*\.\d{3,})$/
                $(this).val($.trim($(this).val()));
                var strmoeny = $(this).val();
                var isempty = true;
                if (strmoeny == "") {
                    $(".paymoney").each(function () {
                        if ($(this).val() != "") {
                            isempty = false;
                        }
                    })
                    if (isempty) {
                        $("#lblPayAmount").val("");
                        return;
                    }
                }

                if (isNaN(strmoeny) || rg.test(strmoeny)) {
                    alert('输入格式有误')
                    $(this).val("");
                }
                $(".paymoney").each(function () {
                    if ($(this).val() != "") {
                        total += parseFloat($(this).val());
                    }
                })

                if (total != 0) {
                    $("#lblPayAmount").val(total.toFixed(2))
                }
                else {
                    $("#lblPayAmount").val("")
                }
            })

            //退款单位金额格式补齐
            $(".backmoney").live("blur", function () {
                SetNum(this);
            });
            //退款单位的金额合计
            $(".backmoney").live("keyup", function () {
                var total = 0
                var rg = /^(0[0-9].*)|(.*\.\d{3,})$/
                $(this).val($.trim($(this).val()));
                var strmoeny = $(this).val();
                var isempty = true;
                if (strmoeny == "") {
                    $(".backmoney").each(function () {
                        if ($(this).val() != "") {
                            isempty = false;
                        }
                    })
                    if (isempty) {
                        $("#lblBackAmount").val("");
                        return;
                    }
                }

                if (isNaN(strmoeny) || rg.test(strmoeny)) {
                    alert('输入格式有误')
                    $(this).val("");
                }
                $(".backmoney").each(function () {
                    if ($(this).val() != "") {
                        total += parseFloat($(this).val());
                    }
                })

                if (total != 0) {
                    $("#lblBackAmount").val(total.toFixed(2))
                }
                else {
                    $("#lblBackAmount").val("")
                }
            })

            function validate(op) {
                debugger;
                var reg = new RegExp("^(0|[1-9][0-9]*)$");
                if (!reg.test(op)) {
                    alert("请输入数字!");
                    return;
                }
            }


            $(".colaut,.colchild,.colwith").live("keyup", function () {
                var ctxt4 = 0;
                var ctxt5 = 0;
                var ctxt6 = 0;
                var auttotal = 0;
                var childtotal = 0;
                var withtotal = 0;
                $(".colaut").each(function () {
                    var audit = $(this).val();
                    validate(audit);
                    auttotal += Number(audit);

                });
                $(".colchild").each(function () {
                    var child = $(this).val();
                    validate(child);
                    childtotal += Number(child);
                });

                $(".colwith").each(function () {
                    var With = $(this).val();
                    validate(With);
                    withtotal += Number(With);
                });


                //                $("#txtTeamnum").val("成人数:" + auttotal + "，儿童数:" + childtotal + "，陪同数:" + withtotal);
                $("#txtTeamnum").val(auttotal + "大，" + childtotal + "小，" + withtotal + "陪");
            })

            //计算收款金额的剩余金额
            $(".colmoney").live("keyup", function () {
                debugger;
                var m1 = $(this).val();
                var m2 = $(this).parent().parent().find(".colhasmoney").val();
                var m3 = parseFloat(m1) - parseFloat(m2);
                $(this).parent().parent().find(".colsymoney").val(m3.toFixed(2));
            })
            //计算退款金额的剩余金额
            $(".paymoney").live("keyup", function () {
                var m1 = $(this).val();
                var m2 = $(this).parent().parent().find(".payhasmoney").val();
                var m3 = parseFloat(m1) - parseFloat(m2);
                $(this).parent().parent().find(".paysymoney").val(m3.toFixed(2));
            })
        })

        //在选择收款单位时，得到已经选择过的单位id，弹出选择单位对话框
        function getcus(salesman) {

            //        控制不能选择相同单位
            //            var unit = "";
            //            $("#tablelink span").each(function () {

            //                unit += $.trim($(this).text()) + "','";
            //            });
            //            art.artDialog.open('SelectCus.aspx?saleman=' + salesman + '&&Cusid=' + unit, { width: '670px' }).lock().title('选择收款单位');

            art.artDialog.open('SelectCus.aspx?saleman=' + salesman, { width: '670px' }).lock().title('选择收款单位');
        }

        //选择收款单位营业部信息（colid存储收款单位id对象的id，link存储营业部名称对象的id，linkid存储营业部id对象的id,linkname存储营业部联系人对象的id）
        function getcollink(colid, link, linkid, linkname) {
            var id = document.getElementById(colid).value; //收款单位id
            if (id == "" || id === undefined)
                alert("请先选择单位，再选择营业部信息");
            else
                art.artDialog.open('SelectColLink.aspx?colid=' + id + '&&link=' + link + '&&linkid=' + linkid + '&&linkname=' + linkname, { width: '620px' }).lock().title('选择营业部');
        }

        //选择付款单位（参数，linkID存储联系人id的列id，link存储联系人名称的列id）
        function getpay(linkID, link) {
            art.artDialog.open('SelectSup.aspx?linkid=' + linkID + '&&link=' + link, { width: '670px' }).lock().title('选择付款单位');
        }

        //选择付款类别
        function getpaytype() {
            debugger;
            var unit = ""; //存储单位id值的集合
            var item = ""; //存储类别名称的集合
            var thisUnit = "";
//            $("#tablebank tr:gt(0)").each(function () {
//                debugger;
//                var $edit = $(this).children("td").children(".clsedit");
//                unit += $.trim($edit.eq(0).val()) + ",";
//                item += $.trim($edit.eq(2).val()) + ",";
//            });
            if ($("#hidsupid").val() == "")
                thisUnit == "";
            else
                thisUnit = document.getElementById($("#hidsupid").val()).value;
            if (thisUnit == "" || thisUnit === undefined)
                alert("请先选择单位,再选择类别");
            else
                art.artDialog.open('SelectPayType.aspx?unit=' + unit + '&&item=' + item + '&&thisUnit=' + thisUnit, { width: '310px', height: '350px' }).lock().title('选择付款类别');

        }

        //选择付款单位联系人
        function getpaylink(payid, link, linkID) {
            debugger;
            var id = document.getElementById(payid).value; //付款单位id
            if (id == "" || id === undefined)
                alert("请先选择单位，再选择联系人");
            else
                art.artDialog.open('SelectPayLink.aspx?payid=' + id + '&&link=' + link + '&&linkid=' + linkID, { width: '620px' }).lock().title('选择联系人');
        }

        //选择退款单位
        function getreturn() {
            var unit = "";
//            $("#tableBack span").each(function () {
//                unit += $.trim($(this).text()) + "','";
//            });
            art.artDialog.open('SelectCusReturn.aspx?unit=' + unit, { width: '670px' }).lock().title('选择付款单位');
        }

    </script>
</head>
<body onload='init();'>
    <form id="myform" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input type="hidden" runat="server" id="hidsalemanrows" value="2" />
    <input type="hidden" runat="server" id="hidsalename" value="saleman1" />
    <input type="hidden" runat="server" id="hidcusrows" value="2" />
    <input type="hidden" runat="server" id="hidcusname" value="cusname1" />
    <input type="hidden" runat="server" id="hidcusvalue" value="" />
    <input type="hidden" runat="server" id="hidsuprows" value="2" />
    <input type="hidden" runat="server" id="hidsupvalue" value="" />
    <input type="hidden" runat="server" id="hidcusreturnrows" value="2" />
    <input type="hidden" runat="server" id="hidcusreturnvalue" value="" />
    <input type="hidden" runat="server" id="hidlink" />
    <input type="hidden" runat="server" id="hidbank" />
    <input type="hidden" runat="server" id="hidback" />
    <input type="hidden" runat="server" id="hidsupid" />
    <input type="hidden" runat="server" id="hidcusid" />
    <input type="hidden" runat="server" id="hidbackid" />
    <input type="hidden" runat="server" id="hidpaytype" />
    <input type="hidden" runat="server" id="hidcoldetailid" />
    <input type="hidden" runat="server" id="hidpaydetailid" />
    <input type="hidden" runat="server" id="hidretdetailid" />
    <input type="hidden" runat="server" id="hidCancel" />
    <%--订单是否作废情况--%>
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">修改订单</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right">
            <%--    <asp:ImageButton runat="server" CommandName="audisend" ID="imgbtnaudisend" ImageUrl="~/Images/Button/btn_audisend.jpg"
                OnClick="imgbtnaudisend_Click" />--%>
            <img id="imgsave" src="../../Images/Button/btn_save.jpg" alt="保存数据" onclick="return imgsave_onclick()" />
            <img id="imgback" src="../../Images/Button/btn_back.jpg" alt="返回" />
            <asp:ImageButton runat="server" CommandName="save" Width="0" Height="0" ID="imgbtnsave"
                ImageUrl="~/Images/Button/btn_save.jpg" OnClick="imgbtnsave_Click" />
            <asp:ImageButton runat="server" Width="0" Height="0" ID="imgbtnback" ImageUrl="~/Images/Button/btn_back.jpg"
                OnClick="imgbtnback_Click" />
            <asp:ImageButton runat="server" Width="0" Height="0" ID="imgnewreim" ImageUrl="~/Images/Button/btn_save.jpg"
                OnClick="imgnewreim_Click" />
        </div>
        <!--基本信息-->
        <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
            <table class="dataBox">
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        业务类型:
                    </td>
                    <td style="width: 26%; padding-left: 10px" align="left">
                        <asp:DropDownList Width="200" ID="OrderType" runat="server">
                            <asp:ListItem Value="-1" Text="请选择">
                                请选择
                            </asp:ListItem>
                            <asp:ListItem Value="1" Text="常规类型">
                                常规类型
                            </asp:ListItem>
                            <asp:ListItem Value="2" Text="非常规类型">
                                非常规类型
                            </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="fieldTitle">
                        订单序号:
                    </td>
                    <td style="width: 25%;" align="left">
                        <input type="text" runat="server" id="txtOrderCode" class="clsunderline" />
                        <span id="txtshow" runat="server" style="color: Red"></span>
                    </td>
                    <td class="fieldTitle">
                        出团日期:
                    </td>
                    <td align="left" style="width: 21%">
                        <input type="text" runat="server" id="txtOutDate" class="clsunderline" />
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle" style="height: 19px">
                        订单类型：
                    </td>
                    <td align="left">
                        <asp:DropDownList Width="200" ID="ddlnature" runat="server" Style="margin-left: 10px;">
                            <asp:ListItem Text="团队" Value="团队"></asp:ListItem>
                            <asp:ListItem Text="散客" Value="散客"></asp:ListItem>
                            <asp:ListItem Text="代订业务" Value="代订业务"></asp:ListItem>
                            <asp:ListItem Text="其他" Value="其他"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="fieldTitle" style="height: 26px">
                        团队总数:
                    </td>
                    <td align="left">
                        <input type="text" runat="server" id="txtTeamnum" class="clsunderline" style="width: 400px;"
                            readonly="readonly" />
                        &nbsp; &nbsp;
                    </td>
                    <td class="fieldTitle" style="height: 19px">
                        操作人员:
                    </td>
                    <td align="left">
                        <asp:DropDownList Width="200" ID="ddlInputer" runat="server" Style="margin-left: 10px;">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle" style="height: 19px">
                        旅游线路:
                    </td>
                    <td align="left">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList Width="200" ID="ddlLine" runat="server" Style="margin-left: 10px;"
                                    OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="fieldTitle" style="height: 26px">
                        线路描述:
                    </td>
                    <td align="left" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <input type="text" runat="server" id="txtRemark" class="clsunderline" style="width: 400px;" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <!--联系方式-->
                <!--银行信息-->
                <tr>
                    <td class="fieldTitle">
                        制单员:
                    </td>
                    <td align="left" style="width: 20%">
                        <%-- <asp:Label ID="lblMadeFrom" runat="server"   class="clsunderline"></asp:Label>--%>
                        <input runat="server" id="lblMadeFrom" class="clsunderline" />
                    </td>
                    <td class="fieldTitle">
                        制单时间:
                    </td>
                    <td align="left">
                        <%-- <asp:Label ID="lblMadeTime" runat="server" class="clsunderline" ></asp:Label>--%>
                        <input runat="server" id="lblMadeTime" class="clsunderline" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="isCancel" runat="server" Font-Bold="true" Text="作废" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <!--收款单位-->
        <div class="content">
            <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
                <table class="dataBox">
                    <tr>
                        <td align="center" style="background: #F0F0F0">
                            <span style="font-weight: bold; font-size: 16px;">收款单位</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px; vertical-align: top;">
                            <table id="tablelink" runat="server" cellspacing="1" cellpadding="1">
                                <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                    <td class="clstitleimg" style="width: 14%">
                                        单位名称
                                    </td>
                                    <td class="clstitleimg" style="width: 6%">
                                        业务员
                                    </td>
                                    <td class="clstitleimg" style="width: 14%">
                                        营业部
                                    </td>
                                    <td class="clstitleimg" style="width: 11%">
                                        联系人
                                    </td>
                                    <td class="clstitleimg" style="width: 4%">
                                        成人数
                                    </td>
                                    <td class="clstitleimg" style="width: 4%">
                                        儿童数
                                    </td>
                                    <td class="clstitleimg" style="width: 4%">
                                        陪同
                                    </td>
                                    <td class="clstitleimg" style="width: 6%">
                                        金额
                                    </td>
                                    <td class="clstitleimg" style="width: 6%">
                                        收款状态
                                    </td>
                                    <td class="clstitleimg" style="width: 6%">
                                        已收金额
                                    </td>
                                    <td class="clstitleimg" style="width: 6%">
                                        剩余金额
                                    </td>
                                    <td class="clstitleimg" style="width: 15%">
                                        备注
                                    </td>
                                    <td class="clstitleimg" style="width: 5%">
                                        <div title="新增一行" class="clsimgadd">
                                            &nbsp;</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="display: none;">
                                        <input type="text" id="cus1" class="clsblurtxt clsedit clscusid" />
                                    </td>
                                    <td style="display: none;">
                                        <input type="text" id="colLinkID1" class="clsblurtxt clsedit clscollinkid" value="0" />
                                    </td>
                                    <td onclick="document.getElementById('hidcusvalue').value=$(this).find('input').attr('id');document.getElementById('hidcusid').value=$(this).parent().find('.clscusid').attr('id');getcus('saleman1');">
                                        <input type="text" id="cusname1" class="clsblurtxt clsedit cus" style="text-align: center;" />
                                    </td>
                                    <td align="center">
                                        <input type="text" class="clsblurtxt clsedit" id="saleman1" style="text-align: center;"
                                            readonly="readonly" />
                                    </td>
                                    <td onclick="getcollink('cus1','colLink1','colLinkID1','colLinkName1')">
                                        <input type="text" class="clsblurtxt clsedit" id="colLink1" style="text-align: center" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit" id="colLinkName1" style="text-align: center" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit colaut" value="0" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit colchild" value="0" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit colwith" value="0" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit colmoney" value="0.00" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit clsStatus" readonly="readonly" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit colhasmoney" readonly="readonly" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit colsymoney" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit " />
                                    </td>
                                    <td>
                                        <input type="text" class="clsedit clsdetail coldetailid" value="0" />
                                        <div title="删除" class="clsimgdel" style="float: left; margin-left: 20%">
                                            &nbsp;</div>
                                        <div title="查看" class="clsimgcollink" style="margin-left: 1px">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px; vertical-align: top;">
                            <table id="collecAmount" runat="server" cellspacing="1" cellpadding="1" width="100%"
                                border="0">
                                <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                    <td style="width: 56%; color: Blue; text-align: left;">
                                        合计：
                                    </td>
                                    <td style="width: 6%;">
                                        <input type="text" id="lblCollAmount" runat="server" class="lblamount" readonly="readonly"
                                            value="0.00" />
                                    </td>
                                    <td style="width: 36%">
                                    </td>
                                </tr>
                            </table>
                            <%--<div style="text-align: left">
                                <span style="color: Red">单位名称，业务员必填</span>
                            </div>--%>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!--付款单位-->
        <div class="content">
            <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
                <table class="dataBox">
                    <tr>
                        <td align="center" style="background: #F0F0F0">
                            <span style="font-weight: bold; font-size: 16px;">付款单位</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px;">
                            <table id="tablebank" runat="server" cellspacing="1" cellpadding="1">
                                <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                    <td class="clstitleimg" style="width: 14%;">
                                        单位名称
                                    </td>
                                    <td class="clstitleimg" style="width: 8%;">
                                        付款类别
                                    </td>
                                    <td class="clstitleimg" style="width: 12%;">
                                        联系人
                                    </td>
                                    <td class="clstitleimg" style="width: 4%;">
                                        成人数
                                    </td>
                                    <td class="clstitleimg" style="width: 4%;">
                                        儿童数
                                    </td>
                                    <td class="clstitleimg" style="width: 8%;">
                                        金额
                                    </td>
                                    <td class="clstitleimg" style="width: 5%;">
                                        付款申请单
                                    </td>
                                    <td class="clstitleimg" style="width: 8%;">
                                        支付状态
                                    </td>
                                    <td class="clstitleimg" style="width: 8%;">
                                        已支付金额
                                    </td>
                                    <td class="clstitleimg" style="width: 8%;">
                                        剩余金额
                                    </td>
                                    <td class="clstitleimg" style="width: 17%">
                                        备注
                                    </td>
                                    <td class="clstitleimg" style="width: 5%;">
                                        <div title="新增一行" class="clsworkimgadd">
                                            &nbsp;</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="display: none;">
                                        <input type="text" id="supid1" class="clsblurtxt clsedit clssupid" />
                                    </td>
                                    <td style="display: none;">
                                        <input type="text" id="linkID1" class="clsblurtxt clsedit clslinkid" value="0" />
                                    </td>
                                    <td onclick="document.getElementById('hidsupvalue').value=$(this).find('input').attr('id');debugger;document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpay('linkID1','payLink1')">
                                        <input type="text" id="sup1" class="clsblurtxt clsedit clseditdate sup" style="text-align: center;" />
                                    </td>
                                    <td onclick="document.getElementById('hidpaytype').value=$(this).find('input').attr('id');document.getElementById('hidsupid').value=$(this).parent().find('.clssupid').attr('id');getpaytype()">
                                        <input type="text" id="payType1" class="clsblurtxt clsedit payType" style="text-align: center" />
                                    </td>
                                    <td onclick="getpaylink('supid1','payLink1','linkID1');">
                                        <input type="text" id="payLink1" class="clsblurtxt clsedit" style="text-align: center" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit payNum" value="0" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit payNum" value="0" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit clseditdate paymoney" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit clsagelimit" readonly="readonly" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit clsStatus" readonly="readonly" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit payhasmoney " readonly="readonly" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit paysymoney" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsedit clsdetail supdetailid" value="0" />
                                        <div title="删除" class="clsimgdel" style="float: left; margin-left: 20%">
                                            &nbsp;</div>
                                        <div title="查看" class="clsimglink" style="margin-left: 1px">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px; vertical-align: top;">
                            <table id="payAmount" runat="server" cellspacing="1" cellpadding="1" width="100%"
                                border="0">
                                <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                    <td style="width: 39%; color: Blue; text-align: left;">
                                        合计：
                                    </td>
                                    <td style="width: 8%;">
                                        <input type="text" id="lblPayAmount" runat="server" class="lblamount" readonly="readonly"
                                            value="0.00" />
                                    </td>
                                    <td style="width: 46%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!-- 退款信息-->
        <div class="content">
            <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
                <table class="dataBox">
                    <tr>
                        <td align="center" style="background: #F0F0F0">
                            <span style="font-weight: bold; font-size: 16px;">退款信息</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px;">
                            <table id="tableBack" runat="server" cellspacing="1" cellpadding="1">
                                <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                    <td class="clstitleimg" style="width: 23%;">
                                        付款单位
                                    </td>
                                    <td class="clstitleimg" style="width: 18%;">
                                        金额
                                    </td>
                                    <td class="clstitleimg" style="width: 18%;">
                                        退款状态
                                    </td>
                                    <td class="clstitleimg" style="width: 18%;">
                                        实际退款金额
                                    </td>
                                    <td class="clstitleimg" style="width: 18%">
                                        备注
                                    </td>
                                    <td class="clstitleimg" style="width: 5%;">
                                        <div title="新增一行" class="clsreturnadd">
                                            &nbsp;</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="display: none;">
                                        <span id="backid1" class="clsedit"></span>
                                    </td>
                                    <td onclick="document.getElementById('hidcusreturnvalue').value=$(this).find('input').attr('id');document.getElementById('hidbackid').value=$(this).parent().find('span').attr('id');getreturn()">
                                        <input type="text" id="cusreturn1" class="clsblurtxt clsedit returnCus" style="text-align: center;" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit clseditdate backmoney" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit" readonly="readonly" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit " readonly="readonly" />
                                    </td>
                                    <td>
                                        <input type="text" class="clsblurtxt clsedit " />
                                    </td>
                                    <td>
                                        <input type="text" class="clsedit clsdetail reudetailid" value="0" />
                                        <div title="删除" class="clsimgdel">
                                            &nbsp;</div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px; vertical-align: top;">
                            <table id="backAmount" runat="server" cellspacing="1" cellpadding="1" width="100%"
                                border="0">
                                <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                    <td style="width: 23%; color: Blue; text-align: left;">
                                        合计：
                                    </td>
                                    <td style="width: 18%;">
                                        <input type="text" id="lblBackAmount" runat="server" class="lblamount" readonly="readonly"
                                            value="0.00" />
                                    </td>
                                    <td style="width: 59%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!-- 报销信息 -->
        <div class="content">
            <div style="margin: 0px 10px 20px 10px; padding-bottom: 5px; border: 1px solid #CDC9C9;">
                <table class="dataBox">
                    <tr>
                        <td align="center" style="background: #F0F0F0">
                            <span style="font-weight: bold; font-size: 16px;">报销信息</span>
                        </td>
                    </tr>
                    <tr style="height: 20px">
                        <td align="left" style="padding-left: 20px; font-size: 13px; font-weight: bold;">
                            <a href="#" id="newReim">新增报销单</a> &nbsp;&nbsp; <a href="#" id="refresh">刷新</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px;">
                            <table id="tablePreim" cellspacing="1" cellpadding="1">
                                <thead>
                                    <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                        <td class="clstitleimg" style="width: 20%;">
                                            报销单号
                                        </td>
                                        <td class="clstitleimg" style="width: 20%;">
                                            报销内容
                                        </td>
                                        <td class="clstitleimg" style="width: 20%;">
                                            报销金额
                                        </td>
                                        <td class="clstitleimg" style="width: 20%;">
                                            备注
                                        </td>
                                        <td class="clstitleimg" style="width: 10%;">
                                            审批状态
                                        </td>
                                        <td class="clstitleimg" style="width: 10%;">
                                            确认报销
                                        </td>
                                    </tr>
                                </thead>
                                <tbody id="container">
                                    <asp:Repeater ID="rpReimbused" runat="server">
                                        <ItemTemplate>
                                            <tr style="height: 25px">
                                                <td align="center">
                                                    <%# Eval("jobflowcname")%>
                                                </td>
                                                <td align="center">
                                                    <%# Eval("itemtype")%>
                                                </td>
                                                <td align="center">
                                                    <%# Eval("totalmoney","{0:F2}")%>
                                                </td>
                                                <td align="center">
                                                    <%#Eval("remark") %>
                                                </td>
                                                <td align="center">
                                                    <%# getAuditTxt(Eval("auditstutastxt").ToString()) %>
                                                </td>
                                                <td align="center">
                                                    <%# Eval("payStatus").ToString() == "1"?"已支付":"未支付"%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 20px; padding-left: 20px; vertical-align: top;">
                            <table id="reimAmount" runat="server" cellspacing="1" cellpadding="1" width="100%"
                                border="0">
                                <tr style="height: 20px; font-size: 12px; font-weight: bold;">
                                    <td style="width: 40%; color: Blue; text-align: left;">
                                        合计：
                                    </td>
                                    <td style="width: 20%;">
                                        <input type="text" id="lblReimAmount" runat="server" class="lblamount" readonly="readonly"
                                            value="0.00" />
                                    </td>
                                    <td style="width: 40%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!-- 审核流程 -->
    <div class="content">
        <table class="dataBox">
            <tr>
                <td align="left">
                    审核流程：
                    <asp:DropDownList ID="DdlIsVirify" dataType="Require" msg="" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="auditpic" class="clsauditpic" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <input id="HidTypeID" type="hidden" runat="server" />
    <input type="hidden" runat="server" id="hidName" />
    <input type="hidden" runat="server" id="hidSaleman" />
    <input type="hidden" runat="server" id="hidorderid" />
    </form>
</body>
</html>
