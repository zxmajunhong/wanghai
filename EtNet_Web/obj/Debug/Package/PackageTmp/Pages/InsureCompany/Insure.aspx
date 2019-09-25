<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insure.aspx.cs" Inherits="EtNet_Web.Pages.InsureCompany.Insure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>客户显示</title>
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="default.css" rel="stylesheet" type="text/css" />
    <link href="../Permission/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
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
            width: 160px;
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
        .style1
        {
            width: 100px;
        }
        .filterInput
        {
            width: 200px;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: #C6E2FF;
        }
    </style>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Permission/jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <script type="text/javascript">

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
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=010&dt=" + new Date().toString(), window.self, strmodal);
            })


            //编辑默认设置
            $("#edittype").click(function () {
                var strmodal = "dialogHeight=500px;dialogWidth=680px;resizable=no;";
                strmodal += "status=yes";
                window.open("Coverage.aspx?pagenum=002&dt=" + new Date().toString(), window.self, strmodal);
            })
//            $("#editpage").click(function () {
//                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;status=no";
//                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=013&dt=" + new Date().toString(), window.self, strmodal);
//            })

            var setting = {
                data: {
                    simpleData: {
                        enable: true
                    }
                },
                callback:{
                  onClick: function(event,treeId,treeNode){                 
                     $("#hidsort").val(treeNode.id);                
                     $("#btnQuery").click();
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
    <asp:Button ID="btnQuery" Text="" runat="server" Style="display: none;" OnClick="btnQuery_Click" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        保险公司列表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage" title="页面设置">
                            <img alt="页面编辑" title="页面设置" src="../../Images/public/layoutedit.png" />
                            <span>页面设置</span></span> <span class="topimgtxt" id="addtxt" title="新增">
                                <img alt="新增" title="新增" src="../../Images/public/pagedit.png" />
                                <span>新增</span> </span><span class="topimgtxt" id="sifttxt" title="筛选">
                                    <img alt="筛选" title="筛选" src="../../Images/public/collapse.gif" />
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
                <td style="width: 80px;" align="right">
                    公司简称:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="comshortename" class="filterInput" />
                </td>
                <td style="width: 80px;" align="right">
                    公司全称:
                </td>
                <td>
                    &nbsp;<input type="text" runat="server" id="comname" class="filterInput" />
                </td>
                <td style="width: 80px;" align="right">
                    公司地址:
                </td>
                <td>
                    <input type="text" runat="server" id="comaddress" class="filterInput" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px;" align="right">
                    联系人名:
                </td>
                <td>
                    <input type="text" runat="server" id="clinkname" class="filterInput" />
                </td>
                <td style="width: 80px;" align="right">
                    是否启用:
                </td>
                <td>
                    <asp:RadioButtonList ID="rbUsed" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Selected="True">已启用</asp:ListItem>
                        <asp:ListItem Value="0">未启用</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 80px;">
                    &nbsp;
                </td>
                <td align="right">
                    <asp:ImageButton ID="imgbtnsearch" runat="server" ImageUrl="~/Images/button/btn_search.jpg"
                        OnClick="imgbtnsearch_Click" />
                    <asp:ImageButton ID="mgbtnreset" runat="server" ImageUrl="~/Images/button/btn_reset.jpg"
                        OnClick="mgbtnreset_Click" />
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td valign="top" class="style1">
                    <ul id="ztree" class="ztree">
                    </ul>
                </td>
                <td style="vertical-align: top;">
                    <table class="clsdata" cellspacing="1" cellpadding="0" style="table-layout: fixed;
                        word-wrap: break-word;">
                        <tr>
                            <th class="clstitleimg" style="width: 10%;">
                                公司代码
                            </th>
                            <th class="clstitleimg" style="width: 10%;">
                                公司简称
                            </th>
                            <th class="clstitleimg" style="width: 15%;">
                                公司全称
                            </th>
                            <th class="clstitleimg" style="width: 15%;">
                                公司地址
                            </th>
                            <th class="clstitleimg" style="width: 8%;">
                                联系人
                            </th>
                            <th class="clstitleimg" style="width: 9%;">
                                电话
                            </th>
                            <th class="clstitleimg" style="width: 135px;">
                                电子邮箱
                            </th>
                            <th class="clstitleimg" style="width: 7%;">
                                是否启用
                            </th>
                            <th class="clstitleimg" style="width: 5%;">
                                险种
                            </th>
                            <th class="clstitleimg" style="width: 100px;">
                                操作
                            </th>
                        </tr>
                        <tbody>
                            <asp:Repeater runat="server" ID="comList" OnItemCommand="comList_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("comCode") %>
                                        </td>
                                        <td>
                                            <%#Eval("comShortName")%>
                                        </td>
                                        <td>
                                            <%#Eval("comCName")%>
                                        </td>
                                        <td>
                                            <%#Eval("comCAddress")%>
                                        </td>
                                        <td>
                                            <%#Eval("LinkName")%>
                                        </td>
                                        <td>
                                            <%#Eval("telephone")%>
                                        </td>
                                        <td>
                                            <%#Eval("Email")%>
                                        </td>
                                        <td>
                                            <%# pages_insurecompany_insure_aspx.ifused(Eval("used").ToString())%>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="edittype" runat="server" AlternateText="险种" title="险种" CommandName="Read"
                                                CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/vie.gif" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton1" AlternateText="编辑" title="编辑" runat="server" CommandName="Update"
                                                Visible='<%# IsSelf(Eval("madefrom")) %>' CommandArgument='<%# Eval("id") %>'
                                                ImageUrl="~/Images/public/edit.gif" />
                                            <asp:ImageButton ID="ImageButton4" AlternateText="复制" title="复制" Visible='<%# IsSelf(Eval("madefrom")) %>'
                                                runat="server" CommandName="Copy" CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/page_copy.png" />
                                            <asp:ImageButton ID="ImageButton2" AlternateText="详细" title="详细" runat="server" CommandName="Detial"
                                                CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/searchform.png" />
                                            <asp:ImageButton ID="ImageButton3" AlternateText="删除" title="删除" runat="server" CommandName="Delete"
                                                CommandArgument='<%# Eval("id") %>' ImageUrl="~/Images/public/delete.gif" Visible='<%# IsSelf(Eval("madefrom")) %>'
                                                OnClientClick="return window.confirm('确认删除吗?')" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div runat="server" id="pages">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:ImageButton ID="imgbtnadd" CssClass="topbtnimg" runat="server" ImageUrl="../../Images/public/layoutedit.png"
            OnClick="imgbtnadd_Click" />
    </div>
    </form>
</body>
</html>
