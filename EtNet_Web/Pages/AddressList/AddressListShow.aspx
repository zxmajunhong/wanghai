<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressListShow.aspx.cs"
    Inherits="Pages.AddressList.AddressListShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>通讯录列表</title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .clsbottom
        {
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 5px 40px 10px 40px;
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
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //新增
            $("#addtxt").click(function () {
                window.location = "AddressListAdd.aspx";
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
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=002&dt=" + new Date().toString(), window.self, strmodal);
            })




        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" value="0" id="hidsift" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        通讯录列表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                      <span class="topimgtxt" id="editpage">
                        <img alt="页面编辑" src="../../Images/public/layoutedit.png" />
                        <span>页面设置</span>
                      </span>
                      <span class="topimgtxt" id="addtxt">
                        <img alt="新增" src="../../Images/public/pagedit.png" />
                        <span>新增</span> 
                      </span>
                      <span class="topimgtxt" id="sifttxt">
                        <img alt="筛选" />
                        <span>筛选</span>
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
              <td style="width: 60px;">中文姓名:</td>    
              <td>
                <input type="text" runat="server" id="iptcname" class="clsunderline" />
              </td>
              <td style="width: 60px;">英文姓名:</td>                     
              <td>
                <input type="text" runat="server" id="iptename" class="clsunderline" />
              </td>
              <td style="width: 60px;">手机号码:</td>
              <td>
               <input type="text" runat="server" id="iptcellphone" class="clsunderline" />
              </td>    
            </tr>
            <tr>
             <td>电话号码:</td>
             <td>
              <input type="text" runat="server" id="iptphone" class="clsunderline" />
             </td>
             <td>邮箱地址:</td>
             <td>
              <input type="text" runat="server" id="iptmailbox" class="clsunderline" />
             </td>
             <td>手机短号:</td>
             <td>
              <input type="text" runat="server" id="iptscellphone" class="clsunderline" />
             </td>
            </tr>
            <tr>
              <td style="display: none;"> 所属部门:</td>   
              <td colspan="5" style="display: none;">
                    <asp:DropDownList runat="server" ID="ddldepart" CssClass="clsdatalist">
                    </asp:DropDownList>
              </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: right;">
                    <asp:ImageButton runat="server" ID="imgbtnsearch" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton runat="server" ID="mgbtnreset" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table class="clsdata" cellspacing="1" cellpadding="0">
            <tr>
                <td class="clstitleimg">
                    中文姓名
                </td>
                <td class="clstitleimg">
                    英文姓名
                </td>
                <td class="clstitleimg" style="width: 40px;">
                    性别
                </td>
                <td class="clstitleimg">
                    手机号码
                </td>
                <td class="clstitleimg">
                   手机短号
                </td>
                <td class="clstitleimg">
                    电话号码
                </td>
                <td class="clstitleimg">
                    邮箱地址
                </td>
                <td class="clstitleimg">
                    备注
                </td>
                <td class="clstitleimg" style="width: 100px;">
                    操作
                </td>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="rptdata" OnItemCommand="rptdata_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("cname") %>
                            </td>
                            <td>
                                <%# Eval("ename") %>
                            </td>
                            <td>
                                <%# Eval("sex") %>
                            </td>
                            <td>
                                <%# Eval("cellphone") %>
                            </td>
                            <td>
                             <%# Eval("scellphone") %>
                            </td>
                            <td>
                                <%# Eval("phone") %>
                            </td>
                            <td>
                                <%#  Eval("mailbox")%>
                            </td>
                            <td>
                                <%# Eval("remark") %>
                            </td>
                            <td>
                                <asp:ImageButton runat="server" CommandName="edit" AlternateText="编辑" CommandArgument='<%# Eval("id") %>'
                                    ImageUrl="~/Images/public/edit.gif" />
                                <asp:ImageButton runat="server" CommandName="del" AlternateText="删除" OnClientClick=" return confirm('确定删除');"
                                    CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/delete.gif" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div runat="server" id="pages">
        </div>
    </div>
    </form>
</body>
</html>
