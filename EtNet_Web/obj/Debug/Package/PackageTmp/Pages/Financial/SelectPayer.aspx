<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectPayer.aspx.cs" Inherits="EtNet_Web.Pages.Financial.SelectPayer" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../Policy/tab.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body{width:600px;}
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
        .paginator{font: 12px Arial, Helvetica, sans-serif;padding: 5px;margin: 0px;}
        .paginator a{border: solid 1px #ccc;color: #0063dc;cursor: pointer;text-decoration: none;}
        .paginator a:visited{padding: 1px 6px;border: solid 1px #61befe;background: #61befe;color: #fff;text-decoration: none;}
        .paginator .cpb{border: 1px solid #61befe;font-weight: 700;color: #fff;background-color: #61befe;}
        .paginator a:hover{border: solid 1px #61befe;color: #fff;background: #61befe;text-decoration: none;}
        .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover{float: left;height: 21px;line-height: 21px;min-width: 10px;_width: 10px;margin-right: 5px;text-align: center;white-space: nowrap;font-size: 12px;font-family: Arial,SimSun;padding: 0 4px;}
    </style>
    <script type="text/javascript">
        $(document).ready(
            function () {
                $('#customerTable tbody tr').each(function () {
                    $(this).hover(function () {
                        $(this).toggleClass('hover');
                    });
                    $(this).click(function () {
                        $(this).addClass('selected').siblings().removeClass('selected').end()
                            .find(':radio').attr('checked', 'checked');
                        $(this).siblings().find(':radio').removeAttr('checked');
                        $('#companyTable tbody tr').each(function () {
                            $(this).removeClass('selected').find(':radio').removeAttr('checked');
                        });
                        $("#selectInfo").html('您选择了<font color="red">客户：</font>' + $(this).find(".cusSName").text());
                        $("#hidInfo").val(encodeURI('您选择了<font color="red">客户：</font>' + $(this).find(".cusSName").text()));
                        $("#hidPayerType").val("0");
                        $("#hidPayerName").val($(this).find(".cusSName").text());
                        $("#hidPayerID").val($(this).find(".cusID").text());
                        $("#hidPayerCode").val($(this).find(".cusCode").text());
                    });
                });
                
                $("#companyTable tbody tr").each(function () {
                    $(this).hover(function () {
                        $(this).toggleClass('hover');
                    });
                    $(this).click(function () {
                        $(this).addClass('selected').siblings().removeClass('selected').end()
                            .find(':radio').attr('checked', 'checked');
                        $(this).siblings().find(':radio').removeAttr('checked');
                        $('#customerTable tbody tr').each(function () {
                            $(this).removeClass('selected').find(':radio').removeAttr('checked');
                        });
                        $("#selectInfo").html('您选择了<font color="red">公司：</font>' + $(this).find(".comSName").text());
                        $("#hidInfo").val(encodeURI('您选择了<font color="red">公司：</font>' + $(this).find(".comSName").text()));
                        $("#hidPayerType").val("1");
                        $("#hidPayerName").val($(this).find(".comSName").text());
                        $("#hidPayerID").val($(this).find(".comID").text());
                        $("#hidPayerCode").val($(this).find(".comCode").text());
                    });
                });

                $("#selectInfo").html(decodeURI($("#hidInfo").val()));
                $(".clsdata tbody>tr:odd").addClass("odd");

                $("#" + $("#hidTabSatae").val()).addClass("selectTag").siblings().removeClass("selectTag");
                if ($("#hidTabSatae").val() == "tagContent0") {
                    $("#tag1").removeClass("selectTag");
                    $("#tag0").addClass("selectTag");
                }
                else {
                    $("#tag0").removeClass("selectTag");
                    $("#tag1").addClass("selectTag");
                }
            }
        );

        function Save() {
            if ($('#hidPayerID').val() == "") {
                alert("请选择付款单位");
                return;
            }
            var origin = artDialog.open.origin;
            var payerName = origin.document.getElementById('txtPayerName');
            var payerID = origin.document.getElementById('hidPayerID');
            var payerType = origin.document.getElementById('hidPayerType');
            var payerCode = origin.document.getElementById('txtPayerCode');
            payerName.value = $.trim($("#hidPayerName").val());
            payerID.value = $.trim($("#hidPayerID").val());
            payerType.value = $.trim($("#hidPayerType").val());
            payerCode.value = $.trim($("#hidPayerCode").val());

            $("#form1").html("<img alt=\"正在加载....\" src=\"../../artDialog4.1.6/skins/icons/loading.gif\" style=\"width:16px;height:16px;margin-left:300px;margin-top:200px;\" />");
            //$("#form1").html("<div class=\"aui_main\" style=\"width: 620px; height: 430px;\"><div class=\"aui_content\" style=\"padding: 20px 25px;\"><div class=\"aui_loading\"><span><img alt=\"正在加载....\" src=\"../../artDialog4.1.6/skins/icons/loading.gif\" /></span></div></div></div>");
            window.parent.loadBankInfo();
            
            art.dialog.close();
        }

        function Cancel() {
            art.dialog.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="con">
            <ul id="tags">
                <li id="tag0" class="selectTag">
                    <a onclick="selectTag('tagContent0',this)" href="javascript:void(0)">投保客户</a> 
                </li>
                <li id="tag1">
                    <a onclick="selectTag('tagContent1',this)" href="javascript:void(0)">保险公司</a>
                </li>
            </ul>
            <div id="tagContent">
                <div class="tagContent selectTag" id="tagContent0">
                    <table id="customerTable" class="clsdata" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <th width="40px" class="clstitleimg">
                                    选择
                                </th>
                                <th width="80px" class="clstitleimg">
                                    客户代码
                                </th>
                                <th width="100px" class="clstitleimg">
                                    客户简称
                                </th>
                                <th  width="200px"class="clstitleimg">
                                    客户名称
                                </th>
                                <th style="display: none">
                                    id
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RpCustomerList">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input id="Radio1" type="radio" />
                                        </td>
                                        <td class="cusCode">
                                            <%#Eval("cusCode") %>
                                        </td>
                                        <td class="cusSName">
                                            <%# Eval("cusShortName") %>
                                        </td>
                                        <td class="cusName">
                                            <%#Eval("cusCName") %>
                                        </td>
                                        <td style="display: none" class="cusID">
                                            <%# Eval("id")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
                        CustomInfoTextAlign="Left" LayoutType="Table" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                    </webdiyer:AspNetPager>
                </div>
                <div class="tagContent" id="tagContent1">
                    <table id="companyTable" class="clsdata" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <th width="40px" class="clstitleimg">
                                    选择
                                </th>
                                <th width="80px" class="clstitleimg">
                                    公司代码
                                </th>
                                <th width="100px" class="clstitleimg">
                                    公司简称
                                </th>
                                <th width="200px" class="clstitleimg">
                                    公司名称
                                </th>
                                <th style="display: none">
                                    id
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="RpCompanyList">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input id="Radio1" type="radio" />
                                        </td>
                                        <td class="comCode">
                                            <%#Eval("comCode") %>
                                        </td>
                                        <td class="comSName">
                                            <%# Eval("comShortName") %>
                                        </td>
                                        <td class="comName">
                                            <%#Eval("comCName") %>
                                        </td>
                                        <td style="display: none" class="comID">
                                            <%# Eval("id")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <webdiyer:AspNetPager ID="AspNetPager2" CssClass="paginator" CurrentPageButtonClass="cpb"
                        runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager2_PageChanged"
                        CustomInfoTextAlign="Left" LayoutType="Table" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                    </webdiyer:AspNetPager>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <div id="selectInfo">
                您尚未选择付款单位
            </div>
            <div style="text-align:right;padding-top:5px;">
                <a href="javascript:void(0);" onclick="Save();" id="save" title="保存">
                    <img alt="保存" src="../../Images/Button/btn_save.jpg" />
                </a>
                <a href="javascript:void(0);" onclick="Cancel();" id="cancel" title="取消">
                    <img alt="取消" src="../../Images/Button/btn_cancel.jpg" />
                </a>
            </div>
        </div>

        

        <input id="hidTabSatae" type="hidden" value="tagContent0" runat="server" />
        <input id="hidInfo" type="hidden" value="您尚未选择付款单位" runat="server" />
        <input id="hidPayerType" type="hidden" value="" runat="server" />
        <input id="hidPayerName" type="hidden" value="" runat="server" />
        <input id="hidPayerID" type="hidden" value="" runat="server" />
        <input id="hidPayerCode" type="hidden" value="" runat="server" />
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

                $("#hidTabSatae").val(showContent);
            }
        </script>
    </form>
</body>
</html>