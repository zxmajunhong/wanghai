﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CollectingList.aspx.cs" Inherits="EtNet_Web.Pages.Financial.CollectingList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .clsbottom{font-size: 12px;border: 1px solid #4CB0D5;padding: 10px;}
        .clsdata{width: 100%;background-color: #B9D3EE;}
        .clsdata tr td{background-color: White;height: 30px;text-align: center;}
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .clstitleimg:hover{color: Black;}
        .topbtnimg{width: 0px;height: 0px;}
        .topimgtxt{font-size: 12px;font-weight: bold;color: #718ABE;cursor: pointer;display: inline-block;margin-top: 4px;margin-right: 6px;}
        .topimgtxt img{height: 14px;width: 14px;margin-right: 0px;margin-bottom: -2px;}
        .toptitletxt{color: White;padding-left: 5px;font-size: 12px;font-weight: bold;width: 100px;}
        a{text-decoration: none;}
        a img{border:none;}
        .paginator{font: 12px Arial, Helvetica, sans-serif;padding: 5px;margin: 0px;}
        .paginator a{border: solid 1px #ccc;color: #0063dc;cursor: pointer;text-decoration: none;}
        .paginator a:visited{padding: 1px 6px;border: solid 1px #61befe;background: #61befe;color: #fff;text-decoration: none;}
        .paginator .cpb{border: 1px solid #61befe;font-weight: 700;color: #fff;background-color: #61befe;}
        .paginator a:hover{border: solid 1px #61befe;color: #fff;background: #61befe;text-decoration: none;}
        .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover{float: left;height: 21px;line-height: 21px;min-width: 10px;_width: 10px;margin-right: 5px;text-align: center;white-space: nowrap;font-size: 12px;font-family: Arial,SimSun;padding: 0 4px;}
        .filterBox{border-bottom:2px solid #4CB0D5;width:100%;height:auto;padding:5px;margin-bottom:10px;}
        .filterInput{width:200px;border-width:0px 0px 1px;border-style: none none solid;border-color: #C6E2FF;}
        input.Wdate{cursor:pointer;width:100px;border-width:0px 0px 1px;border-style: none none solid;border-color: #C6E2FF;}
        #filterBox{display:none;}
        #DdlFilterPayMode{width:200px;}
    </style>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            $("#addtxt").click(function () {
                window.location = "CollectingAdd.aspx";
            })

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=019&dt=" + new Date().toString(), window.self, strmodal);
            })

            $('#filterBtn').click(function () {
                if ($("#filterBox").is(":hidden")) {
                    $(this).find('img').attr('src', '../../Images/public/collapse.gif');
                    $("#filterBox").slideDown(400, function () { });
                    $("#hidFilterState").val("1");
                } else {
                    $(this).find('img').attr('src', '../../Images/public/expand.gif');
                    $("#filterBox").slideUp(400, function () { });
                    $("#hidFilterState").val("0");
                }
            });

            setFilterBox();

            $("#txtFilterPolicyAmount").blur(function () {
                if (isNaN($(this).val())) {
                    $(this).val("");
                }
            });
        });

        function setFilterBox() {
            if ($("#hidFilterState").val() == "1") {
                $("#filterBtn").find('img').attr('src', '../../Images/public/collapse.gif');
                $("#filterBox").show();
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td class="toptitletxt">
                        收款登记
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" /><span>页面设置</span>
                        </span>
                        <span class="topimgtxt" id="addtxt" title="新增收款单据">
                            <img style="margin-right:0px;" alt="新增收款单据" title="新增收款单据" src="../../Images/public/pagedit.png"/><span>新增</span>
                        </span>
                        <span class="topimgtxt" id="filterBtn" title="筛选">
                            <img alt="筛选" src="../../Images/public/expand.gif" /><span>筛选</span>
                        </span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="clsbottom">
        <div id="filterBox">
            <table class="filterBox">
                <tr>
                    <td align="right">收款单号：</td>
                    <td><asp:TextBox class="filterInput" ID="txtFilterNum" runat="server"></asp:TextBox></td>
                    <td align="right">付款单位：</td>
                    <td><asp:TextBox class="filterInput" ID="txtFilterUnit" runat="server"></asp:TextBox></td>
                    <td align="right">入账方式：</td>
                    <td>
                        <asp:DropDownList ID="DdlFilterPayMode" runat="server">
                            <asp:ListItem Value="">全部</asp:ListItem>
                            <asp:ListItem Value="0">现金</asp:ListItem>
                            <asp:ListItem Value="1">转账</asp:ListItem>
                            <asp:ListItem Value="2">网银</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="80px" align="right">收款金额：</td>
                    <td><asp:TextBox class="filterInput" ID="txtFilterPolicyAmount" runat="server"></asp:TextBox></td>
                    <td width="80px" align="right">收款时间：</td>
                    <td>
                        <asp:TextBox class="filterInput Wdate" ID="txtFilterSatrtTime" runat="server"
                            onFocus="var d5222=$dp.$('txtFilterEndTime');WdatePicker({onpicked:function(){txtFilterEndTime.focus();},maxDate:'#F{$dp.$D(\'txtFilterEndTime\')}'})"></asp:TextBox>
                        到
                        <asp:TextBox class="filterInput Wdate" ID="txtFilterEndTime" runat="server"
                            onFocus="WdatePicker({minDate:'#F{$dp.$D(\'txtFilterSatrtTime\')}'})"></asp:TextBox>
                    </td>
                    <td width="80px" align="right">入账银行：</td>  
                    <td><asp:TextBox class="filterInput" ID="txtinbank" runat="server"></asp:TextBox></td>          
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan="2" align="right" style="padding-left:20px;">
                        <asp:ImageButton runat="server" ID="btnFilter" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="BtnFilter_Click" />
                        <asp:ImageButton runat="server" ID="btnResetFilter" ImageUrl="~/Images/Button/btn_reset.jpg"
                            OnClick="BtnResetFilter_Click" />
                    </td>   
                </tr>
            </table>         
        </div>
        <table class="clsdata" cellpadding="0" cellspacing="1">
            <thead>
                <tr>
                    <th width="150px" class="clstitleimg">
                        认领进度
                    </th>                      
                    <th width="150px" class="clstitleimg">
                        收款单号
                    </th>
                    <th width="100px" class="clstitleimg">
                        收款日期
                    </th>
                    <th width="100px" class="clstitleimg">
                        收款金额
                    </th>
                    <th width="200px" class="clstitleimg">
                        付款单位
                    </th>
                    <th width="80px" class="clstitleimg">
                        入账方式
                    </th>
                    <th width="200px" class="clstitleimg">
                        入账银行
                    </th>
                    <%--<th width="200px" class="clstitleimg">
                        经营单位
                    </th>--%>
                    <th width="80px" class="clstitleimg">
                        制单员
                    </th>                  
                    <th width="80px" class="clstitleimg">
                        确认登记
                    </th>
                    <th width="180px" class="clstitleimg">
                        备注
                    </th>
                    <th width="170px" class="clstitleimg">
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RpList" runat="server" onitemcommand="RpList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("receiptStatusCode") == null ? "<font color='red'>未开始</font>" : (Eval("receiptStatusCode").ToString() == "0" ? "<font color='red'>未开始</font>" : (Eval("receiptStatusCode").ToString()=="1"?"<font color='green'>认领中</font>":"已完成"))%></td>
                            <td><%# Eval("receiptNum") %></td>
                            <td><%# DateTime.Parse(Eval("receiptDate").ToString()).ToString("yyyy-MM-dd") %></td>
                            <td>￥<%# Eval("receiptAmount","{0:f2}") %></td>
                            <td><%# Eval("paymentUnit") %></td>
                            <td><%# ChangePaymentMode(Eval("paymentMode").ToString()) %></td>
                            <td><%# Eval("payBank") %></td>
                          <%--  <td><%# Eval("businessUnit") %></td>--%>
                            <td><%# Eval("marker") %></td>
                            <td><%# Eval("confirmReceipt").ToString()=="0"?"<font color='red'>未确认</font>":"已确认" %></td>
                             <td><%# Eval("receiptMark")%></td>
                            <td style="text-align:left;padding-left:2px;">
                                <asp:ImageButton ID="BtnEdit" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("ID")+","+Eval("confirmReceipt")+","+Eval("marker") %>'
                                   ImageUrl="../../Images/public/edit.gif" alt="编辑" ToolTip="编辑"  ></asp:ImageButton>

                                <%--<a href='<%# "CollectingEdit.aspx?id="+Eval("id")+"&action=0" %>' title="复制单据" runat="server"
                                    Visible='<%# GetVisible(Convert.ToInt32(Eval("markerID"))) %>' >
                                    <img src="../../Images/public/page_copy.png" alt="复制单据" />
                                </a>--%>

                               <%-- <a href='<%# "Collecting.aspx?id="+Eval("id")+"&returnUrl=CollectingList.aspx" %>' title="预览">
                                    <img src="../../Images/public/searchform.png" alt="预览" />
                                </a>--%>
                                 <asp:ImageButton ID="ImageButton1" runat="server" title="预览" CommandName="search"
                                                CommandArgument='<%# Eval("id")%>' ImageUrl="~/Images/Public/searchform.png" />

                                <asp:ImageButton  ID="BtnDelete" runat="server" OnClientClick="return window.confirm('确认删除吗?');"
                                    CommandName="DELETE" CommandArgument='<%# Eval("ID")+","+Eval("confirmReceipt")+","+Eval("marker") %>' ImageUrl="../../Images/public/delete.gif"
                                     alt="删除" ToolTip="删除" Visible='<%# IsSelf(Eval("markerID")) %>' ></asp:ImageButton>

                                <asp:ImageButton ID="BtnConfirm" runat="server" CommandName="confirm" CommandArgument='<%# Eval("ID") %>' alt="登记确认" ToolTip="登记确认"
                                    ImageUrl="~/Images/icons/tick.png" Visible='<%# Eval("confirmReceipt").ToString() !="1" %>' />
                                <asp:ImageButton  ID="BtnCancelConfirm" runat="server" OnClientClick="return window.confirm('确定要取消确认吗?');"
                                    CommandName="CANCEL" CommandArgument='<%# Eval("ID") %>' ImageUrl="../../Images/public/pic25.gif"
                                    alt="撤销确认" ToolTip="撤销确认" 
                                    Visible='<%# Eval("confirmReceipt").ToString()=="1"%>'></asp:ImageButton>  
                                     <asp:ImageButton  ID="btnzhuanhua" runat="server" OnClientClick="return window.confirm('确定要对该项进行转化吗?');"
                                    CommandName="CHANGE" CommandArgument='<%# Eval("ID") %>' ImageUrl="../../Images/public/load.png"
                                    alt="转化确认" ToolTip="转化确认" style='<%# IsShow(Eval("receiptStatusCode") == null ? "0" : Eval("receiptStatusCode").ToString() == "0" ?"0":"1") %>'></asp:ImageButton>                                                                   
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                   <tr>
                    <td>
                        合计：
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                       <asp:Label ID="zje" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        &nbsp
                    </td>
                </tr>

            </tbody>
        </table>

        <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
            runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
            PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
            CustomInfoTextAlign="Left" LayoutType="Table" PageIndexBoxType="DropDownList"
            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </div>
    <input id="hidFilterState" value="0" runat="server" type="hidden" />
    </form>
</body>
</html>
