<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAuditRole.aspx.cs"
    Inherits="Pages.SysSet.AuditRole.ShowAuditRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看审批流程</title>
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
            border: 1px solid #CDC9C9;
        }
        .toptitletxt
        {
            color: White;
            padding-left: 5px;
            font-size: 12px;
            font-weight: bold;
            width: 100px;
        }
        .clsmtxt
        {
            display: inline-block;
            width: 400px;
            line-height:20px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
        .clstxt
        {
            display: inline-block;
            width: 200px;
            line-height:20px;
            border: 0;
            border-bottom: 1px solid #C6E2FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="clstop">
        <div style="background-image: url('../../../Images/public/title_hover.png'); background-repeat: no-repeat;
            height: 25px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                  <td class="toptitletxt">查看审批流程</td>
                </tr>
            </table>
        </div>
        <div style="background: #4CB0D5; height: 5px;">
        </div>
        <div class="clsbottom">
            <div style="text-align: right">
                <asp:ImageButton runat="server" ID="imgbtnback" ImageUrl="../../../Images/Button/btn_back.jpg"
                    OnClick="imgbtnback_Click" />
            </div>
            <table class="clsdata">
                <tr>
                    <td style="width:80px; height:24px;">流程名称:</td>
                    <td>
                       <asp:Label ID="iptcname" CssClass="clstxt" runat="server"></asp:Label>
                    </td>
                    <td style="width:80px;">所属分类:</td>      
                    <td>
                      <asp:Label ID="iptsort" CssClass="clstxt" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td  style="height:24px;">关联工作流:</td>  
                    <td>
                      <asp:Label ID="iptjobflow" CssClass="clstxt" runat="server"></asp:Label>
                    </td>
                    <td>
                       所属部门:
                    </td>
                    <td>
                      <asp:Label ID="iptdepart" CssClass="clstxt" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                  <td>流程描述:</td>
                  <td colspan="3">
                     <asp:Label ID="iptremark" CssClass="clsmtxt"  runat="server"></asp:Label>
                  </td>
                </tr>

                <tr>
                    <td colspan="4">
                        审批流程图
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div id="auditpic" style="border: 1px solid #C6E2FF;" runat="server">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
