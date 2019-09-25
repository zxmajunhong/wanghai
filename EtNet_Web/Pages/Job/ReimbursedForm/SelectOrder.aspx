<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectOrder.aspx.cs" Inherits="EtNet_Web.Pages.Job.ReimbursedForm.SelectOrder" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../../Financial/css/jPages.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/AspNetPager/AspNetPager.css" />
    <script src="../../Financial/js/jPages.min.js" type="text/javascript"></script>
           <script src="../../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
      <script src="../../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
       <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
          <script src="../../../Scripts/customdate.js" type="text/javascript"></script>

    <style type="text/css">
        body{font-size:12px;} 
        a{text-decoration:none;}
        a img{border:none;}
        .clstitleimg{background-image: url('../../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .clsdata{border: 1px none #4f6b72;width: 100%;padding: 0;margin: 0;border-collapse: collapse;color: black;background-color: #B9D3EE;}
        .clsdata{border-collapse: collapse;width: 100%;}
        .clsdata tr{background-color: #FFFFFF;}
        .clsdata th{border: 1px solid #DED6DC;}
        .clsdata tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        .clsdata tr.hover td,.clsdata tr.hover input
        {
            background-color: #FFEFBB !important;
            cursor: pointer;
        }
        .clsdata tr.selected td,.clsdata tr.selected input
        {
            background-color: #FFECB5 !important;
        }
        tr.odd td,tr.odd input
        {
            background-color: #E3EBEF !important;
        }
        td,input{font-size:12px;}
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        input.filterInput
        {
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
        .clssift
        {
            width: 100%;
        }
    </style>
    <script type="text/javascript">
            $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //按照条件判断是否显示筛选栏
            function fist() {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();


            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../Images/public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");
                }
                else {
                    $("#sifttxt img").attr("src", "../../Images/public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }

            })

            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=090&dt=" + new Date().toString(), window.self, strmodal);
            })


  //指定时间
            $("#selDate").click(function () {
                cdate({ sid: "dateBox", hid: "hidDateValue" });
                $("#ddlRequestDate").val(5);
            })

            //选时间段
            $("#ddlRequestDate").change(function () {
                if ($(this).val() == "5") {
                    $("#selDate").click();
                }
                else {
                    $("#dateBox").text("");
                    $("#hidDateValue").val("");
                }
            })

        })


        $(document).ready(function () {
            $('.clsdata tbody tr').each(function () {
                $(this).hover(function () {
                    $(this).toggleClass('hover');
                });
                $(this).click(function () {
                    if ($(this).hasClass("selected")) {
                        $(this).removeClass("selected").find('input').removeAttr("checked");
                    }
                    else {
                        $(this).addClass('selected')
                                        .find('input').attr('checked', 'checked');
                    }
                });
            });

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td,.clsdata tr:odd input").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            $('#saveBack').click(function () {
                debugger;
                var origin = artDialog.open.origin;
                if ($('tr.selected').length == 0) {
                    alert('请选择订单');
                    return;
                }

                var listHTML = "";
                $('tr.selected').each(function () {
                    listHTML += "<tr>";
                    listHTML += $(this).html();
                    listHTML += "</tr>";
                })
                //list.innerText = listHTML;
                window.parent.getList(listHTML);

                //window.parent.addDelCol();

                art.dialog.close();
            });

            $('#cancel').click(function () {
                art.dialog.close();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" value="0" id="hidsift" />
     <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        选择订单
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../../Images/public/layoutedit.png" />&nbsp;<span>页面设置</span></span>
                       <span class="topimgtxt" id="sifttxt" title="筛选">
                            <img alt="筛选" title="筛选" src="../../../Images/public/collapse.gif" />&nbsp;<span>筛选</span>
                        </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    </div>
    <div class="clsbottom">
        <table class="clssift">
            <tr>
                <td align="right" style="width: 60px;">
                    旅游线路:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLine" runat="server" Style="margin-left: 10px;" Width="150">
                        <asp:ListItem Text="手动填写" Value="-1">
                                请选择
                        </asp:ListItem>
                        <asp:ListItem Text="常规类型" Value="1">
                                常规类型
                        </asp:ListItem>
                        <asp:ListItem Text="非常规类型" Value="2">
                                非常规类型
                        </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" style="width: 60px;">
                    出团日期:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlRequestDate" CssClass="filterInput" runat="server">
                        <asp:ListItem Value="-1">——请选择——</asp:ListItem>
                        <asp:ListItem Value="0">——今天——</asp:ListItem>
                        <asp:ListItem Value="1">——今天之前——</asp:ListItem>
                        <asp:ListItem Value="2">——昨天——</asp:ListItem>
                        <asp:ListItem Value="3">——7天内——</asp:ListItem>
                        <asp:ListItem Value="4">——15天内——</asp:ListItem>
                        <asp:ListItem Value="5">——指定范围——</asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../../Images/public/calendar.png" id="selDate" style="cursor: pointer;"
                        alt="选取时间范围" /><br />
                    <span id="dateBox"></span>
                    <input id="hidDateValue" type="hidden" runat="server" />
                </td>
                <td align="right" style="width: 60px;">
                    性质:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtNature" class="filterInput" />
                </td>
            </tr>
            <tr>
                <td style="width: 60px;" align="right">
                    订单序号:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtOrderNum" class="filterInput" />
                </td>
                <td align="right" style="width: 60px;">
                    线路描述:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtTourRemark" class="filterInput" />
                </td>
                <td align="right" style="width: 60px;">
                    操作员:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddloperator" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 60px;" align="right">
                    保存状态:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlsavestatus" runat="server" Width="150px">
                        <asp:ListItem Text="——请选择——" Value=""></asp:ListItem>
                        <asp:ListItem Text="草稿" Value="草稿"></asp:ListItem>
                        <asp:ListItem Text="已提交" Value="已提交"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 60px;" align="right">
                    结算状态:
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="ddlaudtistatus" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
    <div>
        <asp:Repeater ID="rpOrderList" runat="server">
            <HeaderTemplate>
                <table id="mytable2" style="text-align:center;" cellspacing="1" class="clsdata">
                   <thead>
                    <tr>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 5%;">
                            选择
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                            订单序号
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                            订单类型
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                            出团日期
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                            性质
                        </th>
                        <th class="clstitleimg" style="border-right: 1px solid #B9D3EE; width: 19%;">
                            旅游线路
                        </th>
                    </tr>
                   </thead>
                   <tbody id="orderList">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="del">
                        <input id="Checkbox1" type="checkbox" />
                    </td>
                    <td class="orderNum">
                        <%# Eval("orderNum") %>
                    </td>
                    <td class="orderType">
                        <%# Eval("orderType") %>
                    </td>
                    <td class="outTime">
                        <%# Eval("outTime","{0:yyyy-MM-dd}") %>
                    </td>
                    <td class="natrue">
                        <%# Eval("natrue") %>
                    </td>
                    <td class="line">
                        <%# Eval("line") %>
                    </td>
                    <td class="orderId" style="display:none">
                        <%# Eval("id") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
              </table>
            </FooterTemplate>
        </asp:Repeater>
        <webdiyer:aspnetpager id="AspNetPager1" cssclass="paginator" currentpagebuttonclass="cpb"
            runat="server" firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页" custominfohtml="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
            prevpagetext="上一页" showcustominfosection="Left" onpagechanged="AspNetPager1_PageChanged"
            custominfotextalign="Left" layouttype="Table" pageindexboxtype="DropDownList"
            showpageindexbox="Always" submitbuttontext="Go" textafterpageindexbox="页" textbeforepageindexbox="转到">
        </webdiyer:aspnetpager>
        <table style="width:100%;margin-top:10px;">
            <tr>
                <td align="right">
                    <a href="javascript:void(0);" id="saveBack">
                        <img alt="保存" src="../../../Images/Button/btn_sure.jpg" /></a><a href="javascript:void(0);"
                            id="cancel">
                            <img alt="取消" src="../../../Images/Button/btn_cancel.jpg" /></a>
                </td>
            </tr>
        </table> 
    </div>
    </div>
    </form>
</body>
</html>
