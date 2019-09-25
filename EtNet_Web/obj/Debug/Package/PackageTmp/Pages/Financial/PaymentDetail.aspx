<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentDetail.aspx.cs" Inherits="EtNet_Web.Pages.Financial.PaymentDetail" %>

<%@ Register Src="../Finance/BudgetPre.ascx" TagName="BudgetPre" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../Policy/tab.css" rel="stylesheet" type="text/css" />
    <link href="../Product/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body{width:600px;overflow-x:hidden;}
        #selectInfo{margin:0px -1px 0px -1px;height:30px;line-height:30px;background:#F5F5F5;font-size:12px;color:#333333;border:1px solid #D4D4D4;border-top:0px;padding-left:10px;}
        .clsdata{border-collapse: collapse;width: 100%;}
        .clsdata tr{background-color: #FFFFFF;}
        .clsdata th{border: 1px solid #DED6DC;}
        .clsdata tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .clsdata tr.hover td{background-color: #FFEFBB;cursor: pointer;}
        .clsdata tr.selected td{background-color: #FFECB5;}
        tr.odd td{background-color: #E3EBEF;}
        a{text-decoration: none;}
        a img{border:none;}
        #lblEmptyMsg{padding:10px;text-align:center;height:50px;line-height:50px;}
    </style>
    <style type="text/css">
        
        #top-left
        {
            width: 500;
            float: left;
            display:none;
        }
        #top-right
        {
            width: 580px;
            float: left;
        }
        #top-right th{height:24px;text-align:center}
        .tabledata input
        {
            width: 95%;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        .tabledata {width:98% !important;}
        .tabledata input.num
        {
            width: 70%;
        }
        img
        {
            border: none;
        }
        a
        {
            text-decoration: none;
        }
#tagContent{width:95%;}
        #tagContent input
        {
            background: none;
            border: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(
            function () {
                $('#customerTable tbody tr').each(function () {
                    $(this).hover(function () {
                        $(this).toggleClass('hover');
                    });
                });

                $("#companyTable tbody tr").each(function () {
                    $(this).hover(function () {
                        $(this).toggleClass('hover');
                    });

                $(".clsdata tbody>tr:odd").addClass("odd");

            }
        );

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="con">
            <ul id="tags">
                <li id="tag0" class="selectTag">
                    <a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">盈亏测算</a> 
                </li>
                <li id="tag1">
                    <a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">支付详细</a>
                </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <uc1:BudgetPre ID="UCBudget" runat="server" />
                </div>
                <div class="tagContent" id="tagContent1" style="padding-bottom:10px;">
                    <table id="companyTable" class="clsdata" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <th width="25%" class="clstitleimg">
                                    付款金额
                                </th>
                                <th width="25%" class="clstitleimg">
                                    付款时间
                                </th>
                                <th width="25%" class="clstitleimg">
                                    付款名称
                                </th>
                                <th width="25%" class="clstitleimg" style="display:none">
                                    付款类别
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RpPaymentDetail">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("payAmount")%></td>
                                        <td><%# Eval("requestDate","{0:D}")%></td>
                                        <td><%# GetPayForName(Eval("payFor"))%></td>
                                        <td style="display:none"><%# Eval("paymentType").ToString().Trim()=="0"?"无票付款":"有票付款"%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <asp:Label ID="lblEmptyMsg" runat="server" ForeColor="Red" Visible="false" Text="暂时没有付款记录"></asp:Label>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div id="selectInfo">
                <asp:Literal ID="ltrPolicyInfo" runat="server"></asp:Literal>
            </div>
        </div>

        <script type="text/javascript">
            function selectTag(showContent, selfObj) {
                // 操作标签
                var tag = document.getElementById("tags").getElementsByTagName("li");
                var taglength = tag.length;
                for (i = 0; i < taglength; i++) {
                    tag[i].className = "";
                }
                selfObj.parentNode.className = "selectTag";
                // 操作内容
                for (i = 0; j = document.getElementById("tagContent" + i); i++) {
                    j.style.display = "none";
                }
                document.getElementById(showContent).style.display = "block";

                if (showContent == "tagContent0") {
                    $("#tagContent").width("95%");
                } else { 
                    $("#tagContent").width("98%");
                }
            }
        </script>
    </form>
</body>
</html>
