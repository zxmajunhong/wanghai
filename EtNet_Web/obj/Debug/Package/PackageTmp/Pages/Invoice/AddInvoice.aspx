<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInvoice.aspx.cs" Inherits="EtNet_Web.Pages.Invoice.AddInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新发票</title>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/artDialog.js" type="text/javascript"></script>
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="Clock.js" type="text/javascript"></script>
    <link href="../Financial/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a
        {
            color: Black;
        }
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 10px 10px 10px;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
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
        .txtline
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
        }
        /*caption
        {
            padding: 0 0 5px 0;
            width: 100%;
            font: 14px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            font-weight: bold;
            text-align: center;
            background-color:transparent;
            border:none;
        }*/
        #txtRemark
        {
            font-family: @宋体;
            font-size: small;
        }
        /*th
        {
            font: bold 11px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            color: #4f6b72;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: right;
            padding: 6px 6px 6px 12px;
            background: #A4C2E0 no-repeat;
        }*/
        
        th
        {
            text-align: right;
            width: 80px;
        }
        
        th.nobg
        {
            border-top: 0;
            border-left: 0;
            border-right: 1px none #C1DAD7;
            background: none;
        }
        
        
        
        alt
        {
            background: #F5FAFA;
            color: #797268;
        }
        
        th.spec
        {
            border-left: 1px solid #C1DAD7;
            border-top: 0;
            background: #fff no-repeat;
            font: bold 10px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
        }
        
        th.specalt
        {
            border-left: 1px solid #C1DAD7;
            border-top: 0;
            background: #f5fafa no-repeat;
            font: bold 10px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            color: #797268;
        }
        img
        {
            border: none;
        }
        #mytable2 th
        {
            text-align: center;
        }
        #confirmBox label
        {
            font-weight: bold;
            vertical-align: middle;
            cursor: pointer;
        }
        .clsunderline
        {
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
            text-align: left;
            margin-left: 0px;
            text-align: left;
        }
        .fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            font-weight: bold;
        }
        #ChkConfirm
        {
            vertical-align: middle;
        }
        .under
        {
            width: 100%;
            border-collapse: collapse;
            color: black;
            border: 0px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        #mytable2
        {
            border: 1px none #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: black;
        }
        #mytable2
        {
            border-collapse: collapse;
            width: 100%;
        }
        #mytable2 tr
        {
            background-color: #FFFFFF;
        }
        #mytable2 th
        {
            border: 1px solid #DED6DC;
        }
        #mytable2 tr td
        {
            border: 1px solid #DED6DC;
            height: 24px;
            text-align: center;
        }
        #mytable2 tr td.select
        {
            text-align: left;
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
            margin: 0px 10px 5px 10px;
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
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $('#imgbtnSave').click(function () {
                if ($('#txtInvoiceID').val() == "") {
                    alert("请输入发票号码\n");
                    return false;
                }
                if ($('#TxtSalesman').val() == "") {
                    alert("请选择业务员\n");
                    return false;
                }
                if ($('#ddlType').val() == "-1") {
                    alert("请选择费用类别\n");
                    return false;
                }
                if ($('#txtDepart').val() == "") {
                    alert("请填写所属部门\n");
                    return false;
                }
                if ($('#txtUnit').val() == "") {
                    alert("请选择开票单位\n");
                    return false;
                }
                if ($('#txtSum').val() == "") {
                    alert("请填写费用金额\n");
                    return false;
                }
            })

            $('#imgbtnSave').click(function () {
                var txtPolicy = "";
                $("#mytable2 tbody tr:gt(0)").each(function () {

                    var $edit = $(this).children("td").children(".clsedit");

                    var ctxt1 = $.trim($edit.eq(0).text());
                    var ctxt2 = $.trim($edit.eq(1).text());
                    var ctxt3 = $.trim($edit.eq(2).text());

                    if ((ctxt1 + ctxt2 + ctxt3) != "") {
                        if (txtPolicy == "") {
                            txtPolicy = ctxt1 + "|" + ctxt2 + "|" + ctxt3;
                        }
                        else {
                            txtPolicy += "," + ctxt1 + "|" + ctxt2 + "|" + ctxt3;
                        }
                    }
                });
                $("#HidPolicy").val(txtPolicy);
            });
            $('#imgbtnSave').click(function () {
                if ($("#txtInvoiceID").val() == "") {
                    str += "发票号不能为空\n"
                }
                if (str) {
                    alert(str);
                    return false;
                }
            });

            $('#Salesman').click(function () {
                art.artDialog.open('SelectSalesman.aspx', { width: '310px' }).lock().title('选择所属业务员');
            });
            $('.ComAndPro').each(function () {
                $(this).click(function () {
                    art.artDialog.open('SelectInvoiceUnit.aspx', { width: '700px', height: '430px' }).lock().title('选择开票单位');
                });
            });
            $('.AddPolicy').each(function () {
                $(this).click(function () {
                    var type = document.getElementById("ddlType").value;
                    var com = document.getElementById("HidComId").value;
                    var sale = document.getElementById("HidSalesman").value;
                    if (type == "-1") {
                        alert("请选择费用类型");
                        return;
                    }
                    if (sale == "") {
                        alert("请选择业务员");
                        return;
                    }
                    if (com == "") {
                        alert("请选择开票单位");
                        return;
                    }
                    art.artDialog.open('SelectPolicy.aspx?type=' + type + '&com=' + com + "&sale=" + sale, { width: '760px', height: '320px' }).lock().title('选择保单');
                });
            });
        });

       
        function addDelCol() {
            $(".delete").html(" ");
            SetNum();

        }
        //获取合计值（费用金额）
        function SetNum() {
            var price = 0;
            $(".linePrice").each(function () {
                price += parseFloat($(this).val());
            });
            $("#sumBox").text(price.toFixed(2));
           
            $("#txtSum").val(price + ".00");
        }

        function getList(html) {
            $("#policyList").html(html);
            $("#hidTable").html(html);
           
            
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidTable" runat="server"/>
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">新增发票信息</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right; margin-right: 10px">
            <asp:ImageButton runat="server" ID="imgbtnSave" ImageUrl="../../Images/Button/btn_save.jpg"
                OnClick="imgbtnSave_Click" />
            <asp:ImageButton runat="server" ID="imgbtnBack" ImageUrl="../../Images/Button/btn_back.jpg"
                OnClick="imgbtnBack_Click" />
        </div>
        <div class="content">
            <table id="mytable" class="dataBox">
                <tr>
                    <td align="center" colspan="6" style="background: #F0F0F0">
                        <span style="font-weight: bold; font-size: 16px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        发票号码：
                    </td>
                    <td scope="col" class="td" style="width: 28%; height: 20px">
                        <input id="txtInvoiceID" type="text" runat="server" class="txtline" />
                        <asp:Label ID="lblInvoiceID" runat="server"></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        发票时间：
                    </td>
                    <td scope="col" class="td" style="width: 23%;">
                        <input id="txtInvoiceDate" type="text" runat="server" class="txtline" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:false,readOnly:true,onpicked:function(dp) {$dp.$('txtInvoiceDate').value=getEndTime(dp);}})" />
                    </td>
                    <td class="fieldTitle">
                        业务员：
                    </td>
                    <td scope="col" class="td" style="width: 23%;">
                        <input id="TxtSalesman" type="text" runat="server" class="txtline" />
                        <a href="javascript:void(0);" id="Salesman">
                            <img alt="选择" src="../../Images/public/folder_user.gif" /></a>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        费用类别：
                    </td>
                    <td scope="col" class="td">
                        <asp:DropDownList ID="ddlType" runat="server" class="inputLine">
                            <asp:ListItem Value="-1">请选择类别</asp:ListItem>
                            <asp:ListItem Value="exp_premium">代垫保费</asp:ListItem>
                            <asp:ListItem Value="exp_commission">佣金</asp:ListItem>
                            <asp:ListItem Value="exp_tiefei">贴费</asp:ListItem>
                            <asp:ListItem Value="exp_consultingFees">咨询费</asp:ListItem>
                            <asp:ListItem Value="exp_serviceCharge">服务费</asp:ListItem>
                            <asp:ListItem Value="exp_managementFees">管理费</asp:ListItem>
                            <asp:ListItem Value="exp_other1">其他1</asp:ListItem>
                            <asp:ListItem Value="exp_other2">其他2</asp:ListItem>
                            <asp:ListItem Value="exp_other3">其他3</asp:ListItem>
                            <asp:ListItem Value="exp_other4">其他4</asp:ListItem>
                            <asp:ListItem Value="exp_other5">其他5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="fieldTitle">
                        费用金额：
                    </td>
                    <td scope="col">
                        <input onfocus="SetNum()" onblur="SetNum()" readonly="readonly" id="txtSum" type="text"
                            runat="server" class="txtline readonly" value="0.00" />
                    </td>
                    
                    <td class="fieldTitle">
                        所属部门：
                    </td>
                    <td scope="col">
                        <input id="txtDepart" readonly="readonly" type="text" runat="server" class="txtline readonly" />
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        开票单位：
                    </td>
                    <td scope="col" colspan="5" class="td">
                        <input readonly="readonly" id="txtUnit" type="text" runat="server" class="txtline readonly" />
                        <a href="javascript:void(0);" class="ComAndPro">
                            <img alt="选择" src="../../Images/public/expand.gif" /></a>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle" valign="top">
                        备注：
                    </td>
                    <%--<td scope="col" colspan="5" class="td" height="56">
                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" style="width:98%;height:60px;max-width:100%;resize:none;border-bottom:#C6E2FF;border-width:0px;border-style:ridge;"
                           ></asp:TextBox>
                    </td>--%>
                    <td colspan="5" align="left">
                        <textarea id="txtRemark" runat="server" name="S1" style="height: 60px; width: 95.5%;
                            resize: none; font-size: small; font-family: @宋体" class="clsunderline"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="fieldTitle">
                        制单员：
                    </td>
                    <td scope="col">
                        <asp:Label ID="lblCMan" runat="server" Width="200px" CssClass="txtline" Text=""></asp:Label>
                    </td>
                    <td class="fieldTitle">
                        制单部门：
                    </td>
                    <td scope="col" style="width: 200px;">
                        <asp:Label ID="lblCDepart" runat="server" Width="200px" CssClass="txtline" Text=""></asp:Label>
                    </td>
                    <td class="row fieldTitle">
                        制单日期：
                    </td>
                    <td class="row" style="width: 200px;">
                        <asp:Label ID="lblCDate" runat="server" Width="200px" CssClass="txtline" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
            </table>
        </div>
        <div class="content">
        
            <table width="100%">
             <tr >
                    <td align="center"  style="background: #F0F0F0" >
                        <span style="font-weight: bold; font-size: 16px;">费用明细</span>
                    </td>
                </tr>
               
              <table id="mytable2" cellspacing="0" class="mytable">
               <tr>
                    <td colspan="4" align="left" style="padding: 10px 0px 5px 10px;" class="select">
                        <a href="javascript:void(0);" class="AddPolicy" style="text-align: left">
                            <img alt="添加费用明细" title="添加费用明细" src="../../Images/public/fileadd.gif" />选择保单</a>
                    </td>
                </tr>
                <tr>
                    <th style="width: 15px; border-right: 1px solid #B9D3EE;" class="clstitleimg">
                        操作
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE;">
                        保单编号
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE;">
                        客户名称
                    </th>
                    <th class="clstitleimg" style="border-right: 1px solid #B9D3EE;">
                        费用金额
                    </th>
                </tr>
               
                <tbody id="policyList" runat="server">
                </tbody>
                 <tbody id="Tbody1">
                                                <tr id="sum" style="color:Blue;">
                                                    <td class="sum-title" colspan="3" align="right">
                                                        合计：
                                                    </td>
                                                    <td id="sumBox">
                                                        0.00
                                                    </td>
                                                </tr>
                                            </tbody>
                                            </table>
            </table>
        </div>
        <div class="content" style="text-align:right">
            <table id="mytable3" class="under" cellspacing="0" style="text-align: right">
                <tr>
                    <td colspan="2" align="right" id="confirmBox" style="padding: 10px;">
                        <asp:CheckBox ID="ChkConfirm" Text="确认登记？" runat="server" />
                        确认之后，发票不能再修改
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <input id="HidComId" type="hidden" runat="server" />
    <input id="HidSalesman" type="hidden" runat="server" />
    <input id="HidPolicy" type="hidden" runat="server" />
    </form>
</body>
</html>
