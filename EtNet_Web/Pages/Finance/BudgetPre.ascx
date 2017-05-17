<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BudgetPre.ascx.cs" Inherits="EtNet_Web.Pages.Finance.BudgetPre" %>
<div id="top-left">
    <table class="tabledata" style="width: 100%;">
        <tr>
            <td colspan="8" style="background-image: url('../../Images/public/win_top.png'); background-repeat: repeat-x;
                height: 31px" class="style1">
                <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                    收入部分</span> 
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <table cellpadding="0" cellspacing="0" border="0" id="leftTable" class="sortable">
                    <thead>
                        <tr>
                            <th>
                                项目内容
                            </th>
                            <th>
                                预计收入金额
                            </th>
                            <th>
                                备注
                            </th>
                        </tr>
                    </thead>
                    <tbody id="container">
                        <tr>
                            <td align="right" width="100px">
                                保费：
                            </td>
                            <td width="80px">
                                <asp:TextBox Enabled="false" ID="TxtPremium" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtPremiunMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                经纪费：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtBrokerage" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtBrokerageMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                服务费：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtService" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtServiceMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项1：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther1" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther1Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项2：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther2" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther2Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项3：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther3" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther3Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项4：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther4" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther4Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项5：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther5Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项6：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther6" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther6Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项7：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther7" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther7Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项8：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther8" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther8Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项9：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther9" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther9Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项10：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther10" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtIncomeOther10Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="leftSum">
                            <td style="color: Blue" colspan="3">
                                收入合计：￥<asp:Literal ID="LtrIncome" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr id="sum">
                            <td style="color: Blue" colspan="3">
                                收入合计：￥<asp:Literal ID="LtrTotal" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</div>
<div id="top-right">
    <table class="tabledata" style="width: 100%;">
        <tr>
            <td colspan="8" style="background-image: url('../../Images/public/win_top.png'); background-repeat: repeat-x;
                height: 31px" class="style1">
                <span class="opadd" style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                    支出部分</span>
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <table cellpadding="0" cellspacing="0" border="0" id="table2" class="sortable">
                    <thead>
                        <tr>
                            <th>
                                项目内容
                            </th>
                            <th>
                                比例系数1
                            </th>
                            <th>
                                比例系数2
                            </th>
                            <th>
                                预计支出费用
                            </th>
                            <th>
                                备注
                            </th>
                        </tr>
                    </thead>
                    <tbody id="Tbody1">
                        <tr>
                            <td align="right" width="100px">
                                代垫保费：
                            </td>
                            <td width="80px">
                                            
                            </td>
                            <td width="80px">
                            </td>
                            <td width="80px">
                                <asp:TextBox ID="TxtExpPremium" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtExpPremiumMark" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="100px">
                                佣金：
                            </td>
                            <td width="80px">
                                <asp:TextBox Enabled="false" ID="TxtYjRatio" runat="server"></asp:TextBox>
                            </td>
                            <td width="80px">
                            </td>
                            <td width="80px">
                                <asp:TextBox Enabled="false" ID="TxtYj" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtYjMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                贴费：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtTfRatio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtTf" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtTfMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                咨询费：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtZxfRatio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtZxf" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtZxfmark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                服务费：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtFwfRatio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtFwf" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtFwfMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                管理费：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtGlfRatio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtGlf" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtGlfMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                垫款利息：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtDklxRatio1" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtDklxRatio2" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtDklx" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtDklxMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                经纪费税金：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtJjfsjRatio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtJjfsj" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtJjfsjMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                服务费税金：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtFwfsjRatio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtFwfsj" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtFwfsjMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它税金：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtOtherRatio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtOther" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtOtherMark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其它项1：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther1Ratio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther1" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther1Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其他项2：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther2Ratio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther2" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther2Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其他项3：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther3Ratio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther3" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther3Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其他项4：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther4Ratio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther4" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther4Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                其他项5：
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther5Ratio" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox Enabled="false" ID="TxtExpOther5Mark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="rightSum">
                            <td style="color: Blue" colspan="5">
                                支出合计：￥<asp:Literal ID="LtrExp" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</div>
