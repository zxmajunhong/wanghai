<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFundsAllocationPre.ascx.cs" Inherits="EtNet_Web.Pages.Financial.UCFundsAllocationPre" %>


<div style="background: url('../../../Images/public/title_hover.png') no-repeat;
        text-align: left; height: 25px;">
        <span style="color: #FFFFFF; padding-left: 5px; font-size: 12px; font-weight: bold;
            line-height: 25px">资金分摊</span>
    </div>
    <div class="border">
        <span style="display: block; width: 100%; text-align: right;"><span style="float: left;">
            共2步，正在执行第2步 </span>
            <asp:ImageButton ID="BtnSubmit" OnClientClick="return readData();"
                runat="server" ImageUrl="~/Images/button/btn_save.jpg" ToolTip="保存" 
            onclick="BtnSubmit_Click" />
            <a href="../FundsAllocation.aspx" title="取消认领">
                <img alt="取消认领" src="../../../Images/button/btn_cancel.jpg" /></a> </span>
        <div style="border:1px solid #CDC9C9;">
            <table id="dataBox">
                <tr>
                    <th>
                        业务员：
                    </th>
                    <td>
                        <asp:Label ID="LblSalesman" runat="server" Text="Label"></asp:Label>
                    </td>
                    <th>
                        付款单位：
                    </th>
                    <td>
                        <asp:Label ID="LblPayer" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        收款类别：
                    </th>
                    <td>
                        <asp:Label ID="LblReceiptType" runat="server" Text="Label"></asp:Label>
                    </td>
                    <th>
                        收款金额：
                    </th>
                    <td>
                        <asp:Literal ID="LtrAmount" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border:1px solid #CDC9C9;margin-top:20px;padding:10px;">
            <div style="width:100%;text-align:left;">
                <a href="javascript:void(0);" title="选择保单" id="selectPolicy">
                    <img alt="" src="../../../Images/public/fileadd.gif" />
                    选择保单
                </a>
            </div>

            <table id="mytable2" style="text-align: center;" cellspacing="1" class="mytable">
                <thead>
                    <tr>
                        <th class="clstitleimg" style="border-right:1px solid #B9D3EE;">
                            删除
                        </th>
                        <th class="clstitleimg" style="border-right:1px solid #B9D3EE;">
                            保单编号
                        </th>
                        <th class="clstitleimg"  style="border-right:1px solid #B9D3EE;">
                            费用金额
                        </th>
                        <th class="clstitleimg"  style="border-right:1px solid #B9D3EE;">
                            应收金额
                        </th>
                    </tr>
                </thead>
                <tbody id="policyList">
                    <tr>
                        <td>ad</td>
                        <td>dsad</td>
                        <td>sdasd</td>
                        <td>asdas</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>