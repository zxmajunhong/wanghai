<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TargetManager.aspx.cs"
    Inherits="EtNet_Web.Pages.Product.TargetManager1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="artDialog.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="product.css" />
    <link href="common.css" rel="stylesheet" type="text/css" />
    <link href="default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tabledata table#table th
        {
            height: 24px;
        }
        .sortable tbody tr
        {
            cursor: pointer;
        }
        .sortable th, .sortable td
        {
            text-align: center;
        }
        .sortable tbody tr:hover
        {
            background-color: #E9F5FF;
        }
        tr.selected
        {
            background-color: Green;
        }
        #editForm
        {
            display: none;
        }
        .paginator
        {
            font: 12px Arial, Helvetica, sans-serif;
            padding: 0px;
            margin: 0px;
        }
        .paginator a
        {
            border: solid 1px #ccc;
            color: #0063dc;
            cursor: pointer;
            text-decoration: none;
        }
        .paginator a:visited
        {
            padding: 1px 6px;
            border: solid 1px #61befe;
            background: #61befe;
            color: #fff;
            text-decoration: none;
        }
        .paginator .cpb
        {
            border: 1px solid #61befe;
            font-weight: 700;
            color: #fff;
            background-color: #61befe;
        }
        .paginator a:hover
        {
            border: solid 1px #61befe;
            color: #fff;
            background: #61befe;
            text-decoration: none;
        }
        .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover
        {
            float: left;
            height: 21px;
            line-height: 21px;
            min-width: 10px;
            _width: 10px;
            margin-right: 5px;
            text-align: center;
            white-space: nowrap;
            font-size: 12px;
            font-family: Arial,SimSun;
            padding: 0 4px;
        }
        .titlebtncls
        {
            position: absolute;
            right: 0px;
            margin-top: 5px;
        }
        .titlebtncls a
        {
            font-size: 12px;
            font-weight: bold;
            margin-right: 10px;
            color: #718ABE;
            cursor: pointer;
            text-decoration: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var $num = $('#txtTypeNum');
            var $name = $('#txtTypeName');
            $('#AddType').click(function () {
                $('#editForm').show();
                $('#HidCmdName').val('ADD');
            });
            $('#EditType').click(function () {
                $name.val($('#ddlTargetType option:selected').text());
                $num.val($('#HidNum').val());
                $('#editForm').show();
                $('#HidCmdName').val('MODIFY');
            });
            $('#BtnSaveType').click(function () {
                $('#editForm').hide();
            });
            $('#cancel').click(function () {
                $('#editForm').hide();
                $name.val("");
                $num.val("");
            });
            //编辑默认设置
            $("#editpage").click(function () {
                var strmodal = "dialogHeight=160px;dialogWidth=500px;resizable=no;";
                strmodal += "status=no";
                window.showModalDialog("../Common/PageSearchSet.aspx?pagenum=011&dt=" + new Date().toString(), window.self, strmodal);
            })
        });

        function confirmDelete() {
            if (window.confirm("确定删除吗")) {
                return true;
            } else {
                return false;
            }
        }

        function CheckProData() {
            if ($("#txtTypeNum").val() == "") {
                $('#msg').val("编号不能为空").show();
                return false;
            }
            else if ($("#txtTypeName").val() == "") {
                $('#msg').val("编号不能为空").show();
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image: url('../../Images/public/title_hover.png'); text-align: left;
        background-repeat: no-repeat; height: 25px;">
        <span style="color: White; display: block; padding-left: 10px; font-size: 12px; vertical-align: bottom;
            font-weight: bold; line-height: 25px">标的定义
            <span class="titlebtncls"> <a href="javascript:void('0');"
                id="editpage" title="设置">
                <img alt="" src="../../Images/public/layoutedit.png" />页面设置</a> </span></span>
    </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
    
    <div class="border" id="slider">
        <div style="float: left; height: 30px; margin-right: 50px; line-height: 30px; vertical-align: middle;">
            <div style="float: left; margin-right: 5px;">
                <label>
                    标的种类：</label><asp:DropDownList ID="ddlTargetType" runat="server" OnSelectedIndexChanged="ddlTargetType_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
            </div>
            <div style="margin-top: 4px; float: left">
                <input id="HidNum" type="hidden" runat="server" />
                <a href="javascript:void(0);" id="AddType">
                    <img alt="添加" src="../../Images/Button/btn_addtype.jpg" /></a> <a href="javascript:void(0);"
                        id="EditType">
                        <img alt="修改" src="../../Images/Button/btn_modtype.jpg" /></a>
                <asp:ImageButton ID="BtnDelType" ImageUrl="../../Images/Button/btn_deltype.jpg" OnClientClick="return confirmDelete()"
                    runat="server" OnClick="BtnDelType_Click" />
            </div>
        </div>
        <div id="editForm">
            <table>
                <tr>
                    <td>
                        编号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTypeNum" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton ID="BtnSaveType" ImageUrl="../../Images/Button/btn_save.jpg" runat="server" OnClientClick="return CheckProData()"
                            OnClick="BtnSaveType_Click" />
                    </td>
                    <td>
                        <a href="javascript:void(0);" id="cancel">
                            <img alt="取消" src="../../Images/Button/btn_cancel.jpg" /></a>
                    </td>
                    <td id="msg">
                    </td>
                </tr>
            </table>
        </div>
        <table id="tabledata" style="width: 100%;">
            <tr>
                <td colspan="8" style="
                    background-repeat: repeat-x; height: 31px" class="style1">
                    <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                        标的描述</span> <span style="float: right; margin-right: 5px">
                            <asp:ImageButton ID="btnSave" ImageUrl="../../Images/Button/btn_add.jpg" runat="server"
                                OnClick="btnSave_Click" /></span>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <table cellpadding="0" cellspacing="0" border="0" id="table" class="sortable">
                        <thead>
                            <tr>
                                <th>
                                    <h3>
                                        标的编号</h3>
                                </th>
                                <th>
                                    <h3>
                                        标的描述</h3>
                                </th>
                                <th>
                                    <h3>
                                        数据类型</h3>
                                </th>
                                <th>
                                    <h3>
                                        主标/副标</h3>
                                </th>
                                <th>
                                    <h3>
                                        是否必填</h3>
                                </th>
                                <th class="nosort" width="80px">
                                    <h3>
                                        操作</h3>
                                </th>
                            </tr>
                        </thead>
                        <tbody id="container">
                            <asp:Repeater ID="rpTargetProperty" runat="server" OnItemCommand="rpTargetProperty_ItemCommand">
                                <ItemTemplate>
                                    <tr class="item" onmouseover="style.backgroundColor='#E9F5FF'" onmouseout="style.backgroundColor='#FFFFFF'">
                                        <td align="center">
                                            <%# Eval("PropertyNO")%>
                                        </td>
                                        <td>
                                            <%# Eval("PropertyName")%>
                                        </td>
                                        <td id="edit">
                                            <%# Eval("PropertyType").ToString() == "0" ? "文字描述" : (Eval("PropertyType").ToString() == "3" ? "是非判断" : (Eval("PropertyType").ToString() == "5" ? "日期" : Eval("PropertyType").ToString() == "9" ? "多选一" : "数据类型未定义"))%>
                                        </td>
                                        <td id="Td1">
                                            <%# Eval("MainFlag")==DBNull.Value?"未定义":(Eval("MainFlag").ToString()=="True"?"主标":"副标")%>
                                        </td>
                                        <td>
                                            <%# Eval("IsRequired")==DBNull.Value?"未定义":(Eval("IsRequired").ToString()=="True"?"必填":"非必填")%>
                                        </td>
                                        <td align="center">
                                            <a title="编辑" href='<%# "TargetEdit.aspx?action=edit&typeid="+Eval("TargetTypeId")+"&targetid="+Eval("PropertyId") %>'>
                                                <img src="../../Images/public/edit.gif" /></a>
                                            <asp:ImageButton ID="btnDelete" OnClientClick="return confirmDelete()" CommandArgument='<%# Eval("PropertyId") %>'
                                                CommandName="DEL" ToolTip="删除" ImageUrl="../../Images/public/delete.gif" runat="server" />
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
    <input id="HidCmdName" type="hidden" runat="server" />
    </form>
</body>
</html>
