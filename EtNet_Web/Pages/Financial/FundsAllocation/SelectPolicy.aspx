<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectPolicy.aspx.cs" Inherits="EtNet_Web.Pages.Financial.FundAllocation.SelectPolicy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--2013年1月7日15:29:56--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/artDialog.js" type="text/javascript"></script>
    <script src="../../../artDialog4.1.6/plugins/iframeTools.js" type="text/javascript"></script>
    

    <link href="../css/jPages.css" rel="stylesheet" type="text/css" />

    <script src="../js/jPages.min.js" type="text/javascript"></script>
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
        .num{background:#fff;border:none;text-align:center;}
    </style>
    <script type="text/javascript">
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

            //分页
            $("div.holder").jPages({
                containerID: "policyList",
                previous: "上一页",
                next: "下一页",
                perPage: 10,
                delay: 20
            });

            $(".num").focus(function () { $(this).blur(); });

            //$("#mytable2 tbody>tr:odd").addClass("odd");
            $(".clsdata tr:first td").css({ "height": "24" })
            $(".clsdata tr:odd td,.clsdata tr:odd input").css({ "backgroundColor": "#ECF2F6" }) //指定需要改变颜色的行

            $('#saveBack').click(function () {
                var origin = artDialog.open.origin;
                if ($('tr.selected').length == 0) {

                    alert('请选择保单');
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
    <div>
        
        <asp:Repeater ID="RpPolicyList" runat="server">
            <HeaderTemplate>
            <table id="mytable2" style="text-align: center;" cellspacing="1" class="clsdata">
                <thead>
                    <tr>
                        <th class="clstitleimg" style="border-right:1px solid #B9D3EE;width:40px;">
                            选择
                        </th>         
                        <th class="clstitleimg" style="border-right:1px solid #B9D3EE;width:120px;">
                            业务编号
                        </th>               
                        <th class="clstitleimg" style="border-right:1px solid #B9D3EE;width:120px;">
                            保单编号
                        </th>
                        <th class="clstitleimg"  style="border-right:1px solid #B9D3EE;width:80px;">
                            应收金额
                        </th>
                        <th class="clstitleimg"  style="border-right:1px solid #B9D3EE;width:80px;">
                            剩余未收金额
                        </th>
                        <th class="clstitleimg"  style="border-right:1px solid #B9D3EE;width:80px;">
                            已认领金额
                        </th>
                    </tr>
                </thead>
                <tbody id="policyList">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="del">
                        <input id="Checkbox1" type="checkbox" />                        
                    </td>
                    <td><%# Eval("serialnum")%></td>
                    <td><%# Eval("Policy_Num") %></td>
                    <td class="amount"><%# Eval(GetReceiptType(),"{0:F2}") %></td>
                    <td>
                        <%--<input class="num" readonly="readonly" dataType="Require" msg="收款金额不能为空" maxvalue='<%# GetAmount(Eval(GetReceiptType()),Convert.ToInt32(Eval("policyID"))) %>' value='<%# GetAmount(Eval(GetReceiptType()),Convert.ToInt32(Eval("policyID"))) %>' type="text" />--%>
                        <input class="num" readonly="readonly" dataType="Require" msg="收款金额不能为空" maxvalue='<%# GetAmount(Eval(GetReceiptType()),Eval("realAmount")) %>' value='<%# GetAmount(Eval(GetReceiptType()),Eval("realAmount")) %>' type="text" />
                    </td>
                    <td class="remove">
                        <%# Eval("realAmount") == DBNull.Value ? "0.00" : Eval("realAmount", "{0:F2}") %>
                    </td>
                    <td class="pid" style="display:none;">
                        <%# Eval("policyID") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </table>
            </FooterTemplate>
        </asp:Repeater>   
        <div id="pages" class="holder">
        </div>   
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
    </form>
</body>
</html>
