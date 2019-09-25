<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReimbursedForm.aspx.cs" Inherits="EtNet_Web.Pages.Job.ReimbursedForm.PrintReimbursedForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="common.css" rel="stylesheet" type="text/css" />
    <link href="print.css" rel="stylesheet" media="print" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        *{font-size:12px;}
        .content{margin-bottom:0px;padding-bottom:0px;padding-left:0px;padding-right:0px;}
        .content caption{background-color:#fff;border:0px;}
        table.dataBox{width:100%;
            height: 170px;
        }
        td.fieldTitle{width:100px;text-align:center;color:#444;min-width:100px;height:10px}
        table.dataBox td{padding:5px 5px 5px 5px;}
        table.dataBox td.fieldTitle,table.ausDetailTable thead td{font-family: 宋体;font-weight:bold;color: #333;border-right: 1px solid #C1DAD7;border-bottom: 1px solid #C1DAD7;border-top: 1px solid #C1DAD7;letter-spacing: 2px;text-transform: uppercase;padding: 6px 6px 6px 12px;}
        .lineTable td{border: 1px solid #C1DAD7;padding-left:5px;}
        .lineTable tr{height:10px;line-height:10px;}
        .lineTable{border: 1px solid #4f6b72;width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: #000000;}
        
        .clstitleimg{background-image: url('../../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .dataBox{border: 1px none #4f6b72;width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: black;}
        #mytable2{border-collapse: collapse;width: 100%;}
        #mytable2 tr{background-color: #FFFFFF;}
        #mytable2 th{border: 1px solid #DED6DC;}
        #mytable2 tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        td.ausDetail table.ausDetailTable td.sum-title{text-align:left;}
        table.ausDetailTable tr td.sumBox{border-right:none;}
        
        div.buttonBox{position:absolute;top:10px;right:15px;}
        div.topTitle{background:none;width:100%;text-align:center;}
        div.topTitle span{color:#000;font-size:13px;width:100%;}
        div#printBox{width:213mm;
padding:0px 5px 0px 5px;
            height: 472px;
        }
        table.dataBox td.ausDetail{padding:0px !important;border:0px 0px 0px 1px;}
        table.dataBox td.ausDetail td{text-align:center;}
        .style2
        {
            width: 65px;
        }
        .style4
        {
            width: 70px;
        }
    </style>
    <style media="print" type="text/css">
        div.buttonBox{display:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="buttonBox" style="margin:30px 0 0 0">
            <a href="javascript:void(0);" onclick="window.print();" title="打印"><img alt="打印" src="../../../Images/button/btn_print.jpg" /></a>
            <a href="javascript:void(0);" onclick="self.close();" title="关闭"><img alt="关闭" src="../../../Images/button/btn_close.jpg" /></a>
        </div>

        <div id="printBox">
            <div class="topTitle">
                <span></span>
            </div>

            <div class="wrapper" 
                
                style="margin:30px 0 0 10px;width:91.5%;padding-top:5px;padding-bottom:5px; height: 371px;">

                <div class="content" >
                    <table class="dataBox lineTable">
                        <caption>报销申请单</caption>
                        <tr>
                            <td class="fieldTitle">报销单号:</td>
                            <td width="21%">
                                <asp:Label ID="lblnumbers" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="fieldTitle" >报销日期:</td>
                            <td width="21%">
                                <asp:Label ID="lblapplydate" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="fieldTitle" >填单人员:</td>
                            <td width="21%">
                                <asp:Label ID="lblcanme" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td class="fieldTitle">费用类别：</td>
                            <td>
                                <asp:Label ID="lblreimbursedsort" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="fieldTitle">报销金额：</td>
                            <td>
                                <asp:Label ID="lblSum1" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="fieldTitle">所属部门：</td>
                            <td>
                                <asp:Label ID="lbldepart" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td class="fieldTitle">报销类别：</td>
                            <td>
                                <asp:Label ID="lblbillstate" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="fieldTitle">费用归属：</td>
                            <td colspan="3">
                                <asp:Label ID="lblbelongsort" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldTitle">备注:</td>
                            <td colspan="5" style="height:30px;">
                                <asp:Literal ID="lblremark" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" class="ausDetail">
                                <table class="dataBox lineTable ausDetailTable">
                                    <thead>
                                        <tr>
                                            <td class="style2">
                                                发生日期
                                            </td>
                                            <td class="style2">
                                                项目类别
                                            </td>
                                            <td class="style2">
                                                发票内容
                                            </td>
                                            <td class="style2">
                                                部门
                                            </td>
                                            <td class="style2">
                                                报销人员
                                            </td>
                                            <td class="style2">
                                                票据张数
                                            </td>
                                            <td class="style2">
                                                报销金额
                                            </td>
                                            <td>
                                                详细说明
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpAusDetail" runat="server">
                                            <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("happendate","{0:d}")%></td>
                                                <td><%# Eval("ausname")%></td>
                                                <td><%# Eval("austype")%></td>
                                                <td><%# Eval("belongsort")%></td>
                                                <td><%# Eval("Salesman")%></td>
                                                <td><%# Eval("billnum")%></td>
                                                <td><%# Eval("ausmoney","{0:C}")%></td>
                                                <td><%# Eval("remark")%></td>
                                            </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr id="sum" style="color:Blue;">
                                            <td class="sum-title" colspan="6" align="left">
                                                合计人民币（大写）：<asp:Label ID="lblRMB" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td class="sumBox" style="width: 65px">
                                                <asp:Label ID="lblSum" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td style="border-left:none;" class="style4"></td>
                                        </tr>
                                        <tr>
                                            <td class="fieldTitle" style="width: 65px">审批人签名:</td>
                                            <td colspan="4" class="sum-title">
                                                <asp:Literal ID="ltrOptinion" runat="server"></asp:Literal>
                                            </td>
                                            <td class="fieldTitle" style="width: 65px">申请人签名:</td>
                                            <td class="style4" colspan="2"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
               
            </div>
        </div>
        <script type="text/javascript">
//            $(document).ready(function () {
//                var row = "<tr><td>&nbsp</td><td>&nbsp</td><td>&nbsp</td><td>&nbsp</td><td>&nbsp</td></tr>";
//                var row2 = row + row;
//                var row3 = row + row2;

//                if ($("table.ausDetailTable tbody tr").length == 4) {
//                    $("tr#sum").before(row);
//                }
//                else if ($("table.ausDetailTable tbody tr").length == 3) {
//                    $("tr#sum").before(row2);
//                }
//                else if ($("table.ausDetailTable tbody tr").length == 2) {
//                    $("tr#sum").before(row3);
//                }
//            });
        </script>
    </form>
</body>
</html>
