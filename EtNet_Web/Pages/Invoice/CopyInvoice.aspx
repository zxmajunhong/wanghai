<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopyInvoice.aspx.cs" Inherits="EtNet_Web.Pages.Invoice.CopyInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新发票</title>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/artDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/iframeTools.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="Clock.js" type="text/javascript"></script>
    <style type="text/css">
        a
        {
            color: #c75f3e;
        }
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 40px 10px 40px;
        }
        .mytable
        {
            border: 1px dashed #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: #4f6b72;
        }
        .txtline
        {
            width: 150px;
            border-bottom: 1px solid #A4C2E0;
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
        caption
        {
            padding: 0 0 5px 0;
            width: 100%;
            font: 14px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            font-weight: bold;
            text-align: center;
        }
        
        th
        {
            font: bold 11px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
            color: #4f6b72;
            border-right: 1px solid #C1DAD7;
            border-bottom: 1px solid #C1DAD7;
            border-top: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: left;
            padding: 6px 6px 6px 12px;
            background: #A4C2E0 no-repeat;
        }
        
        th.nobg
        {
            border-top: 0;
            border-left: 0;
            border-right: 1px dashed #C1DAD7;
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
        .td
        {
            border: 1px dashed #4f6b72;
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
        .fieldTitle{width:100px;text-align:right;color:#444;}
        #ChkConfirm{vertical-align:middle;}
        .content{margin-bottom:20px;padding-bottom:5px;}
        #mytable2{border: 1px none #4f6b72;width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: black;}
        #mytable2{border-collapse: collapse;width: 100%;}
        #mytable2 tr{background-color: #FFFFFF;}
        #mytable2 th{border: 1px solid #DED6DC;}
        #mytable2 tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        #mytable2 tr td.select{text-align:left;}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#imgbtnSave').click(function () {
                var txtPolicy = "";
                $("#mytable2 tbody tr").each(function () {
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
                    art.artDialog.open('SelectPolicy.aspx?type=' + type + '&com=' + com + "&sale=" + sale, { width: '600px', height: '320px' }).lock().title('选择保单');
                });
            });
        });

        function addDelCol() {
            $(".delete").html(" ");
            SetNum();
        }
        function SetNum() {
            var price = 0;
            $(".linePrice").each(function () {
                price += parseFloat($(this).val());
            });
            $("#txtSum").val(price);
        }

        function getList(html) {
            $("#mytable2 tbody").html(html);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 5px; font-size: 12px;
                            font-weight: bold;">复制发票</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <div style="text-align: right;">
            <asp:ImageButton runat="server" ID="imgbtnSave" ImageUrl="../../Images/Button/btn_save.jpg"
                OnClick="imgbtnSave_Click" />
            &nbsp;
            <asp:ImageButton runat="server" ID="imgbtnBack" ImageUrl="../../Images/Button/btn_back.jpg"
                OnClick="imgbtnBack_Click" />
        </div>
        <div>
            <table id="mytable" cellspacing="0" class="mytable">
                <caption>
                    基本信息
                </caption>
                <tr>
                    <th scope="col" style="width: 15%">
                        发票号码
                    </th>
                    <td scope="col" class="td" style="width: 200px;">
                        <input id="txtInvoiceID" type="text" runat="server" class="txtline" />
                    </td>
                    <th scope="col" style="width: 15%">
                        发票时间
                    </th>
                    <td scope="col" class="td" style="width: 200px;">
                        <input id="txtInvoiceDate" type="text" runat="server" class="txtline" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',isShowClear:false,readOnly:true,onpicked:function(dp) {$dp.$('txtInvoiceDate').value=getEndTime(dp);}})" />
                    </td>
                    <th scope="col" style="width: 15%">
                        业务员
                    </th>
                    <td scope="col" class="td" style="width: 200px;">
                        <input id="TxtSalesman" type="text" runat="server" class="txtline" />
                        <a href="javascript:void(0);" id="Salesman">
                            <img alt="选择" src="../../Images/public/folder_user.gif" /></a>
                    </td>
                </tr>
                <tr>
                    <th scope="col" style="width: 15%">
                        费用类别
                    </th>
                    <td scope="col" class="td">
                        <asp:DropDownList ID="ddlType" runat="server" class="txtline">
                            <asp:ListItem Value="-1">请选择类别</asp:ListItem>
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
                    <th scope="col" style="width: 15%" class="td">
                        费用金额
                    </th>
                    <td scope="col">
                        <input onfocus="SetNum()" onblur="SetNum()" id="txtSum" type="text" runat="server"
                            class="txtline" />
                    </td>
                    <th scope="col" style="width: 15%" class="td">
                        所属部门
                    </th>
                    <td scope="col">
                        <input id="txtDepart" type="text" runat="server" class="txtline" />
                    </td>
                </tr>
                <tr>
                    <th scope="col" style="width: 15%">
                        开票单位
                    </th>
                    <td scope="col" colspan="5" class="td">
                        <input id="txtUnit" type="text" runat="server" class="txtline" style="width: 400px;" />
                        <a href="javascript:void(0);" class="ComAndPro">
                            <img alt="选择" src="../../Images/public/expand.gif" /></a>
                    </td>
                </tr>
                <tr>
                    <th scope="col" style="width: 15%">
                        备注
                    </th>
                    <td scope="col" colspan="5" class="td" height="56">
                        <asp:TextBox ID="txtRemark" runat="server" Style="width: 500px;" TextMode="MultiLine"
                            CssClass="txtline"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table id="mytable2" cellspacing="0" class="mytable">
                <caption>
                    费用明细</caption>
                <thead>
                    <tr>
                        <th style="width: 15px; text-align: left">
                            <a href="javascript:void(0);" class="AddPolicy">
                                <img alt="添加费用明细" title="添加费用明细" src="../../Images/public/fileadd.gif" /></a>
                        </th>
                        <th scope="col">
                            保单编号
                        </th>
                        <th scope="col">
                            客户名称
                        </th>
                        <th scope="col">
                            费用金额
                        </th>
                    </tr>
                </thead>
                <tbody id="policyList">
                    <asp:Repeater ID="rpPolicyDetial" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="delete">
                                    &nbsp;
                                </td>
                                <td>
                                    <span class="clsblurtxt clsedit">
                                        <%#Eval("policyID") %>
                                </td>
                                <td id="cuscname">
                                    <span class="clsblurtxt clsedit">
                                        <%#Eval("cusName") %></span>
                                </td>
                                <td id="cusshortname">
                                    <span class="clsblurtxt clsedit">
                                        <%#Eval("cost") %></span>
                                    <input id="Text1" class="linePrice" type="text" runat="server" value='<%#Eval("cost") %>'
                                        style="display: none" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table id="mytable3" class="mytable" cellspacing="0">
                <caption>
                    &nbsp;
                </caption>
                <tr>
                    <th scope="col" style="width: 15%">
                        制单员
                    </th>
                    <td scope="col" style="width: 200px;">
                        &nbsp;
                        <asp:Label ID="lblCMan" runat="server" Text="制单员"></asp:Label>
                    </td>
                    <th scope="col" style="width: 15%">
                        制单部门
                    </th>
                    <td scope="col" style="width: 200px;">
                        &nbsp;
                        <asp:Label ID="lblCDepart" runat="server" Text="制单部门"></asp:Label>
                    </td>
                    <th class="row" style="width: 15%">
                        制单日期
                    </th>
                    <td class="row" style="width: 200px;">
                        &nbsp;
                        <asp:Label ID="lblCDate" runat="server" Text="制单日期"></asp:Label>
                        <script type="text/javascript">
                            var clock = new Clock();
                            clock.display(document.getElementById("lblCDate"));
                        </script>
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