<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostAddType.aspx.cs" Inherits="EtNet_Web.Pages.Common.PostAddType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>页面设置</title>
    <base target="_self" />
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../CusInfo/artDialog.js" type="text/javascript"></script>
    <script src="../CusInfo/iframeTools.js" type="text/javascript"></script>
    <style type="text/css">
        .clstop
        {
            width: 97%;
            margin: 5px 10px 0px 10px;
        }
        .clsbottom
        {
             width: 92.4%;
            margin: 0px 10px 0px 10px;
            font-size: 12px;
            border: 1px solid #4CB0D5;
            padding: 10px;
        }
        .clsdata2
        {
            width: 100%;
            border-collapse: collapse;
           
        }
        .clsunderline
        {
            width: 140px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        hr
        {
            color: #4CB0D5;
            background-color: #4CB0D5;
            border: 0;
            height: 1px;
        }
        #btn
        {
            margin-top: 10px;
            width: 100%;
            text-align: right;
        }
        .clstitleimg
        {
            background-image: url('../../Images/public/list_tit.png');
            color: White;
            height: 24px;
            font-weight: bold;
            text-align: left;
        }
        .clsdata{border-collapse: collapse;width: 100%;}
        .clsdata tr{background-color: #FFFFFF;}
        .clsdata th{border: 1px solid #DED6DC;}
        .clsdata tr td{border: 1px solid #DED6DC;height: 24px;text-align: center;}
        .clstitleimg{background-image: url('../../Images/public/list_tit.png');color: White;height: 24px;font-weight: bold;text-align: center;}
        .clsdata tr.hover td{background-color: #FFEFBB;cursor: pointer;}
        .clsdata tr.selected td{background-color: #FFECB5;}
         tr.odd td{background-color: #E3EBEF;}
        .style4
        {
            width:420px;
        }
        </style>
    <script type="text/javascript">

        window.onunload = function () {
            var dia = window.dialogArguments;
            dia.location = dia.location.href;
            window.close();
        }

        $(document).ready(function () {
            $('.clsdata tbody tr').each(function () {
                $(this).hover(function () {
                    $(this).toggleClass('hover');
                });
                $(this).click(function () {
                    $(this).addClass('selected').siblings().removeClass('selected').end()
                    .find(':radio').attr('checked', 'checked');
                    $(this).siblings().find(':radio').removeAttr('checked');
                });
            });

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

            $('#choose').click(function () {


                var origin = artDialog.open.origin;
                if ($('tr.selected').length == 0) {
                    alert('请选择类别');
                    return;
                }
                var cusid = origin.document.getElementById('HidTypeID');
                var cusname = origin.document.getElementById('TxtType');

                cusid.value = $.trim($('tr.selected').find('.postid').html());
                cusname.value = $.trim($('tr.selected').find('.typename').html());
                art.dialog.close();
            });
            $('#cancel').click(function () {
                art.dialog.close();
            });

        })
       
         
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <span style="color: White; font-size: 12px; font-weight: bold; position: relative;
                top: 5px; left: 5px;">新增岗位</span>
        </div>
        <div style="background: #4CB0D5; height: 5px; margin-right:4px">
        </div>
    </div>
    <%--<div class="clsbottom">
        <!--版本号:20120311-->
        <table class="clsdata" cellspacing="0" cellpadding="0">
            <tr>
                <th class="clstitleimg">
                    选择
                </th>
                <th class="clstitleimg">
                    类别名称:
                </th>
                <th class="clstitleimg">
                    类别注释:
                </th>
                <th style="display: none">
                    id
                </th>
            </tr>
            <tbody>
                <asp:Repeater runat="server" ID="rpCusType">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input id="Radio1" type="radio" />
                            </td>
                            <td class="typename">
                                <%#Eval("TypeName")%>
                            </td>
                            <td>
                                <%#Eval("TypeRemark")%>
                            </td>
                            <td style="display: none" id="custypeid">
                                <%# Eval("id")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div id="btn">
            <a href="javascript:void(0);" id="choose">
                <img alt="选择" src="../../Images/button/btn_sure.jpg" /></a> <a href="javascript:void(0);"
                    id="cancel">
                    <img alt="取消" src="../../Images/button/btn_cancel.jpg" /></a></div>
    </div>--%>
    <!--旧版代码-->
    <div class="clsbottom">
    <table class="clsdata2">
    
        <tr>
            
            <td align="right" style="width:60px">
                岗位名称:
            </td>
            <td class="style4">
               &nbsp;&nbsp; &nbsp;  <asp:TextBox runat="server" CssClass="clsunderline" ID="tbxTypeName"></asp:TextBox><span
                    style="color: Red;">*</span>
                <asp:Label ID="lblTypename" runat="server" ></asp:Label>
            </td>
            
           
                <td style="width:20px" >
                    <asp:ImageButton runat="server" ID="imgbtnsave" ImageUrl="../../Images/Button/btn_add.jpg"
                        OnClick="imgbtnsave_Click" />
                
            </td>
            <td style="display: none">
                id
            </td>
        </tr>
      
        <tr>
            <td colspan="6">
                <hr />
            </td>
        </tr>
        
      
    </table>
    <table class="clsdata">
      <asp:Repeater ID="rpPost" runat="server" OnItemCommand="rpPost_ItemCommand">
            <ItemTemplate>
                <tr>
                    
                  
                 
                    <td style="width:250px">
                        <%#Eval("postname") %>
                    </td>
                    <td style="width:250px">
                        <asp:LinkButton ID="delete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id") %>'
                            OnClientClick="return window.confirm('确认删除吗?')">删除</asp:LinkButton>
                    </td>
                    <td style="display: none" class="postid">
                        <%# Eval("id")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    
    </form>
</body>
</html>
