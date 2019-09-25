<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReimbursedForm.aspx.cs"
    Inherits="EtNet_Web.Pages.Job.ReimbursedForm.ShowReimbursedForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报销申请列表</title>
    <link href="../../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
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
            width: 200px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clsdatalist
        {
            width: 200px;
        }
        .clstitleimg
        {
            background-image: url('../../../Images/public/list_tit.png');
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
        .buttonStyle
        {
            background: url('../../../Images/Common/buticon.gif');
            height: 22px;
            width: 64px;
            border: 0;
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
    </style>
    <script src="../../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../../Scripts/customdate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {



            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //提交时判断编号的输入是否符合要求
            $("#ibtnsearchjob,#ibtnjobreset").click(function () {
                var rg = /[^\w]/g;
                var rgmoney = /^(0|[1-9][0-9]*)\.\d{2}$/
                var str = "";
                if ($("#tbxnumber").val() && rg.test($("#tbxnumber").val())) {
                    str += '单据编号只包含数字与字母!\n';
                    $("#tbxnumber").val("");
                }
                if ($("#iptmoney").val() != "" && !rgmoney.test($("#iptmoney").val())) {
                    str += '合计金额只能包含数字与小数点且要有两位小数!';
                }
                if (str != "") {
                    alert(str);
                    return false;
                }
                else {
                    return true;
                }
            });



            //金额格式补全
            $("#iptmoney").live("blur", function () {
                var strmoney = $(this).val()
                if (strmoney == "") {
                    return;
                }
                rg = new RegExp("^(0|[1-9][0-9]*)$");
                if (rg.test(strmoney)) {
                    $(this).val(strmoney + ".00");
                    return;
                }
                rg = new RegExp("^(0|[1-9][0-9]*)\.$");
                if (rg.test(strmoney)) {
                    $(this).val(strmoney + "00");
                    return;
                }
                rg = new RegExp("^(0|[1-9][0-9]*)\.[0-9]$");
                if (rg.test(strmoney)) {
                    $(this).val(strmoney + "0");
                    return;
                }
            })


            //新增
            $("#addtxt").click(function () {
                window.location = "AddReimbursedForm.aspx?page=1";
            })


            $("#editpage").click(function () {
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;status=no";
                window.showModalDialog("../../Common/PageSearchSet.aspx?pagenum=007&dt=" + new Date().toString(), window.self, strmodal);
            })


            //按照条件判断是否显示筛选栏
            function fist() {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", "../../../Images/Public/expand.gif");
                    $(".clssift").hide();
                }
                else {
                    $("#sifttxt img").attr("src", " ../../../Images/Public/collapse.gif");
                    $(".clssift").show();
                }
            }

            fist();

            //展开或影藏筛选栏
            $("#sifttxt").click(function () {
                if ($("#hidsift").val() == "0") {
                    $("#sifttxt img").attr("src", " ../../../Images/Public/collapse.gif");
                    $(".clssift").show();
                    $("#hidsift").val("1");
                }
                else {
                    $("#sifttxt img").attr("src", "../../../Images/Public/expand.gif");
                    $(".clssift").hide();
                    $("#hidsift").val("0");
                }

            })

            //指定时间
            $("#selimgdt").click(function () {
                cdate({ sid: "customdate", hid: "hidcdate" });
                $("#ddldate").val(6);
            })

            //选时间段
            $("#ddldate").change(function () {
                if ($(this).val() == "6") {
                    $("#selimgdt").click();
                }
                else {
                    $("#customdate").text("");
                    $("#hidcdate").val("");
                }
            })


        });

        function printForm(id) {
            var url = 'PrintReimbursedForm.aspx?id=' + id;
            window.open(url, 'newwindow', 'height=440,width=850,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
        }

        function issend() {
            debugger;
            var value = document.getElementById('hidstatus').value;
            if (value == "03") {
                return confirm('该单据被拒绝过，请确认数据后再送审');
            }
            else {
                return true;
            }
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidsift" runat="server" value="0" />
    <input type="hidden" id="hidstatus" runat="server" value="" />
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        报销申请列表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage">
                            <img alt="页面编辑" src="../../../Images/public/layoutedit.png" />
                            <span>页面设置</span> </span><span class="topimgtxt" id="addtxt">
                                <img alt="新增" src="../../../Images/public/pagedit.png" />
                                <span>新增</span> </span><span class="topimgtxt" id="sifttxt">
                                    <img alt="筛选" />
                                    <span>筛选</span> </span>
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
                <td>
                    报销单号:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxnumber" CssClass="clsunderline"></asp:TextBox>
                </td>
                <td>
                    保存状态:
                </td>
                <td>
                    <asp:DropDownList ID="ddlsavestatus" runat="server" CssClass="clsdatalist">
                        <asp:ListItem Selected="True" Value="0" Text="——请选中——"></asp:ListItem>
                        <asp:ListItem Value="草稿" Text="草稿"></asp:ListItem>
                        <asp:ListItem Value="已提交" Text="已提交"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    填单人员:
                </td>
                <td>
                    <asp:DropDownList runat="server" CssClass="clsdatalist" ID="ddlpeople">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <%--<td>费用归属:</td>
           <td>
             &nbsp;<asp:DropDownList runat="server" ID="ddlbelongsort" CssClass="clsdatalist"></asp:DropDownList>
             <br />
             <span id="customdate"></span>
             <input type="hidden" runat="server" id="hidcdate"/>      
            </td>
            <td>费用类别：</td>
            <td>
               <asp:DropDownList ID="ddlAusType" CssClass="clsdatalist" runat="server">
               </asp:DropDownList>
            </td>--%>
                <td>
                    项目类别:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBillType" CssClass="clsdatalist" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    报销金额:
                </td>
                <td>
                    <input type="text" runat="server" id="iptmoney" class="clsunderline" />
                </td>
                <td>
                    审核状态:
                </td>
                <td>
                    <asp:DropDownList ID="ddlauditstatus" runat="server" CssClass="clsdatalist">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    报销日期:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddldate" CssClass="clsdatalist">
                        <asp:ListItem Text="——请选择——" Value="0"></asp:ListItem>
                        <asp:ListItem Text="——今天——" Value="1"></asp:ListItem>
                        <asp:ListItem Text="——今天之前——" Value="2"></asp:ListItem>
                        <asp:ListItem Text="——昨天——" Value="3"></asp:ListItem>
                        <asp:ListItem Text="——7天内——" Value="4"></asp:ListItem>
                        <asp:ListItem Text="——15天内——" Value="5"></asp:ListItem>
                        <asp:ListItem Text="——指定范围——" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                    <img src="../../../Images/public/calendar.png" id="selimgdt" style="cursor: pointer;"
                        alt="选取时间范围" />
                    <br />
                    <span id="customdate"></span>
                    <input type="hidden" runat="server" id="hidcdate" />
                </td>
            </tr>
            <tr>
                <td colspan="6" align="right">
                    <asp:ImageButton ID="ibtnsearchjob" runat="server" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="ibtnsearchjob_Click" />
                    <asp:ImageButton ID="ibtnjobreset" runat="server" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="ibtnjobreset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <thead>
                <tr>
                    <td class="clstitleimg" style="width: 90px;">
                        审核状态
                    </td>
                    <td class="clstitleimg" style="width: 120px;">
                        报销单号
                    </td>
                    <td class="clstitleimg" style="width: 80px;">
                        报销日期
                    </td>
                    <td class="clstitleimg" style="width: 80px;">
                        填单人员
                    </td>
                    <td class="clstitleimg" style="width: 80px;">
                        报销人员
                    </td>
                    <%--<td class="clstitleimg" style=" width:90px;">费用归属</td>
              <td class="clstitleimg" style=" width:80px;">费用类别</td>--%>
                    <td class="clstitleimg" style="width: 80px;">
                        报销金额
                    </td>
                    <td class="clstitleimg" style="width: 80px;">
                        项目类别
                    </td>
                    <td class="clstitleimg" style="width: 140px;">
                        备注
                    </td>
                    <td class="clstitleimg" style="width: 90px;">
                        保存状态
                    </td>
                    <td class="clstitleimg" style="width: 150px;">
                        操作
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptdata" runat="server" OnItemCommand="rptdata_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# ShowColor(Eval("auditstutastxt").ToString()) %>
                                
                            </td>
                            <td>
                                <%# Eval("jobflowcname")%>
                            </td>
                            <td>
                                <%# ShowDate(Eval("applydate").ToString()) %>
                            </td>
                            <td>
                                <%# Eval("applycantcname")%>
                            </td>
                            <td>
                                <%# Eval("person")%>
                            </td>
                            <td>
                                <%# ShowMoney( Eval("totalmoney").ToString() )%>
                            </td>
                            <td>
                                <%# Eval("itemtype") %>
                            </td>
                            <td style="text-align: left">
                                <%# Eval("remark") %>
                            </td>
                            <td>
                                <%# Eval("savestatus") %>
                            </td>
                            <td>
                                <asp:ImageButton runat="server" title="回收" CommandName="refresh" CommandArgument='<%# Eval("jobflowid") %>'
                                    ImageUrl="~/Images/Public/formfresh.png" />
                                <asp:ImageButton runat="server" title="送审" CommandName="audit"  OnClientClick="return issend();"
                                    CommandArgument='<%# Eval("jobflowid") %>'
                                    ImageUrl="~/Images/public/itemgo.png" />
                                <asp:ImageButton runat="server" title="编辑" CommandName="edit" CommandArgument='<%# Eval("jobflowid") %>'
                                    ImageUrl="~/Images/Public/edit.gif" />
                                <asp:ImageButton runat="server" title="查看" CommandName="search" CommandArgument='<%# Eval("jobflowid") %>'
                                    ImageUrl="~/Images/Public/person.gif" />
                                <asp:ImageButton ID="print" runat="server" title="打印" CommandName="print" CommandArgument='<%# Eval("id")+","+Eval("auditstatus") %>'
                                    ImageUrl="~/Images/icons/printer.png" Visible="false" />
                                <asp:ImageButton runat="server" title="删除" OnClientClick=" return confirm('确定删除');"
                                    CommandName="del" CommandArgument='<%# Eval("jobflowid") %>' ImageUrl="~/Images/Public/delete.gif" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="pages" runat="server">
        </div>
    </div>
    </form>
</body>
</html>
