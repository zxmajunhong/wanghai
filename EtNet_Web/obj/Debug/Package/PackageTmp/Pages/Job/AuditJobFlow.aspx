<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditJobFlow.aspx.cs" Inherits="EtNet_Web.Pages.Job.AuditJobFlow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审批管理列表</title>
    <link href="../../CSS/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />
    <link href="../Permission/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
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
        
        .oTree
        {
            background-image: url('../Permission/css/zTreeStyle/img/zTreeStandard.gif');
            background-repeat: no-repeat;
            background-position: -110px 0px;
            width: 16px;
            height: 14px;
        }
        
        .cTree
        {
            background-image: url('../Permission/css/zTreeStyle/img/zTreeStandard.gif');
            background-repeat: no-repeat;
            background-position: -110px -18px;
            width: 16px;
            height: 14px;
        }
        
        
        .style1
        {
            width: 139px;
        }
    </style>
    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../Permission/jquery.ztree.all-3.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {

            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            //提交时判断编号的输入是否符合要求 
            $("#ibtnAuditSerch").click(function () {
                var rg = /[^\w]/g;
                if ($("#iptnumber").val() && rg.test($("#iptnumber").val())) {
                    alert('单据编号只包含数字与字母!');
                    $("#iptnumber").val("");
                    return false;
                }
                else {
                    return true;
                }
            });


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
                var strmodal = "dialogHeight=200px;dialogWidth=500px;resizable=no;status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=003&dt=" + new Date().toString(), window.self, strmodal);
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
                     $("#ibtnAuditSerch").click();
                  }
               }
       
            };

            var zNodes = <%# LoadZtreeData() %>;

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

           
            SetStyle(ZtreeObject);
          
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="hidsort" value="" />
    <input type="hidden" id="hidsift" runat="server" value="0" />
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
            background-repeat: no-repeat; height: 25px;">
            <table style="width: 100%;">
                <tr>
                    <td class="toptitletxt">
                        审批管理列表
                    </td>
                    <td style="text-align: right; padding-right: 20px;">
                        <span class="topimgtxt" id="editpage">
                            <img alt="页面编辑" src="../../Images/public/layoutedit.png" />
                            <span>页面设置</span> </span><span class="topimgtxt" id="sifttxt">
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
                <td style="width: 60px;">
                    单据编号:
                </td>
                <td>
                    <input id="iptnumber" type="text" runat="server" class="clsunderline" />
                </td>
                <td style="width: 60px;">
                    审批情况:
                </td>
                <td>
                    <select id="selauditstatus" runat="server" class="clsdatalist">
                        <option value="——请选中——" selected="selected">——请选中——</option>
                        <option value="全部">全部</option>
                        <option value="未审批">未审批</option>
                        <option value="已审批">已审批</option>
                    </select>
                </td>
                <td style="width: 60px;">
                    申请人员:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlpeople" CssClass="clsdatalist">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="right">
                    <asp:ImageButton ID="ibtnAuditSerch" runat="server" ImageUrl="~/Images/Button/btn_search.jpg"
                        OnClick="ibtnAuditSerch_Click" />
                    <asp:ImageButton ID="ibtnAuditReset" runat="server" ImageUrl="~/Images/Button/btn_reset.jpg"
                        OnClick="ibtnAuditReset_Click" />
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
                    <table class="clsdata" cellspacing="1" cellpadding="0">
                        <thead>
                            <tr>
                                <td class="clstitleimg">
                                    单据编号
                                </td>
                                <td class="clstitleimg">
                                    <asp:Label runat="server" ID="lbltxt"> </asp:Label>
                                </td>
                                <td class="clstitleimg">
                                    <asp:Label runat="server" ID="lbltxtone"></asp:Label>
                                </td>
                                <td class="clstitleimg">
                                    <asp:Label runat="server" ID="lbltxttwo"> </asp:Label>
                                </td>
                                <td class="clstitleimg">
                                    申请人
                                </td>
                                <td class="clstitleimg">
                                    制单日期
                                </td>
                                <td class="clstitleimg">
                                    审批情况
                                </td>
                                <td class="clstitleimg">
                                    审批操作
                                </td>
                                <td class="clstitleimg">
                                    操作
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptauditjobflow" runat="server" OnItemCommand="rptauditjobflow_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("cname") %>
                                        </td>
                                        <td>
                                            <%# ShowData(Eval("jobflowid").ToString())%>
                                        </td>
                                        <td>
                                            <%# ShowDataOne(Eval("jobflowid").ToString())%>
                                        </td>
                                        <td>
                                            <%# ShowDataTwo(Eval("jobflowid").ToString())%>
                                        </td>
                                        <td>
                                            <%# Eval("logincname") %>
                                        </td>
                                        <td>
                                            <%# ShowDate(Eval("jobflowid").ToString()) %>
                                        </td>
                                        <td>
                                            <%# ShowColor(Eval("operatstatus").ToString().Trim())%>
                                        </td>
                                        <td>
                                            <%# ShowAuditoperatColor(Eval("auditoperat").ToString().Trim())%>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton1" runat="server" title="查看" CommandName="search"
                                                CommandArgument='<%# Eval("jobflowid") + "-" + Eval("sort") %>' ImageUrl="~/Images/Public/person.gif" />
                                            <asp:ImageButton ID="btnaudit" CommandName="audit" CommandArgument='<%# Eval("jobflowid")  + "-" +  Eval("sort")  %> '
                                                runat="server" ImageUrl="~/Images/public/edit.gif" title="现在审批" />
                                            <asp:ImageButton ID="btnrefresh" CommandName="refresh" CommandArgument='<%# Eval("jobflowid") + "-" + Eval("sort") %>' OnClientClick='return  window.confirm("确定撤销审核重新审核吗？")'
                                                runat="server" ImageUrl="~/Images/public/formfresh.png" title="撤销" Visible='<%# isRefresh(Eval("jobflowid").ToString()) %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div id="pages" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
