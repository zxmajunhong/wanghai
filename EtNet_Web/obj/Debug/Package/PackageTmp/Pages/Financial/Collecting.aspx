<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Collecting.aspx.cs" Inherits="EtNet_Web.Pages.Financial.Collecting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>收款登记</title>
    <link href="../Financial/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
a{color: #000000;}
        .clsbottom{font-size: 12px;border: 1px solid #4CB0D5;padding: 10px;}

        #claimBox{width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: #000000;}    
        #mytable th{font-family: 宋体;font-weight:normal;color: #333;border-right: 1px solid #C1DAD7;border-bottom: 1px solid #C1DAD7;border-top: 1px solid #C1DAD7;letter-spacing: 2px;text-transform: uppercase;text-align: right;padding: 6px 6px 6px 12px;background: #DBE6E3 no-repeat;width:80px;}
      
      
        a img{border:none;}
        
        .border{font-size: 12px;border: 1px solid #4CB0D5;padding: 10px;overflow: auto;min-width: 880px;}
       
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        caption{padding:5px;font-size:14px;font-weight:bold;font-family:微软雅黑;}
        #claimBox{border-collapse: collapse;width: 100%;}
        #claimBox tr{background-color: #FFFFFF;}
        #claimBox th{border: 1px solid #DED6DC;}
        #claimBox tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
         .content
        {
            padding: 5px;
        }
        .content caption
        {
            background-color: #fff;
            border: 0px;
        }
        table.dataBox
        {
            width: 100%;
        }
       
        table.dataBox td
        {
            padding: 5px;
        }
        .fieldTitle
        {
            width: 100px;
            text-align: right;
            color: #444;
            min-width: 100px;
            font-family: 宋体;
            font-weight: normal;
            color: #333;
      
            border: 1px solid #C1DAD7;
            letter-spacing: 2px;
            text-transform: uppercase;
            text-align: right;
            padding: 6px 6px 6px 12px;
            font-weight: bold;
            font-size:12px;
        }
        .lineTable td
        {
            border: 1px solid #C1DAD7;
            padding-left: 5px;
        }
        .lineTable tr
        {
            height: 20px;
            line-height: 20px;
        }
        .lineTable
        {
            border: 1px solid #4f6b72;
            width: 100%;
            padding: 0;
            margin: 0;
            border-collapse: collapse;
            color: #000000;
        }
        
       
        .databox
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
        #mytable2 tr .sum-title
        {
            text-align: right;
        }
        .invoiceCol
        {
            display: none;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        <span style="color: White; vertical-align: bottom; padding-left: 0px; font-size: 12px;
                            font-weight: bold;">收款登记预览</span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <span style="display:block;width:100%;text-align:right;padding-bottom:5px;">
            <asp:ImageButton ID="BtnBack" runat="server" 
            ImageUrl="../../Images/button/btn_back.jpg" onclick="BtnBack_Click" />
        </span>
        <div class="content">
            <table  class="dataBox lineTable">
                 <tr>
                    <td colspan="6" style="text-align: center; background: #F0F0F0;">
                        <span style="font-weight: bold; font-size: 14px;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <th scope="col" class="fieldTitle">
                        收款单号：
                    </th>
                    <td scope="col" style="width: 23%;">
                        <asp:Label ID="LblReceiptNum" runat="server" Text=""></asp:Label>
                    </td>
                    <th scope="col" class="fieldTitle">
                        收款时间：
                    </th>
                    <td scope="col" style="width: 23%;">
                        <asp:Label ID="LblReceiptDate" runat="server" Text=""></asp:Label>
                    </td>
                    <th scope="col" class="fieldTitle">
                        收款金额：
                    </th>
                    <td scope="col" style="width: 23%;">
                        <asp:Label ID="LblReceiptAmount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th scope="col" class="fieldTitle" >
                        经营单位：
                    </th>
                    <td scope="col" >
                        <asp:Label ID="LblBusinessUnit" runat="server" Text=""></asp:Label>
                    </td>
                    <th scope="col" class="fieldTitle">
                        付款单位：
                    </th>
                    <td scope="col" >
                        <asp:Label ID="LblPaymentUnit" runat="server" Text=""></asp:Label>
                    </td>
                    <th scope="col" class="fieldTitle">
                        入帐方式：
                    </th>
                    <td scope="col" >
                        <asp:Label ID="LblPaymentMode" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="paymentInfo" runat="server">
                    <th scope="col" class="fieldTitle">
                        入账银行：
                    </th>
                    <td scope="col" >
                        <asp:Label ID="LblPayBank" runat="server" Text=""></asp:Label>
                    </td>
                    <th scope="col" class="fieldTitle">
                        银行帐号：
                    </th>
                    <td scope="col"  colspan="3">
                        <asp:Label ID="LblPayBankAcount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <th scope="col" class="fieldTitle">
                        备注：
                    </th>
                    <td scope="col" colspan="5" height="50">
                        <asp:Literal ID="LtrMark" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <th  class="fieldTitle">
                        制单员：
                    </th>
                    <td>
                        <asp:Label ID="LblMaker" runat="server" Text=""></asp:Label>
                    </td>
                    <th  class="fieldTitle">
                        制单部门：
                    </th>
                    <td>
                        <asp:Label ID="LblMakeDepartment" runat="server" Text=""></asp:Label>
                    </td>
                    <th  class="fieldTitle">
                        制单日期：
                    </th>
                    <td >
                        <asp:Label ID="LblMakeDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="confirm" runat="server" visible="false">
                    <th class="fieldTitle">
                        确认人：
                    </th>
                    <td>
                        <asp:Label ID="lblConfirmMan" runat="server" Text=""></asp:Label>
                    </td>
                    <th class="fieldTitle">
                        确认日期：
                    </th>
                    <td>
                        <asp:Label ID="lblConfirmDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="td"></td>
                    <th  class="fieldTitle">
                        单据状态：
                    </th>
                    <td  class="fieldTitle">
                        <asp:Literal ID="LtrConfirm" runat="server"></asp:Literal>
                    </td>                   
                </tr>
            </table>
        </div>

        <div style="border:1px solid #CDC9C9;padding:10px;margin-top:20px;">
            <table id="claimBox" style="text-align: center;" cellspacing="1">
            
              
                <thead>
                 <tr>
                    <td colspan="4" style="text-align: center;">
                        <span style="font-weight: bold; font-size: 14px;background: #F0F0F0;">收款认领信息</span>
                    </td>
                </tr>
                    <tr>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 25%;">
                            订单编号
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 25%;">
                            应收金额
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 25%;">
                            本次收款金额
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 25%;">
                            收款备注
                        </th>
                    </tr>
                </thead>
                <tbody id="policyList">
                    <asp:Repeater ID="RpClaimDetail" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("orderNum")%></td>
                                <td><%# Eval("money", "{0:N2}")%></td>
                                <td><%# Eval("realAmount", "{0:N2}")%></td>
                                <td><%# Eval("mark")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
