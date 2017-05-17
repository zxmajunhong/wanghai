<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="EtNet_Web.Pages.Product.Product" %>

<%@ Register TagPrefix="yyc" Assembly="YYControls" Namespace="YYControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Customers/main.css" rel="stylesheet" type="text/css" />
    <link href="default.css" rel="stylesheet" type="text/css" />
    <link href="common.css" rel="stylesheet" type="text/css" />
    <link href="product.css" rel="stylesheet" type="text/css" />
    <link href="cuscosky.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <script src="iframeTools.js" type="text/javascript"></script>
    <style type="text/css">
        .sortable th, .sortable td
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">险种定义</span>
    </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    
    <div class="border" id="slider">
        <div id="leftDiv">
            <div>
                 <asp:ImageButton ID="btnDel" CssClass="btn" runat="server" Text="删除险种" ImageUrl="../../Images/Button/btn_deleteitem.jpg"
            OnClientClick="return confirmDelete()" OnClick="btnDel_Click" />
        <img class="btn" alt="" src="../../Images/Button/btn_additem.jpg" id="btnAdd" />
        <img alt="" class="btn" src="../../Images/Button/btn_modify.jpg" id="btnEdit" />
        <%--<asp:ImageButton CssClass="btn" ID="btnSave" CommandName="" Text="保存" Enabled="False" runat="server"
            OnClick="btnSave_Click" OnClientClick="return CheckProData()" ImageUrl="~/Pages/Product/Image/btn_save.jpg" />--%>
            </div>
            <yyc:SmartTreeView ID="stvProType" runat="server" OnSelectedNodeChanged="stvProType_SelectedNodeChanged"
                ExpandDepth="1" Font-Size="Small" PopulateNodesFromClient="False" 
                Target="_blank" ShowCheckBoxes="Leaf">
                <SelectedNodeStyle BorderStyle="Ridge" BorderWidth="1px" BackColor="#C8E3FF" BorderColor="#6699FF" />
            </yyc:SmartTreeView>
        </div>
        <input id="divScrollValue" value="" type="hidden" runat="server" />
        <div id="rightDiv">
            <div style="height: 50%; overflow: auto; overflow-x: hidden; border-bottom: 1px solid #ccc;
                margin-bottom: 10px;">
                <table id="tabledata" style="width: 100%;">
                    <tr>
                        
                        <td colspan="8" style="background-image: url('../../Images/public/win_top.png'); background-repeat: repeat-x;
                            height: 31px" class="style1">
                            <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                                子险列表</span> 
                                <span class="titlebtncls"><a href="javascript:void(0)" class="opadd"  title="添加"  >
                                    <img src="../../Images/public/pagedit.png" style="margin-bottom:-2px;width:14px;height:14px;" alt="添加项目"  title="添加" />添加子险 </a></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <table cellpadding="0" cellspacing="0" border="0" id="table" class="sortable">
                                <thead>
                                    <tr>
                                        <th>
                                            <h3>子险编号</h3>
                                        </th>
                                        <th>
                                            <h3>子险名称</h3>
                                        </th>
                                        <th>
                                            <h3>是否主险</h3>
                                        </th>
                                        <th class="nosort">
                                            <h3>操作</h3>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="container">
                                    <asp:Repeater ID="rpProList" runat="server" OnItemCommand="rpProList_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center">
                                                    <%# Eval("ProdNo")%>
                                                </td>
                                                <td>
                                                    <%# Eval("ProdName")%>
                                                </td>
                                                <td align="center">
                                                    <%#Convert.ToBoolean(Eval("FlagMain")) == true ? "是" : "否"%>
                                                </td>
                                                <td align="center">
                                                    <a onclick='openEdit(<%# Eval("ProdID") %>)' href="javascript:void(0)" title="编辑">
                                                        <img src="../../Images/public/edit.gif" /></a>&nbsp
                                                    <asp:ImageButton ID="btnDelPro" runat="server" ToolTip="删除" ImageUrl="../../Images/public/delete.gif"
                                                        CommandName="DEL" CommandArgument='<%# Eval("ProdID") %>' OnClientClick="return confirm('是否删除');" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <script src="script.js" type="text/javascript"></script>
                            <script type="text/javascript">
                                var sorter = new TINY.table.sorter("sorter");
                                sorter.head = "head";
                                sorter.asc = "asc";
                                sorter.desc = "desc";
                                sorter.even = "evenrow";
                                sorter.odd = "oddrow";
                                sorter.evensel = "evenselected";
                                sorter.oddsel = "oddselected";
                                sorter.paginate = true;
                                sorter.currentid = "currentpage";
                                sorter.limitid = "pagelimit";
                                sorter.init("table", 1);
                            </script>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel ID="Panel1" runat="server" BackColor="#D0E8FF">
                <span style="float: left; color: #000; width: 50px; height: 100%; text-align: center;
                    margin-top: 10px; font-size: large; font-weight: bold;" font-family="微软雅黑">险<br />种<br />信<br />息<br />维<br />护</span>
                <ol id="need">
                    <li>
                        <label class="">上级险种：</label>
                        <asp:TextBox ID="txtParent" Enabled="false" runat="server"></asp:TextBox><input id="hidParent"
                            type="hidden" runat="server" /></li>
                    <li>
                        <label class="">险种名称：</label>
                        <asp:TextBox ID="txtName" Enabled="false" runat="server"></asp:TextBox><dfn
                                id="msg"></dfn></li>
                    <li>
                        <label class="">险种大类：</label>
                        <asp:DropDownList ID="ddlType" Enabled="false" runat="server">
                            </asp:DropDownList></li>
                    <li>
                        <label class="">标的类别：</label>
                        <asp:DropDownList ID="ddlTarget" Enabled="false" runat="server">
                            </asp:DropDownList></li>
                </ol>
                <input id="hidNum" type="hidden" runat="server" />
            </asp:Panel>
        </div>
        <div style="clear: both">
        </div>
        
        
    </div>
    <script type="text/javascript">
        function CheckProData() {
            if ($("#txtName").val() == "") {
                $("#msg").html("险种名称为必填项，请填写！").show();
                return false;
            }
            else if ($("#txtName").val().length > 60) {
                $("#msg").html("险种名称为必填项，请填写！").show();
                return false;
            }
            else {
                $("#msg").hide();
                return true;
            }
        }

        function confirmDelete() {
            if (window.confirm("确定删除吗")) {
                return true;
            } else {
                return false;
            }
        }

        function openEdit(id) {
            art.dialog.open('EditProduct.aspx?id=' + id, { width: '610px', height: '400px' }).lock().title('添加保险项目');
        }

        $(function () {
            $('a.opadd').click(function () {
                var id = $("#hidNum").val();
                art.dialog.open('AddProduct.aspx?typeid=' + id, { width: '610px', height: '400px' }).lock().title('添加保险项目');
            });


            $('#btnAdd').click(function () {
                art.dialog.open("AddProType.aspx?action=ADD&id=" + $("#hidParent").val(), { width: '350px', height: '240px' }).lock().title("添加险种");
            });
            $('#btnEdit').click(function () {
                art.dialog.open("AddProType.aspx?action=MODIFY&id=" + $("#hidParent").val(), { width: '350px', height: '240px' }).lock().title("修改险种");
            });
        });

        function showDialog(c) {
            art.dialog({
                content: c
            });
        }


        //刷新时滚动条保留位置
        function ScrollToSelectNode() {
            document.getElementById("treeDiv").scrollTop = "<%=ScrollValue%>";
        }
        function bindData() {
            document.getElementById("divScrollValue").value = document.getElementById("treeDiv").scrollTop;
        }

        window.onload = ScrollToSelectNode;
        $("#stvProType a").click(function () {
            document.getElementById("divScrollValue").value = document.getElementById("treeDiv").scrollTop;
        });
    </script>
    
    <input id="hidResult" value="" type="hidden" runat="server" />
    <asp:Button ID="btnType" Width="0px" Height="0px" runat="server" 
            Text="dsada" onclick="btnType_Click" />
        <asp:Button ID="btnPro" Width="0px" Height="0px" runat="server" 
            Text="" onclick="btnPro_Click" />     
    </form>
</body>
</html>
