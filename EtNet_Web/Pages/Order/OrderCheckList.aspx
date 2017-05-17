<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderCheckList.aspx.cs"
    Inherits="EtNet_Web.Pages.Order.OrderCheckList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单查看</title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
    <link href="../Permission/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/AspNetPager/AspNetPager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 5px 10px 5px;
        }
        .clsdata
        {
            width: 100%;
            background-color: #B9D3EE;
        }
        .clsdata tr td
        {
            background-color: White;
            height: 30px;
            text-align: center;
        }
        .clssift
        {
            width: 100%;
        }
        .clsunderline
        {
            width: 150px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: center;
        }
        .clstitleimg:hover
        {
            color: Black;
        }
        .topbtnimg
        {
            width: 0px;
            height: 0px;
        }
        .topimgtxt
        {
            font-size: 12px;
            font-weight: bold;
            color: #718ABE;
            cursor: pointer;
            display: inline-block;
            margin-top: 4px;
            margin-right: 6px;
        }
        .topimgtxt img
        {
            height: 14px;
            width: 14px;
            margin-right: -6px;
            margin-bottom: -2px;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .style2
        {
            width: 100px;
        }
        .filterInput
        {
            width: 200px;
        }
        input.filterInput
        {
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Permission/jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/customdate.js" type="text/javascript"></script>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function clickLink(id) {
            art.dialog.open('CusLinkInfo.aspx?id=' + id).lock().title('联系人');
        }
        function clickSet() {
            art.dialog.open('../Common/PageSearchSet.aspx?pagenum=001').lock().title('设置');
        }
        function clickBank(id) {
            art.dialog.open('CusBankInfo.aspx?id=' + id).lock().title('银行信息');
        }


        function share(cid) {
            art.dialog.open('ShareCus.aspx?id=' + cid, { title: '权限设置', width: 600 }).lock();
        }

        //查看订单信息
        function getOrder(orderId) {
            if (orderId != "")
                window.open('OrderDetial.aspx?id=' + orderId);
            else
                alert('参数错误，找不到该订单');
        }


        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //新增
            $("#addtxt").click(function () {
                $("#imgbtnadd").click();
            })

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
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=013&dt=" + new Date().toString(), window.self, strmodal);
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


         var setting = {
                data: {
                    simpleData: {
                        enable: true
                    }
                },
                callback:{
                  onClick: function(event,treeId,treeNode){                 
                     $("#hidsort").val(treeNode.id);                
                     $("#imgbtnsearch").click();
                  }
               }
       
            };
            //tree控件
            var zNodes = <%= result %>
            $.fn.zTree.init($("#ztree"), setting, zNodes);
            var ZtreeObject =  $.fn.zTree.getZTreeObj("ztree");
            function SetStyle(treeobj)
            {
               var nodeid = $("#hidsort").val();
               if(nodeid !="")
               {                             
                   var node =  treeobj.getNodeByParam("id",nodeid,null);            
                   // var node = treeobj.getNodeByTId(nodeid);       
                   if(node != null)
                   {       
                     treeobj.selectNode(node);
                   }
               }         
            }
            SetStyle(ZtreeObject)
        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" value="0" id="hidsift" />
    <input type="hidden" runat="server" id="hidsort" value="" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        订单查看
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" />&nbsp;<span>页面设置</span></span>
                        <span class="topimgtxt" id="addtxt" title="新增">
                            <img alt="新增" title="新增" src="../../Images/public/pagedit.png" />&nbsp;<span>新增</span>
                        </span><span class="topimgtxt" id="sifttxt" title="筛选">
                            <img alt="筛选" title="筛选" src="../../Images/public/collapse.gif" />&nbsp;<span>筛选</span>
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
                <td align="right" style="width: 80px;">
                    旅游线路:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLine" runat="server" Style="margin-left: 10px;" Width="200">
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
                <td align="right" style="width: 90px;">
                    出团日期:
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="ddlRequestDate" CssClass="filterInput" runat="server">
                        <asp:ListItem Value="-1">——请选择——</asp:ListItem>
                        <asp:ListItem Value="0">——今天——</asp:ListItem>
                        <asp:ListItem Value="1">——今天之前——</asp:ListItem>
                        <asp:ListItem Value="2">——昨天——</asp:ListItem>
                        <asp:ListItem Value="3">——7天内——</asp:ListItem>
                        <asp:ListItem Value="4">——15天内——</asp:ListItem>
                        <asp:ListItem Value="5">——指定范围——</asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../Images/public/calendar.png" id="selDate" style="cursor: pointer;"
                        alt="选取时间范围" /><br />
                    <span id="dateBox"></span>
                    <input id="hidDateValue" type="hidden" runat="server" />
                </td>
                <td align="right" style="width: 80px;">
                    性质:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtNature" class="filterInput" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px;" align="right">
                    订单序号:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtOrderNum" class="filterInput" />
                </td>
                <td align="right" style="width: 80px;">
                    线路描述:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="txtTourRemark" class="filterInput" />
                </td>
                <td>
                </td>
                <td colspan="8" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td valign="top" class="style2">
                    <ul id="ztree" class="ztree">
                    </ul>
                </td>
                <td style="vertical-align: top;">
                    <table class="clsdata" cellspacing="1" cellpadding="0">
                        <tr>
                            <th class="clstitleimg" style="width: 12%;">
                                订单序号
                            </th>
                            <th class="clstitleimg" style="width: 9%;">
                                出团日期
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                性质
                            </th>
                            <th class="clstitleimg" style="width: 14%;">
                                团队总数
                            </th>
                            <th class="clstitleimg" style="width: 9%;">
                                旅游线路
                            </th>
                            <th class="clstitleimg" style="width: 14%;">
                                线路描述
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                制单人
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                操作员
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                收款状态
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                状态
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                结算状态
                            </th>
                        </tr>
                        <tbody>
                            <asp:Repeater runat="server" ID="cuslist">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href="javascript:void(0)" onclick="getOrder('<%# Eval("id") %>')" >
                                            <%#Eval("orderNum")%></a>
                                        </td>
                                        <td>
                                            <%#DateTime.Parse(Eval("outTime").ToString()).ToString("yyyy-MM-dd")%>
                                        </td>
                                        <td>
                                            <%#Eval("natrue")%>
                                        </td>
                                        <td>
                                            <%#Eval("teamNum")%>
                                        </td>
                                        <td>
                                            <%# TourLine(Convert.ToInt32( Eval("tour")))%>
                                        </td>
                                        <td>
                                            <%#Eval("tourRemark")%>
                                        </td>
                                        <td>
                                            <%#Eval("makerName")%>
                                        </td>
                                        <td>
                                            <%# Eval("inputer")%>
                                        </td>
                                        <td>
                                            <%#colStatus(Eval("id").ToString()) %>
                                        </td>
                                        <td>
                                            <%# OrderStatus(Eval("savestatus").ToString()) %>
                                        </td>
                                        <td>
                                            <%#AuditsStatus(Eval("auditstatus").ToString())%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" CustomInfoHTML="第 <font color='red'><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" OnPageChanged="AspNetPager1_PageChanged"
                        CustomInfoTextAlign="Left" LayoutType="Table" PageIndexBoxType="DropDownList"
                        ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
